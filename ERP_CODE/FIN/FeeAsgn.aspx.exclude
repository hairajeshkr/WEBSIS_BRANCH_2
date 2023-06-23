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
                      <tr class="result-head">                         
                          <td style="height: 39px">
                              <asp:Label ID="Label13" runat="server" Text="Institute" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:DropDownList ID="DrpInstitute" runat="server" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" Width="200px" AutoPostBack="True" OnTextChanged="DrpInstitute_SelectedIndexChanged">
                              
                                  </asp:DropDownList>
                             
                          </td>
                          <td style="height: 39px">
                              <asp:Label ID="Label14" runat="server" Text="Class" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                             <asp:DropDownList ID="DrpClass" runat="server" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DrpClass_SelectedIndexChanged">
                                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                          <td style="height: 39px">
                              <asp:Label ID="Label1" runat="server" Text="Division" Width="42px"></asp:Label>
                          </td>
                          <td style="height: 39px">
                              <asp:DropDownList ID="DrpDivision" runat="server" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" Width="200px">
                                  <asp:ListItem Value="0">--Select--</asp:ListItem>
                              </asp:DropDownList>
                          </td>
                          <td style="height: 39px">
                              <asp:Button ID="BtnFind" runat="server" Text="Fill" Width="69px"  OnClick="BtnFind_Click" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="2">
                              <div class="result-list" style="overflow: scroll; height: 400px; width: 200px;">
                                  <asp:GridView ID="GrdVwRecords" runat="server"  SkinID="GrdVwMaster" OnSelectedIndexChanged="GrdVwRecords_SelectedIndexChanged" >
                                      <Columns>

                                                  <asp:BoundField HeaderText ="ID" DataField ="ID" />  

                                          <asp:TemplateField HeaderText="Institute/Class/Division">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                                                                
                                        
                                          <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                          <ItemStyle Width="200px" />
                                          </asp:BoundField>
                                          <asp:CheckBoxField DataField="Active" HeaderText="Active" />
                                      </Columns>
                                  </asp:GridView>
                              </div>
                          </td>

                          <td colspan="5">
                              <div class="result-list" style="overflow: scroll; height: 400px; width: 690px;">
<<<<<<< HEAD
                                  <asp:GridView ID="GrdVwFee" runat="server"  SkinID="GrdVwMaster" Width="662px">
                                       <Columns>
=======
                                 
                                  <asp:GridView ID="GrdVwFee" runat="server"  Width="662px"   OnRowDataBound ="GrdVwFee_RowDataBound" onrowcommand="GrdVwFee_RowCommand" OnRowEditing="txtDynamic_TextChanged" OnRowUpdating="GrdVwFee_RowUpdating1" OnSelectedIndexChanged="GrdVwFee_SelectedIndexChanged" >
                                  
                                      

                                  </asp:GridView>
                                  <script type="text/javascript">
                                      function Myfunction(ID,INS,CLS,DIV,GRDR,GRDFEE) {
                                          //Text SS = document.getElementsByTagName("txt");
                                          var txtName = document.getElementById(ID);
                                          var DrpInstitute = document.getElementById(INS);
                                          var DrpClass = document.getElementById(CLS);
                                          var DrpDivision = document.getElementById(DIV);
                                          var GGG = GRDR;
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
                                          alert("function" + txtName.value + " " + DrpInstitute.value + "" + DrpClass.value + " " + DrpDivision.value + "" + GGG + " " + FEEG + "");
                                         // alert("function" + txtName.value + "");

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
                             

                                  



>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a

                                       </Columns>
                                  </asp:GridView>
                              </div>
                          </td>


                      </tr>
                      <tr>
                          <td></td>
                          <td></td>
                          <td></td>
                          <td>
                              <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                          </td>
                          <td>
                              <asp:Button ID="Button1" runat="server" Text="Save Fee" OnClick="Button1_Click" />
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
                </table>
                   </ContentTemplate>
              </ajaxToolkit:TabPanel>
           <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
          </ajaxToolkit:TabPanel>
           </ajaxToolkit:TabContainer>
        </div>

</asp:Content>

