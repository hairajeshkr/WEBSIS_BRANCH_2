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
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                              
                ObjLst.FnGetStaffList(DdlTeacher, "");
            }

            DataTable DtTemp = (ObjCls.FnGetDataSet("select * from TblNEPStudentMarkEntryTemp") as DataSet).Tables[0];
            //DataTable dtt = (ObjCls.FnGetDataSet("delete from  TblNEPStudentMarkEntryTemp") as DataSet).Tables[0];

            //DataTable ggg = (ObjCls.FnGetDataSet("ALTER VIEW [dbo].[VwStudentMarkEntryTemp] AS SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SlNo,TBL.nId AS Id,TBL.nTokenId AS TokenNo,TBL.nStaffId AS StaffId, TRS.cName AS StaffName,TSTGRP.nNEPStudentGroupName AS StudentGroupName,TSTGRP.nId AS StudentGroupId,TNEP.cNEPPaperName AS PaperName,TNEP.nId AS PaperId,TAS.cNEPRptColumnName AS ExamName,TBL.nExamId AS ExamId,TES.cSubExamName AS ExamSubName, TBL.nExamSubId AS ExamSubId,TSAD.nStudentId AS StudentId,TRSS.cName AS StudentName,TSAD.nRollNo AS RollNo,TRSS.cAdmissionNo AdmissionNo, TCD.cName As ClassName, TSAD.nClassId AS ClassId,TDCD.cName AS DivisionName,TSAD.nDivisionId AS DivisionId,TBL.nStudentStatusId AS StudentStatusId,TBL.nMark AS ObtainedMark,TBL.nMaxMark AS Maxmark,TBL.cRemarks AS Remarks,TBL.nActive AS Active,TBL.nIsDelete AS IsDelete,TBL.nIsExport AS IsExport,TBL.cTType AS TType,TSAD.nCompanyId AS CompanyId,TSAD.nBranchId AS BranchId,TSAD.nFaId AS FaId,TSAD.nAcId AS AcId,TBL.nModifiedUserId AS UserId,TBL.dModifiedDate AS UpdateDate FROM TblStudentAdmissionDetails  TSAD INNER JOIN TblRegistrationStudent TRSS ON TRSS.nId=TSAD.nStudentId INNER JOIN TblNEPStudentMarkEntryTemp TBL ON TRSS.nId=TBL.nStudentId INNER JOIN TblRegistration TRS ON TRS.nId=TBL.nStaffId INNER JOIN TblNEPPapers TNEP ON TNEP.nId=TBL.nPaperId INNER JOIN TblClassDetails TCD ON TCD.nId=TBL.nClassId and TCD.cTType='CLS' INNER JOIN TblClassDetails TDCD ON TDCD.nId=TBL.nDivisionId and TDCD.cTType='DIVN' INNER JOIN TblNEPReportColumns TAS ON TAS.nId=TBL.nExamId and TAS.nNEPPaperGroupID=TNEP.nNEPPaperGroupID INNER JOIN TblNEPSubExam TES ON TES.nNEPReportColumnId=TAS.nId AND TES.nId=TBL.nExamSubId INNER JOIN TblNEPStudentGroup TSTGRP  ON TSTGRP.nId=TBL.nStudentGroupId WHERE TBL.nIsDelete=0") as DataSet).Tables[0];
            DataTable DtOrg = (ObjCls.FnGetDataSet("select * from TblNEPStudentMarkEntry") as DataSet).Tables[0];


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
        ObjCls = new ClsNEPMarkAssignStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["TOKENNO"] = ObjCls.FnGetTokenId().ToString();
        ViewState["INDX"] = "0";
        FnGridViewBinding("");
        ViewState["STAFF"] = FnGetGeneralTable(ObjCls);

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
                        DdlStudStatus = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlStatus");

                        TxtMark.Text = DT.Rows[i]["ObtainedMark"].ToString();
                        DdlStudStatus.SelectedValue = DT.Rows[i]["StudentStatusId"].ToString();

                        if (DdlStudStatus.SelectedValue == "1")
                        {
                            TxtMark.Enabled = true;
                        }

                        //if (DdlStudStatus.SelectedValue == "2" || DdlStudStatus.SelectedValue == "3")
                        else
                        {
                            //TxtMark.Text = ddlstatus.SelectedItem.Text;
                            TxtMark.Enabled = false;

                        }


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


                
                TxtMark.Attributes.Add("onchange", "return FnUpdateStudMark('" + ViewState["TOKENNO"].ToString() + "','" + ViewState["ID"].ToString() + "','" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().FAYEARID + "','" + FnGetRights().TTYPE + "','" + FnGetRights().USERID + "','" + DdlTeacher.ClientID + "','" + DdlGroup.ClientID + "','" + DdlPaper.ClientID + "','" + DdlExam.ClientID + "','" + DdlSubExam.ClientID + "','" + TxtMark.ClientID + "', '" + HdnClassId.ClientID + "','" + HdnDivId.ClientID + "','" + HdnStudentId.ClientID + "','" + LblMaxMark.Text + "','" + CtrlExamDate.ClientID + "','" + DdlStudStatus.ClientID + "');");
               DdlStudStatus.Attributes.Add("onchange", "return FnUpdateStudMark('" + ViewState["TOKENNO"].ToString() + "','" + ViewState["ID"].ToString() + "','" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().FAYEARID + "','" + FnGetRights().TTYPE + "','" + FnGetRights().USERID + "','" + DdlTeacher.ClientID + "','" + DdlGroup.ClientID + "','" + DdlPaper.ClientID + "','" + DdlExam.ClientID + "','" + DdlSubExam.ClientID + "','" + TxtMark.ClientID + "', '" + HdnClassId.ClientID + "','" + HdnDivId.ClientID + "','" + HdnStudentId.ClientID + "','" + LblMaxMark.Text + "','" + CtrlExamDate.ClientID + "','" + DdlStudStatus.ClientID + "');");
               //DdlStudStatus.Attributes.Add("onkeyup", "if ('" + DdlStudStatus.ClientID + "'.value=='2'){'" + TxtMark.ClientID + "'.disabled=true;}else{'" + TxtMark.ClientID + "'.disabled=false;} ");
                //DdlStudStatus.Attributes.Add("onchange", "return ChangeText('" + DdlStudStatus.ClientID + "','" + TxtMark.ClientID + "');");





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
        DataTable DT = (ObjCls.FnGetDataSet("select * from TblNEPReportColumns ") as DataSet).Tables[0];
        DataTable DTT = (ObjCls.FnGetDataSet("select * FROM TblNEPPapers") as DataSet).Tables[0];
        DataTable dtt = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplate") as DataSet).Tables[0];
        DataTable DTS = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplateDetails") as DataSet).Tables[0];


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
        int PaperId = ObjCls.FnIsNumeric(DdlPaper.SelectedValue);
        
        DataTable DTExam = (ObjCls.FnGetDataSet("select TETP.nId Id, TETP.cSubExamName Name from tblnepsubexam TETP inner join tblnepsyllabuspapers TNSP on TNSP.nid=TETP.nnepsyllabuspaperid inner join tblnepteacherpaper TNTP on TNTP.nNEPPaperId = TNSP.nNEPPaperId where TETP.nNEPReportColumnId = " + SubExamId + "and TNTP.nNEPPaperId = " + PaperId) as DataSet).Tables[0];


        DdlSubExam.DataSource = DTExam;
        DdlSubExam.DataValueField = "Id";
        DdlSubExam.DataTextField = "Name";
        DdlSubExam.DataBind();
        DdlSubExam.Items.Insert(0, new ListItem("--select--", "0"));
    }



    protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}