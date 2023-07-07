using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class STUDENT_StudentPrvEdu : ClsPageEvents, IPageInterFace
{
    ClsStudentPreviousEducation ObjCls = new ClsStudentPreviousEducation();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
                TxtPercentage.Attributes.Add("onkeydown", "return NumbersOnly(event);");
                FnBindYear(ObjCls, DdlYear);
                FnInitializeForm();
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
        ObjCls = new ClsStudentPreviousEducation(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        //ViewState["DT"] = FnGetGeneralTable(ObjCls);
        Session["DOC"] = "";
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjCls.Qualification = TxtEducation.Text.Trim();
        ObjCls.InstituteName = TxtInstitute.Text.Trim();
        ObjCls.Board = TxtBoard.Text.Trim();
        ObjCls.RegNo = TxtRegNo.Text.Trim();
        ObjCls.PassingYear = ObjCls.FnIsNumeric(DdlYear.SelectedValue);
        ObjCls.Percentage = ObjCls.FnIsDouble(TxtPercentage.Text);
        ObjCls.PassingDate = ObjCls.FnDateTime(CtrlTo.MonthYearText);
        ObjCls.FromDate = ObjCls.FnDateTime(CtrlFrm.MonthYearText);
        ObjCls.ToDate = ObjCls.FnDateTime(CtrlTo.MonthYearText);
        ObjCls.UploadFileName = Session["DOC"].ToString();

        ObjCls.Percentage = ObjCls.FnIsNumeric(TxtPercentage.Text);
        ObjCls.Remarks = TxtRemarks.Text.Trim();
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        TxtEducation.Text = "";
        TxtInstitute.Text = "";
        CtrlFrm.FnSetClear();
        CtrlTo.FnSetClear();
        TxtPercentage.Text = "";
        DdlYear.SelectedIndex = 0;
        TxtBoard.Text = "";
        TxtInstitute.Text = "";
        TxtRemarks.Text = "";
        ChkActive.Checked = true;

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        FnFocus(TxtEducation);
        TabContainer1.ActiveTabIndex = 1;
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        TabContainer1.ActiveTabIndex = 0;
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
                    if (TxtEducation.Text.Trim().Length <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the education"));
                        FnFocus(TxtEducation);
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
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
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
            TxtEducation.Text = ObjCls.Qualification.ToString();
            TxtInstitute.Text = ObjCls.InstituteName.ToString();
            TxtBoard.Text = ObjCls.Board.ToString();
            DdlYear.Text = ObjCls.PassingYear.ToString();
            TxtPercentage.Text = ObjCls.Percentage.ToString();
            TxtRegNo.Text = ObjCls.RegNo.ToString();
            Session["DOC"] = ObjCls.UploadFileName;
            FnBindDocumetPath(HyLnkDoc, ObjCls.UploadFileName, "DOC");

            CtrlFrm.MonthYearText = FnGetDateString(ObjCls.FromDate.ToString());
            CtrlTo.MonthYearText = FnGetDateString(ObjCls.ToDate.ToString());

            TxtRemarks.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 1;
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

    protected void FileUploadDoc_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        try
        {
            string[] allowed = FnGetPdfFormat(ref _strFileFormat);
            if (FileUploadDoc.PostedFile != null && FileUploadDoc.PostedFile.ContentLength > 0)
            {
                if (allowed.Contains(Path.GetExtension(e.FileName)))
                {
                    Session["DOC"] = FnSaveUploadFileName(ObjCls, e.FileName, "EDU");
                    FileUploadDoc.PostedFile.SaveAs(FnServerUploadPath(FnDocFilePath("DOC", Session["DOC"].ToString().Trim())));
                }
                else
                {
                    FileUploadDoc.Attributes.Clear();
                    FileUploadDoc.Dispose();
                    Session["DOC"] = "";
                    FnPopUpAlert(ObjCls.FnAlertMessage(_strFileFormat));
                    return;
                }
            }
            else
            {
                FnPopUpAlert(ObjCls.FnAlertMessage(_strFileFormat));
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(_strFileFormat);
            throw ex;
        }
    }
}