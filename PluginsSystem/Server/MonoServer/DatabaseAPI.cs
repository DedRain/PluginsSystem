using System;
using System.IO;
using System.Text;
using System.CodeDom;
using System.Collections;
using System.ComponentModel;

namespace MonoServer
{
    public class DatabaseSettings
    {
        public string ServerName;
        public string DatabaseName;
        public string UserName;
        public string Password;

        public DatabaseSettings()
        {
            ServerName = "127.0.0.1";
            DatabaseName = "test";
            UserName = "root";
        }
    }

    /// <summary>
    /// Database query.
    /// </summary>
    public struct DatabaseQuery
    {
        /// <summary>
        /// The name of the table.
        /// </summary>
        public string TableName;

        /// <summary>
        /// The other parametres.
        /// </summary>
        public string OtherParametres;
    }

    /// <summary>
    /// Database AP.
    /// </summary>
	static public class DatabaseAPI
	{
        static string m_connectionString = "";

        static DatabaseSettings settings;

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        static public string ConnectionString
        {
            get{return m_connectionString;}
        }

        /// <summary>
        /// Selects from database.
        /// </summary>
        /// <returns>
        /// The from database.
        /// </returns>
        /// <param name='query'>
        /// Query.
        /// </param>
        static public object SelectFromDatabase(DatabaseQuery query)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Server=" + settings.ServerName + ";");
                builder.Append("Database=" + settings.DatabaseName + ";");
                builder.Append("User=" + settings.UserName + ";");
                builder.Append("Password=" + settings.Password + ";");
                string ConnectionString = builder.ToString();
            }
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Inserts the into database.
        /// </summary>
        /// <param name='query'>
        /// Query.
        /// </param>
        /// <param name='Data'>
        /// Data.
        /// </param>
        static public void InsertIntoDatabase(DatabaseQuery query, object Data)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Server=localhost;");
                builder.Append("Database=" + settings.DatabaseName + ";");
                builder.Append("User=" + settings.UserName + ";");
                builder.Append("Password=" + settings.Password + ";");
                string ConnectionString = builder.ToString();
            }
            catch (Exception ex)
            {
                MainClass.Crashlog.WriteLog(ex.ToString());
            }
        }
	}
}

