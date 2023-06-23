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
    var TxtFrmDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlFrmDate_TxtDate');
    var TxtToDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlToDate_TxtDate');

    if(!isEmpty(TxtName,'Please enter Financial Year Name.',TxtName) && 
        !isEmpty(TxtCode,'Please enter Code.',TxtCode) && 
        !isEmpty(TxtFrmDate,'Please enter From Date.',TxtFrmDate) &&
        !isEmpty(TxtToDate,'Please enter To Date.',TxtToDate))  
    {
        return true;
    }
    else
    {
        return false;
    }
}