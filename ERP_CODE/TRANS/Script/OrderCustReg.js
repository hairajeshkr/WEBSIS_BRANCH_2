function ValidateMasterData()  
{
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd()  
{
    var TxtName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdName_TxtCaption');
    var TxtMobNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdMobNo_TxtCaption');
    var TxtHouseName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdHouseName_TxtCaption');

    var TxtCustTypeId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustType_HdnId');
    var TxtCustType = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustType_TxtCaption');

    if (!isEmpty(TxtMobNo, 'Please enter Mobile No.', TxtMobNo) &&
        !isEmpty(TxtName, 'Please enter Name.', TxtName) &&
        isChildData(TxtCustTypeId, 'Please select Customer Type', TxtCustType) &&
        !isEmpty(TxtHouseName, 'Please enter House Name', TxtHouseName))
    {
        return true;
    }
    else
    {
        return false;
    }
}