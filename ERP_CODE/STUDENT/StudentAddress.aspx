<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentAddress.aspx.cs" Inherits="STUDENT_StudentAddress" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/StudentAddress.js" type="text/javascript"></script>
    <div style="height:540px; width:880px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="880px" BorderColor="White" BorderStyle="Solid"  BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate>Student Address
              </HeaderTemplate>
               <ContentTemplate>
                   <table class="auto-style1">
                        <tr>
                         <td colspan="2">
                             <asp:Label ID="Label127" runat="server" SkinID="LblIHeaderText" Text="Permanent Address"></asp:Label>
                            </td>
                         <td colspan="2">
                             <table style="width: 100%">
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label128" runat="server" SkinID="LblIHeaderText" Text="Temporary Address"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:CheckBox ID="ChkSame" runat="server" SkinID="ChkBox" Text="Same as permanent" Width="210px" />
                                     </td>
                                 </tr>
                             </table>
                            </td>
                    </tr>

                    <tr>
                          <td class="odd" style="width: 90px; height:30px">
                            <asp:Label ID="Label122" runat="server" Text="House Name" Width="90px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 200px; height:30px" width="180px">
                              <asp:TextBox ID="TxtHouseNamePerm" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>

                           <td class="odd" style="width: 90px; height:30px" >
                             <asp:Label ID="Label126" runat="server" Text="House Name" Width="90px"></asp:Label>
                        </td>
                         <td class="odd" width="200px" >
                              <asp:TextBox ID="TxtHouseNameTemp" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label131" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtAddressPerm" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label132" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtAddressTemp" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label1" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtPostOfficePerm" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label2" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtPostOfficeTemp" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label3" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtPinCodePerm" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label4" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtPinCodeTemp" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label5" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtCityPerm" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label6" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtCityTemp" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label7" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdCountryPer" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label8" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdCountryTemp" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label9" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdStatePer" runat="server" GridHeight="200" PlaceHoldr="State" AccountType="State" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label10" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdStateTemp" runat="server" AccountType="State" PlaceHoldr="State" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label129" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdDistrictPer" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label130" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdDistrictTemp" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label11" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtPhoneNoPerm" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label12" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtPhoneNoTemp" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label14" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtEmailPerm" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label15" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtEmailTemp" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label16" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMobNoPerm" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label13" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMobNoTemp" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label133" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 201px">
                                  <asp:TextBox ID="TxtRemarksPerm" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label134" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 180px">
                                  <asp:TextBox ID="TxtRemarksTemp" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              
                              <td align="center" class="FooterCommand" colspan="5" valign="middle">
                                  
                                  <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="false" />
                              </td>
                               <td align="center" class="FooterCommand" colspan="6" valign="middle">
                                 <asp:Button ID="Button1" runat="server" Text="Copy To" OnClick="Button1_Click" />
                               </td>
                          </tr>
                      </tr>                            
             </table>
               </ContentTemplate>


                </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
              <HeaderTemplate>Father Address
              </HeaderTemplate>
               <ContentTemplate>
                   <table class="auto-style1">
                        <tr>
                         <td colspan="2">
                             <asp:Label ID="Label17" runat="server" SkinID="LblIHeaderText" Text="Permanent Address"></asp:Label>
                            </td>
                         <td colspan="2">
                             <table style="width: 100%">
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label18" runat="server" SkinID="LblIHeaderText" Text="Temporary Address"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:CheckBox ID="ChkSameFthr" runat="server" SkinID="ChkBox" Text="Same as permanent" Width="210px" />
                                     </td>
                                 </tr>
                             </table>
                            </td>
                    </tr>

                    <tr>
                          <td class="odd" style="width: 90px; height:30px">
                            <asp:Label ID="Label19" runat="server" Text="House Name" Width="90px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 200px; height:30px" width="180px">
                              <asp:TextBox ID="TxtFthrHousePer" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>

                           <td class="odd" style="width: 90px; height:30px" >
                             <asp:Label ID="Label20" runat="server" Text="House Name" Width="90px"></asp:Label>
                        </td>
                         <td class="odd" width="200px" >
                              <asp:TextBox ID="TxtFthrHouseTemp" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label21" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrStreetPer" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label22" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrStreetTemp" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label23" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrPostPer" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label24" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrPostTemp" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label25" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrPincodePer" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label26" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrPincodeTemp" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label27" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrLandmarkPer" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label28" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrLandmarkTemp" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label29" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrCntryPer" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label30" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrCntryTemp" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label31" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrStatePer" runat="server" GridHeight="200" PlaceHoldr="State" AccountType="State" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label32" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrStateTemp" runat="server" AccountType="State" PlaceHoldr="State" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label33" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrDistPer" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label34" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdFthrDistTEmp" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label35" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrPhNoPer" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label36" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrPhNoTemp" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label37" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrEmailPer" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label38" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtFthrEmailTemp" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label39" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrMobPer" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label40" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtFthrMobTemp" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label41" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 201px">
                                  <asp:TextBox ID="TxtFthrRemarksPer" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label42" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 180px">
                                  <asp:TextBox ID="TxtFthrRemarksTemp" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                  <uc1:CtrlCommand ID="CtrlCommandFthr" runat="server" SaveCommandName="SAVE_FTHR" ClearCommandName="CLEAR_FTHR" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="false" />
                              </td>
                          </tr>
                      </tr>                            
             </table>
               </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3">
              <HeaderTemplate>Mother Address
              </HeaderTemplate>
               <ContentTemplate>
                      <table class="auto-style1">
                        <tr>
                         <td colspan="2">
                             <asp:Label ID="Label43" runat="server" SkinID="LblIHeaderText" Text="Permanent Address"></asp:Label>
                            </td>
                         <td colspan="2">
                             <table style="width: 100%">
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label44" runat="server" SkinID="LblIHeaderText" Text="Temporary Address"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:CheckBox ID="ChkSameMthr" runat="server" SkinID="ChkBox" Text="Same as permanent" Width="210px" />
                                     </td>
                                 </tr>
                             </table>
                            </td>
                    </tr>

                    <tr>
                          <td class="odd" style="width: 90px; height:30px">
                            <asp:Label ID="Label45" runat="server" Text="House Name" Width="90px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 200px; height:30px" width="180px">
                              <asp:TextBox ID="TxtMthrHousePer" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>

                           <td class="odd" style="width: 90px; height:30px" >
                             <asp:Label ID="Label46" runat="server" Text="House Name" Width="90px"></asp:Label>
                        </td>
                         <td class="odd" width="200px" >
                              <asp:TextBox ID="TxtMthrHouseTemp" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label47" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrStreetPer" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label48" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrStreetTemp" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label49" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrPostPer" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label50" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrPostTemp" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label51" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrPincodePer" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label52" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrPincodeTemp" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label53" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrLandmarkPer" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label54" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrLandmarkTemp" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label55" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrCntryPer" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label56" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrCntryTemp" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label57" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrStatePer" runat="server" GridHeight="200" PlaceHoldr="State" AccountType="State" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label58" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrStateTemp" runat="server" AccountType="State" PlaceHoldr="State" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label59" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrDistPer" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label60" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdMthrDistTEmp" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label61" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrPhNoPer" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label62" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrPhNoTemp" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label63" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrEmailPer" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label64" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtMthrEmailTemp" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label65" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrMobPer" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label66" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtMthrMobTemp" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label67" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 201px">
                                  <asp:TextBox ID="TxtMthrRemarksPer" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label68" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 180px">
                                  <asp:TextBox ID="TxtMthrRemarksTemp" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommandMthr" runat="server" SaveCommandName="SAVE_MTHR" ClearCommandName="CLEAR_MTHR" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="false" />
                              </td>
                          </tr>
                      </tr>                            
             </table>
               </ContentTemplate>
                </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel4">
              <HeaderTemplate>Guardian Address
              </HeaderTemplate>
               <ContentTemplate>
                     <table class="auto-style1">
                        <tr>
                         <td colspan="2">
                             <asp:Label ID="Label69" runat="server" SkinID="LblIHeaderText" Text="Permanent Address"></asp:Label>
                            </td>
                         <td colspan="2">
                             <table style="width: 100%">
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label70" runat="server" SkinID="LblIHeaderText" Text="Temporary Address"></asp:Label>
                                     </td>
                                     <td>
                                         <asp:CheckBox ID="ChkSameGurdn" runat="server" SkinID="ChkBox" Text="Same as permanent" Width="210px" />
                                     </td>
                                 </tr>
                             </table>
                            </td>
                    </tr>

                    <tr>
                          <td class="odd" style="width: 90px; height:30px">
                            <asp:Label ID="Label71" runat="server" Text="House Name" Width="90px"></asp:Label>
                          </td>
                            <td class="odd" style="width: 200px; height:30px" width="180px">
                              <asp:TextBox ID="TxtGurdnHousePer" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>

                           <td class="odd" style="width: 90px; height:30px" >
                             <asp:Label ID="Label72" runat="server" Text="House Name" Width="90px"></asp:Label>
                        </td>
                         <td class="odd" width="200px" >
                              <asp:TextBox ID="TxtGurdnHouseTemp" runat="server" placeholder="House" Width="280px"></asp:TextBox>
                          </td>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label73" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnStreetPer" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label74" runat="server" Text="Street" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnStreetTemp" runat="server" placeholder="Street" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label75" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnPostPer" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label76" runat="server" Text="Post Office" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnPostTemp" runat="server" placeholder="Post Office" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label77" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnPincodePer" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label78" runat="server" Text="Pin Code" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnPincodeTemp" runat="server" placeholder="Pin Code" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label79" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnLandmarkPer" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label80" runat="server" Text="Landmark" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnLandmarkTemp" runat="server" placeholder="Landmark" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label81" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnCntryPer" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label82" runat="server" Text="Country" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnCntryTemp" runat="server" GridHeight="200" PlaceHoldr="Country" AccountType="Country" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label83" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnStatePer" runat="server" GridHeight="200" PlaceHoldr="State" AccountType="State" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label84" runat="server" Text="State" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnStateTemp" runat="server" AccountType="State" PlaceHoldr="State" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label85" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnDistPer" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                              <td class="odd" style="width: 90px; height:20px">
                                  <asp:Label ID="Label86" runat="server" Text="District" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:20px" width="180px">
                                  <uc2:CtrlGridList ID="CtrlGrdGurdnDistTEmp" runat="server" AccountType="District" GridHeight="200" PlaceHoldr="District" />
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label87" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnPhNoPer" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label88" runat="server" Text="Phone no." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnPhNoTemp" runat="server" placeholder="Phone no." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label89" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnEmailPer" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label90" runat="server" Text="Email" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" width="180px">
                                  <asp:TextBox ID="TxtGurdnEmailTemp" runat="server" placeholder="Email" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label91" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnMobPer" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" style="width: 90px; height:30px">
                                  <asp:Label ID="Label92" runat="server" Text="Mobile No." Width="90px"></asp:Label>
                              </td>
                              <td class="odd" style="width: 180px; height:30px" width="180px">
                                  <asp:TextBox ID="TxtGurdnMobTemp" runat="server" placeholder="Mobile No." Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label93" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 201px">
                                  <asp:TextBox ID="TxtGurdnRemarksPer" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                              <td class="odd" height="20px" style="width: 90px; height:20px">
                                  <asp:Label ID="Label94" runat="server" Text="Remarks" Width="90px"></asp:Label>
                              </td>
                              <td class="odd" height="20px" style="width: 180px">
                                  <asp:TextBox ID="TxtGurdnRemarksTemp" runat="server" placeholder="Remarks" SkinID="TxtMultiLine" TextMode="MultiLine" Width="280px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td align="center" class="FooterCommand" colspan="4" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommandGurdn" runat="server" SaveCommandName="SAVE_GURDN" ClearCommandName="CLEAR_GURDN" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="False" IsVisiblePrint="false" />
                              </td>
                          </tr>
                      </tr>                            
             </table>
               </ContentTemplate>
                </ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer>
        </div>  

</asp:Content>

