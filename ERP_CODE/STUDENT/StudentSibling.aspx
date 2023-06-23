<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentSibling.aspx.cs" Inherits="STUDENT_StudentSibling" StyleSheetTheme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:300px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="700px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Siblings Details
              </HeaderTemplate>
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server"  OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>
                              <asp:TemplateField HeaderText="Course Name">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Institution">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblInstitution" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Code") %>' Width="100px"></asp:LinkButton>
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
                         <td class="odd" style="width: 16px; height: 30px">
                             <asp:Label ID="Label122" runat="server" Text="Siblings Name" Width="90px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd" style="width: 319px; height: 30px">
                             <asp:TextBox ID="TxtName" runat="server" placeholder="Siblings Name" Width="300px" Height="30px"></asp:TextBox>
                         </td>
                         </tr>
                     <tr>
                         <td class="odd" style="width: 16px; height: 30px">
                             <asp:Label ID="Label2" runat="server" Text="Code" Width="90px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd" style="width: 319px; height: 30px">
                             <asp:TextBox ID="TxtCode" runat="server" placeholder="Code" Width="300px" Height="30px"></asp:TextBox>
                         </td>
                         </tr>
                     <tr>
                         <td class="odd" style="width: 16px; height: 30px">
                             <asp:Label ID="Label125" runat="server" Height="30px" Text="Relationship" Width="90px"></asp:Label>
                         </td>
                         <td class="odd" style="width: 319px; height: 20px">
                             <asp:DropDownList ID="DrpRelationshp" runat="server" placeholder="Relationship" Width="200px" Height="25px">
                             </asp:DropDownList>
                         </td>
                     </tr>
                     <tr>
                         <td class="odd" style="width: 16px; height: 30px">
                             <asp:Label ID="Label1" runat="server" Text="Remarks" Width="90px" Height="30px"></asp:Label>
                         </td>
                         <td class="odd" style="width: 319px; height: 30px">
                             <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>

                         <td class="odd" style="width: 16px; height: 30px"></td>
                         
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
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                  
                 <%-- <table >


                        <tr>
                          <td class="odd" style="width: 133px; height:30px" height="30px">
                            <asp:Label ID="Label33" runat="server" Text="Siblings Name" Width="150px"></asp:Label>
                          </td>
                            <td class="odd" height="30px" style="width: 189px">
                              <asp:TextBox ID="TxtSiblingName" runat="server" placeholder="Siblings Name" Width="280px" Height="20px"></asp:TextBox>
                          </td>
                           
                                 <td class="odd" height="30px" style="width: 90px; height: 30px">
                                     <asp:Label ID="Label34" runat="server" Text="Relationship" Width="150px"></asp:Label>
                                 </td>
                                 <td class="odd" height="30px" width="180px">
                                       <asp:DropDownList ID="DrpRelationship" runat="server" placeholder="Relationship" Width="200px">
                              </asp:DropDownList>
                                 </td>

                             </tr>
                                  <tr>
                                     <td class="odd" height="30px" style="width: 90px; height: 30px">
                                         <asp:Label ID="Label35" runat="server" Text="Remarks" Width="150px"></asp:Label>
                                     </td>
                                     <td class="odd" height="30px" style="width: 189px">
                                          
                                     </td>
                                     <td class="odd" height="30px" style="width: 90px; height: 30px"></td>
                                     <td class="odd" height="30px" style="width: 90px; height: 30px"></td>
                                     <tr>
                                         <td align="center" class="FooterCommand" colspan="4" valign="middle" height="60">
                                             <uc1:CtrlCommand ID="CtrlCommand5" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                                         </td>
                                     </tr>
                                 </tr>
                                                

                       </table>--%>


