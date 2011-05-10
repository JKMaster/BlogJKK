<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.komentarz>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	dodajKomentarz
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dodaj komentarz</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.tresc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.tresc, new {@cols="40",@rows="5"}) %>
                <%: Html.ValidationMessageFor(model => model.tresc) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.autor) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.autor) %>
                <%: Html.ValidationMessageFor(model => model.autor) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Wstecznij", "Index") %>
    </div>

</asp:Content>

