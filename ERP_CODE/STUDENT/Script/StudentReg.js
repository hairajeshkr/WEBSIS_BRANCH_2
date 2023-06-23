function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtAdharNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAdharNo');
    var TxtStudentId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtStudentId');

    if (!isEmpty(TxtAdharNo, 'Please enter Adhar Number.', TxtAdharNo) &&
        !isEmpty(TxtStudentId, 'Please enter Student Id.', TxtStudentId)) {
        return true;
    }
    else {
        return false;
    }
}