function ValidateMasterData()  
{
    var HdnAutoId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlOrdeDetails1_HdnAutoId');
    var DdlTransportPerson = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdlTransportPerson');
    var DdLBagNo = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdLBagNo');
    var DdLUnit = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_DdLUnit');
    if (FnIsNumeric(HdnAutoId.value) > 0)
    {
        if (isListSelected(DdlTransportPerson, 'Please select Despatch Mode.', DdlTransportPerson, 0) &&
        isListSelected(DdLBagNo, 'Please select Bag No.', DdLBagNo, 0) &&
        isListSelected(DdLUnit, 'Please select Despatch Unit.', DdLUnit, 0)) {
            return true;
        }
        else {
            return false;
        }
    }
    else
    {
        return false;
    }
}