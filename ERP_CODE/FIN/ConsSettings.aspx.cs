using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

//using System.Windows.Forms;


public partial class FIN_ConsSettings : ClsPageEvents, IPageInterFace
{
    ClsFeeMaster ObjCls = new ClsFeeMaster();
    ClsDropdownRecordList objLst = new ClsDropdownRecordList();

    public String GRDS;
    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            if (!IsPostBack)
            {
                FnInitializeForm();

                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);
                fillInstallment();
            }
            CtrlGrdClass.ParentControl = CtrlGrdInstitute.IdControl;
            CtrlGrdDiv.ParentControl = CtrlGrdClass.IdControl;
            CtrlGrdStudent.ParentControl = CtrlGrdDiv.IdControl;
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
                TreeView1.Nodes.Add(tnode);
                DataTable dtChild = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId= " + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(dtChild, VS, tnode);
            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild1 = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN'and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(dtChild1, VS, tnode);
            }
            //else if (ParentId == 2)
            //{
            //    treeNode.ChildNodes.Add(tnode);
            //    DataTable dtChild2 = (ObjCls.FnGetDataSet("select  TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId=SAD.nStudentId where SAD.nDivisionId= " + tnode.Value) as DataSet).Tables[0];
            //    VS = 3;
            //    PopulateTreeView(dtChild2, VS, tnode);
            //}
            else
            {
                treeNode.ChildNodes.Add(tnode);
            }
        }
    }


    [WebMethod]
    public static string InsertData(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount,int AcId,int BrId,int CmpId,int FaId,int AccLedgerId,int OrderIndex)
    {
        string msg = string.Empty;
            
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("Insert into TblFeeConcessionAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount,nAcId,nBranchId,nAccCmpId,nFaId,nAccLedgerId,nOrderIndex) VALUES(" + nFEEId + "," + nINSSTALId + "," + nINSTIId + "," + nCLSId + "," + nDIVId + "," + nSTUDId + "," + nAmount + ","+AcId+","+BrId+","+CmpId+","+FaId+","+AccLedgerId+ "," + OrderIndex + ")", con);
            
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 1)
                {
                    msg = "true";
                }
                else
                {
                    msg = "false";
                }
            
        
        return msg;
    }





    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        // fillInstallment();
    }


    public void FnAssignProperty()
    {

        base.FnAssignProperty(ObjCls);
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
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
        //GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        //GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //GrdVwRecords.DataBind();
        //GrdVwRecords.SelectedIndex = -1;
    }

    public void FnPrintRecord()
    {
        throw new NotImplementedException();
    }

    //public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    //{
    //    throw new NotImplementedException();
    //}


    //protected void BtnFind_Click(object sender, EventArgs e)
    //{
    //    //FnFindRecord();
    //    // GrdVwRecords.Focus()
    //    //fillInstallment();
    //}
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
                            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
                            {
                                using (SqlCommand cmd = new SqlCommand("ProInsertMainGrd", con))
                                {
                                    con.Open();
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    int i = cmd.ExecuteNonQuery();
                                    con.Close();

                                }

                            }
                            break;
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
    public void fillInstallment()
    {
        //DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId,cName, CONVERT(varchar,GETDATE(),106) FromDate, CONVERT(varchar,GETDATE(),106) DueDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        //DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName + cast(nId as char)  FROM TblFeeMaster") as DataSet).Tables[0];
        DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName  FROM TblFeeMaster") as DataSet).Tables[0];
        DataTable ClsTGFMC = (ObjCls.FnGetDataSet("SELECT nId FROM TblFeeMaster") as DataSet).Tables[0];

        GrdVwFee.DataSource = FlipDataTable(ClsTGFM, ClsTGF, ClsTGFMC);
        GrdVwFee.DataBind();
        GrdVwFee.Rows[0].Visible = false;

        ViewState["DT1"] = GrdVwFee.DataSource;
        DataTable DDD = ViewState["DT1"] as DataTable;

    }











    public static DataTable FlipDataTable(DataTable dt, DataTable dt1, DataTable dt2)

    {
        DataRow dr;
        DataTable table = new DataTable();
        table.Columns.Add(Convert.ToString("nId"));
        table.Columns.Add(Convert.ToString("cName"));
        table.Columns.Add(Convert.ToString("FromDate"));
        table.Columns.Add(Convert.ToString("DueDate"));
        //Get all the rows and change into columns
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            dr = table.NewRow();
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)
            {
                table.Columns.Add(Convert.ToString(dt.Rows[i][j]));
            }
        }

        //get all the columns and make it as rows
        for (int j = 0; j < 1; j++)
        {
            dr = table.NewRow();
            //dr = table.NewRow();
            table.Rows.Add(Convert.ToString(0));
            for (int k = 1; k <= dt1.Rows.Count; k++)
            {
                //table.Rows.Add(Convert.ToString(0));
                table.Rows.Add(Convert.ToString(dt1.Rows[k - 1][j]));
                //table.Rows.Add(Convert.ToString(dt1.Rows[k][j]));
                var VD = (dt1.Rows[k - 1][j]).ToString();
                var VD1 = (dt1.Rows[k - 1][1]).ToString();
                var VD2 = (dt1.Rows[k - 1][2]).ToString();
                var VD3 = (dt1.Rows[k - 1][3]).ToString();
                //get feecode from table and assign to next line
                //table.Rows[k - 1][1] = VD1;
                table.Rows[k][1] = VD1;
                table.Rows[k][2] = VD2;
                table.Rows[k][3] = VD3;
            }



            for (int h = 1; h <= dt2.Rows.Count; h++)
            {

                //table.Rows.Add(Convert.ToString(dt1.Rows[k - 1][j]));

                var VD2 = (dt2.Rows[h - 1][j]).ToString();
                //var VD1 = (dt1.Rows[k - 1][1]).ToString();

                // table.Rows[0][h+1] = VD2;
                table.Rows[0][h + 3] = VD2;
            }


        }
        return table;
    }


    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            CtrlDate CtrlFromDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[2].Controls.Add(CtrlFromDate);
            CtrlFromDate.ID = "txtdate";


            CtrlDate CtrlDueDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[3].Controls.Add(CtrlDueDate);

            int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;


            for (int i = 4; i < e.Row.Cells.Count; i++)
            {

                System.Web.UI.WebControls.TextBox txt = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(txt);

                System.Web.UI.WebControls.TextBox txt1 = new System.Web.UI.WebControls.TextBox() { ID = "T" + i };
                e.Row.Cells[i].Controls.Add(txt1);

                DataTable DDDR = ViewState["DT2"] as DataTable;
                //txt.Text = Convert.ToString(DDDR.Rows[i][i]);

                int RR = e.Row.RowIndex;
                var LLL = txt.Text;
                ViewState["DT1"] = GrdVwFee.DataSource;
                DataTable DDD = ViewState["DT1"] as DataTable;
                txt1.Text = Convert.ToString(DDD.Rows[0][i]);
                //var INSSS = GrdVwFee.HeaderRow.Cells[1].Text;

                string sqlquery = "select nAccLedgerId from TblFeeMaster where nId=" + txt1.Text;
                int accledgerid = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery).ToString());


                string sqlquery2= "select nOrderIndex from TblFeeMaster where nId=" + txt1.Text;
                int OrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery2).ToString());


                var INSSS = e.Row.Cells[0].Text;
                var INSSSN = e.Row.Cells[1].Text;
                var GrpId = lblGrpId.Text;
                var ClsId = lblClsId.Text;
                var DivId = lblDivId.Text;

                var FDT = lblMessage.Text;
                // var StudId = String.IsNullOrEmpty(CtrlGrdStudent.SelectedValue);
                var StudId = CtrlGrdStudent.SelectedValue;

                //var date1 = CtrlFromDate.ClientID;

                txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "','"+ iAcId +"','"+ iBrId +"','" +iCmpId+ "','"+ iFaId+ "','"+accledgerid+ "','" + OrderIndex + "')");

                //txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "','" + CtrlFromDate.ID+ "','" + CtrlDueDate.ID+ "')");
                
            }
            
        }

        



    }



    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        var CLN = TreeView1.SelectedNode.Value;
        int IH = TreeView1.SelectedNode.Depth;
        string GRP, CLS, DIVN;
        if (TreeView1.SelectedNode.Depth == 0)
        {
            //group
            GRP = TreeView1.SelectedNode.Value;
            //TxtGrp.Text = TreeView1.SelectedNode.Value;
            lblGrp.Text = "-->" + TreeView1.SelectedNode.Text;
            lblGrpId.Text = TreeView1.SelectedNode.Value;
            lblGrpId.Visible = false;
            lblCls.Text = "";
            lblDiv.Text = "";
            CtrlGrdInstitute.SelectedValue = TreeView1.SelectedNode.Value;
            CtrlGrdInstitute.SelectedText = TreeView1.SelectedNode.Text;

            CtrlGrdClass.SelectedValue = "";
            CtrlGrdClass.SelectedText = "";
            CtrlGrdDiv.SelectedValue = "";
            CtrlGrdDiv.SelectedText = "";
        }
        else if (TreeView1.SelectedNode.Depth == 1)
        {
            //Class
            GRP = TreeView1.SelectedNode.Parent.Value;
            //TxtGrp.Text = TreeView1.SelectedNode.Parent.Value;
            lblGrp.Text = "-->" + TreeView1.SelectedNode.Parent.Text;
            lblGrpId.Text = TreeView1.SelectedNode.Parent.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreeView1.SelectedNode.Parent.Value;
            CtrlGrdInstitute.SelectedText = TreeView1.SelectedNode.Parent.Text;
            CLS = TreeView1.SelectedNode.Value;
            // TxtCls.Text = TreeView1.SelectedNode.Value;
            lblCls.Text = "-->" + TreeView1.SelectedNode.Text;
            lblClsId.Text = TreeView1.SelectedNode.Value;
            lblClsId.Visible = false;
            lblDiv.Text = "";
            CtrlGrdClass.SelectedValue = TreeView1.SelectedNode.Value;
            CtrlGrdClass.SelectedText = TreeView1.SelectedNode.Text;
            CtrlGrdDiv.SelectedValue = "";
            CtrlGrdDiv.SelectedText = "";
        }
        else if (TreeView1.SelectedNode.Depth == 2)
        {
            //Division
            GRP = TreeView1.SelectedNode.Parent.Parent.Value;
            //TxtGrp.Text = TreeView1.SelectedNode.Parent.Parent.Value;
            lblGrp.Text = "-->" + TreeView1.SelectedNode.Parent.Parent.Text;
            lblGrpId.Text = TreeView1.SelectedNode.Parent.Parent.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreeView1.SelectedNode.Parent.Parent.Value;
            CtrlGrdInstitute.SelectedText = TreeView1.SelectedNode.Parent.Parent.Text;
            CLS = TreeView1.SelectedNode.Parent.Value;
            // TxtCls.Text = TreeView1.SelectedNode.Parent.Value;
            lblCls.Text = "-->" + TreeView1.SelectedNode.Parent.Text;
            lblClsId.Text = TreeView1.SelectedNode.Parent.Value;
            lblClsId.Visible = false;
            CtrlGrdClass.SelectedValue = TreeView1.SelectedNode.Parent.Value;
            CtrlGrdClass.SelectedText = TreeView1.SelectedNode.Parent.Text;
            DIVN = TreeView1.SelectedNode.Value;
            //TxtDiv.Text = TreeView1.SelectedNode.Value;
            lblDiv.Text = "-->" + TreeView1.SelectedNode.Text;
            lblDivId.Text = TreeView1.SelectedNode.Value;
            lblDivId.Visible = false;
            CtrlGrdDiv.SelectedValue = TreeView1.SelectedNode.Value;
            CtrlGrdDiv.SelectedText = TreeView1.SelectedNode.Text;

            //DdlStudent.DataSource =

            //objLst.FnGetStudentList(Convert.ToInt32(GRP), Convert.ToInt32(CLS), Convert.ToInt32(DIVN));


            //DdlStudent.Enabled = true;
            //DdlStudent.Items.Clear();

            //DdlStudent.Items.Add(new ListItem("Select", "0"));
            //DataTable ClsTC = (ObjCls.FnGetDataSet("select  TCD.nId nId, TCD.cName cName FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId = SAD.nStudentId where SAD.nDivisionId = " + DIVN) as DataSet).Tables[0];
            //DdlStudent.DataSource = ClsTC;
            //DdlStudent.DataValueField = "nId";
            //DdlStudent.DataTextField = "cName";
            //DdlStudent.DataBind();

        }
        //else if (TreeView1.SelectedNode.Depth == 3)
        //{
        //    //Student
        //    //GRP = TreeView1.SelectedNode.Parent.Parent.Parent.Value;
        //   // lblGrp.Text = TreeView1.SelectedNode.Parent.Parent.Parent.Value;
        //    TxtGrp.Text= TreeView1.SelectedNode.Parent.Parent.Parent.Value;

        //    CLS = TreeView1.SelectedNode.Parent.Parent.Value;
        //    lblCls.Text = TreeView1.SelectedNode.Parent.Parent.Value;

        //    lblCls.Text = TreeView1.SelectedNode.Parent.Parent.Text;


        //    TxtCls.Text = TreeView1.SelectedNode.Parent.Parent.Value;
        //    DIVN = TreeView1.SelectedNode.Parent.Value;
        //    lblDiv.Text = TreeView1.SelectedNode.Parent.Value;
        //    TxtDiv.Text = TreeView1.SelectedNode.Parent.Value;
        //    STUD = TreeView1.SelectedNode.Value;
        //    lblStd.Text = TreeView1.SelectedNode.Value;
        //    TxtStd.Text = TreeView1.SelectedNode.Value;
        //}



        //if (TreeView1.SelectedNode)
        fillInstallment();
        //TreeView1.Attributes.Add("OnSelectedNodeChanged", "FillGrid('" + TxtGrp.ClientID + "','" + TxtCls.ClientID + "','" + TxtDiv.ClientID + "','" + TxtStd.ClientID + "')");

        //string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount
        DataTable DDD = ViewState["DT1"] as DataTable;
        //FillGrd(DDD, lblGrpId.Text, lblClsId.Text, lblDivId.Text);
    }

    public void FillGrd(DataTable DDD, string nINSTIId, string nCLSId, string nDIVId)
    {
        string msg = string.Empty;
        //string VV = TId;
        DataTable DDT = new DataTable();

        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPTestT", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmptableT", DDD);
                cmd.Parameters.AddWithValue("@nINSTIId", nINSTIId);
                cmd.Parameters.AddWithValue("@nCLSId", nCLSId);
                cmd.Parameters.AddWithValue("@nDIVId", nDIVId);
                //int i = cmd.ExecuteNonQuery();
                con.Close();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(DDT);
                }
            }



            //GrdVwFee.DataSource = DDT;
            //GrdVwFee.DataBind();
            ViewState["DT2"] = DDT;
        }


    }





    
   

}