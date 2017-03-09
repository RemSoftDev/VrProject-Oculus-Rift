using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VrManager.Data.Abstract;

namespace VrManager.Service
{
    class ClientService
    {
        private IRemoteVideoCommand channel;

        public ClientService()
        {
            try
            {
                Uri address = new Uri("http://localhost:4000/IManagerComand");  // ADDRESS.   (A)

                // Указание, как обмениваться сообщениями.
                BasicHttpBinding binding = new BasicHttpBinding();         // BINDING.   (B)

                // Создание Конечной Точки.
                EndpointAddress endpoint = new EndpointAddress(address);

                // Создание фабрики каналов.
                ChannelFactory<IRemoteVideoCommand> factory = new ChannelFactory<IRemoteVideoCommand>(binding, endpoint);  // CONTRACT.  (C) 

                // Использование factory для создания канала (прокси).
                channel = factory.CreateChannel();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void Pause()
        {
            try
            {
                channel.Pause();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        public void Play()
         {
            try
            {
                channel.Play();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
        
        public void Stop()
        {
            try
            {
                channel.Stop();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void ChangeSize()
        {
            try
            {
                channel.ChangeSize();
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public void ChangeToampostMode(bool mode)
        {
            try
            {
                channel.ChangeToampostMode(mode);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

    }
}
