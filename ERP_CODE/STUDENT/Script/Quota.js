function ValidateMasterData()  
{
    if(ValidateAdd()==true)
    {
        return true;
    }
    else
    {
        return false;
    }
}
function ValidateAdd()  
{
    var TxtName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtName');
    var TxtCode = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCode');

    if(!isEmpty(TxtName,'Please enter Name.',TxtName) && 
        !isEmpty(TxtCode,'Please enter Code.',TxtCode))  
    {
        return true;
    }
    else
    {
        return false;
    }
}