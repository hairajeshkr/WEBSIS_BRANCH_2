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
                FnDdlgrpfilterfill();

                

                //TemplateField tfield = new TemplateField();
                //tfield.HeaderText = "Country";
                //GrdVwRecords.Columns.Add(tfield);

                //tfield = new TemplateField();
                //tfield.HeaderText = "View";
                //GrdVwRecords.Columns.Add(tfield);

            }
            //FnBindGrid();

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    private void FnBindGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                       new DataColumn("Name", typeof(string)),
                        new DataColumn("Country",typeof(string)) });
        dt.Rows.Add(1, "John Hammond", "United States");
        //dt.Rows.Add(2, "Mudassar Khan", "India");
        //dt.Rows.Add(3, "Suzanne Mathews", "France");
        //dt.Rows.Add(4, "Robert Schidner", "Russia");
        GrdVwRecords.DataSource = dt;
        GrdVwRecords.DataBind();
    }
    public void FnDdlgrpfilterfill() 
    {
        Ddlgrpfilter.Enabled = true;

        Ddlgrpfilter.Items.Clear();

        Ddlgrpfilter.Items.Add(new ListItem("Select", "0"));
        DataTable DTClass = (ObjCls.FnGetDataSet("SELECT nId,cName  FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
        Ddlgrpfilter.DataSource = DTClass;
        Ddlgrpfilter.DataValueField = "nId";
        Ddlgrpfilter.DataTextField = "cName";
        Ddlgrpfilter.DataBind();



        DdlReligion.Enabled = true;
        
        DdlReligion.Items.Clear();

        DdlReligion.Items.Add(new ListItem("Select", "0"));
         //DataTable DTReligion = (ObjCls.FnGetDataSet("SELECT distinct  * FROM TblCustomHead ") as DataSet).Tables[0];
        DataTable DTReligion = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
        DdlReligion.DataSource = DTReligion;
        DdlReligion.DataValueField = "nId";
        DdlReligion.DataTextField = "cName";
        DdlReligion.DataBind();


       
        ChkClassDivList.DataSource = DTReligion;
        ChkClassDivList.DataValueField = "nId";
        ChkClassDivList.DataTextField = "cName";
        ChkClassDivList.DataBind();

        DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
        ChkDivList.DataSource = DTChkClassDiv;
        ChkDivList.DataValueField = "nId";
        ChkDivList.DataTextField = "cName";
        ChkDivList.DataBind();






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

        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;

        //GrdVwSummary.DataSource = ViewState["DT"] as DataTable;
        //GrdVwSummary.DataBind();

        //GrdVwList.DataSource = ViewState["DT"] as DataTable;
        //GrdVwList.DataBind();

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


    //protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            DropDownList DdlDiv = (DropDownList)e.Row.FindControl("DdlDiv");
    //            HiddenField HdnDivId = (HiddenField)e.Row.FindControl("HdnDivId");
    //            if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
    //            {
    //                FnBindingDropDownList(ObjLst, ViewState["DIV"] as DataTable, DdlDiv, "");
    //                FnSetDropDownValue(DdlDiv, DataBinder.Eval(e.Row.DataItem, "DivisionId").ToString());
    //                _strDestControl = HdnDivId.ClientID + "," + GrdVwSummary.ClientID;

    //                DdlDiv.Attributes.Add("onchange", "return FnUpdateStudentDivision('" + FnGetRights().COMPANYID + "','" + FnGetRights().BRANCHID + "','" + FnGetRights().ACYEARID + "','" + FnGetRights().USERID + "','" + DataBinder.Eval(e.Row.DataItem, "StudentId").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "ClassId").ToString() + "','" + HdnDivId.ClientID + "','" + DdlDiv.ClientID + "','" + _strDestControl + "');");
    //            }
    //            else
    //            {
    //                ObjLst.FnNullDropDownList(DdlDiv);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
    //    }
    //}

    protected void DdlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (DdlFilter.SelectedValue == "1")
        {
            lblFromdate.Visible = true;
            lblduedate.Visible = true;
            CtrlFromDate.Visible = true;
            CtrlDueDate.Visible = true;

            lBLGRP2.Visible = false;
            Ddlgrpfilter.Visible = false;

            lblreligion.Visible = false;
            DdlReligion.Visible = false;
        }
        else if (DdlFilter.SelectedValue == "2")
        {
            lblgroup.Visible = false;
            TxtGroup.Visible = false;
            BtnGroup.Visible = false;

            lBLGRP2.Visible = true;
            Ddlgrpfilter.Visible = true;

            lblFromdate.Visible = false;
            lblduedate.Visible = false;
            CtrlFromDate.Visible = false;
            CtrlDueDate.Visible = false;
        }
        else if (DdlFilter.SelectedValue == "3")
        {
            lblreligion.Visible = true;
            DdlReligion.Visible = true;

            lBLGRP2.Visible = false;
            Ddlgrpfilter.Visible = false;

            lblFromdate.Visible = false;
            lblduedate.Visible = false;
            CtrlFromDate.Visible = false;
            CtrlDueDate.Visible = false;

            lblgroup.Visible = true;
            TxtGroup.Visible = true;
            BtnGroup.Visible = true;
        }
       
    }

    protected void ChkSelect_SelectedIndexChanged2(object sender, EventArgs e)
    {
        string selectedItems = "";
        for (int i = 0; i < ChkSelect.Items.Count; i++)
        {
            if (ChkSelect.Items[i].Selected)
                selectedItems = ChkSelect.Items[i].ToString();
        }

        BoundField bfield = new BoundField();
        bfield.HeaderText = selectedItems;
        //bfield.DataField = "Name";
        GrdVwRecords.Columns.Add(bfield);
        
        FnBindGrid();

        
    }
}