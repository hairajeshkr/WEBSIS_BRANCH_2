using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPExamTemplate : ClsCommonBaseMaster, IMasterCommands
{

    private int nNEPExamTemplateID = 0, nNEPPaperGroupID = 0, nNEPExamTemplateDetailID=0;
    private int  nNEPRptColumnID=0, nMaxMark=0, nPercentage=0, nDisplayOrder=0;
    private string cNEPTemplateName, cSubExamName;
    private bool nDefaultTemplate;
    public string cFlag, NEPPaperGroupName;
    public int nFlag;

    public ClsNEPExamTemplate() : base("TblNEPExamTemplate", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPExamTemplate(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblNEPExamTemplate", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPPaperGroupID
    {
        get
        { return nNEPPaperGroupID; }
        set
        { nNEPPaperGroupID = value; }
    }
   
    public int NEPExamTemplateID
    {
        get
        { return nNEPExamTemplateID; }
        set
        { nNEPExamTemplateID = value; }
    }
    public bool DefaultTemplate
    {
        get
        { return nDefaultTemplate; }
        set
        { nDefaultTemplate = value; }
    }

    public int NEPExamTemplateDetailID
    {
        get
        { return nNEPExamTemplateDetailID; }
        set
        { nNEPExamTemplateDetailID = value; }
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
    public int DisplayOrder
    {
        get
        { return nDisplayOrder; }
        set
        { nDisplayOrder = value; }
    }
    public string NEPTemplateName
    {
        get
        { return cNEPTemplateName; }
        set
        { cNEPTemplateName = value; }
    }
    public string SubExamName
    {
        get
        { return cSubExamName; }
        set
        { cSubExamName = value; }
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
        SubExamName = drVal["SubExamName"].ToString().Trim();
             
        
        DefaultTemplate = FnIsBoolean(drVal["DefaultTemplate"].ToString());
       
        NEPRptColumnID = FnIsNumeric(drVal["RptColumnID"].ToString());
        MaxMark = FnIsNumeric(drVal["MaxMark"].ToString());
        Percentage = FnIsNumeric(drVal["Percentage"].ToString());
        DisplayOrder = FnIsNumeric(drVal["DisplayOrder"].ToString());
        //NEPPaperGroupID = FnIsNumeric(drVal["PaperGroupID"].ToString());
        NEPPaperGroupID = 6;
        cFlag = "ss";
        //ID= FnIsNumeric(drVal["ID"].ToString());
        NEPPaperGroupName= drVal["PaperGroupName"].ToString().Trim();

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code); 
        objFields.AddParameterFields("Prm_cSubExamName", System.Data.DbType.String, SubExamName);

        objFields.AddParameterFields("Prm_nDefaultTemplate", System.Data.DbType.Int32, DefaultTemplate);
        objFields.AddParameterFields("Prm_nNEPRptColumnID", System.Data.DbType.Int32, NEPRptColumnID);

        objFields.AddParameterFields("Prm_nNEPPaperGroupID", System.Data.DbType.Int32, nNEPPaperGroupID);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, MaxMark);
        objFields.AddParameterFields("Prm_nPercentage", System.Data.DbType.Int32, Percentage);
        objFields.AddParameterFields("Prm_nDisplayOrder", System.Data.DbType.Int32, DisplayOrder);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, cFlag);
        objFields.AddParameterFields("Prm_cFFlag", System.Data.DbType.String, nFlag);
        //objFields.AddParameterFields("Prm_nId", System.Data.DbType.Int32, ID);


        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProExamTemplate", objFields) as DataSet; 
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProExamTemplate", objFields));
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