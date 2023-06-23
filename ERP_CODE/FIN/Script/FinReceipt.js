function ValidateMasterData()  
{
   
    var TxtRefNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlRewindEvent1_TxtReffNo');
    var TxtTrDate = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlTrDate_TxtDate');
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdAcc_TxtCaption');
    var LblCash = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_LblCash').innerHTML;

    if (!isEmpty(TxtRefNo, 'Please enter Reference No.', TxtRefNo) &&
        !isEmpty(TxtTrDate, 'Please enter Transaction Date.', TxtTrDate) && FnCheckFaYearTrDate(TxtTrDate) &&
         isChildData(TxtAccId, 'Please select Valid ' + LblCash, TxtAcc))
    {
        resp=window.confirm('Do you want to print this record.');
        document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ctl03_HdnCnfrm').value = resp;
        return true;
    }
    else
    {
        return false;
    }
}
function ValidateChildData()  
{
    var TxtAccId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdParty_HdnId');
    var TxtAcc = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdParty_TxtCaption');

    if (isChildData(TxtAccId, 'Please select Valid Account Dr/Party.', TxtAcc))
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
    document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TotalAmt').value = "";
}
function GridChkSelectAll() {
    var grid = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords');
    if (grid.rows.length > 0) {
        for (i = 0; i < grid.rows.length - 1; i++) {
            document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwRecords_ChkGrd_' + i).checked = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ChkSelect').checked;
        }
    }
}