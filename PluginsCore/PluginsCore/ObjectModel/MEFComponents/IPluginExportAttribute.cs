using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace PluginsCore.MEFComponents
{
    /// <summary>
    /// Аттрибут экспорта плагина
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class IPluginExportAttribute : ExportAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип интерфейса который реализует плагин</param>
        public IPluginExportAttribute(Type type)
            : base(type)
        {
        }
    }
}