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
    var TxtPwd = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPwd');

    var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdUserGroup_HdnId');
    var TxtGrpName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdUserGroup_TxtCaption');

    if (!isEmpty(TxtName, 'Please enter User Name.', TxtName) &&
        !isEmpty(TxtCode, 'Please enter Code.', TxtCode) &&
        !isEmpty(TxtPwd, 'Please enter Password.', TxtPwd) && FnCheckPassword(TxtPwd) &&
        isChildData(TxtGrpId, 'Please select Valid User Group.', TxtGrpName)) {
        return true;
    }
    else {
        return false;
    }
}
function FnCheckPassword(inputtxt) {
    var paswd = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,15}$/;
    if (inputtxt.value.match(paswd)) {
        return true;
    }
    else {
        alert('To check a password between 7 to 15 characters which contain at least one numeric digit ,one upper case ,one Lower case and a special character')
        inputtxt.focus();
        inputtxt.select();
        return false;
    }
}
/*

/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,15}$/

*/