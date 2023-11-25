using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsAcademicTermMaster : ClsCommonBaseMaster, IMasterCommands
{

    private int nParentId = 0, nOrderIndex = 0;

    public ClsAcademicTermMaster() : base("TblAcademicTermMaster", "ID", 0, 0, 0, 0)
    {
    }
    public ClsAcademicTermMaster(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblAcademicTermMaster", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
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

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProAcademicTermMaster", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProAcademicTermMaster", objFields));
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