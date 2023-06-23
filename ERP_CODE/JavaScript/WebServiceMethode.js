
function FnProductDeliveryQty(PrmCompanyId,PrmBranchId,PrmFaId,PrmUserId,PrmTType,PrmId,PrmTokenNo,PrmItemId,PrmUomId,PrmPackId,PrmGradeId,PrmShopeId,PmQty,PrmShipQty,PrmPrvQty,PrmDestControl)
{
    var dShipQty=document.getElementById(PrmShipQty).value;
    Web_GetResultService.FnGetProductDeliveryValue(PrmCompanyId,PrmBranchId,PrmFaId,PrmUserId,PrmTType,PrmId,PrmTokenNo,PrmItemId,PrmUomId,PrmPackId,PrmGradeId,PrmShopeId,PmQty,dShipQty,PrmPrvQty,ValProductDeliveryValueSuccess,ValFailed,PrmDestControl);
}
function ValProductDeliveryValueSuccess(ress,PrmDestControl) 
{   
    /*var strDest=PrmDestControl.split(",");*/
    document.getElementById(PrmDestControl).value=ress;
    /*document.getElementById(strDest[2]).value=ress[2];*/
}
//================== END =================================================================================================================================
function FnCalculateGroupInvoice(PrmCompanyId,PrmBranchId,PrmFaId,PrmUserId,PrmTType,PrmId,PrmTokenNo,PrmItemId,PrmUomId,PrmPackId,PmQty,PmSlQty,PrmRate,PrmDestControl)
{
    var dSlQty=document.getElementById(PmSlQty).value;
    Web_GetResultService.FnGetGroupInvoice(PrmCompanyId,PrmBranchId,PrmFaId,PrmUserId,PrmTType,PrmId,PrmTokenNo,PrmItemId,PrmUomId,PrmPackId,PmQty,dSlQty,PrmRate,ValGroupInvoiceSuccess,ValFailed,PrmDestControl);
}
function ValGroupInvoiceSuccess(ress,PrmDestControl) 
{ 
    document.getElementById(PrmDestControl).value=ress;
}
//================== END =================================================================================================================================
function FnTaxCalculation(PrmQty,PrmRate,PrmTaxId,PrmDiscount,PrmDestControl)
{
    var dQty=document.getElementById(PrmQty).value;
    var dRate=document.getElementById(PrmRate).value;
    var dDisc=document.getElementById(PrmDiscount).value;
    var dTaxId=document.getElementById(PrmTaxId).value;
    
    Web_GetResultService.FnGetTaxCalculation(dQty,dRate,dTaxId,dDisc,ValTaxCalculationSuccess,ValFailed,PrmDestControl);
}
function FnGetTaxCalculationExclusive(PrmQty,PrmRate,PrmTaxId,PrmDiscount,PrmDestControl)
{
    var dQty=document.getElementById(PrmQty).value;
    var dRate=document.getElementById(PrmRate).value;
    var dDisc=document.getElementById(PrmDiscount).value;
    var dTaxId=document.getElementById(PrmTaxId).value;

    Web_GetResultService.FnGetTaxCalculationExclusive(dQty,dRate,dTaxId,dDisc,ValTaxCalculationSuccess,ValFailed,PrmDestControl);
}
function ValTaxCalculationSuccess(ress,PrmDestControl) 
{ 
   var strDest=PrmDestControl.split(",");
   document.getElementById(strDest[0]).value=ress[0];
   document.getElementById(strDest[1]).value=ress[3];
   document.getElementById(strDest[2]).value=ress[1];
   document.getElementById(strDest[3]).value=ress[4];  
}
//================================ Tax Exclusive Mode
function FnGetTaxCalculationExclusiveMode(PrmQty, PrmRate, PrmTaxId, PrmDiscount, PrmDestControl)
{
    var dQty = document.getElementById(PrmQty).value;
    var dRate = document.getElementById(PrmRate).value;
    var dDisc = document.getElementById(PrmDiscount).value;
    var dTaxId = document.getElementById(PrmTaxId).value;

    Web_GetResultService.FnGetTaxCalculationExclusiveMode(dQty, dRate, dTaxId, dDisc, ValTaxCalculationModeSuccess, ValFailed, PrmDestControl);
}
function ValTaxCalculationModeSuccess(ress, PrmDestControl)
{
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[0]).value = ress[0];
    document.getElementById(strDest[1]).value = ress[1];
    document.getElementById(strDest[2]).value = ress[2];
    document.getElementById(strDest[3]).value = ress[3];
    document.getElementById(strDest[4]).value = ress[5];
}
//================================ Tax Exclusive Mode NEW
function FnGetTaxCalculationExclusiveModeNew(PrmQty, PrmRate, PrmTaxId, PrmDiscount, PrmDestControl) {
    var dQty = document.getElementById(PrmQty).value;
    var dRate = document.getElementById(PrmRate).value;
    var dDisc = document.getElementById(PrmDiscount).value;
    var dTaxId = document.getElementById(PrmTaxId).value;

    Web_GetResultService.FnGetTaxCalculationExclusiveModeNew(dQty, dRate, dTaxId, dDisc, ValTaxCalculationModeNewSuccess, ValFailed, PrmDestControl);
}
function ValTaxCalculationModeNewSuccess(ress, PrmDestControl) {
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[0]).value = ress[0];
    document.getElementById(strDest[1]).value = ress[1];
   // document.getElementById(strDest[2]).value = ress[2];
    document.getElementById(strDest[3]).value = ress[3];
    document.getElementById(strDest[4]).value = ress[5];
    document.getElementById(strDest[5]).value = ress[6];
}
//================== END =================================================================================================================================
function FnAdditionalChargeCalculation(PrmChargeCtrl,PrmAmtCtrl,PrmTaxCtrl,PrmNetCtrl,PrmDestControl)
{
    var dChrgId=document.getElementById(PrmChargeCtrl).value;
    var dAmt=document.getElementById(PrmAmtCtrl).value;
    var dTaxAmt=document.getElementById(PrmTaxCtrl).value;
    var dNetAmt=document.getElementById(PrmNetCtrl).value;
     
    Web_GetResultService.FnGetAdditionChargeCalculation(dChrgId,dAmt,dTaxAmt,dNetAmt,ValAdditionalChargeCalculationSuccess,ValFailed,PrmDestControl);
}
function ValAdditionalChargeCalculationSuccess(ress,PrmDestControl) 
{ 
   var strDest=PrmDestControl.split(",");
   document.getElementById(strDest[0]).value=ress[0];
   document.getElementById(strDest[1]).value=ress[1];
   document.getElementById(strDest[2]).value=ress[2];
}
//================== END =================================================================================================================================
function FnGetBookSerialNo(PrmCompanyId,PrmBranchId,PrmFaId,PrmTType,PrmSrcCtrl,PrmDestControl)
{
    var strBookSerial=document.getElementById(PrmSrcCtrl).value;
    Web_GetResultService.FnGetBookSerialNoList(PrmCompanyId,PrmBranchId,PrmFaId,PrmTType,strBookSerial,ValBookSerialNoValueSuccess,ValFailed,PrmDestControl);
}
function ValBookSerialNoValueSuccess(ress,PrmDestControl) 
{   
    document.getElementById(PrmDestControl).value=ress;
}
function FnUpdatePrice(PrmId,PrmTokenId,PrmItemId,PrmMrp,PrmPrice1,PrmPrice2,PrmCompanyId,PrmBranchId,PrmFaId,PrmTType)
{
    var dMrp=document.getElementById(PrmMrp).value;
    var dPrice1=document.getElementById(PrmPrice1).value;
    var dPrice2=document.getElementById(PrmPrice2).value;
    Web_GetResultService.FnUpdatePrice(PrmId,PrmTokenId,PrmItemId,dMrp,dPrice1,dPrice2,PrmCompanyId,PrmBranchId,PrmFaId,PrmTType,ValPriceValueSuccess,ValFailed);
}
function ValPriceValueSuccess(ress)
{
    /*alert(ress);*/
}
function FnGetPieceDiscTaxCalculation(PrmQty,PrmRate,PrmPieceVal,PrmTaxId,PrmDestControl)
{
    var dQty=document.getElementById(PrmQty).value;
    var dRate=document.getElementById(PrmRate).value;
    var dPiece=document.getElementById(PrmPieceVal).value;
    var dTaxId=document.getElementById(PrmTaxId).value;
    
    Web_GetResultService.FnGetPieceDiscTaxCalculation(dQty,dRate,dPiece,dTaxId,ValTaxPieceCalculationSuccess,ValFailed,PrmDestControl);
}
function ValTaxPieceCalculationSuccess(ress,PrmDestControl)
{
   var strDest=PrmDestControl.split(",");
   document.getElementById(strDest[0]).value=ress[0];
   document.getElementById(strDest[1]).value=ress[3];
   document.getElementById(strDest[2]).value=ress[1];
   document.getElementById(strDest[3]).value=ress[4];
   document.getElementById(strDest[4]).value=ress[7]; 
}

