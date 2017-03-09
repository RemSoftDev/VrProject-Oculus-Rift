using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using ComPortPackages.Core.Extensions;
using ComPortPackages.Core.Model;
using ComPortPackages.Core.RS232;
using log4net;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using ComPortPackages.Core;

namespace ComPortPackages.Console
{
    public class ComPortPackagesService : IDisposable
    {
        private static readonly object _syncThreadObject = new object();
        //private readonly ILog _log = LogManager.GetLogger(typeof(ComPortPackagesService));
        private readonly Queue<EffectStreamBytesSample> _messages = new Queue<EffectStreamBytesSample>();
        private readonly Package _package;
        private static Rs232Impl _rs232;
        private readonly ManualResetEvent _threadEvent = new ManualResetEvent(false);
        private SendThreadState _sendThreadState = SendThreadState.StandBy;
        private static Thread _thread;

        private int T0 = ConstantRepositoriy.T0;
        private int T1 = ConstantRepositoriy.T1;
        private int T2 = ConstantRepositoriy.T2;
        private int T3 = ConstantRepositoriy.T3;

        public TextBox TB_showProcess { get; private set; }

        public ComPortPackagesService(Rs232Impl rs232, Package package)
        {
            _rs232 = rs232;
            _package = package;
        }

        public event EventHandler Completed;

        private void OnCompleted()
        {
            try
            {
                if (Completed != null)
                {
                    Completed(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public void Dispose()
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public void Init(TextBox TB_showProcess)
        {
            try
            {
                this.TB_showProcess = TB_showProcess;
                foreach (var eStream in _package.Effect.BytesSamples)
                {
                    _messages.Enqueue(eStream);
                }
                _rs232.Open();
                _thread = new Thread(SendFunc);
                _thread.IsBackground = false;
                _thread.Start();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public void StartSender()
        {
            try
            {
                lock (_syncThreadObject)
                {
                    _sendThreadState = SendThreadState.Send;
                }
            }


            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public void StopSender()
        {
            lock (_syncThreadObject)
            {
                _sendThreadState = SendThreadState.StandBy;
            }
        }

        public void SimpleSend(byte[] buffer)
        {
            try
            {
                _rs232.Open();
                _rs232.Send(buffer);

                string s = String.Format("Данные {0} отправлены", string.Concat(buffer.Select(b => $" 0x{b.ToString("X2")}")));
                CallBacker.CallBackMessage?.Invoke(s);
                //_log.InfoFormat();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);

            }
        }


        private void SendFunc()
        {
            try
            {
                bool firstPack = true;
                int counter = 0;
                while (_sendThreadState != SendThreadState.Terminated)
                {
                    if (_sendThreadState == SendThreadState.Send)
                    {
                        if (_messages.Count > 0)
                        {
                            var message = _messages.Dequeue();
                            if (message != null)
                            {

                                _rs232.Send(message.Data.StringToByteArray());

                                CallBacker.CallBackMessage?.Invoke(String.Format("Данные {0} отправлены", message.SampleTime.ToString("HH:mm:ss")));

                                Action a = () =>
                                {
                                    TB_showProcess.Text += $"Итерацыя №{counter++} Данные {message.SampleTime.ToString("HH:mm:ss")} отправлены" + Environment.NewLine;
                                };
                                ComPrortSender.App.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, a);


                            }
                        }
                        else
                        {
                            _threadEvent.Set();
                            OnCompleted();
                        }
                        //Thread.Sleep(1000);
                    }

                    if (firstPack == false)
                    {
                        if (_messages.Count > 1)
                        {
                            Thread.Sleep(T1);
                        }

                        if (_messages.Count == 1)
                        {
                            Thread.Sleep(T2);
                        }

                        if (_messages.Count == 0)
                        {
                            Thread.Sleep(T3);
                        }
                    }
                    else
                    {
                        //после пакета инициализации
                        Thread.Sleep(T0);
                    }

                    firstPack = false;
                }

                _threadEvent.Set();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public void Close()
        {
            try
            {
                _rs232.Close();
                TerminateThread();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        private void TerminateThread()
        {
            try
            {
                lock (_syncThreadObject)
                {
                    if (_thread != null && _thread.IsAlive)
                    {
                        if (_sendThreadState != SendThreadState.Terminated)
                        {
                            _sendThreadState = SendThreadState.Terminated;
                            _threadEvent.WaitOne();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }
        }

        public static bool Pause()
        {
            try
            {
                if (_thread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    _thread?.Suspend();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return false;
            }
        }

        public static bool Resume()
        {
            try
            {
                if (_thread.ThreadState == ThreadState.Suspended)
                {
                    _thread?.Resume();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return false;
            }
        }

        public static void Stop()
        {
            try
            {
                if (_thread.ThreadState == ThreadState.Suspended)
                {
                    _thread?.Resume();
                }

                _thread?.Abort();
                _thread?.Join();
                _rs232?.Close();
                _thread?.DisableComObjectEagerCleanup();
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
            }

        }
    }
}