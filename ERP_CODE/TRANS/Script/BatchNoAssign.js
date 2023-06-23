function ValidateMasterData()  
{
    var TxtItmId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdItem_Srch_HdnId');
    var TxtItm = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdItem_Srch_TxtCaption');
      
    if (isChildData(TxtItmId, 'Please select Valid Item Name', TxtItm))
    {
        return true;
    }
    else
    {
        return false;
    }
}
function GridChkSelectAll()   
{  
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0)
    {
        var dQtyVal=0.000;
        for (i = 0; i < grid.rows.length - 1; i++)
        {
            document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ChkSelect').checked;
            if (document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked == true) {

                dQtyVal = dQtyVal + parseFloat(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_HdnQty_' + i).value);
            }
        }
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtQty').value = dQtyVal;
    }
}
function FnGridChkSelectSingle()
{
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0)
    {
        var dQtyVal = 0;
        for (i = 0; i < grid.rows.length - 1; i++) {
            if (document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked == true) {
                dQtyVal = dQtyVal + parseFloat(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_HdnQty_' + i).value);
            }
        }
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtQty').value = dQtyVal;
    }
}
function ValidateApproveData()
{
    var DdlBarCodeList = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlBarCodeList');
    var TxtQty = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtQty');
    var TxtAvbQty = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtAvbQty');
    if (isListSelected(DdlBarCodeList, 'Please Select Valid Barcode No.', DdlBarCodeList, 0) &&
        isGreaterThanToValue(TxtAvbQty, TxtQty, 'Please check your selected quantity'))
    {
       return true;
    }
    else
    {
        return false;
    }
}