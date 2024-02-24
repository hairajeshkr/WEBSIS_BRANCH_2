
using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPPapers : ClsCommonBaseMaster, IMasterCommands
{

    private int nNEPPaperID = 0, nExpired = 0, nNEPPaperGroupID = 0;
    private string cAbbreviation, cNEPPaperPrintName, cNEPPaperName, cNEPpaperCode;
    public string NEPPaperGroupName;


    public ClsNEPPapers() : base("TblNEPPapers", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPPapers(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblNEPPapers", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPPaperGroupID
    {
        get
        { return nNEPPaperGroupID; }
        set
        { nNEPPaperGroupID = value; }
    }
    public int Expired
    {
        get
        { return nExpired; }
        set
        { nExpired = value; }
    }
    public int NEPPaperID
    {
        get
        { return nNEPPaperID; }
        set
        { nNEPPaperID = value; }
    }
    
    public string Abbreviation
    {
        get
        { return cAbbreviation; }
        set
        { cAbbreviation = value; }
    }
    public string NEPPaperName
    {
        get
        { return cNEPPaperName; }
        set
        { cNEPPaperName = value; }
    }

    public string NEPpaperCode
    {
        get
        { return cNEPpaperCode; }
        set
        { cNEPpaperCode = value; }
    }
    public string NEPPaperPrintName
    {
        get
        { return cNEPPaperPrintName; }
        set
        { cNEPPaperPrintName = value; }
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
        Abbreviation = drVal["Abbreviation"].ToString().Trim();
        NEPPaperPrintName = drVal["PrintName"].ToString().Trim();
                
        NEPPaperGroupID = FnIsNumeric(drVal["PaperGroupID"].ToString());
        NEPPaperGroupName=drVal["PaperGroupName"].ToString().Trim();

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);

        objFields.AddParameterFields("Prm_cAbbreviation", System.Data.DbType.String, Abbreviation);
        objFields.AddParameterFields("Prm_cNEPPaperPrintName", System.Data.DbType.String, NEPPaperPrintName);
        
        objFields.AddParameterFields("Prm_nNEPPaperGroupID", System.Data.DbType.Int32, NEPPaperGroupID);
             
        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProPaperMaster", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProPaperMaster", objFields));
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