using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPGradeMaster : ClsCommonBaseMaster, IMasterCommands
{

    private int nNEPGradeID = 0, nNEPRangeFrom = 0, nNEPRangeTo = 0, nNEPGradePoint = 0, nFailed = 0;
    private int nNEPGradingID = 0, nNEPGradeForOneByEight = 0, nExpired = 0, nDisplayOrder = 0;
    private string cNEPGrade, cNEPGradingName, cNEPPaperPrintName, cNEPRemarks;
    public string cFlag = "";
    public int nFlag;
    public ClsNEPGradeMaster() : base("TblNEPGradeMaster", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPGradeMaster(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblNEPGradeMaster", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPGradeID
    {
        get
        { return nNEPGradeID; }
        set
        { nNEPGradeID = value; }
    }
    public int NEPRangeFrom
    {
        get
        { return nNEPRangeFrom; }
        set
        { nNEPRangeFrom = value; }
    }
    public int NEPRangeTo
    {
        get
        { return nNEPRangeTo; }
        set
        { nNEPRangeTo = value; }
    }
    public int NEPGradePoint
    {
        get
        { return nNEPGradePoint; }
        set
        { nNEPGradePoint = value; }
    }
    public int Failed
    {
        get
        { return nFailed; }
        set
        { nFailed = value; }
    }
    public int NEPGradingID
    {
        get
        { return nNEPGradingID; }
        set
        { nNEPGradingID = value; }
    }
    public int NEPGradeForOneByEight
    {
        get
        { return nNEPGradeForOneByEight; }
        set
        { nNEPGradeForOneByEight = value; }
    }
    public int Expired
    {
        get
        { return nExpired; }
        set
        { nExpired = value; }
    }
    public int DisplayOrder
    {
        get
        { return nDisplayOrder; }
        set
        { nDisplayOrder = value; }
    }

    public string NEPGrade
    {
        get
        { return cNEPGrade; }
        set
        { cNEPGrade = value; }
    }
    public string NEPGradingName
    {
        get
        { return cNEPGradingName; }
        set
        { cNEPGradingName = value; }
    }
    public string NEPPaperPrintName
    {
        get
        { return cNEPPaperPrintName; }
        set
        { cNEPPaperPrintName = value; }
    }
     public string NEPRemarks
    {
        get
        { return cNEPRemarks; }
        set
        { cNEPRemarks = value; }
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
        NEPGrade = drVal["Grade"].ToString().Trim();//grid grade
        NEPRemarks= drVal["GRemarks"].ToString().Trim();

        NEPRangeFrom = FnIsNumeric(drVal["RangeFrom"].ToString());
        NEPRangeTo = FnIsNumeric(drVal["RangeTo"].ToString());
        NEPGradePoint = FnIsNumeric(drVal["GradePoint"].ToString());
        Failed = FnIsNumeric(drVal["Failed"].ToString());
        NEPGradeForOneByEight = FnIsNumeric(drVal["GradeForOneByEight"].ToString());
        DisplayOrder = FnIsNumeric(drVal["nDisplayOrder"].ToString()); 


}
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cNEPGrade", System.Data.DbType.String, NEPGrade);
        objFields.AddParameterFields("Prm_cNEPRemarks", System.Data.DbType.String, NEPRemarks);

        objFields.AddParameterFields("Prm_nNEPRangeFrom", System.Data.DbType.Int32, NEPRangeFrom);
        objFields.AddParameterFields("Prm_nNEPRangeTo", System.Data.DbType.Int32, NEPRangeTo);
        objFields.AddParameterFields("Prm_nNEPGradePoint", System.Data.DbType.Int32, NEPGradePoint);
        objFields.AddParameterFields("Prm_nFailed", System.Data.DbType.Int32, Failed);
        objFields.AddParameterFields("Prm_nNEPGradeForOneByEight", System.Data.DbType.Int32, NEPGradeForOneByEight);   
        objFields.AddParameterFields("Prm_nDisplayOrder", System.Data.DbType.Int32, DisplayOrder);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, cFlag);
        objFields.AddParameterFields("Prm_cFFlag", System.Data.DbType.String, nFlag);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProGradeMaster", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProGradeMaster", objFields));
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