using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_RollNoAsgn : ClsPageEvents, IPageInterFace
{
    ClsStudentRollNoAssign ObjCls = new ClsStudentRollNoAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            if (!IsPostBack)
            {
                ObjLst.FnGetLanguageList(DdlLanguage, "---Sort by Language---");
                FnInitializeForm();
            }
            CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
            CtrlGrdDivision_Srch.ParentControl = CtrlGrdClass_Srch.IdControl;
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
        ObjCls = new ClsStudentRollNoAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        FnGridViewBinding("SRCH");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue);
        ObjCls.SortByName = RadBtnName.SelectedValue.ToString();
        ObjCls.SortByLanguage = DdlLanguage.SelectedValue.ToString();
        ObjCls.SortBySex = RadBtnGender.SelectedValue.ToString();
    }
    public void FnAssignProperty_Srch()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass_Srch.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision_Srch.SelectedValue);
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
        RadBtnName.SelectedIndex = 0;
        RadBtnGender.SelectedIndex = 0;
        DdlLanguage.SelectedIndex = 0;
        txtStartingRollNo.Text = "";
        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnCancel_Srch()
    {
        CtrlGrdClass_Srch.SelectedValue = "0";
        CtrlGrdClass_Srch.SelectedText = "";
        CtrlGrdDivision_Srch.SelectedValue = "0";
        CtrlGrdDivision_Srch.SelectedText = "";
        FnFocus(CtrlGrdClass_Srch.ControlTextBox);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("SRCH");
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
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
        if (PrmFlag == "SRCH")
        {
            GrdVwRecords_Srch.DataSource = ViewState["DT_CHILD"] as DataTable;
            GrdVwRecords_Srch.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords_Srch.DataBind();
            GrdVwRecords_Srch.SelectedIndex = -1;
        }
        else
        {
            GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
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
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            int iCnt = 0;
                            TextBox TxtRollNo = null;
                            HiddenField HdnStudentId = null, HdnAdId = null;
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnStudentId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnStudentId");
                                HdnAdId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnAdId");
                                TxtRollNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRollNo");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnAdId.Value);
                                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnStudentId.Value);
                                ObjCls.RollNo = ObjCls.FnIsNumeric(TxtRollNo.Text);
                                _strMsg = ObjCls.UpdateRecord() as string;
                                iCnt = iCnt + 1;
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Roll No Assigned"));
                            }
                            break;
                    }
                    break;
                case "ASGN":
                    FnAssignProperty();
                    FnSearchRecord(ObjCls);
                    FnGridViewBinding("");
                    AssignRollNumbers();
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
                    FnCancel_Srch();
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

    private void AssignRollNumbers()
    {
        int startingRollNo;
        TextBox TxtRollNo = null;
        // Parse the input starting roll number
        if (int.TryParse(txtStartingRollNo.Text, out startingRollNo))
        {
            // Loop through each row in the GridView and update the Roll No
            for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
            {
            
                TxtRollNo = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtRollNo");
               
                TxtRollNo.Text= (startingRollNo + i).ToString();
            }
        }
        else
        {
            // Handle invalid input
            Response.Write("<script>alert('Please enter a valid starting roll number');</script>");
        }
    }

}