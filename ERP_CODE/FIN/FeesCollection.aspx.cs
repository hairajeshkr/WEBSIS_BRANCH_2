using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeesCollection : ClsPageEvents, IPageInterFace
{
    ClsFeeCollection ObjCls = new ClsFeeCollection();
    ClsFeeCollectionTemp ObjChld = new ClsFeeCollectionTemp();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    TextBox TxtTotalFee, TxtConcession, TxtPaid, TxtExcess, TxtPayable, TxtFeeTotAmt = null;

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlTokenEvent1.TokenCommands += new CtrlTokenEvent.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlRewindEvent1.RewindCommands += new CtrlRewindEvent.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ObjLst.FnGetFeeAccountList(DdlAcc, "");
                ObjLst.FnGetFeeTypeList(DdlFeeType, "All");

                ChkSelect.Attributes.Add("onclick", "return GridChkSelectAll();");

                LblHdr.Text = Request.QueryString["TITLE"].ToString();
                LblHdr1.Text = Request.QueryString["TITLE"].ToString() + " List";
                //===================================================================================================================
                TxtFineTotal.Attributes.Add("onkeydown", "return IsDecimal(event,'" + TxtFineTotal.ClientID + "');");
                TxtPayableAmt.Attributes.Add("onkeydown", "return IsDecimal(event,'" + TxtPayableAmt.ClientID + "');");
                TxtConcnAmt.Attributes.Add("onkeydown", "return IsDecimal(event,'" + TxtConcnAmt.ClientID + "');");

                if (ObjCls.FnIsNumeric(Request.QueryString["CNTRID"].ToString()) > 0)
                {
                    CtrlRewindEvent1.IsEnableFirstButton = false;
                    CtrlRewindEvent1.IsEnableLastButton = false;
                    CtrlRewindEvent1.IsEnableNextButton = false;
                    CtrlRewindEvent1.IsEnablePreviousButton = false;
                    CtrlRewindEvent1.IsEnableGetButton = false;
                    CtrlCommand1.IsVisibleClear = false;
                    ViewState["ID"] = Request.QueryString["CNTRID"].ToString();
                    FnAssignProperty();
                    FnFindRecord(ObjCls);
                    FnFindRecord();
                }
                else
                {
                    CtrlRewindEvent1.IsEnableFirstButton = true;
                    CtrlRewindEvent1.IsEnableLastButton = true;
                    CtrlRewindEvent1.IsEnableNextButton = true;
                    CtrlRewindEvent1.IsEnablePreviousButton = true;
                    CtrlRewindEvent1.IsEnableGetButton = true;
                    FnInitializeForm();

                }
            }
            CtrlGrdAcc.DestinationControls = TxtAdmNo.TextControl + "," + TxtRegNo.TextControl + "," + TxtClass.IdControl + "," + TxtClass.TextControl + "," + TxtDivision.IdControl + "," + TxtDivision.TextControl + "," + TxtInstitueGrp.IdControl + "," + TxtInstitueGrp.TextControl;
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
        ObjCls = new ClsFeeCollection(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);

        ObjCls.TType = FnGetRights().TTYPE;
        CtrlRewindEvent1.TxtRefNo = ObjCls.FnGetRefNo().ToString();
        CtrlRewindEvent1.TokenNo = ObjCls.FnGetTokenId().ToString();
        CtrlTokenEvent1.TokenNo = CtrlRewindEvent1.TokenNo;

        ViewState["DT"] = FnGetTransMasterTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetTransFeeChildTable(ObjCls);

        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.TokenNo = ObjChld.FnIsDouble(CtrlRewindEvent1.TokenNo);
        ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
        ObjCls.TrDate = ObjCls.FnDateTime(CtrlTrDate.DateText);
        ObjCls.EndDate = ObjCls.FnDateTime(CtrlInstDate.DateText);
        ObjCls.ChqNo = TxtChqNo.Text.Trim();
        ObjCls.ChqDate = ObjCls.FnDateTime(CtrlChqDate.DateText);

        ObjCls.StudentId = ObjCls.FnIsNumeric(CtrlGrdAcc.SelectedValue.ToString());
        ObjCls.CrId = ObjCls.FnIsNumeric(CtrlGrdAcc.SelectedValue.ToString());
        ObjCls.FeeTypeId = ObjCls.FnIsNumeric(DdlFeeType.SelectedValue.ToString());
        ObjCls.DrId = ObjCls.FnIsNumeric(DdlAcc.SelectedValue.ToString());

        ObjCls.ConcenAmt = ObjCls.FnIsDouble(TxtConcnAmt.Text);
        ObjCls.PayableAmt = ObjCls.FnIsDouble(TxtPayableAmt.Text);
        ObjCls.FineAmt = ObjCls.FnIsDouble(TxtFineTotal.Text);
        ObjCls.GrandTotal = ObjCls.FnIsDouble(TxtNetPayable.Text);
        ObjCls.NetTotal = ObjCls.FnIsDouble(TxtNetPayable.Text);

        
        ObjCls.Description = TxtPayableAt.Text.Trim();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
    }
    public void FnAssignChildProperty()
    {
        base.FnAssignChildProperty(ObjChld);
        ObjChld.TokenNo = ObjChld.FnIsDouble(CtrlRewindEvent1.TokenNo);
        ObjChld.InvoiceId= ObjCls.FnIsNumeric(ViewState["ID"].ToString());
        ObjCls.OptDate = ObjCls.FnDateTime(CtrlInstDate.DateText);

        ObjChld.StudentId = ObjCls.FnIsNumeric(CtrlGrdAcc.SelectedValue.ToString());
        ObjChld.InstituteGrpId = ObjCls.FnIsNumeric(TxtInstitueGrp.SelectedValue.ToString());
        ObjChld.ClassId = ObjCls.FnIsNumeric(TxtClass.SelectedValue.ToString());
        ObjChld.DivisionId = ObjCls.FnIsNumeric(TxtDivision.SelectedValue.ToString());
        ObjChld.FeeTypeId = ObjCls.FnIsNumeric(DdlFeeType.SelectedValue.ToString());
    }
    public void FnAssignProperty_Search()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.RefNo = ObjCls.FnIsNumeric(TxtFrmRefNo.Text);
        ObjCls.ID = ObjCls.FnIsNumeric(TxtToRefNo.Text);
        ObjCls.TrDate = ObjCls.FnDateTime(CtrlFrmDate.DateText);
        ObjCls.DueDate = ObjCls.FnDateTime(CtrlToDate.DateText);
        //ObjCls.AccountId = ObjCls.FnIsNumeric(CtrlGrdAcc_Srch.SelectedValue.ToString());
        ObjCls.Remarks = TxtOptNo_Srch.Text.Trim();
     }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        TxtToRefNo.Text = "";
        TxtFrmRefNo.Text = "";
        CtrlGrdAcc.SelectedText = "";
        CtrlGrdAcc.SelectedValue = "0";
        CtrlGrdAcc_Srch.SelectedText = "";
        CtrlGrdAcc_Srch.SelectedValue = "0";
        TxtOptNo_Srch.Text = "";
        CtrlFrmDate.FnNewDate();
        CtrlToDate.FnNewDate();
        //=====================================================
        TxtChqNo.Text = "";
        CtrlChqDate.DateText = "";
        CtrlGrdAcc.SelectedValue = "0";
        CtrlGrdAcc.SelectedText = "";
        DdlAcc.SelectedIndex = 0;
        DdlFeeType.SelectedIndex = 0;
        TxtConcnAmt.Text = "";
        TxtPayableAmt.Text = "";
        TxtFineTotal.Text = "";
        TxtNetPayable.Text = "";
        TxtPayableAt.Text = "";
        TxtRemarks.Text = "";
        FnInitializeForm();

        TxtAdmNo.SelectedText = "";
        TxtRegNo.SelectedText = "";
        TxtClass.SelectedText = "";
        TxtDivision.SelectedText = "";
        TxtInstitueGrp.SelectedText = "";
        TxtAmount.Text = "";

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnFindRecord()
    {
        if (ObjCls.FnIsNumeric(ViewState["ID"].ToString()) > 0)
        {
            ObjCls.GetDataRow(ViewState["ID"].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            CtrlRewindEvent1.TxtRefNo = ObjCls.RefNo.ToString();
            CtrlTrDate.DateText = ObjCls.FnDateTime(ObjCls.TrDate, "");
            CtrlRewindEvent1.TokenNo = ObjCls.TokenNo.ToString();
            CtrlTokenEvent1.TokenNo = CtrlRewindEvent1.TokenNo;

            CtrlGrdAcc.SelectedText = ObjCls.StudentName;
            CtrlGrdAcc.SelectedValue = ObjCls.StudentId.ToString();

            //CtrlGrdHeadAcc.SelectedText = ObjCls.AccountDr;
            DdlAcc.Text = ObjCls.DrId.ToString();
            DdlFeeType.SelectedValue = ObjCls.FeeTypeId.ToString();
           
            TxtChqNo.Text = ObjCls.ChqNo;
            CtrlChqDate.DateText = ObjCls.FnDateTime(ObjCls.ChqDate, "");
            CtrlInstDate.DateText = ObjCls.FnDateTime(ObjCls.EndDate, "");

            TxtConcnAmt.Text = ObjCls.ConcenAmt.ToString();
            TxtPayableAmt.Text = ObjCls.PayableAmt.ToString();
            TxtFineTotal.Text = ObjCls.FineAmt.ToString();
            TxtNetPayable.Text = FnSetFormatedValue(ObjCls.FnIsDouble(ObjCls.GrandTotal.ToString()));

            TxtPayableAt.Text = ObjCls.Description;
            TxtRemarks.Text = ObjCls.Remarks;


            FnGridViewBinding("");

            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();
            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";
            TabContainer1.ActiveTabIndex = 0;
        }
    }
    private void FnGetTotal()
    {
        double dNetTotal = 0, dAmount = 0, dFineAmount = 0, dConcAmount = 0;
        DT_RECORD = ViewState["DT_CHILD"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            if (ObjCls.FnIsNumeric(DT_RECORD.Rows[0]["StudentId"].ToString()) > 0)
            {
                dNetTotal = ObjCls.FnIsDouble(DT_RECORD.Compute("SUM(TotalAmt)", ""));
                dAmount = ObjCls.FnIsDouble(DT_RECORD.Compute("SUM(TotalAmt)", ""));
            }
        }

        TextBox PayableAmt = (TextBox)GrdVwChild.Rows[0].FindControl("TxtPayable");
        double PayableAMTT=0;
        
        for (int iRw = 0; iRw <= GrdVwChild.Rows.Count - 1; iRw++)
        {
            PayableAmt =  (TextBox)GrdVwChild.Rows[iRw].FindControl("TxtPayable");
            PayableAMTT = PayableAMTT + ObjCls.FnIsDouble(PayableAmt.Text);
         
        }

        double number1 = 10.5;
        double number2 = 20.3;

        // Adding two double values
        double sum = number1 + number2;
               
        dFineAmount = ObjCls.FnIsDouble(TxtFineTotal.Text);
        TxtNetPayable.Text = dFineAmount + FnSetFormatedValue(PayableAMTT);
        double number3= dFineAmount + ObjCls.FnIsDouble(FnSetFormatedValue(PayableAMTT));
        TxtAmount.Text = number3.ToString();

        dConcAmount = ObjCls.FnIsDouble(TxtConcnAmt.Text);
        TxtPayableAmt.Text= number3.ToString();
        TxtNetPayable.Text = (number3- dConcAmount).ToString();
        
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        if (PrmFlag.Equals("SEARCH"))
        {
            GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
            LblGrdInfo.Visible = (GrdVwRecords.Rows.Count <= 0 ? true : false);
            
        }
        else
        {
            GrdVwChild.DataSource = ViewState["DT_CHILD"] as DataTable;
            GrdVwChild.DataKeyNames = new String[] { ObjChld.KeyName };
            GrdVwChild.DataBind();
            GrdVwChild.SelectedIndex = -1;
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
                    if (ObjCls.FnIsNumeric(CtrlGrdAcc.SelectedValue.ToString()) <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the valid " + LblCash.Text));
                        FnFocus(CtrlGrdAcc.ControlTextBox);
                        return;
                    }
                    HiddenField HdnAutoId = (HiddenField)GrdVwChild.Rows[0].FindControl("HdnAutoId");
                    if (ObjCls.FnIsNumeric(HdnAutoId.Value) <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please add atleast one item."));
                        //FnFocus(CtrlGrdParty.ControlTextBox);
                        return;
                    }
                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, CtrlCommand1.IsPrint);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, CtrlCommand1.IsPrint);
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
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnGridViewBinding("");
                    break;
                case "SEARCH":
                    FnAssignProperty_Search();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnGridViewBinding("SEARCH");
                    TabContainer1.ActiveTabIndex = 1;
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
                case "FIRST":
                    ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnFindRecord();
                    break;
                case "PREVIOUS":
                    ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnFindRecord();
                    break;
                case "NEXT":
                    ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnFindRecord();
                    break;
                case "LAST":
                    ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnFindRecord();
                    break;
                case "GET":
                    ObjCls.RefNo = ObjCls.FnIsNumeric(CtrlRewindEvent1.TxtRefNo);
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnFindRecord();
                    break;
                case "SHOW":
                    FnAssignChildProperty();
                    ViewState["DT_CHILD"] = ObjChld.ManipulateData("S") as DataTable;
                    FnGridViewBinding("");
                    FnGetTotal();
                    break;
                case "DELETE_ALL":// Delete all list
                    string str = "";
                    CheckBox ChkGrd = null;
                    int iCnt = 0;
                    if (FnGetRights().DELETE == true)
                    {
                        base.FnAssignProperty(ObjCls);
                        for (int iRw = 0; iRw <= GrdVwRecords.Rows.Count - 1; iRw++)
                        {
                            ChkGrd = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkGrd");
                            if (ChkGrd.Checked == true)
                            {
                                HdnAutoId = (HiddenField)GrdVwRecords.Rows[iRw].FindControl("HdnAutoId0");
                                if (ObjCls.FnIsNumeric(HdnAutoId.Value) > 0)
                                {
                                    ObjCls.ID = ObjCls.FnIsNumeric(HdnAutoId.Value);
                                    str = ObjCls.DeleteRecord() as string;
                                    iCnt = iCnt + 1;
                                }
                            }
                        }
                        if (iCnt > 0)
                        {
                            FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Record deleted Successfully."));
                        }
                    }
                    else
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage(" You Have No permission To Delete Record"));
                    }
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
            ViewState["ID"] = GrdVwRecords.SelectedDataKey.Values[0].ToString();
            base.FnAssignProperty(ObjCls);
            FnFindRecord(ObjCls);
            FnFindRecord();
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
            FnGridViewBinding("SEARCH");
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
                
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public string FnGetDateFormat(object PrmDate)
    {
        DateTime dt = ObjCls.FnDateTime(PrmDate);
        return (dt.ToString("dd/MMM/yyyy").Equals("01/Jan/1800") ? "" : dt.ToString("dd/MMM/yyyy")).ToString();
    }

    protected void TxtFineTotal_Textchanged(object sender, EventArgs e)
    {
        FnGetTotal();
    }
    protected void TxtConcnAmt_Textchanged(object sender, EventArgs e)
    {
        FnGetTotal();
    }
    protected void GrdVwChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox TotalFee = (TextBox)e.Row.FindControl("TxtTotalFee");
                TextBox TxtConcession = (TextBox)e.Row.FindControl("TxtConcession");
                TextBox TxtExcess = (TextBox)e.Row.FindControl("TxtExcess");
                TextBox Payable = (TextBox)e.Row.FindControl("TxtPayable");
                                
                Payable.Attributes.Add("onchange", " return FeeCollectionCal('" + TotalFee.ClientID + "','" + TxtConcession.ClientID + "','" + TxtExcess.ClientID + "','" + Payable.ClientID + "','" + TxtPayableAmt.ClientID + "','" + GrdVwChild.ClientID + "');");

                ViewState["DT_CHILD"] = GrdVwChild.DataSource;
                 FnGetTotal();

                TxtFeeTotAmt = (TextBox)e.Row.FindControl("TxtAmount");
                FnSetFeeMasterValue( TxtFeeTotAmt);
            }

            //TxtMark = (TextBox)e.Row.FindControl("TxtMark");
           
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
              


    }

    public void FnSetFeeMasterValue( TextBox PrmTxtAmount)
    {
        if ((ViewState["DT"] as DataTable).Rows.Count > 0)
        {
            _dwMainRecord = new DataView(ViewState["DT"] as DataTable);
            DT_RECORD = _dwMainRecord.ToTable();
            if (DT_RECORD.Rows.Count > 0)
            {
                TxtAmount.Text = FnGetDoubleString((ViewState["DT"] as DataTable).Compute("SUM(TxtPayable)", "").ToString());
               
            }
            else
            {
                TxtAmount.Text = "";
            }
        }
        else
        {
            TxtAmount.Text = "";
        }
    }
}