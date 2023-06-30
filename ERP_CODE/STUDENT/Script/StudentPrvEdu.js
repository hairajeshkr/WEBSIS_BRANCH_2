function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtEducation = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtEducation');
    var TxtYear = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtYear');
    var TxtInstitute = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtInstitute');
    var TxtPercentage = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtPercentage');
    var TxtRegNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtRegNo');
    var TxtBoard = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtBoard');
    var CtrlFrmDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlFrmDate_TxtDate');
    var CtrlToDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlToDate_TxtDate');

    
    //var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_ClassId');
    //var TxtClassName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_TxtCaption');
    //var TxtQuotaName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlQuota');


    if (!isEmpty(TxtEducation, 'Please enter Course Name.', TxtEducation) &&
        !isEmpty(TxtYear, 'Please enter Year.', TxtYear) &&
        !isEmpty(TxtInstitute, 'Please enter Institute.', TxtInstitute) &&
        !isEmpty(TxtPercentage, 'Please enter Percentage.', TxtPercentage) &&
        !isEmpty(TxtRegNo, 'Please enter Register No.', TxtRegNo) &&
        !isEmpty(TxtBoard, 'Please enter Board.', TxtBoard) &&
        IsValidateDate(CtrlFrmDate, 'Please enter From Date.') &&
        IsValidateDate(CtrlToDate, 'Please enter To Date.')) {
        return true;
    }
    else {
        return false;
    }
}