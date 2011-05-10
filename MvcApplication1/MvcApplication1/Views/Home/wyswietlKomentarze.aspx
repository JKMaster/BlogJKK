<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Komentarze>>" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	wyswietlKomentarze
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Komentarze</h2>
    <p>
        <%: Html.ActionLink("Dodaj cos od siebie.", "dodajKomentarz", new { id=Convert.ToInt32(ViewData["id"])})%>
    </p>
    <% post p = (post)ViewData["post"]; %>
    <h1><%: p.tytul %></h1>
    <%: p.tresc %><br />
    <br />Komentarze do posta
    <% foreach (komentarz item in (IEnumerable)ViewData["lista"])
       { %>
    <h3><%= item.autor%></h3><%= item.data_dodania%><br />
    <%= item.tresc%><br />
    <% } %>

    <div>
    <br />
        <%: Html.ActionLink("Wstecznij", "Index") %>
    </div>
</asp:Content>

