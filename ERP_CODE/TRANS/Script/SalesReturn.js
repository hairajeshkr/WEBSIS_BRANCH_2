function ValidateMasterData()  
{
   
    var TxtRefNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlRewindEvent1_TxtReffNo');
    var TxtTrDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTrDate_TxtDate');
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_TxtCaption');
    var TxtPuId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdSlAcc_HdnId');
    var TxtPuAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdSlAcc_TxtCaption');

    if (!isEmpty(TxtRefNo, 'Please enter Reference No.', TxtRefNo) &&
        !isEmpty(TxtTrDate, 'Please enter Transaction Date.', TxtTrDate) && FnCheckFaYearTrDate(TxtTrDate) &&
         isChildData(TxtAccId, 'Please select Valid Customer', TxtAcc) &&
         isChildData(TxtPuId, 'Please select Valid Sales Account', TxtPuAcc))
    {
        resp=window.confirm('Do you want to print this record.');
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ctl03_HdnCnfrm').value = resp;
        return true;
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

    if(isChildData(TxtItemId,'Please select Valid Item.',TxtItem) && 
       isChildData(TxtUomId, 'Please select Valid Uom.', TxtItem) && 
       isChildData(TxtUomId, 'Please select Valid Tax %.', TxtItem))
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
    var dRoundOff = FnIsNumeric(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRoundOff').value);
    var dGrandTotal = roundNumber(dTotal + dRoundOff, 2);
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

/*isListSelected(DdlBookSerial,'Please select Bill Book Serial Code.',DdlBookSerial,0) && 
!isEmpty(TxtBookNo,'Please enter Book Number.',TxtBookNo) &&*/