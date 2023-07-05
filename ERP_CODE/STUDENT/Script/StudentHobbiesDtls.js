function ValidateMasterData()
{
    if (ValidateAdd() == true)
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
    var TxtCustomeId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustome_HdnId');
    var TxtCustomeName = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustome_TxtCaption');

    var TxtCustomeHeadId = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustomeHead_HdnId');
    var TxtCustomeHead = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCustomeHead_TxtCaption');

    if (isChildData(TxtCustomeHeadId, 'Please select Valid Custome Head.', TxtCustomeHead) &&
        isChildData(TxtCustomeId, 'Please select Valid Hobbies & Activities	.', TxtCustomeName))
    {
        return true;
    }
    else
    {
        return false;
    }
}