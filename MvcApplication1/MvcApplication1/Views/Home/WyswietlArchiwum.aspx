<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.post>" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	WyswietlArchiwum
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Wyswietl Archiwum</h2>
<% foreach (post item in (List<post>)ViewData["archiwum"])
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
    <p>
        <%: Html.ActionLink("Wstecznij", "Index") %>
    </p>

</asp:Content>

