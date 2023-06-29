function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    
    var TxtPriority = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtCode');
    var TxtHobbie = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlHobbie');
   

    if (isChildData(TxtHobbie, 'Please select Valid Hobbie.', TxtHobbie)&&
        !isEmpty(TxtPriority, 'Please enter Priority.', TxtPriority)    ) {
        return true;
    }
    else {
        return false;
    }
}