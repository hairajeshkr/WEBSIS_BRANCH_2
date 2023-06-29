function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
   
    //var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdUserGroup_HdnId');
    var SibName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdName_TxtCaption');
    var Relashp = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ddlRelationship');

    if (isChildData(Relashp, 'please select a valid relationship', Relashp)&&
        isChildData(SibName, 'Please select Valid student Name.', SibName)) {
        return true;
    }
    else {
        return false;
    }
}
