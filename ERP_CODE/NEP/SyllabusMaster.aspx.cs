using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NEP_SyllabusMaster :  ClsPageEvents, IPageInterFace
{
    ClsNEPSyllabus ObjCls = new ClsNEPSyllabus();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    TextBox TxtSubject = null, TxtPriority = null;
    HiddenField HdnStudentId = null, HdnId = null;
    CheckBox ChkElective = null, ChkOptional=null;
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
                FnGridViewBinding("");
                FnGridViewBinding("S1");
                SetInitialRow();
            }
            DataTable dtt = (ObjCls.FnGetDataSet("select * from TblNEPSyllabus") as DataSet).Tables[0];
            DataTable DT = (ObjCls.FnGetDataSet("select * from TblNEPSyllabusSubjects") as DataSet).Tables[0];
            DataTable dtt1 = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplate") as DataSet).Tables[0];
            DataTable DT1 = (ObjCls.FnGetDataSet("select * from TblNEPPaperGroup") as DataSet).Tables[0];
            DataTable DT12 = (ObjCls.FnGetDataSet("select * from TblNEPGradeMaster") as DataSet).Tables[0];
            DataTable DT13 = (ObjCls.FnGetDataSet("SELECT * FROM TblNEPSyllabus TBL INNER JOIN TblNEPSyllabusSubjects TBLD on TBL.nId=TBLD.nNEPSyllabusID  INNER JOIN TblNEPPaperGroup TBLG on TBL.nNEPPaperGroupID=TBLG.nId INNER JOIN TblNEPExamTemplate TBLE on TBL.nNEPExamTemplateId=TBLE.nId INNER JOIN TblNEPGradeMaster TBLR on TBL.nGradeId=TBLR.nId WHERE TBL.nIsDelete=0") as DataSet).Tables[0];
            DataTable DT2 = (ObjCls.FnGetDataSet(" SELECT * FROM VwSyllabus where CompanyId=1 AND TType='SYSM' AND BranchId=4 AND FaId=1 AND AcId=2 and Id=2") as DataSet).Tables[0];

        }
        catch (Exception ex)
    {
        FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
    }
}

