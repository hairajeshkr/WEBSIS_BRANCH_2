using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;

public partial class REPORT_FORMS_RptSchoolCumulative : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    static int icount = 0;
    string CType;
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
                DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(DTInstitute, icount, null);


            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode)
    {
        int VS;
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode tnode = new TreeNode
            {
                Text = row["Name"].ToString(),
                Value = row["ID"].ToString()
            };

            if (ParentId == 0)
            {
                TreVwLst.Nodes.Add(tnode);
                DataTable DTClass = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId= " + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(DTClass, VS, tnode);
            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable DTDivision = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN'and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(DTDivision, VS, tnode);
            }
            else
            {
                treeNode.ChildNodes.Add(tnode);
            }
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
       
        TabContainer1.ActiveTabIndex = 0;
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        //FnGetDivisionList();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");

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

        //GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        //GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //GrdVwRecords.DataBind();
        //GrdVwRecords.SelectedIndex = -1;

        

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



                    ExportDataTable();
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
                    this.BindReport();
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


  

    protected void GrdVwRecords_DataBound(object sender, EventArgs e)
    {
        if (ChkReligionCat.SelectedValue == "1")
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "Class";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 1;
            cell.Text = "Division";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Christian";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Hindu";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Muslim";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "All Religion";
            row.Controls.Add(cell);



        }




    }

    protected void GrdVwCategory_DataBound(object sender, EventArgs e)
    {
        if (ChkReligionCat.SelectedValue == "2")
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "Class";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 1;
            cell.Text = "Division";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "GENERAL";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "NON RESERVATION";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "OBC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "OEC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "RESERVATION";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "SC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "ST";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "All Category";
            row.Controls.Add(cell);


         

        }
    }



    private void BindReport()
    {
        string selectedItemsC = "", selectedclass = "";


        String InstId = "", Instmessage = "", Clsmessage = "", ClsId = "", Divmessage = "", DivId = "";

        foreach (TreeNode node in TreVwLst.CheckedNodes)
        {
            if (node.Depth == 0)
            {
                Instmessage += node.Text + ",";
                InstId += node.Value + ",";
            }
            else if (node.Depth == 1)
            {
                Clsmessage += node.Text + ",";
                ClsId += node.Value + ",";
            }
            else if (node.Depth == 2)
            {
                Divmessage += node.Text + ",";
                DivId += node.Value + ",";
            }

        }
        InstId = InstId.TrimEnd(',');
        ClsId = ClsId.TrimEnd(',');
        DivId = DivId.TrimEnd(',');



        if (ChkReligionCat.SelectedValue == "1")
        {

            string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=7  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=7  then 1 end)as Female,0 total,count(case when cSex= 'Male' and nReligionId=2  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=2  then 1 end)as hFemale,0 htotal,count(case when cSex= 'Male' and nReligionId=6  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=6  then 1 end)as mFemale,0 mtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  group by CLS.cName,DIV.cName";

            string parameter1 = query;
            string parameter2 = "1";
            Session["param1"] = parameter1;
            Session["param2"] = parameter2;
        }
        if (ChkReligionCat.SelectedValue == "2")
        {

            string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nCategoryId=5  then 1 end) as GMale,count(case when cSex= 'Female' and nCategoryId=5  then 1 end)as GFemale,count(case when cSex= 'Male' and nCategoryId=30  then 1 end) as NonResMale,count(case when cSex= 'Female' and nCategoryId=30  then 1 end)as NonResFeMale,count(case when cSex= 'Male' and nCategoryId=6  then 1 end) as OBCMale,count(case when cSex= 'Female' and nCategoryId=6  then 1 end)as OBCFemale,count(case when cSex= 'Male' and nCategoryId=15  then 1 end) as OECMale,count(case when cSex= 'Female' and nCategoryId=15  then 1 end)as OECFemale,count(case when cSex= 'Male' and nCategoryId=23  then 1 end) as RESMale,count(case when cSex= 'Female' and nCategoryId=23  then 1 end)as RESFemale,count(case when cSex= 'Male' and nCategoryId=3  then 1 end) as SCMale,count(case when cSex= 'Female' and nCategoryId=3  then 1 end)as SCFemale,count(case when cSex= 'Male' and nCategoryId=11  then 1 end) as STMale,count(case when cSex= 'Female' and nCategoryId=11  then 1 end)as STFemale FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  group by CLS.cName,DIV.cName ";

            string parameter1 = query;
            string parameter2 = "2";
            Session["param1"] = parameter1;
            Session["param2"] = parameter2;
        }


        Response.Redirect("RptSchoolCumulativeViewer.aspx");
    }



    private void ExportDataTable()
    {
        int Par = 0, i4 = 1;



        String InstId = "", Instmessage = "", Clsmessage = "", ClsId = "", Divmessage = "", DivId = "";

        foreach (TreeNode node in TreVwLst.CheckedNodes)
        {
            if (node.Depth == 0)
            {
                Instmessage += node.Text + ",";
                InstId += node.Value + ",";
            }
            else if (node.Depth == 1)
            {
                Clsmessage += node.Text + ",";
                ClsId += node.Value + ",";
            }
            else if (node.Depth == 2)
            {
                Divmessage += node.Text + ",";
                DivId += node.Value + ",";
            }

        }
        InstId = InstId.TrimEnd(',');
        ClsId = ClsId.TrimEnd(',');
        DivId = DivId.TrimEnd(',');


        string query = "SELECT ";


        if (ChkReligionCat.SelectedValue == "1")
        {

             query += "CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=7  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=7  then 1 end)as Female,count(case when cSex= 'Male' and nReligionId=7  then 1 end)+count(case when cSex= 'Female' and nReligionId=7  then 1 end) total,count(case when cSex= 'Male' and nReligionId=2  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=2  then 1 end)as hFemale,count(case when cSex= 'Male' and nReligionId=2  then 1 end)+count(case when cSex= 'Female' and nReligionId=2  then 1 end) htotal,count(case when cSex= 'Male' and nReligionId=6  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=6  then 1 end)as mFemale,count(case when cSex= 'Male' and nReligionId=6  then 1 end)+count(case when cSex= 'Female' and nReligionId=6  then 1 end) mtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  group by CLS.cName,DIV.cName order by CLS.cName,DIV.cName";

            CType = "1";
        }
        if (ChkReligionCat.SelectedValue == "2")
        {

             query += "CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nCategoryId=5  then 1 end) as GMale,count(case when cSex= 'Female' and nCategoryId=5  then 1 end)as GFemale,count(case when cSex= 'Male' and nCategoryId=5  then 1 end)+count(case when cSex= 'Female' and nCategoryId=5  then 1 end) GTotal,count(case when cSex= 'Male' and nCategoryId=30  then 1 end) as NonResMale,count(case when cSex= 'Female' and nCategoryId=30  then 1 end)as NonResFeMale,count(case when cSex= 'Male' and nCategoryId=30  then 1 end)+count(case when cSex= 'Female' and nCategoryId=30  then 1 end) NonTotal,count(case when cSex= 'Male' and nCategoryId=6  then 1 end) as OBCMale,count(case when cSex= 'Female' and nCategoryId=6  then 1 end)as OBCFemale,count(case when cSex= 'Male' and nCategoryId=6  then 1 end)+count(case when cSex= 'Female' and nCategoryId=6  then 1 end) OBCTotal,count(case when cSex= 'Male' and nCategoryId=15  then 1 end) as OECMale,count(case when cSex= 'Female' and nCategoryId=15  then 1 end)as OECFemale,count(case when cSex= 'Male' and nCategoryId=15  then 1 end)+count(case when cSex= 'Female' and nCategoryId=15  then 1 end) OECTotal,count(case when cSex= 'Male' and nCategoryId=23  then 1 end) as RESMale,count(case when cSex= 'Female' and nCategoryId=23  then 1 end)as RESFemale,count(case when cSex= 'Male' and nCategoryId=23  then 1 end)+count(case when cSex= 'Female' and nCategoryId=23  then 1 end) RESTotal,count(case when cSex= 'Male' and nCategoryId=3  then 1 end) as SCMale,count(case when cSex= 'Female' and nCategoryId=3  then 1 end)as SCFemale,count(case when cSex= 'Male' and nCategoryId=3  then 1 end)+count(case when cSex= 'Female' and nCategoryId=3  then 1 end) SCTotal,count(case when cSex= 'Male' and nCategoryId=11  then 1 end) as STMale,count(case when cSex= 'Female' and nCategoryId=11  then 1 end)as STFemale,count(case when cSex= 'Male' and nCategoryId=11  then 1 end)+count(case when cSex= 'Female' and nCategoryId=11  then 1 end) STTotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  group by CLS.cName,DIV.cName order by CLS.cName,DIV.cName";

            CType = "2";
        }

        DataTable DTCC1 = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
        if (CType == "1")
        {
            string Path = Server.MapPath(Request.ApplicationPath) + "EXCELFILES\\SCHOOL_CUMULATIVE_RELEGION" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
            WriteDataTableToExcel(DTCC1, "TEST", Path, "Excel");

        }
        else if (CType == "2")
        {
            string Path = Server.MapPath(Request.ApplicationPath) + "EXCELFILES\\SCHOOL_CUMULATIVE_CATEGORY" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
            WriteDataTableToExcel(DTCC1, "TEST", Path, "Excel");
           
        }

    }

    public bool WriteDataTableToExcel
