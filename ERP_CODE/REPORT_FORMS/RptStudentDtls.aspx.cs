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

                DataTable DTClasses = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
                ChkClassDivList.DataSource = DTClasses;
                ChkClassDivList.DataValueField = "nId";
                ChkClassDivList.DataTextField = "cName";
                ChkClassDivList.DataBind();

                DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
                ChkDivList.DataSource = DTChkClassDiv;
                ChkDivList.DataValueField = "nId";
                ChkDivList.DataTextField = "cName";
                ChkDivList.DataBind();

            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public string FnCountDetails(object PrmDivId)
    {
        return (ObjCls.FnIsNumeric((ViewState["DT"] as DataTable).Rows[0]["ID"].ToString()) > 0 ? (ViewState["DT"] as DataTable).Compute("Count(ID)", " DivisionId=" + ObjCls.FnIsNumeric(PrmDivId.ToString())).ToString() : "");
    }
    public string FnGenderCntDetails(object PrmDivId)
    {
        return (ObjCls.FnIsNumeric((ViewState["DT"] as DataTable).Rows[0]["ID"].ToString()) > 0 ? "B-" + (ViewState["DT"] as DataTable).Compute("Count(ID)", " Sex= 'Male' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString() + ", G-" + (ViewState["DT"] as DataTable).Compute("Count(ID)", " Sex= 'Female' AND DivisionId=" + ObjCls.FnIsNumeric(PrmDivId)).ToString() : "");
    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        //FnGridViewBinding("");
        //FnGridViewBinding("SRCH");
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
        //CtrlGrdClass.SelectedValue = "0";
        //CtrlGrdClass.SelectedText = "";
        //CtrlGrdDivision.SelectedValue = "0";
        //CtrlGrdDivision.SelectedText = "";
        //CtrlCommand1.SaveText = "Save";
        //CtrlCommand1.SaveCommandArgument = "NEW";
        //FnFocus(CtrlGrdClass.ControlTextBox);
        TabContainer1.ActiveTabIndex = 0;
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        //FnGetDivisionList();
        FnFindRecord(ObjCls);
       // FnGridViewBinding("");

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

        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        
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


                    DataTable DTList = new DataTable();
                    string selectedItemsC = "";
                    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    {
                        if (ChkClassDivList.Items[i].Selected)
                            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                    }
                    selectedItemsC = selectedItemsC.TrimEnd(',');
                    string selectedItemsD = "";
                    for (int i = 0; i < ChkDivList.Items.Count; i++)
                    {
                        if (ChkDivList.Items[i].Selected)
                            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                    }
                    selectedItemsD = selectedItemsD.TrimEnd(',');


                    //string query = "select count(case when cSex='Male' then 1 end) as Male,count(case when cSex='Female' then 1 end) as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") ";

                    string query = "select count(case when cSex='Male' then 1 end) as Male,count(case when cSex='Female' then 1 end) as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") ";
                    DataTable DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    GrdVwRecords.DataSource = DTMale;
                    GrdVwRecords.DataBind();

                    
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
                    //FnCancel_Srch();
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


    protected void ChkSelctAllClass_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in ChkClassDivList.Items)
        {
            item.Selected = true;
            item.Enabled = true;
        }
    }



    protected void ChkSelectAllDiv_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in ChkDivList.Items)
        {
            item.Selected = true;
            item.Enabled = true;
        }
    }
}