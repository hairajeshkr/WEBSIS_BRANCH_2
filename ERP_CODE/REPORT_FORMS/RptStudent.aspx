<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudent.aspx.cs" Inherits="REPORT_FORMS_RptStudent" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="700px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Filter Students
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" rowspan="9">
                                &nbsp;</td>

                            <td class="odd" rowspan="9">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 220px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged" ShowCheckBoxes="All" ExpandDepth="0"   ></asp:TreeView>
                                    
                                </div>

                            </td>
                            <td class="odd" colspan="2" >
                                <asp:Label ID="Label122" runat="server" SkinID="LblBold" Text="Filter Criteria"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DdlFilter" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DdlFilter_SelectedIndexChanged" Width="198px">
                                    <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Admission Date" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Group Wise" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Religion search" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Community" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Category Filter" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="House Wise" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                            </td>

                            <td class="odd" >
                                <asp:Label ID="lblFromdate" runat="server" SkinID="LblBold" Text="From date"></asp:Label>
                            </td>
                            <td class="odd" >
                                <uc3:CtrlDate ID="CtrlFromDate" runat="server" />
                            </td>

                            <td class="odd" ">
                                &nbsp;</td>
                            <td class="odd" ></td>
                            <td class="odd" ></td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2" >
                                <asp:Label ID="lblreligion" runat="server" Enabled="False"  SkinID="LblBold" Text="Religion" ></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DdlReligion" runat="server" Width="198px">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                <asp:Label ID="lblduedate" runat="server" SkinID="LblBold" Text="Due Date"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc3:CtrlDate ID="CtrlDueDate" runat="server" />
                            </td>
                            <td colspan="2" rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                    <asp:CheckBoxList ID="ChkSelectColumns" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="Student Name" Value="cName"></asp:ListItem>
                                        <asp:ListItem Text="Reg.No" Value="cRegNo"></asp:ListItem>
                                        <asp:ListItem Text="Adhar No" Value="cAdharNo"></asp:ListItem>
                                        <asp:ListItem Text="Dob" Value="dDob"></asp:ListItem>
                                        <asp:ListItem Text="PhoneNo" Value="cPhoneNo"></asp:ListItem>
                                        <asp:ListItem Text="PinCode" Value="cPincode"></asp:ListItem>
                                        <asp:ListItem Text="PlaceofBirth" Value="cPlaceofBirth"></asp:ListItem>
                                        <asp:ListItem Text="BloodGroup" Value="cBloodGroup"></asp:ListItem>
                                        <asp:ListItem Text="Admission Date" Value="dJoinDate"></asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                                <asp:CheckBox ID="ChkSelectAllFields" runat="server" Text="Select All" OnCheckedChanged="ChkSelectAllFields_CheckedChanged" AutoPostBack="True"  />

                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 14px"> &nbsp;<td>
                            <td class="odd" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                               
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>

                        </tr>
                        <tr>
                            <td class="odd" style="width: 14px">&nbsp;</td>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                            <td class="odd" style="width: 31px">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="5" rowspan="5">
                                <div class="result-list" style="overflow: scroll; height: 268px; width: 800px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing">
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                            </td>
                        </tr>


                        <tr>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd" colspan="5" rowspan="2">&nbsp;</td>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                        </tr>


                        <tr>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>

                        <tr class="odd">
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" SkinID="LblBold" Text="Sort Order" Width="100px"></asp:Label>
                            </td>
                            <td style="width: 14px">
                                <asp:DropDownList ID="DdlSortOrder" runat="server" Width="200px">
                                    <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="ASC" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="DESC" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label4" runat="server" SkinID="LblBold" Text="Based On" Width="100px"></asp:Label>
                            </td>
                            <td style="width: 31px">
                                <asp:DropDownList ID="DdlBasedOn" runat="server" Width="200px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="result-headTop">
                            <td class="Footercommand" align="center" valign="middle">
                                &nbsp;</td>
                            <td align="center" class="Footercommand" colspan="7" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" SaveText="List" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
