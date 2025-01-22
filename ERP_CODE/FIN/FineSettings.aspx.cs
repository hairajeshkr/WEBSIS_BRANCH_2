using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FIN_FineSettings : ClsPageEvents, IPageInterFace
{
    ClsFineSettings ObjCls = new ClsFineSettings();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    TextBox TxtAmount = null, TxtPerAmt = null, TxtRemarks = null;
    HiddenField HdnStudentId = null, HdnId = null;
    CtrlDate CtrlTrDate = null;
    int iCnt = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                ObjLst.FnGetInstallmentList(DdlInslment, "");
                ObjLst.CompanyId = FnGetRights().COMPANYID;
                ObjLst.BranchId = FnGetRights().BRANCHID;
                ViewState["DT_TRE"] = ObjLst.FnGetClassDetailedList();
                _dwMainRecord = new DataView(ViewState["DT_TRE"] as DataTable);
                _dwMainRecord.RowFilter = " ParentId=0";
                _dwMainRecord.Sort = "OrderIndex ASC";
                this.FnPopulateTreeView(_dwMainRecord.ToTable(), 0, null);
            }
            CtrlGridClass.ParentControl = CtrlGrdGroup.IdControl;
            CtrlGridDivision.ParentControl = CtrlGridClass.IdControl;
            CtrlGridStudent.ParentControl = CtrlGridDivision.IdControl;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    private void FnPopulateTreeView(DataTable dtParent, int PrmParentId, TreeNode treeNode)
    {
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["Name"].ToString(),
                Value = row["Id"].ToString()
            };
            if (PrmParentId == 0)
            {
                TreVwLst.Nodes.Add(child);
                _dwMainRecord = new DataView(ViewState["DT_TRE"] as DataTable);
                _dwMainRecord.RowFilter = " ParentId=" + ObjCls.FnIsNumeric(child.Value);
                _dwMainRecord.Sort = "OrderIndex ASC";
                FnPopulateTreeView(_dwMainRecord.ToTable(), 1, child);
            }
            else if (PrmParentId == 1)
            {
                treeNode.ChildNodes.Add(child);
                _dwMainRecord = new DataView(ViewState["DT_TRE"] as DataTable);
                _dwMainRecord.RowFilter = " ParentId=" + ObjCls.FnIsNumeric(child.Value);
                _dwMainRecord.Sort = "OrderIndex ASC";
                FnPopulateTreeView(_dwMainRecord.ToTable(), 2, child);
            }
            else
            {
                treeNode.ChildNodes.Add(child);
            }
        }
    }
    public override void FnInitializeForm()
    {
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsFineSettings(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT_MAIN"] = ObjLst.FnGetFineMasterList();
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        CtrlCommand1.IsVisibleSave = false;
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);

        ObjCls.AccCmpId = FnGetRights().BRANCHID;
        ObjCls.InstalmentId = ObjCls.FnIsNumeric(DdlInslment.SelectedValue);
        ObjCls.InstituteGrpId = ObjCls.FnIsNumeric(CtrlGrdGroup.SelectedValue);
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGridClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGridDivision.SelectedValue);
        ObjCls.StudentId = ObjCls.FnIsNumeric(CtrlGridStudent.SelectedValue);
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        DdlInslment.SelectedIndex = 0;
        CtrlGrdGroup.SelectedValue = "0";
        CtrlGrdGroup.SelectedText = "";

        CtrlGridClass.SelectedValue = "0";
        CtrlGridClass.SelectedText = "";

        CtrlGridDivision.SelectedValue = "0";
        CtrlGridDivision.SelectedText = "";

        CtrlGridStudent.SelectedValue = "0";
        CtrlGridStudent.SelectedText = "";

        FnFocus(CtrlGrdGroup.ControlTextBox);
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        CtrlCommand1.IsVisibleSave = true;
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource = ViewState["DT_MAIN"] as DataTable;
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
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            if (ObjCls.FnIsNumeric(DdlInslment.SelectedValue.ToString()) <= 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage("Please select valid installment"));
                                FnFocus(DdlInslment);
                                return;
                            }

                            FnAssignProperty();                          
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                TxtAmount = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtAmount");
                                TxtPerAmt = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPerAmt");

                                CtrlTrDate = (CtrlDate)GrdVwRecords.Rows[i].FindControl("CtrlTrDate");
                                TxtRemarks = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRemarks");

                                ObjCls.TrDate = ObjCls.FnDateTime(DateTime.Now.ToString("dd/MMM/yyyy"));
                                ObjCls.DueDate = ObjCls.FnDateTime(CtrlTrDate.DateText);

                                ObjCls.FineMasterId = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.Amount = ObjCls.FnIsDouble(TxtAmount.Text);
                                ObjCls.PerAmt = ObjCls.FnIsDouble(TxtPerAmt.Text);
                                ObjCls.Remarks = TxtRemarks.Text.Trim();

                                _strMsg = ObjCls.SaveRecord() as string;

                                if (ObjCls.FnIsDouble(TxtAmount.Text) > 0 || ObjCls.FnIsDouble(TxtPerAmt.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }
                            FnCancel();
                            TreVwLst.CollapseAll();
                            CtrlGrdGroup.Focus();
                            TreVwLst.SelectedNode.Selected = false;
                            break;
                    }
                    break;
                case "FIND":
                    if (ObjCls.FnIsNumeric(DdlInslment.SelectedValue.ToString()) <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please select valid installment"));
                        FnFocus(DdlInslment);
                        return;
                    }
                    FnFindRecord();
                    break;
                case "CLEAR":
                    FnCancel();
                    TreVwLst.CollapseAll();
                    CtrlGrdGroup.Focus();
                    TreVwLst.SelectedNode.Selected = false;
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
    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            FnCancel();
            if (TreVwLst.SelectedNode.Depth == 0)
            {
                CtrlGrdGroup.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdGroup.SelectedText = TreVwLst.SelectedNode.Text;
            }
            else if (TreVwLst.SelectedNode.Depth == 1)
            {
                CtrlGrdGroup.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGrdGroup.SelectedText = TreVwLst.SelectedNode.Parent.Text;

                CtrlGridClass.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGridClass.SelectedText = TreVwLst.SelectedNode.Text;
            }
            else if (TreVwLst.SelectedNode.Depth == 2)
            {
                CtrlGrdGroup.SelectedValue = TreVwLst.SelectedNode.Parent.Parent.Value;
                CtrlGrdGroup.SelectedText = TreVwLst.SelectedNode.Parent.Parent.Text;

                CtrlGridClass.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGridClass.SelectedText = TreVwLst.SelectedNode.Parent.Text;

                CtrlGridDivision.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGridDivision.SelectedText = TreVwLst.SelectedNode.Text;
            }
            //FnFindRecord();
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {
                    HdnId = (HiddenField)e.Row.FindControl("HdnId");
                    TxtAmount = (TextBox)e.Row.FindControl("TxtAmount");
                    TxtPerAmt = (TextBox)e.Row.FindControl("TxtPerAmt");
                    CtrlTrDate = (CtrlDate)e.Row.FindControl("CtrlTrDate");
                    TxtRemarks = (TextBox)e.Row.FindControl("TxtRemarks");

                    FnSetValue(ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")), CtrlTrDate, TxtAmount, TxtPerAmt, TxtRemarks);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void FnSetValue(int PrmId, CtrlDate PrmCtrlDate, TextBox PrmTxtAmt, TextBox PrmTxtPer, TextBox PrmTxtRemarks)
    {
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            _dwMainRecord.RowFilter = "FineMasterId=" + PrmId;
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                PrmCtrlDate.DateText = FnGetDateString(DT_RECORD.Rows[0]["DueDate"].ToString());
                PrmTxtAmt.Text = FnGetDoubleString(DT_RECORD.Rows[0]["Amount"].ToString());
                PrmTxtPer.Text = FnGetDoubleString(DT_RECORD.Rows[0]["PerAmt"].ToString());
                PrmTxtRemarks.Text = DT_RECORD.Rows[0]["Remarks"].ToString();
            }
            else
            {
                PrmCtrlDate.DateText = "";
                PrmTxtAmt.Text = "";
                PrmTxtPer.Text = "";
                PrmTxtRemarks.Text = "";
            }
        }
    }
}