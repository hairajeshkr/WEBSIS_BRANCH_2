<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptStudentDtls.aspx.cs" Inherits="REPORT_FORMS_RptStudentDtls" StylesheetTheme="SkinFile" %>


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
                            <td class="odd" colspan="2">
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="All" />
                            </td>
                                
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="Group/Section Wise" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TxtGroup" runat="server" Width="167px"></asp:TextBox>
                                <asp:Button ID="BtnGroup" runat="server" Text="...." Width="28px"  />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BtnShow" runat="server" Text="Show" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="odd" colspan="2">
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="Selected Group" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label1" runat="server" Text="Group/Section"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">
                                <div class="result-list" style="overflow: scroll; height: 327px; width: 800px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="770px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Group">
                                                <ItemTemplate>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubGroup">
                                                <ItemTemplate>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Boys">
                                                <ItemTemplate>
                                                     <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Male") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Girls">
                                                <ItemTemplate>
                                                     <asp:Label ID="lblfemale" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Female") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sub. Total">
                                                <ItemTemplate>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Group Total">
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grant Total">
                                                
                                                    <ItemTemplate>
                                                        
                                                    </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                                 <asp:CheckBoxList ID="ChkClassDivList" runat="server" >
                                    </asp:CheckBoxList>
                                               
                                            </div>

                                <asp:CheckBox ID="ChkSelctAllClass" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelctAllClass_CheckedChanged" Text="Select All" />

                            </td>
                        </tr>
                       
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                    <asp:CheckBoxList ID="ChkDivList" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                                <asp:CheckBox ID="ChkSelectAllDiv" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectAllDiv_CheckedChanged" Text="Select All" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">
                                &nbsp;</td>
                            <td class="odd">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="List" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" rowspan="2">
                                </td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="2">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                       
                        <tr class="result-headTop">
                            <td align="center" class="Footercommand" colspan="2" valign="middle">
                                &nbsp;</td>
                        </tr>
                       
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>

