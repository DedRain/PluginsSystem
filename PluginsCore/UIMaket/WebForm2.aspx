<%@ Page Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs"
    Inherits="UIMaket.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/PluginsControl.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="30%">
            <tr>
                <td>
                    <fieldset>
                        <legend>Плагины</legend>
                        <div>
                            <table rules="all" width="100%" class="pluginsTable">
                                <thead class="pluginsTableHeader">
                                    <tr class="pluginsTableHeaderRow">
                                        <th class="pluginsTableCellCheckBox">
                                            <input type="checkbox" name="namecheck" value="False" style="visibility: hidden;" />
                                        </th>
                                        <th class="pluginsTableCellCommon">
                                            Название
                                        </th>
                                        <th class="pluginsTableCellCommon">
                                            Информация о сборке
                                        </th>
                                    </tr>
                                </thead>
                                <tbody class="pluginsTableBody">
                                    <tr class="pluginsTableBodyRow">
                                        <td class="pluginsTableCellCheckBox" headers="1">
                                            <input type="checkbox" name="namecheck" value="False" />
                                        </td>
                                        <td class="pluginsTableCellCommon" headers="2">
                                            фывфыв
                                        </td>
                                        <td class="pluginsTableCellCommon" headers="3">
                                            пфй
                                        </td>
                                    </tr>
                                    <tr class="pluginsTableBodyRow">
                                        <td class="pluginsTableCellCheckBox">
                                            <input type="checkbox" name="namecheck" value="False" />
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            фывфыв
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            пфй
                                        </td>
                                    </tr>
                                    <tr class="pluginsTableBodyRow">
                                        <td class="pluginsTableCellCheckBox">
                                            <input type="checkbox" name="namecheck" value="False" />
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            фывфыв
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            пфй
                                        </td>
                                    </tr>
                                    <tr class="pluginsTableBodyRow">
                                        <td class="pluginsTableCellCheckBox">
                                            <input type="checkbox" name="namecheck" value="False" />
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            фывфыв
                                        </td>
                                        <td class="pluginsTableCellCommon">
                                            пфй
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
