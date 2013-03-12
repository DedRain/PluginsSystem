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
        private bool __init_CurrentAssembly;
        private Assembly _CurrentAssembly;
        public Assembly CurrentAssembly
        {
            get
            {
                if (!__init_CurrentAssembly)
                {
                    _CurrentAssembly = Assembly.GetAssembly(this.GetType());
                    __init_CurrentAssembly = true;
                }
                return _CurrentAssembly;
            }
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
    }
}
