using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;

public class ClsRegistration : ClsCommonBaseMaster, IMasterCommands
{

    private int nPId = 0, nSId = 0, nGroupId = 0, nSubGrpId = 0, nPaymentTermsId = 0, nAgentId = 0, nStudentId = 0, nNationalityId1 = 0;
    private int nLocationId1 = 0, nDistance = 0, nDesigId = 0, nImgTempId = 0, nBankAccId = 0;
    private double nTarget = 0, nCreditLimit = 0, nDisc = 0;

    private string  cHouseName, cPAddress, cCAddress, cGstNo, cDesignationList, cBranchList;
    private string  cFaxNo, cPhoto, cMStatus, cEducation, cWebAdd,  cExperience, cBankBranch,cImgePath;

    public ClsRegistration() : base("TblRegistration", "ID", 0, 0, 0, 0)
    {
    }
    public ClsRegistration(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("TblRegistration", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int PId
    {
        get
        { return nPId; }
        set
        { nPId = value; }
    }
    public int SId
    {
        get
        { return nSId; }
        set
        { nSId = value; }
    }

    public int GroupId
    {
        get
        { return nGroupId; }
        set
        { nGroupId = value; }
    }

    public int SubGrpId
    {
        get
        { return nSubGrpId; }
        set
        { nSubGrpId = value; }
    }

    public int PaymentTermsId
    {
        get
        { return nPaymentTermsId; }
        set
        { nPaymentTermsId = value; }
    }
    public int AgentId
    {
        get
        { return nAgentId; }
        set
        { nAgentId = value; }
    }
    public int NationalityId1
    {
        get
        { return nNationalityId1; }
        set
        { nNationalityId1 = value; }
    }
    public int LocationId1
    {
        get
        { return nLocationId1; }
        set
        { nLocationId1 = value; }
    }
    public int Distance
    {
        get
        { return nDistance; }
        set
        { nDistance = value; }
    }
    public int DesigId
    {
        get
        { return nDesigId; }
        set
        { nDesigId = value; }
    }
    public int ImgTempId
    {
        get
        { return nImgTempId; }
        set
        { nImgTempId = value; }
    }
    public int BankAccId
    {
        get
        { return nBankAccId; }
        set
        { nBankAccId = value; }
    }
    public double Target
    {
        get
        { return nTarget; }
        set
        { nTarget = value; }
    }
    public double CreditLimit
    {
        get
        { return nCreditLimit; }
        set
        { nCreditLimit = value; }
    }
    
    public double Disc
    {
        get
        { return nDisc; }
        set
        { nDisc = value; }
    }

    public string HouseName
    {
        get
        { return cHouseName; }
        set
        { cHouseName = value; }
    }
    public string PAddress
    {
        get
        { return cPAddress; }
        set
        { cPAddress = value; }
    }
    public string CAddress
    {
        get
        { return cCAddress; }
        set
        { cCAddress = value; }
    }
    public string GstNo
    {
        get
        { return cGstNo; }
        set
        { cGstNo = value; }
    }
    public string DesignationList
    {
        get
        { return cDesignationList; }
        set
        { cDesignationList = value; }
    }
    public string BranchList
    {
        get
        { return cBranchList; }
        set
        { cBranchList = value; }
    }

    public string FaxNo
    {
        get
        { return cFaxNo; }
        set
        { cFaxNo = value; }
    }
    public string Photo
    {
        get
        { return cPhoto; }
        set
        { cPhoto = value; }
    }
    public string MStatus
    {
        get
        { return cMStatus; }
        set
        { cMStatus = value; }
    }
    public string Education
    {
        get
        { return cEducation; }
        set
        { cEducation = value; }
    }
    public string WebAdd
    {
        get
        { return cWebAdd; }
        set
        { cWebAdd = value; }
    }
    public string Experience
    {
        get
        { return cExperience; }
        set
        { cExperience = value; }
    }
    public string ImgePath
    {
        get
        { return cImgePath; }
        set
        { cImgePath = value; }
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

        ParentId = FnIsNumeric(drVal["ParentId"].ToString());
        Name = drVal["Name"].ToString().Trim();
        Code = drVal["Code"].ToString().Trim();
        RegNo = drVal["RegNo"].ToString().Trim();
        DisplayName = drVal["DisplayName"].ToString().Trim();

        HouseName = drVal["HouseName"].ToString().Trim();
        PAddress = drVal["PAddress"].ToString().Trim();
        CAddress = drVal["CAddress"].ToString().Trim();
        GstNo = drVal["GstNo"].ToString().Trim();
        DesignationList = drVal["DesignationList"].ToString().Trim();
        BranchList = drVal["BranchList"].ToString().Trim();
        FaxNo = drVal["FaxNo"].ToString().Trim();
        Photo = drVal["Photo"].ToString().Trim();

        MStatus = drVal["MStatus"].ToString().Trim();
        Education = drVal["Education"].ToString().Trim();
        WebAdd = drVal["WebAdd"].ToString().Trim();
        Experience = drVal["Experience"].ToString().Trim();
        ImgePath = drVal["ImgePath"].ToString().Trim();


        PId = FnIsNumeric(drVal["PId"].ToString());
        SId = FnIsNumeric(drVal["SId"].ToString());
        GroupId = FnIsNumeric(drVal["GroupId"].ToString());

        SubGrpId = FnIsNumeric(drVal["SubGrpId"].ToString());
        PaymentTermsId = FnIsNumeric(drVal["PaymentTermsId"].ToString());
        AgentId = FnIsNumeric(drVal["AgentId"].ToString());

        Dob = FnDateTime(drVal["Dob"].ToString());
        Sex = drVal["Sex"].ToString().Trim();
        PAddress = drVal["PAddress"].ToString().Trim();
        CAddress = drVal["CAddress"].ToString().Trim();
        GstNo = drVal["GstNo"].ToString().Trim();
        DesignationList = drVal["DesignationList"].ToString().Trim();
        BranchList = drVal["BranchList"].ToString().Trim();

        //Nationality = drVal["Nationality"].ToString().Trim();
        NationalityId = FnIsNumeric(drVal["NationalityId"].ToString());

        //Nationality1 = drVal["Nationality1"].ToString().Trim();
        NationalityId1 = FnIsNumeric(drVal["NationalityId1"].ToString());

        //State = drVal["State"].ToString().Trim();
        StateId = FnIsNumeric(drVal["StateId"].ToString());

        //District = drVal["District"].ToString().Trim();
        DistrictId = FnIsNumeric(drVal["DistrictId"].ToString());

        //Location = drVal["Location"].ToString().Trim();
        LocationId = FnIsNumeric(drVal["LocationId"].ToString());
        //Location1 = drVal["Location1"].ToString().Trim();
        LocationId1 = FnIsNumeric(drVal["LocationId1"].ToString());


        Pincode = drVal["Pincode"].ToString().Trim();
        Distance = FnIsNumeric(drVal["Distance"].ToString());

        Email = drVal["Email"].ToString().Trim();
        MobNo = drVal["MobNo"].ToString().Trim();
        PhoneNo = drVal["PhoneNo"].ToString().Trim();
        WebAdd = drVal["WebAdd"].ToString().Trim();
        FaxNo = drVal["FaxNo"].ToString().Trim();

        ImgePath = drVal["ImgePath"].ToString().Trim();
        ImgTempId = FnIsNumeric(drVal["ImgTempId"].ToString().Trim());

        MStatus = drVal["MStatus"].ToString().Trim();
        Education = drVal["Education"].ToString().Trim();
        WebAdd = drVal["WebAdd"].ToString().Trim();
        BloodGroup = drVal["BloodGroup"].ToString().Trim();
        JoinDate = FnDateTime(drVal["JoinDate"].ToString());
        ResignDate = FnDateTime(drVal["ResignDate"].ToString());

        DesigId = FnIsNumeric(drVal["DesigId"].ToString());
        //Designation = drVal["Designation"].ToString().Trim();
        PassPortNo = drVal["PassPortNo"].ToString().Trim();
        Experience = drVal["Experience"].ToString().Trim();
        Target = FnIsDouble(drVal["Target"].ToString());
        Disc = FnIsDouble(drVal["Disc"].ToString());
        CreditLimit = FnIsDouble(drVal["CreditLimit"].ToString());

        BankAccId = FnIsNumeric(drVal["BankAccId"].ToString());
        BankName = drVal["BankName"].ToString().Trim();
        BankIfsc = drVal["BankIfsc"].ToString().Trim();
        BankAccNo = drVal["BankAccNo"].ToString().Trim();
        BankBranch = drVal["BankBranch"].ToString().Trim();
    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cRegNo", System.Data.DbType.String, RegNo);
        objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);
        objFields.AddParameterFields("Prm_cDisplayName", System.Data.DbType.String, DisplayName);
        objFields.AddParameterFields("Prm_nPId", System.Data.DbType.Int32, PId);
        objFields.AddParameterFields("Prm_nSId", System.Data.DbType.Int32, SId);
        objFields.AddParameterFields("Prm_nGroupId", System.Data.DbType.Int32, GroupId);
        objFields.AddParameterFields("Prm_nSubGrpId", System.Data.DbType.Int32, SubGrpId);
        objFields.AddParameterFields("Prm_nPaymentTermsId", System.Data.DbType.Int32, PaymentTermsId);
        objFields.AddParameterFields("Prm_nAgentId", System.Data.DbType.Int32, AgentId);
        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId);

        objFields.AddParameterFields("Prm_dDob", System.Data.DbType.DateTime, Dob);
        objFields.AddParameterFields("Prm_cSex", System.Data.DbType.String, Sex);
        objFields.AddParameterFields("Prm_cPAddress", System.Data.DbType.String, PAddress);
        objFields.AddParameterFields("Prm_cCAddress ", System.Data.DbType.String, CAddress);
        objFields.AddParameterFields("Prm_cGstNo ", System.Data.DbType.String, GstNo);
        objFields.AddParameterFields("Prm_cDesignationList ", System.Data.DbType.String, DesignationList);
        objFields.AddParameterFields("Prm_cBranchList ", System.Data.DbType.String, BranchList);
        objFields.AddParameterFields("Prm_nNationalityId", System.Data.DbType.Int32, NationalityId);
        objFields.AddParameterFields("Prm_nNationalityId1", System.Data.DbType.Int32, NationalityId1);
        objFields.AddParameterFields("Prm_nStateId", System.Data.DbType.Int32, StateId);
        objFields.AddParameterFields("Prm_nDistrictId", System.Data.DbType.Int32, DistrictId);
        objFields.AddParameterFields("Prm_nLocationId", System.Data.DbType.Int32, LocationId);
        objFields.AddParameterFields("Prm_nLocationId1", System.Data.DbType.Int32, LocationId1);
        objFields.AddParameterFields("Prm_cPincode", System.Data.DbType.String, Pincode);
        objFields.AddParameterFields("Prm_nDistance", System.Data.DbType.Int32, Distance);
        objFields.AddParameterFields("Prm_cMobNo", System.Data.DbType.String, MobNo);
        objFields.AddParameterFields("Prm_cPhoneNo", System.Data.DbType.String, PhoneNo);
        objFields.AddParameterFields("Prm_cEmail", System.Data.DbType.String, Email);
        objFields.AddParameterFields("Prm_cFaxNo", System.Data.DbType.String, FaxNo);
        objFields.AddParameterFields("Prm_cMStatus", System.Data.DbType.String, MStatus);
        objFields.AddParameterFields("Prm_cEducation", System.Data.DbType.String, Education);
        objFields.AddParameterFields("Prm_cHouseName", System.Data.DbType.String, HouseName);


        objFields.AddParameterFields("Prm_cWebAdd", System.Data.DbType.String, WebAdd);
        objFields.AddParameterFields("Prm_cBloodGroup", System.Data.DbType.String, BloodGroup);
        objFields.AddParameterFields("Prm_dJoinDate", System.Data.DbType.DateTime, JoinDate);
        objFields.AddParameterFields("Prm_dResignDate", System.Data.DbType.DateTime, ResignDate);
        objFields.AddParameterFields("Prm_nBankAccId", System.Data.DbType.Int32, BankAccId);
        objFields.AddParameterFields("Prm_nDesigId", System.Data.DbType.Int32, DesigId);
        objFields.AddParameterFields("Prm_cPassPortNo", System.Data.DbType.String, PassPortNo);
        objFields.AddParameterFields("Prm_cExperience", System.Data.DbType.String, Experience);
        objFields.AddParameterFields("Prm_nTarget", System.Data.DbType.Double, Target);
        objFields.AddParameterFields("Prm_nDisc", System.Data.DbType.Double, Disc);
        objFields.AddParameterFields("Prm_nCreditLimit", System.Data.DbType.Double, CreditLimit);
        objFields.AddParameterFields("Prm_cBankName", System.Data.DbType.String, BankName);
        objFields.AddParameterFields("Prm_cBankAccNo", System.Data.DbType.String, BankAccNo);
        objFields.AddParameterFields("Prm_cBankIfsc", System.Data.DbType.String, BankIfsc);
        objFields.AddParameterFields("Prm_cBankBranch", System.Data.DbType.String, BankBranch);
        objFields.AddParameterFields("Prm_cImgePath", System.Data.DbType.String, ImgePath);
        objFields.AddParameterFields("Prm_nImgTempId", System.Data.DbType.Int32, ImgTempId);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProRegistration", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProRegistration", objFields));
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