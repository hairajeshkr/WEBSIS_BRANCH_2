function ValidateMasterData()  
{
   
    var TxtRefNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlRewindEvent1_TxtReffNo');
    var TxtTrDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTrDate_TxtDate');
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_TxtCaption');
    var TxtPuId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdPuAcc_HdnId');
    var TxtPuAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdPuAcc_TxtCaption');
    var TxtOptionalNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtOptionalNo');
    var TxtOptDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlOptDate_TxtDate');

    if (!isEmpty(TxtRefNo, 'Please enter Reference No.', TxtRefNo) &&
        !isEmpty(TxtTrDate, 'Please enter Transaction Date.', TxtTrDate) && FnCheckFaYearTrDate(TxtTrDate) &&
         isChildData(TxtAccId, 'Please select Valid Supplier', TxtAcc) &&         
         !isEmpty(TxtOptDate, 'Please Enter the Bill Date', TxtOptDate) &&
         !isEmpty(TxtOptionalNo, 'Please Enter the Bill No.', TxtOptionalNo) &&
         isChildData(TxtPuId, 'Please select Valid Purchase Account', TxtPuAcc))
    {
        if (window.confirm('Do you want to save/update this record.') == true)
        {
            /*resp = window.confirm('Do you want to print this record.');
            document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ctl03_HdnCnfrm').value = resp;*/
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
}
function ValidateChildData()  
{
    var TxtItemId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemName_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemName_TxtCaption');
    var TxtUomId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlUom_HdnId');
    var TxtTaxId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTax_HdnId'); 
    var TxtItmBarCode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtItmBarCode');
    var TxtRate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRate');
    var TxtSlRate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtSlRate');

    if (isChildData(TxtItemId, 'Please select Valid Item.', TxtItem) &&
       isChildData(TxtUomId, 'Please select Valid Uom.', TxtItem) && 
       isChildData(TxtUomId, 'Please select Valid Tax %.', TxtItem) &&
       isChildData(TxtSlRate, 'Please enter the sale rate', TxtSlRate) &&
       isGreaterThanVlaue(TxtRate,TxtSlRate,'Sale Rate Must Be Greate Than Or Equal Purchase Rate') &&
       !isEmpty(TxtItmBarCode, 'Please enter the Barcode.', TxtItmBarCode))
    {
        return true;
    }
    else
    {
        return false;
    }
}
function FnCalculateGrandTotal()
{
    var dTotal = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtTotal').value);
    var dTotalTax = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtTotalTax').value);
    var dRoundOff = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRoundOff').value);
    var dDiscVal = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtDiscVal').value);
    var dTcsAmt = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtTcsAmt').value);

    var dGrandTotal = roundNumber(dTotal + dTotalTax + dRoundOff + dTcsAmt - dDiscVal, 2);
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtGrandTotal').value = dGrandTotal;
}
function FnClearValues()
{
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtQty').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtDisc').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAmt').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtTotalAmt').value = "";
}
function GridChkSelectAll() {
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0) {
        for (i = 0; i < grid.rows.length - 1; i++) {
            document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ChkSelect').checked;
        }
    }
}
function ValidateGenerateData() {
    var TxtTrDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlInvDate_TxtDate');
    if (!isEmpty(TxtTrDate, 'Please enter invoice Date.', TxtTrDate) && FnCheckFaYearTrDate(TxtTrDate)) {
        return true;
    }
    else {
        return false;
    }
}
/*isListSelected(DdlBookSerial,'Please select Bill Book Serial Code.',DdlBookSerial,0) && 
!isEmpty(TxtBookNo,'Please enter Book Number.',TxtBookNo) &&  */