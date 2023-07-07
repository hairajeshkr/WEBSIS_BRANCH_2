<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAdmissionDtls.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentAdmissionDtls" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>

<%@ Register src="../CtrlNameIdCtrlSngle.ascx" tagname="CtrlNameIdCtrlSngle" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" src="Script/StudentAdmisDtls.js" type="text/javascript"></script>
    <div style="height:400px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Admission Register
              </HeaderTemplate>
              <ContentTemplate>
                     <table class="auto-style1">
                        <tr>
                          <td class="odd" style="width: 90px; height:37px">
                              <asp:Label ID="Label29" runat="server" Text="Admission Date" Width="110px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 182px; height: 37px;">
                                <asp:TextBox ID="TxtTrDate" runat="server" Enabled="False" Height="25px" placeholder="Roll No." SkinID="TxtDateDisable"></asp:TextBox>
                          </td>
                            <td class="odd" style="width: 180px; height: 37px;">
                                &nbsp;</td>
                            <td class="odd" style="width: 180px; height: 37px;">
                                &nbsp;</td>
                            </tr>

                         <tr>
                             <td class="odd" style="width: 90px; height:37px">
                                 <asp:Label ID="Label22" runat="server" Text="Admission Class" Width="110px"></asp:Label>
                             </td>
                             <td class="odd" style="width: 182px; height: 37px;">
                                 <uc3:CtrlNameIdCtrlSngle ID="CtrlGrdAdmmisionClass" runat="server" />
                             </td>
                             <td class="odd" style="width: 180px; height: 37px;">&nbsp;</td>
                             <td class="odd" style="width: 180px; height: 37px;">
                                 <asp:Label ID="Label25" runat="server" Width="180px"></asp:Label>
                             </td>
                         </tr>

                        <tr>

                            <td class="odd" style="width: 90px; height: 35px" height="30px" >
                                <asp:Label ID="Label26" runat="server" Text="Division" Width="110px"></asp:Label>
                        </td>
                         <td class="odd" height="30px" style="width: 182px; height: 30px;">
                               
                             <uc3:CtrlNameIdCtrlSngle ID="CtrlGrdDivision" runat="server" />
                               
                          </td>
                            <td class="odd" height="30px" style="width: 180px; height: 30px;">
                                <asp:Label ID="Label28" runat="server" Text="Roll No." Width="110px"></asp:Label>
                            </td>
                            <td class="odd" height="30px" style="width: 180px; height: 30px;">
                                <asp:TextBox ID="TxtRollNo" runat="server" Height="25px" placeholder="Roll No." SkinID="TxtQtyCentreDisable" Enabled="False"></asp:TextBox>
                            </td>
                       </tr>
                         <tr>
                             <td class="odd" height="30px" style="width: 90px; height: 35px">
                                 <asp:Label ID="Label23" runat="server" Text="Quota" Width="90px"></asp:Label>
                             </td>
                             <td class="odd" height="30px" style="width: 182px; height: 30px;">
                                 <uc2:CtrlGridList ID="CtrlGrdQuota" runat="server" AccountType="QuotaList" PlaceHoldr="Quota List" GridHeight="200" />
                             </td>
                             <td class="odd" height="30px" style="width: 180px; height: 30px;">&nbsp;</td>
                             <td class="odd" height="30px" style="width: 180px; height: 30px;">&nbsp;</td>
                         </tr>
                         <tr>
                             <td class="odd" height="30px" style="width: 90px; height: 30px">
                                 <asp:Label ID="Label27" runat="server" Text="Second Language" Width="120px"></asp:Label>
                          </td>
                           <td class="odd" height="30px" style="width: 182px">
                               <asp:DropDownList ID="DdlLanguage" runat="server" SkinID="DdlList">
                               </asp:DropDownList>
                             </td>
                            
                             <td class="odd" height="30px" width="180px">&nbsp;</td>
                            
                             <td class="odd" height="30px" width="180px">&nbsp;</td>
                            
                           <tr>
                               <td class="odd" height="30px" style="width: 90px; height: 30px">
                                   <asp:Label ID="Label21" runat="server" Text="Rank" Width="90px"></asp:Label>
                               </td>
                               <td class="odd" height="30px" style="width: 182px; ">
                                   <asp:TextBox ID="TxtRank" runat="server" placeholder="Rank"></asp:TextBox>
                               </td>
                               <td class="odd" height="30px" width="180px">&nbsp;</td>
                               <td class="odd" height="30px" width="180px">&nbsp;</td>
                               <tr>
                                   <td class="odd" height="30px" style="width: 90px; height: 30px">
                                       <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                                   </td>
                                   <td class="odd" height="30px" style="width: 182px">
                                       <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                   </td>
                                   <td class="odd" height="30px" width="180px">&nbsp;</td>
                                   <td class="odd" height="30px" width="180px">&nbsp;</td>
                                   <tr>
                                       <td align="center" class="FooterCommand" colspan="4" height="60px" valign="middle">
                                           <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="True" IsVisiblePrint="false" />
                                       </td>
                                   </tr>
                               </tr>
                        </tr>
                       </table>
               </ContentTemplate>
          </ajaxToolkit:TabPanel>
           </ajaxToolkit:TabContainer>
        </div>


</asp:Content>
