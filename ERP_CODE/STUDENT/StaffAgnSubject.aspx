﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffAgnSubject.aspx.cs" Inherits="STUDENT_StaffAgnSubject" StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1180px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px" Width="1150px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>Teacher Paper Allocation</HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <table class="auto-style1" style="height: 42px">
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label17" runat="server" Text="Teacher"></asp:Label></td>
                                        <td class="odd">
                                            <asp:DropDownList ID="DdlTeacher" runat="server" Width="300px"></asp:DropDownList>
                                        </td>
                                        <td class="odd">
                                            <asp:Button ID="BtnFind0" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" Style="left: -27px; top: -1px; right: -42px;" Text="FIND" Width="69px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 390px; width: 1150px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="1100px" ShowFooter="True" OnRowDeleting="GrdVwRecords_RowDeleting">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSelect" runat="server" /></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Papers">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlPapers" runat="server" Width="125px" SkinID="DdlInputType" AutoPostBack="true" OnSelectedIndexChanged="SelectedIndexChangedP"></asp:DropDownList></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Is CustomClass">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkIsCustomclass" OnCheckedChanged="ChkIsCustomclass_CheckedChanged" AutoPostBack="true" runat="server" /></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlClass" runat="server" Width="125px" SkinID="DdlInputType" AutoPostBack="true" OnSelectedIndexChanged="SelectedIndexChangedC"></asp:DropDownList></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlDivision" runat="server" Width="125px" SkinID="DdlInputType" AutoPostBack="true" OnSelectedIndexChanged="SelectedIndexChangedD"></asp:DropDownList></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Group Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtGroupName" runat="server" placeholder="Group Name" Width="200px"></asp:TextBox><asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <FooterTemplate>
                                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add+" OnClick="ButtonAdd_Click" UseSubmitBehavior="false" /></FooterTemplate>
                                                <FooterStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnStudents" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text="..." Width="100px" Enabled='<%# Eval("Status").ToString() == "A" ? true : false %>'></asp:Button></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleDelete="False" IsVisiblePrint="True" SaveText="Continue" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel4">
                <HeaderTemplate>Teacher-Student Allocation</HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 450px; width: 1150px">
                                    <asp:GridView ID="GrdVwPapers" runat="server" SkinID="GrdVwMasterNoPageing" Width="1100px" ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Paper">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPaper" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PaperName") %>'></asp:Label><asp:HiddenField ID="HdnIds" runat="server" Value='<%# Eval("Id") %>' />
                                                    <asp:HiddenField ID="HdnSubjId" runat="server" Value='<%# Eval("PaperId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDivision" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Group Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblGroupName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GroupName") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnStudent" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text="..." Width="100px"></asp:Button></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>



            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                <HeaderTemplate>Teacher Paper List</HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label></td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtName_Srch" runat="server"></asp:TextBox></td>
                                        <td class="odd">
                                            <asp:Label ID="Label2" runat="server" Text="Code"></asp:Label></td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtCode_Srch" runat="server"></asp:TextBox></td>
                                        <td class="odd">
                                            <asp:Button ID="BtnFind" runat="server" CommandName="FIND" SkinID="BtnCommandFind" Text="Find" Width="100px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 1150px">
                                    <asp:GridView ID="GrdVwLst" runat="server" SkinID="GrdVwMasterNoPageing" Width="1100px">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Staff Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton><asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPaperGroup" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PaperGroupName") %>' Width="100px"></asp:Label></ItemTemplate>
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

