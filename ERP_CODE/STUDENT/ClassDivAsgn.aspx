<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClassDivAsgn.aspx.cs" StylesheetTheme="SkinFile" Inherits="STUDENT_ClassAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Class&Division Assign
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr class="result-head">
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Height="30px" Text="Class" Width="100px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>

                            <td class="odd">
                                <asp:Label ID="Label3" runat="server" Height="30px" SkinID="LblBold" Text="Division" Width="80px"></asp:Label>
                               </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                            </td>
                            <td class="odd">
                                <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" style="left: 3px; top: -3px" Text="FIND" Width="69px" />
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label123" runat="server" Height="30px" SkinID="LblBold" Text=" " Width="150px"></asp:Label>
                                </td>
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="7">
                                <table class="upload-field-parent" style="width: 63%">
                                    <tr>
                                        <td>
                                            <div class="result-list" style="overflow: scroll; height: 420px; width:800px;">
                                                <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" OnRowDataBound="GrdVwRecords_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSlNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SlNo") %>' Width="50px"></asp:Label>
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
                                                                <asp:HiddenField ID="Hdnstid" runat="server" Value='<%# Eval("StudentId") %>' />
                                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Existing Div.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDivNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="120px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlDiv" runat="server" SkinID="Ddl100" ></asp:DropDownList>
                                                                <asp:HiddenField ID="HdnDivId" runat="server" Value='<%# Eval("DivisionId") %>' />
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
                                                     
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 256px;">
                                                <asp:GridView ID="GrdVwSummary" runat="server" SkinID="GrdVwMasterNoPageing" OnRowDataBound="GrdVwSummary_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField />
                                                        <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDiv2" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="100px"></asp:Label>
                                                                  <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Count">
                                                              <ItemTemplate>
                                                                <asp:Label ID="LblCnt" runat="server" SkinID="LblGrdIdentify" Text='<%# FnCountDetails(Eval("Id"))%>' Width="50px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Gender">
                                                              <ItemTemplate>
                                                                <asp:Label ID="LblGender" runat="server" SkinID="LblGrdIdentify" Text='<%# FnGenderCntDetails(Eval("Id"))%>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                         <tr class="result-headTop">
                            <td class="Footercommand" colspan="7" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="Submit" />
                             </td>
                             </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Class&Division List
              </HeaderTemplate>
              <ContentTemplate>
                   <table class="auto-style1">
                        <tr class="result-head">
                            <td class="odd">
                                <asp:Label ID="Label1" runat="server" Height="30px" Text="Class" Width="100px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdClass_Srch" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>

                            <td class="odd">
                               </td>
                            <td class="odd">
                                 <asp:Label ID="Label2" runat="server" Height="30px" Text="Division" Width="80px"  SkinID="LblBold"></asp:Label>
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
                                <table class="upload-field-parent" style="width: 63%">
                                    <tr>
                                        <td>
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 700px;">
                                                <asp:GridView ID="GrdVwRecords_Srch" runat="server" SkinID="GrdVwMasterNoPageing">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSlNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SlNo") %>' Width="50px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="250px"></asp:Label>
                                                                <asp:HiddenField ID="Hdnstid" runat="server" Value='<%# Eval("StudentId") %>' />
                                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Id">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblStudentId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentCode") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Admission No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblAdmissionNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Class" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Roll No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblRollNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RollNo") %>' Width="60px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 256px;">
                                                <asp:GridView ID="GrdVwSummary_Srch" runat="server" SkinID="GrdVwMasterNoPageing" OnRowDataBound="GrdVwSummary_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField />
                                                        <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDiv2" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Count">
                                                              <ItemTemplate>
                                                                <asp:Label ID="LblCnt" runat="server" SkinID="LblGrdIdentify" Text='<%# Eval("Count") %>' Width="50px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Gender">
                                                              <ItemTemplate>
                                                                <asp:Label ID="LblGender" runat="server" SkinID="LblGrdIdentify" Text='<%# FnGenderCntDetailsSrch(Eval("DivisionId"))%>' Width="100px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
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
