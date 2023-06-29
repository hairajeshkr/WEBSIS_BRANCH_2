function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {

   
    var TxtDocument = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlDocument');
    var TxtFile = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_FileUploadDoc_ClassId');
    var TxtFileN = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_HyLnkDoc_ClassId');

    if (isChildData(TxtDocument, 'Please select Valid Document.', TxtDocument) &&
        isChildData(TxtFile, 'Please Upload Document.', TxtFile)) {
        return true;
    }
    else {
        return false;
    }
}