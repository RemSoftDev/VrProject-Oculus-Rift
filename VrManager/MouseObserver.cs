using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VrManager.Data.Abstract;
using VrManager.Data.Entity;

namespace VrManager.Helpers
{
    public class Observer
    {
        private static ProcessorHelper _itemProcess; 
        private static TypeItem _typeItem;

        public static bool IsObservGame { get; private set; } = false;
        public static void StartObserv()
        {
            try
            {
                if (_typeItem == TypeItem.Game)
                {
                    if ((_itemProcess as GameProcessor).Game.TypeStartFocus != TypeStartFocus.FocusToMainWnd)
                    {
                        IsObservGame = true;
                    }
                }
                else
                {
                    IsObservGame = true;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        public static void EndObserv()
        {
            try
            {
                IsObservGame = false;
                addRecordToStatistic();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }     
        public static void SetItem(ProcessorHelper item)
        {
            try
            {
                _itemProcess = item;

                if (_itemProcess is GameProcessor)
                {
                    _typeItem = TypeItem.Game;
                }
                else
                {
                    OpenVrPleyerHelper VideoItem = item as OpenVrPleyerHelper;
                    _typeItem = VideoItem.Video.TypeItem.Value;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }

        }
        public static void ObservIteration()
        {
            try
            {
                if (IsObservGame)
                {
                    if (_typeItem == TypeItem.Game)
                    {
                        IntPtr gameHandle = WinAPI.FindWindow(null, (_itemProcess as GameProcessor).Game.NameProcess);
                        WinAPI.SwitchToThisWindow(gameHandle, true);
                        WinAPI.SetForegroundWindow(gameHandle);
                    }
                    else
                    {
                        IntPtr videoHandle = WinAPI.FindWindow(null, "VR Player");
                        WinAPI.ShowWindow(videoHandle, 3);
                        WinAPI.SetForegroundWindow(videoHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private static void addRecordToStatistic()
        {
            try
            {
                string name = _itemProcess is GameProcessor ?
                (_itemProcess as GameProcessor).Game.Name : (_itemProcess as OpenVrPleyerHelper).Video.Name;

                if (_typeItem == TypeItem.Video360)
                {
                    _typeItem = (_itemProcess as OpenVrPleyerHelper).Video.TypeItem.Value;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }

        }
    }
}
