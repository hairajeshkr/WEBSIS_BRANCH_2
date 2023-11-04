using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class REPORT_FORMS_RptStudent : ClsPageEvents, IPageInterFace
{
    ClsRegistrationStudent ObjCls = new ClsRegistrationStudent();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                FnGrpClassDivChkFill();
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


    public void FnGrpClassDivChkFill()
    {

        DataTable DdlReligionDT = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory where cttype='RELGN'") as DataSet).Tables[0];
        DdlReligion.DataSource = DdlReligionDT;
        DdlReligion.DataValueField = "nId";
        DdlReligion.DataTextField = "cName";
        DdlReligion.DataBind();
        DdlReligion.Items.Insert(0, new ListItem("---Select---", "0"));

    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsRegistrationStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
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
                   

                    //FnExportExcelSheet(DTCC1);
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
                    Response.Redirect("RptStudentViewer.aspx");
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
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
        bool isSelected = ChkSelectColumns.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
        if (!isSelected)
        {
            ChkSelectColumns.Items[0].Selected = true;
        }
        foreach (ListItem item in ChkSelectColumns.Items)
        {
            if (item.Selected)
            {
                query += item.Value + ",";

                isSelected = true;
                if (item.Value == "nStudentId")
                {
                    Par = i4;
                }
                i4++;
            }
        }
        query = query.Substring(0, query.Length - 1);

        if (DdlFilter.SelectedValue == "2")
        {

            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.nReligionId=" + DdlReligion.SelectedValue + " order by STDR.cName asc";


        }
        else if (DdlFilter.SelectedValue == "1")
        {
            DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
            DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' order by STDR.cName asc";

        }
        else
        {
            query += " FROM TblRegistrationStudent";
        }

        DataTable DTCC1 = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
        string Path = Server.MapPath(Request.ApplicationPath) + "EXCELFILES\\STUDENT_FILTER" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";

        WriteDataTableToExcel(DTCC1, "TEST", Path, "Excel");
    }

    private void FnExportExcelSheet(DataTable PrmDtVal)
    {
        try
        {
            DataTable dt1 = PrmDtVal;
            if (dt1 == null)
            {
                throw new Exception("No Records to Export");
            }
            string Path = Server.MapPath(Request.ApplicationPath) + "\\EXCELFILES\\myexcelfile_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
            FileInfo FI = new FileInfo(Path);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = dt1;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            string directory = Path.Substring(0, Path.LastIndexOf("\\"));// GetDirectory(Path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            System.IO.StreamWriter vw = new System.IO.StreamWriter(Path, true);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            vw.Close();
            
            WriteAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            
        }
    }
    public static void WriteAttachment(string FileName, string FileType, string content)
    {
        HttpResponse Response = System.Web.HttpContext.Current.Response;
        Response.ClearHeaders();
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
        Response.ContentType = FileType;
        Response.Write(content);
        Response.End();

    }




    protected void DdlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DdlFilter.SelectedValue == "1")
        {
            lblFromdate.Enabled = true;
            lblduedate.Enabled = true;
            CtrlFromDate.EnableViewState = true;
            CtrlDueDate.EnableViewState = true;

            lblreligion.Enabled = false;
            DdlReligion.Enabled = false;
        }
        else if (DdlFilter.SelectedValue == "2")
        {

            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState = false;
            CtrlDueDate.EnableViewState = false;

            lblreligion.Enabled = false;
            DdlReligion.Enabled = true;
        }
        else if (DdlFilter.SelectedValue == "3")
        {
            lblreligion.Enabled = true;
            DdlReligion.Enabled = true;



            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState = false;
            CtrlDueDate.EnableViewState = false;


        }

    }



    protected void ChkSelectAllFields_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in ChkSelectColumns.Items)
        {
            item.Selected = true;
            item.Enabled = true;
        }
    }

    private void BindReport()
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
        bool isSelected = ChkSelectColumns.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
        if (!isSelected)
        {
            ChkSelectColumns.Items[0].Selected = true;
        }
        foreach (ListItem item in ChkSelectColumns.Items)
        {
            if (item.Selected)
            {
                query += item.Value + ",";
               
                isSelected = true;
                if (item.Value == "nStudentId")
                {
                    Par = i4;
                }
                i4++;
            }
        }
        query = query.Substring(0, query.Length - 1);

        if (DdlFilter.SelectedValue == "2")
        {

            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.nReligionId=" + DdlReligion.SelectedValue + " order by STDR.cName asc";


        }
        else if (DdlFilter.SelectedValue == "1")
        {
            DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
            DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + ClsId + ") and STDA.nDivisionId in (" + DivId + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' order by STDR.cName asc";

        }
        else
        {
            query += " FROM TblRegistrationStudent";
        }




        string parameter1 = query;
        string parameter2 = Par.ToString();
        Session["param1"] = parameter1;
        Session["param2"] = parameter2;


    }

    private DataSetDynamic GetData(string query, ReportDocument crystalReport)
    {

        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True"))
        {
            DataSetDynamic dsCustomers = new DataSetDynamic();
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                //Get the List of all TextObjects in Section2.
                List<TextObject> textObjects = crystalReport.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();

                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (sdr.FieldCount > i)
                    {
                        textObjects[i].Text = sdr.GetName(i).Substring(1);

                    }

                }


                //Load all the data rows in the Dataset.
                while (sdr.Read())
                {
                    DataRow dr = dsCustomers.Tables[0].Rows.Add();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        dr[i] = sdr[i];
                    }
                }
            }
            con.Close();
            return dsCustomers;

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
            int rowcount = 1;

            foreach (DataRow datarow in dataTable.Rows)
            {
                rowcount += 1;
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    // on the first iteration we add the column headers
                    if (rowcount == 3)
                    {
                        //excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                        string query11 = dataTable.Columns[i - 1].ColumnName;
                        excelSheet.Cells[2, i] = query11.Substring(1);
                    }
                    // Filling the excel file 
                    excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                }
            }


            excelSheet.Cells[1, 1] = "STUDENT FILTER";
            Microsoft.Office.Interop.Excel.Range rowRange = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
            rowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            Microsoft.Office.Interop.Excel.Range rowRange1 = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
            rowRange1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            Microsoft.Office.Interop.Excel.Range FirstRow = excelSheet.Rows[1] as Microsoft.Office.Interop.Excel.Range;
            FirstRow.Font.Bold = true;
            Microsoft.Office.Interop.Excel.Range secondRow = excelSheet.Rows[2] as Microsoft.Office.Interop.Excel.Range;
            secondRow.Font.Bold = true;
            //now save the workbook and exit Excel
            excelworkBook.SaveAs(saveAsLocation);
           // excelworkBook.RenderControl(new HtmlTextWriter(Response.Output));
            //HtmlTextWriter ;
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






}