using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginsCore.MEFComponents;
using PluginsCore;
using System.ComponentModel.Composition;
using System.Reflection;
using ExternalPlugin;

namespace ExternalPlugin
{
    public interface ILogger : IPlugin
    {
        string LogFileName { get; set; }
    }

    [IPluginExport(typeof(IPlugin))]
    public class Logger : ILogger
    {
        private bool __init_ID;
        private Guid _ID;
        public Guid ID
        {
            get
            {
                if (!__init_ID)
                {
                    Type t = this.GetType();
                    this._ID = t.GUID;
                    __init_ID = true;
                }
                return _ID;
            }
        }

        private bool __init_PluginAssembly;
        private Assembly _PluginAssembly;
        public Assembly PluginAssembly
        {
            get
            {
                if (!__init_PluginAssembly)
                {
                    _PluginAssembly = Assembly.GetAssembly(this.GetType());
                    __init_PluginAssembly = true;
                }
                return _PluginAssembly;
            }
            set
            {
            }
        }

        public string Name
        {
            get { return "test"; }
        }

        public string AssemblyDisplayInfo
        {
            get
            {
                return this.PluginAssembly.FullName;
            }
        }

        public dynamic Data
        {
            get { return "Hello"; }
            set { }
        }

        /// <summary>
        /// Тип плагина
        /// </summary>
        public PluginType PluginType
        {
            get;
            set;
        }

        public object ThroughData
        {
            get;
            set;
        }

        private string _LogFileName = "test";
        public string LogFileName
        {
            get { return _LogFileName; }
            set { _LogFileName = value; }
        }

        public Logger()
        {
        }

        public void Initialize()
        {
        }

        public object DataProcessing(object data)
        {
            return null;
        }
    }

    [IPluginExport(typeof(IPlugin))]
    public class test : IPlugin
    {
        private bool __init_ID;
        private Guid _ID;
        public Guid ID
        {
            get
            {
                if (!__init_ID)
                {
                    Type t = this.GetType();
                    this._ID = t.GUID;
                    __init_ID = true;
                }
                return _ID;
            }
        }

        private bool __init_PluginAssembly;
        private Assembly _PluginAssembly;
        public Assembly PluginAssembly
        {
            get
            {
                if (!__init_PluginAssembly)
                {
                    _PluginAssembly = Assembly.GetAssembly(this.GetType());
                    __init_PluginAssembly = true;
                }
                return _PluginAssembly;
            }
            set
            {
            }
        }

        public string Name
        {
            get { return "test2"; }
        }

        public string AssemblyDisplayInfo
        {
            get
            {
                return this.PluginAssembly.FullName;
            }
        }

        public dynamic Data
        {
            get { return "Hello"; }
            set { }
        }

        /// <summary>
        /// Тип плагина
        /// </summary>
        public PluginType PluginType
        {
            get;
            set;
        }

        public object ThroughData
        {
            get;
            set;
        }

        private string _LogFileName = "test";
        public string LogFileName
        {
            get { return _LogFileName; }
            set { _LogFileName = value; }
        }

        public test()
        {
        }

        public void Initialize()
        {
        }

        public object DataProcessing(object data)
        {
            return null;
        }
    }
}
