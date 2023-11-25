using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicStaffAssign : ClsCommonBaseMaster, IMasterCommands
{
    
    private int nStaffId=0,nInstGrpId = 0, nClassId = 0, nDivisionId=0, nSubjectId = 0;
    public ClsAcademicStaffAssign() : base("TblAcademicStaffAssign", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicStaffAssign(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicStaffAssign", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
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
        InstGrpId = FnIsNumeric(drVal["InstGrpId"].ToString());
        ClassId = FnIsNumeric(drVal["ClassId"].ToString());
        DivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        SubjectId = FnIsNumeric(drVal["SubjectId"].ToString());       

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_nStaffId", System.Data.DbType.Int32, StaffId);
        objFields.AddParameterFields("Prm_nInstGrpId", System.Data.DbType.Int32, InstGrpId);
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId);
        objFields.AddParameterFields("Prm_nDivisionId", System.Data.DbType.Int32, DivisionId);
        objFields.AddParameterFields("Prm_nSubjectId", System.Data.DbType.Int32, SubjectId);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicStaffAssign", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicStaffAssign", objFields));
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