function ValidateMasterData()  
{
   /* var HdnAutoId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlOrdeDetails1_HdnAutoId');*/
    var DdLRackNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdLRackNo');
    if (isListSelected(DdLRackNo, 'Please Select Valid Rack', DdLRackNo, 0))
    {
        return true;
    }
    else
    {
        return false;
    }
}