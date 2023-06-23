function ValidateTrackingData()
{
    var HdnAutoId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlOrdeDetails1_HdnAutoId');
    var TxtDueDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlOrdeDetails1_TxtDueDate');
    var TxtWork = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlOrdeDetails1_TxtWork');

    var DdlWorker = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_DdlWorker');
    var TxtWrkDueDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlWrkDueDate_TxtDate');

    var DdlCutter = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_DdlCutter');
    var DdLRackNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_DdLRackNo');
    var TxtCutDueDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlCutDueDate_TxtDate');

    if (FnIsNumeric(HdnAutoId.value) > 0)
    {
        if (TxtWork.value == "WORK")// DdlWorker.selectedIndex != 0)
        {
            if (isListSelected(DdlWorker, 'Please select Valid Worker.', DdlWorker, 0) &&
                !isEmpty(TxtWrkDueDate, 'Please enter Work Due Date.', TxtWrkDueDate) &&
                FnCompaireTwoDate(TxtWrkDueDate, TxtDueDate, 'Please select Valid Work Due Date'))
            {
                if (isListSelected(DdlCutter, 'Please select Valid Cutter.', DdlCutter, 0) &&
                    !isEmpty(TxtCutDueDate, 'Please enter Cutting Due Date.', TxtCutDueDate) &&
                    FnCompaireTwoDate(TxtCutDueDate, TxtWrkDueDate, 'Please select Valid Cutting Due Date.Cutting Date must be less than or equal to work due date') &&
                    isListSelected(DdLRackNo, 'Please select Valid Rack No.', DdLRackNo, 0))
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
        else
        {
            if (isListSelected(DdlCutter, 'Please select Valid Cutter.', DdlCutter, 0) &&
                !isEmpty(TxtCutDueDate, 'Please enter Cutting Due Date.', TxtCutDueDate) &&
                FnCompaireTwoDate(TxtCutDueDate, TxtDueDate, 'Please select Valid Cutting Due Date') &&
                isListSelected(DdLRackNo, 'Please select Valid Rack No.', DdLRackNo, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    else
    {
        alert('Please Enter The Valid Order No.');
        return false;
    }
}