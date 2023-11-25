using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicGradeMaster : ClsCommonBaseMaster, IMasterCommands
{

    private string cRangeFrom, cRangeTo;

    private int nParentId = 0, nOrderIndex = 0, nGradePoint=0;

    public ClsAcademicGradeMaster() : base("TblAcademicGradeMaster", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicGradeMaster(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicGradeMaster", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }

    public string RangeFrom
    {
        get
        { return cRangeFrom; }
        set
        { cRangeFrom = value; }
    }
    public string RangeTo
    {
        get
        { return cRangeTo; }
        set
        { cRangeTo = value; }
    }
    public int GradePoint
    {
        get
        { return nGradePoint; }
        set
        { nGradePoint = value; }
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

        ParentId = FnIsNumeric(drVal["ParentId"].ToString());
        OrderIndex = FnIsNumeric(drVal["OrderIndex"].ToString());
        GradePoint = FnIsNumeric(drVal["GradePoint"].ToString());

        RangeFrom = drVal["RangeFrom"].ToString().Trim();
        RangeTo= drVal["RangeTo"].ToString().Trim();

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
        objFields.AddParameterFields("Prm_nGradePoint", System.Data.DbType.Int32, GradePoint);

        objFields.AddParameterFields("Prm_cRangeFrom", System.Data.DbType.String, RangeFrom);
        objFields.AddParameterFields("Prm_cRangeTo", System.Data.DbType.String, RangeTo);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicGradeMaster", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicGradeMaster", objFields));
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