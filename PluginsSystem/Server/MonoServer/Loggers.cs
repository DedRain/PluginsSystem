using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using System.ComponentModel;

namespace MonoServer
{
    /// <summary>
    /// Logger provides functionality for logging any infomation.
    /// </summary>
	public class Logger
	{
		private string logfile_name = "";
		private FileInfo logfile_info = null;
		private FileStream logfile_writer = null;
        private int message_count = 0;

        /// <summary>
        /// Gets the name of the log file_.
        /// </summary>
        /// <value>
        /// The name of the log file_.
        /// </value>
		public string LogFile_Name 
		{
			get{ return logfile_name;}
		}

        /// <summary>
        /// Gets the log file info.
        /// </summary>
        /// <value>
        /// The log file info.
        /// </value>
		public FileInfo LogFileInfo 
		{
			get{return logfile_info;}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.Logger"/> class.
        /// </summary>
		public Logger ()
		{
            logfile_name = DateTime.Now.ToShortDateString() + ".log";

            if(File.Exists(logfile_name))
               logfile_writer = File.OpenWrite(logfile_name);
            else 
                logfile_writer = File.Create(logfile_name);
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MonoServer.Logger"/> class.
        /// </summary>
        /// <param name='logname'>
        /// Logname.
        /// </param>
		public Logger(string logname)
		{
			logfile_name = logname;

			if(File.Exists(logname))
			   logfile_writer = File.OpenWrite(logname);
			else 
				logfile_writer = File.Create(logname);
		}

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name='text'>
        /// Text.
        /// </param>
		public void WriteLog(string text)
        {
            try
            {
                logfile_writer.Write(Encoding.Default.GetBytes(DateTime.Now.ToShortDateString() + "\t" + DateTime.Now.ToShortTimeString() + "\n"
                                                            + text + "\n"),0,Encoding.Default.GetByteCount(DateTime.Now.ToShortDateString() + "\n" + text + "\n"));
                /*if (message_count < Common.COUNT_MAX_LOG_MESSAGES)
                    ++message_count;
                else 
                    FlushLog();*/
            } catch (Exception ex)
            {
                new Logger("Logger_Crash.log").WriteLog(ex.ToString());
            }

		}

        /// <summary>
        /// Flushs the log.
        /// </summary>
        /// <returns>
        /// The log.
        /// </returns>
        public bool FlushLog()
        {
            logfile_writer.Flush(true);
            return true;
        }
	}
}

