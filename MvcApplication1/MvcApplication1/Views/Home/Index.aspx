<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"]%></h2>
    <p>
    </p>
    <% foreach (post item in (IEnumerable)ViewData["lista"])
       { %>
    <h1><%= item.tytul%></h1><%= item.data_dodania.ToShortDateString()%><br />
    <%= item.tresc%><br />
    <%: Html.ActionLink("Komentarz", "wyswietlKomentarze", new { id=item.ID})%>
    <!--<%: Html.ActionLink("Dodaj", "dodajKomentarz",new { id = item.ID })%>-->
    <% if (Request.IsAuthenticated)
       {%>
            <%: Html.RouteLink("Edytuj", new { controller = "Admin", action = "edytujPost", id = item.ID })%>
        <%} %>
    <% } %>
</asp:Content>
