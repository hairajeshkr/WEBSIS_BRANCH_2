<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptSchoolCumulative.aspx.cs" Inherits="REPORT_FORMS_RptSchoolCumulative" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    School Cumulative Statistics
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                             <td class="odd" rowspan="7">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 250px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged" ShowCheckBoxes="All" ExpandDepth="0"   ></asp:TreeView>
                                    
                                </div>
                             <td class="odd" style="width: 354px">
                                 <asp:CheckBoxList ID="ChkReligionCat" runat="server" Width="298px" Height="120px">
                                     <asp:ListItem Text="Display Religion Wise Statistics" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Display Category Wise Statistics" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="Display BoardingType wise Statistics" Value="3"></asp:ListItem>
                                 </asp:CheckBoxList>
                                 <asp:CheckBox ID="ChKSelAll0" runat="server" Text="All" />
                                 <br />
&nbsp;
                                 </td>
                             <td class="odd" style="width: 172px">
                                 &nbsp;</td>
                             <td class="odd" style="width: 172px">
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px">
                                &nbsp;</td>
                           
                            <td class="odd" style="width: 172px">
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </td>
                            <td class="odd" style="width: 172px">
                                &nbsp;</td>
                           
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px; height: 20px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td class="odd" style="width: 354px; height: 20px;">
                                &nbsp;</td>
                            <td class="odd" style="width: 354px; height: 20px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                
                                &nbsp;</td>
                            
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                       
                        <tr>
                            <td class="odd" colspan="2">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                &nbsp;</td>
                            <td class="odd">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="True" SaveText="Export Excel" style="position:relative;float:right" />
                            </td>
                        </tr>
                       
                        <tr class="result-headTop">
                            <td align="center" class="Footercommand" valign="middle">
                                &nbsp;</td>
                            <td align="center" class="Footercommand" colspan="3" valign="middle">&nbsp;</td>
                        </tr>
                       
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>



