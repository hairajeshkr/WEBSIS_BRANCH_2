<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentSibling.aspx.cs" Inherits="STUDENT_StudentSibling" StyleSheetTheme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc5" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/StudentSiblng.js" type="text/javascript"></script>
    <div style="height:300px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="700px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Siblings Details
              </HeaderTemplate>
              <ContentTemplate>
                   <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>
                              <asp:TemplateField HeaderText="Sibling Name">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("SiblingName") %>' Width="175px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <%--<asp:TemplateField HeaderText="Relationship">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblInstitution" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Relationship") %>' Width="100px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>   --%>                       
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
                             <asp:Label ID="Label122" runat="server" Text="Siblings Name" Width="90px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd">
                             <uc1:CtrlGridList runat="server" ID="CtrlGrdName" AccountType="StudentList"  />
                         </td>
                         </tr>
                     <%--<tr>
                         <td class="odd">
                             <asp:Label ID="Label125" runat="server" Height="30px" Text="Relationship" Width="90px"></asp:Label>
                         </td>
                         <td class="odd">
                             <asp:DropDownList ID="DdlRelationship" runat="server" placeholder="Relationship" Width="200px" Height="27px" SkinID="DdlRelationShip"  >
                             </asp:DropDownList>
                         </td>
                     </tr>--%>
                     <tr>
                         <td class="odd">
                             <asp:Label ID="Label1" runat="server" Text="Remarks" Width="90px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd">
                             <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="odd"></td>
                         <td align="center" class="FooterCommand" valign="middle" height="60">
                             <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                         </td>
                     </tr>
                     
                  
                  </table>
                                    </ContentTemplate>
              </ajaxToolkit:TabPanel>
          </ajaxToolkit:TabContainer>
        </div>
</asp:Content>