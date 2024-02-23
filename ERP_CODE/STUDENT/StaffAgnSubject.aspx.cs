using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_StaffAgnSubject : ClsPageEvents, IPageInterFace
{
    ClsTeacherVsPaperandStudent ObjCls = new ClsTeacherVsPaperandStudent();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    TextBox TxtGroupName = null;
    HiddenField HdnStudentId = null, HdnId = null;
    CheckBox ChkSelect = null, ChkIsCustomclass = null;
    DropDownList DdlPapers, DdlClass, DdlDivision;
    int iCnt = 0;
    string selectedTextP, selectedTextC, selectedTextD, CCP,CCC;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {

                ObjLst.FnGetStaffList(DdlTeacher, "");
                                
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
        ObjCls = new ClsTeacherVsPaperandStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["CLS"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);

        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
       
        ObjCls.nNEPTeacherId = ObjCls.FnIsNumeric(DdlTeacher.SelectedValue.ToString());
    }
    public void FnGetClassList()
    {
        ViewState["CLS"] = ObjLst.FnGetClassDetailedList();
        DataTable dtt = ViewState["CLS"] as DataTable;
      

    }

    public void FnGetDivisionList()
    {
        ViewState["DIV"] = ObjLst.FnGetDivisionList(ObjCls.FnIsNumeric(1), 0);
        DataTable dtt1 = ViewState["DIV"] as DataTable;
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        
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
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                DdlPapers = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlPapers");
                                DdlClass = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlClass");
                                DdlDivision = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlDivision");
                                TxtGroupName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGroupName");
                                ChkIsCustomclass = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkIsCustomclass");

                                ObjCls.nNEPTeacherId = ObjCls.FnIsNumeric(DdlTeacher.SelectedValue);
                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.nSelect = ObjCls.FnIsNumeric(ChkSelect.Checked);
                                ObjCls.nDdlPapers = ObjCls.FnIsNumeric(DdlPapers.SelectedValue);
                                ObjCls.nDdlClass = ObjCls.FnIsNumeric(DdlClass.SelectedValue);
                                ObjCls.nDdlDivision = ObjCls.FnIsNumeric(DdlDivision.SelectedValue);
                                ObjCls.cGroupName = TxtGroupName.Text.ToString();
                                ChkIsCustomclass = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkIsCustomclass");
                                if (ChkIsCustomclass.Checked == true)
                                {
                                    ObjCls.IsCustomClass = ObjCls.FnIsNumeric(ChkIsCustomclass.Checked);
                                    
                                }


                                _strMsg = ObjCls.SaveRecord() as string;

                                if (ObjCls.FnIsDouble(TxtGroupName.Text) > 0)
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
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                DdlPapers = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlPapers");
                                DdlClass = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlClass");
                                DdlDivision = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlDivision");
                                TxtGroupName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGroupName");
                                ChkIsCustomclass = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkIsCustomclass");

                                HdnId.Value = HdnId.Value;
                                DdlPapers.SelectedValue = dataTable1.Rows[i]["PaperId"].ToString();
                                ChkIsCustomclass.Checked = ObjCls.FnIsBoolean(dataTable1.Rows[i]["CustomClass"].ToString());
                                DdlClass.SelectedValue = dataTable1.Rows[i]["ClassId"].ToString();
                                DdlDivision.SelectedValue = dataTable1.Rows[i]["DivisionId"].ToString();
                                TxtGroupName.Text = dataTable1.Rows[i]["GroupName"].ToString();

                            }

                            
                            break;

                        case "UPDATE":

                            ObjCls.PFlag = "S1";

                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                DdlPapers = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlPapers");
                                DdlClass = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlClass");
                                DdlDivision = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlDivision");
                                TxtGroupName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGroupName");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.nSelect = ObjCls.FnIsNumeric(ChkSelect.Checked);
                                ObjCls.nDdlPapers = ObjCls.FnIsNumeric(DdlPapers.SelectedValue);
                                ObjCls.nDdlClass = ObjCls.FnIsNumeric(DdlClass.SelectedValue);
                                ObjCls.nDdlDivision = ObjCls.FnIsNumeric(DdlDivision.SelectedValue);
                                ObjCls.cGroupName = TxtGroupName.Text.ToString();

                                _strMsg = ObjCls.SaveRecord() as string;

                                if (ObjCls.FnIsDouble(TxtGroupName.Text) > 0)
                                {
                                    iCnt = iCnt + 1;
                                    ObjCls.CFlag = iCnt;
                                }
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Updated"));
                            }
                            ObjCls.PFlag = "S2";
                            FnFindRecord_P();

                            TabContainer1.ActiveTabIndex = 1;

                            break;

                    }
                    break;
                case "FIND":
                    ObjCls.PFlag = "S1";
                    
                    FnFindRecord_S();

                    DataTable dataTable2 = ViewState["DT"] as DataTable;
                    int RowCount1 = dataTable2.Rows.Count;

                    for (int i = 0; i < RowCount1; i++)
                    {
                        HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                        ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                        DdlPapers = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlPapers");
                        DdlClass = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlClass");
                        DdlDivision = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlDivision");
                        TxtGroupName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGroupName");
                        ChkIsCustomclass = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkIsCustomclass");

                        HdnId.Value = HdnId.Value;
                        DdlPapers.SelectedValue = dataTable2.Rows[i]["PaperId"].ToString();
                        ChkIsCustomclass.Checked = ObjCls.FnIsBoolean(dataTable2.Rows[i]["CustomClass"].ToString());
                        DdlClass.SelectedValue = dataTable2.Rows[i]["ClassId"].ToString();
                        DdlDivision.SelectedValue = dataTable2.Rows[i]["DivisionId"].ToString();
                        TxtGroupName.Text = dataTable2.Rows[i]["GroupName"].ToString();


                    }
                    if (RowCount1 == 0)
                    {
                        SetInitialRow();
                    }
                    else
                    {
                        ViewState["CurrentTable"] = dataTable2;
                    }
                                       
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
        dt.Columns.Add(new DataColumn("ChkSelect", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("ChkIsCustomclass", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("DdlPapers", typeof(int)));
        dt.Columns.Add(new DataColumn("DdlClass", typeof(int)));
        dt.Columns.Add(new DataColumn("DdlDivision", typeof(int)));
        dt.Columns.Add(new DataColumn("TxtGroupName", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));

        dr = dt.NewRow();
        dr["ID"] = 1;
        dr["ChkSelect"] = false;
        dr["ChkIsCustomclass"] = false;
        dr["DdlPapers"] = 0;
        dr["DdlClass"] = 0;
        dr["DdlDivision"] = 0;
        dr["TxtGroupName"] = string.Empty;
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
            
            DataTable DTUpdate = ViewState["Update"] as DataTable;
            if (dtCurrentTable.Rows.Count > 0)
            {
                
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    CheckBox box1 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("ChkSelect");
                   
                    DropDownList box2 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("DdlPapers");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("DdlClass");
                    DropDownList box4 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("DdlDivision");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtGroupName");
                    CheckBox box6 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("ChkIsCustomclass");

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["ChkSelect"] = ObjCls.FnIsBoolean(box1.Checked);
                    dtCurrentTable.Rows[i - 1]["DdlPapers"] = ObjCls.FnIsNumeric(box2.SelectedValue);
                    dtCurrentTable.Rows[i - 1]["DdlClass"] = ObjCls.FnIsNumeric(box3.SelectedValue);
                    dtCurrentTable.Rows[i - 1]["DdlDivision"] = ObjCls.FnIsNumeric(box4.SelectedValue);
                    dtCurrentTable.Rows[i - 1]["TxtGroupName"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["ChkIsCustomclass"] = ObjCls.FnIsBoolean(box6.Checked);

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
                    CheckBox box1 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("ChkSelect");
                    DropDownList box2 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[2].FindControl("DdlPapers");
                    DropDownList box3 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[3].FindControl("DdlClass");
                    DropDownList box4 = (DropDownList)GrdVwRecords.Rows[rowIndex].Cells[4].FindControl("DdlDivision");
                    TextBox box5 = (TextBox)GrdVwRecords.Rows[rowIndex].Cells[5].FindControl("TxtGroupName");
                    CheckBox box6 = (CheckBox)GrdVwRecords.Rows[rowIndex].Cells[1].FindControl("ChkIsCustomclass");

                    box1.Checked = ObjCls.FnIsBoolean(dt.Rows[i]["ChkSelect"].ToString());
                    box2.SelectedValue = dt.Rows[i]["DdlPapers"].ToString();
                    box3.SelectedValue = dt.Rows[i]["DdlClass"].ToString();
                    box4.SelectedValue = dt.Rows[i]["DdlDivision"].ToString();
                    box5.Text = dt.Rows[i]["TxtGroupName"].ToString();
                    box6.Checked = ObjCls.FnIsBoolean(dt.Rows[i]["ChkIsCustomclass"].ToString());
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
            
            DropDownList DdlPapers = (DropDownList)GrdVwRecords.Rows[e.RowIndex].FindControl("DdlPapers");
            DropDownList DdlClass = (DropDownList)GrdVwRecords.Rows[e.RowIndex].FindControl("DdlClass");
            DropDownList DdlDivision = (DropDownList)GrdVwRecords.Rows[e.RowIndex].FindControl("DdlDivision");
            
            TextBox TxtGroupName = (TextBox)GrdVwRecords.Rows[e.RowIndex].FindControl("TxtGroupName");
            
            Button ButtonAddStude = (Button)GrdVwRecords.Rows[e.RowIndex].FindControl("BtnStudents");
            string h = HdnAutoId.Value;
            string h2 = DdlPapers.SelectedValue;
            string vs = DdlPapers.Text;
            string ds = TxtGroupName.Text;


            _strHdr = "Paper Name :- " + vs;
            _strUrl = "TeacherVsStudents.aspx?CNTRID=" + h2 + "&UID=" + Request.QueryString["UID"].ToString() + "&CID=" + Request.QueryString["CID"].ToString() + "&BID=" + Request.QueryString["BID"].ToString() + "&FID=" + Request.QueryString["FID"].ToString() + "&AID=" + Request.QueryString["AID"].ToString() + "&MID=" + Request.QueryString["MID"].ToString() + "&UGRPID=" + Request.QueryString["UGRPID"].ToString() + "&TTYPE=" + FnGetRights().TTYPE + "&WIDTH=" + Request.QueryString["WIDTH"].ToString() + "&HEIGHT=" + Request.QueryString["HEIGHT"].ToString();

            _strTitle = "Papers : -PaperId " + h2 + "-GroupId " + h + "" + _strHdr;
            _strLnk = "return FnGetPopUp('" + _strUrl + "','" + _strTitle + "',830,500);";
            ButtonAddStude.Attributes.Add("onClick", _strLnk);
           
            Session["param1"] = h2;
            Session["param2"] =DdlTeacher.SelectedValue.ToString();
            Session["param3"]= HdnAutoId.Value;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void SelectedIndexChangedP(object sender, EventArgs e)
    {
        
        DropDownList DdlPaper = sender as DropDownList;
        string selectedText = DdlPaper.SelectedItem.Text;
       
        TextBox TxtGroupName = DdlPaper.NamingContainer.FindControl("TxtGroupName") as TextBox;
         CCP = TxtGroupName.Text;
        TxtGroupName.Text = CCP + selectedText;
    }
    protected void SelectedIndexChangedC(object sender, EventArgs e)
    {
        
        DropDownList DdlClass = sender as DropDownList;
        string selectedText = DdlClass.SelectedItem.Text;
       
        TextBox TxtGroupName = DdlClass.NamingContainer.FindControl("TxtGroupName") as TextBox;
       

        GridViewRow currentRow = (GridViewRow)DdlClass.NamingContainer;
        DropDownList DdlDivision = (DropDownList)currentRow.FindControl("DdlDivision");

       
        DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='DIVN' and nParentId=" + DdlClass.SelectedValue + "") as DataSet).Tables[0];
        DdlDivision.DataSource = ClsTD;
        DdlDivision.DataValueField = "ID";
        DdlDivision.DataTextField = "Name";
        DdlDivision.DataBind();
        DdlDivision.Items.Insert(0, new ListItem("--select--", "0"));

        String CCC = TxtGroupName.Text;
        TxtGroupName.Text = CCC + selectedText;

    }
    protected void SelectedIndexChangedD(object sender, EventArgs e)
    {
        
        DropDownList DdlDiv = sender as DropDownList;
        string selectedText = DdlDiv.SelectedItem.Text;
        TextBox TxtGroupName = DdlDiv.NamingContainer.FindControl("TxtGroupName") as TextBox;
        String CCD = TxtGroupName.Text;
        TxtGroupName.Text = CCD + selectedText;
        
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DdlPaper = (DropDownList)e.Row.FindControl("DdlPapers");
                DropDownList DdlClass = (DropDownList)e.Row.FindControl("DdlClass");
                DropDownList DdlDiv = (DropDownList)e.Row.FindControl("DdlDivision");
                TextBox TxtGroupName = (TextBox)e.Row.FindControl("TxtGroupName");

                DataTable ClsTP = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cNEPPaperName Name FROM TblNEPPapers  TCD ") as DataSet).Tables[0];
                DdlPaper.DataSource = ClsTP;
                DdlPaper.DataTextField = "Name";
                DdlPaper.DataValueField = "ID";
                DdlPaper.DataBind();
                DdlPaper.Items.Insert(0, new ListItem("--select--", "0"));

                DataTable ClsTC = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='CLS'") as DataSet).Tables[0];
                DdlClass.DataSource = ClsTC;
                DdlClass.DataTextField = "Name";
                DdlClass.DataValueField = "ID";
                DdlClass.DataBind();
                DdlClass.Items.Insert(0, new ListItem("--select--", "0"));

                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='DIVN'") as DataSet).Tables[0];
                DdlDiv.DataSource = ClsTD;
                DdlDiv.DataTextField = "Name";
                DdlDiv.DataValueField = "ID";
                DdlDiv.DataBind();
                DdlDiv.Items.Insert(0, new ListItem("--select--", "0"));
                
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    
}