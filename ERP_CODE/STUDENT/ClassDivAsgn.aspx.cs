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
        //TabContainer1.ActiveTabIndex = 0;
        ///*int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID;
        //ObjCls = new clsAccountGroup(ref iCmpId, ref iBrId, ref iFaId);*/
        //ViewState["DT"] = ObjCls.FnConvertStringToDataTable(ObjCls.FnReadXmlFile(Server.MapPath("XML_NULL//GENERAL.xml"))) as DataTable;
        //FnGridViewBinding("");

        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsClass(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);

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
                    DataTable dt = new DataTable();
                    DataRow dr;
                    DataTable dts = new DataTable();
                    DataRow drs;

                    dt.Columns.Add(new DataColumn("StudentName"));
                    dt.Columns.Add(new DataColumn("StudentId"));
                    dt.Columns.Add(new DataColumn("ClassName"));
                    dt.Columns.Add(new DataColumn("DivisionName"));

                    dts.Columns.Add(new DataColumn("StudentName"));
                    dts.Columns.Add(new DataColumn("StudentId"));
                    dts.Columns.Add(new DataColumn("Institution"));
                    dts.Columns.Add(new DataColumn("ClassName"));
                    dts.Columns.Add(new DataColumn("DivisionName"));


                    foreach (GridViewRow gvr in GrdVwRecords.Rows)
                    {
                        if (((CheckBox)gvr.Cells[0].FindControl("chk")).Checked == true)
                        {
                            dr = dt.NewRow();
                            dr["StudentName"] = ((Label)gvr.Cells[0].FindControl("LblName")).Text;
                            dr["StudentId"] = ((Label)gvr.Cells[1].FindControl("LblCode")).Text;
                            dr["ClassName"] = ((Label)gvr.Cells[2].FindControl("LblClass")).Text;
                            dr["DivisionName"] = ((Label)gvr.Cells[3].FindControl("LblDiv")).Text;
                            dt.Rows.Add(dr);
                        }
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                    }


                    string ins = DrpInstitution1.SelectedItem.ToString();
                    string cls1 = DrpClass1.SelectedItem.ToString();
                    string division = DrpDivision1.SelectedItem.ToString();
                    foreach (GridViewRow gvr in GridView1.Rows)
                    {
                        drs = dts.NewRow();
                        drs["StudentName"] = ((Label)gvr.Cells[1].FindControl("LblName1")).Text;
                        drs["StudentId"] = ((Label)gvr.Cells[1].FindControl("LblCode1")).Text;
                        drs["Institution"] = ins;
                        drs["ClassName"] = cls1;                 //((Label)gvr.Cells[2].FindControl("LblClass")).Text;
                        drs["DivisionName"] = division;          //((Label)gvr.Cells[3].FindControl("LblDiv")).Text;
                        dts.Rows.Add(drs);
                    }


                    GrdStudents.DataSource = dts;
                    GrdStudents.DataBind();
                    GrdStudents.SelectedIndex = -1;
                    TabContainer1.ActiveTabIndex = 1;



                    break;

                    //// if (TxtName.Text.Trim().Length <= 0)
                    // {
                    //     FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                    //  //   FnFocus(TxtName);
                    //     return;
                    // }
                    //FnAssignStudent();
                    //switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    //{
                    //    case "NEW":
                    //        base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                    //        break;
                    //    case "UPDATE":
                    //        base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                    //        break;
                    //}
                    //break;
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
        else if ((DrpInstitution.SelectedValue != "0") && (DrpClass.SelectedValue == "0") && (DrpDivision.SelectedValue == "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblBranch") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if ((DrpInstitution.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue == "0"))
        {
            //DataTable dt = (ObjCls.FnGetDataSet("select  nId ID,cName,'' Remarks,'True' Active from TblRegistrationStudent") as DataSet).Tables[0];
            DataTable dt = (ObjCls.FnGetDataSet("select  * from TblRegistrationStudent") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if ((DrpInstitution.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue != "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
            //DataTable dt = (ObjCls.FnGetDataSet("select  * from TblRegistrationStudent") as DataSet).Tables[0];
            // INNER JOIN TblClassDetails TDL on TRS.nDivisionId=TDL.nId AND TCL.cTType='DIVN'
            //DataTable dt = (ObjCls.FnGetDataSet("select  TRS.nId ID,TRS.cName,TAD.cName,TAD.cName,'' Remarks,'True' Active from TblRegistrationStudent TRS inner join TblStudentAdmissionDetails TAD on TRS.nStudentId=TAD.nStudentId ") as DataSet).Tables[0];
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
                    dr["StudentId"] = ((Label)gvr.Cells[2].FindControl("LblCode")).Text;
                    dr["ClassName"] = ((Label)gvr.Cells[3].FindControl("LblClass")).Text;
                    dr["DivisionName"] = ((Label)gvr.Cells[4].FindControl("LblDiv")).Text;
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
                    dr["StudentId"] = ((Label)gvr.Cells[2].FindControl("LblCode")).Text;
                    dr["ClassName"] = ((Label)gvr.Cells[3].FindControl("LblClass")).Text;
                    dr["DivisionName"] = ((Label)gvr.Cells[4].FindControl("LblDiv")).Text;
                    dt.Rows.Add(dr);
                    // }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }

}
