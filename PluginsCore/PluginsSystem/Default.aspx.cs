using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PluginsCore;

namespace PluginsSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
                welcome.Visible = false;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            if (this.User.Identity.IsAuthenticated)
            {
                PluginsTableControl plugins = (PluginsTableControl)LoadControl("~/PluginsTableControl.ascx");
                plugins.ID = "PluginsTableControl";
                plugins.Visible = true;
                PluginsTableControlContainer.Controls.Add(plugins);
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
        }
    }
}