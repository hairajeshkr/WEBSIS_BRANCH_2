<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FineSettings.aspx.cs" Inherits="FIN_FineSettings" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<%@ Register Src="~/CtrlDateTime.ascx" TagPrefix="uc1" TagName="CtrlDateTime" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 990px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="980px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fine Settings
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" colspan="7">
                                <table class="upload-field-parent" style="width: 63%">
                                   
                                    <tr>
                                        <td rowspan="3">
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 256px;">
                                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1" style="margin-left: 0px">
                                                </asp:TreeView>
                                                <asp:Label ID="Message" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Student"></asp:Label>
                                                <asp:DropDownList ID="DdlStudent" runat="server" Width="170px" Height="25px" ></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Installment"></asp:Label>
                                                <asp:DropDownList ID="DdlInslment" runat="server" Width="170px" Height="25px" ></asp:DropDownList>
                                        </td>
                                         
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#FF6699" ></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Fuchsia" ></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#CC3399" ></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text="Label" Visible="false"></asp:Label>
                                            

                                        </td>
                                        </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 700px;">
                                                <asp:GridView ID="GrdVwRecordsMain" runat="server" SkinID="GrdVwMasterNoPageing" Width="604px">
                                                    <Columns>
                                                        <asp:BoundField />
                                                        <asp:TemplateField HeaderText="Fine name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDiv2" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="100px"></asp:Label>
                                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Due date">
                                                            <ItemTemplate>
                                                                <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="dd/MM/yyyy" SkinID="TxtCode"></asp:TextBox>--%>
                                                                <uc1:CtrlDate ID="CtrldueDate" runat="server" />
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtAmount" runat="server" placeholder="0.00" SkinID="TxtCode"></asp:TextBox>
                                                                <%--<asp:Label ID="LblDiv22" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Percentage">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtPercentage" runat="server" placeholder="0.00" SkinID="TxtCode"></asp:TextBox>
                                                                <%--<asp:Label ID="LblCnt1" runat="server" SkinID="LblGrdIdentify" Text='<%# Eval("Count") %>' Width="50px"></asp:Label>--%>
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
                             <td class="odd" style="width: 90px; "></td>
                             <td class="odd" colspan="2">
                                 
                                 
                             </td>
                             <td class="odd" style="width: 319px;">
                                 <asp:Button ID="BtnSubmit" runat="server" Text="Submit" SkinID="BtnAddSub" OnClick="Button1_Click" />
                             </td>
                             <td class="odd" style="width: 319px; height: 30px">&nbsp;</td>
                             </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Fine Settings List
              </HeaderTemplate>
              <%--<ContentTemplate>
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
              </ContentTemplate>--%>
              </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
