using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;


namespace MonoServer
{
    /// <summary>
    /// Network settings.
    /// </summary>
    public class NetworkSettings
    {
        /// <summary>
        /// The address.
        /// </summary>
        public string address;

        /// <summary>
        /// The port.
        /// </summary>
        public int port;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkSettings"/> class.
        /// </summary>
        public NetworkSettings()
        {
            address = IPAddress.Loopback.ToString();
            this.port = 55480;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkSettings"/> class.
        /// </summary>
        /// <param name='addr'>
        /// Address.
        /// </param>
        /// <param name='port'>
        /// Port.
        /// </param>
        public NetworkSettings(string addr,int port)
        {
            address = addr;
            this.port = port;
        }
    }

    /// <summary>
    /// Network API class provides funcionality for network .
    /// </summary>
	public class NetworkAPI
	{
        IPAddress address = null;
        int port = 55480;
		TcpListener listener;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkAPI"/> class.
        /// </summary>
		public NetworkAPI()
        {
            address = IPAddress.Loopback;
            try
            {
                listener = new TcpListener(address, port);
                listener.Start();
                listener.BeginAcceptSocket(OnAcceptCallback, listener);
            } catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkAPI"/> class.
        /// </summary>
        /// <param name='addr'>
        /// Address.
        /// </param>
        /// <param name='port'>
        /// Port.
        /// </param>
        public NetworkAPI(IPAddress addr, int port)
        {
            address = addr;
            this.port = port;
            try
            {
                listener = new TcpListener(address, port);
                listener.Start();
                listener.BeginAcceptSocket(OnAcceptCallback, listener);
            } 
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.NetworkAPI"/> class.
        /// </summary>
        /// <param name='setting'>
        /// Setting.
        /// </param>/
        public NetworkAPI(NetworkSettings setting)
        {
            address = IPAddress.Parse(setting.address);
            port = setting.port;
            try
            {
                listener = new TcpListener(address, port);
                listener.Start();
                listener.BeginAcceptSocket(OnAcceptCallback, listener);
            } 
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
        }

        /// <summary>
        /// Raises the accept callback event.
        /// </summary>
        /// <param name='ar'>
        /// Ar.
        /// </param>
		void OnAcceptCallback(IAsyncResult ar)
		{
			//Reference to login method
		}

        /// <summary>
        /// Raises the close callback event.
        /// </summary>
        /// <param name='socket'>
        /// Socket.
        /// </param>
        public void OnCloseCallback(Socket socket)
        {

        }

        /// <summary>
        /// Sends the data.
        /// </summary>
        /// <returns>
        /// The data.
        /// </returns>
        /// <param name='socket'>
        /// Socket.
        /// </param>
        /// <param name='data'>
        /// Data.
        /// </param>
        public int SendData(Socket socket, byte[] data)
        {
            return 0;
        }

        /// <summary>
        /// Sends the data.
        /// </summary>
        /// <returns>
        /// The data.
        /// </returns>
        /// <param name='socket'>
        /// Socket.
        /// </param>
        /// <param name='Message'>
        /// Message.
        /// </param>
        public int SendData(Socket socket,string Message)
        {
            return 0;
        }

        /// <summary>
        /// Sends the data.
        /// </summary>
        /// <returns>
        /// The data.
        /// </returns>
        /// <param name='socket'>
        /// Socket.
        /// </param>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public int SendData(Socket socket,NetworkPacket packet)
        {
            return 0;
        }

	}
}

