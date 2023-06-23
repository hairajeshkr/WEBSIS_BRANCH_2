<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlYesNo.ascx.cs" Inherits="CtrlYesNo" %>
<style type="text/css">
    .auto-style1 {
        width: 10%;
    }
    .cmddstyleYesNO 
    {
        width: 100px; 
        height: 25px;
        padding-right: 3px;
    }
</style>
<script type="text/javascript">
    function FnGetRadBtnSelectedValue(PrmCtrlId,PrmCtrlVal)
    {
        var radio = document.getElementById(PrmCtrlId);
        var inputs = radio.getElementsByTagName('input');
        for (var i = 0; i < inputs.length; i++) {

            if (inputs[i].checked)
            {
                if (inputs[i].value == "YES") {
                    document.getElementById(PrmCtrlVal).disabled = false;
                    document.getElementById(PrmCtrlVal).value = "";
                    document.getElementById(PrmCtrlVal).focus();
                }
                else
                {
                    document.getElementById(PrmCtrlVal).disabled = true;
                    document.getElementById(PrmCtrlVal).value = "";
                }
            }
        }
    }
</script>
<table border="0" cellpadding="0" cellspacing="0" style="height: 18px; width: 132px;">
    <tr>
<td class="cmddstyleYesNO ">
<asp:RadioButtonList ID="RadBtnLst" runat="server" Height="27px" RepeatDirection="Horizontal" Width="105px" SkinID="RadBtn1" onclick="GetRDBValue();">
    <asp:ListItem Selected="True">NO</asp:ListItem>
    <asp:ListItem>YES</asp:ListItem>
</asp:RadioButtonList>
</td>
 <td class="cmddstyleYesNO ">
    <asp:TextBox runat="server" SkinID="Txt50Centre" ID="TxtNo" Width="50px"></asp:TextBox>
    </tr>
</table>

