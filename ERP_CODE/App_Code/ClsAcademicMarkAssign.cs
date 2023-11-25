using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicMarkAssign : ClsCommonBaseMaster, IMasterCommands
{
   
    private int nStaffId = 0, nTermId = 0, nInstGrpId = 0, nClassId = 0, nDivisionId = 0, nSubjectId = 0, nStudentId = 0, nExamId = 0, nExamSubId = 0, nObtainedMark = 0, nAvgMark = 0;
    private int nObtainedGradeId = 0, nExamGradeId = 0, nExamCalculationId = 0;
    public ClsAcademicMarkAssign() : base("TblAcademicMarkAssign", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicMarkAssign(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicMarkAssign", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int StaffId
    {
        get
        { return nStaffId; }
        set
        { nStaffId = value; }
    }
    public int InstGrpId
    {
        get
        { return nInstGrpId; }
        set
        { nInstGrpId = value; }
    }
    public int SubjectId
    {
        get
        { return nSubjectId; }
        set
        { nSubjectId = value; }
    }
    public int TermId
    {
        get
        { return nTermId; }
        set
        { nTermId = value; }
    }
    public int ExamId
    {
        get
        { return nExamId; }
        set
        { nExamId = value; }
    }
    public int ExamSubId
    {
        get
        { return nExamSubId; }
        set
        { nExamSubId = value; }
    }
    public int ObtainedMark
    {
        get
        { return nObtainedMark; }
        set
        { nObtainedMark = value; }
    }
    public int AvgMark
    {
        get
        { return nAvgMark; }
        set
        { nAvgMark = value; }
    }
    public int ObtainedGradeId
    {
        get
        { return nObtainedGradeId; }
        set
        { nObtainedGradeId = value; }
    }
    public int ExamGradeId
    {
        get
        { return nExamGradeId; }
        set
        { nExamGradeId = value; }
    }
    public int ExamCalculationId
    {
        get
        { return nExamCalculationId; }
        set
        { nExamCalculationId = value; }
    }

    //    nId, nStaffId, nTermId, nInstGrpId, nClassId, nDivisionId, nSubjectId, nStudentId, nExamId, nExamSubId, nObtainedMark, 
    //nAvgMark, nObtainedGradeId, nExamGradeId, nExamCalculationId, 
    #region IMasterCommands Members
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        StaffId = FnIsNumeric(drVal["StaffId"].ToString());
        TermId = FnIsNumeric(drVal["TermId"].ToString());
        InstGrpId = FnIsNumeric(drVal["InstGrpId"].ToString());
        ClassId = FnIsNumeric(drVal["ClassId"].ToString());
        DivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        SubjectId = FnIsNumeric(drVal["SubjectId"].ToString());
        StudentId = FnIsNumeric(drVal["StudentId"].ToString());
        ExamId= FnIsNumeric(drVal["ExamId"].ToString());
        ExamSubId = FnIsNumeric(drVal["ExamSubId"].ToString());
        ObtainedMark = FnIsNumeric(drVal["ObtainedMark"].ToString());
        AvgMark = FnIsNumeric(drVal["AvgMark"].ToString());
        ObtainedGradeId = FnIsNumeric(drVal["ObtainedGradeId"].ToString());
        ExamGradeId = FnIsNumeric(drVal["ExamGradeId"].ToString());
        ExamCalculationId = FnIsNumeric(drVal["ExamCalculationId"].ToString());

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_nStaffId", System.Data.DbType.Int32, StaffId);
        objFields.AddParameterFields("Prm_nTermId", System.Data.DbType.Int32, TermId);
        objFields.AddParameterFields("Prm_nInstGrpId", System.Data.DbType.Int32, InstGrpId);
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId);
        objFields.AddParameterFields("Prm_nDivisionId", System.Data.DbType.Int32, DivisionId);
        objFields.AddParameterFields("Prm_nSubjectId", System.Data.DbType.Int32, SubjectId);
        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId);
        objFields.AddParameterFields("Prm_nExamId", System.Data.DbType.Int32, ExamId);
        objFields.AddParameterFields("Prm_nExamSubId", System.Data.DbType.Int32, ExamSubId);
        objFields.AddParameterFields("Prm_nObtainedMark", System.Data.DbType.Int32, ObtainedMark);
        objFields.AddParameterFields("Prm_nAvgMark", System.Data.DbType.Int32, AvgMark);
        objFields.AddParameterFields("Prm_nObtainedGradeId", System.Data.DbType.Int32, ObtainedGradeId);
        objFields.AddParameterFields("Prm_nExamGradeId", System.Data.DbType.Int32, ExamGradeId);
        objFields.AddParameterFields("Prm_nExamCalculationId", System.Data.DbType.Int32, ExamCalculationId);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicMarkAssign", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicMarkAssign", objFields));
            return objRetArrList[0].ToString();
        }
    }
    public override void ObjectToRow(System.Data.DataRow dRow, string ObjPrmCls)
    {
        base.ObjectToRow(dRow, ObjPrmCls);
        dRow["Name"] = Name;
        dRow["Code"] = Code;
        dRow["ParentId"] = ParentId;
        dRow["Parent"] = Parent;
    }
    #endregion
}