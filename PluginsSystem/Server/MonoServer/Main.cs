using System;
using System.Text;

namespace MonoServer
{
	class MainClass
	{
        static public Logger Crashlog = new Logger();
        static public Settings settings = new Settings();

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name='args'>
        /// The command-line arguments.
        /// </param>
		public static void Main(string[] args)
        {
            try
            {
                settings = settings.LoadSettingsFromFile();
            } 
            catch (Exception ex)
            {
                Crashlog.WriteLog(ex.ToString());
            } 
            finally
            {
                Crashlog.FlushLog();
                settings.SaveSettingsToFile(null);
            }
		}
	}
}
