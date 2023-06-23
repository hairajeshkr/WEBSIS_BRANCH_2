function ValidateMasterData()  
{
    var DdlBranch = document.getElementById('DdlBranch');
    var DdlFYear = document.getElementById('DdlFYear');

    if(isListSelected(DdlBranch,'Please select branch.',DdlBranch,0) && 
            isListSelected(DdlFYear,'Please select financial year.',DdlFYear,0))
        {
            return true;
        }
        else
        {
            return false;
        }
}