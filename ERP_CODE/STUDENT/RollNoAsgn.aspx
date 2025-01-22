<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RollNoAsgn.aspx.cs" StylesheetTheme="SkinFile" Inherits="STUDENT_RollNoAsgn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 555px; width: 980px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="545px" Width="980px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Roll No Assign
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                             <tr>
                            <td class="odd" style="width: 60px; ">
                                <asp:Label ID="Label123" runat="server" Text="Class" Width="100px" Height="30px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px;">
                                 <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>

                            <td class="odd" style="width: 60px; ">
                                <asp:Label ID="Label125" runat="server" Height="30px" SkinID="LblBold" Text="Sort By Name" Width="120px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px; ">
                                 <asp:RadioButtonList ID="RadBtnName" runat="server" SkinID="RadBtnSort">
                                 </asp:RadioButtonList>
                                 </td>
                            <td class="odd" style="width: 100px; height: 30px">
                                <asp:Label ID="Label155" runat="server" Text="Starting Roll No." SkinID="LblBold" Width="130px"></asp:Label>
                                </td>
                        </tr>
                             <tr>
                                 <td class="odd" style="width: 60px; ">
                                     <asp:Label ID="Label124" runat="server" Height="30px" SkinID="LblBold" Text="Division" Width="80px"></asp:Label>
                                 </td>
                                 <td class="odd" style="width: 150px;">
                                     <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                                 </td>
                                 <td class="odd" style="width: 60px; ">
                                     <asp:Label ID="Label1" runat="server" SkinID="LblBold" Text="Sort By Gender" Width="150px"></asp:Label>
                                 </td>
                                 <td class="odd" style="width: 150px; ">
                                     <asp:RadioButtonList ID="RadBtnGender" runat="server" SkinID="RadBtnSexBoth">
                                     </asp:RadioButtonList>
                                 </td>
                                 <td class="odd" style="width: 100px; height: 30px">
                                     <asp:TextBox ID="txtStartingRollNo" runat="server" placeholder="RollNo" SkinID="Txt140" Width="130px"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr class="result-head">
                                 <td class="odd" style="width: 60px; ">
                                     </td>
                                 <td class="odd" style="width: 150px;">
                                     <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" Text="FIND" Width="69px" />
                                 </td>
                                 <td class="odd" style="width: 60px; ">
                                     <asp:Label ID="Label126" runat="server" SkinID="LblBold" Text="Sort By Language" Width="150px"></asp:Label>
                                 </td>
                                 <td class="odd" style="width: 150px; ">
                                     <asp:DropDownList ID="DdlLanguage" runat="server" SkinID="DdlList200">
                                     </asp:DropDownList>
                                 </td>
                                 <td class="odd" style="width: 100px; height: 30px">
                                     <asp:Button ID="BtnAssign" runat="server" CommandName="ASGN" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandSave" Text="Assign Roll No." Width="130px" />
                                 </td>
                             </tr>
                        <tr class="result-head">
                            <td colspan="5">
                                <div class="result-list" style="overflow: scroll; height: 360px; width: 943px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMaster">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Roll No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRollNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RollNo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admission No.">
                                            <ItemTemplate>
                                                <asp:Label ID="LblAdmissionNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="300px"></asp:Label>
                                                <asp:HiddenField ID="HdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Id">
                                            <ItemTemplate>
                                                <asp:Label ID="LblStudentId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentCode") %>' Width="120px"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Class" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="150px"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                            <ItemTemplate>
                                                <asp:Label ID="LblDiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Roll No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtRollNo" runat="server" SkinID="TxtGrdCentre100" Text='<%# Eval("RollSlNo") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                         <tr>
                          <td align="center" class="FooterCommand" colspan="5" valign="middle">
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="false" IsVisiblePrint="false" />
                          </td>
                      </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Roll No Assign List
              </HeaderTemplate>
              <ContentTemplate>
                  <table class="auto-style1">
                        <tr class="result-head">
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" Height="30px" Text="Class" Width="100px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdClass_Srch" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>

                            <td class="odd">
                               </td>
                            <td class="odd">
                                 <asp:Label ID="Label3" runat="server" Height="30px" Text="Division" Width="80px"  SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdDivision_Srch" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                            </td>
                            <td class="odd">
                                </td>
                            <td class="odd">
                                <asp:Button ID="BtnFind_Srch" runat="server" Text="FIND" Width="69px" CommandName="FIND_SRCH" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="7">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 943px;">
                                    <asp:GridView ID="GrdVwRecords_Srch" runat="server" SkinID="GrdVwMaster">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Roll No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRollNo1" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RollNo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Admission No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAdmNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                       <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="350px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDivision" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="120px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Id">
                                                <ItemTemplate>
                                                   <asp:Label ID="LblStudentId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentCode") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                         <tr class="result-headTop">
                            <td class="footercommand" colspan="7" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand2" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" ClearCommandName="CLEAR_SRCH" IsVisibleSave="False" />
                             </td>
                             </tr>
                    </table>
              </ContentTemplate>
              </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
