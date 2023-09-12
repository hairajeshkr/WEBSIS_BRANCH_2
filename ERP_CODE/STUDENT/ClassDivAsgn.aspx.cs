using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class STUDENT_ClassDivAsgn : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //FnInitializeForm();


                //DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[9] { new DataColumn("hMale"), new DataColumn("hFemale"), new DataColumn("hTotal"), new DataColumn+("mMale"), new DataColumn("mFemale"), new DataColumn("mTotal"), new DataColumn("cMale"), new DataColumn("cFemale"), new DataColumn("cTotal") });
                ////dt.Rows.Add("John Hammond", "United States", "Albert Dunner", "Bolivia");
                ////dt.Rows.Add("Mudassar Khan", "India", "Jason Sprint", "Canada");
                ////dt.Rows.Add("Suzanne Mathews", "France", "Alfred Lobo", "Philippines");
                ////dt.Rows.Add("Robert Schidner", "Russia", "Shaikh Ayyaz", "UAE");
                //GrdVwRecords.DataSource = dt;
                //GrdVwRecords.DataBind();



                DataTable DTClasses = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
                ChkClassDivList.DataSource = DTClasses;
                ChkClassDivList.DataValueField = "nId";
                ChkClassDivList.DataTextField = "cName";
                ChkClassDivList.DataBind();

                DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
                ChkDivList.DataSource = DTChkClassDiv;
                ChkDivList.DataValueField = "nId";
                ChkDivList.DataTextField = "cName";
                ChkDivList.DataBind();
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
        ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        FnGridViewBinding("SRCH");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);

    }
    public void FnAssignProperty_Srch()
    {
        base.FnAssignProperty(ObjCls);

    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        //CtrlGrdClass.SelectedValue = "0";
        //CtrlGrdClass.SelectedText = "";
        //CtrlGrdDivision.SelectedValue = "0";
        //CtrlGrdDivision.SelectedText = "";
        //CtrlCommand1.SaveText = "Save";
        //CtrlCommand1.SaveCommandArgument = "NEW";
        //FnFocus(CtrlGrdClass.ControlTextBox);
        TabContainer1.ActiveTabIndex = 0;
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        //FnGetDivisionList();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");

        //ObjLst.FnGetDivisionList(DdlToDivision, "", ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue), ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue));
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnFindRecord_Srch()
    {
        FnAssignProperty_Srch();
        ViewState["DT_CHILD"] = (ObjCls.FindRecord() as DataSet).Tables[0];
        FnGridViewBinding("SRCH");
        TabContainer1.ActiveTabIndex = 1;
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
        //GrdVwRecords.SelectedIndex = -1;

        //GrdVwSummary.DataSource = ViewState["DT"] as DataTable;
        //GrdVwSummary.DataBind();

        //GrdVwList.DataSource = ViewState["DT"] as DataTable;
        //GrdVwList.DataBind();

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


                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Group", typeof(string)));
                    //dt.Columns.Add(new DataColumn("SubGroup", typeof(string)));

                    string selectedItemsC = "", selectedclass = "";
                    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    {
                        if (ChkClassDivList.Items[i].Selected)
                        {
                            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                            selectedclass = ChkClassDivList.Items[i].Text;
                            DataRow row = dt.NewRow();
                            row["Group"] = selectedclass.TrimEnd(',');
                            dt.Rows.Add(row);
                        }

                    }

                    selectedItemsC = selectedItemsC.TrimEnd(',');
                    selectedclass = selectedclass.TrimEnd(',');

                    DataTable dclass = new DataTable();
                    dclass.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                    string selectedItemsD = "", selecteddiv = "";
                    for (int i = 0; i < ChkDivList.Items.Count; i++)
                    {

                        if (ChkDivList.Items[i].Selected)
                        {
                            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                            selecteddiv = ChkDivList.Items[i].Text;
                            DataRow drow = dclass.NewRow();
                            drow["SubGroup"] = selecteddiv;
                            dclass.Rows.Add(drow);


                        }

                    }

                    

                    selectedItemsD = selectedItemsD.TrimEnd(',');
                    selecteddiv = selecteddiv.TrimEnd(',');

                    DataTable DTMale = new DataTable();

                    //string query = "select count(case when cSex='Male' then 1 end) as Male,count(case when cSex='Female' then 1 end) as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") ";

                    //string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=8  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=8  then 1 end)as Female,0 total FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";

                    // string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=8  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=8  then 1 end)as Female,0 total,count(case when cSex= 'Male' and nReligionId=18  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=18  then 1 end)as hFemale,0 htotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";


                    string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=8  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=8  then 1 end)as Female,0 total,count(case when cSex= 'Male' and nReligionId=18  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=18  then 1 end)as hFemale,0 htotal,count(case when cSex= 'Male' and nReligionId=9  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=9  then 1 end)as mFemale,0 mtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";




                    DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    GrdVwRecords.DataSource = DTMale;
                   // DTMale.Columns.Add
                    GrdVwRecords.DataBind();
                    //FnPopUpAlert(ObjCls.FnAlertMessage("Record saved successfully"));
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "FIND_SRCH":
                    FnFindRecord_Srch();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "CLEAR_SRCH":
                    //FnCancel_Srch();
                    break;
                case "PRINT":
                    FnAssignProperty_Srch();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    protected void ChkSelctAllClass_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSelctAllClass.Checked == true)
        {
            foreach (ListItem item in ChkClassDivList.Items)
            {
                item.Selected = true;
                item.Enabled = true;
            }
        }
        else
        {
            foreach (ListItem item in ChkClassDivList.Items)
            {
                item.Selected = false;
                item.Enabled = true;
            }
        }
    }



    protected void ChkSelectAllDiv_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSelectAllDiv.Checked == true)
        {
            foreach (ListItem item in ChkDivList.Items)
            {
                item.Selected = true;
                item.Enabled = true;
            }
        }
        else
        {
            foreach (ListItem item in ChkDivList.Items)
            {
                item.Selected = false;
                item.Enabled = true;
            }

        }
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //for(int j=0;j<GrdVwRecords.Rows.Count;j++)
        //{
        //    GrdVwRecords.Rows[j].Cells[3].Text = "M";
        //}


        //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //TableHeaderCell cell = new TableHeaderCell();
        //cell.Text = "Customers";
        //cell.ColumnSpan = 2;
        //row.Controls.Add(cell);

        //cell = new TableHeaderCell();
        //cell.ColumnSpan = 2;
        //cell.Text = "Employees";
        //row.Controls.Add(cell);


        //GrdVwRecords.Controls[0].Controls.AddAt(0, row);
        ////row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        ////GrdVwRecords.HeaderRow.Parent.Controls.AddAt(1, row);
        ///

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "class";
            //HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = new TableCell();
            HeaderCell.Text = "division";
            //HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "hindu";
            HeaderCell.ColumnSpan =3 ;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = new TableCell();
            HeaderCell.Text = "christian";
            HeaderCell.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "muslim";
            HeaderCell.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(HeaderCell);

            GrdVwRecords.Controls[0].Controls.AddAt(2, HeaderGridRow);


        }
    }




    protected void GrdVwRecords_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }

    //protected void GrdVwRecords_DataBound2(object sender, EventArgs e)
    //{
    //    //if (e.Row.RowType == DataControlRowType.Header)
    //    //{
    //        GridView HeaderGrid = (GridView)sender;
    //        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


    //        TableCell HeaderCell = new TableCell();
    //        HeaderCell.Text = "class";
    //        //HeaderCell.ColumnSpan = 2;
    //        HeaderGridRow.Cells.Add(HeaderCell);


    //        HeaderCell = new TableCell();
    //        HeaderCell.Text = "division";
    //        //HeaderCell.ColumnSpan = 2;
    //        HeaderGridRow.Cells.Add(HeaderCell);

    //        HeaderCell = new TableCell();
    //        HeaderCell.Text = "hindu";
    //        HeaderCell.ColumnSpan = 3;
    //        HeaderGridRow.Cells.Add(HeaderCell);


    //        HeaderCell = new TableCell();
    //        HeaderCell.Text = "christian";
    //        HeaderCell.ColumnSpan = 3;
    //        HeaderGridRow.Cells.Add(HeaderCell);

    //        HeaderCell = new TableCell();
    //        HeaderCell.Text = "muslim";
    //        HeaderCell.ColumnSpan = 3;
    //        HeaderGridRow.Cells.Add(HeaderCell);

    //        GrdVwRecords.Controls[0].Controls.AddAt(0, HeaderGridRow);


    //    //}
    //}

    protected void GrdVwRecords_RowDataBound11(object sender, GridViewRowEventArgs e)
    {

    }
}
