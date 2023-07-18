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
function CopyAddressAll() {
    
    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkSame');

    var TxtHouseNamePerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtHouseNamePerm");
    var TxtAddressPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAddressPerm");
    var TxtPostOfficePerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPostOfficePerm");
    var TxtPinCodePerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPinCodePerm");
    var TxtCityPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCityPerm");

    var CtrlGrdCountryPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCountryPer_TxtCaption");
    var CtrlGrdCountryPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCountryPer_HdnId");

    var CtrlGrdStatePer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdStatePer_TxtCaption");
    var CtrlGrdStatePerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdStatePer_HdnId");

    var CtrlGrdDistrictPer = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdDistrictPer_TxtCaption");
    var CtrlGrdDistrictPerId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdDistrictPer_HdnId");

    var TxtPhoneNoPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPhoneNoPerm");
    var TxtEmailPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtEmailPerm");
    var TxtMobNoPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtMobNoPerm");
    var TxtRemarksPerm = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRemarksPerm");

    var TxtHouseNameTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtHouseNameTemp");
    var TxtAddressTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtAddressTemp");
    var TxtPostOfficeTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPostOfficeTemp");
    var TxtPinCodeTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPinCodeTemp");
    var TxtCityTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtCityTemp");

    var CtrlGrdCountryTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCountryTemp_TxtCaption");
    var CtrlGrdCountryTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdCountryTemp_HdnId");

    var CtrlGrdStateTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdStateTemp_TxtCaption");
    var CtrlGrdStateTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdStateTemp_HdnId");

    var CtrlGrdDistrictTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdDistrictTemp_TxtCaption");
    var CtrlGrdDistrictTempId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_CtrlGrdDistrictTemp_HdnId");


    var TxtPhoneNoTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtPhoneNoTemp");
    var TxtEmailTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtEmailTemp");
    var TxtMobNoTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtMobNoTemp");
    var TxtRemarksTemp = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_TxtRemarksTemp");

    if (checkBox.checked == true) {
        var TxtHouseNamePermValue = TxtHouseNamePerm.value;
        var TxtAddressPermValue = TxtAddressPerm.value;
        var TxtPostOfficePermValue = TxtPostOfficePerm.value;
        var TxtPinCodePermValue = TxtPinCodePerm.value;
        var TxtCityPermValue = TxtCityPerm.value;

        var CtrlGrdCountryPerValue = CtrlGrdCountryPer.value;
        var CtrlGrdountryPerId = CtrlGrdCountryPerId.value;
        var CtrlGrdStatePerValue = CtrlGrdStatePer.value;
        var CtrlGrdStatePerId = CtrlGrdStatePerId.value;
        var CtrlGrdDistrictPerValue = CtrlGrdDistrictPer.value;
        var CtrlGrdDistrictPerId = CtrlGrdDistrictPerId.value;

        var TxtPhoneNoPermValue = TxtPhoneNoPerm.value;
        var TxtEmailPermValue = TxtEmailPerm.value;
        var TxtMobNoPermValue = TxtMobNoPerm.value;
        var TxtRemarksPermValue = TxtRemarksPerm.value;

        TxtHouseNameTemp.value = TxtHouseNamePermValue;
        TxtAddressTemp.value = TxtAddressPermValue;
        TxtPostOfficeTemp.value = TxtPostOfficePermValue;
        TxtPinCodeTemp.value = TxtPinCodePermValue;
        TxtCityTemp.value = TxtCityPermValue;

        CtrlGrdCountryTemp.value = CtrlGrdCountryPerValue;
        CtrlGrdCountryTempId.value = CtrlGrdountryPerId;
        CtrlGrdStateTemp.value = CtrlGrdStatePerValue;
        CtrlGrdStateTempId.value = CtrlGrdStatePerId;
        CtrlGrdDistrictTemp.value = CtrlGrdDistrictPerValue;
        CtrlGrdDistrictTempId.value = CtrlGrdDistrictPerId;
        TxtPhoneNoTemp.value = TxtPhoneNoPermValue;
        TxtEmailTemp.value = TxtEmailPermValue;
        TxtMobNoTemp.value = TxtMobNoPermValue;
        TxtRemarksTemp.value = TxtRemarksPermValue;

    }
    else {
        TxtHouseNameTemp.value = "";
        TxtAddressTemp.value = "";
        TxtPostOfficeTemp.value = "";
        TxtPinCodeTemp.value = "";
        TxtCityTemp.value = "";
        CtrlGrdCountryTemp.value = "";
        CtrlGrdStateTemp.value = "";
        CtrlGrdDistrictTemp.value = "";
        TxtPhoneNoTemp.value = "";
        TxtEmailTemp.value = "";
        TxtMobNoTemp.value = "";
        TxtRemarksTemp.value = "";
    }
}

