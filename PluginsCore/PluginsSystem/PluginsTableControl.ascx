<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsTableControl.ascx.cs" Inherits="PluginsSystem.PluginsTableControl" %>
<link href="Content/Css/superTables.css" rel="stylesheet" type="text/css" />
<link href="Content/Css/PluginsControl.css" rel="Stylesheet" type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
    <tr>
        <td>
            <fieldset>
                <legend>Плагины</legend>
                <div>
                    <div class="fakeContainer">
                        <table class="demoTable" runat="server" id="demoTable">
                            <<%--thead class="pluginsTableHeader">
                                <tr id="PluginsTableHeader" runat="server">
                                    <td id="CheckStatusColumn" title="On/Off">
                                        <input type="checkbox" style="visibility: hidden" />
                                    </td>
                                    <td>PluginName
                                    </td>
                                    <td>Info
                                    </td>
                                </tr>
                            </thead>--%>
                            <tbody class="pluginsTableBody">
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button Text="Обновить" runat="server" ID="UpdateButton" style="margin-top:20px; margin-left:4px;" ToolTip="Обновить список плагинов" OnClick="UpdateButton_Click" />
        </td>
    </tr>
</table>
<script src="Controls/PluginsTableControl/superTables.js" type="text/javascript"></script>
<%--<script type="text/javascript">
    //<![CDATA[
    (function () {var mySt = new superTable("demoTable");})();
    //]]>
</script>--%>
