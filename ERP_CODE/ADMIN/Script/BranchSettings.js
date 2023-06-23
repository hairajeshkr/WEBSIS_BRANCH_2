
function ValidateMasterData()  
{
    var DdlUsrGrp = document.getElementById('ContentPlaceHolder1_DdlUsrGrp');
    
    if(isListSelected(DdlUsrGrp,'Please select valid user .',DdlUsrGrp,0))
        {
            return true;
        }
        else
        {
            return false;
        }
}