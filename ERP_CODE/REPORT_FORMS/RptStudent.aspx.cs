using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
public partial class REPORT_FORMS_RptStudent : ClsPageEvents, IPageInterFace
{
    ClsRegistrationStudent ObjCls = new ClsRegistrationStudent();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    static int icount = 0;
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
                DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(DTInstitute, icount, null);

            }
           

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode)
    {
        int VS;
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode tnode = new TreeNode
            {
                Text = row["Name"].ToString(),
                Value = row["ID"].ToString()
            };

            if (ParentId == 0)
            {
                TreVwLst.Nodes.Add(tnode);
                DataTable DTClass = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId= " + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(DTClass, VS, tnode);
            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable DTDivision = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN'and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(DTDivision, VS, tnode);
            }
            else
            {
                treeNode.ChildNodes.Add(tnode);
            }
        }
    }


    public void FnGrpClassDivChkFill()
    {

        DataTable DdlReligionDT = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentCategory where cttype='RELGN'") as DataSet).Tables[0];
        DdlReligion.DataSource = DdlReligionDT;
        DdlReligion.DataValueField = "nId";
        DdlReligion.DataTextField = "cName";
        DdlReligion.DataBind();
        DdlReligion.Items.Insert(0, new ListItem("---Select---", "0"));

    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsRegistrationStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
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

        //GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        //GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //GrdVwRecords.DataBind();
        //GrdVwRecords.SelectedIndex = -1;

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
                    DataTable clsdetail = (ObjCls.FnGetDataSet("SELECT * FROM TblStudentAdmissionDetails ") as DataSet).Tables[0];
                    DataTable ins= (ObjCls.FnGetDataSet("SELECT * FROM TblRegistrationStudent ") as DataSet).Tables[0];
                    String InstId = "", Instmessage = "", Clsmessage="", ClsId="", Divmessage="", DivId="";

                    foreach (TreeNode node in TreVwLst.CheckedNodes)
                    {
                        if(node.Depth==0)
                        {
                            Instmessage += node.Text + ",";
                            InstId += node.Value + ",";
                        }
                        else if (node.Depth == 1)
                        {
                            Clsmessage += node.Text + ",";
                            ClsId += node.Value + ",";
                        }
                        else if (node.Depth == 2)
                        {
                            Divmessage += node.Text + ",";
                            DivId += node.Value + ",";
                        }

                    }
                    InstId = InstId.TrimEnd(',');
                    ClsId= ClsId.TrimEnd(',');
                    DivId = DivId.TrimEnd(',');

                    DataTable dt= (ObjCls.FnGetDataSet("select * FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and  STDR.nInstituteId in(" + 4 + ") and STDA.nClassId in(" + ClsId + ")  and STDA.nDivisionId in(" + DivId + ") ") as DataSet).Tables[0];

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
                    //this.BindReport();
                    Response.Redirect("RptStudentViewer.aspx");
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

            lblreligion.Enabled = false;
            DdlReligion.Enabled = false;
        }
        else if (DdlFilter.SelectedValue == "2")
        {

            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState = false;
            CtrlDueDate.EnableViewState = false;

            lblreligion.Enabled = false;
            DdlReligion.Enabled = false;
        }
        else if (DdlFilter.SelectedValue == "3")
        {
            lblreligion.Enabled = true;
            DdlReligion.Enabled = true;



            lblFromdate.Enabled = false;
            lblduedate.Enabled = false;
            CtrlFromDate.EnableViewState = false;
            CtrlDueDate.EnableViewState = false;


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

    //private void BindReport()
    //{
    //    int Par = 0, i4 = 1;

    //    string selectedItemsC = "";
    //    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
    //    {
    //        if (ChkClassDivList.Items[i].Selected)
    //        {
    //            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
    //        }         
    //    }
    //    selectedItemsC = selectedItemsC.TrimEnd(',');
    //    string selectedItemsD = "";
    //    for (int i = 0; i < ChkDivList.Items.Count; i++)
    //    {
    //        if (ChkDivList.Items[i].Selected)
    //        {
    //            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
    //        }
    //    }
    //    selectedItemsD = selectedItemsD.TrimEnd(',');


    //    string query = "SELECT ";
    //    bool isSelected = ChkSelectColumns.Items.Cast<ListItem>().Count(i => i.Selected == true) > 0;
    //    if (!isSelected)
    //    {
    //        ChkSelectColumns.Items[0].Selected = true;
    //    }
    //    foreach (ListItem item in ChkSelectColumns.Items)
    //    {
    //        if (item.Selected)
    //        {
    //            query += item.Value + ",";
    //            //if (item.Text == "Student Id")
    //            //{

    //            //    query += "STDR.cCode as cCode,";
    //            //}
    //            //else if (item.Text == "Student Name")
    //            //{

    //            //    query += "STDR.cName as cName,";
    //            //}
    //            //else if (item.Text == "Mother Tongue")
    //            //{

    //            //    query += "LANG.cName as McName,";
    //            //}
    //            //else
    //            //{
    //            //    query += item.Value + ",";
    //            //}

    //            isSelected = true;
    //            if (item.Value == "nStudentId")
    //            {
    //                Par = i4;
    //            }
    //            i4++;
    //        }
    //    }
    //    query = query.Substring(0, query.Length - 1);

    //    if (DdlFilter.SelectedValue == "3")
    //    {

    //           // query += "FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") and STDR.nReligionId=8 order by STDR.cName asc";
    //            query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ")  and STDR.nReligionId="+ DdlReligion.SelectedValue + " order by STDR.cName asc";


    //    }
    //    else if (DdlFilter.SelectedValue == "1")
    //    {
    //        DateTime fdate = ObjCls.FnDateTime(CtrlFromDate.DateText);
    //        DateTime tdate = ObjCls.FnDateTime(CtrlDueDate.DateText);
    //        //query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' order by STDR.cName asc";
    //        query += " FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId=STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ") and STDR.dJoindate>='" + fdate + "' and STDR.dJoindate<= '" + tdate + "' order by STDR.cName asc";

    //    }
    //    else
    //    {
    //        query += " FROM TblRegistrationStudent";
    //    }




    //    string parameter1 = query;
    //    string parameter2 = Par.ToString();
    //    Session["param1"] = parameter1;
    //    Session["param2"] = parameter2;


    //}

    private DataSetDynamic GetData(string query, ReportDocument crystalReport)
    {

        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True"))
        {
            DataSetDynamic dsCustomers = new DataSetDynamic();
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                //Get the List of all TextObjects in Section2.
                List<TextObject> textObjects = crystalReport.ReportDefinition.Sections["Section2"].ReportObjects.OfType<TextObject>().ToList();

                for (int i = 0; i < textObjects.Count; i++)
                {
                    //Set the name of Column in TextObject.
                    textObjects[i].Text = string.Empty;
                    if (sdr.FieldCount > i)
                    {
                        textObjects[i].Text = sdr.GetName(i).Substring(1);

                    }

                }


                //Load all the data rows in the Dataset.
                while (sdr.Read())
                {
                    DataRow dr = dsCustomers.Tables[0].Rows.Add();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        dr[i] = sdr[i];
                    }
                }
            }
            con.Close();
            return dsCustomers;

        }
    }



    //protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    //var CLN = TreVwLst.SelectedNode.Value;
    //    //int IH = TreVwLst.SelectedNode.Depth
    //    try
    //    {
    //        FnCancel();
    //        string message = "";
    //        if (TreVwLst.SelectedNode.Depth == 0)
    //        {
    //            foreach (TreeNode node in TreVwLst.CheckedNodes)
    //            {
    //                //if (node.Depth > 0)
    //                //{
    //                    //string checkedValue = node.Text.ToString();
    //                    //activityData = new ActivityData { ActivityName = checkedValue };
    //                    //listActivity.Add(activityData);
    //                    //Session["listActivity"] = listActivity;

    //                    message += node.Text;
    //                //}
    //            }
    //        }
    //        //else if (TreVwLst.SelectedNode.Depth == 1)
    //        //{
    //        //    CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
    //        //    CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Text;
    //        //    CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Value;
    //        //    CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Text;
    //        //}
    //        //else if (TreVwLst.SelectedNode.Depth == 2)
    //        //{

    //        //    CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Parent.Value;
    //        //    CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Parent.Text;
    //        //    CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
    //        //    CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Parent.Text;
    //        //    CtrlGrdDiv.SelectedValue = TreVwLst.SelectedNode.Value;
    //        //    CtrlGrdDiv.SelectedText = TreVwLst.SelectedNode.Text;

    //        //}

    //        //FnFillInstallment();


    //    }
    //    catch (Exception ex)
    //    {
    //        FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
    //    }
    //}
}