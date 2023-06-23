<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DivisionReg.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_DivisionReg" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/Division.js" type="text/javascript"></script>
    <div style="height:367px; width:569px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="365px" Width="560px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Division Registration
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table class="auto-style1">

                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label122" runat="server" Text="Division Name" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtName" runat="server" placeholder="Division Name" Width="300px" Height="30px"></asp:TextBox>
                            </td>
                      </tr>
                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label1" runat="server" Text="Code" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" Width="200px" Height="30px"></asp:TextBox>
                            </td>
                      </tr>
                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label2" runat="server" Text="Class" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <uc1:CtrlGridList runat="server" ID="CtrlGrdCls" PlaceHoldr="Class" AccountType="ClassList"/>
                            </td>
                      </tr>
                      <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label3" runat="server" Text="Priority" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                              <asp:TextBox ID="TxtPriority" runat="server" placeholder="Priority" SkinID="TxtCode" ></asp:TextBox>
                          
                            </td>
                      </tr>
                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label12" runat="server" Text="Remarks" Width="105px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                      </tr>
                       <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Font-Bold="False" Text="Active" Width="92px" />
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
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Division List
              </HeaderTemplate>
              
              <ContentTemplate>
                <table>
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
                                          <asp:TemplateField HeaderText="Student Id">
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
                                          <asp:TemplateField HeaderText="Class">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Parent") %>' Width="150px"></asp:Label>
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
