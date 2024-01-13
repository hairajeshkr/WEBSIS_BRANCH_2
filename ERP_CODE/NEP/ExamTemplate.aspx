<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExamTemplate.aspx.cs" Inherits="NEP_ExamTemplate" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1080px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Exam Template
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>


                            <td class="odd">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label15" runat="server" Text="Paper Group" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGrdPaperGroup" runat="server" PlaceHoldr="Paper Group" AccountType="ClassList" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label10" runat="server" Text="Template Name" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label1" runat="server" Text="Code" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtCode" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label17" runat="server" Text="Remarks" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtRemark" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="odd">&nbsp;</td>
                                        <td class="odd">
                                            <asp:CheckBox ID="ChkDefaultTemp" runat="server" Text="Default Template" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:CheckBox ID="ChkActive" runat="server" Text="Active" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 280px; width: 1030px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="1000px" ShowFooter="True">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Sub Exam name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtSubExamName" runat="server" placeholder="sub exam name" ></asp:TextBox>
                                                    <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Report Column">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DdlRptColumn" runat="server" Width="150px" SkinID="DdlInputType"></asp:DropDownList>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Max Mark">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtMaxMark" runat="server" placeholder="0" SkinID="TxtRateCentre" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Percentage">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtPercentage" runat="server" placeholder="0" SkinID="TxtQtyCentre" Width="70px" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Display Order">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtPriority" runat="server" placeholder="Order" Text='' SkinID="TxtSng170" Width="70px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <FooterStyle HorizontalAlign="Center" />
                                                <FooterTemplate>
                                                    <asp:Button ID="BtnAddRow" runat="server" Text="Add+" OnClick="ButtonAdd_Click" AutoPostback="false"  UseSubmitBehavior="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" colspan="2">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleDelete="False" IsVisiblePrint="True" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                <HeaderTemplate>
                    Exam Template
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>


                            <td class="odd">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtName_Srch" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="odd">
                                            <asp:Label ID="Label2" runat="server" Text="Code"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtCode_Srch" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="odd">
                                            <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFind" Text="Find" Width="100px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 450px; width: 1030px">
                                    <asp:GridView ID="GrdVwLst" runat="server" SkinID="GrdVwMasterNoPageing" Width="1000px" OnSelectedIndexChanging="GrdVwLst_SelectedIndexChanging">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Template Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                                    <%--<asp:HiddenField ID="HdnID" runat="server" Value='<%# Eval("ID") %>' />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
