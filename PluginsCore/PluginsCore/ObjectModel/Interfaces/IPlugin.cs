using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginsCore.MEFComponents;

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
        /// Автор плагина
        /// </summary>
        string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Название сборки
        /// </summary>
        string AssemblyName
        {
            get;
            set;
        }

        /// <summary>
        /// Версия сборки
        /// </summary>
        string AssemblyVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Идентификационный ключ сборки
        /// </summary>
        string AssemblyKey
        {
            get;
            set;
        }

        object ThroughData
        {
            get;
            set;
        }

        /// <summary>
        /// Инициализация экземпляра
        /// </summary>
        void Initialize();
    }
}
