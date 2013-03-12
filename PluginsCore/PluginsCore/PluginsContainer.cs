using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using PluginsCore.MEFComponents;
using System.ComponentModel.Composition.Hosting;

namespace PluginsCore
{
    public class PluginsContainer
    {
        [ImportMany(typeof(IPlugin))]
        private IEnumerable<Lazy<IPlugin>> _Plugins;

        private bool __init_Plugins;
        public IEnumerable<Lazy<IPlugin>> Plugins
        {
            get
            {
                if (!__init_Plugins)
                {
                    var catalog = new AggregateCatalog();
                    DirectoryCatalog c = new DirectoryCatalog(@"C:\Users\adushelubov\Documents\visual studio 2010\Projects\PluginsCore\PluginsCore\Plugins");
                    catalog.Catalogs.Add(c);
                    var container = new CompositionContainer(catalog);
                    container.ComposeParts(this);
                    __init_Plugins = true;
                }
                return _Plugins;
            }
        }

        public IEnumerable<IPlugin> GetPlugins(PluginType pluginType)
        {
            return Plugins.Where(v => v.Value.PluginType.Equals(pluginType)).Select(v => v.Value);
        }
    }
}
