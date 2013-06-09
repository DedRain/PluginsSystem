using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using PluginsCore.MEFComponents;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;
using PluginsSystem.ObjectModel.Database;

namespace PluginsCore
{
    /// <summary>
    /// Singleton Класс - контейнер предоставляющий коллекцию плагинов
    /// </summary>
    public sealed class PluginsContainer
    {
        private Entities _DBContext;
        public Entities DBContext
        {
            get { return _DBContext; }
            private set { _DBContext = value; }
        }

        private static readonly PluginsContainer _Instance = new PluginsContainer();
        public static PluginsContainer Instance
        {
            get
            {
                _Instance._DBContext = new Entities();
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
        private Dictionary<Guid, IPlugin> _PluginsMap;
        /// <summary>
        /// Карта плагинов
        /// </summary>
        public Dictionary<Guid, IPlugin> PluginsMap
        {
            get
            {
                if (!__init_PluginsMap)
                {
                    this._PluginsMap = new Dictionary<Guid, IPlugin>();

                    foreach (IPlugin plugin in Plugins)
                    {
                        if (!_PluginsMap.ContainsKey(plugin.ID))
                        {
                            _PluginsMap.Add(plugin.ID, plugin);

                            DBPlugin newDBPlugin = new DBPlugin
                            {
                                ID = plugin.ID,
                                AssemblyInfo = plugin.PluginAssembly.FullName,
                                IsActive = false,
                                Name = plugin.Name,
                                Owner = null,
                                DBUsersPermisions = new HashSet<DBUsersPermision>()
                            };

                            DBPlugin existingDBPlugin = DBContext.DBPlugins.Find(plugin.ID);

                            if (existingDBPlugin == null)
                                DBContext.DBPlugins.Add(newDBPlugin);
                            else
                            {
                                existingDBPlugin.ID = newDBPlugin.ID;
                                existingDBPlugin.Name = newDBPlugin.Name;
                                existingDBPlugin.AssemblyInfo = newDBPlugin.AssemblyInfo;
                            }

                            int result = DBContext.SaveChanges();

                            if (result == 0)
                            {
                                string errorText = string.Format("Не удалось сохранить изменения для записи \"{0}\"",existingDBPlugin.ID);
                                Logger.Logger.HandleException(new Exception(errorText));
                            }
                        }
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
        private IEnumerable<IPlugin> _Plugins;
        /// <summary>
        /// Коллекция плагинов
        /// </summary>
        protected IEnumerable<IPlugin> Plugins
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
        public Dictionary<Guid,IPlugin> Recompose()
        {
            foreach (DirectoryCatalog catalog in PluginsCatalog.Catalogs)
                catalog.Refresh();

            __init_PluginsMap = false;
            return PluginsMap;
        }
    }
}
