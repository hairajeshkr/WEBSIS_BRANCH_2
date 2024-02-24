
using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPPaperGroup : ClsCommonBaseMaster, IMasterCommands
{

    private int nNEPPaperGroupID = 0,  nExpired = 0, nIsScholastic = 0, nNEPRptColumnID = 0, nMaxMark = 0;
    private int nPercentage=0, nWeightage = 0, nInputType=0, nDisplayOrder=0;
    private string cAbbreviation, cNEPPaperGroupName, cNEPpaperGroupCode, cNEPRptColumnName, cRptAbbreviation;
    public string PFlag;
    public int CFlag;
    public ClsNEPPaperGroup() : base("TblNEPPaperGroup", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPPaperGroup(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblNEPPaperGroup", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
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
    public int IsScholastic
    {
        get
        { return nIsScholastic; }
        set
        { nIsScholastic = value; }
    }
    public int NEPRptColumnID
    {
        get
        { return nNEPRptColumnID; }
        set
        { nNEPRptColumnID = value; }
    }
    public int MaxMark
    {
        get
        { return nMaxMark; }
        set
        { nMaxMark = value; }
    }
    public int Percentage
    {
        get
        { return nPercentage; }
        set
        { nPercentage = value; }
    }
    public int Weightage
    {
        get
        { return nWeightage; }
        set
        { nWeightage = value; }
    }
    public int InputType
    {
        get
        { return nInputType; }
        set
        { nInputType = value; }
    }
    public int DisplayOrder
    {
        get
        { return nDisplayOrder; }
        set
        { nDisplayOrder = value; }
    }
    public string Abbreviation
    {
        get
        { return cAbbreviation; }
        set
        { cAbbreviation = value; }
    }
    public string NEPPaperGroupName
    {
        get
        { return cNEPPaperGroupName; }
        set
        { cNEPPaperGroupName = value; }
    }
    public string NEPpaperGroupCode
    {
        get
        { return cNEPpaperGroupCode; }
        set
        { cNEPpaperGroupCode = value; }
    }
    public string NEPRptColumnName
    {
        get
        { return cNEPRptColumnName; }
        set
        { cNEPRptColumnName = value; }
    }
    public string RptAbbreviation
    {
        get
        { return cRptAbbreviation; }
        set
        { cRptAbbreviation = value; }
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
        
    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;
        
        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cAbbreviation", System.Data.DbType.String, Abbreviation);
        objFields.AddParameterFields("Prm_cNEPRptColumnName", System.Data.DbType.String, NEPRptColumnName);
        objFields.AddParameterFields("Prm_cRptAbbreviation", System.Data.DbType.String, RptAbbreviation);


        objFields.AddParameterFields("Prm_nIsScholastic", System.Data.DbType.Int32, IsScholastic);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, MaxMark);
        objFields.AddParameterFields("Prm_nPercentage", System.Data.DbType.Int32, Percentage);
        objFields.AddParameterFields("Prm_nWeightage", System.Data.DbType.Int32, Weightage);
        objFields.AddParameterFields("Prm_nInputType", System.Data.DbType.Int32, InputType);
        objFields.AddParameterFields("Prm_nDisplayOrder", System.Data.DbType.Int32, DisplayOrder);

        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, PFlag);
        objFields.AddParameterFields("Prm_cFFlag", System.Data.DbType.String, CFlag);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProPaperGroup", objFields) as DataSet;
            
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProPaperGroup", objFields));
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