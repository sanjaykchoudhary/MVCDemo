<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarUserControl.ascx.cs" Inherits="TestWebApplication.CalendarUserControl" %>

<asp:TextBox ID="txtDate" runat="server" Width="115px"></asp:TextBox>
<asp:ImageButton ID="imgBtn" runat="server" ImageUrl="~/Images/Calendar.png" OnClick="imgBtn_Click" />
<asp:Calendar ID="calendarCtrl" runat="server" OnSelectionChanged="calendarCtrl_SelectionChanged"></asp:Calendar>
