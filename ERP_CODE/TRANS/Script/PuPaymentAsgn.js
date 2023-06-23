function ValidateMasterData()  
{
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAcc_Srch_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdAcc_Srch_TxtCaption');
    var DdlFaYear = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlFaId');

    if (isListSelected(DdlFaYear, 'Please select financial year.', DdlFaYear, 0) &&
        isChildData(TxtAccId, 'Please select Valid Supplier', TxtAcc))
    {
        return true;
    }
    else
    {
        return false;
    }
}
function FnGetGridTotalPaidAmt()
{
    var dAmt = 0.00;
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0)
    {
        for (i = 0; i < grid.rows.length - 1; i++)
        {
            
            dAmt = dAmt + FnGetDoubleVal(document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_TxtPaidAmt_' + i).value);
        }
    }
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_TxtTotPaid').value = dAmt;
}
function GridChkSelectAll()   
{  
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0)
    {
        for (i = 0; i < grid.rows.length - 1; i++)
        {
            document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ChkSelect').checked;
        }
    }
}