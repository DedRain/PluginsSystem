using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace MonoServer
{

	public class Settings
	{
        string filename = "settings.xml";
        public NetworkSettings net = new NetworkSettings();
        public DatabaseSettings db = new DatabaseSettings();



        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.Settings"/> class.
        /// </summary>
		public Settings ()
		{

		}

        /// <summary>
        /// Loads the settings from file.
        /// </summary>
        public Settings LoadSettingsFromFile(StringBuilder path = null)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
                if (path != null)
                    filename = path + filename;

                XmlTextReader reader = new XmlTextReader(filename);
                Settings obj = (Settings)deserializer.Deserialize(reader);
                reader.Close();
                return obj;
            } 
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Saves the settings to file.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public void SaveSettingsToFile(StringBuilder path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                FileStream stream = File.OpenWrite(filename);
                serializer.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// Applies the settings.
        /// </summary>
        /// <returns>
        /// The settings.
        /// </returns>
        public bool ApplySettings()
        {
            return true;
        }
	}
}

