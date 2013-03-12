using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluginsCore;
using System.ComponentModel.Composition.Hosting;
using PluginsCore.MEFComponents;

namespace UnitTesting
{
    [TestClass]
    public class CommonTestCore
    {
        [IPluginImport(typeof(IPlugin))]
        IPlugin Logger;

        [TestMethod]
        public void TestCore()
        {
            PluginsContainer container = new PluginsContainer();
            foreach (Lazy<IPlugin> item in container.Plugins)
            {
                Type type = item.Value.GetType();
                dynamic logger = Activator.CreateInstance(type);
                string test = logger.LogFileName;
                logger.Initialize();
            }
            
        }
    }
}
