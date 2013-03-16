<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UIMaket.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div align="right" style="background-color: Gray">
                        <input type="text" name="CurrentUserLogin" value="CurrentUser" readonly="readonly" />
                        <input type="button" name="LogOut" value="LogOut" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 20px; background-color: Green;">
                    <ul>
                        <li style="display:table-cell;list-style-type: none;">
                            <a type="text/asp" href="WebForm1.aspx" title="Главная">Главная</a>
                        </li>
                        <li style="display:table-cell; list-style-type: none;">
                            <a type="text/asp" href="WebForm1.aspx" title="Главная">Настройки</a>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" width="30%">
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Плагины</legend>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>
                                                            <input type="checkbox" name="namecheck" value="False" style="visibility: hidden;" />
                                                        </th>
                                                        <th>
                                                            Название
                                                        </th>
                                                        <th>
                                                            Информация о сборке
                                                        </th>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="height: 400px; overflow: auto">
                                                    <table>
                                                        <tr style="cursor:pointer">
                                                            <td>
                                                                <input type="checkbox" name="namecheck" value="False" />
                                                            </td>
                                                            <td>
                                                                фывфыв
                                                            </td>
                                                            <td>
                                                                пфй
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="checkbox" name="namecheck" value="False" />
                                                            </td>
                                                            <td>
                                                                фывфыв
                                                            </td>
                                                            <td>
                                                                пфй
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="checkbox" name="namecheck" value="False" />
                                                            </td>
                                                            <td>
                                                                фывфыв
                                                            </td>
                                                            <td>
                                                                пфй
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
