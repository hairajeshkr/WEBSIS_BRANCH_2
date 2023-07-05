using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class STUDENT_StudentGrpReg : ClsPageEvents, IPageInterFace
{
    ClsStudentGroup ObjCls = new ClsStudentGroup();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
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
        ObjCls = new ClsStudentGroup(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ObjCls.TType = FnGetRights().TTYPE;
        ObjCls.MenuId = FnGetRights().MENUID;
        TxtCode.Text = ObjCls.FnGetAutoCode().ToString();
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.ParentId = ObjCls.FnIsNumeric(CtrlGrdGrpname.SelectedValue.ToString());
        ObjCls.Abrevation = TxtAbbrv.Text.Trim();
        //ObjCls.GroupType = ChkGrpType.SelectedValue.ToString();
        ObjCls.AdmPrefix = TxtAdmPre.Text.Trim();
        ObjCls.AccCmpId = ObjCls.FnIsNumeric(CtrlGrdAyear.SelectedValue.ToString());
        ObjCls.AdmSuffix = TxtAdmNoSuf.Text.Trim();
        ObjCls.EmpId = ObjCls.FnIsNumeric(CtrlGrdGrpstaff.SelectedValue.ToString());
        ObjCls.FeeRecptSuffix = TxtFeeRecPre.Text.Trim();
        ObjCls.ChronicalOrder = ObjCls.FnIsNumeric(TxtChronOrder.Text.Trim());
        // ObjCls.IsInstitution=(ChkIsIns.Checked == true? true:false);

        ObjCls.Remarks = TxtRemarks.Text.Trim();
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
        TxtCode_Srch.Text = "";
        CtrlGrdGrpname.SelectedText = "";
        CtrlGrdGrpname.SelectedValue = "0";
        TxtAbbrv.Text = "";
        TxtAdmPre.Text = "";
        CtrlGrdAyear.SelectedValue = "0";
        CtrlGrdAyear.SelectedText = "";
        TxtAdmNoSuf.Text = "";
        CtrlGrdGrpstaff.SelectedText = "";
        CtrlGrdGrpstaff.SelectedValue = "0";
        TxtFeeRecPre.Text = "";
        TxtChronOrder.Text = "";
        TxtRemarks.Text = "";
        ChkActive.Checked = true;
        ChkApprove.Checked = false;
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName_Srch.Text.Trim();
        ObjCls.Code = TxtCode_Srch.Text.Trim();
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
            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();
            TxtAbbrv.Text = ObjCls.Abrevation.ToString();
            TxtAdmPre.Text = ObjCls.AdmPrefix.ToString();
            TxtAdmNoSuf.Text = ObjCls.AdmSuffix.ToString();
            TxtFeeRecPre.Text = ObjCls.FeeRecptSuffix.ToString();
            TxtChronOrder.Text = ObjCls.ChronicalOrder.ToString();

            CtrlGrdAyear.SelectedText = ObjCls.AccCmpName;
            CtrlGrdAyear.SelectedValue = ObjCls.AccCmpId.ToString();

            CtrlGrdGrpname.SelectedText = ObjCls.Parent.ToString();
            CtrlGrdGrpname.SelectedValue = ObjCls.ParentId.ToString();

            CtrlGrdGrpstaff.SelectedText = ObjCls.EmpName.ToString();
            CtrlGrdGrpstaff.SelectedValue = ObjCls.EmpId.ToString();

            TxtRemarks.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            //ChkApprove.Checked = ObjCls.IsApprove;
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

}