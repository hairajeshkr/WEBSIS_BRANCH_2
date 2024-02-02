using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

public partial class STUDENT_MarkAsgnStudent : ClsPageEvents, IPageInterFace
{
    string connString = "Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True";
    ClsNEPMarkAssignStudent ObjCls = new ClsNEPMarkAssignStudent();
    TextBox TxtMark;
    HiddenField HdnId, HdnRwIndex,HdnClassId,HdnDivId, HdnStudentId;
    DropDownList DdlStudStatus;
    Label LblMaxMark;
    DataTable DT = new DataTable();
    DataTable DTGrade = new DataTable();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();

                DataTable DTTeacher = (ObjCls.FnGetDataSet("select nId Id,cName Name from tblregistration where cttype='emp'") as DataSet).Tables[0];
                DdlTeacher.DataSource = DTTeacher;
                DdlTeacher.DataValueField = "Id";
                DdlTeacher.DataTextField = "Name"; 
                DdlTeacher.DataBind();
                DdlTeacher.Items.Insert(0, new ListItem("--select--", "0"));


            }

            DataTable DtTemp = (ObjCls.FnGetDataSet("select * from TblNEPStudentMarkEntryTemp") as DataSet).Tables[0];
            DataTable DtOrg = (ObjCls.FnGetDataSet("select * from TblNEPStudentMarkEntry") as DataSet).Tables[0];


        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
        //DataTable DTTeachers = (ObjCls.FnGetDataSet("select * from tblregistration where cttype='emp'") as DataSet).Tables[0];

    }

    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsNEPMarkAssignStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["TOKENNO"] = ObjCls.FnGetTokenId().ToString();
        ViewState["INDX"] = "0";
        FnGridViewBinding("");


    }
    public void FnAssignProperty()
    {

        base.FnAssignProperty(ObjCls);

        ObjCls.TokenNo = ObjCls.FnIsDouble(ViewState["TOKENNO"].ToString());
        ObjCls.StaffId = ObjCls.FnIsNumeric(DdlTeacher.SelectedValue);
        ObjCls.StudGroupId = ObjCls.FnIsNumeric(DdlGroup.SelectedValue);
        ObjCls.PaperId = ObjCls.FnIsNumeric(DdlPaper.SelectedValue);
        ObjCls.ExamId = ObjCls.FnIsNumeric(DdlExam.SelectedValue);
        ObjCls.ExamSubId = ObjCls.FnIsNumeric(DdlSubExam.SelectedValue);
        ObjCls.ExamDate = ObjCls.FnDateTime(CtrlExamDate.DateText);
        ObjCls.MarkUploaded = (ChkMarkUpdated.Checked == true ? true : false);


    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        DdlTeacher.SelectedValue = "0";
        DdlGroup.SelectedValue = "0";
        DdlPaper.SelectedValue = "0";
        DdlExam.SelectedValue = "0";
        DdlSubExam.SelectedValue = "0";
        TabContainer1.ActiveTabIndex = 0;
        //FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        //FnAssignProperty();
        //FnFindRecord(ObjCls);
        //FnGridViewBinding("");
        ////FnFindGrid();
        //TabContainer1.ActiveTabIndex = 1;

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
                

                ViewState["TOKENNO"] = (ViewState["DT"] as DataTable).Rows[0]["TokenNo"].ToString();
            }
        }

        FnGridViewBinding("");

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
                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);

                            FnCancel();
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
                    DataTable DtOrg = (ObjCls.FnGetDataSet("select * from VwStudentMarkEntryTemp") as DataSet).Tables[0];
                    DataTable DT = ViewState["DT"] as DataTable;
                    int Rwcount = DT.Rows.Count;
                    for (int i = 0; i < Rwcount; i++)
                    {
                        TxtMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMark");

                        TxtMark.Text = DT.Rows[i]["ObtainedMark"].ToString();
                        
                    }





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

  



    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox TxtMarks;
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                    TxtMark = (TextBox)e.Row.FindControl("TxtMark");
                    FnAutocompleteOff(TxtMark);

                    HdnRwIndex = (HiddenField)e.Row.FindControl("HdnRwIndex");
                    HdnClassId = (HiddenField)e.Row.FindControl("HdnClassId");
                    HdnDivId = (HiddenField)e.Row.FindControl("HdnDivId");
                    HdnStudentId = (HiddenField)e.Row.FindControl("HdnStudentId");
                    LblMaxMark = (Label)e.Row.FindControl("LblMaxMark");
                    DdlStudStatus=(DropDownList)e.Row.FindControl("DdlStatus");


                TxtMark.Attributes.Add("onkeyup", "return FnUpdateStudMark('" + ViewState["TOKENNO"].ToString() + "','" + ViewState["ID"].ToString() + "','" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().FAYEARID + "','" + FnGetRights().TTYPE + "','" + FnGetRights().USERID + "','" + DdlTeacher.ClientID + "','" + DdlGroup.ClientID + "','" + DdlPaper.ClientID + "','" + DdlExam.ClientID + "','" + DdlSubExam.ClientID + "','" + TxtMark.ClientID + "', '" + HdnClassId.ClientID + "','" + HdnDivId.ClientID + "','" + HdnStudentId.ClientID + "','" + LblMaxMark.Text + "','" + CtrlExamDate.ClientID + "','"+ DdlStudStatus.ClientID + "');");

                //DT_RECORD = ViewState["DT"] as DataTable;
                //int j = DT_RECORD.Rows.Count;
                
                //if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                //{
                //    if (j > 0)
                //    {
                //       for (int i = 0; i < j; i++)
                //       {
                //        TxtMarks = (TextBox)e.Row.FindControl("TxtMark");
                //        TxtMarks.Text = DT_RECORD.Rows[i]["ObtainedMark"].ToString();
                //       }

                //    }
                //    //ViewState["TOKENNO"] = (ViewState["DT"] as DataTable).Rows[0]["TokenNo"].ToString();
                //}

            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void DdlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        int StaffId = ObjCls.FnIsNumeric(DdlTeacher.SelectedValue);
        DataTable DTPaper = (ObjCls.FnGetDataSet("select TNP.nId Id,TNP.cNEPPaperName Name from TblNEPPapers TNP inner join TblNEPTeacherPaper TNTP on TNTP.nNEPPaperId=TNP.nId where TNTP.nNEPTeacherId=" + StaffId) as DataSet).Tables[0];
        DdlPaper.DataSource = DTPaper;
        DdlPaper.DataValueField = "Id";
        DdlPaper.DataTextField = "Name";
        DdlPaper.DataBind();
        DdlPaper.Items.Insert(0, new ListItem("--select--", "0"));
    }

    protected void DdlPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PaperId = ObjCls.FnIsNumeric(DdlPaper.SelectedValue);
        DataTable DTgroup = (ObjCls.FnGetDataSet("select TNSG.nId Id,TNSG.nNEPStudentGroupName Name from TblNEPTeacherPaper TNTP inner join TblNEPTeacherStudentAllocation TNSA on TNSA.nNEPTeacherPaperId=TNTP.nId inner join TblNEPStudentGroup TNSG on TNSA.nNEPStudentGroupId = TNSG.nId where TNTP.nNEPPaperId =" + PaperId) as DataSet).Tables[0];
        DdlGroup.DataSource = DTgroup;
        DdlGroup.DataValueField = "Id";
        DdlGroup.DataTextField = "Name";
        DdlGroup.DataBind();
        DdlGroup.Items.Insert(0, new ListItem("--select--", "0"));

        
        DdlExam.Items.Add(new ListItem("Select", "0"));
        DataTable DTExams = (ObjCls.FnGetDataSet("select RPTC.nId Id,RPTC.cNEPRptColumnName Name from TblNEPReportColumns RPTC inner Join TblNEPPapers PAPR on PAPR.nNEPPaperGroupID = RPTC.nNEPPaperGroupID where PAPR.nId ="+ PaperId) as DataSet).Tables[0];
        DdlExam.DataSource = DTExams;
        DdlExam.DataValueField = "Id";
        DdlExam.DataTextField = "Name";
        DdlExam.DataBind();
        DdlExam.Items.Insert(0, new ListItem("--select--", "0"));


    }
    protected void DdlExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SubExamId = ObjCls.FnIsNumeric(DdlExam.SelectedValue);
        DataTable DTExamTmp = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplateDetails") as DataSet).Tables[0];

        DataTable DTExam = (ObjCls.FnGetDataSet("select TETP.nId Id,TETP.cSubExamName Name from TblNEPExamTemplateDetails TETP where nNEPRptColumnID=" + SubExamId) as DataSet).Tables[0];
        DdlSubExam.DataSource = DTExam;
        DdlSubExam.DataValueField = "Id";
        DdlSubExam.DataTextField = "Name";
        DdlSubExam.DataBind();
        DdlSubExam.Items.Insert(0, new ListItem("--select--", "0"));
    }
}