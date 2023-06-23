function ValidateImportData() {
    var DdlFaYear = document.getElementById('ContentPlaceHolder1_DdlFaId');

    if (isListSelected(DdlFaYear, 'Please select financial year.', DdlFaYear, 0)) {
        resp = window.confirm('Be careful all your existing Opening Balance for the year will be deleted and the closing Balance from the year you specify will be carried fowarded.');
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
function ValidateChildData() {
    var TxtAccId = document.getElementById('ContentPlaceHolder1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_CtrlGrdAcc_TxtCaption');

    if (isChildData(TxtAccId, 'Please select Valid Accounr .', TxtAcc)) {
        return true;
    }
    else {
        return false;
    }
}