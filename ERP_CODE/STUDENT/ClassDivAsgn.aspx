<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClassDivAsgn.aspx.cs" StylesheetTheme="SkinFile" Inherits="STUDENT_ClassAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/ClassDivAsgn.js" type="text/javascript"></script>
    <div style="height: 420px; width: 970px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px" Width="950px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Class&Division Assign
                </HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">

                        <tr>
                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label5" runat="server" Text="Institution" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px; ">
                                 <asp:DropDownList ID="DrpInstitution" runat="server" Width="150px" AppendDataBoundItems="true" DataTextField="cName" DataValueField="nId" AutoPostBack="true" OnSelectedIndexChanged="DrpInstitution_SelectedIndexChanged" >
                                 </asp:DropDownList>
                            </td>

                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label122" runat="server" Text="Class" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px; ">
                                 <asp:DropDownList ID="DrpClass" runat="server" Width="150px" AppendDataBoundItems="true" DataTextField="cName" DataValueField="nId" AutoPostBack="true" OnSelectedIndexChanged="DrpClass_SelectedIndexChanged">
                                     <asp:ListItem Text="select" Value="0">select</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label3" runat="server" Text="Division" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px;">
                                 <asp:DropDownList ID="DrpDivision" runat="server" Width="150px" AppendDataBoundItems="true" DataTextField="cName" DataValueField="nId" >
                                     <asp:ListItem Text="select" Value="0">select</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:Button ID="BtnFind" runat="server" Text="Fill" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="BtnFind_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div class="result-list" style="overflow: scroll; height: 300px; width: 720px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server"  SkinID="GrdVwMaster"  >
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" onclick="SelectAll(this)" OnCheckedChanged="cbxHdrPresent_OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk" runat="server" onclick="SelectOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("cName") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                      </Columns>
                                    </asp:GridView>
                                  
                                    <script type="text/javascript">
                                        function SelectAll(headerCheckBox) {
                                            //Get the reference of GridView.
                                            var GridView = headerCheckBox.parentNode.parentNode.parentNode;

                                            //Loop through all GridView Rows except first row.
                                            for (var i = 1; i < GridView.rows.length; i++) {
                                                //Reference the CheckBox.
                                                var checkBox = GridView.rows[i].cells[0].getElementsByTagName("input")[0];
                                                checkBox.checked = headerCheckBox.checked;
                                            }
                                        }
                                    </script>
                                    <script type="text/javascript">
                                        function SelectOne(chk) {
                                            //Get the reference of GridView.
                                            var GridView = chk.parentNode.parentNode.parentNode;

                                            //Reference the Header CheckBox.
                                            var headerCheckBox = GridView.rows[0].cells[0].getElementsByTagName("input")[0];;

                                            var checked = true;

                                            //Loop through all GridView Rows.
                                            for (var i = 1; i < GridView.rows.length; i++) {
                                                //Reference the CheckBox.
                                                var checkBox = GridView.rows[i].cells[0].getElementsByTagName("input")[0];
                                                if (!checkBox.checked) {
                                                    checked = false;
                                                    break;
                                                }
                                            }

                                            headerCheckBox.checked = checked;
                                        };
                                    </script>

                                   

                                </div>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="odd" style="width: 90px; height: 30px"></td>
                            <td class="odd" style="width: 90px; height: 30px"></td>
                        </tr>
                         <tr>
                            <td class="odd" style="width: 90px; height: 30px">
                                <asp:Label ID="Label1" runat="server" Text="Move To" Width="60px" Height="30px"></asp:Label>
                            </td>
                             <td class="odd" style="height: 30px" colspan="6">
                                 
                                <asp:Label ID="Label6" runat="server" Text="Institution" Width="60px" Height="30px"></asp:Label>
                                 <asp:DropDownList ID="DrpInstitution1" runat="server" Width="150px" AppendDataBoundItems="true" DataTextField="cName" DataValueField="nId" AutoPostBack="true" OnSelectedIndexChanged="DrpInstitution1_SelectedIndexChanged">
                                     <asp:ListItem Text="select" Value="1"></asp:ListItem>
                                 </asp:DropDownList>
                          
                                
                                 <asp:Label ID="Label4" runat="server" Height="30px" Text="Class" Width="60px"></asp:Label>
                                 <asp:DropDownList ID="DrpClass1" runat="server" Width="150px" AppendDataBoundItems="true" DataTextField="cName" DataValueField="nId" AutoPostBack="true" OnSelectedIndexChanged="DrpClass1_SelectedIndexChanged">
                                     <asp:ListItem Text="select" Value="1"></asp:ListItem>
                                 </asp:DropDownList>
                                 <asp:Label ID="Label2" runat="server" Height="30px" Text="Division" Width="60px"></asp:Label>
                                 <asp:DropDownList ID="DrpDivision1" runat="server"  Width="150px">
                                     <asp:ListItem Text="select" Value="1"></asp:ListItem>
                                 </asp:DropDownList>
                                
                            </td>
                             </tr>
                        <tr>
                            <td></td>
                            <td></td>
                          <td align="center" class="FooterCommand" colspan="4" valign="middle">
                              <%--<asp:Button ID="Button1" runat="server" Text="Proceed" OnClick="Button1_Click" />--%>
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false"  />
                          </td>
                      </tr>
                    </table>



                </ContentTemplate>
                
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Class&Division List
              </HeaderTemplate>
              
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 300px; width: 720px;">
                      <asp:GridView ID="GridView1" runat="server" SkinID="GrdVwMaster" Visible="false"  > 
                          <Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblName1" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode1" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentId") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblClass1" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDiv1" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                              </Columns>
                          </asp:GridView>
                      <asp:GridView ID="GrdStudents" runat="server" SkinID="GrdVwMaster" AutoGenerateColumns="true"  Width="700px"> 
                          <%--<Columns>
                              <%--<asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                              <asp:BoundField DataField="ID" HeaderText="Id" ItemStyle-Width="150" />
                               <asp:BoundField DataField="Name" HeaderText="Class" ItemStyle-Width="150" />
                              <asp:BoundField DataField="Name" HeaderText="DivisionName" ItemStyle-Width="150" />
                          </Columns>
                      </asp:GridView>
                                        
                                           <Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("Name") %>' Width="175px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("Name") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                      
                                            </Columns>--%>
                          </asp:GridView>
                    
                      </div>

                  </ContentTemplate>
                </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

