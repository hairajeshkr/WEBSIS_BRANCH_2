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
    ClsStudentAdmissionDetails ObjCls = new ClsStudentAdmissionDetails();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
                ObjLst.FnGetLanguageList(DdlLanguage, "");

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
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdAdmmisionClass.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue.ToString());
        ObjCls.SecondLanguageId = ObjCls.FnIsNumeric(DdlLanguage.SelectedValue.ToString());
        ObjCls.QuotaId = ObjCls.FnIsNumeric(CtrlGrdQuota.SelectedValue.ToString());
        ObjCls.RollNo = ObjCls.FnIsNumeric(TxtRollNo.Text);
        ObjCls.Rank = TxtRank.Text.Trim();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        //base.FnCancel();
        CtrlGrdQuota.SelectedValue = "";
        CtrlGrdQuota.SelectedText = "";
        DdlLanguage.SelectedIndex = 0;
        TxtRank.Text = "";
        TxtRemarks.Text = "";

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 1;
        FnFocus(CtrlGrdQuota.ControlTextBox);
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjCls.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), DT_RECORD);
            ViewState["ID"] = ObjCls.ID.ToString();

            TxtTrDate.Text = ObjCls.FnDateTime(ObjCls.TrDate, "");
            CtrlGrdAdmmisionClass.SelectedValue = ObjCls.ClassId.ToString();
            CtrlGrdAdmmisionClass.SelectedText = ObjCls.ClassName.ToString();

            CtrlGrdQuota.SelectedValue = ObjCls.QuotaId.ToString();
            CtrlGrdQuota.SelectedText = ObjCls.QuotaName.ToString();

            CtrlGrdDivision.SelectedValue = ObjCls.DivisionId.ToString();
            CtrlGrdDivision.SelectedText = ObjCls.DivisionName.ToString();

            DdlLanguage.Text = ObjCls.SecondLanguageId.ToString();
            TxtRank.Text = ObjCls.Rank.ToString();
            TxtRollNo.Text = ObjCls.RollNo.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();

            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;
        }
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
                            _strMsg = ObjCls.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjCls.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                    }
                    break;
                case "CLEAR":
                    FnCancel();
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
}