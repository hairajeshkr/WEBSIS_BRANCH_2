using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class STUDENT_StudentAdmissionDtls : ClsPageEvents, IPageInterFace
{
    ClsStudentAdmissionDetails ObjClsStudAdmm = new ClsStudentAdmissionDetails();


    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
               // TxtPercentage.Attributes.Add("onkeydown", "return NumbersOnly(event);");
                FnInitializeForm();
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjClsStudAdmm.FnAlertMessage(ex.Message));
        }
    }

    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjClsStudAdmm = new ClsStudentAdmissionDetails(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        //ViewState["DT"] = FnGetGeneralTable(ObjCls);
        Session["DOC"] = "";
        FnFindRecord();
    }


    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjClsStudAdmm);
        ObjClsStudAdmm.StudentId = ObjClsStudAdmm.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjClsStudAdmm.Rank = TxtRank.Text.Trim();
        ObjClsStudAdmm.ClassId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdAdmmisionClass.SelectedValue.ToString());
        ObjClsStudAdmm.QuotaId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdQuota.SelectedValue.ToString());
        ObjClsStudAdmm.CategoryId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdCategory.SelectedValue.ToString());

    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        TxtRank.Text = "";
        CtrlGrdAdmmisionClass.SelectedValue = "";
        CtrlGrdQuota.SelectedValue = "";
        CtrlGrdCategory.SelectedValue = "";

        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        FnFocus(TxtRank);
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjClsStudAdmm);
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
        GrdVwRecords.DataKeyNames = new String[] { ObjClsStudAdmm.KeyName };
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
                    if (TxtRank.Text.Trim().Length <= 0)
                    {
                        FnPopUpAlert(ObjClsStudAdmm.FnAlertMessage("Please enter the education"));
                        FnFocus(TxtRank);
                        return;
                    }
                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjClsStudAdmm, false);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjClsStudAdmm, false);
                            break;
                    }
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjClsStudAdmm, false);
                    break;
                case "CLEAR":
                    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
                    FnCancel();
                    break;
                case "CLOSE":
                    ObjClsStudAdmm.FnAlertMessage(" You Have No permission To Close Record");
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjClsStudAdmm, false);
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "HELP":
                    ObjClsStudAdmm.FnAlertMessage(" You Have No permission To Help Record");
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjClsStudAdmm.FnAlertMessage(ex.Message));
        }
    }


    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjClsStudAdmm.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjClsStudAdmm.ID.ToString();

            //ObjClsStudAdmm.Rank = TxtRank.Text.Trim();
            //ObjClsStudAdmm.ClassId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdAdmmisionClass.SelectedValue.ToString());
            //ObjClsStudAdmm.QuotaId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdQuota.SelectedValue.ToString());
            //ObjClsStudAdmm.CategoryId = ObjClsStudAdmm.FnIsNumeric(CtrlGrdCategory.SelectedValue.ToString());

            TxtRank.Text = ObjClsStudAdmm.Rank.ToString();
            CtrlGrdAdmmisionClass.SelectedValue = ObjClsStudAdmm.ClassId.ToString();
            CtrlGrdQuota.SelectedValue = ObjClsStudAdmm.QuotaId.ToString();
            CtrlGrdCategory.SelectedValue = ObjClsStudAdmm.CategoryId.ToString();

            ViewState["DT_UPDATE"] = ObjClsStudAdmm.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 1;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjClsStudAdmm.FnAlertMessage(ex.Message));
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
            FnPopUpAlert(ObjClsStudAdmm.FnAlertMessage(ex.Message));
        }
    }


}