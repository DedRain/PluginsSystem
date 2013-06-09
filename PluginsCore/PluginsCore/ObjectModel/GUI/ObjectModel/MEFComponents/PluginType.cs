using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsCore
{
    /// <summary>
    /// Тип плагина
    /// </summary>
    public enum PluginType
    {
        /// <summary>
        /// Плагин для логирования
        /// </summary>
        ILoggerPlugin,
        /// <summary>
        /// Плагин работы с базой данных
        /// </summary>
        IDatabasePlugin,
        /// <summary>
        /// Плагин безопасности
        /// </summary>
        ISecurityPlugin,
        /// <summary>
        /// Плагин настроек
        /// </summary>
        ISettingsPlugin,
        /// <summary>
        /// Плагин пользовательского интерфейса
        /// </summary>
        IGUIPlugin,
        /// <summary>
        /// Пользовательский плагин
        /// </summary>
        ICustomPlugin
    }
}
