function ValidateMasterData() {

    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {

    var TxtClassId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_HdnId');
    var TxtClassName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAdmmisionClass_TxtCaption');

    var TxtQuotaId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdQuota_HdnId');
    var TxtQuotaName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdQuota_TxtCaption');

    var TxtRank = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtRank');

    if (isChildData(TxtClassId, 'Please select Valid Class.', TxtClassName) &&
        isChildData(TxtQuotaId, 'Please select Valid Quota.', TxtQuotaName) &&
        !isEmpty(TxtRank, 'Please enter Rank.', TxtRank))
    {
        return true;
    }
    else
    {
        return false;
    }
}