<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BranchSettings.aspx.cs" Inherits="BranchSettings" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Src="../CtrlDateTime.ascx" TagName="CtrlDateTime" TagPrefix="uc3" %>

<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="Script/BranchSettings.js"></script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 200px; height: 100px;">
        <tr>
            <td class="odd" style="width: 100px; height: 10px">
            </td>
            <td class="odd" style="width: 100px; height: 10px">
            </td>
            <td class="odd" style="width: 100px; height: 10px">
            </td>
        </tr>
        <tr>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:Label ID="Label1" runat="server" Text="User Name" SkinID="LblBold" Width="130px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:DropDownList id="DdlUsrGrp" runat="server" SkinID="DdlList" AutoPostBack="True" OnSelectedIndexChanged="DdlUsrGrp_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td class="odd" style="width: 100px; height: 25px;"><asp:Label ID="Label2" runat="server" Width="104px"></asp:Label></td>
        </tr>
        <tr>
            <td class="odd" style="width: 100px; height: 25px">
            </td>
            <td class="odd" style="width: 100px; height: 25px"><asp:Label ID="Label3" runat="server" Width="304px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px">
                <asp:CheckBox id="ChkActive" runat="server" SkinID="IsActive" Checked="True" Visible="False">
                </asp:CheckBox></td>
        </tr>
        <tr>
            <td class="odd" colspan="3" style="height: 25px">
                <div style="overflow: scroll; width: 524px; height: 325px" id="Div2" onclick="return DIV1_onclick()">
                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" Width="537px" OnRowDataBound="GrdVwRecords_RowDataBound">
                        <Columns>
<asp:TemplateField HeaderText="SNo."><ItemTemplate>
<asp:Label id="Label4" runat="server" Width="35px" Text="<%# Container.DataItemIndex + 1 %>" __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="300px" Text='<%# Eval("Name") %>' SkinID="LblGrdMaster" __designer:wfdid="w16"></asp:Label> <asp:Label id="LblNam" runat="server" Width="300px" Text='<%# Eval("Name") %>' SkinID="LblBold" Visible="False" __designer:wfdid="w17"></asp:Label> <asp:HiddenField id="HdnId" runat="server" __designer:wfdid="w18" Value='<%# Eval("Id") %>'></asp:HiddenField> <asp:HiddenField id="HdnTType" runat="server" __designer:wfdid="w18" Value='<%# Eval("TType") %>'></asp:HiddenField>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Approve"><ItemTemplate>
<asp:CheckBox id="ChkCreate" runat="server" __designer:wfdid="w2"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField></asp:BoundField>
<asp:TemplateField HeaderText="Is Block" Visible="False"><ItemTemplate>
<asp:CheckBox id="ChkIsBlck" runat="server" __designer:wfdid="w3"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
                    </asp:GridView>
                </div>
                </td>
        </tr>
        <tr>
            <td class="FooterCommand" colspan="3" style="height: 10px" align="center" valign="middle">
                <uc1:CtrlCommand ID="CtrlCommand" runat="server" IsVisibleClear="true" IsVisibleDelete="true" IsVisibleFind="false" IsVisiblePrint="false" />
            </td>
        </tr>
    </table>
</asp:Content>

