<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%: Page.User.Identity.Name %></b>!
        [ <%: Html.ActionLink("Loong Off", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Loong On", "LogOn", "Account") %> ]
<%
    }
%>
