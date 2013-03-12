using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginsCore.MEFComponents;
using System.Reflection;

namespace PluginsCore
{
    /// <summary>
    /// Плагин
    /// </summary>
    public interface IPlugin
    {
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
        /// Инициализация экземпляра
        /// </summary>
        void Initialize();

        /// <summary>
        /// Обработка данных
        /// </summary>
        /// <param name="data">Данные для обработки</param>
        /// <returns>Обработанные данные</returns>
        object DataProcessing(object data);
    }
}
