using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace PluginsCore.MEFComponents
{
    /// <summary>
    /// Аттрибут импорта плагина
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class IPluginImportAttribute : ImportAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип интерфейса который реализует плагин</param>
        public IPluginImportAttribute(Type type)
            : base(type)
        {
        }
    }
}
