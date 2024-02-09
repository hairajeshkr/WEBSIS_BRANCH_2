using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
public partial class NEP_SyllabusVsPapers : ClsPageEvents, IPageInterFace
{
    ClsNEPSyllabusPaper ObjCls = new ClsNEPSyllabusPaper();
    Label LblPaper = null, LblCreditHrs = null, LblPaperName=null, LblSubExam=null, LblPrintName=null, LblOrder=null, LblReport=null;
    HiddenField HdnId = null, HdnReportCId=null,HdnSyllbId=null, HdnReportCIdV = null;
    CheckBox ChkSelect = null;
    TextBox TxtMaxMark = null, TxtPercentage = null, TxtOrder=null, TxtPercentageV = null;
    int iCnt = 0,PaperId, GPaperId;
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
                ObjCls.SUBFlag = "D";
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
        ObjCls.PFlag = "S3";
        ObjCls.SUBFlag = "P";
        FnFindRecord_P();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
         ObjCls.NEPSubjectId = ObjCls.FnIsNumeric(ViewState["SUBJ_ID"].ToString());
        ObjCls.SyllabusId = ObjCls.FnIsNumeric(Sylb);
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
    public void FnFindRecord_P()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("S3");
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
        else if (PrmFlag == "S2")
        {
        GrdVwPaper.DataSource = ViewState["DT"] as DataTable;
            ViewState["DT1"] = ViewState["DT"] as DataTable;
            GrdVwPaper.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwPaper.DataBind();
        GrdVwPaper.SelectedIndex = -1;
        }
        else if (PrmFlag == "S3")
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
                                ObjCls.SUBFlag = "F";
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
                                    PaperId= ObjCls.FnIsNumeric(HdnId.Value);
                                    ObjCls.SyllabusId = ObjCls.FnIsNumeric(Sylb);
                                    _strMsg = ObjCls.SaveRecord() as string;
                               }
                                
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }


                            int TPerc, TReportId, TPercV, TReportIdV,PercSum=0;

                            for (int i = 0; i <= GrdVwPaper.Rows.Count - 1; i++)
                            {
                                HdnReportCId = (HiddenField)GrdVwPaper.Rows[i].FindControl("HdnReportCId");
                                TxtPercentage = (TextBox)GrdVwPaper.Rows[i].FindControl("TxtPercentage");
                                 TPerc= ObjCls.FnIsNumeric(TxtPercentage.Text);
                                 TReportId = ObjCls.FnIsNumeric(HdnReportCId.Value);
                                PercSum = 0;
                                for (int j = 0; j <= GrdVwPaper.Rows.Count - 1; j++)
                                {
                                    HdnReportCIdV = (HiddenField)GrdVwPaper.Rows[j].FindControl("HdnReportCId");
                                    TxtPercentageV = (TextBox)GrdVwPaper.Rows[j].FindControl("TxtPercentage");
                                     TPercV = ObjCls.FnIsNumeric(TxtPercentageV.Text);
                                     TReportIdV = ObjCls.FnIsNumeric(HdnReportCIdV.Value);
                                    if(TReportId== TReportIdV)
                                    {
                                        PercSum = PercSum + TPercV;
                                        if(PercSum != 100)
                                        {
                                            FnPopUpAlert(ObjCls.FnAlertMessage("Sum of Percentage should be 100 "));
                                            break;
                                        }

                                    }

                                }


                            }


                                for (int i = 0; i <= GrdVwPaper.Rows.Count - 1; i++)
                            {
                                
                                    Label LblPaper = null;
                                    TextBox TxtCreditHrs = null;
                                    HiddenField HdnId = null;
                                ObjCls.SUBFlag = "S";

                                LblPaperName = (Label)GrdVwPaper.Rows[i].FindControl("LblPaperName");

                                LblSubExam = (Label)GrdVwPaper.Rows[i].FindControl("LblSubExam");
                                LblPrintName = (Label)GrdVwPaper.Rows[i].FindControl("LblPrintName");
                                LblReport = (Label)GrdVwPaper.Rows[i].FindControl("LblReport");
                                HdnReportCId = (HiddenField)GrdVwPaper.Rows[i].FindControl("HdnReportCId");
                                TxtMaxMark = (TextBox)GrdVwPaper.Rows[i].FindControl("TxtMaxMark");
                                TxtPercentage = (TextBox)GrdVwPaper.Rows[i].FindControl("TxtPercentage");
                                TxtOrder = (TextBox)GrdVwPaper.Rows[i].FindControl("TxtOrder");

                                
                                ObjCls.NEPPaperId = PaperId;
                                ObjCls.ReportCId= ObjCls.FnIsNumeric(HdnReportCId.Value);
                                ObjCls.LblSubExam =LblSubExam.Text;
                                ObjCls.LblPrintName = LblPrintName.Text;
                                ObjCls.TxtMaxMark = ObjCls.FnIsNumeric(TxtMaxMark.Text);
                                ObjCls.TxtPercentage = ObjCls.FnIsNumeric(TxtPercentage.Text);
                                ObjCls.TxtOrder = ObjCls.FnIsNumeric(TxtOrder.Text);
                                ObjCls.SyllabusId = ObjCls.FnIsNumeric(Sylb);

                                _strMsg = ObjCls.SaveRecord() as string;
                                

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

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["DT1"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["DT1"] = dt;
        GrdVwPaper.DataSource = ViewState["DT1"] as DataTable;
        GrdVwPaper.DataBind();
    }

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        
        for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
        {
            ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
            if (ChkSelect.Checked == true)
            {
                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                LblPaper = (Label)GrdVwRecords.Rows[i].FindControl("LblPaper");
                Session["ParamPaperId"] = ObjCls.FnIsNumeric(HdnId.Value);
                GPaperId= ObjCls.FnIsNumeric(HdnId.Value);
                ObjCls.NEPPaperId= ObjCls.FnIsNumeric(HdnId.Value);
                ObjCls.GPaperName = LblPaper.Text;
                ObjCls.SyllabusId = ObjCls.FnIsNumeric(Sylb);
            }
        }
        CtrlGrdTemplate.SelectedValue = ExamT;
        ObjCls.PFlag = "S2";
        
        FnFindRecord_S();
        
    }

   
}