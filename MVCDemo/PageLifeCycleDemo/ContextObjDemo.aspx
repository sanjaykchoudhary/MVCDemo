<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContextObjDemo.aspx.cs" Inherits="PageLifeCycleDemo.ContextObjDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HttpContext Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Using the current HttpContext to get information about the current page.
        <br />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
