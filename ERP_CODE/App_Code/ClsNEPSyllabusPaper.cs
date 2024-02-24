using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;

public class ClsNEPSyllabusPaper : ClsCommonBaseMaster, IMasterCommands
{

    public int nNEPSubjectId = 0, nNEPPaperId, nCreditHrs,nNEPSyllabusId, ReportCId, TxtMaxMark=0,  TxtOrder=0,SyllabusId;
    public string cNEPSubjectName, LblPaperName, LblSubExam, LblPrintName, LblReport,GPaperName;
    public string PFlag="S1", SUBFlag ="D";
    public Decimal TxtPercentage = 0;

    public ClsNEPSyllabusPaper() : base("TblNEPSyllabusPapers", "ID", 0, 0, 0, 0)
    {
    }

    public ClsNEPSyllabusPaper(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
      : base("TblNEPSyllabusPapers", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }


    public int NEPSubjectId
    {
        get
        { return nNEPSubjectId; }
        set
        { nNEPSubjectId = value; }
    }
    public int NEPPaperId
    {
        get
        { return nNEPPaperId; }
        set
        { nNEPPaperId = value; }
    }
    public int NEPSyllabusId
    {
        get
        { return nNEPSyllabusId; }
        set
        { nNEPSyllabusId = value; }
    }
    public int CreditHrs
    {
        get
        { return nCreditHrs; }
        set
        { nCreditHrs = value; }
    }
    public String NEPSubjectName
    {
        get
        { return cNEPSubjectName; }
        set
        { cNEPSubjectName = value; }
    }
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];
              
        NEPSubjectId = FnIsNumeric(drVal["NEPSubjectId"].ToString());
        NEPPaperId = FnIsNumeric(drVal["NEPPaperId"].ToString());
        CreditHrs= FnIsNumeric(drVal["CreditHrs"].ToString());

    }

    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

       
        objFields.AddParameterFields("Prm_nNEPSubjectId", System.Data.DbType.Int32, NEPSubjectId);
        objFields.AddParameterFields("Prm_nNEPPaperId", System.Data.DbType.Int32, NEPPaperId);
        objFields.AddParameterFields("Prm_nNEPSyllabusId", System.Data.DbType.Int32, SyllabusId);
        objFields.AddParameterFields("Prm_cGPaperName", System.Data.DbType.String, GPaperName);
        objFields.AddParameterFields("Prm_nCreditHrs", System.Data.DbType.Int32, CreditHrs);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, PFlag);
        objFields.AddParameterFields("Prm_nNEPReportColumnId", System.Data.DbType.String, ReportCId);
        objFields.AddParameterFields("Prm_cSubExamName", System.Data.DbType.String, LblSubExam);
        objFields.AddParameterFields("Prm_cPrintName", System.Data.DbType.String, LblPrintName);
        objFields.AddParameterFields("Prm_nMaxMark", System.Data.DbType.Int32, TxtMaxMark);
        objFields.AddParameterFields("Prm_nPercentage", System.Data.DbType.Decimal, TxtPercentage);
        objFields.AddParameterFields("Prm_nDisplayOrder", System.Data.DbType.Int32, TxtOrder);
        objFields.AddParameterFields("Prm_SUBFlag", System.Data.DbType.String, SUBFlag);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProSyllabusPaper", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProSyllabusPaper", objFields));
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