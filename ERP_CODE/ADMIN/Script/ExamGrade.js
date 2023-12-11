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
    var TxtRangeFrom = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRangeFrom');
    var TxtRangeTo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRangeTo');

    var DdlGradeSysId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_DdlGradeSystem');

    if (!isEmpty(TxtName, 'Please enter Name.', TxtName) &&
        !isEmpty(TxtCode, 'Please enter Code.', TxtCode) &&
        !isEmpty(TxtRangeFrom, 'Please enter Range From.', TxtRangeFrom) &&
        !isEmpty(TxtRangeTo, 'Please enter Range To', TxtRangeTo) &&
        isListSelected(DdlGradeSysId, 'Please select Grading system .', DdlGradeSysId, 0)) {
        return true;
    }
    else {
        return false;
    }
}