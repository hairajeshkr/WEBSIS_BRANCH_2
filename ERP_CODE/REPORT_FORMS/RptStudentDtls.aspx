<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudentDtls.aspx.cs" Inherits="REPORT_FORMS_RptStudentDtls" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
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
                             <td class="odd" rowspan="7" style="width: 449px">
                                
                            <td class="odd" style="height: 54px">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 220px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" ExpandDepth="0" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged" ShowCheckBoxes="All">
                                    </asp:TreeView>
                                </div>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                 <td class="odd" colspan="2" style="height: 54px">
                                     </td>
                                 <td class="odd" style="height: 54px"></td>
                        </tr>
                        
                        <tr>
                            <td class="odd" rowspan="2" colspan="2">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" SaveText="List" />
                            </td>
                            <td class="odd" rowspan="2" colspan="2">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" colspan="2">&nbsp;</td>
                            <td class="odd" rowspan="2" colspan="2">
                                </td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd" rowspan="2" colspan="2">&nbsp;</td>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2" style="width: 449px">&nbsp;</td>
                            <td class="odd" rowspan="2" colspan="2">&nbsp;</td>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">&nbsp;</td>
                        </tr>
                       
                        <tr class="result-headTop">
                            <td align="center" class="Footercommand" valign="middle" style="width: 449px">
                                &nbsp;</td>
                            <td align="center" class="Footercommand" colspan="4" valign="middle">&nbsp;</td>
                        </tr>
                       
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>

