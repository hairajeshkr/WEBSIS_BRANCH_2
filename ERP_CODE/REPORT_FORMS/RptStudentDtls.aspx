<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudentDtls.aspx.cs" Inherits="REPORT_FORMS_RptStudentDtls" StylesheetTheme="SkinFile" %>


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
                    Campus Statistics
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" rowspan="6" >
                                <div class="result-list" style="overflow: scroll; height: 400px; width: 250px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" ShowCheckBoxes="All" ExpandDepth="0"></asp:TreeView>

                                </div>

                            </td>
                            <td class="odd"  >
                                <asp:Label ID="Label122" runat="server" SkinID="LblBold" Text="Filter Criteria" Width="100px"></asp:Label>
                            </td>

                            <td class="odd" >
                                <asp:DropDownList ID="DdlFilter" runat="server" AppendDataBoundItems="True" AutoPostBack="True" SkinID="DdlFilterCriteria">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" >
                                <asp:Label ID="lblreligion" runat="server" Enabled="False" SkinID="LblBold" Text="Religion" Width="146px"></asp:Label>
                            </td>
                            <td class="odd" >
                                <asp:DropDownList ID="DdlReligion" runat="server" Style="margin-bottom: 0px" Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" >
                                <asp:Label ID="lblFromdate" runat="server" SkinID="LblBold" Text="From Date" Width="146px"></asp:Label>
                            </td>
                            <td class="odd" colspan="1" >
                                <uc3:CtrlDate ID="CtrlFromDate" runat="server" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="lblduedate" runat="server" SkinID="LblBold" Text="Due Date" Width="146px"></asp:Label>
                            </td>
                            <td class="odd" colspan="1" >
                                <uc3:CtrlDate  ID="CtrlDueDate" runat="server" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        
                        <tr>
                            
                            <td class="odd" rowspan="2" colspan="2">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" SaveText="Export Excel" style="position:relative;float:right" />
                            </td>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd" rowspan="2">&nbsp;</td>
                        </tr>

                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

