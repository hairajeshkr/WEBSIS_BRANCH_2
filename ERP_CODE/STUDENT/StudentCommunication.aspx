<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentCommunication.aspx.cs" StylesheetTheme="SkinFile" Inherits="STUDENT_StudentCommunication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../CtrlCommand.ascx" TagName="CtrlCommand" TagPrefix="uc1" %>
<%@ Register Src="../CtrlGridList.ascx" TagName="CtrlGridList" TagPrefix="uc2" %>

<%@ Register Src="../CtrlNameIdCtrlSngle.ascx" TagName="CtrlNameIdCtrlSngle" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="Script/StudentAdmisDtls.js" type="text/javascript"></script>
     <script type="text/javascript">
         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                 return false;
             }
             return true;
         }
     </script>
    <div style="height: 400px; width: 750px">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="395px" Width="750px" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" Style="border: 1px solid #fff !important;">
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                <HeaderTemplate>Communication Register</HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="odd" style="width: 90px; height: 37px">
                                <asp:Label ID="Label29" runat="server" Text="Primary Contact" Width="110px"></asp:Label></td>
                            <td class="odd" style="width: 182px; height: 37px;">
                                <asp:DropDownList ID="DdlPrimaryContact" runat="server" SkinID="DdlPrimaryContact"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label1" runat="server" Text="Communication Phone No." Width="177px" Height="30px"></asp:Label></td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtphoneNo" runat="server" placeholder="Communication Phone No" SkinID="TxtSng250" onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label2" runat="server" Text="WatsApp/Message No." Width="166px" Height="30px"></asp:Label></td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtMessageNo" runat="server" placeholder="WatsApp/Message No" SkinID="TxtSng250" onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="odd">
                                <asp:Label ID="Label3" runat="server" Text="Communication Email" Width="154px" Height="30px"></asp:Label></td>
                            <td class="odd" colspan="2">
                                <asp:TextBox ID="TxtCommunicationEmail" runat="server" placeholder="Communication Email" SkinID="TxtSng250"></asp:TextBox></td>
                        </tr>

                        <tr>
                             <td class="odd" height="30px" style="width: 90px; height: 30px">
                                       <asp:Label ID="Label12" runat="server" Text="Remarks" Width="125px"></asp:Label>
                                   </td>
                                   <td class="odd" height="30px" style="width: 182px">
                                       <asp:TextBox ID="TxtRemarks" runat="server" SkinID="TxtMultiLine" TextMode="MultiLine"></asp:TextBox>
                                   </td>
                        </tr>



                        <tr>
                            <td align="center" class="FooterCommand" colspan="4" height="60px" valign="middle">
                                <uc1:CtrlCommand ID="CtrlCommand1" runat="server" IsVisibleClear="True" IsVisibleDelete="False" IsVisibleFind="True" IsVisiblePrint="false" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>


</asp:Content>
