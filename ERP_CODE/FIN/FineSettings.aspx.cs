﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class FIN_FineSettings : ClsPageEvents, IPageInterFace
{
    ClsStudentAdmissionDetails ObjCls = new ClsStudentAdmissionDetails();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    ClsFeeMaster ObjCls1 = new ClsFeeMaster();
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
    static int icount = 0;
    TreeNode tnode;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {

            base.Page_Load(sender, e);
            //CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //ChkSelect.Attributes.Add("onclick", "return GridChkSelectAll();");

                //ObjLst.FnGetUserAcYearList(DdlAcYear, "--- ACADEMIC YEAR ---");
                // ObjLst.FnGetLanguageList(DdlAcYear, "---Sort by Language---");

                FnInitializeForm();
                DrpInstallFill();

                /////Tree View
                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);

            }
            //CtrlGridClass.ParentControl = CtrlGridInstitution.IdControl;
            CtrlGridDivision.ParentControl = CtrlGridClass.IdControl;
            CtrlGridStudent.ParentControl = CtrlGridDivision.IdControl;

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void DrpInstallFill()
    {

        DataTable ClsTD = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DdlInslment.DataSource = ClsTD;
        DdlInslment.DataValueField = "nId";
        DdlInslment.DataTextField = "cName";
        DdlInslment.DataBind();
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
                TreeView1.Nodes.Add(tnode);
                DataTable dtChild = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId=" + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(dtChild, VS, tnode);


            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild1 = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN' and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(dtChild1, VS, tnode);

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
        ObjCls1 = new ClsFeeMaster(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        FnFindRecord();
    }
    public void FnAssignProperty()
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
        ViewState["DT"] = ObjLst.FnGetFineMasterList() as DataTable;
        //ViewState["DT_CHILD"] = (ObjCls.FindRecord() as DataSet).Tables[0];

        //FnGridViewBinding("MAIN");
        FnGridViewBinding("");
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {

        GrdVwRecordsMain.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecordsMain.DataKeyNames = new String[] { ObjCls1.KeyName };
        GrdVwRecordsMain.DataBind();
        GrdVwRecordsMain.SelectedIndex = -1;

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
                            break;
                    }
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }



    protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
    {

        var CLN = TreeView1.SelectedNode.Value;
        int IH = TreeView1.SelectedNode.Depth;
        string GRP, CLS, DIVN;
        if (TreeView1.SelectedNode.Depth == 0)
        {
            //group
            GRP = TreeView1.SelectedNode.Value;
            Label2.Text = TreeView1.SelectedNode.Text;
            Label3.Text = "";
            Label4.Text = "";

            Label6.Text = GRP;
            Label7.Text = "";
            Label8.Text = "";
            CtrlGridInstitution.SelectedValue = GRP;
            CtrlGridInstitution.SelectedText = Label2.Text;



            int Dinsti = Convert.ToInt32(TreeView1.SelectedNode.Value);
            int Dcls = Convert.ToInt32(CtrlGridClass.SelectedValue);
            int Ddiv= Convert.ToInt32(CtrlGridDivision.SelectedValue);
            int DStudent= Convert.ToInt32(CtrlGridStudent.SelectedValue);

            int Dinstallment = Convert.ToInt32(DdlInslment.SelectedValue);
            SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId=" + Dinsti + "and nClassId=" + Dcls +"and nDivisionId="+Ddiv+ "and nStudentId=" + DStudent + "and nInstallmentId=" + Dinstallment , con);


            viewgrid(cmd);

        }
        else if (TreeView1.SelectedNode.Depth == 1)
        {
            //Class
            GRP = TreeView1.SelectedNode.Parent.Value;
            Label2.Text = (TreeView1.SelectedNode.Parent.Text) + "->";

            Label6.Text = GRP;

            CLS = TreeView1.SelectedNode.Value;
            Label3.Text = (TreeView1.SelectedNode.Text);
            Label4.Text = "";

            Label7.Text = CLS;
            Label8.Text = "";

            CtrlGridInstitution.SelectedValue = GRP;
            CtrlGridInstitution.SelectedText = TreeView1.SelectedNode.Parent.Text;

            CtrlGridClass.SelectedValue = CLS;
            CtrlGridClass.SelectedText = TreeView1.SelectedNode.Text;

            int Dinsti = Convert.ToInt32(TreeView1.SelectedNode.Parent.Value);
            int Dcls= Convert.ToInt32(TreeView1.SelectedNode.Value);
            int Ddiv = Convert.ToInt32(CtrlGridDivision.SelectedValue);
            int DStudent = Convert.ToInt32(CtrlGridStudent.SelectedValue);

            int Dinstallment = Convert.ToInt32(DdlInslment.SelectedValue);

            SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId=" + Dinsti + "and nClassId=" + Dcls + "and nDivisionId=" + Ddiv + "and nStudentId=" + DStudent + "and nInstallmentId=" + Dinstallment, con);
            //SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId="+Dinsti+"and nClassId="+Dcls+ "and nInstallmentId=" + Dinstallment, con);

            viewgrid(cmd);
        }
        else if (TreeView1.SelectedNode.Depth == 2)
        {
            //Division
            GRP = TreeView1.SelectedNode.Parent.Parent.Value;
            Label2.Text = (TreeView1.SelectedNode.Parent.Parent.Text) + "->";
            Label6.Text = GRP;

            CLS = TreeView1.SelectedNode.Parent.Value;
            Label3.Text = (TreeView1.SelectedNode.Parent.Text) + "->";
            Label7.Text = CLS;

            DIVN = TreeView1.SelectedNode.Value;
            Label4.Text = TreeView1.SelectedNode.Text;
            Label8.Text = DIVN;

            CtrlGridInstitution.SelectedValue = GRP;
            CtrlGridInstitution.SelectedText = TreeView1.SelectedNode.Parent.Parent.Text;

            CtrlGridClass.SelectedValue = CLS;
            CtrlGridClass.SelectedText = TreeView1.SelectedNode.Parent.Text;

            CtrlGridDivision.SelectedValue = DIVN;
            CtrlGridDivision.SelectedText = TreeView1.SelectedNode.Text;

            int Dinsti = Convert.ToInt32(TreeView1.SelectedNode.Parent.Parent.Value);
            int Dcls = Convert.ToInt32(TreeView1.SelectedNode.Parent.Value);
            int Ddiv= Convert.ToInt32(TreeView1.SelectedNode.Value);
            int DStudent = Convert.ToInt32(CtrlGridStudent.SelectedValue);

            int Dinstallment = Convert.ToInt32(DdlInslment.SelectedValue);

            SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId=" + Dinsti + "and nClassId=" + Dcls + "and nDivisionId=" + Ddiv + "and nStudentId=" + DStudent + "and nInstallmentId=" + Dinstallment, con);

            //SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId=" + Dinsti + "and nClassId=" + Dcls + "and nDivisionId=" + Ddiv+ "and nInstallmentId=" + Dinstallment, con);
            viewgrid(cmd);

            //DdlStudent.Items.Add(new ListItem("Select", "0"));
            //DataTable ClsTC = (ObjCls.FnGetDataSet("select  TCD.nId nId, TCD.cName cName FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId = SAD.nStudentId where SAD.nDivisionId = " + DIVN) as DataSet).Tables[0];
            //DdlStudent.DataSource = ClsTC;
            //DdlStudent.DataValueField = "nId";
            //DdlStudent.DataTextField = "cName";
            //DdlStudent.DataBind();

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        int insti, cls, div;
        for (int i = 0; i <= GrdVwRecordsMain.Rows.Count - 1; i++)
        {
            Label LblDiv2 = (Label)GrdVwRecordsMain.Rows[i].FindControl("LblDiv2");
            string fname = LblDiv2.Text;

            CtrlDate tdate = (CtrlDate)GrdVwRecordsMain.Rows[i].FindControl("CtrlDate");
            //DateTime a = ObjCls.FnDateTime(tdate);


            DateTime a = DateTime.Now;
            
            
           

            //TextBox DueDate= (TextBox)GrdVwRecordsMain.Rows[i].FindControl("CtrldueDate");
            //FnDateTime(CtrldueDate.DateText);
            

            TextBox TxtAmt = (TextBox)GrdVwRecordsMain.Rows[i].FindControl("TxtAmount");
            string amt = TxtAmt.Text;
            TextBox TxtPer = (TextBox)GrdVwRecordsMain.Rows[i].FindControl("TxtPercentage");
            string per = TxtPer.Text;
            int dins = ObjCls.FnIsNumeric(DdlInslment.SelectedValue);
            //int stuid = ObjCls.FnIsNumeric(DdlStudent.SelectedValue);
            //int dins = ObjCls.FnIsNumeric(CtrlGridInstallment.SelectedValue);
            int stuid= ObjCls.FnIsNumeric(CtrlGridStudent.SelectedValue);     //kmn@federalbank.co.in
            if (((Label6.Text) != "") && ((Label7.Text) == "") && ((Label8.Text) == ""))
            {
                insti = Convert.ToInt32(Label6.Text);
                cls = 0;
                div = 0;
            }
            else if (((Label6.Text) != "") && ((Label7.Text) != "") && ((Label8.Text) == ""))
            {
                insti = Convert.ToInt32(Label6.Text);
                cls = Convert.ToInt32(Label7.Text);
                div = 0;
            }
            else
            {
                insti = Convert.ToInt32(Label6.Text);
                cls = Convert.ToInt32(Label7.Text);
                div = Convert.ToInt32(Label8.Text);

            }


            //viewgrid();



             SqlCommand cmd = new SqlCommand("Insert into TblFineSettings(nStudentId, nClassId, nDivisionId, nInstitutionId, nInstallmentId, cName, dDuedate, cAmount, cPercentage) VALUES(" + stuid + "," + cls + "," + div + "," + insti + "," + dins + ",'" + fname + "','" + a + "', " + amt + "," + per + ")", con);

            //SqlCommand cmd = new SqlCommand("Insert into TblFineSettings( nStudentId, nClassId, nDivisionId, nInstitutionId, cName, dDuedate, cAmount, cPercentage) VALUES(" + stuid + "," + cls + "," + div + "," + insti + ",'" + fname + "','" + a + "', " + amt + "," + per + ")", con);
            con.Open();

            int k = cmd.ExecuteNonQuery();
            con.Close();
            if (k == 1)
            {
                Response.Write("success");
            }
            else
            {
                Response.Write("failed");
            }

        }


    }

    protected void viewgrid(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        //int Dinsti = Convert.ToInt32(TreeView1.SelectedNode.Value);
        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        //SqlCommand cmd = new SqlCommand("select distinct nId Id, cName Name,dDuedate,cAmount,cPercentage from TblFineSettings where nInstitutionId=" + Dinsti, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        //dt = ViewState["DT"] as DataTable;
        //TextBox marks = (TextBox)GrdVwRecordsMain.Rows[i].FindControl("TxtAmount");
        int count = dt.Rows.Count;
        if (count > 1)
        {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GrdVwRecordsMain.DataSource = dt;
                GrdVwRecordsMain.DataBind();
                TextBox amount2 = (TextBox)GrdVwRecordsMain.Rows[i].FindControl("TxtAmount");
                TextBox per2 = (TextBox)GrdVwRecordsMain.Rows[i].FindControl("TxtPercentage");
                var amount3 = dt.Rows[i]["cAmount"];
                var per3 = dt.Rows[i]["cPercentage"];
                amount2.Text = amount3.ToString();
                per2.Text = per3.ToString();


            }
            GrdVwRecordsMain.DataSource = dt;
            GrdVwRecordsMain.DataBind();


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                TextBox amount = (TextBox)GrdVwRecordsMain.Rows[j].FindControl("TxtAmount");
                TextBox per = (TextBox)GrdVwRecordsMain.Rows[j].FindControl("TxtPercentage");
                var amount1 = dt.Rows[j]["cAmount"];
                var per1 = dt.Rows[j]["cPercentage"];
                amount.Text = amount1.ToString();
                per.Text = per1.ToString();
            }

        }
        else
        {
            FnGridViewBinding("");
        }
        con.Close();
    }
}