public override void FnInitializeForm()
{
    int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
    ObjCls = new ClsNEPSyllabus(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
    ViewState["DT"] = FnGetGeneralTable(ObjCls);
    TabContainer1.ActiveTabIndex = 0;
}
public void FnAssignProperty()
{
    base.FnAssignProperty(ObjCls);

        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.NEPPaperGroupID = 6;   //ObjCls.FnIsNumeric(CtrlGrdPaperGroup.SelectedValue.ToString());
        ObjCls.NEPExamTempalteId = 10; // ObjCls.FnIsNumeric(CtrlGrdTemplate.SelectedValue.ToString());
        ObjCls.GradeId = 1;//ObjCls.FnIsNumeric(CtrlGrdGrdSystem.SelectedValue.ToString());
        //ObjCls.NEPPaperGroupID = ObjCls.FnIsNumeric(DdlAcYear.SelectedValue.ToString());
        ObjCls.Remarks= TxtRemarks.Text.Trim();
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }
public void FnClose()
{
    throw new NotImplementedException();
}
public override void FnCancel()
{
        base.FnCancel();
        TxtName.Text = "";
        TxtCode.Text = "";
        TxtName_Srch.Text = "";
        TxtCode_Srch.Text = "";
        CtrlGrdPaperGroup.SelectedValue = "0";
        CtrlGrdPaperGroup.SelectedText = "";
        CtrlGrdTemplate.SelectedValue = "0";
        CtrlGrdTemplate.SelectedText = "";
        CtrlGrdGrdSystem.SelectedValue = "0";
        CtrlGrdGrdSystem.SelectedText = "";
        TxtRemarks.Text = "";
        GrdVwRecords.DataSource = null;
    }
public void FnFindRecord()
{
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        CtrlCommand1.IsVisibleSave = true;
    }

    public void FnFindRecord_S()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("S1");
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
            GrdVwLst.DataSource = ViewState["DT"] as DataTable;
            GrdVwLst.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwLst.DataBind();
            GrdVwLst.SelectedIndex = -1;
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
                            ObjCls.PFlag = "S1";

                            FnAssignProperty();
                        for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                        {
                            HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                            TxtSubject = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubject");
                            ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                            ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                            TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                            //ObjCls.TrDate = ObjCls.FnDateTime(DateTime.Now.ToString("dd/MMM/yyyy"));
                            //ObjCls.DueDate = ObjCls.FnDateTime(CtrlTrDate.DateText);

                             ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                             ObjCls.NEPSubjectName = TxtSubject.Text.Trim();
                             ObjCls.Elective = ObjCls.FnIsNumeric(ChkElective.Checked);
                             ObjCls.Optional = ObjCls.FnIsNumeric(ChkOptional.Checked);
                             ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());

                               // ObjCls.PerAmt = ObjCls.FnIsDouble(TxtPerAmt.Text);
                            //ObjCls.Remarks = TxtRemarks.Text.Trim();

                            _strMsg = ObjCls.SaveRecord() as string;

                            if (ObjCls.FnIsDouble(TxtPriority.Text) > 0 )
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


    protected void GrdVwLst_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            FnCancel();
            GrdVwLst.SelectedIndex = e.NewSelectedIndex;
            ObjCls.PFlag = "V";
            ViewState["ID"] = GrdVwLst.SelectedDataKey.Values[0].ToString();
            FnFindRecord_S();
            ObjCls.GetDataRow(GrdVwLst.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();

            CtrlGrdPaperGroup.SelectedValue = ObjCls.NEPPaperGroupID.ToString(); 
            CtrlGrdPaperGroup.SelectedText = ObjCls.PaperGroupName.ToString();
            CtrlGrdTemplate.SelectedValue = ObjCls.NEPPaperGroupID.ToString();
            CtrlGrdTemplate.SelectedText = ObjCls.NEPExamTemplateName.ToString();
            CtrlGrdGrdSystem.SelectedValue = ObjCls.NEPPaperGroupID.ToString();
            CtrlGrdGrdSystem.SelectedText = ObjCls.NEPGradingName.ToString();
            DdlAcYear.SelectedValue= ObjCls.AcId.ToString();

            TxtRemarks.Text = ObjCls.Remarks.ToString();
            DataTable dataTable1 = ViewState["DT"] as DataTable;
            int RowCount = dataTable1.Rows.Count;

            for (int i = 0; i < RowCount; i++)
            {
                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                TxtSubject = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubject");
                ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

            }


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

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtSubject", typeof(string)));
        dt.Columns.Add(new DataColumn("ChkElective", typeof(Int32)));
        dt.Columns.Add(new DataColumn("ChkOptional", typeof(Int32)));
        dt.Columns.Add(new DataColumn("TxtPriority", typeof(string)));
        
        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["TxtSubject"] = string.Empty;
        dr["ChkElective"] = 0;
        dr["ChkOptional"] = 0;
        dr["TxtPriority"] = string.Empty;
        
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        GrdVwRecords.DataSource = dt;
        GrdVwRecords.DataBind();
    }

    private void AddNewRowToGrid()

    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtSubject");
                    CheckBox box2 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("ChkElective");
                    CheckBox box3 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("ChkOptional");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtPriority");
                   

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["TxtSubject"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["ChkElective"] =ObjCls.FnIsNumeric( box2.Text);
                    dtCurrentTable.Rows[i - 1]["ChkOptional"] = ObjCls.FnIsNumeric(box3.Text);
                    dtCurrentTable.Rows[i - 1]["TxtPriority"] = box4.Text;
                   
                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                GrdVwRecords.DataSource = dtCurrentTable;
                GrdVwRecords.DataBind();
            }

        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks
        SetPreviousData();
    }


    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtSubject");
                    CheckBox box2 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("ChkElective");
                    CheckBox box3 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("ChkOptional");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtPriority");



                    box1.Text = dt.Rows[i]["TxtSubject"].ToString();
                    box2.Text = dt.Rows[i]["ChkElective"].ToString();
                    box3.Text = dt.Rows[i]["ChkOptional"].ToString();
                    box4.Text = dt.Rows[i]["TxtPriority"].ToString();
                    
                    rowIndex++;
                }
            }
        }
    }


    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void GrdVwRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField HdnAutoId = (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnId");
            TextBox LnkName = (TextBox)GrdVwRecords.Rows[e.RowIndex].FindControl("TxtSubject");
            // LinkButton LnkStudentCode = (LinkButton)GrdVwRecords.Rows[e.RowIndex].FindControl("LnkStudentCode");
            Button ButtonAddpaper = (Button)GrdVwRecords.Rows[e.RowIndex].FindControl("BtnPapers");
            //HdnId.Value = HdnAutoId.Value;
            //LblStudentName.Text = LnkName.Text;
            //LblStudentId.Text = LnkStudentCode.Text;

            _strHdr = "Subject Id :- " + LnkName.Text;
           // _strUrl = "SyllabusVsPapers.aspx?CNTRID=" + HdnAutoId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();
            _strUrl = "SyllabusVsPapers.aspx?UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();

            _strTitle = "Papers : - " + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',800,550);";
            ButtonAddpaper.Attributes.Add("onClick", _strLnk);


            //TabContainer1.ActiveTabIndex = 2;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


}