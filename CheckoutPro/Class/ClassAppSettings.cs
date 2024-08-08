using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckoutPro.Class
{
    public class ClassAppSettings
    {
        public string Version { get; set; }
        public string Key { get; set; }
        public bool Darkmode { get; set; }
        public bool PrintseperatLabels { get; set; }
        public bool SaveDatabaseonClose { get; set; }
        public bool ClearPrinterHistory { get; set; }
        public string Basicprinter { get; set; }
        public bool StartFullscreen { get; set; }
        public bool Print1x { get; set; }


        public static void Save(ClassAppSettings settings, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ClassAppSettings));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, settings);
            }
        }

        public static ClassAppSettings Load(string filePath)
        {
            if (!File.Exists(filePath))
                return new ClassAppSettings();

            XmlSerializer serializer = new XmlSerializer(typeof(ClassAppSettings));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (ClassAppSettings)serializer.Deserialize(reader);
            }
        }
    }
}
