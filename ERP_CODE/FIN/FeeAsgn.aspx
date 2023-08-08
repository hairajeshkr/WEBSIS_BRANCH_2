<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeeAsgn.aspx.cs" Inherits="FIN_FeeAsgn" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<%@ Register Src="../CtrlDate.ascx" TagName="CtrlDate" TagPrefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register Src="../CtrlGridSmallList.ascx" TagName="CtrlGridSmallList" TagPrefix="uc4" %>
<%@ Register Src="~/CtrlDate.ascx" TagPrefix="uc1" TagName="CtrlDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                    <asp:TreeView ID="TreVwLst" runat="server" OnSelectedNodeChanged="TreVwLst_SelectedNodeChanged"></asp:TreeView>
                                    <script type="text/javascript">
                                      
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
                                    <uc2:CtrlGridList ID="CtrlGrdStudent" runat="server" AccountType="StudentList" PlaceHoldr="Student"  />
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="cmdFill" runat="server" OnClick="cmdFill_Click" Text="Fill Data" SkinID="BtnCommandFindNew" CommandName="FIND" />
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
                                    <div class="result-list" style="overflow: scroll; height: 350px; width: 780px;">
                                         <script language="javascript" type="text/javascript">
                                             function divexpandcollapse(divname) {
                                                 var div = document.getElementById(divname);

                                                 if (div.style.display == "none") {
                                                     div.style.display = "inline";

                                                 } else {
                                                     div.style.display = "none";
                                                 }
                                             }
                                         </script>


                                        <asp:GridView ID="GrdVwIns" runat="server" AutoGenerateColumns="False" SkinID="GrdVwMaster"  Width="780px" OnRowDataBound="GrdVwIns_RowDataBound" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href="JavaScript:divexpandcollapse('div<%# Eval("ID") %>');">
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblIID" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Installment">
                                        <ItemTemplate>
                                            <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("cName") %>' Width="180px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="From Date">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="LblFromDate" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("FromDate") %>' Width="100px"></asp:Label>--%>
                                            <uc1:CtrlDate runat="server" ID="CtrlFromDate" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Due Date">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="LblDueDate" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DueDate") %>' Width="100px"></asp:Label>--%>
                                            <uc1:CtrlDate runat="server" ID="CtrlDueDate" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <tr>
                                                <td colspan="100%">
                                                    <div id="div<%# Eval("ID") %>" style=" position: relative; left: 15px; overflow: auto">
                                                        <asp:GridView ID="GrdVwRecordsF" runat="server" SkinID="GrdVwMaster" Width="740px" AutoGenerateColumns="False" OnRowDataBound="GrdVwRecordsF_RowDataBound">
                                                            <Columns>
                                                               
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LblID" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="100px" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="Fees Name">
                                                                    <ItemTemplate>
                                                                         <asp:Label ID="FeeName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("FeeName") %>' Width="250px" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%-- <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />--%>
                                                                
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtAmount" runat="server" Width="200px"></asp:TextBox>
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
                                            <RowStyle Font-Bold="True" />
                            </asp:GridView>


                                        <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript">

                                        </script>
                                        <script type="text/javascript">

                                            function MyfunctionG(Amt, DrpInstitute, DrpClass, DrpDivision, DrpStudId, GRDFEE, GRI)
                                            {
                                                var txtAmt = document.getElementById(Amt);
                                                alert(txtAmt);
                                            }





                                            function Myfunction(Amt, DrpInstitute, DrpClass, DrpDivision, DrpStudId, GRDFEEID, GRDINSTID,  iCmpId, iBrId, iFaId, iAcId, nAccLedgerId, nOrderIndex,FromDate,DueDate) {

                                                //alert(FromDate);
                                                //var FromD = document.getElementById(FromDate).value;
                                                //alert(FromD);
                                                //alert(GRDINSTID);
                                                var txtAmt = document.getElementById(Amt);
                                               // alert(txtAmt);
                                              <%--  var grd = document.getElementById('<%= GrdVwIns.ClientID %>');
                                                var ri = GRI;
                                                var InstallID = grd.rows[ri].cells[0].childNodes[0].textContent;--%>
                                                //alert(CtrlGrdStudent.ClientID);
                                                var InstallID = GRDINSTID;
                                                var nStudId = document.getElementById(DrpStudId).value;
                                                var Division = document.getElementById(DrpDivision).value;
                                                var Class = document.getElementById(DrpClass).value;
                                                var Institute = document.getElementById(DrpInstitute).value;
                                                //alert(StudId1);

                                                alert("function" + txtAmt.value + "" + Institute + "" + Class + " " + Division + "" + nStudId + " " + GRDFEEID + " -" + InstallID + "");


                                                $.ajax({

                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    url: "FeeAsgn.aspx/InsertData",
                                                    data: "{'nFEEId':'" + GRDFEEID + "','nINSSTALId':'" + InstallID + "','nINSTIId':'" + Institute + "','nCLSId':'" + Class + "','nDIVId':'" + Division + "','nSTUDId':'" + nStudId + "','nAmount':'" + txtAmt.value + "','iCmpId':'" + iCmpId + "','iBrId':'" + iBrId + "','iFaId':'" + iFaId + "','iAcId':'" + iAcId + "','nAccLedgerId':'" + nAccLedgerId + "','nOrderIndex':'" + nOrderIndex + "'}",
                                                    dataType: "json",
                                                    success: function (data) {
                                                        var obj = data.d;
                                                        if (obj == 'true') {
                                                            $('#nFEEId').val('');
                                                            $('#nINSSTALId').val('');
                                                            $('#nINSTIId').val('0');
                                                            $('#nCLSId').val('0');
                                                            $('#nDIVId').val('0');
                                                            $('#nSTUDId').val('0');
                                                            $('#nAmount').val('');
                                                            $('#iCmpId').val('');
                                                            $('#iBrId').val('');
                                                            $('#iFaId').val('');
                                                            $('#iAcId').val('');
                                                            $('#nAccLedgerId').val('');
                                                            $('#nOrderIndex').val('');
                                                            $('#lblmsg').html("Details Submitted Successfully");
                                                            //window.location.reload();
                                                        }
                                                    },
                                                    error: function (result) {
                                                        alert("Error");
                                                    }
                                                });


                                                $.ajax({

                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    url: "FeeAsgn.aspx/UpdateGridcell",
                                                    data: "{'RowG':'" + GRI + "','ColumnG':'" + cov + "','amount':'" + txtName.value + "'}",
                                                    dataType: "json",
                                                    success: function (data) {
                                                        var obj = data.d;
                                                        if (obj == 'true') {
                                                            $('#RowG').val('');
                                                            $('#ColumnG').val('');
                                                            $('#nAmount').val('');
                                                            $('#lblmsg').html("Details Submitted Successfully");
                                                            //window.location.reload();
                                                        }
                                                    },
                                                    error: function (result) {
                                                        alert("Error");
                                                    }
                                                });


                                               

                                                function DateGetF(CtrlFDate) {
                                                    alert(1);
                                                    alert(CtrlFDate);
                                                                                                      
                                                    var FromDate = document.getElementsById(CtrlFDate);
                                                }



                                            }

                                        </script>
                                    </div>
                              </td>
                                
                                   
                                   
                              

                                
                            </tr>

                        </tr>
                              <tr>
                                   
                                    <td align="center" class="FooterCommand" colspan="5" valign="middle">
                                        <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                                    </td>
                                </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
           
             <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Student Details</HeaderTemplate>

                <ContentTemplate>
                    <table>

                        <script language="javascript" type="text/javascript">
                            function divexpandcollapse(divname) {
                                var div = document.getElementById(divname);
                                
                                if (div.style.display == "none") {
                                    div.style.display = "inline";
                                    
                                } else {
                                    div.style.display = "none";
                                       }
                            }
                        </script>

                        
                           
                            

                      </table>

                 


                </ContentTemplate>
                 </ajaxToolkit:TabPanel>

        </ajaxToolkit:TabContainer>
    </div>

</asp:Content>