//================== ORDER NO WISE DETAILS================================================================================
function FnGetShopeOrderItemDetails(PrmCompanyId, PrmBranchId, PrmOrderNoCtrl, PrmDestControl)
{
    var strOrderNoCtrl = document.getElementById(PrmOrderNoCtrl).value;
    Web_GetResultService.FnGetShopeOrderItemDetails(PrmCompanyId, PrmBranchId, strOrderNoCtrl, ValShopeOrderItemReceiveSuccess, ValFailed, PrmDestControl);
}
function ValShopeOrderItemReceiveSuccess(ress, PrmDestControl)
{
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[0]).value = ress[0];
    document.getElementById(strDest[1]).value = ress[1];
    document.getElementById(strDest[2]).value = ress[2];
    document.getElementById(strDest[3]).value = ress[3];
    document.getElementById(strDest[4]).value = ress[4];
    document.getElementById(strDest[5]).value = ress[5];
    document.getElementById(strDest[6]).value = ress[6];
    document.getElementById(strDest[7]).value = ress[7];
    document.getElementById(strDest[8]).value = ress[8];
    document.getElementById(strDest[9]).value = ress[9];
    document.getElementById(strDest[10]).value = ress[10];
    document.getElementById(strDest[11]).value = ress[11];
    document.getElementById(strDest[12]).value = ress[12];
    document.getElementById(strDest[13]).innerHTML = ress[13];
    document.getElementById(strDest[14]).value = ress[14];
    document.getElementById(strDest[15]).value = ress[15];
    document.getElementById(strDest[16]).value = ress[16];
    document.getElementById(strDest[17]).value = ress[17];
    document.getElementById(strDest[18]).value = ress[18];
}

