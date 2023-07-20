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


public partial class FIN_FeeAsgn : ClsPageEvents, IPageInterFace
{
    ClsFeeInstallmentMaster ObjCls = new ClsFeeInstallmentMaster();
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
               
            }
            fillInstallment();
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
            else if (ParentId == 2)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild2 = (ObjCls.FnGetDataSet("select  TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId=SAD.nStudentId where SAD.nDivisionId= " + tnode.Value) as DataSet).Tables[0];
                VS = 3;
                PopulateTreeView(dtChild2, VS, tnode);
            }
            else
            {
                treeNode.ChildNodes.Add(tnode);
            }
        }
    }

   
    [WebMethod]
    public static string InsertData(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount)
    {
        string msg = string.Empty;
        //string VV = TId;
        
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("Insert into TblFeeInstallmentAssignT(nFEEId, nINSSTALId, nINSTIId, nCLSId, nDIVId, nSTUDId, nAmount) VALUES(@nFEEId,@nINSSTALId,@nINSTIId,@nCLSId,@nDIVId,@nSTUDId,@nAmount)", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@nFEEId", nFEEId);
                cmd.Parameters.AddWithValue("@nINSSTALId", nINSSTALId);
                cmd.Parameters.AddWithValue("@nINSTIId", nINSTIId);
                cmd.Parameters.AddWithValue("@nCLSId", nCLSId);
                cmd.Parameters.AddWithValue("@nDIVId", nDIVId);
                cmd.Parameters.AddWithValue("@nSTUDId", nSTUDId);
                cmd.Parameters.AddWithValue("@nAmount", nAmount);
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
            }
        }
        return msg;
    }





    //public static string UpdateTble(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount, string TId)
    //{
    //    string msg = string.Empty;
    //    string VV = TId;

    //    using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("Insert_Customers"))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Connection = con;
    //            cmd.Parameters.AddWithValue("@tblCustomers", dt);
    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }
    //    return msg;
    //}




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

    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }


    protected void BtnFind_Click(object sender, EventArgs e)
    {
       //FnFindRecord();
        // GrdVwRecords.Focus()
        //fillInstallment();
    }

    public void fillInstallment()
    {
        DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName + cast(nId as char)  FROM TblFeeMaster") as DataSet).Tables[0];
        DataTable ClsTGFMC = (ObjCls.FnGetDataSet("SELECT nId FROM TblFeeMaster") as DataSet).Tables[0];
        GrdVwFee.DataSource = FlipDataTable(ClsTGFM, ClsTGF, ClsTGFMC);
        GrdVwFee.DataBind();

        //ViewState["DT1"] = GrdVwFee.DataSource;
        DataTable DDD = ViewState["DT1"] as DataTable;

    }


    public static DataTable FlipDataTable(DataTable dt, DataTable dt1,DataTable dt2)

    {
        DataRow dr;
        DataTable table = new DataTable();
        table.Columns.Add(Convert.ToString("nId"));
        table.Columns.Add(Convert.ToString("cName"));
        
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
        for (int j = 0; j <1; j++)
        {
            dr = table.NewRow();
            for (int k = 1; k <= dt1.Rows.Count; k++)
            {
               table.Rows.Add(Convert.ToString(dt1.Rows[k - 1][j]));
               var VD= (dt1.Rows[k - 1][j]).ToString();
                var VD1 = (dt1.Rows[k - 1][1]).ToString();
                //get feecode from table and assign to next line
                table.Rows[k - 1][1] = VD1;
            }
        }
        return table;
    }
        
        
    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 2; i < e.Row.Cells.Count; i++)
            {
                System.Web.UI.WebControls.TextBox txt = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(txt);

                System.Web.UI.WebControls.TextBox txt1 = new System.Web.UI.WebControls.TextBox() { ID = "T" + i };
                e.Row.Cells[i].Controls.Add(txt1);

                string CCD = GrdVwFee.HeaderRow.Cells[i].Text.Trim();
                CCD = CCD.Substring(CCD.Length - 1);
                txt1.Text = CCD;

                if (i== e.Row.Cells.Count)
                {
                    string CCD1 = CCD.Remove(CCD.Length - 1, 1);
                    GrdVwFee.HeaderRow.Cells[i].Text = CCD1;
                }
                int RR = (e.Row.RowIndex)+1;
                var LLL = txt.Text;
                ViewState["DT1"] = GrdVwFee.DataSource;
                txt.Attributes.Add("onkeyup", "Myfunction('" + txt.ClientID + "','" + TxtGrp.ClientID + "','" + TxtCls.ClientID  + "','" + TxtDiv.ClientID + "','" + TxtStd.ClientID + "','" + txt1.ClientID + "','" + RR + "')");
            }
        }

    }


    protected void txtDynamic_TextChanged(object sender, EventArgs e)
    {
        var Column1TextBoxes = Request.Form.AllKeys.Where(k => k.Contains("txtDynamic")).ToList();
        for (int i = 0; i < Column1TextBoxes.Count; i++)
        {
            string value = Request.Form[Column1TextBoxes[i]]; // Textbox values
        }
    }

    protected void GrdVwFee_RowUpdating(object sender, GridViewUpdatedEventArgs e)
    {
        var Column1TextBoxes = Request.Form.AllKeys.Where(k => k.Contains("txtDynamic")).ToList();
        for (int i = 0; i < Column1TextBoxes.Count; i++)
        {
            string value = Request.Form[Column1TextBoxes[i]]; // Textbox values
        }

    }

    protected void GrdVwFee_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
               
        var item = GrdVwFee.SelectedRow.Cells[1].Text;
        lblMessage.Text = item.ToString();

    }

    protected void GrdVwFee_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string commandName = e.CommandName;
        int rowIndex = Convert.ToInt32(e.CommandName);
        GridViewRow row = GrdVwFee.Rows[rowIndex];
        System.Web.UI.WebControls.TextBox txt = row.FindControl("TextBox1") as System.Web.UI.WebControls.TextBox;

        if (txt != null)
        {

        }
        string value = Request.Form[rowIndex];

    }



    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow r in GrdVwFee.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                for (int columnIndex = 0; columnIndex <
                    r.Cells.Count; columnIndex++)
                {
                    Page.ClientScript.RegisterForEventValidation(
                        r.UniqueID + "$ctl00", columnIndex.ToString());
                }
            }
        }

        base.Render(writer);

    }


    protected void GrdVwFee_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if(e.AffectedRows<1)
        {
            e.KeepInEditMode = true;
        }

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        var Column1TextBoxes = Request.Form.AllKeys.Where(k => k.Contains("txtDynamic")).ToList();
        for (int i = 0; i < Column1TextBoxes.Count; i++)
        {
            string value = Request.Form[Column1TextBoxes[i]]; // Textbox values
        }
    }

    protected void GrdVwFee_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        var Column1TextBoxes = Request.Form.AllKeys.Where(k => k.Contains("txtDynamic")).ToList();
        for (int i = 0; i < Column1TextBoxes.Count; i++)
        {
            string value = Request.Form[Column1TextBoxes[i]]; // Textbox values
        }
    }

    protected void GrdVwFee_SelectedIndexChanged(object sender, EventArgs e)
    {
        var Column1TextBoxes = Request.Form.AllKeys.Where(k => k.Contains("txtDynamic")).ToList();
        for (int i = 0; i < Column1TextBoxes.Count; i++)
        {
            string value = Request.Form[Column1TextBoxes[i]]; // Textbox values
        }

    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        var CLN = TreeView1.SelectedNode.Value;
        int IH = TreeView1.SelectedNode.Depth;
        string GRP, CLS, DIVN, STUD;
        if (TreeView1.SelectedNode.Depth==0)
        {
            //group
             GRP = TreeView1.SelectedNode.Value;
        }
        else if(TreeView1.SelectedNode.Depth == 1)
            {
            //Class
            GRP = TreeView1.SelectedNode.Parent.Value;
             CLS = TreeView1.SelectedNode.Value;
        }
        else if (TreeView1.SelectedNode.Depth == 2)
        {
            //Division
            GRP = TreeView1.SelectedNode.Parent.Parent.Value;
            CLS = TreeView1.SelectedNode.Parent.Value;
             DIVN = TreeView1.SelectedNode.Value;
        }
        else if (TreeView1.SelectedNode.Depth == 3)
        {
            //Student
            //GRP = TreeView1.SelectedNode.Parent.Parent.Parent.Value;
           // lblGrp.Text = TreeView1.SelectedNode.Parent.Parent.Parent.Value;
            TxtGrp.Text= TreeView1.SelectedNode.Parent.Parent.Parent.Value;
            CLS = TreeView1.SelectedNode.Parent.Parent.Value;
            lblCls.Text = TreeView1.SelectedNode.Parent.Parent.Value;
            TxtCls.Text = TreeView1.SelectedNode.Parent.Parent.Value;
            DIVN = TreeView1.SelectedNode.Parent.Value;
            lblDiv.Text = TreeView1.SelectedNode.Parent.Value;
            TxtDiv.Text = TreeView1.SelectedNode.Parent.Value;
            STUD = TreeView1.SelectedNode.Value;
            lblStd.Text = TreeView1.SelectedNode.Value;
            TxtStd.Text = TreeView1.SelectedNode.Value;
        }
        

        //if (TreeView1.SelectedNode)
        fillInstallment();
    }
}