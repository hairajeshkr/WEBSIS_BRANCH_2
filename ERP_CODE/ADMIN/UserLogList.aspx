<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogList.aspx.cs" Inherits="UserLogList" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Src="../CtrlDateTime.ascx" TagName="CtrlDateTime" TagPrefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="Script/UserGroup.js"></script>
                     <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="440px" Width="885px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>
USER LOG DETAILS 
</HeaderTemplate>
<ContentTemplate>
                    <div style="overflow: scroll; width: 874px; height:430px" id="DIV1" onclick="return DIV1_onclick()">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 100px">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 378px">
                    <tr>
                        <td style="width: 100px">
                            <asp:Label id="Label3" runat="server" SkinID="LblBold" Text="User Name" Width="79px"></asp:Label></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TxtUserName" runat="server" SkinID="TxtCode"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:Label id="Label2" runat="server" SkinID="LblBold" Text="User Group" Width="80px"></asp:Label></td>
                        <td style="width: 100px">
                            <uc2:CtrlGridList ID="CtrlGrdUserGroup" runat="server" AccountType="UserGroup" PlaceHoldr="User Group" />
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label4" runat="server" SkinID="LblBold" Text="  " Width="50px"></asp:Label>
                        </td>
                        <td style="width: 100px">
                            <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Width="87px" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="BtnFetch" runat="server" CommandName="FIND" Height="37px" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnSimple" Text="SEARCH" Width="100px" />
                        </td>
                        <td style="width: 100px">
                            </td>
                    </tr>
                </table></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" 
                                    OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging"  OnRowDataBound="GrdVwRecords_RowDataBound" OnRowDeleting="GrdVwRecords_RowDeleting" 
                                    SkinID="GrdVwMaster" Width="340px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" SkinID="LblRedBold" Text='<%# Bind("SlNo") %>' Width="50px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="USER NAME"><ItemTemplate>
                                        <asp:Label id="LblName" runat="server" Width="150px" Text='<%# Eval("UserName") %>' SkinID="LblGrdMaster" ></asp:Label>
                                            <asp:HiddenField id="HdnUserId" runat="server" Value='<%# Eval("UserId") %>'></asp:HiddenField> 
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="USER GROUP"><ItemTemplate>
                                        <asp:Label id="LblGrp" runat="server" Width="200px" Text='<%# Eval("UserGrpName") %>' SkinID="LblGrdMaster" ></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LOGIN DATE TIME">
                                            <ItemTemplate>
                                                <asp:Label ID="LogIn" runat="server" SkinID="LblBold" Text='<%# Bind("LogInDateTime", "{0:dd/MMM/yyyy hh:mm:tt}") %>' Width="175px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LOGOUT DATE TIME">
                                            <ItemTemplate>
                                                <asp:Label ID="LblLogOut" runat="server" SkinID="LblDarGreen" Text='<%# Bind("LogOutDateTime", "{0:dd/MMM/yyyy hh:mm:tt}") %>' Width="175px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LOG OUT">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkLogOut" runat="server" CommandName="DELETE" SkinID="LnkBtnGrdMain" Text="LOG OUT" Width="83px"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label id="lblMsg" runat="server" SkinID="LblReadOnly" Text="Nothing Record's"  Visible="False" Width="100%"></asp:Label></td>
                        </tr>
                    </table></div>
    </ContentTemplate>
</ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer> 
</asp:Content>

