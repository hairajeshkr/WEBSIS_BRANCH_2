<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPrvEdu.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentPrvEdu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<%@ Register src="../CtrlMnthYear.ascx" tagname="CtrlMnthYear" tagprefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/Division.js" type="text/javascript"></script>
    <div style="height:400px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Education Details
              </HeaderTemplate>
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>
                              <asp:TemplateField HeaderText="Course Name">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Qualification") %>' Width="175px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Institution">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblInstitution" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("InstituteName") %>' Width="100px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Board / University">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblBoard" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Board") %>' Width="200px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Register No.">
                                  <ItemTemplate>
                                      <asp:Label ID="LblRegNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("RegNo") %>' Width="150px"></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Document File">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyLnkFile" runat="server" Text='<%# Eval("UploadFileName") %>' Target = "_blank" NavigateUrl='<%# FnFileDownloadPath(Eval("UploadFileName"),"DOC")%>' Width="175px"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Start">
                                  <ItemTemplate>
                                      <asp:Label ID="LblFrmDate" runat="server" SkinID="LblGrdMaster" Text='<%# FnGetMonthYear(Eval("FromDate"))%>' Width="100px"></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                               <asp:TemplateField HeaderText="End">
                                  <ItemTemplate>
                                      <asp:Label ID="LblToDate" runat="server" SkinID="LblGrdMaster" Text='<%# FnGetMonthYear(Eval("ToDate"))%>' Width="100px"></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                              <ItemStyle Width="200px" />
                              </asp:BoundField>
                          </Columns>
                      </asp:GridView>
                  </div>
              </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Education Details Register
              </HeaderTemplate>
              <ContentTemplate>
                      <table class="auto-style1">
                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label122" runat="server" Text="Course Name " Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtEducation" runat="server" placeholder="Course Name" Width="300px" Height="30px"></asp:TextBox>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:Label ID="Label125" runat="server" Height="30px" Text="Year of passing" Width="120px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:DropDownList ID="DdlYear" runat="server" SkinID="Ddl150">
                                </asp:DropDownList>
                            </td>
                             </tr>
                             <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label1" runat="server" Text="Institution Name" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtInstitute" runat="server" placeholder="Institution"></asp:TextBox>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:Label ID="Label123" runat="server" Height="30px" Text="Percentage" Width="120px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">  
                                <asp:TextBox ID="TxtPercentage" runat="server" placeholder="Percentage" SkinID="TxtCode"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label2" runat="server" Text="Register No." Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:TextBox ID="TxtRegNo" runat="server" placeholder="Register No."></asp:TextBox>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px"></td>
                            <td class="odd" style="width: 319px; height: 30px"></td>
                      </tr>
                      <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label3" runat="server" Text="Board / University" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                              <asp:TextBox ID="TxtBoard" runat="server" placeholder="Board / University" ></asp:TextBox>
                          
                            </td>
                            <td class="odd" style="width: 319px; height: 30px"></td>
                            <td class="odd" style="width: 319px; height: 30px"></td>
                      </tr>
                      <tr>
                          <td class="odd" style="width: 90px; height: 30px">
                              <asp:Label ID="Label126" runat="server" Height="30px" Text="Start" Width="100px"></asp:Label>
                          </td>
                          <td class="odd" style="width: 319px; height: 30px">
                              <uc4:CtrlMnthYear ID="CtrlFrm" runat="server" />
                          </td>
                          <td class="odd" style="width: 319px; height: 30px"></td>
                          <td class="odd" style="width: 319px; height: 30px"></td>
                      </tr>
                      <tr>
                          <td class="odd" style="width: 90px; height: 30px">
                              <asp:Label ID="Label127" runat="server" Height="30px" Text="End" Width="100px"></asp:Label>
                          </td>
                          <td class="odd" style="width: 319px; height: 30px">
                              <uc4:CtrlMnthYear ID="CtrlTo" runat="server" />
                          </td>
                          <td class="odd" style="width: 319px; height: 30px"></td>
                          <td class="odd" style="width: 319px; height: 30px"></td>
                      </tr>
                  <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label124" runat="server" Text="Upload Document" Width="120px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="height: 30px" colspan="3">
                                <table>
                                    <tr>
                                        <td>
                                            <ajaxToolkit:AsyncFileUpload ID="FileUploadDoc" runat="server" CssClass="FileUploadControl upload-field-parent upload-field-input" FailedValidation="False" OnUploadedComplete="FileUploadDoc_UploadedComplete" Width="360px" />
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="HyLnkDoc" runat="server" CssClass="upload-field-img"></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                      </tr>
                       <tr>
                           <td class="odd" style="width: 90px; height: 30px">
                               <asp:Label ID="Label12" runat="server" Text="Remarks" Width="105px"></asp:Label>
                           </td>
                           <td class="odd" style="width: 319px; height: 30px">
                               <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                           </td>
                           <td class="odd" style="width: 319px; height: 30px"></td>
                           <td class="odd" style="width: 319px; height: 30px">
                               <asp:CheckBox ID="ChkActive" runat="server" Checked="True" Visible="False" Font-Bold="False" SkinID="IsActive" Text="Active" Width="92px" />
                           </td>
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
