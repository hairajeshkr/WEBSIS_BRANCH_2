using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class STUDENT_StudentAsgn : ClsPageEvents, IPageInterFace
{
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    ClsStudentAssign ObjCls = new ClsStudentAssign();


    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();              
            }
            CtrlGrdClass.ParentControl = CtrlGrdGroup.IdControl;
            CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
            // CtrlGrdDivision_Srch.ParentControl = CtrlGrdClass_Srch.IdControl;
            DataTable ClsTGFI = (ObjCls.FnGetDataSet("SELECT * FROM TblRegistrationStudent order by cName asc") as DataSet).Tables[0];
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
        ObjCls = new ClsStudentAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue);
    }
   
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";
        CtrlGrdDivision.SelectedValue = "0";
        CtrlGrdDivision.SelectedText = "";
        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        FnFocus(CtrlGrdClass.ControlTextBox);
        TabContainer1.ActiveTabIndex = 0;
    }
    
    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");

        //ObjLst.FnGetDivisionList(DdlToDivision, "", ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue), ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue));
        TabContainer1.ActiveTabIndex = 0;
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
            GrdVwRecords.SelectedIndex = -1;

           
        
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
                    FnPopUpAlert(ObjCls.FnAlertMessage("Record saved successfully"));
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
                   // FnCancel_Srch();
                    break;
                case "PRINT":
                    //FnAssignProperty_Srch();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                DropDownList DdlSaltn = (DropDownList)e.Row.FindControl("DdlSaltn");
                DropDownList DdlSaltnFthr = (DropDownList)e.Row.FindControl("DdlSaltnFthr");
                DropDownList DdlSaltnMthr = (DropDownList)e.Row.FindControl("DdlSaltnMthr");
                DropDownList DdlSaltnGurdn = (DropDownList)e.Row.FindControl("DdlSaltnGurdn");

                TextBox StudName = ((TextBox)e.Row.FindControl("TxtName"));
                HiddenField HdnStuId = (HiddenField)e.Row.FindControl("Hdnstid");
                var StuId = CtrlGrdStudent.SelectedValue;
                var ClsId = CtrlGrdClass.SelectedValue;
                var DivId = CtrlGrdDivision.SelectedValue;


                DataTable ClsTGFI = (ObjCls.FnGetDataSet("select cFatherName as FatherName,cMotherName as MotherName,cGuardianName as GuardianName from TblRegistrationStudent where nClassId="+ClsId+"and nDivisionId="+DivId) as DataSet).Tables[0];

                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {

                    FnSetDropDownValue(DdlSaltn, ObjCls.SaluationId.ToString());
                    FnSetDropDownValue(DdlSaltnFthr, ObjCls.FatherSaluationId.ToString());
                    FnSetDropDownValue(DdlSaltnMthr, ObjCls.MotherSaluationId.ToString());
                    FnSetDropDownValue(DdlSaltnGurdn, ObjCls.GuardianSaluationId.ToString());
                }
                else
                {
                    //ObjLst.FnNullDropDownList(DdlDiv);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }

    }
} 