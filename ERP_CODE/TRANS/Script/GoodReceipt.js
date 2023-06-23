function ValidateChildData()  
{
    var TxtItemId = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_TxtCaption');

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
    document.getElementById('ContentPlaceHolder1_TxtQty').value = "";
    document.getElementById('ContentPlaceHolder1_TxtNoPieces').value = "";
    document.getElementById('ContentPlaceHolder1_TxtTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_TxtRate').value = "";
    document.getElementById('ContentPlaceHolder1_TxtMrp').value = "";
    document.getElementById('ContentPlaceHolder1_TxtSlRate').value = "";
    document.getElementById('ContentPlaceHolder1_HdnTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_HdnTotAmt').value = "";
}
function FnSetMrpVal()
{
    document.getElementById('ContentPlaceHolder1_TxtMrp').value = document.getElementById('ContentPlaceHolder1_TxtSlRate').value;
}