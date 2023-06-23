<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlNameIdCtrlSmall.ascx.cs" Inherits="CtrlNameIdCtrlSmall" %>
<style type="text/css">
    .auto-style1 {
        width: 12%;
    }
</style>
<table border="0" cellpadding="0" cellspacing="0" style="width: 1px; position: static; height: 3px;">
    <tr>
        <td align="center" style="padding-right: 2px; padding-left: 2px; margin-left: 2px;
            width: 100px; margin-right: 2px; height: 20px">
            <asp:TextBox ID="TxtName" runat="server" SkinID="Txt265Disable" Style="position: static;" AutoPostBack="false"></asp:TextBox></td>
    </tr>
</table>
<table id="TblCtrl" runat="server" class="auto-style1">
    <tr>
        <td>
            <asp:HiddenField ID="HdnId" runat="server" Visible="true" />
        </td>
    </tr>
</table>

