<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeeMasterReg.aspx.cs" Inherits="STUDENT_FeeMasterReg" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/Fee.js" type="text/javascript"></script>


    <div style="height: 380px; width: 569px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="450px" Width="560px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff;">
            
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fees
                </HeaderTemplate>


                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label9" runat="server" Text="Fees Name" Width="90px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 40px">
                                <asp:TextBox ID="TxtName" runat="server" placeholder="Fees Name" Width="300px" Height="30px"></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label10" runat="server" Text="Code" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 40px">
                                <asp:TextBox ID="TxtCode" runat="server" Height="30px" placeholder="Code" SkinID="TxtCodeDisable" Enabled="false"></asp:TextBox>
                                <asp:CheckBox ID="ChkExfrmFine" runat="server" Text="Exclude From Fine" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 31px">
                                <asp:Label ID="Label3" runat="server" Text="Fees Type" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 31px">
                               <uc2:CtrlGridList ID="CtrlGrdFeeType" runat="server" PlaceHoldr="Fees Type" GridHeight="200" />
                            </td>
                            </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label1" runat="server" Text="Print Name" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 40px">
                                <asp:TextBox ID="TxtPrintName" runat="server" placeholder="Print Name"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label5" runat="server" Text="Company" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 40px">
                                <uc2:CtrlGridList ID="CtrlGrdInstitution" runat="server" GridHeight="200" PlaceHoldr="Company" />
                            </td>
                        </tr>
                         <tr>
                             <td class="odd" colspan="2" style="height: 30px">
                                 <asp:Label ID="Label2" runat="server" Text="Priority" Width="90px"></asp:Label>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtPriority" FilterType="Numbers" BehaviorID="_content_FilteredTextBoxExtender1"  />
                              <asp:TextBox ID="TxtPriority" runat="server" placeholder="Enter numbers" SkinID="TxtCode" ></asp:TextBox>
                          
                                 <asp:CheckBox ID="ChkOwnAcc" runat="server" Font-Bold="False" Text="Create Own Account" Width="157px" />
                             </td>
                        </tr>
                        <tr>
                             <td class="odd" style="width: 90px; height: 41px">
                                 <asp:Label ID="Label4" runat="server" Text="Account Head" Width="90px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 41px">
                                
                                <uc2:CtrlGridList ID="CtrlGrdAccHead" runat="server" GridHeight="200" PlaceHoldr="Account Head" />
                            </td>
                            </tr>
                        <tr>
                            <td class="odd" style="height: 30px" colspan="2">
                                <asp:CheckBox ID="ChkTutFee" runat="server" Font-Bold="False" Style="margin-left: 58px" Text="Tution Fee" Width="109px" />
                                <asp:CheckBox ID="ChkSwPro" runat="server" Font-Bold="False" Style="margin-left: 16px; margin-bottom: 0px;" Text="Show in Student Profile" Width="271px" />
                            </td>

                        </tr>
                        
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label8" runat="server" Width="90px">Remarks</asp:Label>
                            </td>
                            <td class="even">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        
                                    
                        <tr>
                            <td class="even">&nbsp;</td>
                            <td class="even">
                                <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Active" Width="92px" />
                            </td>
                        </tr>
                        
                                    
                        <tr>

                            <td></td>
                            <td class="FooterCommand" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>

                        </tr>
                        

                    </table>
                </ContentTemplate>


            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Fees List
                </HeaderTemplate>

                <ContentTemplate>
                  <table style="width: 100%; height: 50px;">
                      <tr class="result-head">                         
                          <td style="height: 39px">
                              <asp:Label ID="Label6" runat="server" Text="Name" Width="42px"></asp:Label>
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
                              <div class="result-list" style="overflow: scroll; height: 370px; width: 561px;">
                                  <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging"  SkinID="GrdVwMaster">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Name">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server"  CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Code">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Fees Type">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblFeeType" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("FeeType") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Print Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblPrName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PrintName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Company Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblCompName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AccCmpName") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Priority">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblPrio" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Priority") %>' Width="100px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <asp:BoundField DataField="IsFine" HeaderText="Exclude from Fine">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <%--<asp:CheckBoxField DataField="IsFine" HeaderText="Exclude from Fine" />--%>
                                          <asp:CheckBoxField DataField="Active" HeaderText="Active" />
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

