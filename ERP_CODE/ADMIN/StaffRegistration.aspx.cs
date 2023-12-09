using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.Services;

public partial class STUDENT_StaffRegistration : ClsPageEvents, IPageInterFace
{
    ClsRegistration ObjCls = new ClsRegistration();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();



    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            //CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {

                ObjLst.FnGetStudentLedgerList(DdlAccountHead, "");
                ViewState["SALT"] = ObjLst.FnGetSalutationList() as DataTable;
                FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltn, "");
                FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlFatherSpouseSalu, "");

                FnBindDocumetPath(HyLnkImg, "1", "PRF");
                FnGetPopUpWindowDispaly("Profile Image", HyLnkImg, 600, 350, "../FileShow.aspx?PDF=0&FILE_TYPE=PRF_IMG", LblScript);
                FnGetPopUpWindowDispaly("Profile Capture", ImgCapture, 950, 550, "../STUDENT/PhotoCapture.aspx?PDF=0&FILE_TYPE=PRF_IMG", LblScript);

                FnInitializeForm();
            }


        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.InstituteId = FnGetRights().BRANCHID;

        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.DisplayName = FnCombineString(DdlSaltn.SelectedItem.ToString(), TxtName.Text.Trim());
        ObjCls.GroupId= 3;
        ObjCls.ApplicationNo = TxtApporderNo.Text.Trim();
        ObjCls.RegNo = TxtRegNo.Text.Trim();
        //ObjCls.ProbationaryPeriod = TxtProbationaryPeriod.Text.Trim();

        //ObjCls.DOJ = ObjCls.FnDateTime(CtrlDOJ.DateText);
        ObjCls.Dob = ObjCls.FnDateTime(CtrlDob.DateText);
        ObjCls.Sex = RadBtnGender.SelectedValue.ToString();
        ObjCls.MStatus = RadBtnMaritalStatus.SelectedValue.ToString();
        //ObjCls.AppointmentNature =  ObjCls.FnIsNumeric( DdlAppointmentNature.SelectedValue);

        ObjCls.PAddress = TxtPermanentAddress.Text.Trim();
        ObjCls.CAddress = TxtTemproraryAddress.Text.Trim();
        ObjCls.BloodGroup = DdlBloodGrp.SelectedValue;
        ObjCls.BankAccNo = TxtBankAccNo.Text;
        ObjCls.BankName = TxtBankName.Text;
        ObjCls.BankBranch = TxtBranchName.Text;
        ObjCls.BankIfsc = TxtIFSC.Text;
        //ObjCls.Subject = DdlSubject.SelectedValue;
        //ObjCls.Training = DdlTraining.SelectedValue;
        //ObjCls.Experiance = DdlExperiance.SelectedValue;
        // ObjCls.Department = ObjCls.FnIsNumeric(CtrlGrdDepartment.SelectedValue.ToString());
        //ObjCls.OfficialStatus = DdlOfficialStatus.SelectedValue;
        ObjCls.StateId = ObjCls.FnIsNumeric( DdlState.SelectedValue);
        //ObjCls.Qualification = ObjCls.FnIsNumeric(CtrlQualification.SelectedValue.ToString());
        ObjCls.AccLedgerId = ObjCls.FnIsNumeric(DdlAccountHead.SelectedValue);
        //ObjCls.AccGroup = ObjCls.FnIsNumeric(DdlAccountGroup.SelectedValue);
        ObjCls.DesigId = ObjCls.FnIsNumeric(CtrlDesignation.SelectedValue.ToString());
        //ObjCls.ReasonforLeaving = TxtReasonLeaving.Text;
        //ObjCls.PFNo = TxtPFNo.Text;
        ObjCls.PanNo = TxtPANNo.Text;
         ObjCls.AdharNo = TxtAadharNo.Text;
        ObjCls.MobNo = TxtMobNo.Text;
        ObjCls.PhoneNo = TxtPhoneNo.Text;
        ObjCls.Remarks = TxtRemarks.Text;
                ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public override void FnCancel()
    {
        base.FnCancel();
        TxtName.Text = "";
        TxtName_Srch.Text = "";
        TxtAdhar_Srch.Text = "";
        TxtAdmNo_Srch.Text = "";
        TxtRegNo_Srch.Text = "";
        TxtApporderNo.Text = "";
        TxtRegNo.Text = "";
        TxtProbationaryPeriod.Text = "";
        CtrlDOJ.DateText = "";
        CtrlDob.DateText = "";
        DdlAppointmentNature.SelectedIndex = 0;
        TxtPermanentAddress.Text = "";
        TxtTemproraryAddress.Text = "";
        DdlBloodGrp.SelectedIndex = 0;
        TxtBankAccNo.Text = "";
        TxtBankName.Text = "";
        TxtBranchName.Text = "";
        TxtIFSC.Text = "";
        DdlSubject.SelectedIndex = 0;
        DdlTraining.SelectedIndex = 0;
        DdlExperiance.SelectedIndex = 0;
        CtrlGrdDepartment.SelectedValue = "0";
        CtrlGrdDepartment.SelectedText = "";
        DdlOfficialStatus.SelectedIndex = 0;
        DdlState.SelectedIndex = 0;
        CtrlQualification.SelectedValue = "0";
        CtrlQualification.SelectedText = "";
        DdlAccountHead.SelectedIndex = 0;
        DdlAccountGroup.SelectedIndex = 0;
        CtrlDesignation.SelectedValue = "0";
        CtrlDesignation.SelectedText = "";
        TxtReasonLeaving.Text = "";
        TxtPFNo.Text = "";
        TxtPANNo.Text = "";
        TxtAadharNo.Text = "";
        TxtMobNo.Text = "";
        TxtPhoneNo.Text = "";
        TxtRemarks.Text = "";


        ChkActive.Checked = true;

        FnNoneImage(ImgItem);

        //HdnId.Value = "";
        //LblStudentName.Text = "";
        //LblStudentId.Text = "";

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName_Srch.Text.Trim();
        ObjCls.AdmissionNo = TxtAdmNo_Srch.Text.Trim();
        ObjCls.RegNo = TxtRegNo_Srch.Text.Trim();
        ObjCls.AdharNo = TxtAdhar_Srch.Text.Trim();
        //ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass_Srch.SelectedValue.ToString());
        //ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDiv_Srch.SelectedValue.ToString());

        //DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT *  FROM TblRegistration") as DataSet).Tables[0];
        //DataTable ClsTGFM1 = (ObjCls.FnGetDataSet("SELECT *  FROM VwRegistration") as DataSet).Tables[0];

        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        TabContainer1.ActiveTabIndex = 1;
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;
    }

    public void FnPrintRecord()
    {
        throw new NotImplementedException();
    }

    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    if (TxtName.Text.Trim().Length <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                        FnFocus(TxtName);
                        return;
                    }

                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "CLEAR":
                    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
                    FnCancel();
                    break;
                case "CLOSE":
                    ObjCls.FnAlertMessage(" You Have No permission To Close Record");
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "FIND":
                    FnFindRecord();
                    //FnAssignProperty();
                    //base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    //FnGridViewBinding("");
                    //System.Threading.Thread.Sleep(1000000);
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
                case "FIRST":
                    //========Code
                    break;
                case "PREVIOUS":
                    //========Code
                    break;
                case "NEXT":
                    //========Code
                    break;
                case "LAST":
                    //========Code
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

  

    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsRegistration(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ObjCls.TType = FnGetRights().TTYPE;
        TxtCode.Text = ObjCls.FnGetAutoCode().ToString();
        Session["IMG_PRF"] = "";
        Session["IMGBYTES"] = "";
        Session["REG_ID"] = "0";
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");



    }

    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            DataTable dt = ViewState["DT"] as DataTable;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            Session["REG_ID"] = ViewState["ID"].ToString();

            TxtName.Text = ObjCls.Name;
            TxtCode.Text = ObjCls.Code;
            TxtRegNo.Text = ObjCls.RegNo;
            TxtApporderNo.Text = ObjCls.ApplicationNo;
            //TxtProbationaryPeriod.Text = ObjCls.ProbationaryPeriod;
            //CtrlDOJ.DateText = ObjCls.FnDateTime(ObjCls.DOJ, "");

            CtrlDob.DateText = ObjCls.FnDateTime(ObjCls.Dob, "");
            RadBtnGender.Text = ObjCls.Sex.ToString();
            RadBtnMaritalStatus.Text = ObjCls.MStatus.ToString();
            
            //FnSetDropDownValue(DdlAppointmentNature, ObjCls.AppointmentNature.ToString());

            TxtPermanentAddress.Text = ObjCls.PAddress.ToString();
            TxtTemproraryAddress.Text = ObjCls.CAddress.ToString();
            FnSetDropDownValue(DdlBloodGrp, ObjCls.BloodGroup.ToString());
            TxtBankAccNo.Text = ObjCls.BankAccNo.ToString();
            TxtBankName.Text = ObjCls.BankName.ToString();
            TxtBranchName.Text = ObjCls.BankBranch.ToString();
            TxtIFSC.Text = ObjCls.BankIfsc.ToString();
           
            //FnSetDropDownValue(DdlSubject, ObjCls.Subject.ToString());
            //FnSetDropDownValue(DdlTraining, ObjCls.Training.ToString());
            //FnSetDropDownValue(DdlExperiance, ObjCls.Experiance.ToString());
            //CtrlGrdDepartment.SelectedText = ObjCls.DepartmentName.ToString();
            //CtrlGrdDepartment.SelectedValue = ObjCls.DepartmentId.ToString();

            //FnSetDropDownValue(DdlOfficialStatus, ObjCls.OfficialStatus.ToString());
            FnSetDropDownValue(DdlState, ObjCls.StateId.ToString());
           
            //CtrlQualification.SelectedText = ObjCls.QualificationName.ToString();
            //CtrlQualification.SelectedValue = ObjCls.QualificationId.ToString();
            
            FnSetDropDownValue(DdlAccountHead, ObjCls.AccLedgerId.ToString());
            //FnSetDropDownValue(DdlAccountGroup, ObjCls.AccGroup.ToString());
            
            //CtrlDesignation.SelectedText = ObjCls.DesigName.ToString();
            CtrlDesignation.SelectedValue = ObjCls.DesigId.ToString();
            //TxtReasonLeaving.Text = ObjCls.ReasonforLeaving.ToString();
            //TxtPFNo.Text = ObjCls.PFNo.ToString();
            TxtPANNo.Text = ObjCls.PanNo.ToString();
            TxtAadharNo.Text = ObjCls.AdharNo.ToString();
           

            TxtMobNo.Text = ObjCls.MobNo.ToString();
            TxtPhoneNo.Text = ObjCls.PhoneNo.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();
           
            Session["IMG_PRF"] = ObjCls.ImgePath;
           // Session["IMGBYTES"] = ObjCls.ImageByte;
            //FnSetImage(ImgItem, ObjCls.ImgePath);

           // FnConvertByteToImge((byte[])((Session["IMGBYTES"])), ImgItem);
            //ViewState["TEMPID"] = ObjCls.ImgTempId.ToString();

           
            ChkActive.Checked = ObjCls.Active;

            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void FileUploadImg_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        try
        {
            string[] allowed = FnGetImageFormat(ref _strFileFormat);
            if (FileUploadImg.PostedFile != null && FileUploadImg.PostedFile.ContentLength > 0)
            {
                if (allowed.Contains(Path.GetExtension(e.FileName)))
                {
                    if (FnValidateFileSize(FileUploadImg, 0, 255, 600) == true)
                    {
                        Session["IMG_PRF"] = FnSaveUploadFileName(ObjCls, e.FileName, "PRF");
                        _strDestPath = FnServerUploadPath(FnProfileFilePath(Session["IMG_PRF"].ToString().Trim()));
                        FileUploadImg.PostedFile.SaveAs(_strDestPath);
                        Session["IMGBYTES"] = FnGenerateThumbnail(_strDestPath, ref _strImgeByte);
                    }
                    else
                    {
                        FileUploadImg.Attributes.Clear();
                        FileUploadImg.Dispose();
                        Session["IMG_PRF"] = "";
                        Session["IMGBYTES"] = "";
                        FnPopUpAlert(ObjCls.FnAlertMessage(_strFileFormat));
                        return;
                    }
                }
                else
                {
                    FnPopUpAlert(ObjCls.FnAlertMessage(_strFileFormat));
                }
            }
        }
        catch (Exception ex)
        {
            // FnPopUpAlert(_strFileFormat);
            throw ex;
        }
    }

}