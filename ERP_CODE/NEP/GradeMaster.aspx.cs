using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NEP_GradeMaster : ClsPageEvents, IPageInterFace
{
    ClsNEPGradeMaster ObjCls = new ClsNEPGradeMaster();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    TextBox TxtGrade = null, TxtRemark = null, TxtRangeFrom = null, TxtRangeTo = null, TxtGradepoint = null, TxtOrder = null, TxtRemarknep=null;
    CheckBox Chkfailed, ChkFailed;

    HiddenField HdnStudentId = null, HdnId = null; 
    int iCnt = 0,cCnt=0;
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

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    public override void FnInitializeForm()
    {
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsNEPGradeMaster(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        TabContainer1.ActiveTabIndex = 0;

    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);

        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
        ObjCls.NEPGradeForOneByEight = ObjCls.FnIsNumeric(ChkGrade.Checked == true ? true : false);

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
        TxtRemarks.Text = "";
        ChkActive.Checked = false;
        ChkGrade.Checked = false;


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
            GrdVwSummary.DataSource = ViewState["DT"] as DataTable;
            GrdVwSummary.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwSummary.DataBind();
            GrdVwSummary.SelectedIndex = -1;
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
                             ObjCls.cFlag = "SS";
                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                TxtGrade = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGrade");
                                TxtRemark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRemark");

                                TxtRangeFrom = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeFrom");
                                TxtRangeTo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeTo");
                                TxtGradepoint= (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGradepoint");
                                Chkfailed=(CheckBox)GrdVwRecords.Rows[i].FindControl("ChkFailed");
                                TxtOrder= (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");

                                ObjCls.NEPGrade = TxtGrade.Text.Trim();
                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.NEPRemarks = TxtRemark.Text.Trim();
                                ObjCls.NEPRangeFrom = ObjCls.FnIsNumeric(TxtRangeFrom.Text.Trim());
                                ObjCls.NEPRangeTo = ObjCls.FnIsNumeric(TxtRangeTo.Text.Trim());
                                ObjCls.NEPGradePoint= ObjCls.FnIsNumeric(TxtGradepoint.Text.Trim());
                                ObjCls.DisplayOrder= ObjCls.FnIsNumeric(TxtOrder.Text.Trim());
                                ObjCls.Failed = ObjCls.FnIsNumeric(Chkfailed.Checked == true ? true : false);


                                _strMsg = ObjCls.SaveRecord() as string;


                                if (ObjCls.FnIsDouble(TxtRangeFrom.Text) > 0 || ObjCls.FnIsDouble(TxtRangeTo.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                    ObjCls.nFlag = iCnt;
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }
                            FnCancel();
                            FnGridViewBinding("S1");
                            break;
                        case "UPDATE":
                            
                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                TxtGrade = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGrade");
                                TxtRemark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRemark");

                                TxtRangeFrom = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeFrom");
                                TxtRangeTo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeTo");
                                TxtGradepoint = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGradepoint");
                                Chkfailed = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkFailed");
                                TxtOrder = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");

                                ObjCls.NEPGrade = TxtGrade.Text.Trim();
                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.NEPRemarks = TxtRemark.Text.Trim();
                                ObjCls.NEPRangeFrom = ObjCls.FnIsNumeric(TxtRangeFrom.Text.Trim());
                                ObjCls.NEPRangeTo = ObjCls.FnIsNumeric(TxtRangeTo.Text.Trim());
                                ObjCls.NEPGradePoint = ObjCls.FnIsNumeric(TxtGradepoint.Text.Trim());
                                ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtOrder.Text.Trim());
                                ObjCls.Failed = ObjCls.FnIsNumeric(Chkfailed.Checked == true ? true : false);

                                cCnt = cCnt + 1;
                                ObjCls.nFlag = cCnt;
                                _strMsg = ObjCls.UpdateRecord() as string;


                                if (ObjCls.FnIsDouble(TxtRangeFrom.Text) > 0 || ObjCls.FnIsDouble(TxtRangeTo.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }
                            FnCancel();
                            FnGridViewBinding("S1");
                            break;
                    }
                    break;
                case "FIND":
                    ObjCls.cFlag = "S1";
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



    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("Grade", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("Range From", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Range To", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Grade Point", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Failed", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("Order", typeof(Int32)));
        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["grade"] = string.Empty;
        dr["Remarks"] = string.Empty;
        dr["Range from"] = 0;
        dr["Range To"] = 0;
        dr["Grade Point"] = 0;
        dr["Failed"] = false;
        dr["Order"] = 0;
        // dr["ChkExpire"] = false;
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
                    //extract the TextBox values
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtGrade");
                    TextBox box2 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("TxtRemark");
                    TextBox box3 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("TxtRangeFrom");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtRangeTo");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtGradepoint");
                    CheckBox box6 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[6].FindControl("ChkFailed");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[7].FindControl("TxtOrder");

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["grade"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Remarks"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Range from"] = ObjCls.FnIsNumeric(box3.Text);
                    dtCurrentTable.Rows[i - 1]["Range To"] = ObjCls.FnIsNumeric( box4.Text);
                    dtCurrentTable.Rows[i - 1]["Grade Point"] = ObjCls.FnIsNumeric( box5.Text);
                    dtCurrentTable.Rows[i - 1]["Failed"] =  ObjCls.FnIsBoolean( box6.Checked);
                    dtCurrentTable.Rows[i - 1]["Order"] = ObjCls.FnIsNumeric(box7.Text);
                    //dtCurrentTable.Rows[i - 1]["ChkExpire"] = box8.Checked;
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
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtGrade");
                    TextBox box2 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("TxtRemark");
                    TextBox box3 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("TxtRangeFrom");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtRangeTo");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtGradepoint");
                    CheckBox box6 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[6].FindControl("ChkFailed");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[7].FindControl("TxtOrder");



                    box1.Text=dt.Rows[i]["grade"].ToString() ;
                    box2.Text = dt.Rows[i]["Remarks"].ToString();
                    box3.Text = ObjCls.FnIsNumeric(dt.Rows[i]["Range from"]).ToString();
                    box4.Text = ObjCls.FnIsNumeric(dt.Rows[i]["Range To"]).ToString();
                    box5.Text = ObjCls.FnIsNumeric(dt.Rows[i]["Grade Point"]).ToString();
                    box6.Checked =  ObjCls.FnIsBoolean(dt.Rows[i]["Failed"].ToString());
                    box7.Text = ObjCls.FnIsNumeric(dt.Rows[i]["Order"]).ToString();
                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }


    protected void GrdVwSummary_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            FnCancel();
            GrdVwSummary.SelectedIndex = e.NewSelectedIndex;
            ObjCls.cFlag = "SS";
            ViewState["ID"] = GrdVwSummary.SelectedDataKey.Values[0].ToString();
            FnFindRecord_S();
            ObjCls.GetDataRow(GrdVwSummary.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);


            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();
            TxtRemarks.Text = ObjCls.NEPRemarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            ChkGrade.Checked = ObjCls.FnIsBoolean(ObjCls.NEPGradeForOneByEight);

            DataTable DT = ViewState["DT"] as DataTable;
            int Rwcount = DT.Rows.Count;
            for (int i = 0; i < Rwcount; i++)
            {
                //AddNewRowToGrid();
                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                TxtGrade = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGrade");
                TxtRemarknep = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRemark");
                TxtRangeFrom = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeFrom");
                TxtRangeTo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRangeTo");
                TxtGradepoint = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGradepoint");
                ChkFailed = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkFailed");
                TxtOrder = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");

                TxtGrade.Text = DT.Rows[i]["Grade"].ToString();
                //HdnId.Value = dataTable1.Rows[i]["SubExamName"].ToString();
                TxtRemarknep.Text = DT.Rows[i]["GRemarks"].ToString();
                TxtRangeFrom.Text = DT.Rows[i]["RangeFrom"].ToString();
                TxtRangeTo.Text = DT.Rows[i]["RangeTo"].ToString();
                TxtGradepoint.Text = DT.Rows[i]["GradePoint"].ToString();
                TxtOrder.Text = DT.Rows[i]["nDisplayOrder"].ToString();
                ChkFailed.Checked = ObjCls.FnIsBoolean(DT.Rows[i]["Failed"].ToString());


            }

            //ChkApprove.Checked = ObjCls.IsApprove;
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
}