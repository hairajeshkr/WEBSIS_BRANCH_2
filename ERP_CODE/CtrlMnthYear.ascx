<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlMnthYear.ascx.cs" Inherits="CtrlMnthYear" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 8px">
    <tr>
        <td>
            <asp:DropDownList ID="DdlMonth" runat="server" SkinID="Ddl100" >
            <asp:ListItem Value="0">---Select---</asp:ListItem>
            <asp:ListItem Value="Jan">January</asp:ListItem>
            <asp:ListItem Value="Feb">February</asp:ListItem>
            <asp:ListItem Value="Mar">March</asp:ListItem>
            <asp:ListItem Value="Apr">April</asp:ListItem>
            <asp:ListItem Value="May">May</asp:ListItem>
            <asp:ListItem Value="Jun">June</asp:ListItem>
            <asp:ListItem Value="Jul">July</asp:ListItem>
            <asp:ListItem Value="Aug">August</asp:ListItem>
            <asp:ListItem Value="Sep">September</asp:ListItem>
            <asp:ListItem Value="Oct">October</asp:ListItem>
            <asp:ListItem Value="Nov">November</asp:ListItem>
            <asp:ListItem Value="Dec">December</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:DropDownList ID="DdlYear" runat="server" SkinID="Ddl100">
            </asp:DropDownList></td>
    </tr>
</table>