function ValidateChildData()  
{
    var TxtItemId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemBarCode_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdItemBarCode_TxtCaption');

    if(isChildData(TxtItemId,'Please select Valid Item.',TxtItem))
    {
        return true;
    }
    else
    {
        return false;
    }
}
function FnClearValues()
{
   /* document.getElementById('ContentPlaceHolder1_TxtRate').value = "";
    document.getElementById('ContentPlaceHolder1_TxtMrp').value = "";
    document.getElementById('ContentPlaceHolder1_TxtSlRate').value = "";*/
}
function FnSetMrpVal()
{
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtMrp').value = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtSlRate').value;
}