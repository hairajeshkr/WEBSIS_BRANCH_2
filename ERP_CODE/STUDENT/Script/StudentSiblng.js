function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {

    var DdlRelationship = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlRelationship');
    var SibId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdName_HdnId');
    var SiblingName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdName_TxtCaption');

    if (isChildData(SibId, 'Please select Valid student Name.', SiblingName) &&
        isListSelected(DdlRelationship, 'Please select relationship.', DdlRelationship, 0)) {
        return true;
    }
    else {
        return false;
    }
}