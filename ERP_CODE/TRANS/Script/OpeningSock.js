function ValidateImportData() {
    var DdlFaYear = document.getElementById('ContentPlaceHolder1_DdlFaId');

    if (isListSelected(DdlFaYear, 'Please select financial year.', DdlFaYear, 0)) {
        resp = window.confirm('Be careful all your existing Opening Stock for the year will be deleted and the closing stock from the year you specify will be carried fowarded.');
        if (resp == true) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}
function ValidateChildData()
{
    var TxtBatchNoId = document.getElementById('ContentPlaceHolder1_CtrlGrdBatchNo_HdnId');
    var TxtBatchNo = document.getElementById('ContentPlaceHolder1_CtrlGrdBatchNo_TxtCaption');

    var TxtItemId = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_TxtCaption');

    var TxtItmGrpId = document.getElementById('ContentPlaceHolder1_CtrlGrdItmGrp_HdnId');
    var TxtItmGrp = document.getElementById('ContentPlaceHolder1_CtrlGrdItmGrp_TxtCaption');

    var TxtAccId = document.getElementById('ContentPlaceHolder1_CtrlGrdSupplier_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_CtrlGrdSupplier_TxtCaption');

    var TxtBillNo = document.getElementById('ContentPlaceHolder1_TxtBillNo');
    var TxtBillDate = document.getElementById('ContentPlaceHolder1_CtrlBillDate_TxtDate');
    var TxtQty = document.getElementById('ContentPlaceHolder1_TxtQty');
    var TxtPuRate = document.getElementById('ContentPlaceHolder1_TxtPuRate');
    var TxtSlRate = document.getElementById('ContentPlaceHolder1_TxtSlRate');

    if (isChildData(TxtBatchNoId, 'Please Select Valid Item BarCode .', TxtBatchNo) && 
        isChildData(TxtItemId, 'Please Select Valid Item Name .', TxtItem) &&
        isChildData(TxtItmGrpId, 'Please Select Valid Item Group Name .', TxtItmGrp) &&
        isChildData(TxtAccId, 'Please Select Valid Supplier Name .', TxtAcc) && 
        !isEmpty(TxtBillNo, 'Please enter Bill No.', TxtBillNo) &&
        !isEmpty(TxtBillDate, 'Please enter Bill Date.', TxtBillDate) &&
        !isEmpty(TxtQty, 'Please enter Qty', TxtQty) &&
        !isEmpty(TxtPuRate, 'Please enter the purchase rate', TxtPuRate) &&
        !isEmpty(TxtSlRate, 'Please enter sale rate', TxtSlRate) &&
        isGreaterThanVlaue(TxtPuRate, TxtSlRate, 'Sale Rate Must Be Greate Than Or Equal Purchase Rate'))
    {
        return true;
    }
    else {
        return false;
    }
}