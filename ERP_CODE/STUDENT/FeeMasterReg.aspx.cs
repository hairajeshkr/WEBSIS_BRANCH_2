using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_FeeMasterReg : ClsPageEvents,IPageInterFace
{
    ClsFeeMaster ObjCls = new ClsFeeMaster();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                TxtOrderIndex.Attributes.Add("onkeydown", "return NumbersOnly(event);");
                ObjLst.FnGetBranchList(DdlCmp, "");
                ObjLst.FnGetFeeTypeList(DdlFeeType, "");
                ObjLst.FnGetFeeTypeList(DdlFeeType_Srch, "");                
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
        ObjCls = new ClsFeeMaster(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ObjCls.TType = FnGetRights().TTYPE;
        ObjCls.MenuId = FnGetRights().MENUID;
        TxtCode.Text = ObjCls.FnGetAutoCode().ToString();
        DdlCmp.SelectedIndex = iBrId;
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.PrintName= TxtPrintName.Text.Trim();
        ObjCls.OrderIndex= ObjCls.FnIsNumeric(TxtOrderIndex.Text.Trim());
        ObjCls.FeeTypeId = ObjCls.FnIsNumeric(DdlFeeType.SelectedValue.ToString());
        ObjCls.AccLedgerId = ObjCls.FnIsNumeric(CtrlGrdAcc.SelectedValue.ToString());
        ObjCls.AccCmpId= ObjCls.FnIsNumeric(DdlCmp.SelectedValue.ToString());
        ObjCls.Remarks = TxtRemarks.Text.Trim();
        ObjCls.IsExcludeFine = ObjCls.FnIsNumeric(ChkExfrmFine.Checked == true ? true : false);
        ObjCls.IsShow = ObjCls.FnIsNumeric(ChkSwPro.Checked == true ? true : false);
        ObjCls.IsTutionFee = ObjCls.FnIsNumeric(ChkTutFee.Checked == true ? true : false);
        ObjCls.IsLedger = 0;
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
        //ObjCls.IsApprove = (ChkApprove.Checked == true ? true : false);
    }
    public override void FnCancel()
    {
        base.FnCancel();
        TxtName.Text = "";
        TxtPrintName.Text = "";
        TxtOrderIndex.Text = "";
        TxtCode_Srch.Text = "";
        TxtRemarks.Text = "";
        DdlFeeType.SelectedIndex = 0;
        DdlCmp.SelectedIndex = 0;
        DdlFeeType_Srch.SelectedIndex = 0;
        CtrlGrdAcc.SelectedValue = "0";
        CtrlGrdAcc.SelectedText = "";
        ChkActive.Checked = true;
        ChkExfrmFine.Checked = false;
        ChkExfrmFine.Checked = false;
        ChkSwPro.Checked = false;
        ChkTutFee.Checked = false;
        ChkPrintName.Checked = false;

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        FnFocus(TxtName);
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName_Srch.Text.Trim();
        ObjCls.Code = TxtCode_Srch.Text.Trim();
        ObjCls.FeeTypeId = ObjCls.FnIsNumeric(DdlFeeType_Srch.SelectedValue.ToString());
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
            TxtPrintName.Text = ObjCls.PrintName.ToString();
            TxtOrderIndex.Text = ObjCls.OrderIndex.ToString();
            DdlCmp.SelectedValue = ObjCls.AccCmpId.ToString();
            DdlFeeType.SelectedValue = ObjCls.FeeTypeId.ToString();
            CtrlGrdAcc.SelectedValue = ObjCls.AccLedgerId.ToString();
            CtrlGrdAcc.SelectedText = ObjCls.AccLedgerName;

            ChkSwPro.Checked = (ObjCls.IsShow > 0 ? true : false);
            ChkExfrmFine.Checked = (ObjCls.IsExcludeFine > 0 ? true : false);
            ChkTutFee.Checked = (ObjCls.IsTutionFee > 0 ? true : false);

            TxtRemarks.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";
            TabContainer1.ActiveTabIndex = 0;
            //ChkApprove.Checked = ObjCls.IsApprove;
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

    protected void ChkPrintName_CheckedChanged(object sender, EventArgs e)
    {
        // Check if the checkbox is checked
        if (ChkPrintName.Checked)
        {
            // Copy the text from TextBox1 to TextBox2
            TxtPrintName.Text = TxtName.Text;
        }
        else
        {
            // Clear TextBox2 if checkbox is unchecked
            TxtPrintName.Text = string.Empty;
        }
    }



}