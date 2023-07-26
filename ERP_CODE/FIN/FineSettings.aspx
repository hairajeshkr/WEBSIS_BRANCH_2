<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FineSettings.aspx.cs" Inherits="FIN_FineSettings" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<%@ Register Src="~/CtrlDateTime.ascx" TagPrefix="uc1" TagName="CtrlDateTime" %>
<%@ Register Src="~/CtrlGridSmallList.ascx" TagPrefix="uc1" TagName="CtrlGridSmallList" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1100px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1100px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fine Settings
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" colspan="7">
                                <table class="upload-field-parent" style="width: 63%">

                                    <tr>
                                      <td rowspan="4">
                                            
                                            <div class="result-list" style="overflow: scroll; height: 420px; width: 200px;">
                                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1" Style="margin-left: 0px">
                                                </asp:TreeView>
                                                <asp:Label ID="Message" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                        <td style="width: 207px">
                                            <asp:Label ID="Label9" runat="server" Text="Institution" Width="95px"></asp:Label>
                                        </td>
                                        <td style="width: 547px">
                                            <uc1:CtrlGridList runat="server" ID="CtrlGridInstitution" AccountType="InstituteGroup" PlaceHoldr="Institution"  />
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="Label1" runat="server" style="margin-left: 31px" Text="Class" Width="100px"></asp:Label>
                                        </td>
                                        <td style="width: 324px">
                                            <uc1:CtrlGridList runat="server" ID="CtrlGridClass" AccountType="ClassList" PlaceHoldr="Class"/>
                                        </td>


                                    </tr>
                                    <tr>
                                        <td style="width: 150px">
                                            <asp:Label ID="Label10" runat="server" Text="Division" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 547px">
                                            <uc1:CtrlGridList runat="server" ID="CtrlGridDivision" AccountType="DivisionList" PlaceHoldr="Division" />
                                        </td>
                                        
                                        <td style="width: 110px">
                                            <asp:Label ID="Label11" runat="server" style="margin-left: 31px" Text="Student" Width="100px"></asp:Label>
                                        </td>
                                        <td style="width: 324px">
                                            <uc1:CtrlGridList runat="server" ID="CtrlGridStudent"  AccountType="StudentList" PlaceHoldr="Student"  />
                                        </td>
                                        
                                         
                                        <td style="width:150px;">
                                            
                                            <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>


                                        </td>  
                                        
                                    </tr>
                                        

                                    
                                    <tr>
                                        <td style="width: 150px">
                                            <asp:Label ID="Label12" runat="server" Text="Installment"></asp:Label>
                                        </td>
                                        <td style="width: 547px">
                                            <%--<uc1:CtrlGridList ID="CtrlGridInstallment" runat="server"/>--%>
                                            <asp:DropDownList ID="DdlInslment" runat="server" Width="300px" Height="30px" placeholder="installment"></asp:DropDownList>
                                        </td>
                                        <td style="width: 110px">
                                            &nbsp;</td>
                                        <td style="width: 324px">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#FF6699"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Fuchsia"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#CC3399"></asp:Label>
                                        </td>
                                        <td style="width:150px;">&nbsp;</td>
                                    </tr>


                                    
                                    <tr>
                                        <td colspan="7">
                                            <div class="result-list" style="overflow: scroll;">
                                                <asp:GridView ID="GrdVwRecordsMain" runat="server" SkinID="GrdVwMasterNoPageing" Width="604px" >
                                                    <Columns>
                                                        <asp:BoundField />
                                                        <asp:TemplateField HeaderText="Fine name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LblDiv2" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="100px"></asp:Label>
                                                                <asp:HiddenField ID="HdnAdId" runat="server" Value='<%# Eval("ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Due date">
                                                            <ItemTemplate>
                                                                <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="dd/MM/yyyy" SkinID="TxtCode"></asp:TextBox>--%>
                                                                <uc1:CtrlDate ID="CtrlDate" runat="server" />

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtAmount" runat="server" placeholder="0.00" SkinID="TxtCode"></asp:TextBox>
                                                                <%--<asp:Label ID="LblDiv22" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="100px"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Percentage">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtPercentage" runat="server" placeholder="0.00" SkinID="TxtCode"></asp:TextBox>
                                                                <%--<asp:Label ID="LblCnt1" runat="server" SkinID="LblGrdIdentify" Text='<%# Eval("Count") %>' Width="50px"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr class="result-headTop">
                            <td class="odd" style="width: 90px;"></td>
                            <td class="odd" colspan="2"></td>
                            <td class="odd" style="width: 319px;">
                                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" SkinID="BtnAddSub" OnClick="Button1_Click" />
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Fine Settings List
                </HeaderTemplate>

            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
