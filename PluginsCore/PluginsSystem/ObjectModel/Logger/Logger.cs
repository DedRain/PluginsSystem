using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PluginsSystem.ObjectModel.Database;

namespace PluginsCore.Logger
{
    /// <summary>
    /// Функционал логирования
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Запись события в базу
        /// </summary>
        /// <param name="eventText">Текст события</param>
        public static void HandleEvent(string eventText)
        {
            Thread writer = new Thread((ThreadStart)delegate()
                {
                    try
                    {
                        
                        //запись события в базу
                    }
                    catch (Exception ex)
                    {
                        //обработка внутренней ошибки
                        Logger.HandleException(ex);
                    }
                });
            writer.Start(); 
        }

        /// <summary>
        /// Запись ошибки в базу
        /// </summary>
        /// <param name="ex">Ошибка</param>
        public static void HandleException(Exception ex)
        {
            
            Thread writer = new Thread((ThreadStart)delegate()
            {
                try
                {
                    //запись события в базу
                }
                catch (Exception e)
                {
                    //обработка внутренней ошибки
                    throw e;
                }
            });
            writer.Start();
        }
    }
}
