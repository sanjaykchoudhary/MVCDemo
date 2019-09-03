<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RoutingInWebDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a runat="server" href="~/Salesreportsummary/2013">Sales Report summary for 2013</a><br />
    <a runat="server" href="~/SalesReport/IND/2014">Sales Report for 2014</a><br />
        <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="<%$RouteUrl:year=2011 %>">Sales Report - All Countries 2012</asp:HyperLink>
        <asp:HyperLink ID="hyperlink2" runat="server" NavigateUrl="<%$RouteUrl:country=IND,year=2009,routename=salesroute %>">Sales Report-IND,2009</asp:HyperLink>
    </div>
    </form>
</body>
</html>
