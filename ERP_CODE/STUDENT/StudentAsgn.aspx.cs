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

    HiddenField HdnId = null;
    TextBox TxtName = null, TxtFName = null, TxtMName = null, TxtGName = null, TxtAdmNo = null, TxtStuId = null, TxtStMobNo = null, TxtFthrMobNo = null, TxtMthrMobNo = null, TxtGrdMobNo = null;

    int iCnt = 1;

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
        //ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        //ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.InstituteId = 4;
            //ObjCls.FnIsNumeric(CtrlGrdGroup.SelectedValue);
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue);
        //ObjCls.StudentId = ObjCls.FnIsNumeric(CtrlGrdStudent.SelectedValue);
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
      
                             FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                DropDownList DdlSaltn = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSaltn");
                                DropDownList DdlSaltnFthr = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSaltnFthr");
                                DropDownList DdlSaltnMthr = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSaltnMthr");
                                DropDownList DdlSaltnGurdn = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlSaltnGurdn");

                                HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnAdId");
                                TxtName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtName");
                                TxtFName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtFName");
                                TxtMName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMName");
                                TxtGName = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGName");
                                TxtAdmNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtAdmNo");
                                TxtStuId = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtStuId");
                                TxtStMobNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtStMobNo");
                                TxtFthrMobNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtFthrMobNo");
                                TxtMthrMobNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMthrMobNo");
                                TxtGrdMobNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtGrdMobNo");

                                ObjCls.SaluationId = ObjCls.FnIsNumeric(DdlSaltn.SelectedValue);
                                ObjCls.FatherSaluationId= ObjCls.FnIsNumeric(DdlSaltnFthr.SelectedValue);
                                ObjCls.MotherSaluationId= ObjCls.FnIsNumeric(DdlSaltnMthr.SelectedValue);
                                ObjCls.GuardianSaluationId= ObjCls.FnIsNumeric(DdlSaltnGurdn.SelectedValue);

                                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnId.Value);
                                ObjCls.Name = TxtName.Text.Trim();
                                ObjCls.FatherName = TxtFName.Text.Trim();
                                ObjCls.MotherName = TxtMName.Text.Trim();
                                ObjCls.GuardianName = TxtGName.Text.Trim();
                                ObjCls.AdmissionNo = TxtAdmNo.Text.Trim();
                                ObjCls.MobNo = TxtStMobNo.Text.Trim();
                                ObjCls.FatherMobNo = TxtFthrMobNo.Text.Trim();
                                ObjCls.MotherMobNo = TxtMthrMobNo.Text.Trim();
                                ObjCls.GuardianMobNo = TxtGrdMobNo.Text.Trim();
                                ObjCls.ID= ObjCls.FnIsNumeric(HdnId.Value);

                        _strMsg = ObjCls.UpdateRecord() as string;
                        iCnt = 1;

                            }
                    if (iCnt > 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage(" Records Saved"));
                    }
                    FnCancel();
                            
                    
                    break; ;
                case "FIND":
                    FnFindRecord();
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
    {    try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {


                      DropDownList DdlSaltn = (DropDownList)e.Row.FindControl("DdlSaltn");
                      DropDownList DdlSaltnFthr = (DropDownList)e.Row.FindControl("DdlSaltnFthr");
                      DropDownList DdlSaltnMthr = (DropDownList)e.Row.FindControl("DdlSaltnMthr");
                      DropDownList DdlSaltnGurdn = (DropDownList)e.Row.FindControl("DdlSaltnGurdn");

                      ViewState["SALT"] = ObjLst.FnGetSalutationList() as DataTable;
                      FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltn, "");
                      FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltnFthr, "");
                      FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltnMthr, "");
                      FnBindingDropDownList(ObjLst, ViewState["SALT"] as DataTable, DdlSaltnGurdn, "");

                      FnSetDropDownValue(DdlSaltn, ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "SaluationId").ToString()).ToString());
                      FnSetDropDownValue(DdlSaltnFthr, ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "FatherSaluationId").ToString()).ToString());
                      FnSetDropDownValue(DdlSaltnMthr, ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "MotherSaluationId").ToString()).ToString());
                      FnSetDropDownValue(DdlSaltnGurdn, ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "GuardianSaluationId").ToString()).ToString());

                
                }

            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }

    }
   


} 