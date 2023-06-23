function ValidateChildData()  
{
    var TxtItemId = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_HdnId');
    var TxtItem = document.getElementById('ContentPlaceHolder1_CtrlGrdItemName_TxtCaption');
    var TxtUomId = document.getElementById('ContentPlaceHolder1_CtrlUom_HdnId');
    var TxtTaxId = document.getElementById('ContentPlaceHolder1_CtrlTax_HdnId'); 

    if(isChildData(TxtItemId,'Please select Valid Item.',TxtItem) && 
       isChildData(TxtUomId, 'Please select Valid Uom.', TxtItem) && 
       isChildData(TxtUomId, 'Please select Valid Tax %.', TxtItem))
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
    document.getElementById('ContentPlaceHolder1_TxtDisc').value = "";
    document.getElementById('ContentPlaceHolder1_TxtTaxValue').value = "";
    document.getElementById('ContentPlaceHolder1_TxtAmt').value = "";
    document.getElementById('ContentPlaceHolder1_TxtTotalAmt').value = "";
}