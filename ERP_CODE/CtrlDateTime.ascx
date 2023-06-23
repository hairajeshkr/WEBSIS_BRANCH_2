<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlDateTime.ascx.cs" Inherits="CtrlDateTime" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 8px">
    <tr>
        <td>
            <asp:TextBox ID="TxtDate" runat="server" placeholder="dd/MMM/yyyy" SkinID="TxtDate"></asp:TextBox></td>
        <td>
            <img id="Img1" runat="server" src="Images/calendar.jpg" /></td>
        <td>
            <asp:DropDownList ID="DdlHr" runat="server" Width="50px" Visible="False">
            </asp:DropDownList></td>
        <td>
            <asp:DropDownList ID="DdlMnt" runat="server" Width="50px" Visible="False">
            </asp:DropDownList></td>
    </tr>
</table>
<asp:PlaceHolder ID="CDdlr" runat="server"></asp:PlaceHolder>
