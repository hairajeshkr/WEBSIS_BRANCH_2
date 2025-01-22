using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;

public class ClsFeeAllocation : ClsCommonBaseMaster, IMasterCommands
{
    public int nNEPClassId = 0, nNEPDivisionId, nNEPGroupNID, nNEPStudentId;

    public ClsFeeAllocation() : base("", "ID", 0, 0, 0, 0)
    {
    }
    public ClsFeeAllocation(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPClassId
    {
        get
        { return nNEPClassId; }
        set
        { nNEPClassId = value; }
    }
    public int NEPDivisionId
    {
        get
        { return nNEPDivisionId; }
        set
        { nNEPDivisionId = value; }
    }
    public int GroupNID
    {
        get
        { return nNEPGroupNID; }
        set
        { nNEPGroupNID = value; }
    }
    public int NEPStudentId
    {
        get
        { return nNEPStudentId; }
        set
        { nNEPStudentId = value; }
    }
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        NEPClassId = FnIsNumeric(drVal["ClassId"].ToString());
        NEPDivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        GroupNID = FnIsNumeric(drVal["GroupID"].ToString());
        NEPStudentId = FnIsNumeric(drVal["Id"].ToString());
    }

    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_nTokenId", System.Data.DbType.Double, TokenNo);
        //objFields.AddParameterFields("Prm_nNEPClassId", System.Data.DbType.Int32, NEPClassId);
        //objFields.AddParameterFields("Prm_nNEPDivisionId", System.Data.DbType.Int32, NEPDivisionId);
        //objFields.AddParameterFields("Prm_GroupNID", System.Data.DbType.Int32, GroupNID);
        //objFields.AddParameterFields("Prm_StudentID", System.Data.DbType.Int32, NEPStudentId);
        

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProInsertFeeAllocationCommon2", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProInsertFeeAllocationCommon2", objFields));
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
}