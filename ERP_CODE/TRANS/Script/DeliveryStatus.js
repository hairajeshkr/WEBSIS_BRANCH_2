function ValidateMasterData()  
{
    var DdlStaffName = document.getElementById('ContentPlaceHolder1_DdlStaffName');
    if (isListSelected(DdlStaffName, 'Please Select Valid Staff Name.', DdlStaffName, 0))
    {
        return true;
    }
    else
    {
        return false;
    }
}