using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPStudentGradeEntryWeb:ClsCommonBaseMaster, IMasterCommands
{

    private int nStaffId = 0, nPaperId = 0, nStudGroupId = 0, nExamId = 0, nStudentId = 0, nClassId = 0, nDivisionId = 0, nSyllabusId = 0, nExamSubId = 0, nMaxMark = 0, nStudStatusId = 0;
    private int nMark = 0, nGradingSystemId = 0, nGradeId = 0;
    private DateTime dExamDate;
    private Boolean nMarkUploaded;

    public ClsNEPStudentGradeEntryWeb()
    : base("", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPStudentGradeEntryWeb(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
     }
    public int GradeId
    {
        get
        { return nGradeId; }
        set
        { nGradeId = value; }
    }


    public int GradingSystemId
    {
        get
        { return nGradingSystemId; }
        set
        { nGradingSystemId = value; }
    }
    public int StudStatusId
    {
        get
        { return nStudStatusId; }
        set
        { nStudStatusId = value; }
    }
    public Boolean MarkUploaded
    {
        get
        { return nMarkUploaded; }
        set
        { nMarkUploaded = value; }
    }
    public DateTime ExamDate
    {
        get
        { return dExamDate; }
        set
        { dExamDate = value; }
    }
    public int StaffId
    {
        get
        { return nStaffId; }
        set
        { nStaffId = value; }
    }
    public int PaperId
    {
        get
        { return nPaperId; }
        set
        { nPaperId = value; }
    }
    public int StudGroupId
    {
        get
        { return nStudGroupId; }
        set
        { nStudGroupId = value; }
    }

    public int ExamId
    {
        get
        { return nExamId; }
        set
        { nExamId = value; }
    }
    public int SyllabusId
    {
        get
        { return nSyllabusId; }
        set
        { nSyllabusId = value; }
    }
    public int ExamSubId
    {
        get
        { return nExamSubId; }
        set
        { nExamSubId = value; }
    }

    public int Mark
    {
        get
        { return nMark; }
        set
        { nMark = value; }
    }
    public int MaxMark
    {
        get
        { return nMaxMark; }
        set
        { nMaxMark = value; }
    }
    #region IMasterCommands Members
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
      throw new Exception("The method or operation is not implemented.");
    }
    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {

    }
   public override object ManipulateData(string PrmDbFlag)
   {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_nStaffId", System.Data.DbType.Int32, StaffId);
        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId);
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId);
        objFields.AddParameterFields("Prm_nDivisionId", System.Data.DbType.Int32, DivisionId);
        objFields.AddParameterFields("Prm_nExamId", System.Data.DbType.Int32, ExamId);
        objFields.AddParameterFields("Prm_nExamSubId", System.Data.DbType.Int32, ExamSubId);
        objFields.AddParameterFields("Prm_nPaperId", System.Data.DbType.Int32, PaperId);
        objFields.AddParameterFields("Prm_nStudGroupId", System.Data.DbType.Int32, StudGroupId);
        objFields.AddParameterFields("Prm_nMarkUploaded", System.Data.DbType.Boolean, MarkUploaded);
        objFields.AddParameterFields("Prm_nStudentStatusId", System.Data.DbType.Int32, StudStatusId);
        objFields.AddParameterFields("Prm_nTokenId", System.Data.DbType.Double, TokenNo);

        objFields.AddParameterFields("Prm_nGradingSystemId", System.Data.DbType.Int32, GradingSystemId);
        objFields.AddParameterFields("Prm_nGradeId", System.Data.DbType.Int32, GradeId);

        return objDBManager.GetRecord("ProStudentWebService", objFields) as DataSet;


   }
   public override void ObjectToRow(System.Data.DataRow dRow, string ObjPrmCls)
   {

   }
  public DataTable FnUpdateStudentGradeEntry()
  {
    return (ManipulateData("GRADE_ASGN") as DataSet).Tables[0];
  }
    #endregion
}