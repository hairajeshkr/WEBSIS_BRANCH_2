function ValidateMasterData() {
    if (ValidateAdd() == true) {
        return true;
    }
    else {
        return false;
    }
}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
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
function FnCopyAddressAllStudent() {

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

    if (checkBox.checked == true)
    {
        TxtHouseNameTemp.value = TxtHouseNamePerm.value;
        TxtAddressTemp.value = TxtAddressPerm.value;
        TxtPostOfficeTemp.value = TxtPostOfficePerm.value;
        TxtPinCodeTemp.value = TxtPinCodePerm.value;
        TxtCityTemp.value = TxtCityPerm.value;

        CtrlGrdCountryTemp.value = CtrlGrdCountryPer.value;
        CtrlGrdCountryTempId.value = CtrlGrdCountryPerId.value;
        CtrlGrdStateTemp.value = CtrlGrdStatePer.value;
        CtrlGrdStateTempId.value = CtrlGrdStatePerId.value;
        CtrlGrdDistrictTemp.value = CtrlGrdDistrictPer.value;
        CtrlGrdDistrictTempId.value = CtrlGrdDistrictPerId.value;
        TxtPhoneNoTemp.value = TxtPhoneNoPerm.value;
        TxtEmailTemp.value = TxtEmailPerm.value;
        TxtMobNoTemp.value = TxtMobNoPerm.value;
        TxtRemarksTemp.value = TxtRemarksPerm.value;


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
function FnCopyAddressAllFather() {

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
function FnCopyAddressAllMother() {

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
        TxtMthrHouseTemp.value = TxtMthrHousePer.value;
        TxtMthrStreetTemp.value = TxtMthrStreetPer.value;
        TxtMthrPostTemp.value = TxtMthrPostPer.value;
        TxtMthrPincodeTemp.value = TxtMthrPincodePer.value;
        TxtMthrLandmarkTemp.value = TxtMthrLandmarkPer.value;

        CtrlGrdMthrCntryTemp.value = CtrlGrdMthrCntryPer.value;
        CtrlGrdMthrCntryTempId.value = CtrlGrdMthrCntryPerId.value;
        CtrlGrdMthrStateTemp.value = CtrlGrdMthrStatePer.value;
        CtrlGrdMthrStateTempId.value = CtrlGrdMthrStatePerId.value;
        CtrlGrdMthrDistTEmp.value = CtrlGrdMthrDistPer.value;
        CtrlGrdMthrDistTEmpId.value = CtrlGrdMthrDistPerId.value;

        TxtMthrPhNoTemp.value = TxtMthrPhNoPer.value;
        TxtMthrEmailTemp.value = TxtMthrEmailPer.value;
        TxtMthrMobTemp.value = TxtMthrMobPer.value;
        TxtMthrRemarksTemp.value = TxtMthrRemarksPer.value;
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
function FnCopyAddressAllGurdian() {

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
        TxtGurdnHouseTemp.value = TxtGurdnHousePer.value;
        TxtGurdnStreetTemp.value = TxtGurdnStreetPer.value;
        TxtGurdnPostTemp.value = TxtGurdnPostPer.value;
        TxtGurdnPincodeTemp.value = TxtGurdnPincodePer.value;
        TxtGurdnLandmarkTemp.value = TxtGurdnLandmarkPer.value;

        CtrlGrdGurdnCntryTemp.value = CtrlGrdGurdnCntryPer.value;
        CtrlGrdGurdnCntryTempId.value = CtrlGrdGurdnCntryPerId.value;
        CtrlGrdGurdnStateTemp.value = CtrlGrdGurdnStatePer.value;
        CtrlGrdGurdnStateTempId.value = CtrlGrdGurdnStatePerId.value;
        CtrlGrdGurdnDistTEmp.value = CtrlGrdGurdnDistPer.value;
        CtrlGrdGurdnDistTEmpId.value = CtrlGrdGurdnDistPerId.value;

        TxtGurdnPhNoTemp.value = TxtGurdnPhNoPer.value;
        TxtGurdnEmailTemp.value = TxtGurdnEmailPer.value;
        TxtGurdnMobTemp.value = TxtGurdnMobPer.value;
        TxtGurdnRemarksTemp.value = TxtGurdnRemarksPer.value;
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




function FnCopyAddressToFather() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkFather');

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
        
        TxtFthrHousePer.value = TxtHouseNamePerm.value;
        TxtFthrStreetPer.value = TxtAddressPerm.value;
        TxtFthrPostPer.value = TxtPostOfficePerm.value;
        TxtFthrPincodePer.value = TxtPinCodePerm.value;
        TxtFthrLandmarkPer.value = TxtCityPerm.value;

        CtrlGrdFthrCntryPer.value = CtrlGrdCountryPer.value;
        CtrlGrdFthrCntryPerId.value = CtrlGrdCountryPerId.value;
        CtrlGrdFthrStatePer.value = CtrlGrdStatePer.value;
        CtrlGrdFthrStatePerId.value = CtrlGrdStatePerId.value;
        CtrlGrdFthrDistPer.value = CtrlGrdDistrictPer.value;
        CtrlGrdFthrDistPerId.value = CtrlGrdDistrictPerId.value;

        TxtFthrPhNoPer.value = TxtPhoneNoPerm.value;
        TxtFthrEmailPer.value = TxtEmailPerm.value;
        TxtFthrMobPer.value = TxtMobNoPerm.value;
        TxtFthrRemarksPer.value = TxtRemarksPerm.value;



        TxtFthrHouseTemp.value = TxtHouseNameTemp.value;
        TxtFthrStreetTemp.value = TxtAddressTemp.value;
        TxtFthrPostTemp.value = TxtPostOfficeTemp.value;
        TxtFthrPincodeTemp.value = TxtPinCodeTemp.value;
        TxtFthrLandmarkTemp.value = TxtCityTemp.value;

        CtrlGrdFthrCntryTemp.value = CtrlGrdCountryTemp.value;
        CtrlGrdFthrCntryTempId.value = CtrlGrdCountryTempId.value;
        CtrlGrdFthrStateTemp.value = CtrlGrdStateTemp.value;
        CtrlGrdFthrStateTempId.value = CtrlGrdStateTempId.value;
        CtrlGrdFthrDistTEmp.value = CtrlGrdDistrictTemp.value;
        CtrlGrdFthrDistTEmpId.value = CtrlGrdDistrictTempId.value;

        TxtFthrPhNoTemp.value = TxtPhoneNoTemp.value;
        TxtFthrEmailTemp.value = TxtEmailTemp.value;
        TxtFthrMobTemp.value = TxtMobNoTemp.value;
        TxtFthrRemarksTemp.value = TxtRemarksTemp.value;


    }
    else {

        TxtFthrHousePer.value = "";
        TxtFthrStreetPer.value = "";
        TxtFthrPostPer.value = "";
        TxtFthrPincodePer.value = "";
        TxtFthrLandmarkPer.value = "";

        CtrlGrdFthrCntryPer.value = "";
        CtrlGrdFthrCntryPerId.value = "";
        CtrlGrdFthrStatePer.value = "";
        CtrlGrdFthrStatePerId.value = "";
        CtrlGrdFthrDistPer.value = "";
        CtrlGrdFthrDistPerId.value = "";

        TxtFthrPhNoPer.value = "";
        TxtFthrEmailPer.value = "";
        TxtFthrMobPer.value = "";
        TxtFthrRemarksPer.value = "";

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

function FnCopyAddressToMother() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkMother');

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

        TxtMthrHousePer.value = TxtHouseNamePerm.value;
        TxtMthrStreetPer.value = TxtAddressPerm.value;
        TxtMthrPostPer.value = TxtPostOfficePerm.value;
        TxtMthrPincodePer.value = TxtPinCodePerm.value;
        TxtMthrLandmarkPer.value = TxtCityPerm.value;

        CtrlGrdMthrCntryPer.value = CtrlGrdCountryPer.value;
        CtrlGrdMthrCntryPerId.value = CtrlGrdCountryPerId.value;
        CtrlGrdMthrStatePer.value = CtrlGrdStatePer.value;
        CtrlGrdMthrStatePerId.value = CtrlGrdStatePerId.value;
        CtrlGrdMthrDistPer.value = CtrlGrdDistrictPer.value;
        CtrlGrdMthrDistPerId.value = CtrlGrdDistrictPerId.value;

        TxtMthrPhNoPer.value = TxtPhoneNoPerm.value;
        TxtMthrEmailPer.value = TxtEmailPerm.value;
        TxtMthrMobPer.value = TxtMobNoPerm.value;
        TxtMthrRemarksPer.value = TxtRemarksPerm.value;

        TxtMthrHouseTemp.value = TxtHouseNameTemp.value;
        TxtMthrStreetTemp.value = TxtAddressTemp.value;
        TxtMthrPostTemp.value = TxtPostOfficeTemp.value;
        TxtMthrPincodeTemp.value = TxtPinCodeTemp.value;
        TxtMthrLandmarkTemp.value = TxtCityTemp.value;

        CtrlGrdMthrCntryTemp.value = CtrlGrdCountryTemp.value;
        CtrlGrdMthrCntryTempId.value = CtrlGrdCountryTempId.value;
        CtrlGrdMthrStateTemp.value = CtrlGrdStateTemp.value;
        CtrlGrdMthrStateTempId.value = CtrlGrdStateTempId.value;
        CtrlGrdMthrDistTEmp.value = CtrlGrdDistrictTemp.value;
        CtrlGrdMthrDistTEmpId.value = CtrlGrdDistrictTempId.value;

        TxtMthrPhNoTemp.value = TxtPhoneNoTemp.value;
        TxtMthrEmailTemp.value = TxtEmailTemp.value;
        TxtMthrMobTemp.value = TxtMobNoTemp.value;
        TxtMthrRemarksTemp.value = TxtRemarksTemp.value;

    }
    else {

        TxtMthrHousePer.value = "";
        TxtMthrStreetPer.value = "";
        TxtMthrPostPer.value = "";
        TxtMthrPincodePer.value = "";
        TxtMthrLandmarkPer.value = "";

        CtrlGrdMthrCntryPer.value = "";
        CtrlGrdMthrCntryPerId.value = "";
        CtrlGrdMthrStatePer.value = "";
        CtrlGrdMthrStatePerId.value = "";
        CtrlGrdMthrDistPer.value = "";
        CtrlGrdMthrDistPerId.value = "";

        TxtMthrPhNoPer.value = "";
        TxtMthrEmailPer.value = "";
        TxtMthrMobPer.value = "";
        TxtMthrRemarksPer.value = "";

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


function FnCopyAddressToGuardian() {

    var checkBox = document.getElementById('ContentPlaceHolder1_TabContainer1_TabPanel1_ChkGuardian');

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

        TxtGurdnHousePer.value = TxtHouseNamePerm.value;
        TxtGurdnStreetPer.value = TxtAddressPerm.value;
        TxtGurdnPostPer.value = TxtPostOfficePerm.value;
        TxtGurdnPincodePer.value = TxtPinCodePerm.value;
        TxtGurdnLandmarkPer.value = TxtCityPerm.value;

        CtrlGrdGurdnCntryPer.value = CtrlGrdCountryPer.value;
        CtrlGrdGurdnCntryPerId.value = CtrlGrdCountryPerId.value;
        CtrlGrdGurdnStatePer.value = CtrlGrdStatePer.value;
        CtrlGrdGurdnStatePerId.value = CtrlGrdStatePerId.value;
        CtrlGrdGurdnDistPer.value = CtrlGrdDistrictPer.value;
        CtrlGrdGurdnDistPerId.value = CtrlGrdDistrictPerId.value;

        TxtGurdnPhNoPer.value = TxtPhoneNoPerm.value;
        TxtGurdnEmailPer.value = TxtEmailPerm.value;
        TxtGurdnMobPer.value = TxtMobNoPerm.value;
        TxtGurdnRemarksPer.value = TxtRemarksPerm.value;

        TxtGurdnHouseTemp.value = TxtHouseNameTemp.value;
        TxtGurdnStreetTemp.value = TxtAddressTemp.value;
        TxtGurdnPostTemp.value = TxtPostOfficeTemp.value;
        TxtGurdnPincodeTemp.value = TxtPinCodeTemp.value;
        TxtGurdnLandmarkTemp.value = TxtCityTemp.value;

        CtrlGrdGurdnCntryTemp.value = CtrlGrdCountryTemp.value;
        CtrlGrdGurdnCntryTempId.value = CtrlGrdCountryTempId.value;
        CtrlGrdGurdnStateTemp.value = CtrlGrdStateTemp.value;
        CtrlGrdGurdnStateTempId.value = CtrlGrdStateTempId.value;
        CtrlGrdGurdnDistTEmp.value = CtrlGrdDistrictTemp.value;
        CtrlGrdGurdnDistTEmpId.value = CtrlGrdDistrictTempId.value;

        TxtGurdnPhNoTemp.value = TxtPhoneNoTemp.value;
        TxtGurdnEmailTemp.value = TxtEmailTemp.value;
        TxtGurdnMobTemp.value = TxtMobNoTemp.value;
        TxtGurdnRemarksTemp.value = TxtRemarksTemp.value;

    }
    else {

        TxtGurdnHousePer.value = "";
        TxtGurdnStreetPer.value = "";
        TxtGurdnPostPer.value = "";
        TxtGurdnPincodePer.value = "";
        TxtGurdnLandmarkPer.value = "";

        CtrlGrdGurdnCntryPer.value = "";
        CtrlGrdGurdnCntryPerId.value = "";
        CtrlGrdGurdnStatePer.value = "";
        CtrlGrdGurdnStatePerId.value = "";
        CtrlGrdGurdnDistPer.value = "";
        CtrlGrdGurdnDistPerId.value = "";

        TxtGurdnPhNoPer.value = "";
        TxtGurdnEmailPer.value = "";
        TxtGurdnMobPer.value = "";
        TxtGurdnRemarksPer.value = "";

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

