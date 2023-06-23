<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlSymbolAddCmnd.ascx.cs" Inherits="CtrlSymbolAddCmnd" %>
<style type="text/css">
    .auto-style1 {
        width: 10%;
    }
    .cmddstyleSymbol 
    {
        width: 100px; 
        height: 25px;
        padding-right: 3px;
    }
</style>
<script type="text/javascript">
    function FnAddScript(PrmQtyCtrl)
    {
        var dQty = FnIsNumeric(document.getElementById(PrmQtyCtrl).value) + 1;
        document.getElementById(PrmQtyCtrl).value = dQty;
    }
    function FnMinScript(PrmQtyCtrl)
    {
        var dQty = FnIsNumeric(document.getElementById(PrmQtyCtrl).value) - 1;
        document.getElementById(PrmQtyCtrl).value = dQty;
    }
</script>
<table border="0" cellpadding="0" cellspacing="0" style="height: 18px; width: 132px;">
    <tr>
<td class="cmddstyleSymbol">
<asp:TextBox runat="server" SkinID="TxtQtyCentre" ID="TxtNo" placeholder="No." Width="50px"></asp:TextBox>
</td>
        <td class="cmddstyleSymbol">
            <asp:Button ID="BtnAdd" runat="server" SkinID="BtnAddSub" Text="+" ToolTip="+" UseSubmitBehavior="false" CausesValidation="False" Height="30px" Width="30px" /></td>
        <td class="cmddstyleSymbol">
            <asp:Button ID="BtnClear" runat="server" SkinID="BtnAddSub" Text="-" ToolTip="-" UseSubmitBehavior="false"  CausesValidation="False" Height="30px" Width="30px" /></td>
    </tr>
</table>


