function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtRank = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtRank');

    var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_ClassId');
    var TxtClassName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_TxtCaption');
    var TxtQuotaName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlQuota');
   

    if (!isEmpty(TxtRank, 'Please enter Rank.', TxtRank) &&
        isChildData(TxtClassName, 'Please select Valid Class.', TxtClassName) &&
        isChildData(TxtQuotaName, 'Please select Valid Quota.', TxtQuotaName) ) {
        return true;
    }
    else {
        return false;
    }
}