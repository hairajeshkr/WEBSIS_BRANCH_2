using System;

using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsStudentAssign : ClsCommonBaseMaster, IMasterCommands
{

    private int  nStudentId = 0, nSaluationId, nFatherSaluationId, nMotherSaluationId, nGuardianSaluationId,nId;
    private int nRollNo = 0;

    private string cSaluationName, cFatherSaluationName, cMotherSaluationName, cGuardianSaluationName, cFatherName, cMotherName, cGuardianName, cMobNo, cName, cAdmissionNo;
    private string cFatherMobNo,cMotherMobNo,cGuardianMobNo,cStudentCode;

    public ClsStudentAssign() : base("TblRegistrationStudent", "ID", 0, 0, 0, 0)
    {
    }
    public ClsStudentAssign(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblRegistrationStudent", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public string SaluationName
    {
        get
        { return cSaluationName; }
        set
        { cSaluationName = value; }
    }
    public string FatherSaluationName
    {
        get
        { return cFatherSaluationName; }
        set
        { cFatherSaluationName = value; }
    }
    public string MotherSaluationName
    {
        get
        { return cMotherSaluationName; }
        set
        { cMotherSaluationName = value; }
    }
    public string GuardianSaluationName
    {
        get
        { return cGuardianSaluationName; }
        set
        { cGuardianSaluationName = value; }
    }
    public int SaluationId
    {
        get
        { return nSaluationId; }
        set
        { nSaluationId = value; }
    }
    public int FatherSaluationId
    {
        get
        { return nFatherSaluationId; }
        set
        { nFatherSaluationId = value; }
    }
    public int MotherSaluationId
    {
        get
        { return nMotherSaluationId; }
        set
        { nMotherSaluationId = value; }
    }
    public int GuardianSaluationId
    {
        get
        { return nGuardianSaluationId; }
        set
        { nGuardianSaluationId = value; }
    }
    
    public int RollNo
    {
        get
        { return nRollNo; }
        set
        { nRollNo = value; }
    }
    public string FatherName
    {
        get
        { return cFatherName; }
        set
        { cFatherName = value; }
    }
    public string MotherName
    {
        get
        { return cMotherName; }
        set
        { cMotherName = value; }
    }
    public string GuardianName
    {
        get
        { return cGuardianName; }
        set
        { cGuardianName = value; }
    }
    public string FatherMobNo
    {
        get
        { return cFatherMobNo; }
        set
        { cFatherMobNo = value; }
    }
    public string MotherMobNo
    {
        get
        { return cMotherMobNo; }
        set
        { cMotherMobNo = value; }
    }
    public string GuardianMobNo
    {
        get
        { return cGuardianMobNo; }
        set
        { cGuardianMobNo = value; }
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

        //ParentId = FnIsNumeric(drVal["ParentId"].ToString());
        Name = drVal["Name"].ToString().Trim();
        Code = drVal["Code"].ToString().Trim();
        DisplayName = drVal["DisplayName"].ToString().Trim();
        StudentCode= drVal["StudentCode"].ToString().Trim();

        FatherName = drVal["FatherName"].ToString().Trim();
        MotherName = drVal["MotherName"].ToString().Trim();
        GuardianName = drVal["GuardianName"].ToString().Trim();

        ID= StudentId = FnIsNumeric(drVal["ID"].ToString());
        StudentId = FnIsNumeric(drVal["StudentId"].ToString());
        InstituteId = FnIsNumeric(drVal["InstituteId"].ToString());
        ClassId = FnIsNumeric(drVal["ClassId"].ToString());
        DivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        SaluationId = FnIsNumeric(drVal["SaluationId"].ToString());
        FatherSaluationId = FnIsNumeric(drVal["FatherSaluationId"].ToString());
        MotherSaluationId = FnIsNumeric(drVal["MotherSaluationId"].ToString());
        GuardianSaluationId = FnIsNumeric(drVal["GuardianSaluationId"].ToString());

        //SaluationName= drVal["SaluationName"].ToString().Trim();
        //FatherSaluationName= drVal["FatherSaluationName"].ToString().Trim();
        //MotherSaluationName= drVal["MotherSaluationName"].ToString().Trim();
        //GuardianSaluationName= drVal["GuardianSaluationName"].ToString().Trim();


        AdmissionNo = drVal["AdmissionNo"].ToString().Trim();
        //RollNo = FnIsNumeric(drVal["RollNo"].ToString());
        MobNo = drVal["MobNo"].ToString().Trim();
        FatherMobNo= drVal["FatherMobNo"].ToString().Trim();
        MotherMobNo = drVal["MotherMobNo"].ToString().Trim();
        GuardianMobNo = drVal["GuardianMobNo"].ToString().Trim();

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        //objFields.AddParameterFields("Prm_cRegNo", System.Data.DbType.String, RegNo);

        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cDisplayName", System.Data.DbType.String, DisplayName);

        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId);
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId);
        objFields.AddParameterFields("Prm_nDivisionId", System.Data.DbType.Int32, DivisionId);
        objFields.AddParameterFields("Prm_nInstituteId", System.Data.DbType.Int32, InstituteId);
        objFields.AddParameterFields("Prm_nSaluationId", System.Data.DbType.Int32, SaluationId);
        objFields.AddParameterFields("Prm_nFatherSaluationId", System.Data.DbType.Int32, FatherSaluationId);
        objFields.AddParameterFields("Prm_nMotherSaluationId", System.Data.DbType.Int32, MotherSaluationId);
        objFields.AddParameterFields("Prm_nGuardianSaluationId", System.Data.DbType.Int32, GuardianSaluationId);
        //objFields.AddParameterFields("Prm_nRollNo", System.Data.DbType.Int32, RollNo);

        objFields.AddParameterFields("Prm_cFatherName", System.Data.DbType.String, FatherName);
        objFields.AddParameterFields("Prm_cMotherName", System.Data.DbType.String, MotherName);
        objFields.AddParameterFields("Prm_cGuardianName ", System.Data.DbType.String, GuardianName);
        objFields.AddParameterFields("Prm_cMobNo", System.Data.DbType.String, MobNo);
        objFields.AddParameterFields("Prm_cFatherMobNo", System.Data.DbType.String, FatherMobNo);
        objFields.AddParameterFields("Prm_cMotherMobNo", System.Data.DbType.String, MotherMobNo);
        objFields.AddParameterFields("Prm_cGuardianMobNo", System.Data.DbType.String, GuardianMobNo);


        objFields.AddParameterFields("Prm_cAdmissionNo", System.Data.DbType.String, AdmissionNo);
        objFields.AddParameterFields("Prm_cStudentCode", System.Data.DbType.String, StudentCode);


        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProStudentDetailsUpdation", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProStudentDetailsUpdation", objFields));
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