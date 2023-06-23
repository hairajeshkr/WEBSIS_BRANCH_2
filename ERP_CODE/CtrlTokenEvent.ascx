<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlTokenEvent.ascx.cs" Inherits="CtrlTokenEvent" %>
<table style="width: 1px; position: static">
    <tr>
        <td align="center">
            <asp:Label ID="LblTokenNo" runat="server" SkinID="LblToken" Text="TOKEN NO." Visible="false" ></asp:Label></td>
        <td align="center" class="tokenalign" >
            <asp:TextBox ID="TxtTokenNo" runat="server" SkinID="TxtTokenNo" Style="position: static;text-align: center;" AutoPostBack="false"></asp:TextBox></td>
        <td align="center" class="tokenalign" >
            <asp:Button ID="BtnTknFind" runat="server" CausesValidation="False" CommandName="TOKEN" Font-Bold="True" SkinID="BtnAddSub"  Visible="false" Text="FIND" ToolTip="First" OnClick="ManiPulateData" style="position: static" CommandArgument="ITEM_FIND" /></td>
    </tr>
</table>
