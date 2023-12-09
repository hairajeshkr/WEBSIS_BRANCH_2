<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StaffAgnSubject.aspx.cs" Inherits="STUDENT_StaffAgnSubject" StylesheetTheme="SkinFile" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="../CtrlCommand.ascx" tagname="CtrlCommand" tagprefix="uc1" %>
<%@ Register src="../CtrlGridList.ascx" tagname="CtrlGridList" tagprefix="uc2" %>
<%@ Register src="../CtrlDate.ascx" tagname="CtrlDate" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" src="Script/InstituteGrp.js" type="text/javascript"></script>
    <div style="height: 535px; width: 1180px">
      <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="540px" Width="1180px" BorderColor="White" BorderStyle="Solid"  BorderWidth="0px" style="border:1px solid #fff !important;">
          <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
              <HeaderTemplate> Staff Student Assign
              </HeaderTemplate>
              
               <ContentTemplate>
                   <table class="auto-style1">
                       <tr>
                               <td>
                                   <asp:Label ID="Label1" runat="server" Text="Staff Name"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="Label3" runat="server" Text="Class"></asp:Label>
                               </td>
                               <td>
                                   <asp:Label ID="Label4" runat="server" Text="Division"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <uc2:CtrlGridList ID="CtrlGrdStaffName" runat="server" AccountType="AllCountryList" />
                               </td>
                               <td>
                                   <uc2:CtrlGridList ID="CtrlGrdClass" runat="server" AccountType="ClassList" />
                               </td>
                               <td>
                                   <uc2:CtrlGridList ID="CtrlGrdDivision" runat="server" AccountType="DivisionList" />
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="Label5" runat="server" Text="Subject"></asp:Label>
                               </td>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                           </tr>
                           <tr>
                               <td>
                                   <uc2:CtrlGridList ID="CtrlGrdSubject" runat="server" AccountType="CoScholasticMainSubject" />
                               </td>
                               <td>
                                   <asp:Button ID="BtnFind" runat="server" CommandName="FIND" OnClick="ManiPulateDataEvent_Clicked" SkinID="BtnCommandFindNew" Text="Find" Width="69px" />
                               </td>
                               <td>&nbsp;</td>
                           </tr>
                           <tr>
                               <td class="odd" colspan="3">
                                   <div class="result-list" style="overflow: scroll; height: 370px; width: 1100px">
                                       <asp:GridView ID="GrdVwRecords" runat="server" SkinID="GrdVwMasterNoPageing" Width="750px">
                                           <Columns>
                                               <asp:BoundField />
                                               <asp:TemplateField HeaderText="Student Name">
                                                   <ItemTemplate>
                                                       <asp:Label ID="LblName" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("StudentName") %>' Width="280px"></asp:Label>
                                                       <asp:HiddenField ID="HdnId" runat="server" Value='<%# Eval("ID") %>' />
                                                       <asp:HiddenField ID="HdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Class">
                                                   <ItemTemplate>
                                                       <asp:Label ID="LblClass" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("ClassName") %>' Width="200px"></asp:Label>
                                                       <asp:HiddenField ID="HdnClassId" runat="server" Value='<%# Eval("ClassId") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Division">
                                                   <ItemTemplate>
                                                       <asp:Label ID="LblDiv" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("DivisionName") %>' Width="200px"></asp:Label>
                                                       <asp:HiddenField ID="HdnDivisionId" runat="server" Value='<%# Eval("DivisionId") %>' />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Subject">
                                                   <ItemTemplate>
                                                       <asp:Label ID="LblSubject" runat="server" SkinID="LblGrdMaster" Text='<%# Eval("SubjectName") %>' Width="200px"></asp:Label>
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Edit students">
                                                   <ItemTemplate>
                                                       <asp:Button ID="BtnOther" runat="server" Text="Edit Students" Width="120px" />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                           </Columns>
                                       </asp:GridView>
                                   </div>
                               </td>
                               <td></td>
                           </tr>
                           <tr>
                               <td align="center" class="FooterCommand" colspan="3" valign="middle">
                                   <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="True" IsVisibleFind="True" IsVisiblePrint="false" />
                               </td>
                           </tr>
                       

                       </table>
              </ContentTemplate>


               </ajaxToolkit:TabPanel>
          
      </ajaxToolkit:TabContainer>
        </div>  
</asp:Content>
