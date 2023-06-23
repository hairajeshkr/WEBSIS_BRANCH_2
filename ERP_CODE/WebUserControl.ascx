<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
<style type="text/css">
    .auto-style1 {
        width: 20%;
    }
</style>

<table class="auto-style1" style="position: static; z-index: auto; vertical-align: middle; text-align: left">
    <tr>
        <td>
            <asp:TextBox ID="TxtCaption" runat="server" Style="position: static"
                Width="285px" CssClass="textbox_field_style"></asp:TextBox></td>
        <td>
            <img src="Images/Arrow.bmp" id="ImgLst" runat="server" height="20" width="18" alt="" /></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>

