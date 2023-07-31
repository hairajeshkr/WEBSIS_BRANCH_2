<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsSettings.aspx.cs" Inherits="FIN_ConsSettings" %>

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
                    Fee Assign
                </HeaderTemplate>

                <ContentTemplate>

                    <table style="width: 100%; height: 0px;">
                        <tr>
                            <td rowspan="4">
                                <div class="result-list" style="overflow: scroll; height: 420px; width: 220px;">
                                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"></asp:TreeView>
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
                                <td>
                                    <asp:Button ID="cmdFill" runat="server" OnClick="Button1_Click" Text="Fill Data" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    <asp:Label ID="lblGrp" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF99FF"></asp:Label>
                                    <asp:Label ID="lblCls" runat="server" Font-Bold="True" ForeColor="#9999FF"></asp:Label>
                                    <asp:Label ID="lblDiv" runat="server" Font-Bold="True" ForeColor="#CC99FF"></asp:Label>
                                    <asp:Label ID="lblGrpId" runat="server"></asp:Label>
                                    <asp:Label ID="lblClsId" runat="server"></asp:Label>
                                    <asp:Label ID="lblDivId" runat="server"></asp:Label>
                                </td>
                            </tr>



                            <tr>
                                <td colspan="4">
                                    <div class="result-list" style="overflow: scroll; height: 360px; width: 780px;">
                                        <asp:GridView ID="GrdVwFee" runat="server" OnRowCommand="GrdVwFee_RowCommand" OnRowDataBound="GrdVwFee_RowDataBound" OnRowEditing="txtDynamic_TextChanged" OnRowUpdating="GrdVwFee_RowUpdating1" OnSelectedIndexChanged="GrdVwFee_SelectedIndexChanged">
                                        
                                        </asp:GridView>
                                        <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript">


                                        </script>
                                        <script type="text/javascript">








                                            function Myfunction(ID, INS, CLS, DIV, GRDR, GRDFEE, GRI, CtrlFDate, CtrlDuDate) {
                                                var txtName = document.getElementById(ID);
                                                //var DrpInstitute = document.getElementById(INS);
                                                var DrpInstitute = INS;
                                                //var DrpClass = document.getElementById(CLS);
                                                var DrpClass = CLS;
                                                //var DrpDivision = document.getElementById(DIV);
                                                var DrpDivision = DIV;
                                                //var GGG = document.getElementById(GRDR);
                                                var GGG = GRDR;
                                                var FEEG = document.getElementById(GRDFEE);

                                                ID.textContent = txtName.value;
                                                //alert(ID.CellValue);
                                                var grd = document.getElementById('<%= GrdVwFee.ClientID %>');
                                                //alert(GRI);
                                                var ri = GRI;
                                                var CellValue = grd.rows[ri].cells[0].childNodes[0].textContent;
                                                //var CDD = grd.rows[1].cells.count;

                                                alert(CtrlFDate);

                                               // var FromDate = document.getElementsByTagName(CtrlFDate);
                                               var FromDate = document.getElementsById(CtrlFDate);
                                               //var DueDate = document.getElementById(CtrlDuDate);
                                                alert(FromDate);
                                               alert(FromDate.value);

                                               // alert("function" + txtName.value + "" + DrpInstitute + "" + DrpClass + " " + DrpDivision + "" + GGG + " " + FEEG.value + " -" + CellValue + "" + CtrlFDate.value + "" + CtrlDuDate + "");
                                                alert("function" + txtName.value + "" + DrpInstitute + "" + DrpClass + " " + DrpDivision + "" + GGG + " " + FEEG.value + " -" + CellValue + "");

                                                $.ajax({

                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    url: "FeeAsgn.aspx/InsertData",
                                                    data: "{'nFEEId':'" + FEEG.value + "','nINSSTALId':'" + CellValue + "','nINSTIId':'" + DrpInstitute + "','nCLSId':'" + DrpClass + "','nDIVId':'" + DrpDivision + "','nSTUDId':'" + GGG + "','nAmount':'" + txtName.value + "'}",
                                                    dataType: "json",
                                                    success: function (data) {
                                                        var obj = data.d;
                                                        if (obj == 'true') {
                                                            $('#nFEEId').val('');
                                                            $('#nINSSTALId').val('');
                                                            $('#nINSTIId').val('');
                                                            $('#nCLSId').val('');
                                                            $('#nDIVId').val('');
                                                            $('#nSTUDId').val(0);
                                                            $('#nAmount').val('');
                                                            $('#lblmsg').html("Details Submitted Successfully");
                                                            //window.location.reload();
                                                        }
                                                    },
                                                    error: function (result) {
                                                        alert("Error");
                                                    }
                                                });


                                                //$.ajax({

                                                //    type: "POST",
                                                //    contentType: "application/json; charset=utf-8",
                                                //    url: "FeeAsgn.aspx/UpdateTble",
                                                //    data: "{'nFEEId':'" + FEEG.value + "','nINSSTALId':'" + CellValue + "','nINSTIId':'" + DrpInstitute.value + "','nCLSId':'" + DrpClass.value + "','nDIVId':'" + DrpDivision.value + "','nSTUDId':'" + GGG.value + "','nAmount':'" + txtName.value + "'}",
                                                //    dataType: "json",
                                                //    success: function (data) {
                                                //        var obj = data.d;
                                                //        if (obj == 'true') {
                                                //            $('#nFEEId').val('');
                                                //            $('#nINSSTALId').val('');
                                                //            $('#nINSTIId').val('');
                                                //            $('#nCLSId').val('');
                                                //            $('#nDIVId').val('');
                                                //            $('#nSTUDId').val('');
                                                //            $('#nAmount').val('');
                                                //            $('#lblmsg').html("Details Submitted Successfully");
                                                //            window.location.reload();
                                                //        }
                                                //    },
                                                //    error: function (result) {
                                                //        alert("Error");
                                                //    }
                                                //});



                                            }

                                        </script>
                                    </div>
                                </td>

                                <tr>

                                    <td>
                                    <asp:Button ID="CmdSave" runat="server" Text="Save Data" OnClick="CmdSave_Click" />
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

