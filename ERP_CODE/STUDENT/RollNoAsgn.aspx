<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RollNoAsgn.aspx.cs" StylesheetTheme="SkinFile" Inherits="STUDENT_RollNoAsgn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 420px; width: 970px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px" Width="950px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                <HeaderTemplate>
                    Roll No Assign
                </HeaderTemplate>

                <ContentTemplate>
                    <table class="auto-style1">

                        <tr>
                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label5" runat="server" Text="Institution" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px; ">
                                 <asp:DropDownList ID="DrpInstitution" runat="server" Width="150px" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" AutoPostBack="True" OnSelectedIndexChanged="DrpInstitution_SelectedIndexChanged" >
                                 </asp:DropDownList>
                            </td>

                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label122" runat="server" Text="Class" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 150px; ">
                                 <asp:DropDownList ID="DrpClass" runat="server" Width="150px" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" AutoPostBack="True" OnSelectedIndexChanged="DrpClass_SelectedIndexChanged" >
                                     <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td class="odd" style="width: 90px; ">
                                <asp:Label ID="Label3" runat="server" Text="Division" Width="60px" Height="30px"></asp:Label>
                            </td>
                            <td class="odd" style="width: 319px;">
                                 <asp:DropDownList ID="DrpDivision" runat="server" Width="150px" AppendDataBoundItems="True" DataTextField="cName" DataValueField="nId" >
                                     <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td class="odd" style="width: 319px; height: 30px">
                                <asp:Button ID="BtnFind" runat="server" Text="Fill" Width="69px" CommandName="FIND" SkinID="BtnCommandFindNew" OnClick="BtnFind_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div class="result-list" style="overflow: scroll; height: 300px; width: 720px;">
                                    <asp:GridView ID="GrdVwRecords" runat="server"  SkinID="GrdVwMaster">
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
                                                    <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        
                         <tr>
                            <td></td>
                            <td></td>
                          <td align="center" class="FooterCommand" colspan="4" valign="middle">
                              
                              <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                          </td>
                      </tr>
                    </table>



                </ContentTemplate>
                
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
              <HeaderTemplate>Roll No Assign List
              </HeaderTemplate>
              
              <ContentTemplate>
                  <div class="result-list" style="overflow: scroll; height: 300px; width: 720px;">
                  <asp:GridView ID="GrdStudents" runat="server"  SkinID="GrdVwMaster">
                                        
                                            <%--<Columns>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkName" runat="server" CommandName="SELECT" SkinID="LnkBtnGrdMain" Text='<%# Eval("cName") %>' Width="175px"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCode" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ID") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblStaff" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("cName") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblgrpName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("cName") %>' Width="150px"></asp:Label>
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

