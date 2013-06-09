using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PluginsCore;
using PluginsSystem.ObjectModel.Database;

namespace PluginsSystem
{
    public partial class SavePluginState : System.Web.UI.Page
    {
        private bool __init_PluginID;
        private Guid _PluginID;
        public Guid PluginID
        {
            get
            {
                if (!__init_PluginID)
                {
                    string strGuid = Request.Params["ID"];
                    _PluginID = new Guid(strGuid);
                    __init_PluginID = true;
                }
                return _PluginID;
            }
            private set
            {
                _PluginID = value;
                __init_PluginID = true;
            }
        }

        private bool __init_State;
        private bool _State;
        public bool State
        {
            get
            {
                if (!__init_State)
                {
                    string strState = Request.Params["State"];
                    if (!bool.TryParse(strState, out _State))
                    {
                        string errorText = string.Format("Не удалось обработать аргумент \"State\"");
                        throw new Exception(errorText);
                    }
                    __init_State = true;
                }
                return _State;
            }
            private set
            {
                _State = value;
                __init_State = true;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void CreateChildControls()
        {
            DBPlugin plugin = PluginsContainer.Instance.DBContext.DBPlugins.Find(PluginID);

            if (plugin == null)
            {
                string errorText = string.Format("Не найден плагин с ID = \"{0}\"",PluginID);
                throw new Exception(errorText);
            }

            plugin.IsActive = State;
            PluginsContainer.Instance.DBContext.SaveChanges();
        }
    }
}