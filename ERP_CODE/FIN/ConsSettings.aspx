﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsSettings.aspx.cs" Inherits="FIN_ConsSettings" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="../CtrlGridSmallList.ascx" TagName="CtrlGridSmallList" TagPrefix="uc4" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/User.js" type="text/javascript"></script>

    <div style="height: 535px; width: 1060px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="535px" Width="1060px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>
                    Concession Assign
                </HeaderTemplate>

                <ContentTemplate>

                    <table style="width: 100%; height: 0px;">
                        <tr>
                            <td rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 220px;">
                                    <asp:TreeView ID="TreVwLst" runat="server" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged"></asp:TreeView>
                                    <script type="text/javascript">
                                        function FillGrid(INS, CLS, DIV, GRDR) {
                                            alert("111");
                                            var DrpInstitute = document.getElementById(INS);
                                            var DrpClass = document.getElementById(CLS);
                                            var DrpDivision = document.getElementById(DIV);
                                            var GGG = document.getElementById(GRDR);
                                            alert("function" + DrpInstitute.value + "" + DrpClass.value + " " + DrpDivision.value + "" + GGG.value + "");
                                        }
                                    </script>
                                </div>

                            </td>

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

                            <tr>

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
                                    <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student" />
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <%--<asp:Button ID="BtnFind" runat="server" OnClick="ManiPulateDataEvent_Clicked" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" />  --%>
                                    <asp:Button ID="BtnFind" runat="server" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="BtnFind_Click" />
                                </td>

                            </tr>



                            <tr>
                                <td colspan="4">
                                    <div class="result-list" style="overflow: scroll; height: 360px; width: 780px;">
                                        <asp:GridView ID="GrdVwInstallment" runat="server" AutoGenerateColumns="false" OnRowDataBound="GrdVwInstallment_RowDataBound" SkinID="GrdVwMaster">
                                            <Columns>

                                                <asp:TemplateField ItemStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <a href="JavaScript:divexpandcollapse('div<%# Eval("ID") %>');"></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="280px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installment">
                                                    <ItemTemplate>
                                                        
                                                        <asp:Label ID="LblInstallment" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("cName") %>' Width="280px"></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Date">
                                                    <ItemTemplate>
                                                        <uc1:CtrlDate runat="server" ID="CtrlFromDate" />
                                                        <%--<asp:Label ID="LblFine" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("dStartDate") %>' Width="280px"></asp:Label>--%>
                                                        <%--<asp:LinkButton ID="LnkCode" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Value='<%# Eval("dStartDate") %>' Width="120px"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Due date">
                                                    <ItemTemplate>
                                                        <uc1:CtrlDate runat="server" ID="CtrlToDate" />
                                                        <%--asp:Label ID="LblFine" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("dEndDate") %>' Width="280px"></asp:Label>
                                                       <asp:LinkButton ID="LnkAdmissionNo" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Value='<%# Eval("dEndDate") %>' Width="120px"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td colspan="100%">
                                                                <div id="div<%# Eval("ID") %>" style="position: relative; left: 15px; overflow: auto">

                                                                    <asp:GridView ID="GrdVwFee" runat="server" AutoGenerateColumns="false" SkinID="GrdVwMaster" Width="780px" OnRowDataBound="GrdVwFee_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="LblFeeId" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="280px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Fees Name" >
                                                                                <ItemTemplate>
                                                                                    
                                                                                    <asp:Label ID="LblFee" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="280px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate></ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="TxtAmount" runat="server" placeholder="0.00"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>


                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>


                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                        <script language="javascript" type="text/javascript">
                                            function divexpandcollapse(divname) {
                                                var div = document.getElementById(divname);

                                                if (div.style.display == "none") {
                                                    div.style.display = "inline";

                                                }
                                                else {
                                                    div.style.display = "none";
                                                }
                                            }
                                        </script>



                                        <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript">


                                        </script>
                                        <script type="text/javascript">








                                            function Myfunction(Amount, InsGrpId, ClsId, DivId, StuId, FeeId, InstallmentId, AcId, BrId, CmpId, FaId, AccLedgerId, OrderIndex,Fromdate,DueDate) {

                                                var txtName = document.getElementById(Amount);


                                                var Fromdate = document.getElementById(Fromdate).value;
                                                var Duedate = document.getElementById(DueDate).value;
                                                //alert("amount" + Amount);
                                                //alert("institution id" + InsGrpId);
                                                //alert("ClsId" + ClsId);
                                                //alert("DivId" + DivId);
                                                //alert("StuId" + StuId);
                                                alert("fromdate" + Fromdate.value);
                                                alert("duedate" + Duedate.value);

                                                var InsGrpIdd = document.getElementById(InsGrpId).value;
                                                var ClsIdd = document.getElementById(ClsId).value;
                                                var DivIdd = document.getElementById(DivId).value;
                                                var StuIdd = document.getElementById(StuId).value;
                                                //alert(stuidd);


                                                alert("function" + txtName.value + "" + InsGrpId + "" + ClsId + " " + DivId + "" + StuId + " " + FeeId + " -" + InstallmentId + "");


                                                $.ajax({

                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    url: "ConsSettings.aspx/InsertData",
                                                    data: "{'nFEEId':'" + FeeId + "','nINSSTALId':'" + InstallmentId + "','nINSTIId':'" + InsGrpIdd + "','nCLSId':'" + ClsIdd + "','nDIVId':'" + DivIdd + "','nSTUDId':'" + StuIdd + "','nAmount':'" + txtName.value + "','AcId':'" + AcId + "','BrId':'" + BrId + "','CmpId':'" + CmpId + "','FaId':'" + FaId + "','AccLedgerId':'" + AccLedgerId + "','OrderIndex':'" + OrderIndex + "'}",
                                                    dataType: "json",
                                                    success: function (data) {
                                                        var obj = data.d;
                                                        if (obj == 'true') {
                                                            $('#nFEEId').val('');
                                                            $('#nINSSTALId').val('');
                                                            $('#nINSTIId').val('');
                                                            $('#nCLSId').val('');
                                                            $('#nDIVId').val('');
                                                            $('#nSTUDId').val('');
                                                            $('#nAmount').val('');
                                                            $('#AcId').val('');
                                                            $('#BrId').val('');
                                                            $('#CmpId').val('');
                                                            $('#FaId').val('');
                                                            $('#AccLedgerId').val('');
                                                            $('#OrderIndex').val('');
                                                            $('#lblmsg').html("Details Submitted Successfully");
                                                            //window.location.reload();
                                                        }
                                                    },
                                                    error: function (result) {
                                                        alert("Error");
                                                    }
                                                });





                                            }

                                        </script>
                                    </div>
                                </td>

                                <tr>

                                    <td></td>
                                    <td align="center" class="FooterCommand" colspan="5" valign="middle">
                                        <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                                    </td>
                                </tr>
                            </tr>

                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
