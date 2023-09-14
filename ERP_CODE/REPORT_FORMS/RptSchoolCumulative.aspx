<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptSchoolCumulative.aspx.cs" Inherits="REPORT_FORMS_RptSchoolCumulative" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1090px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    School Cumulative Statistics
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadReligion" runat="server" Text="Display Religion Wise Statistics" />
                            </td>
                                
                            <td class="odd" style="width: 172px">
                                <asp:RadioButton ID="RadAll" runat="server" Text="All" />
                            </td>
                            <td class="odd">&nbsp;</td>
                                
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadCategory" runat="server" Text="Display Category Wise Statistics" />
                            </td>
                           
                            <td class="odd" style="width: 172px">
                                <asp:RadioButton ID="RadGpSec" runat="server" Text="Group/Section Wise" />
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtGroup" runat="server" Width="167px"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadBoarding" runat="server" Text="Display BoardingType wise Statistics" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td class="odd" style="width: 354px">
                                <asp:RadioButton ID="RadSelGroup" runat="server" Text="Selected Group" />
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
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="770px" AutoGenerateColumns="False" OnDataBound="GrdVwRecords_DataBound"   >
                                        <Columns>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("class") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbldiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("division") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblchristianm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Male") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblchristianf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Female") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblchristiantot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("total") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblhindum" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("hMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lblhinduf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("hFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblhindumtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("htotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblmuslimmale" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmuslimfeMale" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmuslimtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblTotalRelgm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalRelgf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalRelgmtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="GrdVwCategory" runat="server" SkinID="GrdVwMasterNoPageing" Width="770px" AutoGenerateColumns="False" OnDataBound="GrdVwCategory_DataBound"   >
                                        <Columns>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("class") %>' Width="75px" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbldiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("division") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblgeneralm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgeneralf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgeneraltot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Gtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblnonresm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NonResMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnonresf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NonResFeMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblnonrestot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NonRestotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblobcm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OBCMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblobcf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OBCFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblobctot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OBCtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lbloecm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OECMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloecf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OECFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbloectot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("OECtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblreservationm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RESMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreservationf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RESFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreservationtot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("REStotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblscm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SCMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblscf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SCFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsctot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SCtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblstm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("STMale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("STFemale") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsttot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("STtotal") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                  <%-- <asp:Label ID="lblAllcatm" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mMale") %>' ></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="F">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblAllcatf" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mFemale") %>' ></asp:Label>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="total">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblAllcattot" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("mtotal") %>' ></asp:Label>--%>
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



