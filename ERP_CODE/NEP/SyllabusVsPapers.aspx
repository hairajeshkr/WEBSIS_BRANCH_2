﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SyllabusVsPapers.aspx.cs" Inherits="NEP_SyllabusVsPapers" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 600px; width: 870px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="580px" Width="850px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Paper Selection
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr class="result-head">
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Height="30px" Text="Filter Paper" Width="100px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtFilterPaper" runat="server" placeholder="Filter Paper"></asp:TextBox>

                            </td>
                            
                            <td class="odd">
                                <asp:Button ID="BtnFind" runat="server" CommandName="FIND" SkinID="BtnCommandFindNew" Text="FIND"  />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="4">
                                <table class="upload-field-parent" style="width: 63%; height: 253px;">
                                    <tr>
                                        <td colspan="2">
                                            <div class="result-list" style="overflow: scroll; height: 200px; width: 830px;">
                                                <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="810px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" OnCheckedChanged="ChkSelect_CheckedChanged" Value='<%# Eval("ChkSelect") %>' Checked='<%# Eval("ChkSelect").ToString() =="False"?false:true %>' AutoPostBack="true" />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Paper Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblPaper" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                                <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                                <asp:HiddenField ID="HdnSyllId" runat="server" Value='<%# Eval("SyllabusId") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub Exam">
                                                            <ItemTemplate>
                                                                <asp:Button ID="BtnSubExam" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text="..." Width="100px"></asp:Button>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Credit Hrs">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtCreditHrs" runat="server" placeholder="Credit Hrs" Width="100px"></asp:TextBox>


                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td class="odd" style="width: 99px">
                                            <asp:Label ID="Label1" runat="server" Text="Exam Template" Width="150px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc2:CtrlGridList ID="CtrlGrdTemplate" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="result-list" style="overflow: scroll; height: 230px; width: 830px;">
                                                <asp:GridView ID="GrdVwPaper" runat="server" SkinID="GrdVwMasterNoPageing" OnRowDeleting="OnRowDeleting" Width="810px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Paper Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblPaperName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PaperName") %>' Width="150px"></asp:Label>
                                                                 <asp:HiddenField ID="HdnPapaerCId" runat="server" Value='<%# Eval("PaperId") %>' />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sl No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSlNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SLNo") %>' Width="50px"></asp:Label>


                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sub Exam">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblSubExam" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SubExamName") %>' Width="120px"></asp:Label>


                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="print Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblPrintName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PrintName") %>' Width="120px"></asp:Label>


                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Report">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblReport" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ReportColumnName") %>' Width="120px"></asp:Label>
                                                                <asp:HiddenField ID="HdnReportCId" runat="server" Value='<%# Eval("ReportColumnId") %>' />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Max Mark">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtMaxMark" runat="server" placeholder="Max Mark" Text='<%# Eval("MaxMark") %>' Width="100px"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Percentage">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtPercentage" runat="server" placeholder="Percentage" Text='<%# Eval("Percentage") %>' Width="100px"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtOrder" runat="server" placeholder="Order" Text='<%# Eval("DisplayOrder") %>' Width="100px"></asp:TextBox>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="BtnDelete" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text="Delete" Width="60px" ></asp:Button>

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
                            <td class="Footercommand" colspan="4" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="Submit" OnClick="ValidateSumOfPercentages"  />
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>


            </ajaxToolkit:TabPanel>

        </ajaxToolkit:TabContainer>
    </div>

</asp:Content>

