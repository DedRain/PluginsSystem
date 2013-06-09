using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using PluginsSystem.ObjectModel.Database;
using System.Reflection;

namespace PluginsCore
{
    /// <summary>
    /// Обертка над Lazy[IPlugin]
    /// </summary>
    public class PluginObject : DBPlugin, IPlugin
    {
        //private Entities _EntitesContext;
        //public Entities EntitesContext
        //{
        //    get { return _EntitesContext; }
        //    private set { _EntitesContext = value; }
        //} 

        public override ICollection<DBUsersPermision> DBUsersPermisions
        {
            get
            {
                return base.DBUsersPermisions;
            }
            set
            {
                base.DBUsersPermisions = value;
            }
        }

        private PluginType _PluginType;
        public PluginType PluginType
        {
            get { return _PluginType; }
            set { _PluginType = value; }
        }

        private Assembly _PluginAssembly;
        public Assembly PluginAssembly
        {
            get { return _PluginAssembly; }
            set { _PluginAssembly = value; }
        }

        private dynamic _Data;
        public dynamic Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public void Initialize()
        {

        }

        public dynamic DataProcessing(dynamic data)
        {
            return data;
        }

        private bool __init_Active;
        private bool _Active = true;
        /// <summary>
        /// Признак активности плагина
        /// </summary>
        public bool Active
        {
            get
            {
                if (!__init_Active)
                {
                    //чтение из базы
                    __init_Active = true;
                }
                return _Active;
            }
        }

        //private bool __init_DBPlugin;
        //private DBPlugin _DBPlugin;
        //protected DBPlugin DBPlugin
        //{
        //    get
        //    {
        //        if (__init_DBPlugin)
        //        {
        //            _DBPlugin = EntitesContext.DBPlugins.Single<DBPlugin>(plugin => plugin.ID == this.Plugin.ID);

        //            if (_DBPlugin == null)
        //                SavePluginToDB();

        //            __init_DBPlugin = true;
        //        }
        //        return _DBPlugin;
        //    }
        //    private set
        //    {
        //        _DBPlugin = value;
        //        __init_DBPlugin = true;
        //    }
        //}

        //protected void SavePluginToDB()
        //{
        //    DBPlugin plugin = new PluginsSystem.ObjectModel.Database.DBPlugin();
        //    plugin.ID = this.Plugin.ID;
        //    plugin.Info = this.Plugin.PluginAssembly.FullName;
        //    plugin.IsActive = false;
        //    EntitesContext.DBPlugins.Add(plugin);
        //}

        //public PluginObject(Entities dbContext)
        //{
        //    if (dbContext == null)
        //    {
        //        string errorMessage = string.Format("Не передан аргумент Entities");
        //        throw new Exception(errorMessage);
        //    }

        //    _EntitesContext = dbContext;
        //}

        public PluginObject()
        {

        }

        //аргументом передать юзера, для определения прав
        /// <summary>
        /// Активация плагина в базе
        /// </summary>
        /// <returns>Результат активации</returns>
        bool Activate()
        {
            //Активация плагина в базе
            return false;
        }
    }
}