using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace PluginsCore
{
    /// <summary>
    /// Класс настроек ядра
    /// </summary>
    [Serializable]
    public static class Settings
    {
        private static string _ConnectionString;
        /// <summary>
        /// Подключение к базу данных
        /// </summary>
        public static string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private static DateTime _LastUpdate;
        /// <summary>
        /// Время последнего обновления
        /// </summary>
        public static DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }

        private static string _PluginsDirectory;
        /// <summary>
        /// Директория для сторонних плагинов
        /// </summary>
        public static string PluginsDirectory
        {
            get 
            {
                if(string.IsNullOrEmpty(_PluginsDirectory))
                    _PluginsDirectory = @"D:\Dev\GitRepo\PluginsSystem\PluginsCore\PluginsCore\bin\Debug\Plugins";
                return _PluginsDirectory;
            }
            set { _PluginsDirectory = value; }
        }

        private static string _UpdateServer;
        /// <summary>
        /// Url сервера обновлений
        /// </summary>
        public static string UpdateServer
        {
            get { return _UpdateServer; }
            set { _UpdateServer = value; }
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <returns>Результат сохранения</returns>
        public static bool Save()
        {
            //сохранение настроек в базу
            return true;
        }

        /// <summary>
        /// Загрузка настроек
        /// </summary>
        public static void Load()
        {

        }

        /// <summary>
        /// Сброс настроек до начального значения
        /// </summary>
        public static void ResetToDefault()
        {

        }

        /// <summary>
        /// Применение настроек
        /// </summary>
        /// <returns>Результат применения</returns>
        public static ValidationResult Apply()
        {
            return new ValidationResult();
        }

        /// <summary>
        /// Обновление плагина(-ов)
        /// </summary>
        public static void Update(IPlugin plugin = null)
        {
            Thread updater = null;
            if (plugin == null)
            {
                updater = new Thread((ThreadStart)delegate()
                    {
                        //обновление сборок плагинов
                    });
            }
            else
            {
                updater = new Thread((ThreadStart)delegate()
                {
                    //обновление сборки конкретного плагина
                });
            }

            updater.Start();
        }
    }
}
