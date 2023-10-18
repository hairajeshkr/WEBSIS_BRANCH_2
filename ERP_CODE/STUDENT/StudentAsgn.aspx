<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAsgn.aspx.cs" Inherits="STUDENT_StudentAsgn" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Class&Division Assign
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label125" runat="server" Height="30px" Text="Group" Width="80px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdGroup" runat="server" AccountType="InstituteGroup" PlaceHoldr="Group" />
                            </td>

                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Height="30px" SkinID="LblBold" Text="Class" Width="100px"></asp:Label>
                               </td>
                            <td class="odd">
                                 <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="Label123" runat="server" Height="30px" SkinID="LblBold" Text=" " Width="150px"></asp:Label>
                                </td>
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label3" runat="server" Height="30px" SkinID="LblBold" Text="Division" Width="80px"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label124" runat="server" Height="30px" SkinID="LblBold" Text="Student" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student" />
                            </td>
                            <td class="odd">
                                <asp:Button ID="BtnFind0" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" style="left: 3px; top: -3px" Text="FIND" Width="69px" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="7">
                                <table class="upload-field-parent" style="width: 63%">
                                    <tr>
                                        <td>
                                            <div class="result-list" style="overflow: scroll; height: 420px; width:1200px;">
                                                <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" OnRowDataBound="GrdVwRecords_RowDataBound"  >
                                                   <Columns>
                                                       <asp:TemplateField HeaderText="Student Name">
                                                           <ItemTemplate>
                                                               <asp:HiddenField ID="Hdnstid" runat="server" Value='<%# Eval("StudentId") %>' />
                                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                               <table class="upload-field-parent">
                                                                   <tr>
                                                                       <td>
                                                                           <asp:DropDownList ID="DdlSaltn" runat="server">
                                                                           </asp:DropDownList>
                                                                       </td>
                                                                       <td>
                                                                           <asp:TextBox ID="TxtName" runat="server" Text='<%# Eval("StudentName") %>'></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </table>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Father Name">
                                                           <ItemTemplate>
                                                               <table class="upload-field-parent">
                                                                   <tr>
                                                                       <td>
                                                                           <asp:DropDownList ID="DdlSaltnFthr" runat="server"></asp:DropDownList>
                                                                       </td>
                                                                       <td>
                                                                            <asp:TextBox ID="TxtFName" runat="server" Text='<%# Eval("StudentName") %>'></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </table>


                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Mother Name">
                                                           <ItemTemplate>

                                                               <table class="upload-field-parent">
                                                                   <tr>
                                                                       <td>
                                                                           <asp:DropDownList ID="DdlSaltnMthr" runat="server"></asp:DropDownList>
                                                                       </td>
                                                                       <td>
                                                                            <asp:TextBox ID="TxtMName" runat="server" Text='<%# Eval("StudentName") %>'></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </table>                                                       
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Guardian Name">
                                                           <ItemTemplate>
                                                                <table class="upload-field-parent">
                                                                   <tr>
                                                                       <td>
                                                                           <asp:DropDownList ID="DdlSaltnGurdn" runat="server"></asp:DropDownList>
                                                                       </td>
                                                                       <td>
                                                                            <asp:TextBox ID="TxtGName" runat="server" Text='<%# Eval("StudentName") %>'></asp:TextBox>
                                                                       </td>
                                                                   </tr>
                                                               </table>                                                                

                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="Admission No.">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtAdmNo" runat="server" Text='<%# Eval("AdmissionNo") %>'></asp:TextBox>
                                                               <%--<asp:Label ID="LblAdmissionNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="120px"></asp:Label>--%>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Student Id">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtStuId" runat="server" Text='<%# Eval("StudentCode") %>'></asp:TextBox>
                                                               <%--<asp:Label ID="LblStudentId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentCode") %>' Width="120px"></asp:Label>--%>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="Roll No.">
                                                           <ItemTemplate>
                                                               <%--<asp:Label ID="LblDivNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="120px"></asp:Label>--%>
                                                               <asp:TextBox ID="TxtRollNO" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Student Mob.No.">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtStMobNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                                               <%--<asp:TextBox ID="TxtMobile" runat="server" Text='<%# Eval("PhoneNo") %>'  ></asp:TextBox>--%>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Father Mob.No.">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtFthrMobNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                                               <%--<asp:TextBox ID="TxtMobile" runat="server" Text='<%# Eval("PhoneNo") %>'  ></asp:TextBox>--%>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Mother Mob.No.">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtMthrMobNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                                               <%--<asp:TextBox ID="TxtMobile" runat="server" Text='<%# Eval("PhoneNo") %>'  ></asp:TextBox>--%>
                                                           </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Guardian Mob.No.">
                                                           <ItemTemplate>
                                                               <asp:TextBox ID="TxtGrdMobNo" runat="server" Text='<%# Eval("RollNo") %>'></asp:TextBox>
                                                               <%--<asp:TextBox ID="TxtMobile" runat="server" Text='<%# Eval("PhoneNo") %>'  ></asp:TextBox>--%>
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
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>