(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType)
    {
        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        Microsoft.Office.Interop.Excel.Range excelCellrange;

        try
        {
            //  get Application object.
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;

            // Creation a new Workbook
            excelworkBook = excel.Workbooks.Add(Type.Missing);

            // Workk sheet
            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = worksheetName;

            // loop through each row and add values to our sheet
            int rowcount = 2;

            foreach (DataRow datarow in dataTable.Rows)
            {
                rowcount += 1;
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    // on the first iteration we add the column headers
                   
                    if (rowcount == 3)
                    {
                        excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                    }
                    // Filling the excel file 
                    excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                }

            }
            // excelSheet.Range["A:B"].Group();

            Microsoft.Office.Interop.Excel.Range sortRange = excelSheet.Range["A1:B20"];


            int rowCount1 = excelSheet.UsedRange.Rows.Count;
            int resultColumn1 = 3; // Column C
            int startRow1 = 3; // Starting from the second row (assuming row 1 contains headers)
            double value1, value2, value3, sumM, value4, value5, value6, sumF, value7, value8, value9, sumT, value10, value11, value12, value13, value14, value15, value16, value17, value18, value19, value20, value21;

            if (CType =="1")
            {
                
                for (int row = startRow1; row <= rowCount1+1; row++)
                {

                     value1 = (double)(excelSheet.Cells[row, 3] as Microsoft.Office.Interop.Excel.Range).Value;
                     value2 = (double)(excelSheet.Cells[row, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                     value3 = (double)(excelSheet.Cells[row, 9] as Microsoft.Office.Interop.Excel.Range).Value;
                    // Calculate the sum
                     sumM = value1 + value2 + value3;

                    value4 = (double)(excelSheet.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value;
                    value5 = (double)(excelSheet.Cells[row, 7] as Microsoft.Office.Interop.Excel.Range).Value;
                    value6 = (double)(excelSheet.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                    // Calculate the sum
                    sumF = value4 + value5 + value6;

                    value7 = (double)(excelSheet.Cells[row, 5] as Microsoft.Office.Interop.Excel.Range).Value;
                    value8 = (double)(excelSheet.Cells[row, 8] as Microsoft.Office.Interop.Excel.Range).Value;
                    value9 = (double)(excelSheet.Cells[row, 11] as Microsoft.Office.Interop.Excel.Range).Value;
                    // Calculate the sum
                    sumT = value7 + value8 + value9;

                    // Place the result in the new column (Column C)
                    excelSheet.Cells[row, 12] = sumM;
                    excelSheet.Cells[row, 13] = sumF;
                    excelSheet.Cells[row, 14] = sumT;
                }


                excelSheet.Cells[1, 3] = "CHRISTIAN";
                excelSheet.Range[excelSheet.Cells[1, 3], excelSheet.Cells[1, 5]].Merge();
                excelSheet.Cells[1, 6] = "HINDU";
                excelSheet.Range[excelSheet.Cells[1, 6], excelSheet.Cells[1, 8]].Merge();
                excelSheet.Cells[1, 9] = "MUSLIM";
                excelSheet.Range[excelSheet.Cells[1, 9], excelSheet.Cells[1, 11]].Merge();
                excelSheet.Cells[1, 12] = "All Religion";
                excelSheet.Range[excelSheet.Cells[1, 12], excelSheet.Cells[1, 14]].Merge();

                excelSheet.Cells[2, 1] = "CLASS";
                excelSheet.Cells[2, 2] = "DIVISION";
                excelSheet.Cells[2, 3] = "M";
                excelSheet.Cells[2, 4] = "F";
                excelSheet.Cells[2, 5] = "Total";
                excelSheet.Cells[2, 6] = "M";
                excelSheet.Cells[2, 7] = "F";
                excelSheet.Cells[2, 8] = "Total";
                excelSheet.Cells[2, 9] = "M";
                excelSheet.Cells[2, 10] = "F";
                excelSheet.Cells[2, 11] = "Total";
                excelSheet.Cells[2, 12] = "M";
                excelSheet.Cells[2, 13] = "F";
                excelSheet.Cells[2, 14] = "Total";
                excelSheet.Range["$A$1:$N$500"].Subtotal(1, Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum, new[] { 14, 14 });

               
                Microsoft.Office.Interop.Excel.Range rowRange = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                Microsoft.Office.Interop.Excel.Range rowRange1 = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
                rowRange1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);


                Microsoft.Office.Interop.Excel.Range FirstRow = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
                FirstRow.Font.Bold = true;
                Microsoft.Office.Interop.Excel.Range secondRow = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
                secondRow.Font.Bold = true;



            }
            else if(CType == "2")
            {


                for (int row = startRow1; row <= rowCount1+1; row++)
                {

                    value1 = (double)(excelSheet.Cells[row, 3] as Microsoft.Office.Interop.Excel.Range).Value;
                    value2 = (double)(excelSheet.Cells[row, 6] as Microsoft.Office.Interop.Excel.Range).Value;
                    value3 = (double)(excelSheet.Cells[row, 9] as Microsoft.Office.Interop.Excel.Range).Value;
                    value4 = (double)(excelSheet.Cells[row, 12] as Microsoft.Office.Interop.Excel.Range).Value;
                    value5 = (double)(excelSheet.Cells[row, 15] as Microsoft.Office.Interop.Excel.Range).Value;
                    value6 = (double)(excelSheet.Cells[row, 18] as Microsoft.Office.Interop.Excel.Range).Value;
                    value7 = (double)(excelSheet.Cells[row, 21] as Microsoft.Office.Interop.Excel.Range).Value;

                    // Calculate the sum
                    sumM = value1 + value2 + value3 + value4 + value5 + value6 + value7;

                    value8 = (double)(excelSheet.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value;
                    value9 = (double)(excelSheet.Cells[row, 7] as Microsoft.Office.Interop.Excel.Range).Value;
                    value10 = (double)(excelSheet.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                    value11 = (double)(excelSheet.Cells[row, 12] as Microsoft.Office.Interop.Excel.Range).Value;
                    value12 = (double)(excelSheet.Cells[row, 15] as Microsoft.Office.Interop.Excel.Range).Value;
                    value13 = (double)(excelSheet.Cells[row, 18] as Microsoft.Office.Interop.Excel.Range).Value;
                    value14 = (double)(excelSheet.Cells[row, 21] as Microsoft.Office.Interop.Excel.Range).Value;
                    // Calculate the sum
                    sumF = value8 + value9 + value10 + value11 + value12 + value13 + value14;

                    value15 = (double)(excelSheet.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value;
                    value16 = (double)(excelSheet.Cells[row, 7] as Microsoft.Office.Interop.Excel.Range).Value;
                    value17 = (double)(excelSheet.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                    value18 = (double)(excelSheet.Cells[row, 4] as Microsoft.Office.Interop.Excel.Range).Value;
                    value19 = (double)(excelSheet.Cells[row, 7] as Microsoft.Office.Interop.Excel.Range).Value;
                    value20 = (double)(excelSheet.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                    value21 = (double)(excelSheet.Cells[row, 10] as Microsoft.Office.Interop.Excel.Range).Value;
                    // Calculate the sum
                    sumT = value15 + value16 + value17 + value18 + value19 + value20 + value21;

                    // Place the result in the new column (Column C)
                    excelSheet.Cells[row, 24] = sumM;
                    excelSheet.Cells[row, 25] = sumF;
                    excelSheet.Cells[row, 26] = sumT;
                }



                excelSheet.Cells[1, 3] = "GENERAL";
                excelSheet.Range[excelSheet.Cells[1, 3], excelSheet.Cells[1, 5]].Merge();
                excelSheet.Cells[1, 6] = "NON RESERVATION";
                excelSheet.Range[excelSheet.Cells[1, 6], excelSheet.Cells[1, 8]].Merge();
                excelSheet.Cells[1, 9] = "OBC";
                excelSheet.Range[excelSheet.Cells[1, 9], excelSheet.Cells[1, 11]].Merge();
                excelSheet.Cells[1, 12] = "OEC";
                excelSheet.Range[excelSheet.Cells[1, 12], excelSheet.Cells[1, 14]].Merge();
                excelSheet.Cells[1, 15] = "RESERVATION";
                excelSheet.Range[excelSheet.Cells[1, 15], excelSheet.Cells[1, 17]].Merge();
                excelSheet.Cells[1, 18] = "SC";
                excelSheet.Range[excelSheet.Cells[1, 18], excelSheet.Cells[1, 20]].Merge();
                excelSheet.Cells[1, 21] = "ST";
                excelSheet.Range[excelSheet.Cells[1, 21], excelSheet.Cells[1, 23]].Merge();
                excelSheet.Cells[1, 24] = "All Category";
                excelSheet.Range[excelSheet.Cells[1, 24], excelSheet.Cells[1, 26]].Merge();


                excelSheet.Cells[2, 1] = "CLASS";
                excelSheet.Cells[2, 2] = "DIVISION";
                excelSheet.Cells[2, 3] = "M";
                excelSheet.Cells[2, 4] = "F";
                excelSheet.Cells[2, 5] = "Total";
                excelSheet.Cells[2, 6] = "M";
                excelSheet.Cells[2, 7] = "F";
                excelSheet.Cells[2, 8] = "Total";
                excelSheet.Cells[2, 9] = "M";
                excelSheet.Cells[2, 10] = "F";
                excelSheet.Cells[2, 11] = "Total";
                excelSheet.Cells[2, 12] = "M";
                excelSheet.Cells[2, 13] = "F";
                excelSheet.Cells[2, 14] = "Total";
                excelSheet.Cells[2, 15] = "M";
                excelSheet.Cells[2, 16] = "F";
                excelSheet.Cells[2, 17] = "Total";
                excelSheet.Cells[2, 18] = "M";
                excelSheet.Cells[2, 19] = "F";
                excelSheet.Cells[2, 20] = "Total";
                excelSheet.Cells[2, 21] = "M";
                excelSheet.Cells[2, 22] = "F";
                excelSheet.Cells[2, 23] = "Total";
                excelSheet.Cells[2, 24] = "M";
                excelSheet.Cells[2, 25] = "F";
                excelSheet.Cells[2, 26] = "Total";
                excelSheet.Range["$A$1:$Z$500"].Subtotal(1, Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum, new[] { 26, 26 });
                Microsoft.Office.Interop.Excel.Range rowRange = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
                rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                Microsoft.Office.Interop.Excel.Range rowRange1 = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
                rowRange1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);


                Microsoft.Office.Interop.Excel.Range FirstRow = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
                FirstRow.Font.Bold = true;
                Microsoft.Office.Interop.Excel.Range secondRow = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
                secondRow.Font.Bold = true;

            }


            //now save the workbook and exit Excel
            excelworkBook.SaveAs(saveAsLocation);
           
            excelworkBook.Close();
            excel.Quit();
            return true;
        }
        catch (Exception ex)
        {
            // MessageBox.Show(ex.Message);
            return false;
        }
        finally
        {
            excelSheet = null;
            excelCellrange = null;
            excelworkBook = null;
        }
    }


    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            FnCancel();
        }
        catch
        {
        }
    }



    protected void DownLoadFile(object sender, EventArgs e)
    {
        try
        {
            string sPath = Server.MapPath("exportedfiles\\");

            Response.AppendHeader("Content-Disposition", "attachment; filename=EmployeeDetails.xlsx");
            Response.TransmitFile(sPath + "EmployeeDetails.xlsx");
            Response.End();
        }
        catch (Exception ex) { }
    }


}
