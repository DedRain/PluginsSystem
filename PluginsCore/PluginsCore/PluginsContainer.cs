using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using PluginsCore.MEFComponents;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

namespace PluginsCore
{
    /// <summary>
    /// Класс - контейнер предоставляющий коллекцию плагинов
    /// </summary>
    public class PluginsContainer
    {
        private bool __init_PluginsCatalog;
        private AggregateCatalog _PluginsCatalog;
        /// <summary>
        /// Текущий каталог плагинов
        /// </summary>
        public AggregateCatalog PluginsCatalog
        {
            get
            {
                if (!__init_PluginsCatalog)
                {
                    _PluginsCatalog = new AggregateCatalog();

                    DirectoryCatalog catalog = new DirectoryCatalog(Settings.PluginsDirectory);
                    DirectoryInfo info = new DirectoryInfo(Settings.PluginsDirectory);
                    DirectoryInfo[] childs = info.GetDirectories();

                    if (childs != null)
                    {
                        foreach (DirectoryInfo child in childs)
                        {
                            DirectoryCatalog childCatalog = new DirectoryCatalog(child.FullName);
                            _PluginsCatalog.Catalogs.Add(childCatalog);
                        }
                    }
                    _PluginsCatalog.Catalogs.Add(catalog);
                    __init_PluginsCatalog = true;
                }
                return _PluginsCatalog;
            }
            private set
            {
            }
        }

        private bool __init_Composer;
        private CompositionContainer _Composer;
        /// <summary>
        /// MEF - компонент
        /// </summary>
        public CompositionContainer Composer
        {
            get
            {
                if (!__init_Composer)
                {
                    _Composer = new CompositionContainer(PluginsCatalog);
                    __init_Composer = true;
                }
                return _Composer;
            }
        }

        private Dictionary<string,IPlugin> _PluginsMap;
        /// <summary>
        /// Карта плагинов
        /// </summary>
        public Dictionary<string,IPlugin> PluginsMap
        {
            get { return _PluginsMap; }
            set { _PluginsMap = value; }
        }

        private bool __init_Plugins;
        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        private IEnumerable<Lazy<IPlugin>> _Plugins;
        /// <summary>
        /// Коллекция плагинов
        /// </summary>
        public IEnumerable<Lazy<IPlugin>> Plugins
        {
            get
            {
                if (!__init_Plugins)
                {
                    Composer.ComposeParts(this);
                    this._PluginsMap = new Dictionary<string, IPlugin>();

                    foreach (Lazy<IPlugin> plugin in _Plugins)
                    {
                        if (!PluginsMap.ContainsKey(plugin.Value.PluginAssembly.FullName))
                            PluginsMap.Add(plugin.Value.PluginAssembly.FullName, plugin.Value);
                    }
                    __init_Plugins = true;
                }
                return _Plugins;
            }
        }

        /// <summary>
        /// Возвращает плагины соответствующего типа
        /// </summary>
        /// <param name="pluginType"></param>
        /// <returns></returns>
        public List<T> GetPlugin<T>(PluginType pluginType)
        {
            return null;
        }

        /// <summary>
        /// Обновление подключенных плагинов
        /// </summary>
        public void Recompose()
        {
            foreach (DirectoryCatalog catalog in PluginsCatalog.Catalogs)
            {
                catalog.Refresh();
            }
        }
    }
}
