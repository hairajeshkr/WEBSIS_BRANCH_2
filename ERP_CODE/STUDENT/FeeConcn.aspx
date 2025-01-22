<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeeConcn.aspx.cs" Inherits="STUDENT_FeeConcn" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/FeeConcn.js" type="text/javascript"></script>
    <div style="height: 470px; width: 890px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="460px" Width="880px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fee Concession 
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label9" runat="server" Text="Fee Concession Name" Width="100px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtName" runat="server" placeholder="Fee Concession Name"></asp:TextBox>
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label10" runat="server" Text="Code" Width="90px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtCode" runat="server" Enabled="False" placeholder="Code" SkinID="TxtCodeDisable"></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label1" runat="server" Text="Print Name" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtPrintName" runat="server" placeholder="Print Name"></asp:TextBox>
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" Text="Order Index" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtOrderIndex" runat="server" placeholder="Order Index" SkinID="TxtCode"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd">
                                <asp:CheckBox ID="ChkOwnAcc" runat="server" Font-Bold="False" SkinID="ChkSelect" Text="Create Own Account" Width="200px" />
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label5" runat="server" Text="Company" Width="90px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlCmp" runat="server" SkinID="DdlList">
                                </asp:DropDownList>
                            </td>
                            </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label4" runat="server" Text="Account Head" Width="120px"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdAcc" runat="server" AccountType="AccountLedger" PlaceHoldr="Account Head" />
                            </td>
                            <td class="odd">
                                </td>
                            <td class="odd">
                                <asp:CheckBox ID="ChkSwPro" runat="server" SkinID="ChkSelect" Text="Show in Student Profile" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                </td>
                            <td class="odd">
                                </td>
                            <td class="odd"></td>
                            <td class="odd">
                                </td>
                        </tr>
                         <tr>
                             <td class="odd">
                                 <asp:Label ID="Label8" runat="server" Width="100px">Remarks</asp:Label>
                             </td>
                             <td class="odd">
                                 <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                             </td>
                             <td class="odd">
                                 </td>
                             <td class="odd">
                                 <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="ChkBox" Text="Active" />
                             </td>
                        </tr>
                        <tr>
                            <td align="center" class="footercommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Fee Concession List
                </HeaderTemplate>
                <ContentTemplate>
                  <table style="width: 100%; height: 50px;">
                      <tr class="result-head">                         
                          <td >
                              <asp:Label ID="Label6" runat="server" Text="Name" Width="50px"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Name" SkinID="TxtSng200"></asp:TextBox>
                          </td>
                          <td >
                              <asp:Label ID="Label14" runat="server" Text="Code" Width="50px"></asp:Label>
                          </td>
                          <td >
                              <asp:TextBox ID="TxtCode_Srch" runat="server" placeholder="Code" SkinID="TxtCode"></asp:TextBox>
                          </td>
                           <td >
                              <asp:Label ID="Label7" runat="server" Width="320px"></asp:Label>
                          </td>
                          <td >
                               &nbsp;</td>
                          <td >
                              <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />
                          </td>
                      </tr>
                      <tr >
                          <td colspan="7" style="height: 39px">
                              <div class="result-list" style="overflow: scroll; height: 380px; width: 860px;">
                                  <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Fee Concession">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="300px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Code">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LblCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Code") %>' Width="100px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Print Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblPrName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PrintName") %>' Width="300px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Company">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCompName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AccCmpName") %>' Width="200px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Order Index">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblPrio" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OrderIndex") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Remarks">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblRemarks" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Remarks") %>' Width="300px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                      </Columns>
                                  </asp:GridView>
                              </div>
                          </td>
                      </tr>
                  </table>
              </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

