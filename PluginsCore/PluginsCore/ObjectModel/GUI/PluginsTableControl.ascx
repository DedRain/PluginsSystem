<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PluginsTableControl.ascx.cs" Inherits="PluginsSystem.PluginsTableControl" %>
<link href="Content/Css/superTables.css" rel="stylesheet" type="text/css" />
<link href="Content/Css/PluginsControl.css" rel="Stylesheet" type="text/css" />

<table border="0" cellpadding="0" cellspacing="0" width="30%">
    <tr>
        <td>
            <fieldset>
                <legend>Плагины</legend>
                <div>
                    <div class="fakeContainer">
                        <table class="demoTable" id="demoTable">
                            <thead class="pluginsTableHeader">
                                <tr id="PluginsTableHeader">
                                    <td id="CheckStatusColumn" title="On/Off">
                                        <input type="checkbox" style="visibility: hidden" />
                                    </td>
                                    <td>PluginName
                                    </td>
                                    <td>Info
                                    </td>
                                </tr>
                            </thead>
                            <tbody class="pluginsTableBody">
                                <tr>
                                    <td>
                                        <input type="checkbox" />
                                    </td>
                                    <td>222222222222222222222222222222222222222222222222222222222
                                    </td>
                                    <td>3
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </td>
    </tr>
</table>
<script src="Controls/PluginsTableControl/superTables.js" type="text/javascript"></script>
<script type="text/javascript">
    //<![CDATA[
    (function () {
        var mySt = new superTable("demoTable", {
            cssSkin: "sSky",
            fixedCols: 0,
            headerRows: 1,
            onStart: function () {
                this.start = new Date();
            },
            onFinish: function () {
                //document.getElementById("testDiv").innerHTML += "Finished...<br>" + ((new Date()) - this.start) + "ms.<br>";
            }
        });
    })();
    //]]>
</script>
