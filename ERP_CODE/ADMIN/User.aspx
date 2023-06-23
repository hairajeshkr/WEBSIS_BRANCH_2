<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/User.js" type="text/javascript"></script>
    <div style="height:367px; width:569px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="365px" Width="560px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> User Registration
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table class="auto-style2">
                      <tr><td class="odd">
                              <asp:Label ID="Label1" runat="server" Text="Name / Code" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtName" runat="server" placeholder="Name"></asp:TextBox>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtCode" runat="server" placeholder="Name" SkinID="Txt100"></asp:TextBox>
                          </td>
                          <td class="odd"></td>
                      </tr>
                      <tr>
                          <td class="even">
                              <asp:Label ID="Label6" runat="server" Text="Staff Name" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <uc2:CtrlGridList ID="CtrlGrdStaff" runat="server" AccountType="StaffList" GridHeight="200" PlaceHoldr="Staff Name" />
                          </td>
                          <td class="even">
                              <asp:Label ID="Label15" runat="server" Height="18px" Width="102px"></asp:Label>
                          </td>
                          <td class="even"></td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label2" runat="server" Text="Password" Width="125px"></asp:Label></td>
                          <td align="left" class="odd">
                              <asp:TextBox ID="TxtPwd" runat="server" placeholder="Password"></asp:TextBox></td>
                          <td class="odd">
                          </td>
                          <td class="odd">
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label8" runat="server" Text="User Group" Width="125px"></asp:Label>
                          </td>
                          <td class="odd" align="left">
                              <uc2:CtrlGridList ID="CtrlGrdGrp" runat="server" AccountType="UserGroup" PlaceHoldr="User Group" GridHeight="200" />
                          </td>
                          <td class="odd"></td>
                          <td class="odd"></td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label17" runat="server" Text="Mobile No." Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <asp:TextBox ID="TxtMobNo" runat="server" placeholder="Mobile No."></asp:TextBox></td>
                          <td class="odd"></td>
                          <td class="odd"></td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label16" runat="server" Text="Email Address" Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                              <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email Address"></asp:TextBox>
                          </td>
                          <td class="odd"></td>
                          <td class="odd"></td>
                      </tr>
                      <tr>
                          <td class="even">
                              <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                          </td>
                          <td class="even"></td>
                          <td class="even"></td>
                      </tr>
                      <tr>
                          <td class="odd"></td>
                          <td class="odd">
                              <table border="0" cellpadding="0" cellspacing="0">
                                  <tr>
                                      <td style="width: 100px">
                                          <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Font-Bold="False" Text="Active" Width="92px" /></td>
                                      <td style="width: 100px">
                                          <asp:CheckBox ID="ChkApprove" runat="server" SkinID="ChkBox" Font-Bold="False" Text="Is Approve" Width="102px" Visible="False" /></td>
                                  </tr>
                              </table>
                                                       </td>
                          <td class="odd"></td>
                          <td class="odd"></td>
                      </tr>
                      <tr>
                          <td align="center" class="FooterCommand" colspan="4" valign="middle">
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                          </td>
                      </tr>                      
                  </table>
              </ContentTemplate>
              
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>User List
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table style="width: 100%; height: 0px;">
                      <tr class="result-head">                         
                          <td style="height: 39px">
                              <asp:Label ID="Label13" runat="server" Text="Name" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Name" SkinID="TxtSng200"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                              <asp:Label ID="Label14" runat="server" Text="Code" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:TextBox ID="TxtCode_Srch" runat="server" placeholder="Code" SkinID="TxtCode"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                              <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 300px; width: 529px;">
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
                                               <asp:TemplateField HeaderText="Staff">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StaffName") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="User Group">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GroupName") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="MobNo.">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblMobName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("MobNo") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Email">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblUomName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Email") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                      </Columns>
                                  </asp:GridView>
                              </div>
                          </td>
                      </tr>
                      <tr>
                          <td></td>
                          <td></td>
                          <td></td>
                          <td></td>
                          <td></td>
                      </tr>
                  </table>
              </ContentTemplate>
              
          </ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer>
    </div>  
</asp:Content>

