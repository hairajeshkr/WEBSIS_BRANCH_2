<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentSibling.aspx.cs" Inherits="STUDENT_StudentSibling" StyleSheetTheme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script language="javascript" src="Script/StudentSiblng.js" type="text/javascript"></script>
   <div style="height:400px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Siblings Details
              </HeaderTemplate>
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server"  OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>
                              <asp:TemplateField HeaderText="Student Name">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("SiblingName") %>' Width="300px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Admission No">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblAdmNo" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("SiblingAdmissionNo") %>' Width="150px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Student Id">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("SiblingCode") %>' Width="150px"></asp:LinkButton>
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
              <HeaderTemplate>Siblings Details Register
              </HeaderTemplate>
              <ContentTemplate>
                 <table class="auto-style1">
                     <tr>
                         <td class="odd">
                             <asp:Label ID="Label122" runat="server" Text="Siblings Name" Width="120px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd">
                             <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student List" GridHeight="200" GridWidht="500" />
                         </td>
                         <td class="odd">
                             <asp:Label ID="Label126" runat="server" Height="30px" Width="150px"></asp:Label>
                         </td>
                         </tr>
                     <tr>
                         <td class="odd">
                             <asp:Label ID="Label1" runat="server" Text="Remarks" Width="120px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd">
                             <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                         </td>
                         <td class="odd"></td>
                     </tr>
                     <tr>

                         <td class="odd"></td>
                         
                         <td class="odd">
                             <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                         </td>
                         <td class="odd"></td>
                     </tr>
                     
                  
                  </table>
                                    </ContentTemplate>
              </ajaxToolkit:TabPanel>
          </ajaxToolkit:TabContainer>
        </div>
</asp:Content>