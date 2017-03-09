using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrManager.Helpers
{
    public static class FolderHelper
    {
        static FolderHelper()
        {
            if (AdvertisingVideo == string.Empty || AdvertisingVideo == null)
            {
                CreateFolders(App.Setting.PathToFolderFiles);
            }
        }

        public static string AdvertisingVideo { get; private set; }
        public static string BannerVideo { get; private set; }
        public static string Config { get; private set; }
        public static string ConfigBackground { get; private set; }
        public static string ConfigDataBase { get; private set; }
        public static string ConfigIcon { get; private set; }
        public static string ConfigImageIcon { get; private set; }
        public static string ConfigSettingPlayer { get; private set; }
        public static string ConfigVidoIcon { get; private set; }
        public static string Games { get; private set; }
        public static string Logs { get; private set; }
        public static string Moution { get; private set; }
        public static string MoutionGames { get; private set; }
        public static string MoutionVideo360 { get; private set; }
        public static string MoutionVideo5D { get; private set; }
        public static string Video { get; private set; }
        public static string Video360 { get; private set; }
        public static string Video5D { get; private set; }

        public static void CreateFolders(string path)
        {
            try
            {
                Config = path + @"\Config";
                Logs = Config + @"\Logs";
                Games = path + @"\Games";
                Moution = path + @"\Moution";
                Video = path + @"\Video";
                ConfigBackground = Config + @"\Background";
                ConfigDataBase = Config + @"\DataBase";
                ConfigIcon = Config + @"\Icon";
                ConfigSettingPlayer = Config + @"\SettingPlayer";
                ConfigImageIcon = ConfigIcon + @"\ImageIcon";
                ConfigVidoIcon = ConfigIcon + @"\VidoIcon";
                MoutionGames = Moution + @"\Games";
                MoutionVideo5D = Moution + @"\Video5D";
                MoutionVideo360 = Moution + @"\Video360";
                Video5D = Video + @"\Video5D";
                Video360 = Video + @"\Video360";
                BannerVideo = Video + @"\BannerVideo";
                AdvertisingVideo = Video + @"\AdvertisingVideo";

                CreateIfNotExist(Config);
                CreateIfNotExist(Logs);
                CreateIfNotExist(Games);
                CreateIfNotExist(Moution);
                CreateIfNotExist(Video);
                CreateIfNotExist(ConfigBackground);
                CreateIfNotExist(ConfigDataBase);
                CreateIfNotExist(ConfigIcon);
                CreateIfNotExist(ConfigSettingPlayer);
                CreateIfNotExist(ConfigImageIcon);
                CreateIfNotExist(ConfigVidoIcon);
                CreateIfNotExist(MoutionGames);
                CreateIfNotExist(MoutionVideo5D);
                CreateIfNotExist(MoutionVideo360);
                CreateIfNotExist(Video5D);
                CreateIfNotExist(Video360);
                CreateIfNotExist(BannerVideo);
                CreateIfNotExist(AdvertisingVideo);
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        private static void CreateIfNotExist(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }
    }
}
