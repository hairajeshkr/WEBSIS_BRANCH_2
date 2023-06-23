<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Src="../CtrlDateTime.ascx" TagName="CtrlDateTime" TagPrefix="uc3" %>

<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="Script/ChangePwd.js"></script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 126px; height: 117px;">
        <tr>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:Label ID="Label1" runat="server" Text="Current Password" SkinID="LblBold" Width="124px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px;">
                :</td>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:TextBox ID="TxtPwd" runat="server" placeholder="Current Password" TextMode="Password"></asp:TextBox></td>
            <td class="odd" style="width: 100px; height: 25px;">
                </td>
        </tr>
        <tr>
            <td class="even" style="width: 100px; height: 25px">
                <asp:Label ID="Label12" runat="server" Text="New Password" SkinID="LblBold" Width="125px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px">
                :</td>
            <td class="even" style="width: 100px; height: 25px"><asp:TextBox ID="TxtNewPawd" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox></td>
            <td class="even" style="width: 100px; height: 25px">
            </td>
        </tr>
        <tr>
            <td class="odd" style="width: 100px; height: 25px">
                <asp:Label ID="Label2" runat="server" Text="Retype Password" SkinID="LblBold" Width="125px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px">
            </td>
            <td class="odd" style="width: 100px; height: 25px"><asp:TextBox ID="TxtREType" runat="server" placeholder="Retype Password" TextMode="Password"></asp:TextBox></td>
            <td class="odd" style="width: 100px; height: 25px">
            </td>
        </tr>
        <tr>
            <td class="odd" style="width: 100px; height: 25px">
                </td>
            <td class="odd" style="width: 100px; height: 25px">
            </td>
            <td class="odd" style="width: 100px; height: 25px">
                <uc1:CtrlCommand ID="CtrlCommand" runat="server" IsVisibleClear="true" IsVisibleDelete="false" IsVisibleFind="false" IsVisiblePrint="false" SaveText="Update" />
            </td>
            <td class="odd" style="width: 100px; height: 25px">
                </td>
        </tr>
    </table>
</asp:Content>

