using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicExamAssign : ClsCommonBaseMaster, IMasterCommands
{
    
    private int nInstGrpId = 0, nClassId = 0, nSubjectId = 0, nExamId = 0, nExamSubId = 0, nOrderIndex = 0, nMinMark = 0, nMaxMark = 0, nExamGradeId = 0;
    public ClsAcademicExamAssign() : base("TblAcademicExamAssign", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicExamAssign(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicExamAssign", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
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
    public int MinMark
    {
        get
        { return nMinMark; }
        set
        { nMinMark = value; }
    }
    public int MaxMark
    {
        get
        { return nMaxMark; }
        set
        { nMaxMark = value; }
    }
    public int ExamGradeId
    {
        get
        { return nExamGradeId; }
        set
        { nExamGradeId = value; }
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

        InstGrpId = FnIsNumeric(drVal["InstGrpId"].ToString());
        ClassId = FnIsNumeric(drVal["ClassId"].ToString());
        SubjectId = FnIsNumeric(drVal["SubjectId"].ToString());
        ExamId = FnIsNumeric(drVal["ExamId"].ToString());
        ExamSubId = FnIsNumeric(drVal["ExamSubId"].ToString());
        OrderIndex = FnIsNumeric(drVal["OrderIndex"].ToString());
        MinMark = FnIsNumeric(drVal["MinMark"].ToString());
        MaxMark = FnIsNumeric(drVal["MaxMark"].ToString());
        ExamGradeId = FnIsNumeric(drVal["MaxMark"].ToString());

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_nInstGrpId", System.Data.DbType.Int32, InstGrpId);
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId);
        objFields.AddParameterFields("Prm_nSubjectId", System.Data.DbType.Int32, SubjectId);
        objFields.AddParameterFields("Prm_nExamId", System.Data.DbType.Int32, ExamId);
        objFields.AddParameterFields("Prm_nExamSubId", System.Data.DbType.Int32, ExamSubId);
        objFields.AddParameterFields("Prm_nOrderIndex", System.Data.DbType.Int32, OrderIndex);
        objFields.AddParameterFields("Prm_nMinMark", System.Data.DbType.Int32, MinMark);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, MaxMark);
        objFields.AddParameterFields("Prm_nExamGradeId", System.Data.DbType.Int32, ExamGradeId);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicExamAssign", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicExamAssign", objFields));
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