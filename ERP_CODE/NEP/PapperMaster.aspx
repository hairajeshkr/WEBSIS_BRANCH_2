<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PapperMaster.aspx.cs" Inherits="NEP_PapperMaster" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/Class.js" type="text/javascript"></script>
    <div style="height: 367px; width: 569px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="365px" Width="560px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Paper Master
                </HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">

                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label122" runat="server" Text="Paper Name" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtName" runat="server" placeholder="Paper Name"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label1" runat="server" Text="Code" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="LblParent" runat="server" Text="Print Name" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtPrintName" runat="server" placeholder="Print Name" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label2" runat="server" Text="Abbreviation" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">

                                <asp:TextBox ID="TxtAbbreviation" runat="server" placeholder="Abbreviation" SkinID="TxtCode"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label3" runat="server" Text="Paper Group" Width="105px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <uc1:CtrlGridList ID="CtrlGrdPaperGrp" runat="server" PlaceHoldr="Paper Group" AccountType="ExamMaster" />

                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label12" runat="server" Text="Remarks" Width="105px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px"></td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Font-Bold="False" Text="Active" Width="92px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>
                    </table>



                </ContentTemplate>

            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Paper List
                </HeaderTemplate>

                <ContentTemplate>
                    <table>
                        <table style="width: 100%; height: 0px;">
                            <tr class="result-head">
                                <td style="height: 39px">
                                    <asp:Label ID="Label13" runat="server" Text="Name" Width="42px"></asp:Label>
                                </td>
                                <td style="height: 39px">
                                    <asp:TextBox ID="TxtName_Srch" runat="server" placeholder="Name" SkinID="TxtSng200"></asp:TextBox>
                                </td>
                                <td style="height: 39px">
                                    <asp:Label ID="Label14" runat="server" Text="Code" Width="42px"></asp:Label>
                                </td>
                                <td style="height: 39px">
                                    <asp:TextBox ID="TxtCode_Srch" runat="server" placeholder="Code" SkinID="TxtCode"></asp:TextBox>
                                </td>
                                <td style="height: 39px">
                                    <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <div class="result-list" style="overflow: scroll; height: 300px; width: 529px;">
                                        <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMaster" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Display Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PrintName") %>' Width="150px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Abbreviation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Abbreviation") %>' Width="150px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Paper Group">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPaperGrp" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Abbreviation") %>' Width="150px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                    <ItemStyle Width="200px" />
                                                </asp:BoundField>
                                                <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
                </ContentTemplate>

            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

