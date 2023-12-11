function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtName');
    var TxtCode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCode');

    var TxtExamId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdExam_HdnId');
    var TxtExamName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdExam_TxtCaption');

    if (!isEmpty(TxtName, 'Please enter Name.', TxtName) &&
        !isEmpty(TxtCode, 'Please enter Code.', TxtCode) &&
        isChildData(TxtExamId, 'Please select Valid Exam.', TxtExamName)){
        return true;
    }
    else {
        return false;
    }
}