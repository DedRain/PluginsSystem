﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UIMaket.WebForm1" %>

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
                    <ul style="height:50px;display:block;list-style-type:disc;">
                        <li style="display:inline-block; list-style-type: none; ">
                            <a type="text/asp" href="WebForm1.aspx" title="Главная" 
                                style="border-width: thin; display:block; height:50px; border-style:groove; text-align:center; text-decoration: none;">Главная</a>
                        </li>
                        <li style="display:inline-block; list-style-type: none;">
                            <a type="text/asp" href="WebForm1.aspx" title="Настройки" 
                                style="border-width: thin; display:block; height:50px; border-style:groove; text-align:center; text-decoration: none;">Настройки</a>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>