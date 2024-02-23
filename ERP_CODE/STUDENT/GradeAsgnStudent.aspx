<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GradeAsgnStudent.aspx.cs" Inherits="STUDENT_GradeAsgnStudent" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 535px; width: 1180px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="545px" Width="1180px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Student Grade Entry        
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="height: 39px;width: 113px">
                                <asp:Label ID="Label1" runat="server" Text="Teacher"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlTeacher" runat="server" Width="300px" OnSelectedIndexChanged="DdlTeacher_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td class="odd" style="height: 39px;width: 176px">
                                <asp:Label ID="Label5" runat="server" Text="Paper"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlPaper" runat="server" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DdlPaper_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="height: 39px;width: 113px">
                                <asp:Label ID="Label2" runat="server" Text="Group"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlGroup" runat="server" AutoPostBack="True" Width="300px">
                                </asp:DropDownList>

                            </td>
                            <td class="odd" style="height: 39px;width: 176px">
                                <asp:Label ID="Label8" runat="server" Text="Exam"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlExam" runat="server" AutoPostBack="True" Width="300px" OnSelectedIndexChanged="DdlExam_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="height: 39px; width: 113px;">
                                <asp:Label ID="Label4" runat="server" Text="Sub Exam"></asp:Label>
                            </td>
                            <td class="odd" style="height: 39px">
                                <asp:DropDownList ID="DdlSubExam" runat="server" AutoPostBack="True" Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td class="odd" style="height: 39px; width: 176px;">
                                <asp:Label ID="Label10" runat="server" Text="Grading system"></asp:Label>
                            </td>
                            <td class="odd" style="height: 39px">
                                <asp:DropDownList ID="DdlGradingSystem" runat="server" Width="300px">
                                    </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" style="height: 39px;">
                                <asp:Label ID="Label9" runat="server" Text="Sort By"></asp:Label>
                            </td>
                            <td class="odd" style="height: 39px;">
                                <asp:DropDownList ID="DdlSortBy" runat="server" Width="300px">
                                    <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Roll Number" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Admn Number" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Name" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd" style="width: 176px; height: 39px;">
                                <asp:Label ID="Label7" runat="server" Text="Exam date"></asp:Label>
                            </td>
                            <td class="odd" style="height: 39px">&nbsp;<uc3:CtrlDate ID="CtrlExamDate" runat="server" IsVisibleDate="True" IsVisibleDateTime="True" />
                            </td>
                        </tr>

                        <tr>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd" style="width: 176px">
                                <asp:CheckBox ID="ChkMarkUpdated" runat="server" Text="Mark Updated" />
                            </td>
                            <td class="odd">
                                <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" Text="Find" Width="69px" />
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" colspan="4">
                                <div class="result-list" style="overflow: scroll; height: 285px; width: 1153px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="1130px" OnRowDataBound="GrdVwRecords_RowDataBound">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="250px"></asp:Label>
                                                    <asp:HiddenField ID="HdnRwIndex" runat="server" />
                                                    <asp:HiddenField ID="HdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Adm.No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAdmnNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Roll No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRollNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RollNo") %>' Width="90px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="100px"></asp:Label>
                                                    <asp:HiddenField ID="HdnClassId" runat="server" Value='<%# Eval("ClassId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDivision" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>
                                                    <asp:HiddenField ID="HdnDivId" runat="server" Value='<%# Eval("DivisionId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlStatus" runat="server" Width="83px" AutoPostBack="true" OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlGrade" runat="server"></asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" colspan="4">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleDelete="False" IsVisiblePrint="True" />
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

