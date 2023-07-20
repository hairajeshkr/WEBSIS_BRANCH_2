function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtHouseNamePerm = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtHouseNamePerm');
    var TxtHouseNameTemp = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtHouseNameTemp');

    if (!isEmpty(TxtHouseNamePerm, 'Please enter Name.', TxtHouseNamePerm) &&
        !isEmpty(TxtHouseNameTemp, 'Please enter Name.', TxtHouseNameTemp)) {
        return true;
    }
    else {
        return false;
    }
}
function CopyFatherAddress() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel2_ChkSameFthr');

    var TxtFthrHousePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrHousePer");
    var TxtFthrStreetPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrStreetPer");
    var TxtFthrPostPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPostPer");
    var TxtFthrPincodePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPincodePer");
    var TxtFthrLandmarkPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrLandmarkPer");
    var CtrlGrdFthrCntryPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrCntryPer_TxtCaption");
    var CtrlGrdFthrCntryPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrCntryPer_HdnId");
    var CtrlGrdFthrStatePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrStatePer_TxtCaption");
    var CtrlGrdFthrStatePerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrStatePer_HdnId");
    var CtrlGrdFthrDistPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrDistPer_TxtCaption");
    var CtrlGrdFthrDistPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrDistPer_HdnId");
    var TxtFthrPhNoPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPhNoPer");
    var TxtFthrEmailPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrEmailPer");
    var TxtFthrMobPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrMobPer");
    var TxtFthrRemarksPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrRemarksPer");

    var TxtFthrHouseTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrHouseTemp");
    var TxtFthrStreetTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrStreetTemp");
    var TxtFthrPostTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPostTemp");
    var TxtFthrPincodeTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPincodeTemp");
    var TxtFthrLandmarkTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrLandmarkTemp");
    var CtrlGrdFthrCntryTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrCntryTemp_TxtCaption");
    var CtrlGrdFthrCntryTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrCntryTemp_HdnId");
    var CtrlGrdFthrStateTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrStateTemp_TxtCaption");
    var CtrlGrdFthrStateTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrStateTemp_HdnId");
    var CtrlGrdFthrDistTEmp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrDistTEmp_TxtCaption");
    var CtrlGrdFthrDistTEmpId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_CtrlGrdFthrDistTEmp_HdnId");
    var TxtFthrPhNoTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrPhNoTemp");
    var TxtFthrEmailTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrEmailTemp");
    var TxtFthrMobTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrMobTemp");
    var TxtFthrRemarksTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel2_TxtFthrRemarksTemp");

    if (checkBox.checked == true) {
        TxtFthrHouseTemp.value = TxtFthrHousePer.value;
        TxtFthrStreetTemp.value = TxtFthrStreetPer.value;
        TxtFthrPostTemp.value = TxtFthrPostPer.value;
        TxtFthrPincodeTemp.value = TxtFthrPincodePer.value;
        TxtFthrLandmarkTemp.value = TxtFthrLandmarkPer.value;

        CtrlGrdFthrCntryTemp.value = CtrlGrdFthrCntryPer.value;
        CtrlGrdFthrCntryTempId.value = CtrlGrdFthrCntryPerId.value;
        CtrlGrdFthrStateTemp.value = CtrlGrdFthrStatePer.value;
        CtrlGrdFthrStateTempId.value = CtrlGrdFthrStatePerId.value;
        CtrlGrdFthrDistTEmp.value = CtrlGrdFthrDistPer.value;
        CtrlGrdFthrDistTEmpId.value = CtrlGrdFthrDistPerId.value;

        TxtFthrPhNoTemp.value = TxtFthrPhNoPer.value;
        TxtFthrEmailTemp.value = TxtFthrEmailPer.value;
        TxtFthrMobTemp.value = TxtFthrMobPer.value;
        TxtFthrRemarksTemp.value = TxtFthrRemarksPer.value;

    }
    else {
        TxtFthrHouseTemp.value = "";
        TxtFthrStreetTemp.value = "";
        TxtFthrPostTemp.value = "";
        TxtFthrPincodeTemp.value = "";
        TxtFthrLandmarkTemp.value = "";
        CtrlGrdFthrCntryTemp.value = "";
        CtrlGrdFthrStateTemp.value = "";
        CtrlGrdFthrDistTEmp.value = "";
        TxtFthrPhNoTemp.value = "";
        TxtFthrEmailTemp.value = "";
        TxtFthrMobTemp.value = "";
        TxtFthrRemarksTemp.value = "";
    }
}