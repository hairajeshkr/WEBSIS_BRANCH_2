
function FnUpdateStudentDivision(PrmCompanyId, PrmBranchId, PrmAcId, PrmUserId, PrmStudentId, PrmClassId, PrmPrvDivCtrl, PrmDivisionCtrl, PrmDestControl)
{
    var nDivId = document.getElementById(PrmDivisionCtrl).value;
    var nPrvDivId = document.getElementById(PrmPrvDivCtrl).value;
    Web_GetStudentService.FnUpdateStudentDivision(PrmCompanyId, PrmBranchId, PrmAcId, PrmUserId, PrmStudentId, PrmClassId, nPrvDivId, nDivId, ValUpdateStudentDivisionSuccess, ValFailed, PrmDestControl);
}
function ValUpdateStudentDivisionSuccess(ress, PrmDestControl)
{
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[0]).value = ress[0];
    var grid = document.getElementById(strDest[1]);
    if (grid.rows.length > 0)
    {
        for (i = 0; i < grid.rows.length - 1; i++)
        {
            if (document.getElementById(strDest[1] + '_HdnId_' + i).value == ress[0])
            {
                document.getElementById(strDest[1] + '_LblCnt_' + i).innerHTML = ress[2];
                document.getElementById(strDest[1] + '_LblGender_' + i).innerHTML = ress[3];
            }
            if (document.getElementById(strDest[1] + '_HdnId_' + i).value == ress[1])
            {
                document.getElementById(strDest[1] + '_LblCnt_' + i).innerHTML = ress[4];
                document.getElementById(strDest[1] + '_LblGender_' + i).innerHTML = ress[5];
            }
        }
    }
}
function FnUpdateFeeAssign(PrmTokenNo, PrmId, PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId, PrmFeeMasteId, PrmInstituteGrpCtrl, PrmClassCtrl, PrmDivisionCtrl, PrmStudentCtrl, PrmTxtAmtCtrl, PrmRowIndex, PrmDestControl) {
    var strInstituteGrpId = document.getElementById(PrmInstituteGrpCtrl).value;
    var strClassId = document.getElementById(PrmClassCtrl).value;
    var strDivId = document.getElementById(PrmDivisionCtrl).value;
    var strStudentId = document.getElementById(PrmStudentCtrl).value;

    var nRwIndex = document.getElementById(PrmRowIndex).value;
    var nAmt = document.getElementById(PrmTxtAmtCtrl).value;

    var strFrmDate = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_CtrlFrmDate_" + nRwIndex + "_TxtDate_" + nRwIndex).value;
    var strToDate = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_CtrlToDate_" + nRwIndex + "_TxtDate_" + nRwIndex).value;
    var strInstalmentId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_HdnId_" + nRwIndex).value;
    PrmDestControl = PrmDestControl + ",ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_TxtInstalAmt_" + nRwIndex;

    Web_GetStudentService.FnGetFeeAssignTemp(PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId, PrmTokenNo, PrmId, strFrmDate, strToDate, strInstalmentId, PrmFeeMasteId, strInstituteGrpId, strClassId, strDivId, strStudentId, nAmt, 0, nAmt, ValUpdateFeeAssignSuccess, ValFailed, PrmDestControl);
}

function ValUpdateFeeAssignSuccess(ress, PrmDestControl)
{
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[2]).value = ress[2];
    document.getElementById(strDest[1]).value = ress[4];
    var grid = document.getElementById(strDest[0]);

    if (grid.rows.length > 0) {
        for (i = 0; i < grid.rows.length - 1; i++)
        {
            if (document.getElementById(strDest[0] + '_HdnId_' + i).value == ress[1])
            {
                document.getElementById(strDest[0] + '_TxtFeeTotAmt_' + i).value = ress[3];
            }
        }
    } 
}

