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
    //var chkdoctype = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkDtype');


    if (!isEmpty(TxtName, 'Please enter Name.', TxtName) &&
        !isEmpty(TxtPriority, 'Please enter Priority.', TxtPriority) &&
        !isEmpty(Txtcode, 'Please enter Code.', Txtcode)) { 
       // !isEmpty(chkdoctype, 'Please select document type', chkdoctype)
        return true;
    }
    else {
        return false;
    }
}