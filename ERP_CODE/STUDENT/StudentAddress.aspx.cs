using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_StudentAddress : ClsPageEvents,IPageInterFace
{
    ClsStudentPermanentAddress ObjCls = new ClsStudentPermanentAddress();
    ClsStudentTemporaryAddress ObjClsTemp = new ClsStudentTemporaryAddress();

    ClsStudentFatherPermanentAddress ObjClsFthr = new ClsStudentFatherPermanentAddress();
    ClsStudentFatherTemporaryAddress ObjClsFthrTemp = new ClsStudentFatherTemporaryAddress();

    ClsStudentMotherPermanentAddress ObjClsMthr = new ClsStudentMotherPermanentAddress();
    ClsStudentMotherTemporaryAddress ObjClsMthrTemp = new ClsStudentMotherTemporaryAddress();

    ClsStudentGuardianPermanentAddress  ObjClsGurdn = new ClsStudentGuardianPermanentAddress();
    ClsStudentGuardianTemporaryAddress ObjClsGurdnTemp = new ClsStudentGuardianTemporaryAddress();
    ClsStudentHouse ObjClsA = new ClsStudentHouse();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommandFthr.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommandMthr.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommandGurdn.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
                FnInitializeForm();
                TxtHouseNamePerm.Focus();
            }
            CtrlGrdStatePer.ParentControl = CtrlGrdCountryPer.IdControl;
            CtrlGrdDistrictPer.ParentControl = CtrlGrdStatePer.IdControl;

            CtrlGrdStateTemp.ParentControl = CtrlGrdCountryTemp.IdControl;
            CtrlGrdDistrictTemp.ParentControl = CtrlGrdStateTemp.IdControl;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public override void FnInitializeForm()
    {
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsStudentPermanentAddress(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjCls.HouseName = TxtHouseNamePerm.Text.Trim();
        ObjCls.PAddress = TxtAddressPerm.Text.Trim();
        ObjCls.CAddress = TxtPostOfficePerm.Text.Trim();
        ObjCls.Pincode = TxtPinCodePerm.Text.Trim();
        ObjCls.NationalityId = ObjCls.FnIsNumeric(CtrlGrdCountryPer.SelectedValue.ToString());
        ObjCls.StateId = ObjCls.FnIsNumeric(CtrlGrdStatePer.SelectedValue.ToString());
        ObjCls.DistrictId = ObjCls.FnIsNumeric(CtrlGrdDistrictPer.SelectedValue.ToString());
        ObjCls.Landmark = TxtCityPerm.Text.Trim();
        ObjCls.PhoneNo = TxtPhoneNoPerm.Text.Trim();
        ObjCls.Email = TxtEmailPerm.Text.Trim();
        ObjCls.MobNo = TxtMobNoPerm.Text.Trim();
        ObjCls.Remarks = TxtRemarksPerm.Text.Trim();
    }
    public void FnAssignPropertyTemp()
    {
        base.FnAssignProperty(ObjClsTemp);
        ObjClsTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsTemp.HouseName = TxtHouseNameTemp.Text.Trim();
        ObjClsTemp.PAddress = TxtAddressTemp.Text.Trim();
        ObjClsTemp.CAddress = TxtPostOfficeTemp.Text.Trim();
        ObjClsTemp.Pincode = TxtPinCodeTemp.Text.Trim();
        ObjClsTemp.NationalityId = ObjCls.FnIsNumeric(CtrlGrdCountryTemp.SelectedValue.ToString());
        ObjClsTemp.StateId = ObjCls.FnIsNumeric(CtrlGrdStateTemp.SelectedValue.ToString());
        ObjClsTemp.DistrictId = ObjCls.FnIsNumeric(CtrlGrdDistrictTemp.SelectedValue.ToString());
        ObjClsTemp.Landmark = TxtCityTemp.Text.Trim();
        ObjClsTemp.PhoneNo = TxtPhoneNoTemp.Text.Trim();
        ObjClsTemp.Email = TxtEmailTemp.Text.Trim();
        ObjClsTemp.MobNo = TxtMobNoTemp.Text.Trim();
        ObjClsTemp.Remarks = TxtRemarksTemp.Text.Trim();
    }
    public void FnAssignPropertyFthr()
    {
        base.FnAssignProperty(ObjClsFthr);
        ObjClsFthr.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsFthr.HouseName = TxtFthrHousePer.Text.Trim();
        ObjClsFthr.PAddress = TxtFthrStreetPer.Text.Trim();
        ObjClsFthr.CAddress = TxtFthrPostPer.Text.Trim();
        ObjClsFthr.Pincode = TxtFthrPincodePer.Text.Trim();
        ObjClsFthr.NationalityId = ObjCls.FnIsNumeric(CtrlGrdFthrCntryPer.SelectedValue.ToString());
        ObjClsFthr.StateId = ObjCls.FnIsNumeric(CtrlGrdFthrStatePer.SelectedValue.ToString());
        ObjClsFthr.DistrictId = ObjCls.FnIsNumeric(CtrlGrdFthrDistPer.SelectedValue.ToString());
        ObjClsFthr.Landmark = TxtFthrLandmarkPer.Text.Trim();
        ObjClsFthr.PhoneNo = TxtFthrPhNoPer.Text.Trim();
        ObjClsFthr.Email = TxtFthrEmailPer.Text.Trim();
        ObjClsFthr.MobNo = TxtFthrMobPer.Text.Trim();
        ObjClsFthr.Remarks = TxtFthrRemarksPer.Text.Trim();
    }
    public void FnAssignPropertyFthrTemp()
    {
        base.FnAssignProperty(ObjClsFthrTemp);
        ObjClsFthrTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsFthrTemp.HouseName = TxtFthrHouseTemp.Text.Trim();
        ObjClsFthrTemp.PAddress = TxtFthrStreetTemp.Text.Trim();
        ObjClsFthrTemp.CAddress = TxtFthrPostTemp.Text.Trim();
        ObjClsFthrTemp.Pincode = TxtFthrPincodeTemp.Text.Trim();
        ObjClsFthrTemp.NationalityId = ObjCls.FnIsNumeric(CtrlGrdFthrCntryTemp.SelectedValue.ToString());
        ObjClsFthrTemp.StateId = ObjCls.FnIsNumeric(CtrlGrdFthrStateTemp.SelectedValue.ToString());
        ObjClsFthrTemp.DistrictId = ObjCls.FnIsNumeric(CtrlGrdFthrDistTEmp.SelectedValue.ToString());
        ObjClsFthrTemp.Landmark = TxtFthrLandmarkTemp.Text.Trim();
        ObjClsFthrTemp.PhoneNo = TxtFthrPhNoTemp.Text.Trim();
        ObjClsFthrTemp.Email = TxtFthrEmailTemp.Text.Trim();
        ObjClsFthrTemp.MobNo = TxtFthrMobTemp.Text.Trim();
        ObjClsFthrTemp.Remarks = TxtFthrRemarksTemp.Text.Trim();
    }
    public void FnAssignPropertyMthr()
    {
        base.FnAssignProperty(ObjClsMthr);
        ObjClsMthr.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsMthr.HouseName = TxtMthrHousePer.Text.Trim();
        ObjClsMthr.PAddress = TxtMthrStreetPer.Text.Trim();
        ObjClsMthr.CAddress = TxtMthrPostPer.Text.Trim();
        ObjClsMthr.Pincode = TxtMthrPincodePer.Text.Trim();
        ObjClsMthr.NationalityId = ObjCls.FnIsNumeric(CtrlGrdMthrCntryPer.SelectedValue.ToString());
        ObjClsMthr.StateId = ObjCls.FnIsNumeric(CtrlGrdMthrStatePer.SelectedValue.ToString());
        ObjClsMthr.DistrictId = ObjCls.FnIsNumeric(CtrlGrdMthrDistPer.SelectedValue.ToString());
        ObjClsMthr.Landmark = TxtMthrLandmarkPer.Text.Trim();
        ObjClsMthr.PhoneNo = TxtMthrPhNoPer.Text.Trim();
        ObjClsMthr.Email = TxtMthrEmailPer.Text.Trim();
        ObjClsMthr.MobNo = TxtMthrMobPer.Text.Trim();
        ObjClsMthr.Remarks = TxtMthrRemarksPer.Text.Trim();
    }
    public void FnAssignPropertyMthrTemp()
    {
        base.FnAssignProperty(ObjClsMthrTemp);
        ObjClsMthrTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsMthrTemp.HouseName = TxtMthrHouseTemp.Text.Trim();
        ObjClsMthrTemp.PAddress = TxtMthrStreetTemp.Text.Trim();
        ObjClsMthrTemp.CAddress = TxtMthrPostTemp.Text.Trim();
        ObjClsMthrTemp.Pincode = TxtMthrPincodeTemp.Text.Trim();
        ObjClsMthrTemp.NationalityId = ObjCls.FnIsNumeric(CtrlGrdMthrCntryTemp.SelectedValue.ToString());
        ObjClsMthrTemp.StateId = ObjCls.FnIsNumeric(CtrlGrdMthrStateTemp.SelectedValue.ToString());
        ObjClsMthrTemp.DistrictId = ObjCls.FnIsNumeric(CtrlGrdMthrDistTEmp.SelectedValue.ToString());
        ObjClsMthrTemp.Landmark = TxtMthrLandmarkTemp.Text.Trim();
        ObjClsMthrTemp.PhoneNo = TxtMthrPhNoTemp.Text.Trim();
        ObjClsMthrTemp.Email = TxtMthrMobTemp.Text.Trim();
        ObjClsMthrTemp.MobNo = TxtMthrRemarksTemp.Text.Trim();
        ObjClsMthrTemp.Remarks = TxtRemarksTemp.Text.Trim();
    }
    public void FnAssignPropertyGurdn()
    {
        base.FnAssignProperty(ObjClsGurdn);
        ObjClsGurdn.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsGurdn.HouseName = TxtGurdnHousePer.Text.Trim();
        ObjClsGurdn.PAddress = TxtGurdnStreetPer.Text.Trim();
        ObjClsGurdn.CAddress = TxtGurdnPostPer.Text.Trim();
        ObjClsGurdn.Pincode = TxtGurdnPincodePer.Text.Trim();
        ObjClsGurdn.NationalityId = ObjCls.FnIsNumeric(CtrlGrdGurdnCntryPer.SelectedValue.ToString());
        ObjClsGurdn.StateId = ObjCls.FnIsNumeric(CtrlGrdGurdnStatePer.SelectedValue.ToString());
        ObjClsGurdn.DistrictId = ObjCls.FnIsNumeric(CtrlGrdGurdnDistPer.SelectedValue.ToString());
        ObjClsGurdn.Landmark = TxtGurdnLandmarkPer.Text.Trim();
        ObjClsGurdn.PhoneNo = TxtGurdnPhNoPer.Text.Trim();
        ObjClsGurdn.Email = TxtGurdnEmailPer.Text.Trim();
        ObjClsGurdn.MobNo = TxtGurdnMobPer.Text.Trim();
        ObjClsGurdn.Remarks = TxtGurdnRemarksPer.Text.Trim();
    }
    public void FnAssignPropertyGurdnTemp()
    {
        base.FnAssignProperty(ObjClsGurdnTemp);
        ObjClsGurdnTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsGurdnTemp.HouseName = TxtGurdnHouseTemp.Text.Trim();
        ObjClsGurdnTemp.PAddress = TxtGurdnStreetTemp.Text.Trim();
        ObjClsGurdnTemp.CAddress = TxtGurdnPostTemp.Text.Trim();
        ObjClsGurdnTemp.Pincode = TxtGurdnPincodeTemp.Text.Trim();
        ObjClsGurdnTemp.NationalityId = ObjCls.FnIsNumeric(CtrlGrdGurdnCntryTemp.SelectedValue.ToString());
        ObjClsGurdnTemp.StateId = ObjCls.FnIsNumeric(CtrlGrdGurdnStateTemp.SelectedValue.ToString());
        ObjClsGurdnTemp.DistrictId = ObjCls.FnIsNumeric(CtrlGrdGurdnDistTEmp.SelectedValue.ToString());
        ObjClsGurdnTemp.Landmark = TxtGurdnLandmarkTemp.Text.Trim();
        ObjClsGurdnTemp.PhoneNo = TxtGurdnPhNoTemp.Text.Trim();
        ObjClsGurdnTemp.Email = TxtGurdnEmailTemp.Text.Trim();
        ObjClsGurdnTemp.MobNo = TxtGurdnMobTemp.Text.Trim();
        ObjClsGurdnTemp.Remarks = TxtGurdnRemarksTemp.Text.Trim();
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjCls);
        DT_RECORD= ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjCls.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);
            TxtHouseNamePerm.Text = ObjCls.HouseName;
            TxtAddressPerm.Text = ObjCls.PAddress;
            TxtPostOfficePerm.Text = ObjCls.CAddress;
            TxtPinCodePerm.Text = ObjCls.Pincode;

            CtrlGrdCountryPer.SelectedValue = ObjCls.NationalityId.ToString();
            CtrlGrdCountryPer.SelectedText = ObjCls.NationalityName;

            CtrlGrdStatePer.SelectedValue = ObjCls.StateId.ToString();
            CtrlGrdStatePer.SelectedText = ObjCls.StateName;

            CtrlGrdDistrictPer.SelectedValue = ObjCls.DistrictId.ToString();
            CtrlGrdDistrictPer.SelectedText = ObjCls.DistrictName;

            TxtCityPerm.Text = ObjCls.Landmark;
            TxtPhoneNoPerm.Text = ObjCls.PhoneNo;
            TxtEmailPerm.Text = ObjCls.Email;
            TxtMobNoPerm.Text = ObjCls.MobNo;
            TxtRemarksPerm.Text = ObjCls.Remarks;
        }

        //...............................................................................
        base.FnAssignProperty(ObjClsTemp);
        ObjClsTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsTemp);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsTemp.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);

            TxtHouseNameTemp.Text = ObjClsTemp.HouseName;
            TxtAddressTemp.Text = ObjClsTemp.PAddress;
            TxtPostOfficeTemp.Text = ObjClsTemp.CAddress;
            TxtPinCodeTemp.Text = ObjClsTemp.Pincode;

            CtrlGrdCountryTemp.SelectedValue = ObjClsTemp.NationalityId.ToString();
            CtrlGrdCountryTemp.SelectedText = ObjClsTemp.NationalityName;

            CtrlGrdStateTemp.SelectedValue = ObjClsTemp.StateId.ToString();
            CtrlGrdStateTemp.SelectedText = ObjClsTemp.StateName;

            CtrlGrdDistrictTemp.SelectedValue = ObjClsTemp.DistrictId.ToString();
            CtrlGrdDistrictTemp.SelectedText = ObjClsTemp.DistrictName;

            TxtCityTemp.Text = ObjClsTemp.Landmark;
            TxtPhoneNoTemp.Text = ObjClsTemp.PhoneNo;
            TxtEmailTemp.Text = ObjClsTemp.Email;
            TxtMobNoTemp.Text = ObjClsTemp.MobNo;
            TxtRemarksTemp.Text = ObjClsTemp.Remarks;
        }
        //=============== FATHER ADDRESS
        base.FnAssignProperty(ObjClsFthr);
        ObjClsFthr.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsFthr);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsFthr.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);
            TxtFthrHousePer.Text = ObjClsFthr.HouseName;
            TxtFthrStreetPer.Text = ObjClsFthr.PAddress;
            TxtFthrPostPer.Text = ObjClsFthr.CAddress;
            TxtFthrPincodePer.Text = ObjClsFthr.Pincode;

            CtrlGrdFthrCntryPer.SelectedValue = ObjClsFthr.NationalityId.ToString();
            CtrlGrdFthrCntryPer.SelectedText = ObjClsFthr.NationalityName;

            CtrlGrdFthrStatePer.SelectedValue = ObjClsFthr.StateId.ToString();
            CtrlGrdFthrStatePer.SelectedText = ObjClsFthr.StateName;

            CtrlGrdFthrDistPer.SelectedValue = ObjClsFthr.DistrictId.ToString();
            CtrlGrdFthrDistPer.SelectedText = ObjClsFthr.DistrictName;

            TxtFthrLandmarkPer.Text = ObjClsFthr.Landmark;
            TxtFthrPhNoPer.Text = ObjClsFthr.PhoneNo;
            TxtFthrEmailPer.Text = ObjClsFthr.Email;
            TxtFthrMobPer.Text = ObjClsFthr.MobNo;
            TxtFthrRemarksPer.Text = ObjClsFthr.Remarks;
        }

        //...............................................................................
        base.FnAssignProperty(ObjClsFthrTemp);
        ObjClsFthrTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsFthrTemp);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsFthrTemp.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);

            TxtFthrHouseTemp.Text = ObjClsFthrTemp.HouseName;
            TxtFthrStreetTemp.Text = ObjClsFthrTemp.PAddress;
            TxtFthrPostTemp.Text = ObjClsFthrTemp.CAddress;
            TxtFthrPincodeTemp.Text = ObjClsFthrTemp.Pincode;

            CtrlGrdFthrCntryTemp.SelectedValue = ObjClsFthrTemp.NationalityId.ToString();
            CtrlGrdFthrCntryTemp.SelectedText = ObjClsFthrTemp.NationalityName;

            CtrlGrdFthrStateTemp.SelectedValue = ObjClsFthrTemp.StateId.ToString();
            CtrlGrdFthrStateTemp.SelectedText = ObjClsFthrTemp.StateName;

            CtrlGrdFthrDistTEmp.SelectedValue = ObjClsFthrTemp.DistrictId.ToString();
            CtrlGrdFthrDistTEmp.SelectedText = ObjClsFthrTemp.DistrictName;

            TxtFthrLandmarkTemp.Text = ObjClsFthrTemp.Landmark;
            TxtFthrPhNoTemp.Text = ObjClsFthrTemp.PhoneNo;
            TxtFthrEmailTemp.Text = ObjClsFthrTemp.Email;
            TxtFthrMobTemp.Text = ObjClsFthrTemp.MobNo;
            TxtFthrRemarksTemp.Text = ObjClsFthrTemp.Remarks;
        }
        //=============== MOTHER ADDRESS
        base.FnAssignProperty(ObjClsMthr);
        ObjClsMthr.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsMthr);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsMthr.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);
            TxtMthrHousePer.Text = ObjClsMthr.HouseName;
            TxtMthrStreetPer.Text = ObjClsMthr.PAddress;
            TxtMthrPostPer.Text = ObjClsMthr.CAddress;
            TxtMthrPincodePer.Text = ObjClsMthr.Pincode;

            CtrlGrdMthrCntryPer.SelectedValue = ObjClsMthr.NationalityId.ToString();
            CtrlGrdMthrCntryPer.SelectedText = ObjClsMthr.NationalityName;

            CtrlGrdMthrStatePer.SelectedValue = ObjClsMthr.StateId.ToString();
            CtrlGrdMthrStatePer.SelectedText = ObjClsMthr.StateName;

            CtrlGrdMthrDistPer.SelectedValue = ObjClsMthr.DistrictId.ToString();
            CtrlGrdMthrDistPer.SelectedText = ObjClsMthr.DistrictName;

            TxtMthrLandmarkPer.Text = ObjClsMthr.Landmark;
            TxtMthrPhNoPer.Text = ObjClsMthr.PhoneNo;
            TxtMthrEmailPer.Text = ObjClsMthr.Email;
            TxtMthrMobPer.Text = ObjClsMthr.MobNo;
            TxtMthrRemarksPer.Text = ObjClsMthr.Remarks;
        }

        //...............................................................................
        base.FnAssignProperty(ObjClsMthrTemp);
        ObjClsMthrTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsMthrTemp);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsMthrTemp.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);

            TxtMthrHouseTemp.Text = ObjClsMthrTemp.HouseName;
            TxtMthrStreetTemp.Text = ObjClsMthrTemp.PAddress;
            TxtMthrPostTemp.Text = ObjClsMthrTemp.CAddress;
            TxtMthrPincodeTemp.Text = ObjClsMthrTemp.Pincode;

            CtrlGrdMthrCntryTemp.SelectedValue = ObjClsMthrTemp.NationalityId.ToString();
            CtrlGrdMthrCntryTemp.SelectedText = ObjClsMthrTemp.NationalityName;

            CtrlGrdMthrStateTemp.SelectedValue = ObjClsMthrTemp.StateId.ToString();
            CtrlGrdMthrStateTemp.SelectedText = ObjClsMthrTemp.StateName;

            CtrlGrdMthrDistTEmp.SelectedValue = ObjClsMthrTemp.DistrictId.ToString();
            CtrlGrdMthrDistTEmp.SelectedText = ObjClsMthrTemp.DistrictName;

            TxtMthrLandmarkTemp.Text = ObjClsMthrTemp.Landmark;
            TxtMthrPhNoTemp.Text = ObjClsMthrTemp.PhoneNo;
            TxtMthrEmailTemp.Text = ObjClsMthrTemp.Email;
            TxtMthrMobTemp.Text = ObjClsMthrTemp.MobNo;
            TxtMthrRemarksTemp.Text = ObjClsMthrTemp.Remarks;
        }
        //============== GUARDIAN ADDRESS
        base.FnAssignProperty(ObjClsGurdn);
        ObjClsGurdn.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsGurdn);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsGurdn.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);
            TxtGurdnHousePer.Text = ObjClsGurdn.HouseName;
            TxtGurdnStreetPer.Text = ObjClsGurdn.PAddress;
            TxtGurdnPostPer.Text = ObjClsGurdn.CAddress;
            TxtGurdnPincodePer.Text = ObjClsGurdn.Pincode;

            CtrlGrdGurdnCntryPer.SelectedValue = ObjClsGurdn.NationalityId.ToString();
            CtrlGrdGurdnCntryPer.SelectedText = ObjClsGurdn.NationalityName;

            CtrlGrdGurdnStatePer.SelectedValue = ObjClsGurdn.StateId.ToString();
            CtrlGrdGurdnStatePer.SelectedText = ObjClsGurdn.StateName;

            CtrlGrdGurdnDistPer.SelectedValue = ObjClsGurdn.DistrictId.ToString();
            CtrlGrdGurdnDistPer.SelectedText = ObjClsGurdn.DistrictName;

            TxtGurdnLandmarkPer.Text = ObjClsGurdn.Landmark;
            TxtGurdnPhNoPer.Text = ObjClsGurdn.PhoneNo;
            TxtGurdnEmailPer.Text = ObjClsGurdn.Email;
            TxtGurdnMobPer.Text = ObjClsGurdn.MobNo;
            TxtGurdnRemarksPer.Text = ObjClsGurdn.Remarks;
        }

        //...............................................................................
        base.FnAssignProperty(ObjClsGurdnTemp);
        ObjClsGurdnTemp.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        FnFindRecord(ObjClsGurdnTemp);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjClsGurdnTemp.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), ViewState["DT"] as DataTable);

            TxtGurdnHouseTemp.Text = ObjClsGurdnTemp.HouseName;
            TxtGurdnStreetTemp.Text = ObjClsGurdnTemp.PAddress;
            TxtGurdnPostTemp.Text = ObjClsGurdnTemp.CAddress;
            TxtGurdnPincodeTemp.Text = ObjClsGurdnTemp.Pincode;

            CtrlGrdGurdnCntryTemp.SelectedValue = ObjClsGurdnTemp.NationalityId.ToString();
            CtrlGrdGurdnCntryTemp.SelectedText = ObjClsGurdnTemp.NationalityName;

            CtrlGrdGurdnStateTemp.SelectedValue = ObjClsGurdnTemp.StateId.ToString();
            CtrlGrdGurdnStateTemp.SelectedText = ObjClsGurdnTemp.StateName;

            CtrlGrdGurdnDistTEmp.SelectedValue = ObjClsGurdnTemp.DistrictId.ToString();
            CtrlGrdGurdnDistTEmp.SelectedText = ObjClsGurdnTemp.DistrictName;

            TxtGurdnLandmarkTemp.Text = ObjClsGurdnTemp.Landmark;
            TxtGurdnPhNoTemp.Text = ObjClsGurdnTemp.PhoneNo;
            TxtGurdnEmailTemp.Text = ObjClsGurdnTemp.Email;
            TxtGurdnMobTemp.Text = ObjClsGurdnTemp.MobNo;
            TxtGurdnRemarksTemp.Text = ObjClsGurdnTemp.Remarks;
        }
        TabContainer1.ActiveTabIndex = 0;
    }
    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    FnAssignProperty();
                    FnAssignPropertyTemp();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            _strMsg = ObjCls.SaveRecord() as string;
                            _strMsg = ObjClsTemp.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjCls.UpdateRecord() as string;
                            _strMsg = ObjClsTemp.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                    }
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "SAVE_FTHR":
                    FnAssignPropertyFthr();
                    FnAssignPropertyFthrTemp();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            _strMsg = ObjClsFthr.SaveRecord() as string;
                            _strMsg = ObjClsFthrTemp.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsFthr, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjClsFthr.UpdateRecord() as string;
                            _strMsg = ObjClsFthrTemp.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsFthrTemp, false);
                            break;
                    }
                    break;
                case "CLEAR_FTHR":
                    FnCancelFthr();
                    break;
                case "SAVE_MTHR":
                    FnAssignPropertyMthr();
                    FnAssignPropertyMthrTemp();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            _strMsg = ObjClsMthr.SaveRecord() as string;
                            _strMsg = ObjClsMthrTemp.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsMthr, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjClsMthr.UpdateRecord() as string;
                            _strMsg = ObjClsMthrTemp.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsMthrTemp, false);
                            break;
                    }
                    break;
                case "CLEAR_MTHR":
                    FnCancelMthr();
                    break;
                case "SAVE_GURDN":
                    FnAssignPropertyGurdn();
                    FnAssignPropertyGurdnTemp();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            _strMsg = ObjClsGurdn.SaveRecord() as string;
                            _strMsg = ObjClsGurdnTemp.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsGurdn, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjClsGurdn.UpdateRecord() as string;
                            _strMsg = ObjClsGurdnTemp.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjClsGurdnTemp, false);
                            break;
                    }
                    break;
                case "CLEAR_GURDN":
                    FnCancelGurdn();
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public override void FnCancel()
    {
        //base.FnCancel();
        TxtHouseNamePerm.Text = "";
        TxtAddressPerm.Text = "";
        TxtPostOfficePerm.Text = "";
        TxtPinCodePerm.Text = "";
        CtrlGrdCountryPer.SelectedValue = "0";
        CtrlGrdCountryPer.SelectedText = "";
        CtrlGrdStatePer.SelectedValue = "0";
        CtrlGrdStatePer.SelectedText = "";
        CtrlGrdDistrictPer.SelectedValue = "0";
        CtrlGrdDistrictPer.SelectedText = "";
        TxtPhoneNoPerm.Text = "";
        TxtEmailPerm.Text = "";
        TxtMobNoPerm.Text = "";
        TxtRemarksPerm.Text = "";
        TxtCityPerm.Text = "";

        TxtHouseNameTemp.Text = "";
        TxtAddressTemp.Text = "";
        TxtPostOfficeTemp.Text = "";
        TxtPinCodeTemp.Text = "";
        CtrlGrdCountryTemp.SelectedValue = "0";
        CtrlGrdCountryTemp.SelectedText = "";
        CtrlGrdStateTemp.SelectedValue = "0";
        CtrlGrdStateTemp.SelectedText = "";
        CtrlGrdDistrictTemp.SelectedValue = "0";
        CtrlGrdDistrictTemp.SelectedText = "";
        TxtPhoneNoTemp.Text = "";
        TxtEmailTemp.Text = "";
        TxtMobNoTemp.Text = "";
        TxtRemarksTemp.Text = "";
        TxtCityTemp.Text = "";

        FnFocus(TxtHouseNamePerm);
    }
    public void FnCancelFthr()
    {
        //base.FnCancel();
        TxtFthrHousePer.Text = "";
        TxtFthrStreetPer.Text = "";
        TxtFthrPostPer.Text = "";
        TxtFthrPincodePer.Text = "";
        CtrlGrdFthrCntryPer.SelectedValue = "0";
        CtrlGrdFthrCntryPer.SelectedText = "";
        CtrlGrdFthrDistPer.SelectedValue = "0";
        CtrlGrdFthrDistPer.SelectedText = "";
        CtrlGrdFthrStatePer.SelectedValue = "0";
        CtrlGrdFthrStatePer.SelectedText = "";
        TxtFthrLandmarkPer.Text = "";
        TxtFthrPhNoPer.Text = "";
        TxtFthrEmailPer.Text = "";
        TxtFthrMobPer.Text = "";
        TxtFthrRemarksPer.Text = "";

        TxtFthrHouseTemp.Text = "";
        TxtFthrStreetTemp.Text = "";
        TxtFthrPostTemp.Text = "";
        TxtFthrPincodeTemp.Text = "";
        CtrlGrdFthrCntryTemp.SelectedValue = "0";
        CtrlGrdFthrCntryTemp.SelectedText = "";
        CtrlGrdFthrDistTEmp.SelectedValue = "0";
        CtrlGrdFthrDistTEmp.SelectedText = "";
        CtrlGrdFthrStateTemp.SelectedValue = "0";
        CtrlGrdFthrStateTemp.SelectedText = "";
        TxtFthrLandmarkTemp.Text = "";
        TxtFthrPhNoTemp.Text = "";
        TxtFthrEmailTemp.Text = "";
        TxtFthrMobTemp.Text = "";
        TxtFthrRemarksTemp.Text = "";

        FnFocus(TxtFthrHousePer);
    }
    public void FnCancelMthr()
    {
        //base.FnCancel();
        TxtMthrHousePer.Text = "";
        TxtMthrStreetPer.Text = "";
        TxtMthrPostPer.Text = "";
        TxtMthrPincodePer.Text = "";
        CtrlGrdMthrCntryPer.SelectedValue = "0";
        CtrlGrdMthrCntryPer.SelectedText = "";
        CtrlGrdMthrDistPer.SelectedValue = "0";
        CtrlGrdMthrDistPer.SelectedText = "";
        CtrlGrdMthrStatePer.SelectedValue = "0";
        CtrlGrdMthrStatePer.SelectedText = "";
        TxtMthrLandmarkPer.Text = "";
        TxtMthrPhNoPer.Text = "";
        TxtMthrEmailPer.Text = "";
        TxtMthrMobPer.Text = "";
        TxtMthrRemarksPer.Text = "";

        TxtMthrHouseTemp.Text = "";
        TxtMthrStreetTemp.Text = "";
        TxtMthrPostTemp.Text = "";
        TxtMthrPincodeTemp.Text = "";
        CtrlGrdMthrCntryTemp.SelectedValue = "0";
        CtrlGrdMthrCntryTemp.SelectedText = "";
        CtrlGrdMthrDistTEmp.SelectedValue = "0";
        CtrlGrdMthrDistTEmp.SelectedText = "";
        CtrlGrdMthrStateTemp.SelectedValue = "0";
        CtrlGrdMthrStateTemp.SelectedText = "";
        TxtMthrLandmarkTemp.Text = "";
        TxtMthrPhNoTemp.Text = "";
        TxtMthrEmailTemp.Text = "";
        TxtMthrMobTemp.Text = "";
        TxtMthrRemarksTemp.Text = "";

        FnFocus(TxtMthrHousePer);
    }
    public void FnCancelGurdn()
    {
        //base.FnCancel();
        TxtGurdnHousePer.Text = "";
        TxtGurdnStreetPer.Text = "";
        TxtGurdnPostPer.Text = "";
        TxtGurdnPincodePer.Text = "";
        CtrlGrdGurdnCntryPer.SelectedValue = "0";
        CtrlGrdGurdnCntryPer.SelectedText = "";
        CtrlGrdGurdnDistPer.SelectedValue = "0";
        CtrlGrdGurdnDistPer.SelectedText = "";
        CtrlGrdGurdnStatePer.SelectedValue = "0";
        CtrlGrdGurdnStatePer.SelectedText = "";
        TxtGurdnLandmarkPer.Text = "";
        TxtGurdnPhNoPer.Text = "";
        TxtGurdnEmailPer.Text = "";
        TxtGurdnMobPer.Text = "";
        TxtGurdnRemarksPer.Text = "";

        TxtGurdnHouseTemp.Text = "";
        TxtGurdnStreetTemp.Text = "";
        TxtGurdnPostTemp.Text = "";
        TxtGurdnPincodeTemp.Text = "";
        CtrlGrdGurdnCntryTemp.SelectedValue = "0";
        CtrlGrdGurdnCntryTemp.SelectedText = "";
        CtrlGrdGurdnDistTEmp.SelectedValue = "0";
        CtrlGrdGurdnDistTEmp.SelectedText = "";
        CtrlGrdGurdnStateTemp.SelectedValue = "0";
        CtrlGrdGurdnStateTemp.SelectedText = "";
        TxtGurdnLandmarkTemp.Text = "";
        TxtGurdnPhNoTemp.Text = "";
        TxtGurdnEmailTemp.Text = "";
        TxtGurdnMobTemp.Text = "";
        TxtGurdnRemarksTemp.Text = "";

        FnFocus(TxtGurdnHousePer);
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
    }
    public void FnPrintRecord()
    {
        throw new NotImplementedException();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //HiddenField HdnAutoId = (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnId");
        //LinkButton LnkName = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkName");
        //LinkButton LnkStudentCode = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkStudentCode");
        //HdnId.Value = HdnAutoId.Value;
        //LblStudentName.Text = LnkName.Text;
        //LblStudentId.Text = LnkStudentCode.Text;

       // _strHdr = "Student Id :-" + LnkStudentCode.Text + " , " + LnkName.Text;
        //_strUrl = "ClassReg.aspx";
        //_strTitle = "ADDRESS DETAILS : - " ;
        //_strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',900,600);";
        //Button1.Attributes.Add("onClick", _strLnk);


       // HiddenField HdnAutoId =  (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnId");
        //LinkButton LnkName = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkName");
        //LinkButton LnkStudentCode = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkStudentCode");
        //HdnId.Value = HdnAutoId.Value;
        //LblStudentName.Text = LnkName.Text;
        //LblStudentId.Text = LnkStudentCode.Text;

       // _strHdr = "Student Id :-" + LnkStudentCode.Text + " , " + LnkName.Text;
        _strUrl = "StudentAddressCopy.aspx?CNTRID=" + ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString()) + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
        _strTitle = "ADDRESS COPY : - " ;
        //_strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',900,600);";
         FnPopUpChild(ObjCls,  _strTitle ,  _strUrl, 450,350,true);

        //Button1.Attributes.Add("onClick", _strLnk);




    }
}