 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsSettings.aspx.cs" Inherits="FIN_ConsSettings" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
    .fa-calendar:before 
    {
        content: "\f073";
        color: floralwhite;
    }
        </style>
    <script language="javascript" src="Script/ConsSettings.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1080px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fee Assign Settings
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 90px;">
                                <div class="result-list" style="overflow: scroll; height: 470px; width: 150px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" BorderStyle="None" ExpandDepth="0" ImageSet="Simple" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#FF0066" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                                        <ParentNodeStyle Font-Bold="False" />
                                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                </div>
                            </td>
                            <td class="odd">
                                <table>
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label15" runat="server" Text="Group" Width="80px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGrdGroup" runat="server" AccountType="InstituteGroup" PlaceHoldr="Group" />
                                        </td>
                                        <td class="odd">
                                            <asp:Label ID="Label17" runat="server" Text="Class" Width="80px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGridClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                                        </td>
                                        <td class="odd">
                                            <asp:Label ID="Label19" runat="server" Width="120px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="result-head">
                                        <td class="odd">
                                            <asp:Label ID="Label10" runat="server" Text="Division" Width="80px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGridDivision" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                                        </td>
                                        <td class="odd">
                                            <asp:Label ID="Label18" runat="server" Text="Student" Width="80px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGridStudent" runat="server" AccountType="DivisionStudentList" PlaceHoldr="Student" />
                                        </td>
                                        <td class="odd">
                                            <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFind" Text="Find" Width="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="odd" colspan="5">
                                            <table class="upload-field-parent">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server" SkinID="LblFuchsiaBold" Text="Fee Calculation" Width="200px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label21" runat="server" SkinID="LblFuchsiaBold" Text="Fee Master Summary" Width="200px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="result-list1" style="overflow: scroll; height: 380px; width: 650px">
                                                            <asp:GridView ID="GrdVwRecords" runat="server" OnRowDataBound="GrdVwRecords_RowDataBound" ShowHeader="False" SkinID="GrdVwNoPageingMain" Width="604px">
                                                                <Columns>
                                                                    <asp:BoundField />
                                                                    <asp:TemplateField HeaderText="SlNo."></asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Installment Name">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="LblSlNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SlNo") %>' Width="40px"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="360px"></asp:Label>
                                                                                        <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="LblWdth2" runat="server" SkinID="LblGrdMaster" Text=" " Width="10px"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TxtInstalAmt" runat="server" SkinID="TxtDigit120Disable"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="7">
                                                                                        <asp:GridView ID="GrdVwChild" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GrdVwChild_RowDataBound" ShowHeader="False" SkinID="GrdVwMasterNoPageing" Width="520px">
                                                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="LblWdth" runat="server" SkinID="LblGrdMaster" Text=" " Width="20px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="LblSlNo0" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SlNo") %>' Width="40px"></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Fee Master Name">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="LblName0" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="360px"></asp:Label>
                                                                                                        <asp:HiddenField ID="HdnFeeId" runat="server" Value='<%# Eval("ID") %>' />
                                                                                                        <asp:HiddenField ID="HdnRwIndex" runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:TextBox ID="TxtAmount" runat="server" SkinID="TxtRateCentre"></asp:TextBox>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <EditRowStyle BackColor="#999999" />
                                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <br />
                                                            <br />
                                                            <br />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="result-list1" style="overflow: scroll; height: 380px; width: 260px;">
                                                            <asp:GridView ID="GrdVwSummary" runat="server" OnRowDataBound="GrdVwSummary_RowDataBound" SkinID="GrdVwMasterNoPageing">
                                                                <Columns>
                                                                    <asp:BoundField />
                                                                    <asp:TemplateField HeaderText="Fee Master">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LblDiv2" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="138px"></asp:Label>
                                                                            <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TxtFeeTotAmt" runat="server" SkinID="TxRate90Disable" Text=""></asp:TextBox>
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
                                </table>
                            </td>
                        </tr>
                        <tr class="result-headTop">
                            <td align="center" valign="middle" colspan="2">
                                <table>
                                    <tr>
                                        <td><asp:Label ID="Label1" runat="server" SkinID="LblBold" Width="400px"></asp:Label></td>
                                        <td><uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="Submit" /></td>
                                        <td><asp:Label ID="Label2" runat="server" SkinID="LblBold" Width="200px"></asp:Label></td>
                                        <td> <asp:Label ID="LblTot" runat="server" SkinID="LblBold" Text='TOTAL AMOUNT' Width="150px"></asp:Label></td>
                                        <td><asp:TextBox ID="TxtTotalAmount" runat="server" SkinID="TxtDigit120Disable"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>