<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="RoutingInWebDemo.Sales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>This is the Sales Report</h1>
        Following are the Details of <%=RouteData.Values["year"] %>
    </div>
        <div>
            <h1>This is another Report</h1>
            Following are the Details of Country: <%=RouteData.Values["country"] %>,<%=RouteData.Values["year"] %>
        </div>
        <div>
            <h1>Sales Report of</h1>
            <asp:Literal ID="ltrCountry" runat="server"></asp:Literal> for the year
            <asp:Literal ID="ltrYear" runat="server"></asp:Literal>
        </div>
        <div>
            <h1>This is the RouteExpression demo</h1>
            <asp:Literal ID="literalCountry" Text="<%$RouteValue:country %>" runat="server"></asp:Literal>for the year
            <asp:Literal ID="literalYear" Text="<%$RouteValue:year %>" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
