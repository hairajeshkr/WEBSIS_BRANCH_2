using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class REPORT_FORMS_RptStudentDtls : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    DataTable DTMale = new DataTable();
    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(DTInstitute, icount, null);
                FnDdlReligionFill();
            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void FnDdlReligionFill()
    {

        DataTable DdlReligionDT = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory where cttype='RELGN'") as DataSet).Tables[0];
        DdlReligion.DataSource = DdlReligionDT;
        DdlReligion.DataValueField = "nId";
        DdlReligion.DataTextField = "cName";
        DdlReligion.DataBind();
        DdlReligion.Items.Insert(0, new ListItem("---Select---", "0"));

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
        FnFindRecord(ObjCls);
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


   

    private void BindReport()
    {
        string selectedItemsC = "", selectedclass = "", selectedItemsD="";

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

        DataTable DTList = new DataTable();



        string query = "SELECT";

        if (DdlFilter.SelectedValue == "2")
        {

            query += " CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  group by CLS.cName,DIV.cName";


        }
        else if (DdlFilter.SelectedValue == "1")
        {
            DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
            DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
            query += " CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' group by CLS.cName,DIV.cName";

        }
        else
        {
            query += "  CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId";
        }




        string parameter1 = query;
        string parameter2 = selectedItemsC;
        Session["param1"] = parameter1;
        Session["param2"] = parameter2;

        Response.Redirect("RptCampusStatisticsViewer.aspx");


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
        
        if (DdlFilter.SelectedValue == "2")
        {

            query += " CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female,count(case when cSex= 'Male' then 1 end)+count(case when cSex= 'Female' then 1 end) [Sub Total] FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ")  and STDR.nReligionId=" + DdlReligion.SelectedValue + " group by CLS.cName,DIV.cName order by CLS.cName,DIV.cName";


        }
        else if (DdlFilter.SelectedValue == "1")
        {
            DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
            DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
            query += " CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female, count(case when cSex= 'Male' then 1 end)+count(case when cSex= 'Female' then 1 end) [Sub Total]  FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' group by CLS.cName,DIV.cName order by CLS.cName,DIV.cName";

        }
        else
        {
            query += "  CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female , count(case when cSex= 'Male' then 1 end)+count(case when cSex= 'Female' then 1 end) [Sub Total]  FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId order by CLS.cName,DIV.cName";
        }

        DataTable DTCC1 = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
        string Path = Server.MapPath(Request.ApplicationPath) + "EXCELFILES\\CAMPUS_STATISTICS" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";

        WriteDataTableToExcel(DTCC1, "TEST", Path, "Excel");
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
            int rowcount = 1;

            foreach (DataRow datarow in dataTable.Rows)
            {
                rowcount += 1;
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    // on the first iteration we add the column headers
                      if (rowcount == 2)
                       {
                        excelSheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                    }
                    // Filling the excel file 
                    excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                }
                
            }

            Microsoft.Office.Interop.Excel.Range sortRange = excelSheet.Range["A1:B20"];


            excelSheet.Cells[1, 1] = "CLASS";
            excelSheet.Cells[1, 2] = "DIVISION";
            excelSheet.Cells[1, 3] = "MALE";
            excelSheet.Cells[1, 4] = "FEMALE";
            excelSheet.Cells[1, 5] = "SUB TOTAL";

            Microsoft.Office.Interop.Excel.Range rowRange = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
            rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

            Microsoft.Office.Interop.Excel.Range FirstRow = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
            FirstRow.Font.Bold = true;

            excelSheet.Range["$A$1:$E$20"].Subtotal(1, Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum, new[] { 5, 5 });
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


}