function ValidateMasterData()  
{
    var DdlTrialStaff = document.getElementById('ContentPlaceHolder1_DdlTrialStaff');
    /*var DdlAltrMode = document.getElementById('ContentPlaceHolder1_DdlAltrMode');*/
    if (isListSelected(DdlTrialStaff, 'Please Select Valid Trial Staff', DdlTrialStaff, 0))/* &&
        isListSelected(DdlAltrMode, 'Please Select Valid Alteration Mode Status', DdlAltrMode, 0))*/
    {
        return true;
    }
    else
    {
        return false;
    }
}