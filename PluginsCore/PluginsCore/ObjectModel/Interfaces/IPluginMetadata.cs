using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsCore
{
    public interface IPluginMetadata
    {
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

        /// <summary>
        /// Тип плагина
        /// </summary>
        PluginType PluginType
        {
            get;
            set;
        }

        /// <summary>
        /// Данные передаваемые при подключении
        /// </summary>
        object ThroughData
        {
            get;
            set;
        }
    }
}
