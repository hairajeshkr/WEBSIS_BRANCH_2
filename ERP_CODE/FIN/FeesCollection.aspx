<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" StylesheetTheme="SkinFile" CodeFile="FeesCollection.aspx.cs" Inherits="FIN_FeesCollection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 800px; width: 1018px; margin-bottom: 28px;">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="800px" Width="1005px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Fee Receipt
                </HeaderTemplate>


                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 180px">
                                <asp:Label ID="LblRptNo" runat="server" Text="Receipt No." Width="100px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 30px" colspan="2">
                                <asp:TextBox ID="TxtRptNo" runat="server" Width="210px"></asp:TextBox>
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="LblRptDate" runat="server" Text="Receipt Date"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <uc3:CtrlDate ID="CtrlRptDate" runat="server" DateText="dd/MMM/yyyy" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 180px">
                                <asp:Label ID="LblAdmNo" runat="server" Text="Admission No." Width="150px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2" style="width: 30px">
                                <asp:TextBox ID="TxtAdmNo" runat="server" Width="210px"></asp:TextBox>
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                               
                                <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student"  />
                                <asp:Button ID="BtnStud" runat="server" Text="Show" OnClick="BtnStud_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 180px">
                                <asp:Label ID="LblInsDate" runat="server" Text="Installment Date" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <uc3:CtrlDate ID="CtrlInsDate" runat="server" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="LblGpSec" runat="server" Text=" Group/Section"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtGrpSec" runat="server" Width="150px"></asp:TextBox>
                                <asp:CheckBox ID="ChkSwPay" runat="server" Text="Show Payable" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" style="width: 180px" >
                                <asp:Label ID="LblHdAc" runat="server" Text="Head of Account" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <uc2:CtrlGridList runat="server" ID="CtrlGridHdOfAcc" AccountType="AccountLedger" />
                            </td>
                            <td class="odd">&nbsp;</td>
                            <td class="odd">
                                <asp:Label ID="LblFType" runat="server" Text="Fee Type"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DdlFeeType" runat="server" Width="210px">
                                   
                                </asp:DropDownList>
                                <asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 300px; width: 607px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server" OnPageIndexChanging="GrdVwRecords_PageIndexChanging" OnSelectedIndexChanging="GrdVwRecords_SelectedIndexChanging" SkinID="GrdVwMaster" Width="600px" OnRowDataBound="GrdVwRecords_RowDataBound" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Fees Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Feename") %>' ></asp:LinkButton>
                                                     <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total fees">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTotalFee" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("TotalFee") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Concession">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblConcession" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Concession") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Paid">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPaid" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Paid")  %>' ></asp:Label>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Excess">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblExcess" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Excess") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Payable">
                                                <ItemTemplate>
                                                   
                                                    <asp:TextBox ID="TxtPayable" runat="server" SkinID="TxtCode" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>

                                      <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript">
                                        </script>
                                        <script type="text/javascript">

                                            function Myfunction(TxtGPayable, TxtTotPayableAmt, TxtCumAmount, TxtTotAmnt, TxtNtPayable) {
                                                
                                                var TOT = 0;
                                                var grid = document.getElementById("<%= GrdVwRecords.ClientID%>");
                                                for (var i = 0; i < grid.rows.length - 1; i++) {
                                                    var txtAmountReceive = $("input[id*=TxtPayable]")
                                                    if (txtAmountReceive[i].value != '') {
                                                        const T = txtAmountReceive[i].value;
                                                        TOT += parseFloat(txtAmountReceive[i].value);
                                                    }
                                                }
                                                document.getElementById(TxtTotPayableAmt).value = TOT;
                                                var FineAmt = document.getElementById(TxtCumAmount).value;
                                               // alert(FineAmt);
                                                document.getElementById(TxtTotAmnt).value = parseFloat(TOT) + parseFloat(FineAmt);
                                                document.getElementById(TxtNtPayable).value = parseFloat(TOT) + parseFloat(FineAmt);
                                            }


                                            function FineAmt(TxtGPayable, TxtTotPayableAmt, TxtCumAmount, TxtTotAmnt) {

                                                <%--var TOT = 0;
                                                var grid = document.getElementById("<%= GrdVwRecords.ClientID%>");
                                                for (var i = 0; i < grid.rows.length - 1; i++) {
                                                    var txtAmountReceive = $("input[id*=TxtPayable]")
                                                    if (txtAmountReceive[i].value != '') {
                                                        const T = txtAmountReceive[i].value;
                                                        TOT += parseFloat(txtAmountReceive[i].value);
                                                    }
                                                }
                                                document.getElementById(TxtTotPayableAmt).value = TOT;
                                                var FineAmt = document.getElementById(TxtCumAmount).value;
                                                
                                                document.getElementById(TxtTotAmnt).value = parseFloat(TOT) + parseFloat(FineAmt);--%>

                                                alert("Hai");
                                            }



                                        </script>

                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="LblFine" runat="server" Text="Fine"></asp:Label>
                                <asp:CheckBox ID="ChkCumulative" runat="server" Text="Cumulative" />
                                <asp:TextBox ID="TxtCumAmount" runat="server" Width="210px" placeholder="0.00" OnTextChanged="TxtCumAmount_TextChanged" AutoPostBack="True" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblAmPay" runat="server" Text="Total Amount Payable"></asp:Label>
                                <asp:TextBox ID="TxtAmntPayable" runat="server" Width="210px" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblAmount" runat="server" Text="Amount"></asp:Label>
                                <asp:TextBox ID="TxtTotAmnt" runat="server" Width="210px" placeholder="0.00"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label12" runat="server" Text="Concession" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DdlConcession" runat="server" Width="320px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                <asp:TextBox ID="TxtConcPerAmnt" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:Label ID="Label13" runat="server" Text="Concession Amount"></asp:Label>
                                <asp:TextBox ID="TxtConcssnAmount" runat="server" SkinID="TxtCode" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label14" runat="server" Text="Con.History" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="2">
                                <asp:DropDownList ID="DdlConcHis" runat="server" Width="320px">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                <asp:Button ID="BtnConDtls" runat="server" Height="25px" Text="Con.Details" Width="90px" />
                            </td>
                            <td class="odd" colspan="2">
                                <asp:Label ID="Label15" runat="server" Text="Net Payable" ></asp:Label>
                                <asp:TextBox ID="TxtNtPayable" runat="server" SkinID="TxtCode" Width="190px" ></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="odd" >
                                <asp:Label ID="Label18" runat="server" Text="Cheque/DD No." Width="115px"></asp:Label>
                            </td>
                            <td class="odd">
                                <asp:TextBox ID="TxtCheqDDNo" runat="server" SkinID="TxtCode"></asp:TextBox>
                            </td>
                            <td class="odd">
                                <asp:Label ID="Label20" runat="server" Text="Cheque/DD Date" Width="100px"></asp:Label>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                            <td class="odd" >
                                <uc3:CtrlDate ID="CtrlChqDDDate" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="BtnArrBal" runat="server" Height="25px" Text="Arrear Balance" Width="110px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label19" runat="server" Text="Payable At" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="4">
                                <asp:TextBox ID="TxtPayAt" runat="server" Width="500px"></asp:TextBox>
                            </td>

                            <td class="odd">
                                <asp:Label ID="LblnId" runat="server"  Width="100px" Visible="False"></asp:Label>
                            </td>
                            <td class="odd">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="odd" style="height: 39px">
                                <asp:Label ID="Label21" runat="server" Text="Remarks" Width="100px"></asp:Label>
                            </td>
                            <td class="odd" colspan="6" style="height: 39px">
                                <asp:TextBox ID="TxtRemarks" runat="server" Width="700px"></asp:TextBox>
                            </td>                       
                        </tr>

                        <tr>
                            <td class="odd" colspan="7" style="height: 39px">
                                <asp:CheckBox ID="ChkPrInsname" runat="server" Text="Print Installment Names" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkUseAbbr" runat="server" Text="Use Abbreviation" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkSendSMS" runat="server" Text="send SMS to Parents" />
                            </td>
                        </tr>
                        <tr>
                            <td class="odd" colspan="7" style="height: 39px">
                                <asp:CheckBox ID="ChkUseDftCase" runat="server" Text="Use Default Case" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:CheckBox ID="ChkPrntSumm" runat="server" Text="Use Fee PrintName Summary" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </td>
                        </tr>
                       
                       <tr>
                            <td align="center" class="FooterCommand" valign="middle" colspan="3">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>


                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Student Details</HeaderTemplate>

                <ContentTemplate>
                    <table style="width: 100%; height: 0px;">
                        <tr>
                            
                           <td class="odd">
                                <asp:Label ID="Label4" runat="server" Height="18px" Text="Group" Width="60px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdInstitute" runat="server" AccountType="InstituteGroup" PlaceHoldr="Group" />
                            </td>
                            <td class="odd" style="width: 60px">
                                <asp:Label ID="Label1" runat="server" Height="30px" Text="Class" Width="60px" SkinID="LblBold"></asp:Label>
                            </td>
                            <td class="odd">
                                <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" PlaceHoldr="Class" />
                            </td>
                        </tr>
                        <tr class="result-head">
                           
                            <td class="odd" style="height: 39px">
                                    <asp:Label ID="Label5" runat="server" Height="30px" SkinID="LblBold" Text="Division" Width="60px"></asp:Label>
                                </td>
                                <td class="odd" style="height: 39px">
                                    <uc2:CtrlGridList ID="CtrlGrdDiv" runat="server" AccountType="DivisionList" PlaceHoldr="Division" />
                                </td>
                                <td class="odd" style="width: 60px; height: 39px;">
                                    <asp:Label ID="Label3" runat="server" Height="30px" SkinID="LblBold" Text="Student" Width="60px"></asp:Label>
                                </td>
                                <td class="odd" style="height: 39px">
                                    <uc2:CtrlGridList ID="CtrlGrdStudent_Scr" runat="server" AccountType="StudentList" PlaceHoldr="Student"  />
                                </td>
                        </tr>
                         <tr>
                                <td>
                                    <asp:Button ID="cmdFill" runat="server" Text="Find" SkinID="BtnCommandFindNew" CommandName="FIND" OnClick="cmdFill_Click" />
                                </td>
                               
                            </tr>


                         <tr>
                            <td colspan="5" rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 300px; width: 900px;">
                                    <asp:GridView ID="GrdReceiptList" runat="server"  SkinID="GrdVwMaster" Width="600px" OnSelectedIndexChanging="GrdReceiptList_SelectedIndexChanging" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Receipt No">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("ReciptNo") %>' Width="100px"></asp:LinkButton>
                                                     <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Receipt Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblReceiptDate" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ReciptDate") %>' Width="150px" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Admission No">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAdmissionNo" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("AdmissionNo") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Student">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblStudent" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Student")  %>' Width="100px" ></asp:Label>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="GroupSection">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblGroupSection" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("GroupSection") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="NetAmountPayable">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblNetAmountPayable" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("NetAmountPayable") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnPrint" runat="server" Text="Print" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </td>
                        </tr>




                    </table>
                </ContentTemplate>




            </ajaxToolkit:TabPanel>

        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

