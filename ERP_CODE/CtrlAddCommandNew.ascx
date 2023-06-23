<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlAddCommandNew.ascx.cs" Inherits="CtrlAddCommandNew" %>
<style type="text/css">
    .auto-style1 {
        width: 10%;
    }
    .cmddstyle 
    {
        width: 100px; 
        height: 25px;
        padding-right: 3px;
    }
</style>
<table border="0" cellpadding="0" cellspacing="0" style="height: 18px; width: 110px;">
    <tr>
        <td class="cmddstyle">
            <asp:Button ID="BtnAdd" runat="server" CommandName="ADD"
                SkinID="BtnAddSub" Text="ADD" ToolTip="ADD" OnClick="ManiPulateData" CommandArgument="ITEM_NEW" /></td>
        <td class="cmddstyle">
            <asp:Button ID="BtnClear" runat="server" CommandName="ADD"
                SkinID="BtnAddSub" Text="Clear" ToolTip="Clear" OnClick="ManiPulateData" CausesValidation="False" CommandArgument="ITEM_CLEAR" /></td>
        <td class="cmddstyle">
            <asp:Button ID="BtnDelete" runat="server" CommandName="ADD"
                SkinID="BtnAddSub" Text="Delete" ToolTip="Delete" OnClick="ManiPulateData" CommandArgument="ITEM_DELETE" /></td>
    </tr>
</table>
<table class="auto-style1" runat="server" visible="false" id="TblCmd">
    <tr>
        <td>
            <asp:HiddenField ID="HdnChldId" runat="server" Value="0" />
        </td>
    </tr>
</table>

