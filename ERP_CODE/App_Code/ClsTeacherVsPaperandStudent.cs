
using System;
using LOTUS_DATA;
using LOTUS_GENERAL;
using System.Collections;
using System.Data;

public class ClsTeacherVsPaperandStudent : ClsCommonBaseMaster, IMasterCommands
{

    public int nNEPTeacherId = 0, cNEPPaperId, nSelect, nDdlPapers, nDdlClass, nDdlDivision, nCrditHrs, nDdlSubject, CFlag,IsCustomClass;
    public string  cGroupName, NEPExamTemplateName, NEPGradingName, NEPTeacherName, NEPPaperName;
    public string PFlag;

    public ClsTeacherVsPaperandStudent() : base("TblNEPTeacherPaper", "ID", 0, 0, 0, 0)
    {
        
    }

    public ClsTeacherVsPaperandStudent(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
       : base("TblNEPTeacherPaper", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }

    public int NEPTeacherId
    {
        get
        { return nNEPTeacherId; }
        set
        { nNEPTeacherId = value; }
    }

    public int NEPPaperId
    {
        get
        { return nNEPTeacherId; }
        set
        { nNEPTeacherId = value; }
    }
    public int DdlClass
    {
        get
        { return nDdlClass; }
        set
        { nDdlClass = value; }
    }
    public int DdlDivision
    {
        get
        { return nDdlDivision; }
        set
        { nDdlDivision = value; }
    }

    public string GroupName
    {
        get
        { return cGroupName; }
        set
        { cGroupName = value; }
    }

    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        NEPTeacherId = FnIsNumeric(drVal["TeacherId"].ToString());
        NEPTeacherName = drVal["TeacherName"].ToString().Trim();
        NEPPaperId = FnIsNumeric(drVal["PaperId"].ToString());
        NEPPaperName = drVal["NEPPaperName"].ToString().Trim();
        DdlClass = FnIsNumeric(drVal["ClassId"].ToString());
        ClassName = drVal["ClassName"].ToString();
        DdlDivision = FnIsNumeric(drVal["DivisionId"].ToString());
        DivisionName = drVal["DivisionName"].ToString();
        GroupName = drVal["GroupName"].ToString();
       
    }

    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_nNEPTeacherId", System.Data.DbType.String, nNEPTeacherId);
        objFields.AddParameterFields("Prm_nNEPPaperId", System.Data.DbType.String, nDdlPapers);
        objFields.AddParameterFields("Prm_nNEPClassId", System.Data.DbType.String, nDdlClass);
        objFields.AddParameterFields("Prm_nNEPDivisionId", System.Data.DbType.Int32, DdlDivision);
        objFields.AddParameterFields("Prm_nNEPStudentGroupName", System.Data.DbType.String, GroupName);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, PFlag);
        objFields.AddParameterFields("Prm_nIsCustomClassFlag", System.Data.DbType.String, IsCustomClass);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProTeacherPaperStudent", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProTeacherPaperStudent", objFields));
            return objRetArrList[0].ToString();
        }
    }

}