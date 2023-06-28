<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentDocumentUpload.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentDocumentUpload" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/Division.js" type="text/javascript"></script>
    <div style="height: 400px; width: 750px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Document Upload Details
              
                </HeaderTemplate>

                <ContentTemplate>
                    <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                        <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging"  SkinID="GrdVwMaster">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Name">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("DocTypeName") %>' Width="175px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                      </Columns>
                                  </asp:GridView>
                    </div>

                </ContentTemplate>

            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Document Upload Register
              
                </HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label122" runat="server" Text="Document" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:DropDownList ID="DrpDownDocument" runat="server" Width="300px"></asp:DropDownList>

                            </td>
                            <td class="odd"></td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label124" runat="server" Text="Upload Document" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 30px" colspan="3">
                                <table>
                                    <tr>
                                        <td>
                                            <ajaxToolkit:AsyncFileUpload ID="FileUploadDoc" runat="server" CssClass="FileUploadControl upload-field-parent upload-field-input" FailedValidation="False"  Width="360px" />
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="HyLnkDoc" runat="server" CssClass="upload-field-img"></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                      </tr>
                        <tr>
                            <td class="even">
                                <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                            </td>
                            <td class="even">
                                <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="even"></td>
                            <td class="even"></td>
                        </tr>

                        


                        <tr>
                            <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

