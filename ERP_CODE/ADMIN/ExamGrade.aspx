<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExamGrade.aspx.cs" Inherits="ADMIN_ExamGrade" StylesheetTheme="SkinFile" Theme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ExamGrade.js" type="text/javascript"></script>
    <div style="height: 460px; width: 700px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="460px" Width="700px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Academic Grade
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 83px">
                                <asp:Label ID="Label122" runat="server" Text="Grade Name" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtName" runat="server" placeholder="Grade Name" Width="246px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label7" runat="server" Text="Grade System" Width="125px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DdlGradeSystem" runat="server" SkinID="DdlGradingSystem" Height="35px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="even" style="width: 83px">
                                <asp:Label ID="Label3" runat="server" Text="Code" Width="100px"></asp:Label>
                            </td>
                            <td class="even" colspan="2">
                                <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" style="width: 40px">
                                <asp:Label ID="Label5" runat="server" Text="Range From" Width="85px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtRangeFrom" runat="server" placeholder="Range From" SkinID="TxtCode"></asp:TextBox>
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label6" runat="server" Text="Range To" Width="85px" Height="32px"></asp:Label>
                                <asp:TextBox ID="TxtRangeTo" runat="server" placeholder="Range To" SkinID="TxtCode"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 83px">
                                <asp:Label ID="Label4" runat="server" Text="Grade Point" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtGradePoint" runat="server" placeholder="Grade Point" SkinID="TxtCode"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 83px">
                                <asp:Label ID="Label1" runat="server" Text="Order Index" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtPriority" runat="server" placeholder="Order Index" SkinID="TxtCode"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td class="even" style="width: 83px">
                                <asp:Label ID="Label12" runat="server" Text="Remarks" Width="100px"></asp:Label>
                            </td>
                            <td class="even" colspan="2">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" style="width: 83px"></td>
                            <td class="odd" colspan="2">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ChkActive" runat="server" Checked="True" SkinID="IsActive" Font-Bold="False" Text="Active" Width="92px" /></td>
                                        <td style="width: 100px">
                                            <asp:CheckBox ID="ChkApprove" runat="server" SkinID="ChkBox" Font-Bold="False" Text="Is Approve" Width="102px" Visible="False" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>


                        <tr>
                            <td align="center" class="FooterCommand" colspan="3" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>


            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Academic Grade List
                </HeaderTemplate>

                <ContentTemplate>
                    <table style="width: 100%; height: 0px;">
                        <tr class="result-head">
                            <td style="height: 39px">
                                <asp:Label ID="Label2" runat="server" Text="Name" Width="42px"></asp:Label>
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
                                <asp:Button ID="BtnFind" runat="server" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked" />
                            </td>
                        </tr>


                        <tr>
                            <td colspan="5">
                                <div class="result-list" style="overflow: scroll; height: 390px; width: 680px;">
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
                                            <asp:TemplateField HeaderText="Range From">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRangeFrom" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RangeFrom") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Range To">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRangeTo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RangeTo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade Point">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblGradePoint" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GradePoint") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbloRDERiNDEX" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OrderIndex") %>' Width="100px"></asp:Label>
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

