<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PluginsSystem.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>Автоматизированная система управления модулями.</h2>
    </hgroup>

    <article>
        <p>        
            Дипломная работа
        </p>

        <p>        
            Модуль сетевого взаимодействия.
        </p>

        <p>        
            Душелюбов А. И. группа 5ИНТ-4ДБ-062
        </p>
    </article>

    <aside>
        <p>        
            Страницы
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>