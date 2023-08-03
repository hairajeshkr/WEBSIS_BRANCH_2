<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsSettings.aspx.cs" Inherits="FIN_ConsSettings" StylesheetTheme="SkinFile" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="../CtrlGridSmallList.ascx" TagName="CtrlGridSmallList" TagPrefix="uc4" %>



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
                                    <asp:Button ID="BtnFind" runat="server" Text="Find" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="ManiPulateDataEvent_Clicked" /> 
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    <asp:Label ID="lblGrpId" runat="server"></asp:Label>
                                    <asp:Label ID="lblClsId" runat="server"></asp:Label>
                                    <asp:Label ID="lblDivId" runat="server"></asp:Label>
                                </td>
                            </tr>



                            <tr>
                                <td colspan="4">
                                    <div class="result-list" style="overflow: scroll; height: 360px; width: 780px;">
                                        <asp:GridView ID="GrdVwFee" runat="server"  OnRowDataBound="GrdVwFee_RowDataBound" >
                                        
                                        </asp:GridView>
                                        <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript">


                                        </script>
                                        <script type="text/javascript">








                                            function Myfunction(Amount, InsGrpId, ClsId, DivId, StuId, FeeId, RowIndxx, AcId, BrId, CmpId, FaId,AccLedgerId,OrderIndex) {

                                                var txtName = document.getElementById(Amount);

                                                //alert("amount" + Amount);
                                                //alert("institution id" + InsGrpId);
                                                //alert("ClsId" + ClsId);
                                                //alert("DivId" + DivId);
                                                //alert("StuId" + StuId);
                                                alert("FeeId" + FeeId);

                                                var grd = document.getElementById('<%= GrdVwFee.ClientID %>');
                                                
                                                var RowIndx = RowIndxx;

                                                var InstallmentId = grd.rows[RowIndx].cells[0].childNodes[0].textContent;
                                                

                                                //alert("function" + txtName.value + "" + InsGrpId + "" + ClsId + " " + DivId + "" + StuId + " " + FeeId + " -" + InstallmentId + "");


                                                $.ajax({

                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    url: "ConsSettings.aspx/InsertData",
                                                    data: "{'nFEEId':'" + FeeId + "','nINSSTALId':'" + InstallmentId + "','nINSTIId':'" + InsGrpId + "','nCLSId':'" + ClsId + "','nDIVId':'" + DivId + "','nSTUDId':'" + StuId + "','nAmount':'" + txtName.value + "','AcId':'" + AcId + "','BrId':'" + BrId + "','CmpId':'" + CmpId + "','FaId':'" + FaId + "','AccLedgerId':'" + AccLedgerId + "','OrderIndex':'" + OrderIndex + "'}",
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

                                    <td>
                                   
                                </td>
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

