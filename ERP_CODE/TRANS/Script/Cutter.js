function ValidateMasterData()  
{
    var DdlCutter = document.getElementById('ContentPlaceHolder1_DdlCutter');
    var TxtDueDate = document.getElementById('ContentPlaceHolder1_HdnWrkDueDate');
    var TxtCutDueDate = document.getElementById('ContentPlaceHolder1_CtrlDueDate_TxtDate');
    var HdnWrkStfId = document.getElementById('ContentPlaceHolder1_HdnWrkStfId');
    var HdnDueDate = document.getElementById('ContentPlaceHolder1_HdnDueDate');

    if (HdnWrkStfId.value != "0")
    {
        if (isListSelected(DdlCutter, 'Please select Valid Cutter.', DdlCutter, 0) &&
            !isEmpty(TxtCutDueDate, 'Please enter Cutting Due Date.', TxtCutDueDate) &&
            FnCompaireTwoDate(TxtCutDueDate, TxtDueDate, 'Please select Valid Cutting Due Date.Cutting Date must be less than or equal to Work due date'))
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
        if (isListSelected(DdlCutter, 'Please select Valid Cutter.', DdlCutter, 0) &&
            !isEmpty(TxtCutDueDate, 'Please enter Cutting Due Date.', TxtCutDueDate) &&
            FnCompaireTwoDate(TxtCutDueDate, HdnDueDate, 'Please select Valid Cutting Due Date.Cutting Date must be less than or equal to Due date')) {
            return true;
        }
        else {
            return false;
        }
    }
}