using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace MonoServer
{
	public class NetworkPacket
	{
        string m_command;
        string m_type;
        string m_user;
        TimeSpan m_time_stamp;
        byte[] m_data;
        byte[] m_digital_sign;

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public string Command
        {
            get{ return m_command;}
            set
            {
                if(value != "")
                    m_command = value;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type
        {
            get{return m_type;}
             set
            {
                if(value != "")
                    m_type = value;
            }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string User
        {
            get{return m_user;}
            set
            {
                if(value != "")
                    m_user = value;
            }
        }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public TimeSpan TimeStamp
        {

            get{return m_time_stamp;}
            set
            {
                if(value != null)
                    m_time_stamp = value;
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public byte[] Data
        {
            get{return m_data;}
            set
            {
                if(value != null)
                    m_data = value;
            }
        }

        /// <summary>
        /// Gets or sets the digital sign.
        /// </summary>
        /// <value>
        /// The digital sign.
        /// </value>
        public byte[] DigitalSign
        {
            get{return m_digital_sign;}
            set
            {
                if(value != null)
                    m_digital_sign = value;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkPacket"/> class.
        /// </summary>
		public NetworkPacket ()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkPacket"/> class.
        /// </summary>
        /// <param name='command'>
        /// Command.
        /// </param>
        /// <param name='type'>
        /// Type.
        /// </param>
        /// <param name='user'>
        /// User.
        /// </param>
        /// <param name='time'>
        /// Time.
        /// </param>
        /// <param name='data'>
        /// Data.
        /// </param>
        /// <param name='sign'>
        /// Sign.
        /// </param>
        public NetworkPacket(string command,string type,string user,TimeSpan time,byte[] data,byte[] sign)
        {
            m_command = command;
            m_type = type;
            m_user = user;
            m_time_stamp = time;
            m_data = data;
            m_digital_sign = sign;
        }

        /// <summary>
        /// Serialize the specified packet.
        /// </summary>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        static public byte[] Serialize(NetworkPacket packet)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, null);
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("NetworkPacket");

                writer.WriteStartElement("Command");
                writer.WriteValue(packet.m_command);
                writer.WriteEndElement();

                writer.WriteStartElement("Type");
                writer.WriteValue(packet.m_type);
                writer.WriteEndElement();

                writer.WriteStartElement("User");
                writer.WriteValue(packet.m_user);
                writer.WriteEndElement();

                writer.WriteStartElement("TimeStamp");
                writer.WriteValue(packet.m_time_stamp.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Data");
                writer.WriteValue(packet.m_data);
                writer.WriteEndElement();

                writer.WriteStartElement("DigitalSign");
                writer.WriteValue(packet.m_digital_sign);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
                return stream.GetBuffer();
            } catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Deserialize the specified data.
        /// </summary>
        /// <param name='data'>
        /// Data.
        /// </param>
        static public NetworkPacket Deserialize(byte[] data)
        {
            NetworkPacket packet = new NetworkPacket();

            MemoryStream stream = new MemoryStream(data);
            XmlTextReader reader = new XmlTextReader(stream);
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(reader);
                XmlNode root = doc.DocumentElement;
                foreach (XmlNode child in root.ChildNodes)
                {
                    switch (child.LocalName)
                    {
                        case "Command":
                            packet.m_command = child.InnerText;
                            break;
                        case "Type":
                            packet.m_type = child.InnerText;
                            break;
                        case "User":
                            packet.m_user = child.InnerText;
                            break;
                        case "TimeStamp":
                            packet.m_time_stamp = TimeSpan.Parse(child.InnerText);
                            break;
                        case "Data":
                            packet.m_data = Encoding.UTF8.GetBytes(child.InnerText);
                            break;
                        case "DigitalSign":
                            packet.m_digital_sign = Encoding.UTF8.GetBytes(child.InnerText);
                            break;
                        default:
                            break;
                    }
                }
                return packet;
            } 
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
                return null;
            }
        }
	}
}

