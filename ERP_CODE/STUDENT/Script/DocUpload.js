function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {

   
    //var TxtDocument = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlDocument');
    //var TxtFile = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_FileUploadDoc_ClassId');
    var DdlDocument = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlDocument');

    if (isListSelected(DdlDocument, 'Please select Valid Document.', DdlDocument, 0) &&
        isChildData(TxtFile, 'Please Upload Document.', TxtFile)) {
        return true;
    }
    else {
        return false;
    }
}