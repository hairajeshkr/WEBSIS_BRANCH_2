<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PapperGrpMaster.aspx.cs" Inherits="NEP_PapperGrpMaster" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

    <script language="javascript" src="Script/FeeAssign.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1080px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Paper Group Master
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>

                            <td class="auto-style5" style="width: 71px;">
                                <asp:Label ID="Label15" runat="server" Text="Name" Width="174px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style5" style="width: 71px">
                                <asp:Label ID="Label10" runat="server" Text="Code" Width="132px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtCode" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="width: 71px">
                                <asp:Label ID="Label21" runat="server" Text="Abbreviation "></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtAbrvtion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="width: 71px">
                                <asp:Label ID="Label22" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="width: 71px">&nbsp;</td>
                            <td class="odd">
                                <asp:CheckBox ID="ChkIsScholastic" runat="server" Text="IsScholastic" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkActive" runat="server" Text="Active" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                
                                        <div class="result-list" style="overflow: scroll; height: 280px; width: 1050px;">

                                            <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMaster" ShowFooter="True" AutoGenerateColumns="False" Autopostback="false" >
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Report Column Name">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtReportColumn" runat="server" Width="190px"></asp:TextBox>
                                                            <asp:HiddenField ID="HdnNId" runat="server" Value='<%# Eval("ID") %>' />
                                                            <%--<asp:Label ID="LblFeeMaste" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("FeeMaster") %>' Width="300px"></asp:Label>
                                                     <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>'></asp:HiddenField>
                                                    <asp:HiddenField ID="HdnFeeMstId" runat="server" Value='<%# Eval("FeeMasterId") %>'></asp:HiddenField>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Abbreviation">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtAbbreviation" runat="server" Width="160px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Input Types">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="DdlInputType" runat="server" Width="150px" SkinID="DdlInputType"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Max.Mark">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtMaxMark" runat="server" Width="110px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Weightage">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtWeightage" runat="server" Width="110px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Percentage">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtPercentage" runat="server" Width="110px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TxtOrder" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Expire">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkExpire" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <FooterTemplate>
                                                            <asp:Button ID="ButtonAdd" runat="server" Text="Add+" OnClick="ButtonAdd_Click"  UseSubmitBehavior="false"  />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>

                                        </div>


                                    
                            </td>
                        </tr>
                        <script type = "text/javascript">
                            function validate() {
                                window.location = "PapperGrpMaster.aspx";
                            }
                        </script>

                        <tr>
                            <td align="center" class="FooterCommand" colspan="2" valign="middle">

                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Paper Group List
                </HeaderTemplate>

                <ContentTemplate>
                    <table style="width: 100%; height: 0px;">
                        <tr class="result-head">
                            <td style="height: 39px">
                                <asp:Label ID="Label1" runat="server" Text="Name" Width="42px"></asp:Label>
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
                                <div class="result-list" style="overflow: scroll; height: 450px; width: 1050px;">
                                    <asp:GridView ID="GrdVwSummary" runat="server" SkinID="GrdVwMaster" Width="1050px" OnSelectedIndexChanging="GrdVwSummary_SelectedIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Paper Group Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                                    <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                    </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paper Group Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <%--<asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>--%>
                                            <asp:CheckBoxField DataField="Active" HeaderText="Active" />
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
                                        </ContentTemplate>
                                </asp:UpdatePanel>
</asp:Content>
