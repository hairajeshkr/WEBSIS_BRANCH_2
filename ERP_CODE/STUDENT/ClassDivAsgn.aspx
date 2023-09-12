<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClassDivAsgn.aspx.cs" Inherits="STUDENT_ClassDivAsgn" StylesheetTheme="SkinFile" %>

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
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadioButton4" runat="server" Text="Display Religion Wise Statistics" />
                            </td>
                                
                            <td class="odd" style="width: 172px">
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="All" />
                            </td>
                            <td class="odd">&nbsp;</td>
                                
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadioButton5" runat="server" Text="Display Category Wise Statistics" />
                            </td>
                           
                            <td class="odd" style="width: 172px">
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="Group/Section Wise" />
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtGroup" runat="server" Width="167px"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadioButton6" runat="server" Text="Display BoardingType wise Statistics" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="Selected Group" />
                            </td>
                            <td class="odd" style="width: 172px">&nbsp;</td>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="3">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label1" runat="server" Text="Group/Section"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" rowspan="5" colspan="2">
                                <div class="result-list" style="overflow: scroll; height: 327px; width: 800px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="770px" AutoGenerateColumns="False"   >
                                        <Columns>

                                            <asp:TemplateField HeaderText="Group">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("class") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubGroup">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbldiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("division") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblchristianm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Male") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblchristianf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Female") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblchristiantot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("total") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblhindum" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("hMale") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblhinduf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("hFemale") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblhindumtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("htotal") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblmuslimmale" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mMale") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmuslimfeMale" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mFemale") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmuslimtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mtotal") %>' Width="100px"></asp:Label>
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

                            </td>
                        </tr>
                       
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:CheckBox ID="ChkSelctAllClass" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelctAllClass_CheckedChanged" Text="Select All" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll; height: 150px; width: 186px;">
                                    <asp:CheckBoxList ID="ChkDivList" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="2" rowspan="5">&nbsp;</td>
                            <td class="odd">
                                <asp:CheckBox ID="ChkSelectAllDiv" runat="server" AutoPostBack="True" OnCheckedChanged="ChkSelectAllDiv_CheckedChanged" Text="Select All" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="False" SaveText="show" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">&nbsp;</td>
                        </tr>
                       
                        <tr class="result-headTop">
                            <td align="center" class="Footercommand" colspan="3" valign="middle">
                                &nbsp;</td>
                        </tr>
                       
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
</asp:Content>


