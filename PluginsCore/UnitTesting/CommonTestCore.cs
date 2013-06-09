using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using PluginsCore;
using PluginsCore.JSON;

namespace UnitTesting
{
    [TestClass]
    public class CommonTestCore
    {
        [TestMethod]
        public void TestCore()
        {
            PluginsContainer container = PluginsContainer.Instance;
            foreach (KeyValuePair<Guid, IPlugin> plugin in container.PluginsMap)
            {
                Type type = plugin.GetType();
                dynamic logger = Activator.CreateInstance(type);
                //PluginJSON jsPlugin = new PluginJSON(plugin);
                //string json = DataSerializer.SerializeJSON(jsPlugin);

                Guid test = logger.ID;
                logger.Initialize();
            }

        }
    }
}
