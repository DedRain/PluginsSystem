using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PluginsCore.JSON
{
    [DataContract]
    public class PluginJSON
    {
        private PluginObject _Plugin;
        [IgnoreDataMember]
        public PluginObject Plugin
        {
            get { return _Plugin; }
            private set { _Plugin = value; }
        }

        private bool __init_IsActive;
        private bool _IsActive;
        [DataMember]
        public bool IsActive
        {
            get
            {
                if (!__init_IsActive)
                {
                    this._IsActive = this.Plugin.Active;
                    __init_IsActive = true;
                }
                return _IsActive;
            }
            set { }
        }

        private bool __init_AssemblyInfo;
        private string _AssemblyInfo;
        [DataMember]
        public string AssemblyInfo
        {
            get
            {
                if (!__init_AssemblyInfo)
                {
                    this._AssemblyInfo = this.Plugin.Plugin.PluginAssembly.FullName;
                    __init_AssemblyInfo = true;
                }
                return _AssemblyInfo;
            }
            set { }
        }

        private bool __init_Name;
        private string _Name;
        [DataMember]
        public string Name
        {
            get
            {
                if (!__init_Name)
                {
                    this._Name = this.Plugin.Plugin.Name;
                    __init_Name = true;
                }
                return _Name;
            }
            set { }
        }

        public PluginJSON(PluginObject plugin)
        {
            if (plugin == null)
            {
                string errorText = string.Format("Ошибка: Не передан аргумент plugin");
                throw new Exception(errorText);
            }

            this._Plugin = plugin;
        }

        public PluginJSON()
        {

        }
    }
}
