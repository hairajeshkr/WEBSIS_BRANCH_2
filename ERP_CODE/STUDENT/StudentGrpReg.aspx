<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentGrpReg.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentGrpReg" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/StudentGrpReg.js" type="text/javascript"></script>
    <div style="height:390px; width:790px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="390px" Width="780px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Group Registration
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table class="auto-style1">
                      <tr>
                          <td class="odd" width="100px">
                              <asp:Label ID="Label18" runat="server" Text="Group Name" Width="100px"></asp:Label>
                          </td>
                          <td align="left" class="odd" style="width: 190px">
                              <asp:TextBox ID="TxtName" runat="server" placeholder="Group Name"></asp:TextBox>
                          </td>
                          <td class="odd" style="width: 81px">
                              <asp:Label ID="Label19" runat="server" Text="Code" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" SkinID="TxtCode" Width="150px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label20" runat="server" Height="18px" Text="Parent GroupName" Width="120px"></asp:Label>
                          </td>
                          <td align="right" class="odd">
                              <uc2:CtrlGridList ID="CtrlGrdGrpname" runat="server" GridHeight="200" PlaceHoldr="Parent Group Name" />
                          </td>
                          <td class="odd" style="width: 81px">
                              <asp:Label ID="Label3" runat="server" Text="Abbreviation" Width="100px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtAbbrv" runat="server" placeholder="Abbreviation" SkinID="TxtCode" Width="150px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label6" runat="server" Text="Group Type" Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd">

                              <asp:CheckBoxList ID="ChkGrpType" runat="server" Width="315px" RepeatDirection="Horizontal" > 
                                  <asp:ListItem>Group</asp:ListItem>
                                  <asp:ListItem>Institution</asp:ListItem>
                                  <asp:ListItem>Class</asp:ListItem>
                                  <asp:ListItem>Division</asp:ListItem>
                                  <asp:ListItem>Student</asp:ListItem>
                              </asp:CheckBoxList>

                          </td>
                          <td style="width: 81px">
                              <asp:Label ID="Label25" runat="server" Text="Adm.No.Prefix" style="margin-left: 5px"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="TxtAdmPre" runat="server" placeholder="Admission Number Prefix" Width="150px" style="margin-left: 5px" ></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label17" runat="server" Text="Academic Year" Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd">
                         <uc2:CtrlGridList ID="CtrlGrdAyear" runat="server" AccountType="UserGroup" PlaceHoldr="Academic Year" GridHeight="200" />
                          </td>
                          <td style="width: 81px">
                              <asp:Label ID="Label1" runat="server" Text="Adm.No.Sufx" style="margin-left: 5px"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="TxtAdmNoSuf" runat="server" placeholder="Admission Number Suffix" Width="150px" style="margin-left: 5px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label16" runat="server" Text="Staff InCharge" Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd" style="width: 190px">
                              <uc2:CtrlGridList ID="CtrlGrdGrpstaff" runat="server"  PlaceHoldr="Staff InCharge" GridHeight="200" />
                          </td>
                          <td class="odd" style="width: 81px">
                            <asp:Label ID="Label2" runat="server" Text="Fee Receipt Prefix" Width="125px"></asp:Label>
                          </td>
                          <td class="odd">
                              <asp:TextBox ID="TxtFeeRecPre" runat="server" Width="150px" placeholder="Fee Receipt Prefix"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="odd">
                              <asp:Label ID="Label4" runat="server" Text="Chronological Order" Width="125px"></asp:Label>
                          </td>
                          <td align="left" class="odd" style="width: 190px">
                             <asp:TextBox ID="TxtChronOrder" runat="server" placeholder="Chronological Order"></asp:TextBox></td>
                          <td class="odd" style="width: 81px">
                             
                          </td>
                          <td class="odd">
                              <asp:CheckBox ID="ChkIsIns" runat="server" Width="150px" Text="IsInstitution" />
                          </td>
                      </tr>
                      <tr>
                          <td class="even">
                              <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                          </td>
                          <td class="even" style="width: 190px">
                              <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                          </td>
                      </tr>
                          <tr>
                              <td class="odd"></td>
                              <td class="odd" style="width: 190px">
                                  <table border="0" cellpadding="0" cellspacing="0">
                                      <tr>
                                          <td style="width: 100px">
                                              <asp:CheckBox ID="ChkHideGroup" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Hide Group" Width="92px" />
                                          </td>
                                          <td style="width: 100px">
                                              <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Active" Width="92px" />
                                          </td>
                                          <td style="width: 100px">
                                              <asp:CheckBox ID="ChkApprove" runat="server" Font-Bold="False" SkinID="ChkBox" Text="Is Approve" Visible="False" Width="102px" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td></td>
                                      </tr>
                                  </table>
                              </td>
                              <td class="odd" style="width: 81px"></td>
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
              <HeaderTemplate>Group List
              </HeaderTemplate>
              
              <ContentTemplate>
                  <table style="width: 100%; height: 0px;">
                      <tr class="result-head">                         
                          <td style="height: 39px">
                              <asp:Label ID="Label13" runat="server" Text="Name" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px; width: 258px;">
                              <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Name" SkinID="TxtSng200"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                              <asp:Label ID="Label14" runat="server" Text="Code" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px; width: 174px;">
                              <asp:TextBox ID="TxtCode_Srch" runat="server" placeholder="Code" SkinID="TxtCode"></asp:TextBox>
                          </td>
                          <td style="height: 39px">
                              <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 300px; width: 730px;">
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
                                                  <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("EmpName") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Parent Group Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ParentId") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Chronological Order">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblMobName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ChronicalOrder") %>' Width="150px"></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Abbreviation">
                                              <ItemTemplate>
                                                  <asp:Label ID="LblUomName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Abrevation") %>' Width="150px"></asp:Label>
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
                          <td class="modal-sm" style="width: 258px"></td>
                          <td></td>
                          <td style="width: 174px"></td>
                          <td></td>
                      </tr>
                  </table>
              </ContentTemplate>
              
          </ajaxToolkit:TabPanel>
           </ajaxToolkit:TabContainer>
        </div>
</asp:Content>

