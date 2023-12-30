using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NEP_ExamTemplate :ClsPageEvents, IPageInterFace
{
    ClsNEPExamTemplate ObjCls = new ClsNEPExamTemplate();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    TextBox TxtSubExamName = null, TxtMaxMark = null, TxtPercentage = null, TxtPriority=null;
    HiddenField HdnStudentId = null, HdnId = null;
    DropDownList DdlRptColumn = null;
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

    }
    catch (Exception ex)
    {
        FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
    }
}
      
public override void FnInitializeForm()
{
    int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
    ObjCls = new ClsNEPExamTemplate(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
    ViewState["DT"] = FnGetGeneralTable(ObjCls);
    TabContainer1.ActiveTabIndex = 0;
    
}
    public void FnAssignProperty()
{
        base.FnAssignProperty(ObjCls);

        ObjCls.NEPPaperGroupID = 6;
            //ObjCls.FnIsNumeric(CtrlGrdPaperGroup.SelectedValue);
        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.Remarks = TxtRemark.Text.Trim();
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
        ObjCls.DefaultTemplate = (ChkDefaultTemp.Checked == true ? true : false);
        
 }
public void FnClose()
{
    throw new NotImplementedException();
}
public override void FnCancel()
{
        base.FnCancel();
        CtrlGrdPaperGroup.SelectedValue = "0";
        CtrlGrdPaperGroup.SelectedText = "";
        TxtName.Text = "";
        TxtCode.Text = "";
        TxtRemark.Text = "";


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

                            ObjCls.cFlag = "SS";
                        FnAssignProperty();
                        for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                        {
                            HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                            TxtSubExamName= (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubExamName");
                            DdlRptColumn = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlRptColumn");
                            TxtMaxMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMaxMark");

                            TxtPercentage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPercentage");
                            TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                                ObjCls.SubExamName = TxtSubExamName.Text.Trim();
                                ObjCls.ID= ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.NEPRptColumnID = ObjCls.FnIsNumeric(DdlRptColumn.SelectedValue);
                                ObjCls.MaxMark = ObjCls.FnIsNumeric(TxtMaxMark.Text.Trim());
                                ObjCls.Percentage= ObjCls.FnIsNumeric(TxtPercentage.Text.Trim());
                                ObjCls.DisplayOrder= ObjCls.FnIsNumeric(TxtPriority.Text.Trim());

                                
                               _strMsg = ObjCls.SaveRecord() as string;
                               

                            if (ObjCls.FnIsDouble(TxtPriority.Text) > 0 || ObjCls.FnIsDouble(TxtMaxMark.Text) > 0)
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
                    DataTable dtt = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplate") as DataSet).Tables[0];
                    DataTable dt = (ObjCls.FnGetDataSet("select * from TblNEPExamTemplateDetails") as DataSet).Tables[0];
                    // DataTable dts = (ObjCls.FnGetDataSet("select * from VwExamTemplate") as DataSet).Tables[0];
                    // DataTable dts = (ObjCls.FnGetDataSet("SELECT *	FROM TblNEPExamTemplate TBL INNER JOIN TblNEPExamTemplateDetails TBLD on TBL.nId = TBLD.nNEPExamTemplateID INNER JOIN TblNEPPaperGroup TBLG on TBL.nNEPPaperGroupID = TBLG.nId WHERE TBL.nIsDelete = 0") as DataSet).Tables[0];
                    DataTable dts = (ObjCls.FnGetDataSet("SELECT *	FROM TblNEPExamTemplate TBL INNER JOIN TblNEPExamTemplateDetails TBLD on TBL.nId = TBLD.nNEPExamTemplateID WHERE TBL.nIsDelete = 0") as DataSet).Tables[0];
                    ObjCls.cFlag = "S1";
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

    

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("Sub Exam name", typeof(string)));
        dt.Columns.Add(new DataColumn("Report Column", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Max Mark", typeof(string)));
        dt.Columns.Add(new DataColumn("Percentage", typeof(string)));
        dt.Columns.Add(new DataColumn("Order", typeof(string)));
        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["Sub Exam name"] = string.Empty;
        dr["Report column"] = 0;
        dr["Max Mark"] = string.Empty;
        dr["Percentage"] = string.Empty;
        dr["Order"] = string.Empty;
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
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtSubExamName");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("DdlRptColumn");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("TxtMaxMark");
                    TextBox box6 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtPercentage");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtPriority");

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Sub Exam name"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Report Column"] = ObjCls.FnIsNumeric(box3.SelectedValue);
                    dtCurrentTable.Rows[i - 1]["Max Mark"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Percentage"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["Order"] = box7.Text;
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
                    TextBox box1 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("TxtSubExamName");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("DdlRptColumn");
                    TextBox box4 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("TxtMaxMark");
                    TextBox box6 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("TxtPercentage");
                    TextBox box7 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtPriority");


                    box1.Text = dt.Rows[i]["Sub Exam name"].ToString();
                    box3.Text = dt.Rows[i]["report Column"].ToString();
                    box4.Text = dt.Rows[i]["Max Mark"].ToString();
                    box6.Text = dt.Rows[i]["Percentage"].ToString();
                    box7.Text = dt.Rows[i]["Order"].ToString();
                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void GrdVwLst_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        try
        {
            FnCancel();
            GrdVwLst.SelectedIndex = e.NewSelectedIndex;
            ObjCls.cFlag = "SS";
            ViewState["ID"] = GrdVwLst.SelectedDataKey.Values[0].ToString();
            FnFindRecord_S();
            ObjCls.GetDataRow(GrdVwLst.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            

            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();
            CtrlGrdPaperGroup.SelectedValue = ObjCls.NEPPaperGroupID.ToString();
            CtrlGrdPaperGroup.SelectedText = ObjCls.NEPPaperGroupName.ToString();
            TxtRemark.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            ChkDefaultTemp.Checked = ObjCls.DefaultTemplate;

            DataTable DT = ViewState["DT"] as DataTable;
            int Rwcount = DT.Rows.Count;
            for (int i = 0; i < Rwcount; i++)
            {
                //AddNewRowToGrid();
                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                TxtSubExamName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtSubExamName");
                DdlRptColumn = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlRptColumn");
                TxtMaxMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMaxMark");
                TxtPercentage = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPercentage");
                TxtPriority = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtPriority");

                TxtSubExamName.Text = DT.Rows[i]["SubExamName"].ToString();
                //HdnId.Value = dataTable1.Rows[i]["SubExamName"].ToString();
                DdlRptColumn.SelectedValue = DT.Rows[i]["RptColumnID"].ToString();
                TxtMaxMark.Text = DT.Rows[i]["MaxMark"].ToString();
                TxtPercentage.Text = DT.Rows[i]["Percentage"].ToString();
                TxtPriority.Text = DT.Rows[i]["DisplayOrder"].ToString();

                //TxtSubExamName.Text=ObjCls.SubExamName;
                //HdnId.Value = ObjCls.FnIsNumeric(ObjCls.ID).ToString();
                //DdlRptColumn.SelectedValue= ObjCls.FnIsNumeric(ObjCls.NEPRptColumnID).ToString();
                //TxtMaxMark.Text= ObjCls.FnIsNumeric(ObjCls.MaxMark).ToString();
                //TxtPercentage.Text= ObjCls.FnIsNumeric(ObjCls.Percentage).ToString();
                //TxtPriority.Text = ObjCls.FnIsNumeric(ObjCls.DisplayOrder).ToString();
            }
            
            //ChkApprove.Checked = ObjCls.IsApprove;
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            //CtrlCommand1.SaveText = "Update";
            //CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
        
    }
    
}