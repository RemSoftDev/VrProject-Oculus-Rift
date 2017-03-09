using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ComPortPackages.Core.Serialization.Abstract;

namespace ComPortPackages.Core.Serialization.Impl
{
    public class SerializationService : ISerializationService
    {
        public Stream Serialize<TObject>(TObject @object, SerializationType serializationType)
            where TObject : class
        {
            try
            {
                switch (serializationType)
                {
                    case SerializationType.Xml:
                        return XmlSerialize(@object);
                    case SerializationType.Binary:
                        return BinarySerialize(@object);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(serializationType), serializationType, null);
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }

        public TObject Deserialize<TObject>(Stream stream, SerializationType serializationType)
            where TObject : class
        {
            try
            {
                switch (serializationType)
                {
                    case SerializationType.Xml:
                        return XmlDeserialize<TObject>(stream);
                    case SerializationType.Binary:
                        return BinaryDeserialize<TObject>(stream);
                    default:
                        throw new ArgumentOutOfRangeException(nameof(serializationType), serializationType, null);
                }
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }

        private Stream XmlSerialize<TObject>(TObject @object) where TObject : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(TObject));
                Stream stream = new MemoryStream();
                serializer.Serialize(stream, @object);
                return stream;
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }

        private Stream BinarySerialize<TObject>(TObject @object) where TObject : class
        {
            try
            {
                var serializer = new BinaryFormatter();
                Stream stream = new MemoryStream();
                serializer.Serialize(stream, @object);
                return stream;
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }

        private TObject XmlDeserialize<TObject>(Stream stream) where TObject : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(TObject));
                TObject result;

                stream.Position = 0;

                var xml = string.Empty;

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    xml = reader.ReadToEnd();
                }
                using (var reader = XmlReader.Create(new StringReader(xml)))
                {
                    result = (TObject)serializer.Deserialize(reader);
                }
                return result;
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }

        private TObject BinaryDeserialize<TObject>(Stream stream) where TObject : class
        {
            try
            {
                var serializer = new BinaryFormatter();

                stream.Position = 0;

                var result = (TObject)serializer.Deserialize(stream);
                return result;
            }
            catch (Exception ex)
            {
                CallBacker.CallBackException?.Invoke(ex);
                return null;
            }
        }
    }
}