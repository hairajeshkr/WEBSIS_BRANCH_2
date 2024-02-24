using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsStudMarkEntryWeb : ClsCommonBaseMaster, IMasterCommands
{

    private int nStaffId = 0, nPaperId = 0, nStudGroupId = 0, nExamId = 0, nStudentId = 0, nClassId = 0, nDivisionId = 0, nSyllabusId = 0, nExamSubId = 0, nMaxMark = 0, nWeightage = 0, nFinalMaxMark = 0;
    private int nStudStatus=0; 
    private DateTime dExamDate;
    private Boolean nMarkUploaded;
    private Decimal nMark = 0;

    public ClsStudMarkEntryWeb()
    : base("", "ID", 0, 0, 0, 0)
    {
    }
    public ClsStudMarkEntryWeb(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int StudStatus
    {
        get
        { return nStudStatus; }
        set
        { nStudStatus = value; }
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

    public Decimal Mark
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

    public int Weightage
    {
        get
        { return nWeightage; }
        set
        { nWeightage = value; }
    }

    public int FinalMaxMark
    {
        get
        { return nFinalMaxMark; }
        set
        { nFinalMaxMark = value; }
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
        //objFields.AddParameterFields("Prm_nSyllabusId", System.Data.DbType.Int32, SyllabusId);
        objFields.AddParameterFields("Prm_nMark", System.Data.DbType.Decimal, Mark);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, MaxMark);
        //objFields.AddParameterFields("Prm_dExamDate", System.Data.DbType.DateTime, ExamDate);
        objFields.AddParameterFields("Prm_nMarkUploaded", System.Data.DbType.Boolean, MarkUploaded);
        objFields.AddParameterFields("Prm_nStudentStatusId", System.Data.DbType.Int32, StudStatus);
        objFields.AddParameterFields("Prm_nTokenId", System.Data.DbType.Double, TokenNo);

        objFields.AddParameterFields("Prm_nWeightage", System.Data.DbType.Int32, Weightage);
        objFields.AddParameterFields("Prm_nFinalMaxMark", System.Data.DbType.Int32, FinalMaxMark);

        return objDBManager.GetRecord("ProStudentWebService", objFields) as DataSet;


        //if (PrmDbFlag.Equals("S"))
        //{

        //}
        //else
        //{
        //    ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProStudMarkEntry", objFields));
        //    return objRetArrList[0].ToString();
        //}
    }
    public override void ObjectToRow(System.Data.DataRow dRow, string ObjPrmCls)
    {

    }
    public DataTable FnUpdateStudentMarkEntry()
    {
        return (ManipulateData("MARK_ASGN") as DataSet).Tables[0];
    }
    #endregion
}