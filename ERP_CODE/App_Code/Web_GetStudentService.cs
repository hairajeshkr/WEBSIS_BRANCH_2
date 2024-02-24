using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Text;
using System.Data;
using System.Configuration;

[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Web_GetStudentService : System.Web.Services.WebService
{
    public Web_GetStudentService()
    {
    }
    [WebMethod()]
    public string[] FnUpdateStudentDivision(string PrmCmpId, string PrmBrId, string PrmAcId, string PrmUserId, string PrmStudentId, string PrmClassId, string PrmPrvDivId, string PrmDivisionId)
    {
        ClsWebServiceStudent ObjCls = new ClsWebServiceStudent();

        ObjCls.CompanyId = ObjCls.FnIsNumeric(PrmCmpId);
        ObjCls.BranchId = ObjCls.FnIsNumeric(PrmBrId);
        ObjCls.AcId = ObjCls.FnIsNumeric(PrmAcId);
        ObjCls.UserId = ObjCls.FnIsNumeric(PrmUserId);
        ObjCls.StudentId = ObjCls.FnIsNumeric(PrmStudentId);
        ObjCls.ClassId = ObjCls.FnIsNumeric(PrmClassId);
        ObjCls.PrvDivId = ObjCls.FnIsNumeric(PrmPrvDivId);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(PrmDivisionId);

        return ObjCls.FnUpdateDivision(ObjCls.FnIsNumeric(PrmDivisionId), ObjCls.FnIsNumeric(PrmPrvDivId));
    }
    [WebMethod()]
    public string[] FnGetFeeAssignTemp(string PrmCmpId, string PrmBrId, string PrmAcId, string PrmFaId, string PrmTType, string PrmUserId, string PrmTokenNo, string PrmId, string PrmStartDate, string PrmEndDate, string PrmInstalmentId, string PrmFeeMasterId, string PrmInstituteGrpId, string PrmClassId, string PrmDivisionId, string PrmStudentId, string PrmAmount, string PrmOtherAmt, string PrmTotalAmt)
    {
        ClsWebServiceFeeAssign ObjCls = new ClsWebServiceFeeAssign();

        ObjCls.CompanyId = ObjCls.FnIsNumeric(PrmCmpId);
        ObjCls.BranchId = ObjCls.FnIsNumeric(PrmBrId);
        ObjCls.AcId = ObjCls.FnIsNumeric(PrmAcId);
        ObjCls.UserId = ObjCls.FnIsNumeric(PrmUserId);
        ObjCls.FaId = ObjCls.FnIsNumeric(PrmFaId);
        ObjCls.TType = PrmTType.Trim();
        ObjCls.ID = ObjCls.FnIsNumeric(PrmId);

        ObjCls.TokenNo = ObjCls.FnIsDouble(PrmTokenNo);
        ObjCls.StartDate = ObjCls.FnDateTime(PrmStartDate);
        ObjCls.EndDate = ObjCls.FnDateTime(PrmEndDate);

        ObjCls.InstituteGrpId = ObjCls.FnIsNumeric(PrmInstituteGrpId);
        ObjCls.InstalmentId = ObjCls.FnIsNumeric(PrmInstalmentId);
        ObjCls.FeeMasterId = ObjCls.FnIsNumeric(PrmFeeMasterId);

        ObjCls.StudentId = ObjCls.FnIsNumeric(PrmStudentId);
        ObjCls.ClassId = ObjCls.FnIsNumeric(PrmClassId);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(PrmDivisionId);

        ObjCls.Amount = ObjCls.FnIsDouble(PrmAmount);
        ObjCls.OtherAmt = ObjCls.FnIsDouble(PrmOtherAmt);
        ObjCls.TotalAmt = ObjCls.FnIsDouble(PrmTotalAmt);


        string[] strList = new string[5];
        DataTable dtTemp = ObjCls.FnGetFeeAssignTemp();
        DataTable DTTeacher = (ObjCls.FnGetDataSet("select * from tblfeeassigntemp") as DataSet).Tables[0];


        if (dtTemp.Rows.Count > 0)
        {
            strList.SetValue(PrmInstalmentId.ToString(), 0);
            strList.SetValue(PrmFeeMasterId.ToString(), 1);

            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", " InstalmentId=" + PrmInstalmentId.ToString()).ToString(), 2);
            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", " FeeMasterId=" + PrmFeeMasterId.ToString()).ToString(), 3);
            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", "").ToString(), 4);
        }
        else
        {
            strList.SetValue("", 0);
            strList.SetValue("", 1);
            strList.SetValue("", 2);
            strList.SetValue("", 3);
            strList.SetValue("", 4);
        }
        return strList;
    }


    [WebMethod()]
    public string[] FeeConcessionAssignTemp(string PrmCmpId, string PrmBrId, string PrmAcId, string PrmFaId, string PrmTType, string PrmUserId, string PrmTokenNo, string PrmId, string PrmInstalmentId, string PrmFeeMasterId, string PrmInstituteGrpId, string PrmClassId, string PrmDivisionId, string PrmStudentId, string PrmAmount, string PrmOtherAmt, string PrmTotalAmt)
    {
        ClsWebServiceFeeAssign ObjCls = new ClsWebServiceFeeAssign();

        ObjCls.CompanyId = ObjCls.FnIsNumeric(PrmCmpId);
        ObjCls.BranchId = ObjCls.FnIsNumeric(PrmBrId);
        ObjCls.AcId = ObjCls.FnIsNumeric(PrmAcId);
        ObjCls.UserId = ObjCls.FnIsNumeric(PrmUserId);
        ObjCls.FaId = ObjCls.FnIsNumeric(PrmFaId);
        ObjCls.TType = PrmTType.Trim();
        ObjCls.ID = ObjCls.FnIsNumeric(PrmId);

        ObjCls.TokenNo = ObjCls.FnIsDouble(PrmTokenNo);

        ObjCls.InstituteGrpId = ObjCls.FnIsNumeric(PrmInstituteGrpId);
        ObjCls.InstalmentId = ObjCls.FnIsNumeric(PrmInstalmentId);
        ObjCls.FeeMasterId = ObjCls.FnIsNumeric(PrmFeeMasterId);

        ObjCls.StudentId = ObjCls.FnIsNumeric(PrmStudentId);
        ObjCls.ClassId = ObjCls.FnIsNumeric(PrmClassId);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(PrmDivisionId);

        ObjCls.Amount = ObjCls.FnIsDouble(PrmAmount);
        ObjCls.OtherAmt = ObjCls.FnIsDouble(PrmOtherAmt);
        ObjCls.TotalAmt = ObjCls.FnIsDouble(PrmTotalAmt);


        string[] strList = new string[5];
        DataTable dtTemp = ObjCls.FnGetConcessionAssignTemp();

        if (dtTemp.Rows.Count > 0)
        {
            strList.SetValue(PrmInstalmentId.ToString(), 0);
            strList.SetValue(PrmFeeMasterId.ToString(), 1);

            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", " InstalmentId=" + PrmInstalmentId.ToString()).ToString(), 2);
            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", " FeeMasterId=" + PrmFeeMasterId.ToString()).ToString(), 3);
            strList.SetValue(dtTemp.Compute("SUM(TotalAmt)", "").ToString(), 4);
        }
        else
        {
            strList.SetValue("", 0);
            strList.SetValue("", 1);
            strList.SetValue("", 2);
            strList.SetValue("", 3);
            strList.SetValue("", 4);
        }
        return strList;
    }





    [WebMethod()]
     public string[] FnUpdateStudentMarkEntry(string PrmCmpId, string PrmBrId, string PrmAcId, string PrmFaId, string PrmTType, string PrmUserId, string PrmTokenNo, string PrmId, string StaffId, string StudGrpId, string PaperId, string ExamId, string ExamSubId, string ClassId, string DivId, string StudentId, string nMark, string MaxMark, string StuDStatus, string Weightage, string FinalMaxMark)
     {

        ClsStudMarkEntryWeb ObjCls = new ClsStudMarkEntryWeb();

        ObjCls.CompanyId = ObjCls.FnIsNumeric(PrmCmpId);
        ObjCls.BranchId = ObjCls.FnIsNumeric(PrmBrId);
        ObjCls.AcId = ObjCls.FnIsNumeric(PrmAcId);
        ObjCls.UserId = ObjCls.FnIsNumeric(PrmUserId);
        ObjCls.FaId = ObjCls.FnIsNumeric(PrmFaId);
        ObjCls.TType = PrmTType.Trim();
        ObjCls.ID = ObjCls.FnIsNumeric(PrmId);

        ObjCls.StudentId = ObjCls.FnIsNumeric(StudentId);
        ObjCls.PaperId= ObjCls.FnIsNumeric(PaperId);
        ObjCls.ClassId = ObjCls.FnIsNumeric(ClassId);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(DivId);
        ObjCls.StaffId = ObjCls.FnIsNumeric(StaffId);
        ObjCls.StudGroupId = ObjCls.FnIsNumeric(StudGrpId);
        ObjCls.ExamId = ObjCls.FnIsNumeric(ExamId);
        ObjCls.ExamSubId = ObjCls.FnIsNumeric(ExamSubId);
        //ObjCls.ExamDate = ObjCls.FnDateTime(examdate);
        ObjCls.Mark= ObjCls.FnIsDecimal(nMark);
        ObjCls.MaxMark = ObjCls.FnIsNumeric(MaxMark);
        ObjCls.StudStatus= ObjCls.FnIsNumeric(StuDStatus);
        ObjCls.TokenNo = ObjCls.FnIsDouble(PrmTokenNo);
        ObjCls.Weightage = ObjCls.FnIsNumeric(Weightage);
        ObjCls.FinalMaxMark = ObjCls.FnIsNumeric(FinalMaxMark);


        string[] strList = new string[5];
        DataTable dtTemp = ObjCls.FnUpdateStudentMarkEntry();
        return strList;
     }

    [WebMethod()]
    public string[] FnUpdateStudGrade(string PrmCmpId, string PrmBrId, string PrmAcId, string PrmFaId, string PrmTType, string PrmUserId, string PrmTokenNo, string PrmId, string StaffId, string StudGrpId, string PaperId, string ExamId, string ExamSubId,string GradingSysId, string ClassId, string DivId, string StudentId, string nGrade, string StuDStatus)
    {

        ClsNEPStudentGradeEntryWeb ObjCls = new ClsNEPStudentGradeEntryWeb();

        ObjCls.CompanyId = ObjCls.FnIsNumeric(PrmCmpId);
        ObjCls.BranchId = ObjCls.FnIsNumeric(PrmBrId);
        ObjCls.AcId = ObjCls.FnIsNumeric(PrmAcId);
        ObjCls.UserId = ObjCls.FnIsNumeric(PrmUserId);
        ObjCls.FaId = ObjCls.FnIsNumeric(PrmFaId);
        ObjCls.TType = PrmTType.Trim();
        ObjCls.ID = ObjCls.FnIsNumeric(PrmId);

        ObjCls.StudentId = ObjCls.FnIsNumeric(StudentId);
        ObjCls.PaperId = ObjCls.FnIsNumeric(PaperId);
        ObjCls.ClassId = ObjCls.FnIsNumeric(ClassId);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(DivId);
        ObjCls.StaffId = ObjCls.FnIsNumeric(StaffId);
        ObjCls.StudGroupId = ObjCls.FnIsNumeric(StudGrpId);
        ObjCls.ExamId = ObjCls.FnIsNumeric(ExamId);
        ObjCls.ExamSubId = ObjCls.FnIsNumeric(ExamSubId);
        //ObjCls.ExamDate = ObjCls.FnDateTime(examdate);
        ObjCls.GradeId = ObjCls.FnIsNumeric(nGrade);
        ObjCls.StudStatusId = ObjCls.FnIsNumeric(StuDStatus);
        ObjCls.TokenNo = ObjCls.FnIsDouble(PrmTokenNo);
        ObjCls.GradingSystemId = ObjCls.FnIsNumeric(GradingSysId);



        string[] strList = new string[5];
        DataTable dtTemp = ObjCls.FnUpdateStudentGradeEntry();

        return strList;
    }


}