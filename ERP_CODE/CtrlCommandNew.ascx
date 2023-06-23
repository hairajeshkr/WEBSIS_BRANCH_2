<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlCommandNew.ascx.cs" Inherits="CtrlCommandNew" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 17px; height: 18px;">
    <tr>
        <td style="width: 100px; height: 24px;">
            <asp:Button ID="BtnFetch" runat="server" CommandName="FIND"
              SkinID="BtnCommandSave"  Text="Fetch" ToolTip="Fetch" OnClick="ManiPulateData" CommandArgument="NEW" /></td>
        <td style="width: 100px; height: 24px;">
            <asp:Button ID="BtnClear" runat="server" CommandName="CLEAR"
                SkinID="BtnCommandClear" Text="Clear" ToolTip="Clear" OnClick="ManiPulateData" CausesValidation="False" /></td>
        <td style="width: 100px; height: 24px;"><asp:Button ID="BtnPrint" runat="server" CommandName="PRINT"
                SkinID="BtnCommandPrint" Text="Print" ToolTip="Print" OnClick="ManiPulateData" Visible="False" /></td> 
    </tr>
</table>
<asp:HiddenField ID="HdnCnfrm" runat="server" Value="false" /><asp:HiddenField ID="HdnId" runat="server" Value="0" />
