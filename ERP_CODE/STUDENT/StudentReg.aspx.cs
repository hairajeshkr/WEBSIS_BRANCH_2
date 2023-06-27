using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentReg : ClsPageEvents, IPageInterFace
{
    ClsRegistrationStudent ObjCls = new ClsRegistrationStudent();
    ClsDropdownRecordList ObjLst= new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ObjLst.FnGetStudentLedgerList(DdlAccountLedger, "");
                ViewState["SALT"] = ObjLst.FnGetSalutationList() as DataTable;
                FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltn, "");
                FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltnFthr, "");
                FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltnMthr, "");
                ObjLst.FnGetLanguageList(DdlLanguage, "");

                FnBindDocumetPath(HyLnkImg, "1", "PRF");
                FnGetPopUpWindowDispaly("Profile Image", HyLnkImg, 600, 350, "../FileShow.aspx?PDF=0&FILE_TYPE=PRF_IMG", LblScript);
                //FnGetPopUpWindowDispaly("Staff Reviced Details", HyLnkBtnAdd, 850, 545, FnGetQueryString("StaffSubDetails.aspx", ViewState["ID"].ToString()), LblScript);

                FnInitializeForm();
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
            CtrlGrdCommunity.ParentControl = CtrlGrdReligion.IdControl;
            CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
            CtrlGrdDiv_Srch.ParentControl = CtrlGrdClass_Srch.IdControl;
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
        ObjCls = new ClsRegistrationStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ObjCls.TType = FnGetRights().TTYPE;
        TxtCode.Text = ObjCls.FnGetAutoCode().ToString();
        Session["IMG_PRF"] = "";
        Session["IMGBYTES"] = "";
        Session["REG_ID"] = "0";
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.InstituteId = FnGetRights().BRANCHID;

        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.DisplayName = FnCombineString(DdlSaltn.SelectedItem.ToString(), TxtName.Text.Trim());

        ObjCls.AdmissionNo = TxtAdmnNo.Text.Trim();
        ObjCls.RegNo = TxtRegNo.Text.Trim();
        ObjCls.StudentCode = TxtStudentCode.Text.Trim();

        ObjCls.SaluationId = ObjCls.FnIsNumeric(DdlSaltn.SelectedValue.ToString());
        ObjCls.Dob = ObjCls.FnDateTime(CtrlDob.DateText);
        ObjCls.Sex = RadBtnGender.SelectedValue.ToString();
        ObjCls.NationalityId = ObjCls.FnIsNumeric(CtrlGrdCountry.SelectedValue.ToString());
        ObjCls.PlaceofBirth = CtrlGrdPlace.SelectedText.ToString();
        ObjCls.ReligionId = ObjCls.FnIsNumeric(CtrlGrdReligion.SelectedValue.ToString());
        ObjCls.CommunityId = ObjCls.FnIsNumeric(CtrlGrdCommunity.SelectedValue.ToString());
        ObjCls.CategoryId = ObjCls.FnIsNumeric(CtrlGrdCategory.SelectedValue.ToString());
        //ObjCls.ReligionId = ObjCls.FnIsNumeric(CtrlGrdReligion.SelectedValue.ToString());
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue.ToString());

        ObjCls.ImgePath = Session["IMG_PRF"].ToString();
        //ObjCls.ImgTempId = ObjCls.FnIsNumeric(ViewState["TEMPID"].ToString());
        if (Session["IMGBYTES"].ToString().Trim().Length > 0)
        {
            ObjCls.ImageByte = (byte[])((Session["IMGBYTES"]));
        }

        ObjCls.FatherSaluationId = ObjCls.FnIsNumeric(DdlSaltnFthr.SelectedValue.ToString());
        ObjCls.FatherName = TxtFatherName.Text;
        ObjCls.MotherSaluationId = ObjCls.FnIsNumeric(DdlSaltnMthr.SelectedValue.ToString());
        ObjCls.MotherName = TxtMotherName.Text;
        ObjCls.JoinDate = ObjCls.FnDateTime(CtrlAdmnDate.DateText);
        ObjCls.AdharNo = TxtAdharNo.Text.Trim();
        ObjCls.MotherLanguageId = ObjCls.FnIsNumeric(DdlLanguage.SelectedValue.ToString());
        ObjCls.AccLedgerId = ObjCls.FnIsNumeric(DdlAccountLedger.SelectedValue.ToString());
        ObjCls.BloodGroup = DdlBloodGrp.SelectedValue.ToString();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
        ObjCls.Active = (ChkActive.Checked == true ? true : false);

        //ObjCls.FaxNo = TxtFaxNo.Text.Trim();
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        FnInitializeForm();
        TxtName.Text = "";
        TxtName_Srch.Text = "";
        TxtAdhar_Srch.Text = "";
        TxtAdmNo_Srch.Text = "";
        TxtRegNo_Srch.Text = "";
        CtrlGrdClass_Srch.SelectedValue = "0";
        CtrlGrdClass_Srch.SelectedText = "";
        CtrlGrdDiv_Srch.SelectedValue = "0";
        CtrlGrdDiv_Srch.SelectedText = "";
        //==============================================================
        DdlSaltn.SelectedIndex = 0;
        DdlSaltnFthr.SelectedIndex = 0;
        DdlSaltnMthr.SelectedIndex = 0;
        TxtFatherName.Text = "";
        TxtMotherName.Text = "";
        TxtRegNo.Text = "";
        TxtStudentCode.Text = "";
        TxtAdmnNo.Text = "";
        CtrlGrdCommunity.SelectedValue = "0";
        CtrlGrdCommunity.SelectedText = "";
        CtrlGrdReligion.SelectedValue = "0";
        CtrlGrdReligion.SelectedText = "";
        CtrlGrdCategory.SelectedValue = "0";
        CtrlGrdCategory.SelectedText = "";
        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";
        CtrlGrdDivision.SelectedValue = "0";
        CtrlGrdDivision.SelectedText = "";
        CtrlGrdPlace.SelectedValue = "0";
        CtrlGrdPlace.SelectedText = "";
        TxtAge.Text = "";
        DdlAccountLedger.SelectedIndex = 0;
        CtrlGrdCountry.SelectedValue = "0";
        CtrlGrdCountry.SelectedText = "";
        DdlLanguage.SelectedIndex = 0;
        DdlBloodGrp.SelectedIndex = 0;

        TxtAdharNo.Text = "";
        CtrlDob.DateText = "";
        CtrlAdmnDate.DateText = "";
        TxtRemarks.Text = "";
        ChkActive.Checked = true;

        FnNoneImage(ImgItem);

        HdnId.Value = "";
        LblStudentName.Text = "";
        LblStudentId.Text = "";

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
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass_Srch.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDiv_Srch.SelectedValue.ToString());

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
    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            Session["REG_ID"] = ViewState["ID"].ToString();

            DdlSaltn.Text = ObjCls.SaluationId.ToString();
            TxtName.Text = ObjCls.Name;
            TxtCode.Text = ObjCls.Code;
            TxtRegNo.Text = ObjCls.RegNo;
            TxtAdmnNo.Text = ObjCls.AdmissionNo;
            TxtStudentCode.Text = ObjCls.StudentCode;
            TxtAdharNo.Text = ObjCls.AdharNo;

            CtrlDob.DateText = ObjCls.FnDateTime(ObjCls.Dob, "");
            TxtAge.Text = ObjCls.Age.ToString();

            CtrlAdmnDate.DateText = ObjCls.FnDateTime(ObjCls.JoinDate, "");
            RadBtnGender.Text = ObjCls.Sex.ToString();
            DdlBloodGrp.Text = ObjCls.BloodGroup.ToString();

            CtrlGrdCountry.SelectedText = ObjCls.NationalityName.ToString();
            CtrlGrdCountry.SelectedValue = ObjCls.NationalityId.ToString();

            CtrlGrdPlace.SelectedText = ObjCls.PlaceofBirth.ToString();

            CtrlGrdCommunity.SelectedText = ObjCls.CommunityName.ToString();
            CtrlGrdCommunity.SelectedValue = ObjCls.CommunityId.ToString();

            CtrlGrdReligion.SelectedText = ObjCls.ReligionName.ToString();
            CtrlGrdReligion.SelectedValue = ObjCls.ReligionId.ToString();

            CtrlGrdCategory.SelectedText = ObjCls.CategoryName.ToString();
            CtrlGrdCategory.SelectedValue = ObjCls.CategoryId.ToString();

            CtrlGrdClass.SelectedText = ObjCls.ClassName.ToString();
            CtrlGrdClass.SelectedValue = ObjCls.ClassId.ToString();

            CtrlGrdDivision.SelectedText = ObjCls.DivisionName.ToString();
            CtrlGrdDivision.SelectedValue = ObjCls.DivisionId.ToString();

            DdlSaltnFthr.Text = ObjCls.FatherSaluationId.ToString();
            TxtFatherName.Text = ObjCls.FatherName;
            DdlSaltnMthr.Text = ObjCls.MotherSaluationId.ToString();
            TxtMotherName.Text = ObjCls.MotherName;

            DdlLanguage.Text = ObjCls.MotherLanguageId.ToString();
            DdlAccountLedger.Text = ObjCls.AccLedgerId.ToString();

            Session["IMG_PRF"] = ObjCls.ImgePath;
            if (ObjCls.ImageByte.Length > 0)
            {
                Session["IMGBYTES"] = ObjCls.ImageByte;
                FnConvertByteToImge((byte[])((Session["IMGBYTES"])), ImgItem);
            }
            //ViewState["TEMPID"] = ObjCls.ImgTempId.ToString();

            TxtRemarks.Text = ObjCls.Remarks.ToString();
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
    protected void GrdVwRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField HdnAutoId = (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnId");
            LinkButton LnkName = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkName");
            LinkButton LnkStudentCode = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkStudentCode");
            HdnId.Value = HdnAutoId.Value;
            LblStudentName.Text = LnkName.Text;
            LblStudentId.Text = LnkStudentCode.Text;

            _strHdr = "Student Id :-" + LnkStudentCode.Text + " , " + LnkName.Text;
            _strUrl = "StudentAddress.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "ADDRESS DETAILS : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',900,600);";
            ImgAddress.Attributes.Add("onClick", _strLnk);

            _strUrl = "StudentPrvEdu.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "EDUCATION DETAILS : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',770,450);";
            ImgEducation.Attributes.Add("onClick", _strLnk);

 

            _strUrl = "StudentSibling.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "SIBLING DETAILS : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',770,450);";
            ImgSibling.Attributes.Add("onClick", _strLnk);

            _strUrl = "StudentAdmissionDtls.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "ADMISSION DETAILS : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',770,450);";
            ImgStudent.Attributes.Add("onClick", _strLnk);

            _strUrl = "StudentHobbiesDtls.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "HOBBIES & ACTIVITIES : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',770,450);";
            ImgHobby.Attributes.Add("onClick", _strLnk);

            _strUrl = "StudentDocumentUpload.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strTitle = "DOCUMENT UPLOAD : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',770,450);";
            ImgDocument.Attributes.Add("onClick", _strLnk);



            TabContainer1.ActiveTabIndex = 2;
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