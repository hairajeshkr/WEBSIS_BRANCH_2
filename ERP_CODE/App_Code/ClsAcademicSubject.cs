using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicSubject : ClsCommonBaseMaster, IMasterCommands
{
    private string cName,cCode,cDisplayName;

    private int nParentId = 0, nOrderIndex = 0, nIsScholastic = 0, nIsOptional=0, nIsElective=0;
    public ClsAcademicSubject() : base("TblAcademicSubject", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicSubject(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicSubject", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int IsScholastic
    {
        get
        { return nIsScholastic; }
        set
        { nIsScholastic = value; }
    }
    public int IsOptional
    {
        get
        { return nIsOptional; }
        set
        { nIsOptional = value; }
    }
    public int IsElective
    {
        get
        { return nIsElective; }
        set
        { nIsElective = value; }
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
        DisplayName = drVal["DisplayName"].ToString().Trim();

        ParentId = FnIsNumeric(drVal["ParentId"].ToString());
        OrderIndex = FnIsNumeric(drVal["OrderIndex"].ToString());
        IsScholastic = FnIsNumeric(drVal["IsScholastic"].ToString());
        IsOptional = FnIsNumeric(drVal["IsOptional"].ToString());
        IsElective = FnIsNumeric(drVal["IsElective"].ToString());

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cDisplayName", System.Data.DbType.String, DisplayName);

        objFields.AddParameterFields("Prm_nParentId", System.Data.DbType.Int32, ParentId);
        objFields.AddParameterFields("Prm_nOrderIndex", System.Data.DbType.Int32, OrderIndex);
        objFields.AddParameterFields("Prm_nIsScholastic", System.Data.DbType.Int32, IsScholastic);
        objFields.AddParameterFields("Prm_nIsOptional", System.Data.DbType.Int32, IsOptional);
        objFields.AddParameterFields("Prm_nIsElective", System.Data.DbType.Int32, IsElective);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicSubject", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicSubject", objFields));
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