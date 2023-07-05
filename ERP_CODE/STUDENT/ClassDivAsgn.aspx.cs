using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class STUDENT_ClassAssign : ClsPageEvents, IPageInterFace
{
    ClsClass ObjCls = new ClsClass();
    ClsDropdownRecordList obj=new ClsDropdownRecordList();
    
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                obj.FnGetBranchList(DrpInstitution, "");
                obj.FnGetBranchList(DrpInstitution1, "");
                //filldropdown();
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        /*int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID;
        ObjCls = new clsAccountGroup(ref iCmpId, ref iBrId, ref iFaId);*/
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
    }
    public void FnAssignStudent() 
    { 
        foreach (GridViewRow gvrow in GrdVwRecords.Rows)
        {
            var checkbox = gvrow.FindControl("ChkSelect") as CheckBox;
            if (checkbox.Checked)
            {
                DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' ") as DataSet).Tables[0];
                GrdStudents.DataSource = clsDiv;
                GrdStudents.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdStudents.DataBind();
                GrdStudents.SelectedIndex = -1;
                TabContainer1.ActiveTabIndex = 1;

            }
        }
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        //TxtName.Text = "";
        //TxtName_Srch.Text = "";
        //TxtCode_Srch.Text = "";
        //TxtRemarks.Text = "";
        //ChkActive.Checked = true;
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        //FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        //ObjCls.Name = TxtName_Srch.Text.Trim();
       // ObjCls.Code = TxtCode_Srch.Text.Trim();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
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
                    //// if (TxtName.Text.Trim().Length <= 0)
                    // {
                    //     FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                    //  //   FnFocus(TxtName);
                    //     return;
                    // }
                    FnAssignStudent();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    break;
                //case "DELETE":
                //    FnAssignProperty();
                //    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    break;
                //case "CLEAR":
                //    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
                //    FnCancel();
                //    break;
                //case "CLOSE":
                //    ObjCls.FnAlertMessage(" You Have No permission To Close Record");
                //    break;
                //case "PRINT":
                //    FnAssignProperty();
                //    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    break;
                //case "FIND":
                //    FnFindRecord();
                //    //FnAssignProperty();
                //    //base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    //FnGridViewBinding("");
                //    //System.Threading.Thread.Sleep(1000000);
                //    break;
                //case "HELP":
                //    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                //    break;
                //case "FIRST":
                //    //========Code
                //    break;
                //case "PREVIOUS":
                //    //========Code
                //    break;
                //case "NEXT":
                //    //========Code
                //    break;
                //case "LAST":
                //    //========Code
                //    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            //TxtName.Text = ObjCls.Name.ToString();
            //TxtCode.Text = ObjCls.Code.ToString();

            //TxtRemarks.Text = ObjCls.Remarks.ToString();
            //ChkActive.Checked = ObjCls.Active;
            //ChkApprove.Checked = ObjCls.IsApprove;
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {
        if (DrpInstitution.SelectedValue == "0")
        {
            DataTable clsls1 = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblQuota") as DataSet).Tables[0];
            GrdVwRecords.DataSource = clsls1;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
            
        }
        else if((DrpInstitution.SelectedValue != "0")&&(DrpClass.SelectedValue=="0")&&(DrpDivision.SelectedValue=="0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblBranch") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if ((DrpInstitution.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue == "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblClassDetails") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if((DrpInstitution.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue != "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblClassDetails") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;

        }

    }

    protected void DrpInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obj.FnGetBranchList(DrpInstitution, "");
        DrpClass.Items.Clear();
        DrpClass.Items.Add(new ListItem("select","0"));
        int i = ObjCls.FnIsNumeric(DrpInstitution.SelectedValue);
        DataTable clsCls = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nBranchId=" + i + "") as DataSet).Tables[0];
        DrpClass.DataSource = clsCls;
        DrpClass.DataValueField = "nId";
        DrpClass.DataTextField = "cName";
        DrpClass.DataBind();
        
    }

    protected void DrpInstitution1_SelectedIndexChanged(object sender, EventArgs e)
    { 
        DrpClass1.Items.Clear();
        DrpClass1.Items.Add(new ListItem("select", "0"));
        int j = ObjCls.FnIsNumeric(DrpInstitution1.SelectedValue);
        DataTable clsCls1 = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nBranchId=" + j + "") as DataSet).Tables[0];
        DrpClass1.DataSource = clsCls1;
        DrpClass1.DataValueField = "nId";
        DrpClass1.DataTextField = "cName";
        DrpClass1.DataBind();


    }

    protected void DrpClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrpDivision.Items.Clear();
        DrpDivision.Items.Add(new ListItem("select", "0"));
        int i = ObjCls.FnIsNumeric(DrpClass.SelectedValue);
        DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nParentId=" + i + "") as DataSet).Tables[0];
        //DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN'") as DataSet).Tables[0];
        DrpDivision.DataSource = clsDiv;
        DrpDivision.DataValueField = "nId";
        DrpDivision.DataTextField = "cName";
        DrpDivision.DataBind();
        ////clsDiv.Clear();

    }
    protected void DrpClass1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrpDivision1.Items.Clear();
        DrpDivision1.Items.Add(new ListItem("select", "0"));
        int i = ObjCls.FnIsNumeric(DrpClass1.SelectedValue);
        DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nParentId=" + i + "") as DataSet).Tables[0];
        //DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN'") as DataSet).Tables[0];
        DrpDivision1.DataSource = clsDiv;
        DrpDivision1.DataValueField = "nId";
        DrpDivision1.DataTextField = "cName";
        DrpDivision1.DataBind();
        ////clsDiv.Clear();

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        
        foreach (GridViewRow gvrow in GrdVwRecords.Rows)
        {
            var checkbox = gvrow.FindControl("ChkSelect") as CheckBox;
            if (checkbox.Checked)
            {
                DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId ID,cName from TblClassDetails where cTType='CLS' ") as DataSet).Tables[0];
                GrdStudents.DataSource = clsDiv;
                GrdStudents.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdStudents.DataBind();
                GrdStudents.SelectedIndex = -1;
                //TabContainer1.ActiveTabIndex = 1;

            }
        }
    }
    protected void GetSelectedRecords(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Name"), new DataColumn("Id"), new DataColumn("Class"), new DataColumn("Division") });
        foreach (GridViewRow row in GrdVwRecords.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("ChkSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    string name = row.Cells[1].Text;
                    //string id=row.Cells[2].Text;
                    string cls=row.Cells[3].Text;
                    string div=row.Cells[4].Text;
                    dt.Rows.Add(name,cls,div);
                }
            }
        }
        GrdStudents.DataSource = dt;
        GrdStudents.DataBind();
    }
}