using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsNEPSyllabus : ClsCommonBaseMaster, IMasterCommands
{

    private int nNEPPaperGroupId=0, nGradeId, nElective, nOptional, nDisplayOrder, nNEPExamTempalteId,nCrditHrs, nDdlSubject;
    public string cNEPSubjectName, cNEPPaperName, PaperGroupName, NEPExamTemplateName, NEPGradingName;
    public string PFlag;
    public int CFlag, HdnSubjId;
    public ClsNEPSyllabus() : base("TblNEPSyllabus", "ID", 0, 0, 0, 0)
    {
    }
    public ClsNEPSyllabus(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblNEPSyllabus", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPPaperGroupID
    {
        get
        { return nNEPPaperGroupId; }
        set
        { nNEPPaperGroupId = value; }
    }
    public int GradeId
    {
        get
        { return nGradeId; }
        set
        { nGradeId = value; }
    }
    public int Elective
    {
        get
        { return nElective; }
        set
        { nElective = value; }
    }
    public int Optional
    {
        get
        { return nOptional; }
        set
        { nOptional = value; }
    }
    public int DisplayOrder
    {
        get
        { return nDisplayOrder; }
        set
        { nDisplayOrder = value; }
    }
    public int NEPExamTempalteId
    {
        get
        { return nNEPExamTempalteId; }
        set
        { nNEPExamTempalteId = value; }
    }
    public string NEPSubjectName
    {
        get
        { return cNEPSubjectName; }
        set
        { cNEPSubjectName = value; }
    }
    public string NEPPaperName
    {
        get
        { return cNEPPaperName; }
        set
        { cNEPPaperName = value; }
    }
    public int NEPCreditHrs
    {
        get
        { return nCrditHrs; }
        set
        { nCrditHrs = value; }
    }

    public int NEPDdlSubject
    {
        get
        { return nDdlSubject; }
        set
        { nDdlSubject = value; }
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
        NEPPaperGroupID = FnIsNumeric(drVal["PaperGroupID"].ToString());
        PaperGroupName = drVal["PaperGroupName"].ToString();
        GradeId = FnIsNumeric(drVal["GradeId"].ToString());
        NEPGradingName = drVal["NEPGradingName"].ToString();
        Elective = FnIsNumeric(drVal["Elective"].ToString());
        Optional = FnIsNumeric(drVal["Optional"].ToString());
        DisplayOrder = FnIsNumeric(drVal["DisplayOrder"].ToString());
        NEPExamTempalteId = FnIsNumeric(drVal["NEPExamTemplateId"].ToString());
        NEPExamTemplateName = drVal["NEPExamTemplateName"].ToString();
    }

   

    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cNEPSubjectName", System.Data.DbType.String, NEPSubjectName);
        objFields.AddParameterFields("Prm_nNEPSubjectId", System.Data.DbType.Int32, HdnSubjId);
        objFields.AddParameterFields("Prm_cNEPPaperName", System.Data.DbType.String, NEPPaperName);

        objFields.AddParameterFields("Prm_nNEPPaperGroupID", System.Data.DbType.Int32, NEPPaperGroupID);
        objFields.AddParameterFields("Prm_nGradeId", System.Data.DbType.Int32, GradeId);
        objFields.AddParameterFields("Prm_nElective", System.Data.DbType.Int32, Elective);
        objFields.AddParameterFields("Prm_nOptional", System.Data.DbType.Int32, Optional);
        objFields.AddParameterFields("Prm_nDisplayOrder", System.Data.DbType.Int32, DisplayOrder);
        objFields.AddParameterFields("Prm_nNEPExamTempalteId", System.Data.DbType.Int32, NEPExamTempalteId);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, PFlag);
        objFields.AddParameterFields("Prm_cFFlag", System.Data.DbType.String, CFlag);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProSyllabus", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProSyllabus", objFields));
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