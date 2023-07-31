<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" StylesheetTheme="SkinFile" CodeFile="FeesCollection.aspx.cs" Inherits="FIN_FeesCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 394px; width: 950px; margin-bottom: 28px;">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="750px" Width="950px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fee Receipt
                </HeaderTemplate>


                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 180px">
                                <asp:Label ID="Label1" runat="server" Text="Admission No." Width="100px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 30px" colspan="2">
                                <asp:TextBox ID="TextBox1" runat="server" Width="173px"></asp:TextBox>
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TextBox2" runat="server" Style="margin-right: 27px" Width="150px"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Height="25px" Text="...." Width="39px" />
                                <asp:Label ID="Label3" runat="server" Text="Details"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 180px">
                                <asp:Label ID="Label4" runat="server" Text="Receipt Date" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <uc1:CtrlDate ID="CtrlDate1" runat="server" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="Label5" runat="server" Text=" Group/Section"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Show Payable" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 180px" >
                                <asp:Label ID="Label6" runat="server" Text="Installment Date" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <uc1:CtrlDate ID="CtrlDate2" runat="server" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="Label7" runat="server" Text="Fee Type"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="210px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="Button2" runat="server" Text="Show" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 300px; width: 664px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster" Width="600px" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Fees Name">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total fees">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Concession">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="LblAbbrevation" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Abbrevation") %>' Width="100px"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Paid">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="LblPriority" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Priority") %>' Width="100px"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Excess">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="LblFrmDate" runat="server" SkinID="LblGrdMaster" Text='<%# Bind("StartDate", "{0:dd-MMM-yyy}") %>' Width="150px"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Payable">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="LblToDate" runat="server" SkinID="LblGrdMaster" Text='<%# Bind("EndDate", "{0:dd-MMM-yyy}") %>' Width="150px"></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>

                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Receipt No."></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" Width="210px"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Fine"></asp:Label>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Cumulative" />
                                <asp:TextBox ID="TextBox5" runat="server" Width="210px" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Total Amount Payable"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" Width="210px" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Amount"></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server" Width="210px" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label12" runat="server" Text="Concession" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DropDownList3" runat="server" Width="320px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                <asp:TextBox ID="TextBox8" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:Label ID="Label13" runat="server" Text="Concession Amount"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label14" runat="server" Text="Con.History" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="320px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                <asp:Button ID="Button3" runat="server" Height="25px" Text="Con.Details" Width="90px" />
                            </td>
                            <td class="odd" colspan="2">
                                <asp:Label ID="Label15" runat="server" Text="Net Payable" ></asp:Label>
                                <asp:TextBox ID="TextBox11" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label16" runat="server" Text="Bank Belongs to" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:CheckBox ID="CheckBox3" runat="server" />
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DropDownList4" runat="server" Width="300px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Height="25px" Text="Arrear Balance" Width="110px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label17" runat="server" Text="Head of Account" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DropDownList5" runat="server" Width="320px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                &nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="Label18" runat="server" Text="Cheque/DD No." Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TextBox10" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label19" runat="server" Text="Payable At" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="4">
                                <asp:TextBox ID="TextBox12" runat="server" Width="500px"></asp:TextBox>
                            </td>

                            <td class="odd">
                                <asp:Label ID="Label20" runat="server" Text="Cheque/DD Date" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc1:CtrlDate runat="server" ID="CtrlDate" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="height: 39px">
                                <asp:Label ID="Label21" runat="server" Text="Remarks" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="6" style="height: 39px">
                                <asp:TextBox ID="TextBox13" runat="server" Width="700px"></asp:TextBox>
                            </td>                       
                        </tr>

                        <tr>
                            <td class="odd" colspan="7" style="height: 39px">
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="Print Installment Names" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="Use Abbreviation" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="send SMS to Parents" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="7" style="height: 39px">
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="Use Default Case" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="Use Fee PrintName Summary" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </td>
                        </tr>
                       
                       <tr>
                            <td align="center" class="FooterCommand" valign="middle" colspan="3">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>


                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

