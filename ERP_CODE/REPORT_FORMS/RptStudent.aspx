<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudent.aspx.cs" Inherits="REPORT_FORMS_RptStudent" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Filter Students
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>

                            <td class="odd" rowspan="11">
                                <div class="result-list" style="overflow: scroll; height: 470px; width: 250px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" ShowCheckBoxes="All" ExpandDepth="0"></asp:TreeView>

                                </div>

                            </td>
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" SkinID="LblBold" Text="Filter Criteria" Width="100px"></asp:Label>
                            </td>

                            <td class="odd">
                                <asp:DropDownList ID="DdlFilter" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DdlFilter_SelectedIndexChanged" SkinID="DdlFilterCriteria">
                                </asp:DropDownList>
                            </td>

                            <td class="odd" rowspan="11"></td>
                            <td class="odd" rowspan="11"></td>
                            <td class="odd" rowspan="11"></td>
                            <td class="odd" rowspan="11">
                                <asp:CheckBox ID="ChkSelectAllFields" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectAllFields_CheckedChanged" Text="Select All" />
                                <div class="result-list" style="overflow: scroll; height: 470px; width: 250px; align-content: ">
                                    <asp:CheckBoxList ID="ChkSelectColumns" runat="server" AutoPostBack="True" SkinID="ChkSelectColumns">
                                    </asp:CheckBoxList>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="lblreligion" runat="server" Enabled="False" SkinID="LblBold" Text="Religion"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlReligion" runat="server" Style="margin-bottom: 0px" Width="300px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="lblFromdate" runat="server" SkinID="LblBold" Text="From date"></asp:Label>
                            </td>
                                <td class="odd" colspan="1">
                                    <uc3:CtrlDate ID="CtrlFromDate" runat="server" />
                                </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="lblduedate" runat="server" SkinID="LblBold" Text="Due Date"></asp:Label>
                            </td>
                            <td class="odd" colspan="1">
                                <uc3:CtrlDate ID="CtrlDueDate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" SkinID="LblBold" Text="Sort Order" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlSortOrder" runat="server" SkinID="DdlSortOrder">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>

                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label4" runat="server" SkinID="LblBold" Text="&amp;nbspBased On&amp;nbsp" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlBasedOn" runat="server" SkinID="DdlBasedOn">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr class="odd">
                            <td>&nbsp;</td>
                            <td style="width: 50px">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td></td>
                        </tr>
                        <tr class="odd">
                            <td>&nbsp;</td>
                            <td style="width: 50px">
                                &nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr class="odd">
                            <td>&nbsp;</td>
                            <td style="width: 50px">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="odd">
                            <td>&nbsp;</td>
                            <td style="width: 50px">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" SaveText="List" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

                        <tr>
                            <td align="center" class="Footercommand" colspan="4" valign="middle">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>

                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
