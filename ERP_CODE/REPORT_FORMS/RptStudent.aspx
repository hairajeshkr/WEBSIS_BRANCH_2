<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudent.aspx.cs" Inherits="REPORT_FORMS_RptStudent" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Filter Students
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Text="Filter Criteria" Width="100px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DdlFilter" runat="server" Width="198px"></asp:DropDownList>
                            </td>

                            <td class="odd" style="width: 60px">
                                <asp:Label ID="Label3" runat="server" SkinID="LblBold" Text="Group" Width="75px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtGroup" runat="server" Width="167px"></asp:TextBox>
                                <asp:Button ID="BtnGroup" runat="server" Text="...." Width="28px" />
                            </td>

                            <td class="odd" style="width: 152px">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="selected group" />
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd">
                                &nbsp;<td class="odd" >
                                    &nbsp;</td>
                                
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label1" runat="server" SkinID="LblBold" Text="Religion" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="3">
                                <asp:DropDownList ID="DdlReligion" runat="server" Width="198px">
                                </asp:DropDownList>
                            </td>
                            <td class="odd">

                                &nbsp;</td>
                            <td class="odd">

                            </td>
                            <td class="odd">

                            </td>
                            <td class="odd">

                            </td>
                           
                        </tr>
                        <tr>
                            <td class="odd" colspan="4" rowspan="3">
                                <div class="result-list" style="overflow: scroll; height: 268px; width: 800px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admission No.">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                            <td class="odd" colspan="4">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                                <asp:GridView ID="GrdVwSummary" runat="server" SkinID="GrdVwMaster" Height="61px">
                                                    <Columns>
                                                        <asp:BoundField />
                                                        <asp:TemplateField HeaderText="Division">
                                                            <ItemTemplate>
                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Count">
                                                              <ItemTemplate>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>

                                                </asp:GridView>
                                               
                                            </div>

                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="4">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Select All" />
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="odd" colspan="4">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                <asp:GridView ID="GrdVwList" runat="server" SkinID="GrdVwMaster">
                                    <Columns>
                                        <asp:BoundField />
                                        <asp:TemplateField HeaderText="Division">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Count">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="4" rowspan="2">
                                &nbsp;</td>
                            <td class="odd" colspan="4">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="Select All" />
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="odd" colspan="4">&nbsp;</td>
                        </tr>
                       
                        <tr class="odd">
                            <td>
                                <asp:Label ID="Label2" runat="server" SkinID="LblBold" Text="Sort Order" Width="100px"></asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" SkinID="LblBold" Text="Based On" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="result-headTop">
                            <td class="Footercommand" colspan="7" align="center" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="Submit" />
                             </td>
                             </tr>
                       
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>
