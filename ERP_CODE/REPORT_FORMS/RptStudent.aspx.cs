using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class REPORT_FORMS_RptStudent : ClsPageEvents, IPageInterFace
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
                FnGrpClassDivChkFill();

            }
            //DataTable ClsTGFI3 = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory where cttype='RELGN'") as DataSet).Tables[0];
            //DataTable ClsTGFI3 = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory") as DataSet).Tables[0];
            //DataTable ClsTGFI = (ObjCls.FnGetDataSet("SELECT * FROM TblRegistrationStudent order by cName asc") as DataSet).Tables[0];
            //DataTable ClsTGFI1 = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentAdmissionDetails") as DataSet).Tables[0];
            //DataTable ClsTGFI2 = (ObjCls.FnGetDataSet("SELECT * FROM TblClassDetails") as DataSet).Tables[0];


        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    public void FnGrpClassDivChkFill() 
    {
        Ddlgrpfilter.Enabled = true;
        Ddlgrpfilter.Items.Clear();
        Ddlgrpfilter.Items.Add(new ListItem("Select", "0"));
        DataTable DTClass = (ObjCls.FnGetDataSet("SELECT nId,cName  FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
        Ddlgrpfilter.DataSource = DTClass;
        Ddlgrpfilter.DataValueField = "nId";
        Ddlgrpfilter.DataTextField = "cName";
        Ddlgrpfilter.DataBind();


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


        DataTable DdlReligionDT = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory where cttype='RELGN'") as DataSet).Tables[0];
        DdlReligion.DataSource = DdlReligionDT;
        DdlReligion.DataValueField = "nId";
        DdlReligion.DataTextField = "cName";
        DdlReligion.DataBind();

    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
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
                    if (GrdVwRecords.Rows.Count > 0)
                    {
                        GrdVwRecords.Columns.Clear();
                        GrdVwRecords.DataBind();
                    }
                    DataTable DTList = new DataTable();
                    string selectedItemsC = "";
                    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    {
                        if (ChkClassDivList.Items[i].Selected)
                        {
                            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                        }
                    }
                    selectedItemsC = selectedItemsC.TrimEnd(',');
                    string selectedItemsD = "";
                    for (int i = 0; i < ChkDivList.Items.Count; i++)
                    {
                        if (ChkDivList.Items[i].Selected)
                        {
                            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                        }
                    }
                    selectedItemsD = selectedItemsD.TrimEnd(',');


                    string query = "SELECT TOP 10 ";
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
                            BoundField bfield = new BoundField();
                            bfield.HeaderText = item.Text;
                            bfield.DataField = item.Value;
                            GrdVwRecords.Columns.Add(bfield);
                        }
                    }


                    query = query.Substring(0, query.Length - 1);
                    if (DdlFilter.SelectedValue == "3")
                    {
                        if (DdlReligion.SelectedValue == "8")
                        {
                            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") and STDR.nReligionId=8 order by STDR.cName asc";
                            DataTable DTCC1 = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                            GrdVwRecords.DataSource = DTCC1;
                            GrdVwRecords.DataBind();
                        }
                    }
                    else if (DdlFilter.SelectedValue == "1")
                    {
                        DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
                        DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
                        query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' order by STDR.cName asc";

                        DataTable DTCC1 = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                        GrdVwRecords.DataSource = DTCC1;
                        GrdVwRecords.DataBind();
                    }





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
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    protected void DdlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (DdlFilter.SelectedValue == "1")
        {
            lblFromdate.Enabled = true;
            lblduedate.Enabled = true;
            CtrlFromDate.EnableViewState = true;
            CtrlDueDate.EnableViewState = true;

            lBLGRP2.Enabled = false;
            Ddlgrpfilter.Enabled = false;

            lblreligion.Enabled = false;
            DdlReligion.Enabled = false;
        }
        else if (DdlFilter.SelectedValue == "2")
        {
            lblgroup.Enabled = false;
            TxtGroup.Enabled = false;
            BtnGroup.Enabled = false;

            lBLGRP2.Enabled = true;
            Ddlgrpfilter.Enabled = true;

            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState= false;
            CtrlDueDate.EnableViewState = false;

            lblreligion.Enabled = false;
            DdlReligion.Enabled = false;
        }
        else if (DdlFilter.SelectedValue == "3")
        {
            lblreligion.Enabled = true;
            DdlReligion.Enabled = true;

            lBLGRP2.Enabled = false;
            Ddlgrpfilter.Enabled = false;

            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState = false;
            CtrlDueDate.EnableViewState = false;

            lblgroup.Enabled = true;
            TxtGroup.Enabled = true;
            BtnGroup.Enabled = true;
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

    protected void ChkSelectAllFields_CheckedChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in ChkSelectColumns.Items)
        {
            item.Selected = true;
            item.Enabled = true;
        }
    }
}