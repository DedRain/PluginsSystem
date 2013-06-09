using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PluginsCore;
using PluginsSystem.ObjectModel.Database;

namespace PluginsSystem
{
    public partial class PluginsTableControl : System.Web.UI.UserControl
    {
        protected override void CreateChildControls()
        {
            string argument = PluginsContainer.Instance.GetJSONPlugins(null);
            //string script = string.Format("<script type=\"text/javascript\"> //<![CDATA[(function () {var mySt = new superTable(\"demoTable\",{0});})();//]]></script>", argument);
            string script = string.Format("<script type=\"text/javascript\"> //<![CDATA[\n" +
                "new superTable(\"{0}\",{1});" +
                    "//]]></script>", "MainContent_PluginsTableControl_demoTable", argument);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Plugins", script, false);
            CreatePluginsTable();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            demoTable.Rows.Clear();
            PluginsContainer.Instance.Recompose();
            CreatePluginsTable();
        }

        private void CreatePluginsTable()
        {
            HtmlTableRow headerRow = new HtmlTableRow();
            headerRow.Attributes.Add("class", "pluginsTableHeader");
            HtmlTableCell stateCell = new HtmlTableCell();
            HtmlInputCheckBox state = new HtmlInputCheckBox();
            state.Visible = false;
            stateCell.Controls.Add(state);
            headerRow.Cells.Add(stateCell);

            HtmlTableCell nameHeaderCell = new HtmlTableCell();
            nameHeaderCell.InnerText = "Name";
            headerRow.Cells.Add(nameHeaderCell);

            HtmlTableCell infoHeaderCell = new HtmlTableCell();
            infoHeaderCell.Align = "Center";
            infoHeaderCell.InnerText = "Info";
            headerRow.Cells.Add(infoHeaderCell);
            demoTable.Rows.Add(headerRow);

            foreach (KeyValuePair<Guid, IPlugin> pair in PluginsContainer.Instance.PluginsMap)
            {
                HtmlTableRow row = new HtmlTableRow();
                row.Attributes.Add("PluginID",pair.Value.ID.ToString());
                DBPlugin plugin = PluginsContainer.Instance.DBContext.DBPlugins.Find(pair.Key);

                if (plugin == null)
                    continue;

                HtmlTableCell statusCell = new HtmlTableCell();
                HtmlInputCheckBox checkBox = new HtmlInputCheckBox();
                checkBox.Checked = plugin.IsActive;
                statusCell.Controls.Add(checkBox);
                row.Cells.Add(statusCell);

                HtmlTableCell nameCell = new HtmlTableCell();
                nameCell.InnerText = pair.Value.Name;
                row.Cells.Add(nameCell);

                HtmlTableCell infoCell = new HtmlTableCell();
                infoCell.InnerText = pair.Value.PluginAssembly.FullName;
                row.Cells.Add(infoCell);

                row.Attributes.Add("IsActive", plugin.IsActive.ToString());

                demoTable.Rows.Add(row);
            }
        }
    }
}