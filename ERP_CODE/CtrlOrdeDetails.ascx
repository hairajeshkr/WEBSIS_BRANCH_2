<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlOrdeDetails.ascx.cs" Inherits="CtrlOrdeDetails" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>
<table>
        <tr>
        <td><asp:Label runat="server" Text="ORDER NO" SkinID="LblIdentify" Width="100px" ID="Label7"></asp:Label>
        </td>
        <td><asp:TextBox runat="server" SkinID="TxtOrderNo" ID="TxtOrderNo" placeholder="ORDER NO"></asp:TextBox>
        </td>
        <td>
                  <asp:Button runat="server" CausesValidation="true" TabIndex="0" Text="FIND" SkinID="BtnCommandFindNew" Width="143px" ID="BtnPrdSrch" ></asp:Button>
                  </td>
        <td colspan="2">
                      <asp:Label runat="server" SkinID="LblRedBold" Width="360px" ID="LblError"></asp:Label>
                  </td>
        <td>
                  <table class="auto-style1">
                      <tr>
                          <td>
                  <asp:TextBox runat="server" SkinID="TxtDisable130" ID="TxtUnit" placeholder="UNIT"></asp:TextBox>
                          </td>
                          <td>
                  <asp:TextBox runat="server" SkinID="TxtDisableNew130" ID="TxtWork" placeholder=""></asp:TextBox>
                          </td>
                      </tr>
                  </table>
        </td>
    </tr>
        <tr>
        <td><asp:Label runat="server" Text="CUSTOMER" SkinID="LblBold" Width="100px" ID="Label9"></asp:Label>
        </td>
        <td><asp:TextBox runat="server" SkinID="Txt250Disable1" ID="TxtCustName" placeholder="CUSTOMER NAME"></asp:TextBox>
        </td>
        <td>
                  <asp:TextBox runat="server" SkinID="TxtCodeDisable1" ID="TxtCustCode" placeholder="CODE"></asp:TextBox>
                  </td>
        <td>
                      <asp:TextBox runat="server" SkinID="Txt250Disable1" ID="TxtCustAdd" placeholder="HOUSE NAME"></asp:TextBox>
                  </td>
        <td>
                  <asp:TextBox runat="server" SkinID="TxtCodeDisable2" ID="TxtDueDate" placeholder="DUE DATE"></asp:TextBox>
                  </td>
        <td><asp:TextBox runat="server" SkinID="Txt265Disable" ID="TxtFunction" placeholder="FUNCTION"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:TextBox runat="server" SkinID="Txt265Disable" ID="TxtDescription" placeholder="DESCRIPTION"></asp:TextBox>
        </td>
        <td><asp:TextBox runat="server" SkinID="TxtCodeDisable2" ID="TxtDesigner" placeholder="DESIGNER"></asp:TextBox>
        </td>
        <td><asp:TextBox runat="server" SkinID="Txt265Disable" ID="TxtFabType" placeholder="FABRICATION"></asp:TextBox>
        </td>
        <td><asp:TextBox runat="server" SkinID="TxtCodeDisable" ID="TxtPriority" placeholder="PRIORITY"></asp:TextBox>
        </td>
        <td><asp:TextBox runat="server" SkinID="Txt265Disable1" ID="TxtWrkStatus" placeholder="CURRENT STATUS"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td><asp:HiddenField runat="server" ID="HdnQcId" />
        </td>
        <td><asp:HiddenField runat="server" ID="HdnCurStatus" />
        </td>
        <td><asp:HiddenField runat="server" ID="HdnAutoId" />
        </td>
        <td><asp:HiddenField runat="server" ID="HdnTokenNo" />
        </td>
        <td><asp:HiddenField runat="server" ID="HdnUnitBranchId" />
        </td>
        <td><asp:HiddenField runat="server" ID="HdnWorkPlan" />
        </td>
    </tr>
</table>


