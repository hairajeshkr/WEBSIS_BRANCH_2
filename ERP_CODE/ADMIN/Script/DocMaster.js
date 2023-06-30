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
    var TxtPriority = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPriority');
    var Txtcode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCode');
    var ChkDtype = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkDtype');


    if (!isEmpty(TxtName, 'Please enter Name.', TxtName) &&
        !isEmpty(Txtcode, 'Please enter Code.', Txtcode) &&
        !isEmpty(TxtPriority, 'Please enter Priority.', TxtPriority) &&
        GetChkRadValue(ChkDtype, 'Please select document type', ChkDtype)) {
       
        return true;
    }
    else {
        return false;
    }
}