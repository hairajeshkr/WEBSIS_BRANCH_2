<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlRewindEvent.ascx.cs" Inherits="CtrlRewindEvent" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 1px; position: static; height: 1px;">
    <tr>
        <td align="center">
            <asp:TextBox ID="TxtReffNo" runat="server" SkinID="TxtRefNoNew" placeholder="Ref No."
                Style="position: static;"></asp:TextBox></td>
        <td align="center" class="tdEventRowStyle">
             <asp:Button ID="BtnFirst" runat="server" CausesValidation="False" CommandName="FIRST"
                Enabled="false" Font-Bold="True" Text="|<<" ToolTip="First" UseSubmitBehavior="False" OnClick="ManiPulateData" CssClass="rewindbuttons"/></td>
        <td align="center" class="tdEventRowStyle">
            <asp:Button ID="BtnPrevious" runat="server" CausesValidation="False" CommandName="PREVIOUS"
                Enabled="false" Font-Bold="True" Text="<<" ToolTip="Previous"
                UseSubmitBehavior="False" OnClick="ManiPulateData" CssClass="rewindbuttons" /></td>
        <td align="center" class="tdEventRowStyle">
            <asp:Button ID="BtnNext" runat="server" CausesValidation="False" CommandName="NEXT"
                Enabled="false" Font-Bold="True" Text=">>" ToolTip="Next" UseSubmitBehavior="False" OnClick="ManiPulateData" 
                 CssClass="rewindbuttons" /></td>
        <td align="center" class="tdEventRowStyle">
            <asp:Button ID="BtnLast" runat="server" CausesValidation="False" CommandName="LAST"
                Enabled="false" Font-Bold="True" CssClass="rewindbuttons"
                Text=">>|" ToolTip="Last" UseSubmitBehavior="False" OnClick="ManiPulateData" /></td>
        <td align="center" class="tdEventRowStyle">
            <asp:Button ID="BtnGet" runat="server" CausesValidation="False" CommandName="GET"
                Enabled="false" Font-Bold="True" CssClass="rewindbuttons"
                Text="GET" ToolTip="GET" UseSubmitBehavior="False" OnClick="ManiPulateData" Width="40px" /></td>
        <td align="center" class="tdEventRowStyle">
            <asp:Label ID="LblTkn" runat="server" Text="0" Visible="false"></asp:Label></td>
    </tr>
</table>
