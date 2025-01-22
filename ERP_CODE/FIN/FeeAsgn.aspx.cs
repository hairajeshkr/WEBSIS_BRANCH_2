using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FIN_FeeAsgn : ClsPageEvents, IPageInterFace
{
    ClsFeeAssign ObjCls = new ClsFeeAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    TextBox TxtAmount = null, TxtRemarks = null, TxtInstalAmt = null, TxtFeeTotAmt = null;
    HiddenField HdnStudentId = null, HdnId = null, HdnRwIndex = null, HdnIndex = null, HdnFeeId = null;
    CtrlDate CtrlFrmDate = null, CtrlToDate = null;
    GridView GrdVwChld = null;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["DT_INST"] = ObjLst.FnGetInstallmentList();
                ViewState["DT_FEE"] = ObjLst.FnGetFeeMasterList(FnGetRights().COMPANYID, FnGetRights().BRANCHID, FnGetRights().ACYEARID, FnGetRights().FAYEARID);

                ObjLst.CompanyId = FnGetRights().COMPANYID;
                ObjLst.BranchId = FnGetRights().BRANCHID;
                ViewState["DT_TRE"] = ObjLst.FnGetClassDetailedList();
                _dwMainRecord = new DataView(ViewState["DT_TRE"] as DataTable);
                _dwMainRecord.RowFilter = " ParentId=0";
                _dwMainRecord.Sort = "OrderIndex ASC";
                this.FnPopulateTreeView(_dwMainRecord.ToTable(), 0, null);

                FnInitializeForm();
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
        ObjCls = new ClsFeeAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        CtrlCommand1.IsVisibleSave = false;
        ViewState["TOKENNO"] = ObjCls.FnGetTokenId().ToString();
        ViewState["INDX"] = "0";
        ViewState["DT"] = FnGetGeneralTable(ObjCls);

        FnGridViewBinding("");

        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);

        ObjCls.TokenNo = ObjCls.FnIsDouble(ViewState["TOKENNO"].ToString());
        ObjCls.TrDate = ObjCls.FnDateTime(DateTime.Now.ToString("dd/MMM/yyyy"));

        ObjCls.AccCmpId = FnGetRights().BRANCHID;
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

        CtrlGrdGroup.SelectedValue = "0";
        CtrlGrdGroup.SelectedText = "";

        CtrlGridClass.SelectedValue = "0";
        CtrlGridClass.SelectedText = "";

        CtrlGridDivision.SelectedValue = "0";
        CtrlGridDivision.SelectedText = "";

        CtrlGridStudent.SelectedValue = "0";
        CtrlGridStudent.SelectedText = "";

        TxtTotalAmount.Text = "";
        FnFocus(CtrlGrdGroup.ControlTextBox);
        //treev.CollapseAll();
        

    }
    public void FnFindRecord()
    {
        ViewState["INDX"] = "1";
        FnAssignProperty();
        FnFindRecord(ObjCls);
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            _dwMainRecord.RowFilter = " Id>0";
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                TxtTotalAmount.Text = FnGetDoubleString((ViewState["DT"] as DataTable).Compute("SUM(TotalAmt)", "").ToString());
                ViewState["TOKENNO"] = (ViewState["DT"] as DataTable).Rows[0]["TokenNo"].ToString();
            }
        }
        else
        {
            TxtTotalAmount.Text = "";
        }

        FnGridViewBinding("");
        CtrlCommand1.IsVisibleSave = true;
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource = ViewState["DT_INST"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;

        GrdVwSummary.DataSource = ViewState["DT_FEE"] as DataTable;
        GrdVwSummary.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwSummary.DataBind();
        GrdVwSummary.SelectedIndex = -1;
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
                           if (ObjCls.FnIsNumeric(CtrlGrdGroup.SelectedValue.ToString()) <= 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage("Please select valid Institute group "));
                                FnFocus(CtrlGrdGroup.ControlTextBox);
                                return;
                            }
                            FnAssignProperty();
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);

                            FnCancel();
                                                       
                           TreVwLst.CollapseAll();
                            CtrlGrdGroup.Focus();
                            TreVwLst.SelectedNode.Selected = false;
                           
                            break;
                    }
                    break;
                case "FIND":
                    if (ObjCls.FnIsNumeric(CtrlGrdGroup.SelectedValue.ToString()) <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please select valid Institute group "));
                        FnFocus(CtrlGrdGroup.ControlTextBox);
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
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0 && ObjCls.FnIsNumeric(ViewState["INDX"].ToString()) > 0)
                {
                    CtrlFrmDate = (CtrlDate)e.Row.FindControl("CtrlFrmDate");
                    CtrlToDate  = (CtrlDate)e.Row.FindControl("CtrlToDate");
                    TxtInstalAmt = (TextBox)e.Row.FindControl("TxtInstalAmt");

                    GrdVwChld = (GridView)e.Row.FindControl("GrdVwChild");

                    GrdVwChld.DataSource = ViewState["DT_FEE"] as DataTable;
                    GrdVwChld.DataKeyNames = new String[] { ObjCls.KeyName };
                    GrdVwChld.DataBind();

                    for (int iRw = 0; iRw <= GrdVwChld.Rows.Count - 1; iRw++)
                    {
                        TxtAmount = (TextBox)GrdVwChld.Rows[iRw].FindControl("TxtAmount");
                        HdnFeeId = (HiddenField)GrdVwChld.Rows[iRw].FindControl("HdnFeeId");
                        HdnIndex = (HiddenField)GrdVwChld.Rows[iRw].FindControl("HdnRwIndex");
                        HdnIndex.Value = e.Row.RowIndex.ToString();

                        FnSetFeeMasterValue(ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")), ObjCls.FnIsNumeric(HdnFeeId.Value), TxtAmount);
                    }
                    FnSetInstametValue(ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")), CtrlFrmDate, CtrlToDate, TxtInstalAmt);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {
                    TxtAmount = (TextBox)e.Row.FindControl("TxtAmount");
                    FnAutocompleteOff(TxtAmount);
                    HdnRwIndex = (HiddenField)e.Row.FindControl("HdnRwIndex");
                    _strDestControl = GrdVwSummary.ClientID + "," + TxtTotalAmount.ClientID;
                    TxtAmount.Attributes.Add("onkeyup", "return FnUpdateFeeAssign('" + ViewState["TOKENNO"].ToString() + "','" + ViewState["ID"].ToString() + "','" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().FAYEARID + "','" + FnGetRights().TTYPE + "','" + FnGetRights().USERID + "','" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "','" + CtrlGrdGroup.IdControl + "','" + CtrlGridClass.IdControl + "','" + CtrlGridDivision.IdControl + "','" + CtrlGridStudent.IdControl + "','" + TxtAmount.ClientID + "','" + HdnRwIndex.ClientID + "', '" + _strDestControl + "');");
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {
                    TxtFeeTotAmt = (TextBox)e.Row.FindControl("TxtFeeTotAmt");
                    FnSetFeeMasterValue(ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")), TxtFeeTotAmt);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void FnSetInstametValue(int PrmId, CtrlDate PrmCtrlFrmDate, CtrlDate PrmCtrlToDate, TextBox PrmTxtInstalAmt)
    {
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            _dwMainRecord.RowFilter = " InstalmentId=" + PrmId;
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                PrmCtrlFrmDate.DateText = FnGetDateString(DT_RECORD.Rows[0]["StartDate"].ToString());
                PrmCtrlToDate.DateText = FnGetDateString(DT_RECORD.Rows[0]["EndDate"].ToString());
                PrmTxtInstalAmt.Text = FnGetDoubleString(DT_RECORD.Compute("SUM(TotalAmt)", " InstalmentId=" + PrmId.ToString()));
            }
            else
            {

                _dwMainRecord = new DataView(ViewState["DT_INST"] as DataTable);
                _dwMainRecord.RowFilter = " ID=" + PrmId;
                DT_RECORD = _dwMainRecord.ToTable();

                PrmCtrlFrmDate.DateText = FnGetDateString(DT_RECORD.Rows[0]["StartDate"].ToString()); 
                PrmCtrlToDate.DateText = FnGetDateString(DT_RECORD.Rows[0]["EndDate"].ToString());
                PrmTxtInstalAmt.Text = "";
            }
        }
    }
    public void FnSetFeeMasterValue(int PrmInstalmentId, int PrmFeeMasterId, TextBox PrmTxtAmount)
    {
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            _dwMainRecord.RowFilter = " InstalmentId=" + PrmInstalmentId + " AND  FeeMasterId=" + PrmFeeMasterId.ToString();
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                PrmTxtAmount.Text = FnGetDoubleString(DT_RECORD.Rows[0]["TotalAmt"].ToString());
            }
            else
            {
                PrmTxtAmount.Text = "";
            }
        }
    }
    public void FnSetFeeMasterValue(int PrmFeeMasterId, TextBox PrmTxtAmount)
    {
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            _dwMainRecord.RowFilter = " FeeMasterId=" + PrmFeeMasterId.ToString();
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                TxtTotalAmount.Text = FnGetDoubleString((ViewState["DT"] as DataTable).Compute("SUM(TotalAmt)", "").ToString());
                ViewState["TOKENNO"] = (ViewState["DT"] as DataTable).Rows[0]["TokenNo"].ToString();

                PrmTxtAmount.Text = FnGetDoubleString(DT_RECORD.Compute("SUM(TotalAmt)", " FeeMasterId=" + PrmFeeMasterId.ToString()));
            }
            else
            {
                PrmTxtAmount.Text = "";
            }
        }
        else
        {
            PrmTxtAmount.Text = "";
        }
    }
   
}