using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NEP_PapperGrpMaster : ClsPageEvents, IPageInterFace
{
    ClsNEPPaperGroup ObjCls = new ClsNEPPaperGroup();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    TextBox TxtReportColumn = null, TxtAbbreviation = null, TxtMaxMark = null, TxtWeightage = null, TxtPercentage = null, TxtOrder= null;
    HiddenField HdnStudentId = null, HdnId = null, HdnRwIndex = null, HdnIndex = null, HdnFeeId = null;
    CtrlDate CtrlFrmDate = null, CtrlToDate = null;
    GridView GrdVwChld = null;
    DropDownList DdlInputType = null;
    CheckBox ChkExpire = null;
    int iCnt = 0, cCnt = 0;

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
        ObjCls = new ClsNEPPaperGroup(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        TabContainer1.ActiveTabIndex = 0;
        //FnGridViewBinding("");
        
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.Abbreviation = TxtAbrvtion.Text.Trim();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
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
        TxtAbrvtion.Text = "";
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
                            ObjCls.PFlag = "S1";
                            FnAssignProperty();

                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnNId");
                                TxtReportColumn = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtReportColumn");
                                TxtAbbreviation = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtAbbreviation");
                                DdlInputType = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlInputType");
                                TxtMaxMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMaxMark");
                                TxtWeightage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtWeightage");

                                TxtPercentage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPercentage");
                                TxtOrder = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");
                                ChkExpire = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkExpire");

                                ObjCls.NEPRptColumnName = TxtReportColumn.Text.Trim();
                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.InputType = ObjCls.FnIsNumeric(DdlInputType.SelectedValue);
                                ObjCls.RptAbbreviation = TxtAbbreviation.Text.Trim();
                                ObjCls.MaxMark = ObjCls.FnIsNumeric(TxtMaxMark.Text.Trim());
                                ObjCls.Weightage = ObjCls.FnIsNumeric(TxtWeightage.Text.Trim());
                                ObjCls.Percentage = ObjCls.FnIsNumeric(TxtPercentage.Text.Trim());
                                ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtOrder.Text.Trim());

                                _strMsg = ObjCls.SaveRecord() as string;

                                if (ObjCls.FnIsDouble(TxtWeightage.Text) > 0 || ObjCls.FnIsDouble(TxtMaxMark.Text) > 0)
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

                        case "UPDATE":

                            ObjCls.PFlag = "S1";
                            FnAssignProperty();

                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                cCnt = cCnt + 1;
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnNId");
                                TxtReportColumn = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtReportColumn");
                                TxtAbbreviation = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtAbbreviation");
                                DdlInputType = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlInputType");
                                TxtMaxMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMaxMark");
                                TxtWeightage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtWeightage");

                                TxtPercentage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPercentage");
                                TxtOrder = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");
                                ChkExpire = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkExpire");

                                ObjCls.NEPRptColumnName = TxtReportColumn.Text.Trim();
                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.InputType = ObjCls.FnIsNumeric(DdlInputType.SelectedValue);
                                ObjCls.RptAbbreviation = TxtAbbreviation.Text.Trim();
                                ObjCls.MaxMark = ObjCls.FnIsNumeric(TxtMaxMark.Text.Trim());
                                ObjCls.Weightage = ObjCls.FnIsNumeric(TxtWeightage.Text.Trim());
                                ObjCls.Percentage = ObjCls.FnIsNumeric(TxtPercentage.Text.Trim());
                                ObjCls.DisplayOrder = ObjCls.FnIsNumeric(TxtOrder.Text.Trim());
                                ObjCls.CFlag = cCnt;
                                _strMsg = ObjCls.UpdateRecord() as string;

                                if (ObjCls.FnIsDouble(TxtWeightage.Text) > 0 || ObjCls.FnIsDouble(TxtMaxMark.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                    
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Updated"));
                            }

                            FnCancel();
                            FnGridViewBinding("S1");


                           

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

    protected void GrdVwSummary_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            FnCancel();
            GrdVwSummary.SelectedIndex = e.NewSelectedIndex;
            ObjCls.PFlag = "V";
            ViewState["ID"] = GrdVwSummary.SelectedDataKey.Values[0].ToString();
            FnFindRecord_S();
            ObjCls.GetDataRow(GrdVwSummary.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();
            TxtAbrvtion.Text = ObjCls.Abbreviation.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();
            DataTable dataTable1 = ViewState["DT"] as DataTable;
            int RowCount = dataTable1.Rows.Count;

            for(int i=0;i<RowCount;i++)
            {
                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnNId");
                TxtReportColumn = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtReportColumn");
                TxtAbbreviation = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtAbbreviation");
                DdlInputType = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlInputType");
                TxtMaxMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMaxMark");
                TxtWeightage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtWeightage");
                TxtPercentage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPercentage");
                TxtOrder = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtOrder");
                
                TxtReportColumn.Text = dataTable1.Rows[i]["RptColumnName"].ToString();
                TxtAbbreviation.Text = dataTable1.Rows[i]["RptAbbreviation"].ToString();
                DdlInputType.SelectedValue = dataTable1.Rows[i]["InputType"].ToString();
                TxtMaxMark.Text = dataTable1.Rows[i]["MaxMark"].ToString();
                TxtWeightage.Text = dataTable1.Rows[i]["Weightage"].ToString();
                TxtPercentage.Text = dataTable1.Rows[i]["Percentage"].ToString();
                TxtOrder.Text = dataTable1.Rows[i]["DisplayOrder"].ToString();
                               
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
        dt.Columns.Add(new DataColumn("TxtReportColumn", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtAbbreviation", typeof(string)));
        dt.Columns.Add(new DataColumn("DdlInputType", typeof(Int32)));
        dt.Columns.Add(new DataColumn("TxtMaxMark", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtWeightage", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtPercentage", typeof(string)));
        dt.Columns.Add(new DataColumn("TxtOrder", typeof(string)));
        dt.Columns.Add(new DataColumn("ChkExpire", typeof(bool)));
        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["TxtReportColumn"] = string.Empty;
        dr["TxtAbbreviation"] = string.Empty;
        dr["DdlInputType"] = 0;
        dr["TxtMaxMark"] = string.Empty;
        dr["TxtWeightage"] = string.Empty;
        dr["TxtPercentage"] = string.Empty;
        dr["TxtOrder"] = string.Empty;
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
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtReportColumn");
                    TextBox box2 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("TxtAbbreviation");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("DdlInputType");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtMaxMark");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtWeightage");
                    TextBox box6 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[6].FindControl("TxtPercentage");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[7].FindControl("TxtOrder");
                    CheckBox box8 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[8].FindControl("ChkExpire");
                   
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["TxtReportColumn"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["TxtAbbreviation"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["DdlInputType"] =ObjCls.FnIsNumeric( box3.SelectedValue);
                    dtCurrentTable.Rows[i - 1]["TxtMaxMark"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["TxtWeightage"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["TxtPercentage"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["TxtOrder"] = box7.Text;
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
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtReportColumn");
                    TextBox box2 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("TxtAbbreviation");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("DdlInputType");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtMaxMark");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtWeightage");
                    TextBox box6 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[6].FindControl("TxtPercentage");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[7].FindControl("TxtOrder");
                    CheckBox box8 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[8].FindControl("ChkExpire");

                    box1.Text = dt.Rows[i]["TxtReportColumn"].ToString();
                    box2.Text = dt.Rows[i]["TxtAbbreviation"].ToString();
                    box3.Text = dt.Rows[i]["DdlInputType"].ToString();
                    box4.Text = dt.Rows[i]["TxtMaxMark"].ToString();
                    box5.Text = dt.Rows[i]["TxtWeightage"].ToString();
                    box6.Text = dt.Rows[i]["TxtPercentage"].ToString();
                    box7.Text = dt.Rows[i]["TxtOrder"].ToString();
                    box8.Text = dt.Rows[i]["ChkExpire"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

}