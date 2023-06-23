using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports_FrmVchr : System.Web.UI.Page
{
    CrystalDecisions.CrystalReports.Engine.ReportDocument MyReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
    ClsReportGeneral ObjRpt = new ClsReportGeneral();
    DataTable dtReport, dtSubReport;
    DataSet dsReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string _strCompanyName = "", _strBranchName = "", _strFaYear = "", _strUserName = "", _strAcName = "";
            string _strRptHeaderName = Request.QueryString["RPT_HDR"].ToString();
            string _strRptFileName = Request.QueryString["RPT_FILE"].ToString();
            string _strRptClassName = Request.QueryString["RPT_CLS"].ToString();
            string _strRptProcedureName = Request.QueryString["RPT_PROC"].ToString();
            string _strRptType = Request.QueryString["RPT_TYPE"].ToString();
            string _strPeriod = "";

            ObjRpt.CompanyId = ObjRpt.FnIsNumeric(Request.QueryString["CID"].ToString());
            ObjRpt.BranchId = ObjRpt.FnIsNumeric(Request.QueryString["BID"].ToString());
            ObjRpt.FaId = ObjRpt.FnIsNumeric(Request.QueryString["FAID"].ToString());
            ObjRpt.UserId = ObjRpt.FnIsNumeric(Request.QueryString["UID"].ToString());
            ObjRpt.FnGetCompanyDetails(ref _strCompanyName, ref _strBranchName, ref _strFaYear, ref _strUserName, ref _strAcName);


            string[] _RptSourc = _strRptProcedureName.Split(',');
            _strRptProcedureName = _RptSourc[0];

            switch (_strRptClassName.ToString())
            {
                case "LIBREPORT.ClsVoucherReport":
                    ClsVoucherReport ObjReport = new ClsVoucherReport();//ObjReport=Session["RPT"] as ClsVoucherReport;
            
                    ObjReport.RefNo = ObjReport.FnIsNumeric(Request.QueryString["REFNO"].ToString());
                    ObjReport.ID = ObjReport.FnIsNumeric(Request.QueryString["ID"].ToString());

                    ObjReport.CompanyId = ObjReport.FnIsNumeric(Request.QueryString["CID"].ToString());
                    ObjReport.BranchId = ObjReport.FnIsNumeric(Request.QueryString["BID"].ToString());
                    ObjReport.FaId = ObjReport.FnIsNumeric(Request.QueryString["FAID"].ToString());
                    ObjReport.UserId = ObjReport.FnIsNumeric(Request.QueryString["UID"].ToString());
                    ObjReport.TType = Request.QueryString["TTYPE"].ToString();
                    ObjReport.ProcedureName = _strRptProcedureName;
                    dtReport = ObjReport.ShowRecord() as DataTable;
                    for (int iRpt = 1; iRpt <= _RptSourc.Length - 1; iRpt++)
                    {
                        ObjReport.ProcedureName = _RptSourc[iRpt];
                        dtSubReport = ObjReport.ShowRecord() as DataTable;
                    }
                    break;
                case "LIBREPORT.ClsDetailedReport":
                    ClsDetailedReport ObjDtReport = new ClsDetailedReport();
                    ObjDtReport = Session["RPT"] as ClsDetailedReport;
                    ObjDtReport.ProcedureName = _strRptProcedureName;
                    dsReport = ObjDtReport.ShowRecord() as DataSet;
                    dtReport = dsReport.Tables[0];
                    _strPeriod = "PERIOD :-  " + ObjDtReport.FromDate.ToString("dd/MMM/yyyy") + " TO " + ObjDtReport.ToDate.ToString("dd/MMM/yyyy");
                    break;
                case "LIBREPORT.ClsFinReport":
                    ClsFinReport ObjFinReport = new ClsFinReport();
                    ObjFinReport = Session["RPT"] as ClsFinReport;
                    ObjFinReport.ProcedureName = _strRptProcedureName;
                    dsReport = ObjFinReport.ShowRecord() as DataSet;
                    dtReport = dsReport.Tables[0];
                    _strPeriod = "PERIOD :-  " + ObjFinReport.FromDate.ToString("dd/MMM/yyyy") + " TO " + ObjFinReport.ToDate.ToString("dd/MMM/yyyy");
                    break;
                case "LIBREPORT.ClsHrReport":
                    ClsHrReport ObjHrReport = new ClsHrReport();
                    ObjHrReport = Session["RPT"] as ClsHrReport;
                    ObjHrReport.ProcedureName = _strRptProcedureName;
                    dsReport = ObjHrReport.ShowRecord() as DataSet;
                    dtReport = dsReport.Tables[0];
                    _strPeriod = "PERIOD :-  " + ObjHrReport.FromDate.ToString("dd/MMM/yyyy") + " TO " + ObjHrReport.ToDate.ToString("dd/MMM/yyyy");
                    break;
                case "LIBREPORT.ClsServiceReport":
                    ClsServiceReport ObjSrReport = new ClsServiceReport();
                    ObjSrReport = Session["RPT"] as ClsServiceReport;
                    ObjSrReport.ProcedureName = _strRptProcedureName;
                    dsReport = ObjSrReport.ShowRecord() as DataSet;
                    dtReport = dsReport.Tables[0];
                    _strPeriod = "PERIOD :-  " + ObjSrReport.FromDate.ToString("dd/MMM/yyyy") + " TO " + ObjSrReport.ToDate.ToString("dd/MMM/yyyy");
                    break;
            }
            if (dtReport.Rows.Count > 0)
            {
                Response.Write(_strRptFileName);
                MyReport.Load(Server.MapPath(_strRptFileName));
                MyReport.SetDataSource(dtReport);
                if (_RptSourc.Length > 1)
                {
                    MyReport.Subreports[0].SetDataSource(dtSubReport);
                }
                if (Request.QueryString["TTYPE"].Equals("PL"))// PROFT & LOOSS
                {
                    double dGrosPrft = 0, dGrosLos = 0, dNetPrft = 0, dNetLos = 0;
                    DataView dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=0";
                    MyReport.Subreports["RptDrExp"].SetDataSource(dwPl.ToTable());

                    dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=1";
                    MyReport.Subreports["RptDrInc"].SetDataSource(dwPl.ToTable());
                    
                    dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=2";
                    MyReport.Subreports["RptIndExp"].SetDataSource(dwPl.ToTable());

                    dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=3";
                    MyReport.Subreports["RptIndInc"].SetDataSource(dwPl.ToTable());

                    if (dtReport.Rows.Count > 0)
                    {
                        dGrosPrft = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(EXPENSE)", " TType IN('DR-EXP','GRP-VAL')")));
                        dGrosLos = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(INCOME)", " TType IN('DR-INC','GRL-VAL')")));
                        dNetPrft = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(EXPENSE)", " TType IN('INDR-EXP','NETP-VAL')")));
                        dNetLos = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(INCOME)", " TType IN('INDR-INC','NETL-VAL')")));
                    }
                    MyReport.DataDefinition.FormulaFields["GrsP"].Text = "'" + dGrosPrft.ToString() + "'";
                    MyReport.DataDefinition.FormulaFields["GrsL"].Text = "'" + dGrosLos.ToString() + "'";
                    MyReport.DataDefinition.FormulaFields["NetP"].Text = "'" + dNetPrft.ToString() + "'";
                    MyReport.DataDefinition.FormulaFields["NetL"].Text = "'" + dNetLos.ToString() + "'";
                }
                if (Request.QueryString["TTYPE"].Equals("BAL"))// BALANCE SHEET
                {
                    double dPrft = 0, dLos = 0;
                    DataView dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=0";
                    MyReport.Subreports["RptDrExp"].SetDataSource(dwPl.ToTable());

                    dwPl = new DataView(dtReport);
                    dwPl.RowFilter = "OrderNo=1";
                    MyReport.Subreports["RptDrInc"].SetDataSource(dwPl.ToTable());
                    if (dtReport.Rows.Count > 0)
                    {
                        dPrft = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(EXPENSE)", " OrderNo=0")), 2);
                        dLos = Math.Round(ObjRpt.FnIsDouble(dtReport.Compute("SUM(INCOME)", " OrderNo=1")), 2);
                    }
                    MyReport.DataDefinition.FormulaFields["GrsP"].Text = "'" + dPrft.ToString() + "'";
                    MyReport.DataDefinition.FormulaFields["GrsL"].Text = "'" + dLos.ToString() + "'";
                }
                if (Request.QueryString["TTYPE"].Equals("TRIAL"))
                {
                    _strPeriod = dtReport.Rows[0]["Period"].ToString();
                }
                MyReport.DataDefinition.FormulaFields["Company"].Text = "'" + _strCompanyName + "'";
                MyReport.DataDefinition.FormulaFields["Branch"].Text = "'" + _strBranchName + "'";
                MyReport.DataDefinition.FormulaFields["FaYear"].Text = "'" + _strFaYear + "'";
                MyReport.DataDefinition.FormulaFields["HeaderName"].Text = "'" + _strRptHeaderName + "'";
                MyReport.DataDefinition.FormulaFields["UserName"].Text = "'" + _strUserName + "'";
                MyReport.DataDefinition.FormulaFields["Period"].Text = "'" + _strPeriod + "'";

                //========================= Generate  Pdf File ==================
                ReportDocument repDoc1 = MyReport; // Stop buffering the response || _strRptClassName.ToString().Equals("LIBREPORT.ClsDetailedReport")
                Response.Buffer = false;// Clear the response content and headers
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    // Export the Report to Response stream in PDF format and file name Customers
                    repDoc1.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Voucher");
                    // There are other format options available such as Word, Excel, CVS, and HTML in the ExportFormatType Enum given by crystal reports
                }
                catch (Exception ex1)
                {
                    string str1 = ex1.Message;
                }
                MyReport.Close();
                MyReport.Dispose();
            }
            else
            {
                Response.Redirect("../RptNone.htm");
                LblInfo.Visible = true;
                Session["REPORT"] = null;
                if (MyReport != null)
                {
                    MyReport.Close();
                    MyReport.Dispose();
                }
            }
           /* if (_strRptClassName.ToString() != "LIBREPORT.ClsVoucherReport")
            {
                CrystlRptViewer.ReportSource = Session["REPORT"] as CrystalDecisions.CrystalReports.Engine.ReportDocument;
            }*/
            //FnExportExcelSheet(dtReport);
        }
        catch (Exception ex)
        {
            if (MyReport != null)
            {
                MyReport.Close();
                MyReport.Dispose();
            }
            LblInfo.Visible = true;
            LblInfo.Text = ex.Message ;
        }
    }
    //=================================================================================== Excel Sheet

    private void FnExportExcelSheet(DataTable PrmDtVal)
    {
        try
        {
            DataTable dt1 = PrmDtVal;
            if (dt1 == null)
            {
                throw new Exception("No Records to Export");
            }
            string Path = Server.MapPath(Request.ApplicationPath) + "\\\\myexcelfile_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
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
}
