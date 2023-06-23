function ValidateMasterData()  
{
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_TxtCaption');
    if (isChildData(TxtAccId, 'Please select Valid Account', TxtAcc))
    {
        return true;
    }
    else
    {
        return false;
    }
}