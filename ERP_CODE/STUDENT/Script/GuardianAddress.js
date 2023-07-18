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
function CopyAddressAll1() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel4_ChkSameGurdn');

    var TxtGurdnHousePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnHousePer");
    var TxtGurdnStreetPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnStreetPer");
    var TxtGurdnPostPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPostPer");
    var TxtGurdnPincodePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPincodePer");
    var TxtGurdnLandmarkPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnLandmarkPer");
    var CtrlGrdGurdnCntryPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnCntryPer_TxtCaption");
    var CtrlGrdGurdnCntryPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnCntryPer_HdnId");
    var CtrlGrdGurdnStatePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnStatePer_TxtCaption");
    var CtrlGrdGurdnStatePerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnStatePer_HdnId");
    var CtrlGrdGurdnDistPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnDistPer_TxtCaption");
    var CtrlGrdGurdnDistPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnDistPer_HdnId");
    var TxtGurdnPhNoPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPhNoPer");
    var TxtGurdnEmailPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnEmailPer");
    var TxtGurdnMobPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnMobPer");
    var TxtGurdnRemarksPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnRemarksPer");

    var TxtGurdnHouseTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnHouseTemp");
    var TxtGurdnStreetTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnStreetTemp");
    var TxtGurdnPostTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPostTemp");
    var TxtGurdnPincodeTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPincodeTemp");
    var TxtGurdnLandmarkTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnLandmarkTemp");
    var CtrlGrdGurdnCntryTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnCntryTemp_TxtCaption");
    var CtrlGrdGurdnCntryTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnCntryTemp_HdnId");
    var CtrlGrdGurdnStateTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnStateTemp_TxtCaption");
    var CtrlGrdGurdnStateTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnStateTemp_HdnId");
    var CtrlGrdGurdnDistTEmp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnDistTEmp_TxtCaption");
    var CtrlGrdGurdnDistTEmpId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_CtrlGrdGurdnDistTEmp_HdnId");
    var TxtGurdnPhNoTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnPhNoTemp");
    var TxtGurdnEmailTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnEmailTemp");
    var TxtGurdnMobTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnMobTemp");
    var TxtGurdnRemarksTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel4_TxtGurdnRemarksTemp");

    if (checkBox.checked == true) {
        var TxtHouseNamePermValue = TxtGurdnHousePer.value;
        var TxtAddressPermValue = TxtGurdnStreetPer.value;
        var TxtPostOfficePermValue = TxtGurdnPostPer.value;
        var TxtPinCodePermValue = TxtGurdnPincodePer.value;
        var TxtCityPermValue = TxtGurdnLandmarkPer.value;

        var CtrlGrdCountryPerValue = CtrlGrdGurdnCntryPer.value;
        var CtrlGrdCountryPerId = CtrlGrdGurdnCntryPerId.value;
        var CtrlGrdStatePerValue = CtrlGrdGurdnStatePer.value;
        var CtrlGrdStatePerId = CtrlGrdGurdnStatePerId.value;
        var CtrlGrdDistrictPerValue = CtrlGrdGurdnDistPer.value;
        var CtrlGrdDistrictPerId = CtrlGrdGurdnDistPerId.value;
        var TxtPhoneNoPermValue = TxtGurdnPhNoPer.value;
        var TxtEmailPermValue = TxtGurdnEmailPer.value;
        var TxtMobNoPermValue = TxtGurdnMobPer.value;
        var TxtRemarksPermValue = TxtGurdnRemarksPer.value;

        TxtGurdnHouseTemp.value = TxtHouseNamePermValue;
        TxtGurdnStreetTemp.value = TxtAddressPermValue;
        TxtGurdnPostTemp.value = TxtPostOfficePermValue;
        TxtGurdnPincodeTemp.value = TxtPinCodePermValue;
        TxtGurdnLandmarkTemp.value = TxtCityPermValue;

        CtrlGrdGurdnCntryTemp.value = CtrlGrdCountryPerValue;
        CtrlGrdGurdnCntryTempId.value = CtrlGrdCountryPerId;
        CtrlGrdGurdnStateTemp.value = CtrlGrdStatePerValue;
        CtrlGrdGurdnStateTempId.value = CtrlGrdStatePerId;
        CtrlGrdGurdnDistTEmp.value = CtrlGrdDistrictPerValue;
        CtrlGrdGurdnDistTEmpId.value = CtrlGrdDistrictPerId;

        TxtGurdnPhNoTemp.value = TxtPhoneNoPermValue;
        TxtGurdnEmailTemp.value = TxtEmailPermValue;
        TxtGurdnMobTemp.value = TxtMobNoPermValue;
        TxtGurdnRemarksTemp.value = TxtRemarksPermValue;

    }
    else {
        TxtGurdnHouseTemp.value = "";
        TxtGurdnStreetTemp.value = "";
        TxtGurdnPostTemp.value = "";
        TxtGurdnPincodeTemp.value = "";
        TxtGurdnLandmarkTemp.value = "";
        CtrlGrdGurdnCntryTemp.value = "";
        CtrlGrdGurdnStateTemp.value = "";
        CtrlGrdGurdnDistTEmp.value = "";
        TxtGurdnPhNoTemp.value = "";
        TxtGurdnEmailTemp.value = "";
        TxtGurdnMobTemp.value = "";
        TxtGurdnRemarksTemp.value = "";
    }
}
