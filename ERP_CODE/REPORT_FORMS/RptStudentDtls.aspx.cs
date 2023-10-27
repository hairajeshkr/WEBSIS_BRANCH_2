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
    DataTable DTMale = new DataTable();
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
                DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(DTInstitute, icount, null);

                //DataTable DTClasses = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
                //ChkClassDivList.DataSource = DTClasses;
                //ChkClassDivList.DataValueField = "nId";
                //ChkClassDivList.DataTextField = "cName";
                //ChkClassDivList.DataBind();

                //DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
                //ChkDivList.DataSource = DTChkClassDiv;
                //ChkDivList.DataValueField = "nId";
                //ChkDivList.DataTextField = "cName";
                //ChkDivList.DataBind();

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

                    //DataTable dt = new DataTable();
                    //dt.Columns.Add(new DataColumn("Group", typeof(string)));
                    ////dt.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                   
                    //string selectedItemsC = "", selectedclass="";
                    //for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    //{
                    //    if (ChkClassDivList.Items[i].Selected)
                    //    { 
                    //        selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                    //        selectedclass = ChkClassDivList.Items[i].Text;
                    //        DataRow row = dt.NewRow();
                    //        row["Group"] = selectedclass.TrimEnd(',');
                    //        dt.Rows.Add(row);
                    //    }
                        
                    //}

                    //selectedItemsC = selectedItemsC.TrimEnd(',');
                    //selectedclass = selectedclass.TrimEnd(',');

                    //DataTable dclass = new DataTable();
                    //dclass.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                    //string selectedItemsD = "",selecteddiv="";
                    //for (int i = 0; i < ChkDivList.Items.Count; i++)
                    //{
                       
                    //    if (ChkDivList.Items[i].Selected)
                    //    {
                    //        selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                    //        selecteddiv = ChkDivList.Items[i].Text;
                    //        DataRow drow = dclass.NewRow();
                    //        drow["SubGroup"] = selecteddiv;
                    //        dclass.Rows.Add(drow);
                            
                            
                    //    }

                    //}

                    ////for (int k = 0; k < dt.Rows.Count; k++)
                    ////{
                    ////    GrdVwRecords.Rows[k].Cells[1].Text = dt.Rows[k].ItemArray.ToString();
                    ////}
                    


                    ////GrdVwRecords.DataSource = dt;
                    ////GrdVwRecords.DataBind();
                    
                    //selectedItemsD = selectedItemsD.TrimEnd(',');
                    //selecteddiv = selecteddiv.TrimEnd(',');



                    ////string query = "select count(case when cSex='Male' then 1 end) as Male,count(case when cSex='Female' then 1 end) as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") ";

                    ////string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";
                    //string query = "select distinct CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";



                    //DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    //GrdVwRecords.DataSource = DTMale;
                    //GrdVwRecords.DataBind();

                    //// kl = GrdVwRecords.Rows[1].Cells[3].Text;

                    //for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
                    //{
                    //    Label k = (Label)GrdVwRecords.Rows[i].Cells[3].FindControl("Lblboys");

                    //    Label h = (Label)GrdVwRecords.Rows[i].Cells[4].FindControl("lblfemale");
                    //    int j = Convert.ToInt32(k.Text);
                    //    int m = Convert.ToInt32(h.Text);
                    //    int n = j + m;
                    //    GrdVwRecords.Rows[i].Cells[4].Text = n.ToString();
                    //}

                   
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








                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    //protected void ChkSelctAllClass_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkSelctAllClass.Checked == true)
    //    {
    //        foreach (ListItem item in ChkClassDivList.Items)
    //        {
    //            item.Selected = true;
    //            item.Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (ListItem item in ChkClassDivList.Items)
    //        {
    //            item.Selected = false;
    //            item.Enabled = true;
    //        }
    //    }
    //}



    //protected void ChkSelectAllDiv_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkSelectAllDiv.Checked == true)
    //    {
    //        foreach (ListItem item in ChkDivList.Items)
    //        {
    //            item.Selected = true;
    //            item.Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (ListItem item in ChkDivList.Items)
    //        {
    //            item.Selected = false;
    //            item.Enabled = true;
    //        }

    //    }
    //}


    //private void BindReport()
    //{
    //    string selectedItemsC = "", selectedclass = "";
    //    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
    //    {
    //        if (ChkClassDivList.Items[i].Selected)
    //        {
    //            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
    //            selectedclass = ChkClassDivList.Items[i].Text;
    //        }

    //    }

    //    selectedItemsC = selectedItemsC.TrimEnd(',');
    //    selectedclass = selectedclass.TrimEnd(',');


    //    string selectedItemsD = "", selecteddiv = "";
    //    for (int i = 0; i < ChkDivList.Items.Count; i++)
    //    {

    //        if (ChkDivList.Items[i].Selected)
    //        {
    //            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
    //            selecteddiv = ChkDivList.Items[i].Text;
    //        }

    //    }


    //selectedItemsD = selectedItemsD.TrimEnd(',');
    //selecteddiv = selecteddiv.TrimEnd(',');

    //DataTable DTList = new DataTable();

    //using (SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
    //{
    //    using (SqlCommand cmd1 = new SqlCommand("SPFillStudentGridData", con1))
    //    {
    //        con1.Open();
    //        cmd1.CommandType = CommandType.StoredProcedure;
    //        cmd1.Parameters.AddWithValue("@Class", selectedItemsC);
    //        cmd1.Parameters.AddWithValue("@Division", selectedItemsD);
    //        int i = cmd1.ExecuteNonQuery();
    //        con1.Close();
    //        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
    //        {
    //            da.Fill(DTList);
    //        }
    //    }

    //    ViewState["DT_List"] = DTList;
    //    //GrdVwRecords.DataSource = DTList;
    //    //GrdVwRecords.DataBind();
    //}



    //string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";

    ////string query = "select 'CLS' class,'DIV' division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") ";
    //string parameter1 = query;
    //string parameter2 = selectedItemsC;
    //Session["param1"] = parameter1;
    //Session["param2"] = parameter2;



    ////string parameter1 = selectedItemsC;
    ////string parameter2 = selectedItemsD;
    ////Session["param1"] = parameter1;
    ////Session["param2"] = parameter2;


    //Response.Redirect("RptCampusStatisticsViewer.aspx");


    //}

    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            FnCancel();
        }
        catch
        {
        }
    }


}