using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicExamMaster : ClsCommonBaseMaster, IMasterCommands
{

    private int nParentId = 0, nOrderIndex=0, nMinMark=0, nMaxMark=0, nExamGradeId=0;

    private string cOtherDetails;
    public ClsAcademicExamMaster() : base("TblAcademicExamMaster", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicExamMaster(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicExamMaster", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }

    public string OtherDetails
    {
        get
        { return cOtherDetails; }
        set
        { cOtherDetails = value; }
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

        Name = drVal["Name"].ToString().Trim();
        Code = drVal["Code"].ToString().Trim();

        OtherDetails = drVal["OtherDetails"].ToString().Trim();

        ParentId = FnIsNumeric(drVal["ParentId"].ToString());
        OrderIndex = FnIsNumeric(drVal["OrderIndex"].ToString());
        MinMark = FnIsNumeric(drVal["MinMark"].ToString());
        MaxMark = FnIsNumeric(drVal["MaxMark"].ToString());
        ExamGradeId = FnIsNumeric(drVal["ExamGradeId"].ToString());

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);

        objFields.AddParameterFields("Prm_nParentId", System.Data.DbType.Int32, ParentId);
        objFields.AddParameterFields("Prm_nOrderIndex", System.Data.DbType.Int32, OrderIndex);
        objFields.AddParameterFields("Prm_nMinMark", System.Data.DbType.Int32, MinMark);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, MaxMark);
        objFields.AddParameterFields("Prm_nExamGradeId", System.Data.DbType.Int32, ExamGradeId);

        objFields.AddParameterFields("Prm_cOtherDetails", System.Data.DbType.String, OtherDetails);
  

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicExamMaster", objFields) as DataSet;
        }
        else 
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicExamMaster", objFields));
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