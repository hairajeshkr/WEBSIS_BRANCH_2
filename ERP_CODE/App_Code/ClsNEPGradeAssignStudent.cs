using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPGradeAssignStudent : ClsCommonBaseMaster, IMasterCommands
{

    private int nStaffId = 0, nPaperId = 0, nStudGroupId = 0, nExamId = 0, nStudentId = 0, nClassId = 0, nDivisionId = 0, nSyllabusId = 0, nExamSubId = 0, nMaxMark = 0, nStudStatusId=0;
    private int nMark = 0,nGradingSystemId=0,nGradeId=0;
    private DateTime dExamDate;
    private Boolean nMarkUploaded;


    public ClsNEPGradeAssignStudent() : base("TblAcademicMarkAssign", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPGradeAssignStudent(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicMarkAssign", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
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
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        StaffId = FnIsNumeric(drVal["StaffId"].ToString());
        ClassId = FnIsNumeric(drVal["ClassId"].ToString());
        DivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        StudentId = FnIsNumeric(drVal["StudentId"].ToString());
        ExamId = FnIsNumeric(drVal["ExamId"].ToString());
        ExamSubId = FnIsNumeric(drVal["ExamSubId"].ToString());
        PaperId = FnIsNumeric(drVal["PaperId"].ToString());
        StudGroupId = FnIsNumeric(drVal["StudGroupId"].ToString());
        SyllabusId = FnIsNumeric(drVal["SyllabusId"].ToString());

        ExamDate = FnDateTime(drVal["ExamDate"].ToString());

        Mark = FnIsNumeric(drVal["Mark"].ToString());
        MaxMark = FnIsNumeric(drVal["MaxMark"].ToString());
        MarkUploaded = FnIsBoolean(drVal["MarkUploaded"].ToString());


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
        objFields.AddParameterFields("Prm_nStudStatusId", System.Data.DbType.Int32, StudStatusId);
        objFields.AddParameterFields("Prm_nTokenId", System.Data.DbType.Double, TokenNo);

        objFields.AddParameterFields("Prm_nGradingSystemId", System.Data.DbType.Int32, GradingSystemId);
        objFields.AddParameterFields("Prm_nGradeId", System.Data.DbType.Int32, GradeId);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProNEPStudententGradeEntry", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProNEPStudententGradeEntry", objFields));
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