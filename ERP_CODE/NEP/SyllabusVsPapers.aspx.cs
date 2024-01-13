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
    ClsNEPSyllabusPaper ObjCls = new ClsNEPSyllabusPaper();
    Label LblPaper = null, LblCreditHrs = null;
    HiddenField HdnId = null;
    CheckBox ChkSelect = null;
    int iCnt = 0;
    string Sylb, ExamT;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            Sylb = Session["param1"] as string;
            ExamT = Session["param2"] as string;
            if (!IsPostBack)
            {
                ObjCls.PFlag = "S1";
                ViewState["SUBJ_ID"] = Request.QueryString["CNTRID"].ToString();
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
        ObjCls = new ClsNEPSyllabusPaper(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnFindRecord();

    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
         ObjCls.NEPSubjectId = ObjCls.FnIsNumeric(ViewState["SUBJ_ID"].ToString());

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
        FnGridViewBinding("S1");
        CtrlCommand1.IsVisibleSave = true;
    }

    public void FnFindRecord_S()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("S2");
        CtrlCommand1.IsVisibleSave = true;
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        if (PrmFlag == "S1")
        {
            GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
            
        }
        else
        {
        GrdVwPaper.DataSource = ViewState["DT"] as DataTable;
        GrdVwPaper.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwPaper.DataBind();
        GrdVwPaper.SelectedIndex = -1;
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
                            ObjCls.PFlag = "S2";

                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                if (ChkSelect.Checked == true)
                                {
                                    Label LblPaper = null;
                                    TextBox TxtCreditHrs = null;
                                    HiddenField HdnId = null;

                                    HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                    ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                    LblPaper = (Label)GrdVwRecords.Rows[i].FindControl("LblPaper");
                                    TxtCreditHrs = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtCreditHrs");

                                    ObjCls.NEPPaperId = ObjCls.FnIsNumeric(HdnId.Value);
                                    ObjCls.CreditHrs = ObjCls.FnIsNumeric(TxtCreditHrs.Text.Trim());
                                    _strMsg = ObjCls.SaveRecord() as string;
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
       
        ChkSelect = (CheckBox)e.Row.FindControl("ChkSelect");
        {
            CtrlGrdTemplate.SelectedValue = ExamT;
            ObjCls.PFlag = "S2";
            FnFindRecord_S();
        }
    }

    protected void GrdVwRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ChkSelect = (CheckBox)GrdVwRecords.Rows[e.RowIndex].FindControl("ChkSelect");
            if (ChkSelect.Checked == true)
            {
                CtrlGrdTemplate.SelectedValue = ExamT;
                ObjCls.PFlag = "S2";
                FnFindRecord_S();
            }

           
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        
        CtrlGrdTemplate.SelectedValue = ExamT;
        ObjCls.PFlag = "S2";
        
        FnFindRecord_S();
        
    }

   
}