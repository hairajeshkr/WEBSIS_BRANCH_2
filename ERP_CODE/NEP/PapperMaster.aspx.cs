using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NEP_PapperMaster:ClsPageEvents, IPageInterFace
{
    ClsNEPPapers ObjCls = new ClsNEPPapers();
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
    ObjCls = new ClsNEPPapers(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
    ObjCls.TType = FnGetRights().TTYPE;
    ObjCls.MenuId = FnGetRights().MENUID;

    ViewState["DT"] = FnGetGeneralTable(ObjCls);
    FnGridViewBinding("");
}
public void FnAssignProperty()
{
    base.FnAssignProperty(ObjCls);
    ObjCls.Name = TxtName.Text.Trim();
    ObjCls.Code = TxtCode.Text.Trim();
    ObjCls.NEPPaperPrintName = TxtPrintName.Text.Trim();
    ObjCls.Abbreviation = TxtAbbreviation.Text.Trim();
    ObjCls.NEPPaperGroupID = ObjCls.FnIsNumeric(CtrlGrdPaperGrp.SelectedValue);
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
    TxtCode.Text = "";
        TxtPrintName.Text = "";
        TxtAbbreviation.Text = "";
        CtrlGrdPaperGrp.SelectedValue = "0";
        CtrlGrdPaperGrp.SelectedText = "";
    TxtName_Srch.Text = "";
    TxtCode_Srch.Text = "";

    TxtRemarks.Text = "";
    ChkActive.Checked = true;

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
        TxtPrintName.Text= ObjCls.NEPPaperPrintName.ToString();
        TxtAbbreviation.Text= ObjCls.Abbreviation.ToString();
            CtrlGrdPaperGrp.SelectedValue = ObjCls.NEPPaperGroupID.ToString();
            CtrlGrdPaperGrp.SelectedText = ObjCls.NEPPaperGroupName.ToString();

           // CtrlGrdPaperGrp.SelectedValue = ObjCls.FnIsNumeric(ObjCls.NEPPaperGroupID).ToString();
            TxtRemarks.Text= ObjCls.Remarks;
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
}