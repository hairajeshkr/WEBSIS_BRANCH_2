<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TeacherVsStudents.aspx.cs" Inherits="STUDENT_TeacherVsStudents" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 450px; width: 800px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="440px" Width="780px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Student Selection
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr class="result-head">
                            <td class="odd" style="height: 55px" colspan="2">
                                <asp:Label ID="Label15" runat="server" Text="Class" Width="50px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 55px" >
                                <uc2:CtrlGridList ID="CtrlGrdClass" runat="server"  AccountType="ClassList" PlaceHoldr="Class" />
                            </td>
                            <td class="odd" style="height: 55px">
                                <asp:Label ID="Label137" runat="server" Text="Division" Width="50px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 55px">
                                <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                            </td>
                            </tr>
                        <tr>
                           
                            <td class="odd" style="height: 40px">
                                <asp:Button ID="BtnFind" runat="server" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked"  Text="FIND" Width="69px" />
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="odd" colspan="5">
                                <table class="upload-field-parent" style="width: 63%; height: 253px;">
                                    <tr>
                                        <td colspan="2">
                                            <div class="result-list" style="overflow: scroll; height: 290px; width: 780px;">
                                                <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="750px"  >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" runat="server" />
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" Checked='<%# Eval("ChkSelect").ToString() =="False"?false:true %>' AutoPostBack="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Student ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblStudentId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                                <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblStudentName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Admission No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblAdmissionNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Roll No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblRollNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Class">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDivision" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="210px"></asp:Label>
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
                            <td class="Footercommand" colspan="5" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="Submit" />

                            </td>
                        </tr>


                        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                        <script type="text/javascript">
                            $("[id*=GrdVwRecords] [id*=chkAll]").on("click", function () {
                                //Get the reference of Header CheckBox.
                                var chkAll = $(this);
                                //Loop through all GridView CheckBoxes except Header CheckBox.
                                $("[id*=GrdVwRecords] [id*=ChkSelect]").not("[id*=chkAll]").each(function () {
                                    $(this)[0].checked = chkAll[0].checked;
                                });
                            });
                        </script>
                        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                        <script type="text/javascript">
                            $("[id*=GrdVwRecords] [id*=ChkSelect]").on("click", function () {
                                //Get the reference of Header CheckBox.
                                var chkAll = $("[id*=GrdVwRecords] [id*=chkAll]");
                                //Set Header CheckBox checked to true.
                                chkAll[0].checked = true;
                                //Loop through all GridView CheckBoxes except Header CheckBox.
                                $("[id*=GrdVwRecords] [id*=ChkSelect]").not("[id*=chkAll]").each(function () {
                                    if (!$(this).is(":checked")) {
                                        chkAll[0].checked = false;
                                        return;
                                    }
                                });
                            });
                        </script>
                      
                    </table>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>
            
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>


