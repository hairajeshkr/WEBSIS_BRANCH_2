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
    HiddenField HdnStudentId = null, HdnId = null, HdnSubjId=null;
    CheckBox ChkElective = null, ChkOptional=null;
    DropDownList DdlSubject;
    int iCnt = 0, cCnt = 0;
    GridView GrdVwChld = null;
    string Status;
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
               FnGridViewBinding("S2");
                SetInitialRow();
            }

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
        ObjCls.NEPPaperGroupID = ObjCls.FnIsNumeric(CtrlGrdPaperGroup.SelectedValue.ToString());
        ObjCls.NEPExamTempalteId = ObjCls.FnIsNumeric(CtrlGrdTemplate.SelectedValue.ToString());
        ObjCls.GradeId = ObjCls.FnIsNumeric(CtrlGrdGrdSystem.SelectedValue.ToString());
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
    public void FnFindRecord_P()
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
        else if (PrmFlag == "S2")
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
                                DdlSubject = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSubject");
                                ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                            ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                            TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                             ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                             ObjCls.NEPSubjectName = TxtSubject.Text.ToString();
                            
                             ObjCls.Elective = ObjCls.FnIsNumeric(ChkElective.Checked);
                             ObjCls.Optional = ObjCls.FnIsNumeric(ChkOptional.Checked);
                             ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());

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
                            ObjCls.PFlag = "S2";
                            FnFindRecord_P();


                            DataTable dataTable1 = ViewState["DT"] as DataTable;
                            int RowCount = dataTable1.Rows.Count;

                            for (int i = 0; i < RowCount; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                HdnSubjId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnSubjId");
                                TxtSubject = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubject");
                                ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                                ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                                TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                                HdnId.Value = HdnId.Value;
                                HdnSubjId.Value = HdnSubjId.Value;
                                TxtSubject.Text = dataTable1.Rows[i]["SubjectName"].ToString();
                                ChkElective.Checked = ObjCls.FnIsBoolean(dataTable1.Rows[i]["Elective"].ToString());
                                ChkOptional.Checked = ObjCls.FnIsBoolean(dataTable1.Rows[i]["Optional"].ToString());
                                TxtPriority.Text = dataTable1.Rows[i]["DisplayOrder"].ToString();

                            }


                            
                            break;

                        case "UPDATE":

                            ObjCls.PFlag = "S1";

                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                cCnt = cCnt + 1;
                                HdnId = (HiddenField)GrdVwRecords.Rows[0].FindControl("HdnId");
                                HdnSubjId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnSubjId");
                                TxtSubject = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubject");
                                DdlSubject = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSubject");
                                ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                                ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                                TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.NEPSubjectName = TxtSubject.Text.ToString();
                                ObjCls.HdnSubjId = ObjCls.FnIsNumeric(HdnSubjId.Value);
                                ObjCls.Elective = ObjCls.FnIsNumeric(ChkElective.Checked);
                                ObjCls.Optional = ObjCls.FnIsNumeric(ChkOptional.Checked);
                                ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());
                                ObjCls.CFlag = cCnt;
                                _strMsg = ObjCls.UpdateRecord() as string;

                                if (ObjCls.FnIsDouble(TxtPriority.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                    
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Updated"));
                            }
                            ObjCls.PFlag = "S2";

                            FnFindRecord_P();


                            DataTable dataTable2 = ViewState["DT"] as DataTable;
                            int RowCount2 = dataTable2.Rows.Count;

                            for (int i = 0; i < RowCount2; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                HdnSubjId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnSubjId");
                                TxtSubject = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubject");
                                ChkElective = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkElective");
                                ChkOptional = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkOptional");
                                TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                                HdnId.Value = HdnId.Value;
                                HdnSubjId.Value = HdnSubjId.Value;
                                TxtSubject.Text = dataTable2.Rows[i]["SubjectName"].ToString();
                                ChkElective.Checked = ObjCls.FnIsBoolean(dataTable2.Rows[i]["Elective"].ToString());
                                ChkOptional.Checked = ObjCls.FnIsBoolean(dataTable2.Rows[i]["Optional"].ToString());
                                TxtPriority.Text = dataTable2.Rows[i]["DisplayOrder"].ToString();

                            }




                            TabContainer1.ActiveTabIndex = 0;

                            break;

                    }
                break;
            case "FIND":
                    ObjCls.PFlag = "S1";
                    FnFindRecord();
                   break;
            case "CLEAR":
                FnCancel();
                    FnGridViewBinding("S1");

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

                TxtSubject.Text = dataTable1.Rows[i]["SubjectName"].ToString();
                ChkElective.Checked = ObjCls.FnIsBoolean(dataTable1.Rows[i]["Elective"].ToString());
                ChkOptional.Checked = ObjCls.FnIsBoolean(dataTable1.Rows[i]["Optional"].ToString());
                TxtPriority.Text = dataTable1.Rows[i]["DisplayOrder"].ToString();
            }


            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();
            if (RowCount == 0)
            {
                SetInitialRow();
            }
            else
            {
                ViewState["CurrentTable"] = dataTable1;
            }


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
        dt.Columns.Add(new DataColumn("SubjectId", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtSubject", typeof(string)));
        dt.Columns.Add(new DataColumn("ChkElective", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("ChkOptional", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("TxtPriority", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));

        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["SubjectId"] = 1;
        dr["TxtSubject"] = string.Empty;
        dr["ChkElective"] = false;
        dr["ChkOptional"] = false;
        dr["TxtPriority"] = string.Empty;
        dr["Status"] = 'B';
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
                    dtCurrentTable.Rows[i - 1]["ChkElective"] =ObjCls.FnIsBoolean( box2.Checked);
                    dtCurrentTable.Rows[i - 1]["ChkOptional"] = ObjCls.FnIsBoolean(box3.Checked);
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
                    box2.Checked =  ObjCls.FnIsBoolean( dt.Rows[i]["ChkElective"].ToString());
                    box3.Checked = ObjCls.FnIsBoolean(dt.Rows[i]["ChkOptional"].ToString());
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
            HiddenField HdnSubjId = (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnSubjId");
            
            TextBox SubjName = (TextBox)GrdVwRecords.Rows[e.RowIndex].FindControl("TxtSubject");
            TextBox DisplayOrder = (TextBox)GrdVwRecords.Rows[e.RowIndex].FindControl("TxtPriority");
            Button ButtonAddpaper = (Button)GrdVwRecords.Rows[e.RowIndex].FindControl("BtnPapers");
            string h = HdnAutoId.Value;
            string h2 = HdnSubjId.Value;
            string vs = SubjName.Text;
            string ds = DisplayOrder.Text;


            _strHdr = "Subject Name :- " + SubjName.Text;
            _strUrl = "SyllabusVsPapers.aspx?CNTRID=" + HdnSubjId.Value + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();

            _strTitle = "Papers : -SUBID " + h2 + "-SYLABID " + h + "" + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',900,550);";
            ButtonAddpaper.Attributes.Add("onClick", _strLnk);
            Session["param1"] = HdnAutoId.Value;
            Session["param2"] = ObjCls.FnIsNumeric(CtrlGrdTemplate.SelectedValue.ToString());

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


}