<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepartmentMaster.aspx.cs" Inherits="ADMIN_DepartmentMaster" StyleSheetTheme="SkinFile" Theme="SkinFile"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div style="height:385px; width:569px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="385px" Width="560px" BorderColor="White" BorderStyle="Solid"  BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Department Master
              </HeaderTemplate>
              
               <ContentTemplate>
                   <table class="auto-style1">
                      <tr><td class="odd" style="width: 83px">
                              <asp:Label ID="Label122" runat="server" Text="Department Name" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtName" runat="server" placeholder="Department Name"></asp:TextBox>
                          </td>
                          </tr>
                        <tr>
                          <td class="even" style="width: 83px">
                              <asp:Label ID="Label3" runat="server" Text="Code" Width="100px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" SkinID="TxtCodeDisable" Enabled="False"></asp:TextBox>
                          </td>
                      </tr>
                       <tr>
                         <td class="odd" style="width: 83px">
                              <asp:Label ID="Label1" runat="server" Text="Order Index" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtPriority" runat="server" placeholder="Order Index" SkinID="TxtCode" ></asp:TextBox>
                          
                          </td>
                      </tr>

                        <tr>
                          <td class="even" style="width: 83px">
                              <asp:Label ID="Label12" runat="server" Text="Remarks" Width="100px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                          </td>
                      </tr>

                        <tr>
                          <td class="odd" style="width: 83px"></td>
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
                      </tr>


                        <tr>
                          <td align="center" class="FooterCommand" colspan="2" valign="middle">
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                          </td>
                      </tr>      

                       </table>
              </ContentTemplate>


               </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Department MasterList
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table style="width: 100%; height: 0px;">
                      <tr class="result-head">                         
                          <td style="height: 39px">
                              <asp:Label ID="Label2" runat="server" Text="Name" Width="42px"></asp:Label>
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
                              <asp:Button ID="BtnFind" runat="server"  Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked" />
                          </td>
                      </tr>


                      <tr>
                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 300px; width: 529px;">
                                  <asp:GridView ID="GrdVwRecords" runat="server"   SkinID="GrdVwMaster" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging">
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
                                                  <asp:Label ID="LbloRDERiNDEX" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OrderIndex") %>' Width="100px"></asp:Label>
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

