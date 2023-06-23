function ValidateTrackingData()
{
    var HdnAutoId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlOrdeDetails1_HdnAutoId');
    var DdlCurStatus = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_DdlCurStatus');
    var DdlStaff = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_DdlStaff');
    if (FnIsNumeric(HdnAutoId.value) > 0)
    {
        if (isListSelected(DdlCurStatus, 'Please select Assign To.', DdlCurStatus, 0) &&
            isListSelected(DdlStaff, 'Please select Valid Staff.', DdlStaff, 0))
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
        return false;
    }
}
/*============================= DropdownList Box Binding ============================*/
function FnDropdownListBindScript_Staff(PrmCompanyId, PrmBranchId, PrmCurStatusCtrl,PrmStaffCtrl)
{
    var DdlCurStatus = document.getElementById(PrmCurStatusCtrl).value;
    Web_GetResultService.FnGetStaffList_DropDownList(PrmCompanyId, PrmBranchId, DdlCurStatus, ValDropDownSuccess, ValFailed, PrmStaffCtrl);
}