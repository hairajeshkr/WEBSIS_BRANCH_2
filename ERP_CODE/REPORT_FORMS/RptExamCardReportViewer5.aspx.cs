using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.ComponentModel;


public partial class REPORT_FORMS_RptExamCardReportViewer5 : System.Web.UI.Page
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    private dynamic dynamicDataTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        string query = Session["param1"] as string;
        string Stud = Session["param2"] as string;
        //string Template = Session["param3"] as string;
        string Template = "3";
        ReportDocument crystalReport = new ReportDocument();
        if (Template == "1")
        {
            crystalReport.Load(Server.MapPath("~/TRANS_REPORTS/RptExamCardReportFormat4.rpt"));
        }
        else if (Template == "2")
        {
            crystalReport.Load(Server.MapPath("~/TRANS_REPORTS/RptExamCardReportFormat3.rpt"));
        }
        else if (Template == "3")
        {
            crystalReport.Load(Server.MapPath("~/TRANS_REPORTS/RptExamCardReportFormat5.rpt"));
        }

    


        //DataSetDynamic dsCustomers = GetData(query +" "+ Stud, crystalReport);
        DataSetDynamic dsCustomers = GetData(query, crystalReport);

        DataTable tbEmp = new DataTable();
       
        //string query2 = "EXEC ProReportTemplateFormat3 " + Stud ;
        string query2 = "EXEC ProReportTemplateFormat3";
        DataTable DT = (ObjCls.FnGetDataSet(query2) as DataSet).Tables[0];
              
        foreach (DataRow row in DT.Rows)
        {
            DataRow newRow = dsCustomers.Tables[1].NewRow();
            newRow.ItemArray = row.ItemArray;
            dsCustomers.Tables[1].Rows.Add(newRow);
        }

            


        //string query3 = "EXEC ProReportTemplateGrade " + Stud;
        string query3 = "EXEC ProReportTemplateGrade";
        DataTable DT3 = (ObjCls.FnGetDataSet(query3) as DataSet).Tables[0];

        foreach (DataRow row in DT3.Rows)
        {
            DataRow newRow = dsCustomers.Tables[2].NewRow();
            newRow.ItemArray = row.ItemArray;
            dsCustomers.Tables[2].Rows.Add(newRow);
        }





        //dsCustomers.Tables.Add(tbEmp.Copy());

        crystalReport.SetDataSource(dsCustomers);
        //crystalReport.SetDataSource(tbEmp);

        CrystalReportViewer1.ReportSource = crystalReport;
        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Campus");
        CrystalReportViewer1.RefreshReport();
        CrystalReportViewer1.Visible = true;
        CrystalReportViewer1.DataBind();


    }

    

    private DataSetDynamic GetData(string query, ReportDocument crystalReport)
    {


        DataSetDynamic dsCustomers = new DataSetDynamic();

        DataTable DT = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
        foreach (DataRow row in DT.Rows)
        {
            DataRow newRow = dsCustomers.Tables[0].NewRow();
            newRow.ItemArray = row.ItemArray;
            dsCustomers.Tables[0].Rows.Add(newRow);
        }

        return dsCustomers;

    }
    
}