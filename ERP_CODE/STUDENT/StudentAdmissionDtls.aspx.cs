﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class STUDENT_StudentAdmissionDtls : ClsPageEvents, IPageInterFace
{
    ClsStudentAdmissionDetails ObjCls = new ClsStudentAdmissionDetails();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
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
        ObjCls = new ClsStudentAdmissionDetails(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        Session["DOC"] = "";
        FnFindRecord();
    }


    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdAdmmisionClass.SelectedValue.ToString());
        ObjCls.QuotaId = ObjCls.FnIsNumeric(CtrlGrdQuota.SelectedValue.ToString());
        ObjCls.Rank = TxtRank.Text.Trim();
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        CtrlGrdAdmmisionClass.SelectedValue = "";
        CtrlGrdAdmmisionClass.SelectedText = "";
        CtrlGrdQuota.SelectedValue = "";
        CtrlGrdQuota.SelectedText = "";
        TxtRank.Text = "";
        TxtRemarks.Text = "";
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 1;
        FnFocus(CtrlGrdAdmmisionClass.ControlTextBox);
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
            
            CtrlGrdAdmmisionClass.SelectedValue = ObjCls.ClassId.ToString();
            CtrlGrdAdmmisionClass.SelectedText = ObjCls.ClassName.ToString();

            CtrlGrdQuota.SelectedValue = ObjCls.QuotaId.ToString();
            CtrlGrdQuota.SelectedValue = ObjCls.QuotaName.ToString();
            TxtRank.Text = ObjCls.Rank.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();

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


}