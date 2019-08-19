<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPageCycle.aspx.cs" Inherits="PageLifeCycleDemo.TestPageCycle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th colspan="2">My Application</th>                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkSkiing" runat="server" Text="Skiing"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkSailing" runat="server" Text="Sailing"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
