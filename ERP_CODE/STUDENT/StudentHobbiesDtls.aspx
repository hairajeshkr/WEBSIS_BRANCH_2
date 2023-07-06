<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentHobbiesDtls.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentHobbiesDtls" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/StudentHobbiesDtls.js" type="text/javascript"></script>
    <div style="height: 400px; width: 750px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Hobbie Details
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="result-list" style="overflow: scroll;height:360px;">
                    <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                        <Columns>
                             <asp:TemplateField HeaderText="Custom Head">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkParent" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Parent") %>' Width="200px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Custom Type">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("CustomName") %>' Width="200px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OrderIndex">
                                <ItemTemplate>
                                    <asp:Label ID="LblOrderIndex" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OrderIndex") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    </div>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Hobbie Details Register              
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label123" runat="server" Text="Custome Head" Width="152px"></asp:Label>
                            </td>
                            <td class="even" >
                                <asp:DropDownList ID="DdlCustomHead" runat="server" OnSelectedIndexChanged="DdlCustomHead_SelectedIndexChanged" Width="300px" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td class="even">
                                <asp:Label ID="Label125" runat="server" Width="200px"></asp:Label>
                            </td>
                            <td class="even"></td>
                        </tr>
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label122" runat="server" Text="Hobbies &amp; Activities" Width="152px"></asp:Label>
                            </td>
                            <td class="even">
                                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
                                    <asp:ListItem Text="S" Value="1"></asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                     <asp:ListItem Text="S1" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="even"></td>
                            <td class="even"></td>
                        </tr>
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label124" runat="server" Text="OrderIndex" Width="152px"></asp:Label>
                            </td>
                            <td class="even">
                                <asp:TextBox ID="TxtOrderIndex" runat="server" placeholder="OrderIndex" SkinID="Txt100"></asp:TextBox>
                            </td>
                            <td class="even"></td>
                            <td class="even"></td>
                        </tr>
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                            </td>
                            <td class="even">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="even"></td>
                            <td class="even"></td>
                        </tr>
                        <tr>
                            <td class="odd"></td>
                            <td class="odd">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Font-Bold="False" Text="Active" Width="92px" /></td>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ChkApprove" runat="server" SkinID="ChkBox" Font-Bold="False" Text="Is Approve" Width="102px" Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td class="odd"></td>
                            <td class="odd"></td>
                        </tr>
                        <tr>
                            <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
