function ValidateMasterData()  
{
    if(ValidateAdd()==true)
    {
        return true;
    }
    else
    {
        return false;
    }
}
function ValidateAdd()  
{
    var TxtName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtName');
    var TxtCode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCode');
    var TxtGrpId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdGrpList_HdnId');
    var TxtGrpName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdGrpList_TxtCaption');

    if(!isEmpty(TxtName,'Please enter Name.',TxtName) && 
        !isEmpty(TxtCode,'Please enter Code.',TxtCode) &&
        isChildData(TxtGrpId, 'Please Select Valid Alteration Type', TxtGrpName))
    {
        return true;
    }
    else
    {
        return false;
    }
}