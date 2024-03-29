<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptExam1.aspx.cs" Inherits="REPORT_FORMS_RptExam1" StylesheetTheme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="700px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Report Card
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label15" runat="server" Text="Student" Width="100px"></asp:Label>
                                            <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student" />
                                        </td>
                                        <td class="odd">
                                            &nbsp;</td>
                                    </tr>
                         <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label1" runat="server" Text="Template" Width="100px"></asp:Label>
                                            <uc2:CtrlGridList ID="CtrlGrdTemplate" runat="server" AccountType="ClassList" PlaceHoldr="Template" />
                                        </td>
                                        <td class="odd">
                                            &nbsp;</td>
                                    </tr>

                        <tr>
                            
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
</asp:Content>

