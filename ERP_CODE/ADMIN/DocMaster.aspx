﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DocMaster.aspx.cs" Inherits="ADMIN_DocMaster" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc5" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" src="Script/Division.js" type="text/javascript"></script>
    <div style="height:385px; width:569px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="385px" Width="560px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
              <HeaderTemplate>Documentation Register
              </HeaderTemplate>
              <ContentTemplate>
                      <table class="auto-style1">
                          <tr>
                              <td class="odd" style="width: 90px; height: 30px">  
                                  <asp:Label ID="Label122" runat="server" Text="Documentation Name " Width="120px" Height="30px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 319px; height: 30px">
                                  <asp:TextBox ID="txtName" runat="server" placeholder="Documentation Name" Width="300px" Height="30px"></asp:TextBox>
                              </td>
                              </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height: 30px">
                                  <asp:Label ID="Label125" runat="server" Height="30px" Text="Documentation Type" Width="120px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 319px; height: 20px">
                                  <asp:CheckBoxList ID="ChkDtype" runat="server" RepeatDirection="Horizontal" >
                                      <asp:ListItem Text="Staff&amp;nbsp" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="&nbspStudent" Value="2"></asp:ListItem>
                                  </asp:CheckBoxList>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height: 30px">
                                  <asp:Label ID="Label1" runat="server" Text="Priority" Width="120px" Height="30px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 319px; height: 30px">
                                  <asp:TextBox ID="TxtPriority" runat="server" placeholder="Enter numbers" Width="300px" Height="30px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height: 30px">
                                  <asp:Label ID="Label12" runat="server" Text="Remarks" Width="105px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 319px; height: 30px">
                                  <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 319px; height: 30px"></td>
                              <td class="odd" style="width: 319px; height: 30px">
                                  <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Visible="False" Font-Bold="False" SkinID="IsActive" Text="Active" Width="92px" />
                              </td>
                          </tr>
                          <tr>
                              <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                  <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                              </td>
                          </tr>
                      </table>
              </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
              <HeaderTemplate>Documentation Register Details
              </HeaderTemplate>
              <ContentTemplate>
                  <table style="width: 100%; height: 0px;">
                      <tr class="result-head">                         
                          <td style="height: 39px;width:50px;" >
                              <asp:Label ID="Label2" runat="server" Text="Name" Width="20px" ></asp:Label>
                          </td>
                          <td style="height: 39px;width:120px">
                              <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Name" SkinID="TxtCode" Width="80px"></asp:TextBox>
                          </td>
                          <td style="height: 39px;width:50px;width:120px;">
                              <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" style="left: 236px; top: 3px" />
                          </td>
                          <td style="height: 39px;width:50px;width:100px;">
                          </td>
                      </tr>

                      <tr>
                          <td colspan="5">
                  <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>
                               <asp:TemplateField HeaderText="Name">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Code">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Priority">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OrderIndex") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                              <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                              <ItemStyle Width="200px" />
                              </asp:BoundField>
                          </Columns>
                      </asp:GridView>
                  </div>
                              </td>
                              </tr>
                      <tr>
                          <td></td>
                          <td colspan="2"></td>
                          <td></td>
                          <td></td>
                          <td></td>
                      </tr>
                      
              </ContentTemplate>
          </ajaxToolkit:TabPanel>
          </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
