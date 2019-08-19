<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarForm.aspx.cs" Inherits="TestWebApplication.CalendarForm" %>

<%@ Register src="CalendarUserControl.ascx" tagname="CalendarUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:CalendarUserControl ID="CalendarUserControl1" runat="server" />
    
        <asp:Button ID="btnClick" runat="server" OnClick="btnClick_Click" Text="Select Date" />
    </div>
    </form>
</body>
</html>
