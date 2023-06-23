function ValidateMasterData()  
{
    var HdnAutoId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlOrdeDetails1_HdnAutoId');
    var HdnWorkPlan = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlOrdeDetails1_HdnWorkPlan');

    var DdLRackNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdLRackNo');
    if (FnIsNumeric(HdnAutoId.value) > 0)
    {
        if (FnIsNumeric(HdnWorkPlan.value) > 0)
        {
            if (isListSelected(DdLRackNo, 'Please Select Valid Rack', DdLRackNo, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            alert("PLEASE SET WORK PLAN FIRST .THEN USE STORE ROOM ");
            return false;
        }
    }
    else
    {
        return false;
    }
}