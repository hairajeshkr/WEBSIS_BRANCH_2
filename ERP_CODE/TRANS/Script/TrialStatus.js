function ValidateMasterData()  
{
    var DdlTrialStatus = document.getElementById('ContentPlaceHolder1_DdlTrialStatus');
    /*var DdlStaffName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_DdlStaffName');*/
    if (isListSelected(DdlTrialStatus, 'Please Select Valid Trial Status.', DdlTrialStatus, 0))
    {
        return true;
    }
    else
    {
        return false;
    }
}