function FnUpdateFeeConcessionAssign(PrmTokenNo, PrmId, PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId, PrmFeeMasteId, PrmInstituteGrpCtrl, PrmClassCtrl, PrmDivisionCtrl, PrmStudentCtrl, PrmTxtAmtCtrl, PrmRowIndex, PrmDestControl) {
    var strInstituteGrpId = document.getElementById(PrmInstituteGrpCtrl).value;
    var strClassId = document.getElementById(PrmClassCtrl).value;
    var strDivId = document.getElementById(PrmDivisionCtrl).value;
    var strStudentId = document.getElementById(PrmStudentCtrl).value;

    var nRwIndex = document.getElementById(PrmRowIndex).value;
    var nAmt = document.getElementById(PrmTxtAmtCtrl).value;

    var strInstalmentId = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_HdnId_" + nRwIndex).value;
    PrmDestControl = PrmDestControl + ",ContentPlaceHolder1_TabContainer1_TabPanel1_GrdVwRecords_TxtInstalAmt_" + nRwIndex;

    Web_GetStudentService.FeeConcessionAssignTemp(PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId, PrmTokenNo, PrmId, strInstalmentId, PrmFeeMasteId, strInstituteGrpId, strClassId, strDivId, strStudentId, nAmt, 0, nAmt, ValUpdateFeeConcessionAssignSuccess, ValFailed, PrmDestControl);
}
function ValUpdateFeeConcessionAssignSuccess(ress, PrmDestControl) {
    var strDest = PrmDestControl.split(",");
    document.getElementById(strDest[2]).value = ress[2];
    document.getElementById(strDest[1]).value = ress[4];
    var grid = document.getElementById(strDest[0]);

    if (grid.rows.length > 0) {
        for (i = 0; i < grid.rows.length - 1; i++) {
            if (document.getElementById(strDest[0] + '_HdnId_' + i).value == ress[1]) {
                document.getElementById(strDest[0] + '_TxtFeeTotAmt_' + i).value = ress[3];
            }
        }
    }
}

function ValStudentMarkUpdateSuccess(ress) {
    //alert("success");
}



function FnUpdateStudMark(PrmTokenNo,PrmId, PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId,PrmStaffIdCtrl, PrmGrpCtrl, PrmPaperCtrl, PrmExamCtrl, PrmSubExamCtrl, PrmTxtMarkCtrl, PrmClassId, PrmDivId, PrmStuId, PrmMaxMark, ExamDate, PrmStudStatus) {

    var StaffId = document.getElementById(PrmStaffIdCtrl).value;
    var StudGrpId = document.getElementById(PrmGrpCtrl).value;
    var PaperId = document.getElementById(PrmPaperCtrl).value;
    var ExamId = document.getElementById(PrmExamCtrl).value;
    var ExamSubId = document.getElementById(PrmSubExamCtrl).value;  
    //var ExamDate = document.getElementById(ExamDate).value;
    var ClassId = document.getElementById(PrmClassId).value;
    var DivId = document.getElementById(PrmDivId).value;
    var StudentId = document.getElementById(PrmStuId).value;
    var MaxMark = PrmMaxMark;
    var StudStatus = document.getElementById(PrmStudStatus).value;

    var nMark = document.getElementById(PrmTxtMarkCtrl).value;

    if (document.getElementById(PrmStudStatus).value== "2") {
        document.getElementById(PrmTxtMarkCtrl).disabled = true;
            }

    else {
        document.getElementById(PrmTxtMarkCtrl).disabled = false;  
       
    }
    




    //Web_GetStudentService.FnUpdateStudentMarkEntry(StaffId, StudGrpId, PaperId, ExamId, ExamSubId, ClassId, DivId, StudentId, nMark, MaxMark, ExamDate, StudStatus, ValStudentMarkUpdateSuccess, ValFailed);
    Web_GetStudentService.FnUpdateStudentMarkEntry(PrmCompanyId, PrmBranchId, PrmAcId, PrmFaId, PrmTType, PrmUserId, PrmTokenNo,PrmId,StaffId, StudGrpId, PaperId, ExamId, ExamSubId, ClassId, DivId, StudentId, nMark, MaxMark, StudStatus, ValStudentMarkUpdateSuccess, ValFailed);

}

