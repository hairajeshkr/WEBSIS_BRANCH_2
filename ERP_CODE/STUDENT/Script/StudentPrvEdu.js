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
    var TxtRegNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtRegNo');
    var TxtBoard = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtBoard');
    

    //var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_ClassId');
    //var TxtClassName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_TxtCaption');
    //var TxtQuotaName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlQuota');


    if (!isEmpty(TxtEducation, 'Please enter Course Name.', TxtEducation) &&
        !isEmpty(TxtYear, 'Please enter Year.', TxtYear) &&
        !isEmpty(TxtInstitute, 'Please enter Institute.', TxtInstitute) &&
        !isEmpty(TxtRegNo, 'Please enter Register No.', TxtRegNo) &&
        !isEmpty(TxtBoard, 'Please enter Register No.', TxtBoard) ) {
        return true;
    }
    else {
        return false;
    }
}