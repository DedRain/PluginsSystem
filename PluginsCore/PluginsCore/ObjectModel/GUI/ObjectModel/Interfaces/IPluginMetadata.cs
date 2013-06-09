using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsCore
{
    /// <summary>
    /// Метаданные о плагине и сборке
    /// </summary>
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
        /// ID плагина
        /// </summary>
        Guid PluginID
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
    }
}
