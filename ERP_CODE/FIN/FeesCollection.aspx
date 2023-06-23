<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" StylesheetTheme="SkinFile" CodeFile="FeesCollection.aspx.cs" Inherits="FIN_FeesCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 394px; width: 872px; margin-bottom: 28px;">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="840px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fee Receipt
                </HeaderTemplate>


                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 93px; height: 39px">
                                <asp:Label ID="Label1" runat="server" Text="Admission No."></asp:Label>
                            </td>
                            <td class="odd" style="width: 206px; height: 39px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="173px"></asp:TextBox>
                            </td>
                            <td class="odd" style="width: 90px; height: 39px">
                                <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td class="odd" style="height: 39px" colspan="2">
                                <asp:TextBox ID="TextBox2" runat="server" style="margin-right: 27px" Width="213px"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Height="25px" Text="...." Width="39px" />
                                <asp:Label ID="Label3" runat="server" Text="Details"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px">&nbsp;
                                <asp:Label ID="Label4" runat="server" Text="Receipt Date"></asp:Label>
                            </td>
                            <td style="width: 206px">
                                <uc1:CtrlDate ID="CtrlDate1" runat="server" />
                            </td>
                            <td style="width: 90px">
                                <asp:Label ID="Label5" runat="server" Text=" Group/Section"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="TextBox3" runat="server" Width="213px"></asp:TextBox>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Payable" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 93px">&nbsp;</td>
                            <td style="width: 206px">&nbsp;</td>
                            <td style="width: 90px">&nbsp;</td>
                            <td class="modal-sm" style="width: 190px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>

