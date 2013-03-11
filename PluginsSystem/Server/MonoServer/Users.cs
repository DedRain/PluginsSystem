using System;
using System.Net.Sockets;

namespace MonoServer
{
	public class User
	{
		Socket ConnectionWithUser;
		int m_premissions;

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <value>
        /// The permissions.
        /// </value>
		public int Permissions 
		{
			get{return m_premissions;}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.User"/> class.
        /// </summary>
		public User ()
		{

		}

        /// <summary>
        /// Users the login.
        /// </summary>
        /// <returns>
        /// The login.
        /// </returns>
		public bool UserLogin()
		{
			return true;
		}

        /// <summary>
        /// Users the logout.
        /// </summary>
        /// <returns>
        /// The logout.
        /// </returns>
		public bool UserLogout()
		{
			return true;
		}

        /// <summary>
        /// Users the send.
        /// </summary>
        /// <returns>
        /// The send.
        /// </returns>
        public int UserSend()
        {
            return 0;
        }

        /// <summary>
        /// Users the recieve.
        /// </summary>
        /// <returns>
        /// The recieve.
        /// </returns>
        public int UserRecieve()
        {
            return 0;
        }

        /// <summary>
        /// Users the action.
        /// </summary>
        /// <returns>
        /// The action.
        /// </returns>
        /// <param name='packet'>
        /// If set to <c>true</c> packet.
        /// </param>
        public bool UserAction(NetworkPacket packet)
        {
            return true;
        }
	}

	public class Moder : MonoServer.User
	{

	}

	public class Admin : MonoServer.Moder
	{

	}
}