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
    /// Singleton Класс - контейнер предоставляющий коллекцию плагинов
    /// </summary>
    public sealed class PluginsContainer
    {
        private static readonly PluginsContainer _Instance = new PluginsContainer();
        public static PluginsContainer Instance
        {
            get
            {
                return _Instance;
            }
        }

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
                    IEnumerable<string> dirs = Directory.EnumerateDirectories(Settings.PluginsDirectory);
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

        private bool __init_PluginsMap;
        private Dictionary<Guid, PluginObject> _PluginsMap;
        /// <summary>
        /// Карта плагинов
        /// </summary>
        public Dictionary<Guid, PluginObject> PluginsMap
        {
            get
            {
                if (!__init_PluginsMap)
                {
                    this._PluginsMap = new Dictionary<Guid, PluginObject>();

                    foreach (Lazy<IPlugin> plugin in Plugins)
                    {
                        PluginObject pluginObj = new PluginObject(plugin.Value);
                        if (!_PluginsMap.ContainsKey(plugin.Value.ID) && pluginObj.Active)
                            _PluginsMap.Add(plugin.Value.ID, pluginObj);
                    }
                    __init_PluginsMap = true;
                }
                return _PluginsMap;
            }
            private set
            {
                _PluginsMap = value;
                __init_PluginsMap = true;
            }
        }

        private bool __init_Plugins;
        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        private IEnumerable<Lazy<IPlugin>> _Plugins;
        /// <summary>
        /// Коллекция плагинов
        /// </summary>
        protected IEnumerable<Lazy<IPlugin>> Plugins
        {
            get
            {
                if (!__init_Plugins)
                {
                    Composer.ComposeParts(this);
                    __init_Plugins = true;
                }
                return _Plugins;
            }
        }

        static PluginsContainer()
        {
        }

        PluginsContainer()
        {
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
