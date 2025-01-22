using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_FeeSettings : ClsPageEvents, IPageInterFace
{
    CheckBox ChkVal = null;
    HiddenField HdnId = null, HdnFeeMstId = null;
    DropDownList DdlLedger = null;
    ClsFeeSettings ObjCls = new ClsFeeSettings();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["ACC"] = ObjLst.FnGetAccountLedgerList() as DataTable;
                //ViewState["BR"] = ObjLst.FnGetBranchList(() as DataTable;
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
        ObjCls = new ClsFeeSettings(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        ViewState["DT"] = ObjLst.FnGetFeeMasterList() as DataTable;
        ViewState["DT_CHILD"] = (ObjCls.FindRecord() as DataSet).Tables[0];

        FnGridViewBinding("MAIN");
        FnGridViewBinding("");
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        if (PrmFlag == "MAIN")
        {
            GrdVwRecordsMain.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecordsMain.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecordsMain.DataBind();
            GrdVwRecordsMain.SelectedIndex = -1;
        }
        else
        {
            GrdVwRecords.DataSource = ViewState["DT_CHILD"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
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
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            int iCnt = 0;
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnFeeMstId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnFeeMstId");
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                DdlLedger = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlLedger");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.FeeMasterId = ObjCls.FnIsNumeric(HdnFeeMstId.Value);
                                ObjCls.AccLedgerId = ObjCls.FnIsNumeric(DdlLedger.SelectedValue);
                                _strMsg = ObjCls.UpdateRecord() as string;
                                iCnt = iCnt + 1;
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records updated successfully"));
                            }
                            

                            break;
                    }
                    break;
                case "ADD":
                    FnAssignProperty();
                    int nCnt = 0;
                    string strId = "";
                    for (int i = 0; i <= GrdVwRecordsMain.Rows.Count - 1; i++)
                    {
                        ChkVal = (CheckBox)GrdVwRecordsMain.Rows[i].FindControl("ChkVal");
                        if (ChkVal.Checked == true)
                        {
                            HdnId = (HiddenField)GrdVwRecordsMain.Rows[i].FindControl("HdnId");
                            strId = strId + HdnId.Value + ",";
                            nCnt++;
                        }
                    }
                    if (nCnt > 0)
                    {
                        ObjCls.Remarks = FnRemoveLastValue(strId);
                        ViewState["DT_CHILD"] = (ObjCls.SaveChildRecord() as DataSet).Tables[0];
                        FnGridViewBinding("");
                    }
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
        {
            DdlLedger = (DropDownList)e.Row.FindControl("DdlLedger");
            FnBindingDropDownList(ObjLst, ViewState["ACC"] as DataTable, DdlLedger, "");
            FnSetDropDownValue(DdlLedger, DataBinder.Eval(e.Row.DataItem, "AccLedgerId").ToString());
            e.Row.Attributes.Add("onmouseover", "this.style.cursor=\'pointer\'");
        }
    }

    protected void GrdVwRecordsMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
        {
            ChkVal = (CheckBox)e.Row.FindControl("ChkVal");
            ChkVal.Checked = (ObjCls.FnIsNumeric((ViewState["DT_CHILD"] as DataTable).Compute("Count(ID)", " FeeMasterId= " + ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID"))).ToString()) > 0 ? true : false);
        }
    }
}