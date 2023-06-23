<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Installment.aspx.cs" Inherits="FIN_Installment" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" src="Script/Installment.js" type="text/javascript"></script>

    <div style="height:385px; width:569px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="385px" Width="560px" BorderColor="White" BorderStyle="Solid"  BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Installment
              </HeaderTemplate>
              
               <ContentTemplate>
                   <table class="auto-style1">
                      <tr><td class="odd">
                              <asp:Label ID="Label122" runat="server" Text="Installment Name" Width="116px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtName" runat="server" placeholder="Installment Name"></asp:TextBox>
                          </td>
                          </tr>
                        <tr>
                          <td class="even">
                              <asp:Label ID="Label3" runat="server" Text="Code" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" SkinID="TxtCode"></asp:TextBox>
                          </td>
                        </tr>
                      <tr>
                          <td class="even">
                              <asp:Label ID="Label1" runat="server" Text="Abbrevation" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtAbbrevation" runat="server" placeholder="Abbrevation" SkinID="TxtCode"></asp:TextBox>
                          </td>
                        </tr>

                        <tr>
                          <td class="even">
                              <asp:Label ID="Label4" runat="server" Text="Priority" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtPriority" FilterType="Numbers" BehaviorID="_content_FilteredTextBoxExtender1"  />
                              <asp:TextBox ID="TxtPriority" runat="server" placeholder="Enter Numbers" SkinID="TxtCode"></asp:TextBox>
                          </td>
                        </tr>

                         <tr>
                        <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label5" runat="server" Text="Start Date" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <uc3:CtrlDate runat="server" ID="CtrlStartDate" />
                            </td>
                      </tr>

                        
                         <tr>
                        <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label6" runat="server" Text="Due Date" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <uc3:CtrlDate runat="server" ID="CtrlDueDate" />
                            </td>
                      </tr>
                        <tr>
                          <td class="even">
                              <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                          </td>
                          <td class="even">
                              <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                          </td>
                         </tr>

                       <tr>
                          <td class="odd"></td>
                          <td class="odd">
                              <table border="0" cellpadding="1" cellspacing="0">
                                  <tr>
                                      <td style="width: 100px">
                                      <asp:CheckBox ID="ChkECAInstallment" runat="server" SkinID="ChkBox" Font-Bold="False" Text="ECA Installment" Width="180px" /></td>
                                      <td style="width: 100px">
                                          <asp:CheckBox ID="ChkOneTimeInstallment" runat="server" SkinID="ChkBox" Font-Bold="False" Text="One Time Installment" Width="180px" /></td>
                                  </tr>
                              </table>
                             </td>
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
              <HeaderTemplate>Installment List
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
                              <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />
                          </td>
                      </tr>


                      <tr>
                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 310px; width: 529px;">
                                  <asp:GridView ID="GrdVwRecords" runat="server"  OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging"  SkinID="GrdVwMaster">
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

                                          <asp:TemplateField HeaderText="Abbrevation">
                                                <ItemTemplate>
                                                  <asp:Label ID="LblAbbrevation" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Abrevation") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Priority">
                                                <ItemTemplate>
                                                  <asp:Label ID="LblPriority" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Priority") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                           </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Start Date">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblFrmDate" runat="server" SkinID="LblGrdMaster" Text='<%# Bind("StartDate", "{0:dd-MMM-yyy}") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                           <asp:TemplateField HeaderText="Due Date">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblToDate" runat="server" SkinID="LblGrdMaster" Text='<%# Bind("EndDate", "{0:dd-MMM-yyy}") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>

                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                           <asp:CheckBoxField DataField="IsEca" HeaderText="ECA Installment" />
                                           <asp:CheckBoxField DataField="IsOneTime" HeaderText="One Time Installment" />
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

