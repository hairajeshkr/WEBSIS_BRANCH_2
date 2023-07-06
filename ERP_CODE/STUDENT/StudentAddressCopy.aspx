<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAddressCopy.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentAddressCopy" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/Club.js" type="text/javascript"></script>

    <div style="height:250px; width:400px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="250px" Width="400px" BorderColor="White" BorderStyle="Solid"  BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Address Copier
              </HeaderTemplate>


              <ContentTemplate>
                   <table class="auto-style1">
                      <tr><td class="odd">
                             
                           <td >
                                <asp:Label ID="Label4" runat="server" Text="Copy Address To" Width="150px" Font-Bold="True"></asp:Label>
                          <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
                                    <asp:ListItem Text="Father Address" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Mother Address" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Guardian Address" Value="3"></asp:ListItem>
                           </asp:CheckBoxList>
                                </td>
                          </td>
                          <td class="odd">
                               <td >
                         
                              <asp:Label ID="Label2" runat="server" Text="Copy Options" Width="100px" Font-Bold="True"></asp:Label>
                              <asp:CheckBoxList ID="CheckBoxList2" runat="server" >
                                    <asp:ListItem Text="Permenant Address" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Temporary Address" Value="2"></asp:ListItem>
                                   
                           </asp:CheckBoxList>

                               </td>
                          </td>
                          </tr>
                       <tr>
                           <td align="center" class="FooterCommand" colspan="6" valign="middle">
                                 <asp:Button ID="Button1" runat="server" Text="Ok"/>
                               <asp:Button ID="Button2" runat="server" Text="Cancel"  />
                               </td>

                       </tr>
                        
                    
                       </table>
              </ContentTemplate>

               </ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer>
        </div>  
</asp:Content>

