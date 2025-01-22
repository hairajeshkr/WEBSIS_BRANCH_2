<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeesCollection.aspx.cs" Inherits="FeesCollection" StyleSheetTheme="SkinFile" Theme="SkinFile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register src="../WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc4" %>
<%@ Register src="../CtrlRewindEvent.ascx" tagname="CtrlRewindEvent" tagprefix="uc5" %>
<%@ Register src="../CtrlNameIdCtrl.ascx" tagname="CtrlNameIdCtrl" tagprefix="uc6" %>
<%@ Register src="../CtrlAddCommand.ascx" tagname="CtrlAddCommand" tagprefix="uc7" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc8" %>
<%@ Register src="../CtrlTokenEvent.ascx" tagname="CtrlTokenEvent" tagprefix="uc9" %>
<%@ Register src="../CtrlNameIdCtrlSngle.ascx" tagname="CtrlNameIdCtrlSngle" tagprefix="uc10" %>
<%@ Register src="../CtrlNameIdCtrlSmall.ascx" tagname="CtrlNameIdCtrlSmall" tagprefix="uc11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="Script/FinReceipt.js" type="text/javascript"></script>
    
    <div style="height:545px; width:995px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="545px" Width="990px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> 
  <asp:Label ID="LblHdr" runat="server" Text="Reg" Width="150px" SkinID="LblTabHdr"></asp:Label></HeaderTemplate><ContentTemplate>
     <table class="auto-style2"><tr><td class="odd">
     <asp:Label ID="Label1" runat="server" Text="Ref No." Width="120px"></asp:Label></td><td class="odd">
     <uc5:CtrlRewindEvent ID="CtrlRewindEvent1" runat="server" /></td><td class="odd">
             <asp:Label ID="Label61" runat="server" Text="Date" Width="120px"></asp:Label>
         </td><td class="odd">
             <uc3:CtrlDate ID="CtrlTrDate" runat="server" IsVisibleDate="True" IsVisibleDateTime="True" />
         </td>
         <td class="odd"></td>
         </tr><tr><td class="even">
             <asp:Label ID="LblCash" runat="server" Text="Student Name" Width="120px"></asp:Label>
             </td><td class="even">
                 <uc2:CtrlGridList ID="CtrlGrdAcc" runat="server" AccountType="StudentList" GridHeight="200" GridWidht="500" PlaceHoldr="Student Name" />
             </td><td class="even">
                      <asp:Label ID="Label75" runat="server" Text="Installment Date" Width="120px"></asp:Label>
                      </td><td class="even">
                 <uc3:CtrlDate ID="CtrlInstDate" runat="server" IsVisibleDate="True" IsVisibleDateTime="True" />
             </td>
             <td class="even">
                 <asp:Label ID="Label84" runat="server" Text=" " Width="80px"></asp:Label>
             </td>
             </tr>
                <tr ><td class="odd">
                    <asp:Label ID="Label90" runat="server" Text="Adm.No &amp;RegNo." Width="120px"></asp:Label>
                    </td>
                      <td class="odd" >
                          <table class="upload-field-parent">
                              <tr>
                                  <td>
                                      <uc11:CtrlNameIdCtrlSmall ID="TxtAdmNo" runat="server" />
                                  </td>
                                  <td>
                                      <uc11:CtrlNameIdCtrlSmall ID="TxtRegNo" runat="server" />
                                  </td>
                              </tr>
                          </table>
                    </td><td class="odd">
                          <asp:Label ID="Label76" runat="server" Text="Institute Group" Width="100px"></asp:Label>
                  </td><td class="odd">
                          <uc10:CtrlNameIdCtrlSngle ID="TxtInstitueGrp" runat="server" />
                  </td>
                    <td class="odd"></td>
                    </tr>
                     <tr class="property-head">
                         <td class="odd">
                             <asp:Label ID="Label77" runat="server" Text="Class &amp; Division" Width="120px"></asp:Label>
                         </td>
                         <td class="odd">
                             <table class="upload-field-parent">
                                 <tr>
                                     <td>
                                         <uc11:CtrlNameIdCtrlSmall ID="TxtClass" runat="server" />
                                     </td>
                                     <td>
                                         <uc11:CtrlNameIdCtrlSmall ID="TxtDivision" runat="server" />
                                     </td>
                                 </tr>
                             </table>
                         </td>
                         <td class="odd">
                             <asp:Label ID="Label17" runat="server" Text="Fee Type" Width="80px"></asp:Label>
                         </td>
                         <td class="odd">
                             <table >
                                 <tr>
                                     <td>
                                         <asp:DropDownList ID="DdlFeeType" runat="server" SkinID="DdlList200">
                                         </asp:DropDownList>
                                     </td>
                                     <td>
                                         <asp:Button ID="BtnGet" runat="server" SkinID="BtnEdit" Text="SHOW" CommandName="SHOW" OnClick="ManiPulateDataEvent_Clicked" />
                                     </td>
                                 </tr>
                             </table>
                         </td>
                         <td class="odd">&nbsp;</td>
         </tr>
         <tr class="property-head">
             <td class="odd" colspan="5">
                 <table>
                     <tr>
                         <td>
                             <div class="result-list" style="overflow: scroll; height: 180px; width:800px">
                                 <asp:GridView ID="GrdVwChild" runat="server" SkinID="GrdVwMaster" OnRowDataBound="GrdVwChild_RowDataBound">
                                     <Columns>
                                         <asp:TemplateField HeaderText="Fee Name">
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="LnkItmName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("FeeMaster") %>' Width="220px"></asp:LinkButton>
                                                <asp:HiddenField ID="HdnRwIndex" runat="server" />
                                                 <asp:HiddenField ID="HdnAutoId" runat="server" Value='<%# Eval("AutoId") %>' />
                                                  <asp:HiddenField ID="HdnFeeMasterId" runat="server" Value='<%# Eval("FeeMasterId") %>' />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Total Fees">
                                             <ItemTemplate>
                                                 <asp:TextBox ID="TxtTotalFee" runat="server" SkinID="Txt100GrdDisable" Text='<%# Eval("Amount") %>'   ></asp:TextBox>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Concession">
                                             <ItemTemplate>
                                                <asp:TextBox ID="TxtConcession" runat="server" SkinID="Txt100GrdDisable" Text='<%# Eval("ConcenAmt") %>'   ></asp:TextBox>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Paid ">
                                             <ItemTemplate>
                                                 <asp:TextBox ID="TxtPaid" runat="server" SkinID="Txt100GrdDisable" Text='<%# Eval("PaidAmt") %>'  ></asp:TextBox>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Excess">
                                             <ItemTemplate>
                                                <asp:TextBox ID="TxtExcess" runat="server" SkinID="Txt100GrdDisable" Text='<%# Eval("ExcessAmt") %>'  ></asp:TextBox>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Payable ">
                                             <ItemTemplate>
                                                <asp:TextBox ID="TxtPayable" runat="server" SkinID="TxtGrdDigit100" Text='<%# Eval("PayableAmt") %>'  ></asp:TextBox>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                             </div>
                         </td>
                         <td style="margin-left: 80px">
                             <asp:Label ID="Label85" runat="server" SkinID="LblBold" Text="Fine" Width="100px"></asp:Label>
                             <table>
                                 <tr>
                                     <td>
                                         <asp:TextBox ID="TxtFineTotal" runat="server" SkinID="TxtDigit" OnTextChanged="TxtFineTotal_Textchanged" AutoPostBack="True"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label86" runat="server" SkinID="LblBold" Text="Total Amount Payable" Width="150px"></asp:Label>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:TextBox ID="TxtPayableAmt" runat="server" SkinID="TxtDigitCentre"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="Label87" runat="server" SkinID="LblBold" Text="Amount" Width="150px"></asp:Label>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         <asp:TextBox ID="TxtAmount" runat="server" SkinID="TxAmount"></asp:TextBox>
                                     </td>
                                 </tr>
                             </table>
                         </td>
                     </tr>
                 </table>
             </td>
         </tr>
         <tr>
             <td class="odd">
                 <asp:Label ID="Label79" runat="server" Text="Head of Account" Width="120px"></asp:Label>
             </td>
             <td class="odd">
                 <asp:DropDownList ID="DdlAcc" runat="server" SkinID="DdlList">
                 </asp:DropDownList>
             </td>
             <td class="odd">
                 <asp:Label ID="Label88" runat="server" Text="Concession Amount" Width="135px"></asp:Label>
             </td>
             <td class="odd">
                 <asp:TextBox ID="TxtConcnAmt" runat="server" SkinID="TxtDigit" OnTextChanged="TxtConcnAmt_Textchanged" AutoPostBack="True"></asp:TextBox>
             </td>
             <td class="odd"></td>
         </tr>
         <tr>
             <td class="odd">
                 <asp:Label ID="Label81" runat="server" Text="Payable At " Width="120px"></asp:Label>
             </td>
             <td class="odd">
                 <asp:TextBox ID="TxtPayableAt" runat="server"></asp:TextBox>
             </td>
             <td class="odd">
                 <asp:Label ID="Label89" runat="server" SkinID="LblBold" Text="Net Payable"></asp:Label>
             </td>
             <td class="odd">
                 <asp:TextBox ID="TxtNetPayable" runat="server" SkinID="TxtDigitDisable"></asp:TextBox>
             </td>
             <td class="odd"></td>
         </tr>
         <tr>
             <td class="odd">
                 <asp:Label ID="Label80" runat="server" Text="Cheque/DD No."></asp:Label>
             </td>
             <td class="odd">
                 <asp:TextBox ID="TxtChqNo" runat="server"></asp:TextBox>
             </td>
             <td class="odd">
                 <asp:Label ID="Label83" runat="server" Text="Cheque/DD Date"></asp:Label>
             </td>
             <td class="odd">
                 <uc3:CtrlDate ID="CtrlChqDate" runat="server" IsVisibleDate="True" IsVisibleDateTime="True" />
             </td>
             <td class="odd"></td>
         </tr>
         <tr>
             <td class="odd">
                 <asp:Label ID="Label82" runat="server" Text="Remarks" Width="120px"></asp:Label>
             </td>
             <td class="odd" colspan="4">
                 <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtWidthNill" Width="830px"></asp:TextBox>
             </td>
         </tr>
                  <tr>
                      <td align="center" class="FooterCommand" colspan="5" valign="middle">
                          <uc1:CtrlCommand ID="CtrlCommand1" runat="server" FindCommandName="SEARCH" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="True" />
                      </td>
                  </tr>
                  <tr><td align="center" class="tokenposition" colspan="5" valign="middle"><uc9:CtrlTokenEvent ID="CtrlTokenEvent1" runat="server" /><asp:HiddenField ID="HdnMargin" runat="server" Value="0" /></td></tr></table></ContentTemplate>
</ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate><asp:Label ID="LblHdr1" runat="server" Text="List" Width="200px" SkinID="LblTabHdr"></asp:Label></HeaderTemplate>
              <ContentTemplate><table style="width: 100%; height: 0px;"><tr><td class="valign-fix">
                  <asp:Label ID="Label13" runat="server" Text="From Date" Width="60px"></asp:Label></td><td class="odd"><uc3:CtrlDate ID="CtrlFrmDate" runat="server" IsVisibleDateTime="True" IsVisibleDate="True" /></td>
                  <td class="valign-fix-left"><asp:Label ID="Label72" runat="server" Text="From Ref No." Width="80px"></asp:Label></td>
                  <td class="valign-fix"><asp:TextBox ID="TxtFrmRefNo" runat="server" placeholder="From Ref No." SkinID="Txt70" ></asp:TextBox></td>
                  <td class="odd"><asp:Label ID="Label26" runat="server" Text="Account Ledger" Width="90px"></asp:Label></td>
                  <td style="height: 39px" align="left" valign="middle" class="valign-fix">
                  <uc2:CtrlGridList ID="CtrlGrdAcc_Srch" runat="server" AccountType="AccountLedger" PlaceHoldr="Account Ledger" GridHeight="200" /></td>
                  <td></td></tr><tr class="result-head"><td class="valign-fix"><asp:Label ID="Label14" runat="server" Text="To Date" Width="60px"></asp:Label></td>
                  <td class="odd"><uc3:CtrlDate ID="CtrlToDate" runat="server" IsVisibleDate="True" IsVisibleDateTime="True" /></td>
                  <td class="valign-fix-left"><asp:Label ID="Label73" runat="server" Text="To Ref No." Width="80px"></asp:Label></td><td class="valign-fix">
                  <asp:TextBox ID="TxtToRefNo" runat="server" placeholder="To Ref No." SkinID="Txt70"></asp:TextBox></td><td class="odd" >
                <asp:Label ID="Label7" runat="server" Text="Remarks" Width="90px"></asp:Label></td><td class="valign-fix">
                <asp:TextBox ID="TxtOptNo_Srch" runat="server" placeholder="Remarks"></asp:TextBox></td><td class="valign-fix-top">
                <asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="SEARCH" SkinID="BtnCommandFindNew" /></td>
                </tr><tr><td colspan="7">
                      <div class="result-list" style="overflow: scroll; height: 350px; width:850px">
                          <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnRowDataBound="GrdVwRecords_RowDataBound" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" PageSize="25" SkinID="GrdVwMaster">
                              <Columns>
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                          <asp:CheckBox ID="ChkGrd" runat="server" Text=" " />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Ref No">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("RefNo") %>' Width="100px"></asp:LinkButton>
                                          <asp:HiddenField ID="HdnAutoId" runat="server" Value='<%# Eval("ID") %>' />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Date">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LnkDate" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Bind("TrDate", "{0:dd/MMM/yyyy}") %>' Width="100px"></asp:LinkButton>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="StudentName">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LblStudentName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("StudentName") %>' Width="250px"></asp:LinkButton>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="StudentCode">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LblStudentCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("StudentCode") %>' Width="250px"></asp:LinkButton>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="GrandTotal">
                                      <ItemTemplate>
                                          <asp:Label ID="LblAmt" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GrandTotal") %>' Width="100px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Remarks">
                                      <ItemTemplate>
                                          <asp:Label ID="LblRemarks" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Remarks") %>' Width="300px"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                          </asp:GridView>
                          <asp:Label ID="LblGrdInfo" runat="server" SkinID="LblReadOnly" style="text-align:center" Text="Record Couldn't found" Width="100%"></asp:Label>
                      </div>
                      </td></tr>
                <tr><td>
                    <asp:CheckBox ID="ChkSelect" runat="server" SkinID="ChkBox" Text="Select" Width="70px" />
                    </td><td></td><td></td><td></td><td>
                    <asp:Button ID="BtnDelete" runat="server" CommandName="DELETE_ALL" OnClick="ManiPulateDataEvent_Clicked" OnClientClick="return confirm(&quot;Do you want to delete this record's&quot;);" SkinID="BtnCommandDelete" Text="Delete" ToolTip="Delete" Width="80px" />
                    </td><td colspan="2">
                        <table style="width: 17%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label74" runat="server" SkinID="LblBoldCenter" style="text-align:center" Text="TOTAL" Width="210px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTotAmt" runat="server" placeholder="Total Amount" SkinID="TxtDigitDisable"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    </td></td></tr></table>
                </ContentTemplate>
</ajaxToolkit:TabPanel>
      </ajaxToolkit:TabContainer>
    </div>  
</asp:Content>

