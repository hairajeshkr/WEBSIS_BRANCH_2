using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class NEP_SyllabusVsPapers : ClsPageEvents, IPageInterFace
{
    ClsNEPSyllabus ObjCls = new ClsNEPSyllabus();
    Label LblPaper = null, LblCreditHrs = null;
    HiddenField HdnId = null;
    CheckBox ChkSelect = null;
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
        ObjCls = new ClsNEPSyllabus(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        FnGridViewBinding("SRCH");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.NEPPaperGroupID = ObjCls.FnIsNumeric(CtrlGrdTemplate.SelectedValue.ToString());
    }

    public override void FnCancel()
    {
        base.FnCancel();
        
        CtrlGrdTemplate.SelectedValue = "0";
        CtrlGrdTemplate.SelectedText = "";
       
        GrdVwRecords.DataSource = null;
    }

    public void FnClose()
    {
        throw new NotImplementedException();
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
        
            GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;

        GrdVwPaper.DataSource = ViewState["DT"] as DataTable;
        GrdVwPaper.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwPaper.DataBind();
        GrdVwPaper.SelectedIndex = -1;
        
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
                            ObjCls.PFlag = "S1";

                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                Label LblPaper = null, LblCreditHrs = null;
                                HiddenField HdnId = null;
                                CheckBox ChkSelect = null;

                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                LblPaper = (Label)GrdVwRecords.Rows[i].FindControl("LblPaper");
                                LblCreditHrs = (Label)GrdVwRecords.Rows[i].FindControl("LblCreditHrs");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.Elective = ObjCls.FnIsNumeric(ChkSelect.Checked);
                                ObjCls.NEPPaperName = LblPaper.Text.Trim();
                                ObjCls.NEPCreditHrs = ObjCls.FnIsNumeric(LblCreditHrs.Text.Trim());

                                // ObjCls.PerAmt = ObjCls.FnIsDouble(TxtPerAmt.Text);
                                //ObjCls.Remarks = TxtRemarks.Text.Trim();

                                _strMsg = ObjCls.SaveRecord() as string;

                                if (ObjCls.FnIsDouble(LblPaper.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }
                            FnCancel();
                            break;
                    }
                    break;
                case "FIND":
                    ObjCls.PFlag = "S1";
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

    
}