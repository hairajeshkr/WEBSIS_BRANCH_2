﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAdmissionDtls.aspx.cs" StyleSheetTheme="SkinFile" Inherits="STUDENT_StudentAdmissionDtls" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" src="Script/StudentAdmisDtls.js" type="text/javascript"></script>
    <div style="height:400px; width:750px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Admission Details
              </HeaderTemplate>
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 370px; width: 735px;">
                      <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster">
                          <Columns>                              
                              <asp:TemplateField HeaderText="Admission Class">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblInstitution" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("ClassName") %>' Width="150px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Quota">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LblQuota" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("QuotaName") %>' Width="150px"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Rank">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LnkRank" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Rank") %>' Width="150px"></asp:LinkButton>
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
              <HeaderTemplate>Admission Register
              </HeaderTemplate>
              <ContentTemplate>
                     <table class="auto-style1">
                        <tr>
                          <td class="odd" style="width: 90px; height:35px">
                              <asp:Label ID="Label22" runat="server" Text="Admission Class" Width="110px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 180px; height: 35px;">
                                <uc2:CtrlGridList ID="CtrlGrdAdmmisionClass" runat="server" AccountType="ClassList" PlaceHoldr=" Class List" />
                          </td>
                            <td class="odd" style="width: 180px; height: 35px;">
                                <asp:Label ID="Label25" runat="server" Width="200px"></asp:Label>
                            </td>
                            </tr>

                        <tr>

                            <td class="odd" style="width: 90px; height: 35px" height="30px" >
                             <asp:Label ID="Label23" runat="server" Text="Quota" Width="90px"></asp:Label>
                        </td>
                         <td class="odd" height="30px" style="width: 180px; height: 30px;">
                               
                             <uc2:CtrlGridList ID="CtrlGrdQuota" runat="server" PlaceHoldr="Quota List" AccountType="QuotaList" />
                               
                          </td>
                            <td class="odd" height="30px" style="width: 180px; height: 30px;">&nbsp;</td>
                       </tr>
                         <tr>
                             <td class="odd" height="30px" style="width: 90px; height: 30px">
                                 <asp:Label ID="Label21" runat="server" Text="Rank" Width="90px"></asp:Label>
                          </td>
                           <td class="odd" height="30px" width="180px">
                               <asp:TextBox ID="TxtRank" runat="server" Height="25px" placeholder="Rank" Width="280px"></asp:TextBox>
                           </td>
                            
                             <td class="odd" height="30px" width="180px">&nbsp;</td>
                            
                           <tr>
                               <td class="odd" height="30px" style="width: 90px; height: 30px">
                                   <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                               </td>
                               <td class="odd" height="30px" width="180px">
                                   <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                               </td>
                               <td class="odd" height="30px" width="180px">&nbsp;</td>
                               <tr>
                                   <td align="center" class="FooterCommand" colspan="3" height="60px" valign="middle">
                                       <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                                   </td>
                               </tr>
                        </tr>
                       </table>
               </ContentTemplate>
          </ajaxToolkit:TabPanel>
           </ajaxToolkit:TabContainer>
        </div>


</asp:Content>
