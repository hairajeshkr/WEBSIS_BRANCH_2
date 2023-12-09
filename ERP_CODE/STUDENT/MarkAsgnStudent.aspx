<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MarkAsgnStudent.aspx.cs" Inherits="STUDENT_MarkAsgnStudent" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%--<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div style="height: 535px; width: 1180px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1180px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Student Mark Entry        
               </HeaderTemplate>                
             <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Staff Name"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Division"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdStaffName" runat="server" AccountType="CategoryList" />
                            </td>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" />
                            </td>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server"  AccountType="DivisionList"/>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Subject"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Term"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Exam"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdSubject" runat="server"  AccountType="CoScholasticMainSubject" />

                            </td>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdSelectTerm" runat="server" AccountType="TermMaster" />

                            </td>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdExam" runat="server" AccountType="ExamMaster" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Sub Exam"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="Label8" runat="server" Text="Entry Type"></asp:Label>
                             </td>
                             <td>
                                 <asp:Label ID="Label9" runat="server" Text="Grading system"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:CtrlGridList ID="CtrlGrdSubExam" runat="server" AccountType="ExamSubMaster" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlEntryType" runat="server" SkinID="DdlEntryType" Width="300px" >
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlGradingSystm" runat="server" Width="300px" SkinID="DdlGradingSystem">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                             <td>&nbsp;</td>
                             <td>&nbsp;</td>
                             <td>&nbsp;</td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" Text="Find" Width="69px" />
                            </td>
                             <td>&nbsp;</td>
                             <td>&nbsp;</td>
                        </tr>
                         <tr>
                            <td class="odd" colspan="3">
                                <div class="result-list" style="overflow: scroll;height:270px; width:1150px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="1100px" OnRowDataBound="GrdVwRecords_RowDataBound"  >
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="200px"></asp:Label>
                                                    <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                    <asp:HiddenField ID="HdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Adm.No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="200px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Mark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtMark" runat="server" Width="100px" Text='<%# Eval("ObtainedMark") %>' ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <ItemTemplate>
                                                  <%-- <asp:Label ID="LblGrade" runat="server" SkinID="LblGrdMaster"   Width="200px"></asp:Label>--%>
                                                    <asp:DropDownList ID="DdlGrade" runat="server" Width="100px"  >
                                                        <asp:ListItem Text="---select---" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="D" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             
                                        </Columns>
                                    </asp:GridView>
                                    
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" colspan="3">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleDelete="False"  IsVisiblePrint="True" />
                            </td>
                        </tr>
                    </table>
                <script type="text/javascript">
                    function FnUpdateMark(PrmTxtMark, PrmLblGrade) {
                        var TxtMark = document.getElementById(PrmTxtMark).value;
                        alert("hello");
                         LblGrade = document.getElementById(PrmLblGrade);
                        alert(LblGrade);
                        alert("function" + TxtMark);
                        if ((TxtMark >= 91) && (TxtMark <= 100)) {
                            LblGrade = 'A';
                        }
                        alert("hai");
                        //$.ajax({

                        //    type: "POST",
                        //    contentType: "application/json; charset=utf-8",
                        //    url: "MarkAsgnStudent.aspx/FnFillGrade",
                        //    data: "{'nAmount':'" + TxtMark + "'}",
                        //    dataType: "json",
                        //    success: function (data) {
                        //        var obj = data.d;
                        //        if (obj == 'true') {
                        //            $('#nAmount').val('');
                        //            $('#lblmsg').html("Details Submitted Successfully");
                        //            //window.location.reload();
                        //        }
                        //    },
                        //    error: function (result) {
                        //        alert("Error");
                        //    }
                        //});
                    }
                </script>
</ContentTemplate>
</ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

