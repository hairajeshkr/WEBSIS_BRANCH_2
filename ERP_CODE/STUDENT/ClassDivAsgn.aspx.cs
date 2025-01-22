using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class STUDENT_ClassAssign : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
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
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue);
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
        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        FnFocus(CtrlGrdClass.ControlTextBox);
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
        FnGetDivisionList();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");

        //ObjLst.FnGetDivisionList(DdlToDivision, "", ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue), ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue));
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
        if (PrmFlag == "SRCH")
        {
            GrdVwRecords_Srch.DataSource = ViewState["DT_CHILD"] as DataTable;
            GrdVwRecords_Srch.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords_Srch.DataBind();
            GrdVwRecords_Srch.SelectedIndex = -1;
            FnGetDivisionSummary_Srch(ViewState["DT_CHILD"] as DataTable);
        }
        else
        {
            GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;

            GrdVwSummary.DataSource = ViewState["DIV"] as DataTable;
            GrdVwSummary.DataBind();
        }
    }
    public void FnGetDivisionList()
    {
        ViewState["DIV"]= ObjLst.FnGetDivisionList(ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue), 0);
    }
     public void FnGetDivisionSummary(DataTable PrmDtList)
    {
        string[] strList = new string[2];
        strList.SetValue("DivisionId", 0);
        strList.SetValue("DivisionName", 1);

        string i_sGroupByColumn = "DivisionName";
        DataView dvLst = new DataView(PrmDtList);
        //DataTable dtGroup = dvLst.ToTable(true, new string[] { "DivisionName" });
        DataTable dtGroup = dvLst.ToTable(true, strList);
        dtGroup.Columns.Add("Count", typeof(int));
        foreach (DataRow dr in dtGroup.Rows)
        {
            dr["Count"] = PrmDtList.Compute("Count(ID)", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
        }
        dvLst = new DataView(dtGroup);
        dvLst.Sort = " DivisionName ASC";
        GrdVwSummary.DataSource = dvLst.ToTable();
        GrdVwSummary.DataBind();
    }
    public void FnGetDivisionSummary_Srch(DataTable PrmDtList)
    {
        string[] strList = new string[2];
        strList.SetValue("DivisionId", 0);
        strList.SetValue("DivisionName", 1);

        string i_sGroupByColumn = "DivisionName";
        DataView dvLst = new DataView(PrmDtList);
        //DataTable dtGroup = dvLst.ToTable(true, new string[] { "DivisionName" });
        DataTable dtGroup = dvLst.ToTable(true, strList);
        dtGroup.Columns.Add("Count", typeof(int));
        foreach (DataRow dr in dtGroup.Rows)
        {
            dr["Count"] = PrmDtList.Compute("Count(ID)", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
        }
        dvLst = new DataView(dtGroup);
        dvLst.Sort = " DivisionName ASC";
        GrdVwSummary_Srch.DataSource = dvLst.ToTable();
        GrdVwSummary_Srch.DataBind();
    }
    public string FnCountDetails(object PrmDivId)
    {
        return (ObjCls.FnIsNumeric((ViewState["DT"] as DataTable).Rows[0]["ID"].ToString()) > 0 ? (ViewState["DT"] as DataTable).Compute("Count(ID)", " DivisionId=" + ObjCls.FnIsNumeric(PrmDivId.ToString())).ToString() : "");
    }
    public string FnGenderCntDetails(object PrmDivId)
    {
        return (ObjCls.FnIsNumeric((ViewState["DT"] as DataTable).Rows[0]["ID"].ToString()) > 0 ? "B-" + (ViewState["DT"] as DataTable).Compute("Count(ID)", " Sex= 'Male' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString() + ", G-" + (ViewState["DT"] as DataTable).Compute("Count(ID)", " Sex= 'Female' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString() : "");
    }
    public string FnGenderCntDetailsSrch(object PrmDivId)
    {
        return "B-" + (ViewState["DT_CHILD"] as DataTable).Compute("Count(ID)", " Sex= 'Male' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString() + ", G-" + (ViewState["DT_CHILD"] as DataTable).Compute("Count(ID)", " Sex= 'Female' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString();
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
                    FnCancel();
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
    protected void GrdVwSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DdlDiv = (DropDownList)e.Row.FindControl("DdlDiv");
                HiddenField HdnDivId = (HiddenField)e.Row.FindControl("HdnDivId");
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {
                    FnBindingDropDownList(ObjLst, ViewState["DIV"] as DataTable, DdlDiv, "");
                    FnSetDropDownValue(DdlDiv, DataBinder.Eval(e.Row.DataItem, "DivisionId").ToString());
                    _strDestControl = HdnDivId.ClientID + "," + GrdVwSummary.ClientID;

                    DdlDiv.Attributes.Add("onchange", "return FnUpdateStudentDivision('" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().USERID + "','" + DataBinder.Eval(e.Row.DataItem, "StudentId").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "ClassId").ToString() + "','" + HdnDivId.ClientID + "','" + DdlDiv.ClientID + "','" + _strDestControl + "');");
                }
                else
                {
                    ObjLst.FnNullDropDownList(DdlDiv);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
}