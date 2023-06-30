function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    
    //var TxtPriority = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtCode');
    var DdlHobbie = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlHobbie');

    if (isListSelected(DdlHobbie, 'Please select Valid Hobbie.', DdlHobbie, 0)   ) {
        return true;
    }
    else {
        return false;
    }
}