<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SyllabusMaster.aspx.cs" Inherits="NEP_SyllabusMaster"StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 550px; width: 1080px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px" Width="1080px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Define Syllabus
                </HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label17" runat="server" Text="Syllabus Name"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                                        </td>
                                         <td class="odd">
                                            <asp:Label ID="Label1" runat="server" Text="Code" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtCode" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label15" runat="server" Text="Paper Group" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGrdPaperGroup" runat="server" PlaceHoldr="Paper Group" />
                                        </td>
                                         <td class="odd">
                                            <asp:Label ID="Label10" runat="server" Text="Template" Width="100px"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGrdTemplate" runat="server" PlaceHoldr="Exam Template" />
                                        </td>
                                    </tr>
                                   
                                     <tr>
                                        <td class="odd" style="height: 21px">
                                            <asp:Label ID="Label18" runat="server" Text="Academic Year"></asp:Label>
                                        </td>
                                        <td class="odd" style="height: 21px">
                                            <asp:DropDownList ID="DdlAcYear" runat="server" Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                          <td class="odd">
                                            <asp:Label ID="Label19" runat="server" Text="Grading System"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <uc1:CtrlGridList ID="CtrlGrdGrdSystem" runat="server" PlaceHoldr="Grading System" />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="odd">
                                            <asp:Label ID="Label20" runat="server" Text="Remarks"></asp:Label>
                                        </td>
                                        <td class="odd">
                                            <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                         <td class="odd">
                                             <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Font-Bold="False" SkinID="IsActive" Text="Active" Width="92px" />
                                        </td>
                                        <td class="odd">
                                            &nbsp;</td>
                                    </tr>
                                 </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <div class="result-list" style="overflow: scroll;height:280px; width:1030px">
                                    <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="1030px" ShowFooter="True" OnRowDeleting="GrdVwRecords_RowDeleting">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Subject">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtSubject" runat="server" placeholder="subject"></asp:TextBox>
                                                    <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("Id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Elective">
                                                <ItemTemplate>
                                                   <asp:CheckBox ID="ChkElective" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Optional">
                                                <ItemTemplate>
                                                   <asp:CheckBox ID="ChkOptional" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Papers">
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnPapers" runat="server" CommandName="DELETE" SkinID="BtnGrdEditGreen" Text="..."  Width="100px"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Order">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtPriority" runat="server" placeholder="Display Order" Text='' SkinID="TxtSng170"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <FooterStyle HorizontalAlign="Center" />
                                                <FooterTemplate>
                                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add+" OnClick="ButtonAdd_Click" UseSubmitBehavior="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr >
                            <td align="center" valign="middle" colspan="2">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleDelete="False" IsVisiblePrint="True" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                <HeaderTemplate>
                    Syllabus List
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
                                <div class="result-list" style="overflow: scroll;height:420px; width:1000px">
                                    <asp:GridView ID="GrdVwLst" runat="server" SkinID="GrdVwMasterNoPageing" OnSelectedIndexChanging="GrdVwLst_SelectedIndexChanging" Width="1000px" >
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:TemplateField HeaderText="Syllabus Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                                    <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Code") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paper Group Name">
                                                <ItemTemplate>
                                                     <asp:Label ID="LblPaperGroup" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("PaperGroupName") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Template">
                                                <ItemTemplate>
                                                   <asp:Label ID="LblTemplate" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NEPExamTemplateName") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Ac.year">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAcYear" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AcId") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grading System">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblGradeing" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NEPGradingName") %>' Width="100px"></asp:Label>
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