<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MenuSettings.aspx.cs" Inherits="MenuSettings" Title="Untitled Page" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Src="../CtrlDateTime.ascx" TagName="CtrlDateTime" TagPrefix="uc3" %>

<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="Script/MenuSettings.js"></script>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 174px; height: 117px;">
        <tr>
            <td class="odd" style="width: 100px; height: 10px">
            </td>
            <td class="odd" style="width: 100px; height: 10px">
            </td>
            <td class="odd" style="width: 100px; height: 10px">
                <asp:CheckBox id="ChkActive" runat="server" SkinID="IsActive" Checked="True" Visible="False">
                </asp:CheckBox></td>
        </tr>
        <tr>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:Label ID="Label1" runat="server" Text="User Group" Width="136px"></asp:Label></td>
            <td class="odd" style="width: 100px; height: 25px;">
                <asp:DropDownList id="DdlUsrGrp" runat="server" SkinID="DdlList" AutoPostBack="True" OnSelectedIndexChanged="DdlUsrGrp_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td class="odd" style="width: 100px; height: 25px;"><asp:Label ID="Label2" runat="server" Width="104px"></asp:Label></td>
        </tr>
        <tr>
            <td class="odd" colspan="3" style="height: 25px">
                <div style="overflow: scroll; width: 558px; height: 382px" id="Div2" onclick="return DIV1_onclick()">
                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" Width="537px" OnRowDataBound="GrdVwRecords_RowDataBound">
                        <Columns>
<asp:TemplateField HeaderText="SNo."><ItemTemplate>
<asp:Label id="Label4" runat="server" Width="35px" Text="<%# Container.DataItemIndex + 1 %>" __designer:wfdid="w3"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="300px" Text='<%# Eval("cName") %>' SkinID="LblGrdMaster" __designer:wfdid="w28"></asp:Label> <asp:Label id="LblNam" runat="server" Width="300px" Text='<%# Eval("cName") %>' SkinID="LblIdentify" Visible="False" __designer:wfdid="w29"></asp:Label> 
<asp:HiddenField id="HdnParentId" runat="server" __designer:wfdid="w30" Value='<%# Eval("nParentId") %>'></asp:HiddenField> 
<asp:HiddenField id="HdnMenuId" runat="server" __designer:wfdid="w30" Value='<%# Eval("nMenuId") %>'></asp:HiddenField>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Create"><ItemTemplate>
<asp:CheckBox id="ChkCreate" runat="server" __designer:wfdid="w17"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Modify"><ItemTemplate>
<asp:CheckBox runat="server" id="ChkModify"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:CheckBox runat="server" id="ChkDelete"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Print"><ItemTemplate>
<asp:CheckBox runat="server" id="ChkPrint"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>
                    </asp:GridView>
                </div>
                </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 25px" valign="middle" class="FooterCommand">
                <uc1:CtrlCommand ID="CtrlCommand" runat="server" IsVisibleClear="true" IsVisibleDelete="true" IsVisibleFind="false" IsVisiblePrint="false" />
            </td>
        </tr>
    </table>
</asp:Content>

