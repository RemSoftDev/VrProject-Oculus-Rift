﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VrManager.Data.Abstract;
using VrManager.Data.Entity;

namespace VrManager.Helpers
{
    public class StisticFormatHelper
    {
        public static List<StatisticItem> StatisticItemFactory(IEnumerable<ModelObserve> observItems)
        {
            List<StatisticItem> staticItems = new List<StatisticItem>();

            foreach(ModelObserve item in observItems)
            {
                staticItems.Add(new StatisticItem(item));
            }

            return staticItems;
        }
    }

   public class StatisticItem
   {
        public StatisticItem(ModelObserve observe)
        {
            try
            {
                Id = observe.ObserveId;
                Name = observe.Name;
                TypeItem = GetTypeItem(observe.TypeItem);
                Duration = GetDuration(observe.Duration);
                PC = GetPC(observe.PC);
                TimeStart = GetTimeStart(observe.TimeStart);
                TimePause = GetTimePause(observe.TimePause);
                TimeStop = GetTimeStop(observe.TimeStop);
                PressStartCounter = observe.PressStartCouner;
                PressPauseCounter = observe.PressPauseCouner;
                Halted = GetHalted(observe.Halted);
                Manager = GetManager(observe.User);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private TimeSpan? GetTimeStop(DateTime? timeStop)
        {
            try
            {
                return timeStop?.TimeOfDay;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private TimeSpan? GetTimePause(DateTime? timePause)
        {
            try
            {
                return timePause?.TimeOfDay;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private TimeSpan? GetTimeStart(DateTime? timeStart)
        {
            try
            {
                return timeStart?.TimeOfDay;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private string GetManager(ModelUser user)
        {
            try
            {
                return user?.Login;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private string GetHalted(Halted? halted)
        {
            try
            {
                switch (halted)
                {

                    case VrManager.Data.Entity.Halted.AfterTime:
                        {
                            return "По истечению времини";
                        }
                    case VrManager.Data.Entity.Halted.Manual:
                        {
                            return "Вручную";
                        }
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private string GetPC(PC pc)
        {
            try
            {
                switch (pc)
                {

                    case VrManager.Data.Entity.PC.PC1:
                        {
                            return "ПК1";
                        }
                    case VrManager.Data.Entity.PC.PC2:
                        {
                            return "ПК2";
                        }
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }
        private TimeSpan GetDuration(DateTime duration)
        {
            try
            {
                return duration.TimeOfDay;
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return new TimeSpan();
            }
        }
        private string GetTypeItem(TypeItem? typeItem)
        {
            try
            {
                switch (typeItem)
                {

                    case VrManager.Data.Abstract.TypeItem.Video360:
                        {
                            return "Видео 360";
                        }
                    case VrManager.Data.Abstract.TypeItem.Video5D:
                        {
                            return "Видео 5D";
                        }
                    case VrManager.Data.Abstract.TypeItem.Game:
                        {
                            return "Игра";
                        }
                    default:
                        return "";
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeItem { get; set; }
        public TimeSpan Duration { get; set; }
        public string PC { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimePause { get; set; }
        public TimeSpan? TimeStop { get; set; }
        public int? PressStartCounter { get; set; }
        public int? PressPauseCounter { get; set; }
        public string Halted { get; set; }
        public string Manager { get; set; }
   }
}
