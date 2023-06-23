function ValidateMasterData()  
{
    var DdlCutter = document.getElementById('ContentPlaceHolder1_DdlCutter');
    var TxtDueDate = document.getElementById('ContentPlaceHolder1_HdnDueDate');
    var TxtCutDueDate = document.getElementById('ContentPlaceHolder1_CtrlDueDate_TxtDate');

    if (isListSelected(DdlCutter, 'Please select Valid Cutter.', DdlCutter, 0) &&
        !isEmpty(TxtCutDueDate, 'Please enter Cutting Due Date.', TxtCutDueDate) &&
        FnCompaireTwoDate(TxtCutDueDate, TxtDueDate, 'Please select Valid Work Due Date.Work Date must be less than or equal to Due date'))
    {
        return true;
    }
    else
    {
        return false;
    }
}