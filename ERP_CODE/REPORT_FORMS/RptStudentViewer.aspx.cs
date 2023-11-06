using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class REPORT_FORMS_RptStudentViewer : System.Web.UI.Page
{
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {

        string query = Session["param1"] as string;
        string Par = Session["param2"] as string;
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/TRANS_REPORTS/rptDynamicColumn.rpt"));
        DataSetDynamic dsCustomers = GetData(query, crystalReport);
        crystalReport.SetDataSource(dsCustomers);
        CrystalReportViewer1.ReportSource = crystalReport;
        crystalReport.SetParameterValue("Paragroup", Par);
        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "student");
        CrystalReportViewer1.Visible = true;
    }


    private DataSetDynamic GetData(string query, ReportDocument crystalReport)
    {

        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;User ID=hrm;Password=hrm"))
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
}