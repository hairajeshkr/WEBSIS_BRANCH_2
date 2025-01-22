<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeeAllocation.aspx.cs" Inherits="FIN_FeeAllocation" StylesheetTheme="SkinFile"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="700px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    FEE Allocation
                
</HeaderTemplate>
                
<ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label15" runat="server" Text="Group" Width="100px"></asp:Label>

                                <uc2:CtrlGridList ID="CtrlGrdGroup" runat="server" AccountType="InstituteGroup" PlaceHoldr="Group" />

                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label1" runat="server" Text="Class" Width="100px"></asp:Label>

                                <uc2:CtrlGridList ID="CtrlGridClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />

                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                         <tr>
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" Text="Division" Width="100px"></asp:Label>

                                <uc2:CtrlGridList ID="CtrlGridDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />

                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label3" runat="server" Text="Student" Width="100px"></asp:Label>

                                 <uc2:CtrlGridList ID="CtrlGridStudent" runat="server" AccountType="DivisionStudentList" PlaceHoldr="Student" />

                            </td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisibleSave="true" IsVisiblePrint="False" SaveText="Allocate" style="position: relative; float: right" />

                            </td>
                        </tr>
                        <tr class="result-headTop">
                            <td align="center" class="Footercommand" valign="middle">&nbsp;</td>
                            <td align="center" class="Footercommand" colspan="3" valign="middle">&nbsp;</td>
                        </tr>
                    </table>
                    
</ContentTemplate>
                
</ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
</asp:Content>

