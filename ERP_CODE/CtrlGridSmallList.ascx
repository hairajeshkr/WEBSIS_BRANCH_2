<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlGridSmallList.ascx.cs" Inherits="CtrlGridSmallList" %>
<link href="../StyleSheet/AutobindStyle.css" rel="stylesheet" type="text/css" />
<link href="../CSS/font-awesome.css" rel="stylesheet" type="text/css" />

<script language ="javascript" type="text/javascript" >
    function txtOnChange(DestCtrl, e) {
        var TxtSearch = document.getElementById(DestCtrl + "_TxtCaption").value;
        if (TxtSearch.length <= 0) {
            document.getElementById(DestCtrl + "_HdnId").value = 0;
        }
        var unicode = e.charCode ? e.charCode : e.keyCode;
        if ((unicode >= 112 && unicode <= 123) || (unicode >= 44 && unicode <= 46) || (unicode >= 33 && unicode <= 36) || (unicode >= 16 && unicode <= 20) || (unicode >= 144 && unicode <= 145) || (unicode == 91) || (unicode == 93))
        { return false; }
        if (unicode == 13 || unicode == 9) {
        }
        else if (unicode == 27) {
            document.getElementById(DestCtrl + "_HdnCount").value = '0';
            document.getElementById(DestCtrl + "_TABLE1").style.display = 'none';
        }
        else if ((unicode >= 65 && unicode <= 90) || (unicode >= 46 && unicode <= 59) || (unicode >= 96 && unicode <= 111) || (unicode >= 188 && unicode <= 192) || (unicode >= 219 && unicode <= 221) || (unicode >= 32 && unicode <= 36) || (unicode >= 8)) {
            if (document.getElementById(DestCtrl + "_HdnCount").value == 0) {
                toggleImgDiv(DestCtrl, e);
            }
            else {
                document.getElementById(DestCtrl + "_TABLE1").style.display = 'block';
                document.getElementById(DestCtrl + "_TABLE1").style.position = 'absolute';
                document.getElementById(DestCtrl + "_HdnCount").value = '1';
                WebServiceCall(1, DestCtrl);
            }
        }
        else {
            document.getElementById(DestCtrl + "_HdnCount").value = '0';
            document.getElementById(DestCtrl + "_TABLE1").style.display = 'none';
        }
        /*DestCtrlId=DestCtrl;
        var unicode=e.charCode? e.charCode : e.keyCode;
        var iCount=document.getElementById(DestCtrlId +"_HdnCount").value;
        document.getElementById(DestCtrlId +"_TABLE1").style.display='block';
        document.getElementById(DestCtrlId +"_TABLE1").style.position='absolute';
        document.getElementById(DestCtrlId +"_HdnCount").value='1'; 
        WebServiceCall(1);*/
    }
    function FnOnHide(DestCtrl) {
        document.getElementById(DestCtrl + "_HdnCount").value = '0';
        document.getElementById(DestCtrl + "_TABLE1").style.display = 'none';
    }
    function toggleImgDiv(DestCtrlId, e) {
        var unicode = e.charCode ? e.charCode : e.keyCode;
        if ((unicode >= 112 && unicode <= 123) || (unicode >= 44 && unicode <= 46) || (unicode >= 33 && unicode <= 36) || (unicode >= 16 && unicode <= 20) || (unicode >= 144 && unicode <= 145) || (unicode == 91) || (unicode == 93))
        { return false; }
        var iCount = document.getElementById(DestCtrlId + "_HdnCount").value;
        if (iCount == 0) {
            document.getElementById(DestCtrlId + "_TABLE1").style.display = 'block';
            document.getElementById(DestCtrlId + "_TABLE1").style.position = 'absolute';
            document.getElementById(DestCtrlId + "_HdnCount").value = '1';
        }
        else {
            document.getElementById(DestCtrlId + "_HdnCount").value = '0';
            document.getElementById(DestCtrlId + "_TABLE1").style.display = 'none';
        }
        WebServiceCall(1, DestCtrlId);
    }
    function WebServiceCall(pageNo, DestCtrlId) {
        var TxtSearch = document.getElementById(DestCtrlId + "_TxtCaption");
        var hdnAcType = document.getElementById(DestCtrlId + "_HiddenAccType");
        var hdnRowCcunt = document.getElementById(DestCtrlId + "_hdnGridRowCount");

        var HdnFlag = document.getElementById(DestCtrlId + "_HdnFlag").value;
        var HdnCmpId = document.getElementById(DestCtrlId + "_HdnCmpId").value;
        var HdnBrId = document.getElementById(DestCtrlId + "_HdnBrId").value;
        var HdnFaId = document.getElementById(DestCtrlId + "_HdnFaId").value;
        var HdnUsrId = document.getElementById(DestCtrlId + "_HdnUserId").value;
        var HdnParent = document.getElementById(DestCtrlId + "_HdnParent").value;
        var HdnSubParent = document.getElementById(DestCtrlId + "_HdnSubParent").value;
        var HdnDestCtrl = document.getElementById(DestCtrlId + "_HdnDestCtrl").value;
        if (HdnParent.length > 0) {
            HdnParent = document.getElementById(HdnParent).value;
        }
        if (HdnSubParent.length > 0) {
            HdnSubParent = document.getElementById(HdnSubParent).value;
        }
        Web_GridSelection.PopulateGrid(HdnFlag, HdnCmpId, HdnBrId, HdnFaId, HdnUsrId, TxtSearch.value, DestCtrlId, HdnParent, HdnSubParent, hdnRowCcunt.value, pageNo, HdnDestCtrl, Callback);
        if (TxtSearch.value.length <= 0) {
            document.getElementById(DestCtrlId + "_HdnId").value = "0";
            document.getElementById(DestCtrlId + "_TxtCaption").value = "";
        }
    }
    function Callback(result) {
        if (result[0].length > 110) {
            ParseData(result[0], result[1]);
        }
        else {
            document.getElementById(result[1] + "_HdnId").value = "";
            document.getElementById(result[1] + "_HdnCount").value = '0';
            document.getElementById(result[1] + "_TABLE1").style.display = 'none';
        }
    }
    function ParseData(xml, DestCtrlId) {
        var xmlDoc;
        if (window.DOMParser) {
            var parser = new DOMParser();
            xmlDoc = parser.parseFromString(xml, "text/xml");
        }
        else // Internet Explorer
        {
            xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            xmlDoc.async = "false";
            xmlDoc.loadXML(xml);
        }
        var Pager = xmlDoc.getElementsByTagName('PAGER')[0];
        var Grid = xmlDoc.getElementsByTagName('GRID')[0];

        document.getElementById(DestCtrlId + "_dvContent").innerHTML = GetNodeData(Grid);
        document.getElementById(DestCtrlId + "_dvPager").innerHTML = GetNodeData(Pager);
    }
    function GetNodeData(node) {
        return (node.textContent || node.innerText || node.text);
    }
    //=============================================================================== Data Bind
    function FnGetSelectedGeneralListValue(strCtrl, strId, strVal) {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;
        FnClearValues();
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
    function FnGetSelectedAccountListValue(strCtrl, strId, strVal, strAddress, strBalance, strDestCtrl) {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;

        var strDest = strDestCtrl.split(",");

        document.getElementById(strDest[0]).value = strAddress;
        if (strDest.length == 2) {
            document.getElementById(strDest[1]).value = strBalance;
        }
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
    function FnGetSelectedEnqCustListValue(strCtrl, strId, strVal, strAddress, strMobNo, strEmail, strDestCtrl) {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;

        var strDest = strDestCtrl.split(",");

        document.getElementById(strDest[0]).value = strAddress;
        if (strDest.length == 2) {
            document.getElementById(strDest[1]).value = strMobNo;
        }
        if (strDest.length == 3) {
            document.getElementById(strDest[1]).value = strMobNo;
            document.getElementById(strDest[2]).value = strEmail;
        }
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
    function FnGetSelecteItemListValue(strCtrl, strId, strVal, strUomId, strUom, strTaxId, strTax, strRate, strMrp, strDestCtrl) {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;

        var strDest = strDestCtrl.split(",");
        document.getElementById(strDest[0]).value = strUomId;
        document.getElementById(strDest[1]).value = strUom;
        if (strDest.length >= 3) {
            document.getElementById(strDest[2]).value = strTaxId;
            document.getElementById(strDest[3]).value = strTax;
        }
        if (strDest.length >= 5) {
            document.getElementById(strDest[4]).value = strRate;
        }
        if (strDest.length >= 6) {
            document.getElementById(strDest[5]).value = strMrp;
        }
        FnClearValues();
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
    function FnGetSelectedContactCustListValue(strCtrl, strId, strVal, strAddress, strMobNo, strEmail, strDepartmentId, strDeprtment, strDestCtrl)
    {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;

        var strDest = strDestCtrl.split(",");
        document.getElementById(strDest[0]).value = strAddress;
        if (strDest.length == 2) {
            document.getElementById(strDest[1]).value = strMobNo;
        }
        if (strDest.length == 3) {
            document.getElementById(strDest[1]).value = strMobNo;
            document.getElementById(strDest[2]).value = strEmail;
        }
        if (strDest.length == 5) {
            document.getElementById(strDest[1]).value = strMobNo;
            document.getElementById(strDest[2]).value = strEmail;
            document.getElementById(strDest[3]).value = strDepartmentId;
            document.getElementById(strDest[4]).value = strDeprtment;
        }
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
    function FnGetSelectedpurchaseBillNoListValue(strCtrl, strId, strVal, strDate, strDestCtrl)
    {
        document.getElementById(strCtrl + "_TxtCaption").value = strVal;
        document.getElementById(strCtrl + "_TABLE1").style.display = 'none';
        document.getElementById(strCtrl + "_HdnCount").value = '0';
        document.getElementById(strCtrl + "_HdnId").value = strId;

        document.getElementById(strDestCtrl).value = strDate;
        document.getElementById(strCtrl + "_TxtCaption").focus();
    }
  </script> 
<table border="0" cellpadding="0" cellspacing="0" style="border-color: black; border-width: 1px; width:0%; position: static;">
    <tr>
        <td style="vertical-align:middle;">
            <asp:TextBox ID="TxtCaption" runat="server" Style="position: static" Width="120px" CssClass="textbox_field_style"></asp:TextBox></td>
        <td style="width: 100px">
            <div class="dropdown-srch" id="DivLst" runat="server"><i class="fa fa-angle-down"></i></div>
            <!-- <img src="Images/Arrow.bmp" id="ImgLst" runat="server" height="20" width="18" alt="" /> --></td>
    </tr>
    </table>
<table id="TABLE1" runat="server" border="0" cellpadding="0" cellspacing="0" class="TblGrdStyle" enableviewstate="false" visible="false">
    <tr>
        <td colspan="3" style="background-color: gainsboro; height: 95%;" valign="top">
            <div id="devGridList" runat="server" enableviewstate="true" style="height:300px">
                <div id="dvContent" runat="server" enableviewstate="true">
                    <table id="tblContent" border="0" cellpadding="0" cellspacing="0" style="width: 130px">
                        <tr class="rowstyle">
                            <td></td>
                        </tr>
                        <tr class="alternatingrowstyle">
                            <td></td>
                        </tr>
                        <tr class="rowstyle">
                            <td></td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="HdnCount" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenAccType" runat="server" Value="0" />
                <asp:HiddenField ID="HdnId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnGridRowCount" runat="server" Value="0" />
                <asp:HiddenField ID="HdnCmpId" runat="server" Value="0" />
                <asp:HiddenField ID="HdnBrId" runat="server" Value="0" />
                <asp:HiddenField ID="HdnFaId" runat="server" Value="0" />
                <asp:HiddenField ID="HdnFlag" runat="server" Value="ACC" />
                <asp:HiddenField ID="HdnParent" runat="server" Value="" />
                <asp:HiddenField ID="HdnIsCurrency" runat="server" Value="false" />
                <asp:HiddenField ID="HdnUserId" runat="server" />
                <asp:HiddenField ID="HdnDestCtrl" runat="server" />
                <asp:HiddenField ID="HdnSubParent" runat="server"/>
            </div>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="3" style="height: 15px; background-color: #f1f1f1;" valign="middle">
            <div id="dvPager" runat="server" style="width: 100%; position: static; text-align: center; color: #ff3300;">
            </div>
        </td>
    </tr>
</table>