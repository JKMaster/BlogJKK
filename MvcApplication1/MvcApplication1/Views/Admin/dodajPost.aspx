<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Klasa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	dodajPost
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dodaj Post</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.tytul) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.tytul) %>
                <%: Html.ValidationMessageFor(model => model.tytul) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.tresc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.tresc, new { @cols = "40", @rows = "5" })%>
                <%: Html.ValidationMessageFor(model => model.tresc) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.status) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.status) %>
                <%: Html.ValidationMessageFor(model => model.status) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.keywords) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.keywords) %>
                <%: Html.ValidationMessageFor(model => model.keywords) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.description) %>
                <%: Html.ValidationMessageFor(model => model.description) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Wstecznij", "Index","Home") %>
    </div>

</asp:Content>

