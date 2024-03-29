using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_FORMS_RptExam1 : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            
            if (!IsPostBack)
            {
                //FnInitializeForm();
                // DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];

                //ObjLst.FnGetStudentList(CtrlGrdStudent, "");

            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void FnAssignProperty()
    {
        throw new NotImplementedException();
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        throw new NotImplementedException();
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        throw new NotImplementedException();
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
                    //ExportDataTable();
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "FIND_SRCH":
                    //FnFindRecord_Srch();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "CLEAR_SRCH":
                    //FnCancel_Srch();
                    break;
                case "PRINT":
                   // FnAssignProperty_Srch();
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
        string selectedItemsC = "", selectedclass = "";
         
            string query = "EXEC ProReportTemplateFormat2";
        
        string parameter1 = query;
            string parameter2 = CtrlGrdStudent.SelectedValue.ToString();
        string parameter3 = CtrlGrdTemplate.SelectedValue.ToString();
            Session["param1"] = parameter1;
            Session["param2"] = parameter2;
            Session["param3"] = parameter3;

        //Response.Redirect("RptExamCardReportViewer.aspx");
        // Response.Redirect("RptExamCardReportViewer2.aspx");
        //Response.Redirect("RptExamCardReportViewer3.aspx");
        // Response.Redirect("RptExamCardReportViewer4.aspx");
        Response.Redirect("RptExamCardReportViewer5.aspx");
    }

}