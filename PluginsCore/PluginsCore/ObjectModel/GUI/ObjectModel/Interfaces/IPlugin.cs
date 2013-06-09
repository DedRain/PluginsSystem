using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginsCore.MEFComponents;
using System.Reflection;
using System.Runtime.Serialization;

namespace PluginsCore
{
    /// <summary>
    /// Плагин
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// ID типа плагина
        /// </summary>
        Guid ID
        {
            get;
        }

        /// <summary>
        /// Имя плагина
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Тип плагина
        /// </summary>
        PluginType PluginType
        {
            get;
            set;
        }

        /// <summary>
        /// Сборка плагина
        /// </summary>
        Assembly PluginAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// Данные внутри плагина
        /// </summary>
        dynamic Data
        {
            get;
            set;
        }

        /// <summary>
        /// Инициализация экземпляра
        /// </summary>
        void Initialize();

        /// <summary>
        /// Обработка данных
        /// </summary>
        /// <param name="data">Данные для обработки</param>
        /// <returns>Обработанные данные</returns>
        dynamic DataProcessing(dynamic data);
    }
}
