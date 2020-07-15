using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace DP_HIT_2020A_Ex03
{
    public class AppSettings
    {
        private const string k_Location = @"D:\FacebookApplicationSettings.xml";

        public Point LastWindowLocation { get; set; }

        public Size LastWindowSize { get; set; }

        public bool RememberUser { get; set; }

        public string LastAccessToken { get; set; }

        private AppSettings()
        {
            LastWindowLocation = new Point(20, 50);
            LastWindowSize = new Size(1000, 500);
            RememberUser = false;
            LastAccessToken = null;
        }

        public static AppSettings LoadFromFile()
        {
            AppSettings appSettings = new AppSettings();
            if (File.Exists(k_Location))
            {
                using (Stream stream = new FileStream(k_Location, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                    appSettings = xmlSerializer.Deserialize(stream) as AppSettings;
                }
            }

            return appSettings;
        }

        public void SaveToFile()
        {
            if (File.Exists(k_Location))
            {
                using (Stream stream = new FileStream(k_Location, FileMode.Truncate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                    xmlSerializer.Serialize(stream, this);
                }
            }
            else
            {
                using (Stream stream = new FileStream(k_Location, FileMode.CreateNew))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                    xmlSerializer.Serialize(stream, this);
                }
            }
        }
    }
}
