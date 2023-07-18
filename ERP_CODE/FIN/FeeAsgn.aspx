<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeeAsgn.aspx.cs" Inherits="FIN_FeeAsgn" StyleSheetTheme="SkinFile"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<%@ Register Src="~/CtrlGridList.ascx" TagPrefix="uc1" TagName="CtrlGridList" %>
<%@ Register src="../CtrlGridSmallList.ascx" tagname="CtrlGridSmallList" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" src="Script/User.js" type="text/javascript"></script>

    <div style="height:535px; width:960px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="535px" Width="960px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Fee Assign
              </HeaderTemplate>
              
              <ContentTemplate>
                <table>
                    <table style="width: 100%; height: 0px;">
                      

                    
                      <tr>
                          <td colspan="2">
                              <div class="result-list" style="overflow: scroll; height: 400px; width: 200px;">
                                  <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"></asp:TreeView>
                              </div>


                          </td>
                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 400px; width: 590px;">
                                  <asp:GridView ID="GrdVwFee" runat="server" OnRowCommand="GrdVwFee_RowCommand" OnRowDataBound="GrdVwFee_RowDataBound" OnRowEditing="txtDynamic_TextChanged" OnRowUpdating="GrdVwFee_RowUpdating1" OnSelectedIndexChanged="GrdVwFee_SelectedIndexChanged">
                                  </asp:GridView>
                                  <script type="text/javascript">


                                      function Myfunction(ID,INS,CLS,DIV,GRDR,GRDFEE) {
                                          //Text SS = document.getElementsByTagName("txt");
                                          var txtName = document.getElementById(ID);
                                          //alert("fff" + INS);
                                          var DrpInstitute = document.getElementById(INS);
                                          //alert("fff1" + DrpInstitute);
                                         // var lblGrp = document.getElementById(INS);
                                          var DrpClass = document.getElementById(CLS);
                                          var DrpDivision = document.getElementById(DIV);
                                          //var GGG = GRDR;
                                          var GGG = document.getElementById(GRDR);
                                          var FEEG = document.getElementById(GRDFEE);


                                          //var GrdVwRecords1 = document.getElementById(GRDR);
                                          //var GRDVAL = GrdVwRecords1.rows[1].cells[1].getElementsByTagName("cName")[0].id;
                                          

                                          //var strClientId = "";
                                          //for (var i = 1; i < GrdVwRecords1.rows.length; i++) {
                                          //    if (GrdVwRecords1.rows[i].cells[position] && GrdVwRecords1.rows[i].cells[position].childNodes[0] && GrdVwRecords1.rows[i].cells[position].childNodes[0].nodeName == 'INPUT' && GrdVwRecords1.rows[i].cells[position].childNodes[0].type == 'text') {
                                          //        strClientId = GrdVwRecords1.rows[i].cells[position].childNodes[0].id;
                                          //        if (strClientId.indexOf(parametrId) > 0) {
                                          //            var GRDVAL=strClientId;
                                          //        }
                                          //    }
                                          //}



                                          //var txtName = ID;
                                          //alert("function" + txtName.value + " " + DrpInstitute.value + "" + DrpClass.value + " " + DrpDivision.value + "" + GGG + " " + FEEG + "");
                                          //alert("function" + txtName.value + " " + DrpInstitute.value + "" + DrpClass.value + " " + DrpDivision.value + "" + GGG + " " + FEEG.value + "");
                                          alert("function" + txtName.value + "" + DrpInstitute.value + "" + DrpClass.value + " " + DrpDivision.value + "" + GGG.value + " " + FEEG.value + "");




                                          var connection = new ActiveXObject("ADODB.Connection");
                                          var connectionstring = "Data Source=.;Initial Catalog=EmpDetail;Persist Security Info=True;User ID=hrm;Password=hrm;Provider=WEBSIS";
                                          connection.Open(connectionstring);
                                          var rs = new ActiveXObject("ADODB.Recordset");
                                          rs.Open("insert into TblFeeInstallmentAssignNew values('" + txtName.value + "','" + DrpInstitute.value + "','" + DrpClass.value + "','" + DrpDivision.value + "','" + GGG.value + "','" + FEEG.value + "')", connection);
                                          alert("Insert Record Successfuly");
                                          txtid.value = " ";
                                          connection.close();







                                          //var x = $("input:txt").val();
                                          //alert(x);

                                          //var table = document.getElementById("GrdVwFee");

                                          //document.getElementById();

                                          ////////


                                         // var GridView = chk.parentNode.parentNode.parentNode;
                                          //for (var i = 1; i < GrdVwFee.rows.length; i++) {
                                          //    for (var j = 1; j < GrdVwFee.Column.length; j++) {

                                          //        var TextV = GrdVwFee.rows[i].cells[j].getElementsByTagName("T"+i+"");
                                          //        document.write(TextV);
                                          //        alert("function");
                                          //    }
                                          //}


                                      }
                                  </script>
                              </div>
                          </td>
                          <tr>
                              <td></td>
                              <td>
                                  <asp:TextBox ID="TxtGrp" runat="server" Width="36px"></asp:TextBox>
                                   <asp:TextBox ID="TxtCls" runat="server" Width="36px"></asp:TextBox>
                                   <asp:TextBox ID="TxtDiv" runat="server" Width="23px"></asp:TextBox>
                                   <asp:TextBox ID="TxtStd" runat="server" Width="36px"></asp:TextBox>
                              </td>
                              <td></td>
                              <td>
                                  <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                                  <asp:Label ID="lblGrp" runat="server" Text="Label" ></asp:Label>
                                  <asp:Label ID="lblCls" runat="server" Text="Label" ></asp:Label>
                                  <asp:Label ID="lblDiv" runat="server" Text="Label" ></asp:Label>
                                  <asp:Label ID="lblStd" runat="server" Text="Label" ></asp:Label>
                              </td>
                              <td>
                                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save Fee" />
                              </td>
                          </tr>
                          <tr>
                              <td style="height: 20px"></td>
                          </tr>
                          <tr>
                              <td align="center" class="FooterCommand" colspan="7" valign="middle">
                                  <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                              </td>
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

