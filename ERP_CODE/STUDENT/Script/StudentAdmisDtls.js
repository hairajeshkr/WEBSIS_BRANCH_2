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

    var TxtClassId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_HdnId');
    var TxtClassName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_TxtCaption');
    var DdlQuota = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlQuota');

    if (!isEmpty(TxtRank, 'Please enter Rank.', TxtRank) &&
        isChildData(TxtClassId, 'Please select Valid Class.', TxtClassName) &&
        isListSelected(DdlQuota, 'Please select Valid Quota.', DdlQuota, 0) ) {
        return true;
    }
    else {
        return false;
    }
}