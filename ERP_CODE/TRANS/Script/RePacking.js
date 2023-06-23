function ValidateMasterData()  
{
   
    var TxtRefNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlRewindEvent1_TxtReffNo');
    var TxtTrDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTrDate_TxtDate');
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_TxtCaption');
    var TxtRemarks = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRemarks');

    if (!isEmpty(TxtRefNo, 'Please enter Reference No.', TxtRefNo) &&
        !isEmpty(TxtTrDate, 'Please enter Transaction Date.', TxtTrDate) && FnCheckFaYearTrDate(TxtTrDate) &&
        isChildData(TxtAccId, 'Please select Valid Staff Name', TxtAcc) &&
        !isEmpty(TxtRemarks, 'Please enter the remarks.', TxtRemarks))
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
    var TxtBatchNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdBatchNo_TxtCaption');

    var TxtUomId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlUom_HdnId');
    var TxtTaxId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTax_HdnId'); 

    if (!isEmpty(TxtBatchNo, 'Please enter the Batch No.', TxtBatchNo) &&
       isChildData(TxtItemId, 'Please select Valid Item.', TxtItem) &&
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
function ValidateChildDataNew()
{
    var TxtItemId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemNameTo_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemNameTo_TxtCaption');
    var TxtUomId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlUomTo_HdnId');
    var TxtTaxId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTaxTo_HdnId');
    var TxtBarCode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtBarCode');

    if (isChildData(TxtItemId, 'Please select Valid Item.', TxtItem) &&
       isChildData(TxtUomId, 'Please select Valid Uom.', TxtItem) &&
       isChildData(TxtUomId, 'Please select Valid Tax %.', TxtItem) && 
       !isEmpty(TxtBarCode, 'Please enter the Batch No.', TxtBarCode))
    {
        return true;
    }
    else {
        return false;
    }
}

function FnClearValues()
{
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtQty').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnFrmTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnFrmAmt').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnFrmTotalAmt').value = "";

    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtToQty').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnToTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnToAmt').value = "";
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_HdnToTotalAmt').value = "";
}
