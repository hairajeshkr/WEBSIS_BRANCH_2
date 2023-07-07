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
            if (!IsPostBack)
            {
                FnInitializeForm();
                ObjLst.FnGetBranchList(DrpInstitution, "");
                ObjLst.FnGetBranchList(DrpInstitution1, "");
                
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
        //int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        //ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);

        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        //FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.ClassId = ObjCls.FnIsNumeric(DrpClass.SelectedValue);
        //ObjCls.DivisionId = ObjCls.FnIsNumeric(DrpDivision.SelectedValue);
    }
    public void cbxHdrPresent_OnCheckedChanged()
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
                    int nCnt = 0;
                    HiddenField Hdnstid = null, HdnAdId = null;
                    CheckBox ChkVal = null;
                    string strStudentId = "", strAdminId = "";
                    for (int i = 1; i <= GrdVwRecords.Rows.Count; i++)
                    {
                        ChkVal = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkVal");
                        if (ChkVal.Checked == true)
                        {
                            Hdnstid = (HiddenField)GrdVwRecords.Rows[i].FindControl("Hdnstid");
                            HdnAdId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnAdId");
                            strStudentId = strStudentId + Hdnstid.Value + ",";
                            strAdminId = strAdminId + HdnAdId.Value + ",";
                            nCnt++;
                        }
                    }
                   
                    if (nCnt > 0)
                    {
                        FnAssignProperty();
                        ObjCls.StudentIdList = FnRemoveLastValue(strStudentId);
                        ObjCls.AdmissionIdList = FnRemoveLastValue(strAdminId);
                        FnPopUpAlert(ObjCls.FnAlertMessage(ObjCls.UpdateRecord() as string));
                    }
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                   
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    

    protected void DrpInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obj.FnGetBranchList(DrpInstitution, "");
        DrpClass.Items.Clear();
        DrpClass.Items.Add(new ListItem("select", "0"));
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
        //DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nParentId=" + i + "") as DataSet).Tables[0];
        DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN'  and nParentId=" + i + "") as DataSet).Tables[0];
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
        //DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN' ") as DataSet).Tables[0];
        DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN' and nParentId=" + i + "") as DataSet).Tables[0];
        DrpDivision1.DataSource = clsDiv;
        DrpDivision1.DataValueField = "nId";
        DrpDivision1.DataTextField = "cName";
        DrpDivision1.DataBind();
        ////clsDiv.Clear();

    }

    protected void cbxHdrPresent_OnCheckedChanged(object sender, EventArgs e)
    {
        int chkCount = 0;
        CheckBox chkHead = (CheckBox)GrdVwRecords.HeaderRow.FindControl("chkAll");
        if (chkHead.Checked)
        {
            for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GrdVwRecords.Rows[i].FindControl("chk");
                chk.Checked = true;
                chkCount++;
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add(new DataColumn("StudentName"));
                dt.Columns.Add(new DataColumn("StudentId"));
                dt.Columns.Add(new DataColumn("ClassName"));
                dt.Columns.Add(new DataColumn("DivisionName"));
                foreach (GridViewRow gvr in GrdVwRecords.Rows)
                {
                    //if(((CheckBox)gvr.Cells[5].FindControl("chkb1")).Checked == true)
                    //{
                    dr = dt.NewRow();
                    dr["StudentName"] = ((Label)gvr.Cells[1].FindControl("LblName")).Text;
                    //dr["StudentId"] = ((Label)gvr.Cells[2].FindControl("LblCode")).Text;
                    dr["ClassName"] = ((Label)gvr.Cells[2].FindControl("LblClass")).Text;
                    dr["DivisionName"] = ((Label)gvr.Cells[3].FindControl("LblDiv")).Text;
                    dt.Rows.Add(dr);
                    // }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

            }
        }
        else
        {
            for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GrdVwRecords.Rows[i].FindControl("chkb2");
                chk.Checked = false;
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add(new DataColumn("StudentName"));
                dt.Columns.Add(new DataColumn("StudentId"));
                dt.Columns.Add(new DataColumn("ClassName"));
                dt.Columns.Add(new DataColumn("DivisionName"));
                foreach (GridViewRow gvr in GrdVwRecords.Rows)
                {
                    //if (((CheckBox)gvr.Cells[5].FindControl("chkb1")).Checked == true)
                    //{
                    dr = dt.NewRow();
                    dr["StudentName"] = ((Label)gvr.Cells[1].FindControl("LblName")).Text;
                    //dr["StudentId"] = ((Label)gvr.Cells[2].FindControl("LblCode")).Text;
                    dr["ClassName"] = ((Label)gvr.Cells[2].FindControl("LblClass")).Text;
                    dr["DivisionName"] = ((Label)gvr.Cells[3].FindControl("LblDiv")).Text;
                    dt.Rows.Add(dr);
                    // }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

}
