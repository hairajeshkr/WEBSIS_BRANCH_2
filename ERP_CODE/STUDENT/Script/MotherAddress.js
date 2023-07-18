function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateAdd() {
    var TxtMthrHousePer = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtMthrHousePer');
    var TxtMthrStreetPer = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_TxtMthrStreetPer');

    if (!isEmpty(TxtMthrHousePer, 'Please enter Name.', TxtMthrHousePer) &&
        !isEmpty(TxtMthrStreetPer, 'Please enter Name.', TxtMthrStreetPer)) {
        return true;
    }
    else {
        return false;
    }
}
function CopyAddressAll2() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel3_ChkSameMthr');

    var TxtMthrHousePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrHousePer");
    var TxtMthrStreetPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrStreetPer");
    var TxtMthrPostPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPostPer");
    var TxtMthrPincodePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPincodePer");
    var TxtMthrLandmarkPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrLandmarkPer");
    var CtrlGrdMthrCntryPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrCntryPer_TxtCaption");
    var CtrlGrdMthrCntryPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrCntryPer_HdnId");
    var CtrlGrdMthrStatePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrStatePer_TxtCaption");
    var CtrlGrdMthrStatePerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrStatePer_HdnId");
    var CtrlGrdMthrDistPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrDistPer_TxtCaption");
    var CtrlGrdMthrDistPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrDistPer_HdnId");
    var TxtMthrPhNoPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPhNoPer");
    var TxtMthrEmailPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrEmailPer");
    var TxtMthrMobPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrMobPer");
    var TxtMthrRemarksPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrRemarksPer");

    var TxtMthrHouseTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrHouseTemp");
    var TxtMthrStreetTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrStreetTemp");
    var TxtMthrPostTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPostTemp");
    var TxtMthrPincodeTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPincodeTemp");
    var TxtMthrLandmarkTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrLandmarkTemp");
    var CtrlGrdMthrCntryTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrCntryTemp_TxtCaption");
    var CtrlGrdMthrCntryTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrCntryTemp_HdnId");
    var CtrlGrdMthrStateTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrStateTemp_TxtCaption");
    var CtrlGrdMthrStateTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrStateTemp_HdnId");
    var CtrlGrdMthrDistTEmp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrDistTEmp_TxtCaption");
    var CtrlGrdMthrDistTEmpId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_CtrlGrdMthrDistTEmp_HdnId");
    var TxtMthrPhNoTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrPhNoTemp");
    var TxtMthrEmailTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrEmailTemp");
    var TxtMthrMobTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrMobTemp");
    var TxtMthrRemarksTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel3_TxtMthrRemarksTemp");

    if (checkBox.checked == true) {
        var TxtHouseNamePermValue = TxtMthrHousePer.value;
        var TxtAddressPermValue = TxtMthrStreetPer.value;
        var TxtPostOfficePermValue = TxtMthrPostPer.value;
        var TxtPinCodePermValue = TxtMthrPincodePer.value;
        var TxtCityPermValue = TxtMthrLandmarkPer.value;

        var CtrlGrdCountryPerValue = CtrlGrdMthrCntryPer.value;
        var CtrlGrdCountryPerId = CtrlGrdMthrCntryPerId.value;
        var CtrlGrdStatePerValue = CtrlGrdMthrStatePer.value;
        var CtrlGrdStatePerId = CtrlGrdMthrStatePerId.value;
        var CtrlGrdDistrictPerValue = CtrlGrdMthrDistPer.value;
        var CtrlGrdDistrictPerId = CtrlGrdMthrDistPerId.value;

        var TxtPhoneNoPermValue = TxtMthrPhNoPer.value;
        var TxtEmailPermValue = TxtMthrEmailPer.value;
        var TxtMobNoPermValue = TxtMthrMobPer.value;
        var TxtRemarksPermValue = TxtMthrRemarksPer.value;

        TxtMthrHouseTemp.value = TxtHouseNamePermValue;
        TxtMthrStreetTemp.value = TxtAddressPermValue;
        TxtMthrPostTemp.value = TxtPostOfficePermValue;
        TxtMthrPincodeTemp.value = TxtPinCodePermValue;
        TxtMthrLandmarkTemp.value = TxtCityPermValue;

        CtrlGrdMthrCntryTemp.value = CtrlGrdCountryPerValue;
        CtrlGrdMthrCntryTempId.value = CtrlGrdCountryPerId;
        CtrlGrdMthrStateTemp.value = CtrlGrdStatePerValue;
        CtrlGrdMthrStateTempId.value = CtrlGrdStatePerId;
        CtrlGrdMthrDistTEmp.value = CtrlGrdDistrictPerValue;
        CtrlGrdMthrDistTEmpId.value = CtrlGrdDistrictPerId;

        TxtMthrPhNoTemp.value = TxtPhoneNoPermValue;

        TxtMthrEmailTemp.value = TxtEmailPermValue;
        TxtMthrMobTemp.value = TxtMobNoPermValue;
        TxtMthrRemarksTemp.value = TxtRemarksPermValue;

    }
    else {
        TxtMthrHouseTemp.value = "";
        TxtMthrStreetTemp.value = "";
        TxtMthrPostTemp.value = "";
        TxtMthrPincodeTemp.value = "";
        TxtMthrLandmarkTemp.value = "";
        CtrlGrdMthrCntryTemp.value = "";
        CtrlGrdMthrStateTemp.value = "";
        CtrlGrdMthrDistTEmp.value = "";
        TxtMthrPhNoTemp.value = "";
        TxtMthrEmailTemp.value = "";
        TxtMthrMobTemp.value = "";
        TxtMthrRemarksTemp.value = "";
    }
}