//================== TRIAL ORDER NO WISE DETAILS================================================================================
function FnGetShopeItemTrialOrderDetails(PrmCompanyId, PrmBranchId, PrmOrderNoCtrl, PrmDestControl)
{
    var strOrderNoCtrl = document.getElementById(PrmOrderNoCtrl).value;
    Web_GetResultService.FnGetShopeTrialOrderDetails(PrmCompanyId, PrmBranchId, strOrderNoCtrl, ValShopeTialOrderItemSuccess, ValFailed, PrmDestControl);
}
function ValShopeTialOrderItemSuccess(ress, PrmDestControl)
{
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[0]).value = ress[0];
    document.getElementById(strDest[1]).innerHTML = ress[1];
    document.getElementById(strDest[2]).innerHTML = ress[2];
   // document.getElementById(strDest[3]).value = ress[3];
    document.getElementById(strDest[4]).innerHTML = ress[4];
    document.getElementById(strDest[5]).innerHTML = ress[5];
    document.getElementById(strDest[6]).value = ress[6];
}

//================== BATCH NO WISE ITEM STOCK DETAILS================================================================================
function FnGetItemBatchNoWiseStockDetails(PrmBatchNoCtrl, PrmCompanyId, PrmBranchId, PrmItemIdCtrl, PrmDestControl) {
 
    var strBatchNo = document.getElementById(PrmBatchNoCtrl).value;
    var strDest = strBatchNo.split(",");
    var strItemId = strDest[0];
    strBatchNo = strDest[1];
    /*var strItemId = document.getElementById(PrmItemIdCtrl).value;*/
    Web_GetResultService.FnGetItemBatchNoWiseStock(PrmCompanyId, PrmBranchId, strItemId, strBatchNo, ValItemBatchNoWiseStockSuccess, ValFailed, PrmDestControl);
}
function ValItemBatchNoWiseStockSuccess(ress, PrmDestControl)
{
    document.getElementById(PrmDestControl).value = ress;
}
//================== ITEm GROUp SETTINGS DETAILS================================================================================
function FnGetItemGroupSettingsSave(PrmCompanyId, PrmBranchId, PrmFaId, PrmTType, PrmTokenNo, PrmInvoiceId, PrmAccId, PrmItemId, PrmItmGrpCtrl, PrmItmSubGrpCtrl, PrmItmSubCatCtrl, PrmBatchNo, PrmGrdRowCount, PrmCurrentIndex) {
    var strItmGrpId = document.getElementById(PrmItmGrpCtrl).value;
    var strItmSubGrpId = document.getElementById(PrmItmSubGrpCtrl).value;
    var strItmSubCatId = document.getElementById(PrmItmSubCatCtrl).value;
    var strGrdRowCnt = document.getElementById(PrmGrdRowCount).value;
    Web_GetResultService.FnGetItemGroupSettingsUpdation(PrmCompanyId, PrmBranchId, PrmFaId, PrmTType, PrmTokenNo, PrmInvoiceId, PrmAccId, PrmItemId, strItmGrpId, strItmSubGrpId, strItmSubCatId, PrmBatchNo, strGrdRowCnt, PrmCurrentIndex, ValItemGroupSettingsSaveSuccess, ValFailed);
}
function ValItemGroupSettingsSaveSuccess(ress)
{
    if (ress != "0")
    {
        alert(ress);
    }
}