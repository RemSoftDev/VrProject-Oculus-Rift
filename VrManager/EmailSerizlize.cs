using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VrManager
{
    [Serializable]
    public class OptionData
    {
        public string Email { get; set; }

    }
    public static class Serializer
    {
        static XmlSerializer formatter = new XmlSerializer(typeof(OptionData));

        public static void Serilize(OptionData serializeObject)
        { // получаем поток, куда будем записывать сериализованный объект
            try
            {
                using (FileStream fs = new FileStream("OptionData.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, serializeObject);
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
            }
        }

        public static OptionData Desirialize()
        {
            try
            {
                using (FileStream fs = new FileStream("OptionData.xml", FileMode.OpenOrCreate))
                {
                    OptionData email = (OptionData)formatter.Deserialize(fs);
                    return email;
                }
            }
            catch (Exception ex)
            {
                App.SendException(ex);
                return null; 
            }
        }
    }
}
