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
function CopyGuardianAddress() {

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
