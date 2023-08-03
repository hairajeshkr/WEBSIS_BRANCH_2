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
                FnFillInstallment();
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
                TreVwLst.Nodes.Add(tnode);
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
        //FnGridViewBinding("");
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
       // base.FnAssignProperty(ObjCls);
       // FnFindRecord(ObjCls);
        //FnGridViewBinding("");
        //TabContainer1.ActiveTabIndex = 1;
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwFee.DataSource = ViewState["DT"] as DataTable;
        GrdVwFee.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwFee.DataBind();
        GrdVwFee.SelectedIndex = -1;
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
                    FnFillInstallment();
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
    public void FnFillInstallment()
    {
        //DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DataTable DTInstallment = (ObjCls.FnGetDataSet("SELECT nId,cName, CONVERT(varchar,GETDATE(),106) FromDate, CONVERT(varchar,GETDATE(),106) DueDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        //DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName + cast(nId as char)  FROM TblFeeMaster") as DataSet).Tables[0];
        DataTable DTFeeName = (ObjCls.FnGetDataSet("SELECT cName  FROM TblFeeMaster") as DataSet).Tables[0];
        DataTable DTFeeId = (ObjCls.FnGetDataSet("SELECT nId FROM TblFeeMaster") as DataSet).Tables[0];

        GrdVwFee.DataSource = FnFlipDataTable(DTFeeName, DTInstallment, DTFeeId);
        GrdVwFee.DataBind();
        GrdVwFee.Rows[0].Visible = false;

        ViewState["DT1"] = GrdVwFee.DataSource;
        DataTable DDD = ViewState["DT1"] as DataTable;

    }



    public static DataTable FnFlipDataTable(DataTable DTFeeName, DataTable DTInstallment, DataTable DTFeeId)

    {
        int j = 0, i = 0, k = 0,h=0;
        DataRow dr;
        DataTable table = new DataTable();
        table.Columns.Add(Convert.ToString("nId"));
        table.Columns.Add(Convert.ToString("cName"));
        table.Columns.Add(Convert.ToString("FromDate"));
        table.Columns.Add(Convert.ToString("DueDate"));
        //Get all the rows and change into columns
        for (j = 0; j < DTFeeName.Columns.Count; j++)
        {
            dr = table.NewRow();
            for (i = 0; i <= (DTFeeName.Rows.Count - 1); i++)
            {
                table.Columns.Add(Convert.ToString(DTFeeName.Rows[i][j]));
            }
        }

        //get all the columns and make it as rows
        for (j = 0; j < 1; j++)
        {
            dr = table.NewRow();
            table.Rows.Add(Convert.ToString(0));
            for (k = 1; k <= DTInstallment.Rows.Count; k++)
            {
                table.Rows.Add(Convert.ToString(DTInstallment.Rows[k - 1][j]));
                var VD = (DTInstallment.Rows[k - 1][j]).ToString();
                var VD1 = (DTInstallment.Rows[k - 1][1]).ToString();
                var VD2 = (DTInstallment.Rows[k - 1][2]).ToString();
                var VD3 = (DTInstallment.Rows[k - 1][3]).ToString();
                table.Rows[k][1] = VD1;
                table.Rows[k][2] = VD2;
                table.Rows[k][3] = VD3;
            }



            for (h = 1; h <= DTFeeId.Rows.Count; h++)
            {

                var VD2 = (DTFeeId.Rows[h - 1][j]).ToString();
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

            var InsGrpId = lblGrpId.Text;
            var ClsId = lblClsId.Text;
            var DivId = lblDivId.Text;

            var StudId = CtrlGrdStudent.SelectedValue;

            ViewState["DT1"] = GrdVwFee.DataSource;
            DataTable DDD = ViewState["DT1"] as DataTable;



            for (int i = 4; i < e.Row.Cells.Count; i++)
            {

                System.Web.UI.WebControls.TextBox TxtAmount = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(TxtAmount);


                int RowIndx = e.Row.RowIndex;
                
                
                var FeeId = Convert.ToString(DDD.Rows[0][i]);
               

                string sqlquery = "select nAccLedgerId from TblFeeMaster where nId=" + FeeId;
                int AccLedgerId = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery).ToString());


                string sqlquery2= "select nOrderIndex from TblFeeMaster where nId=" + FeeId;
                int OrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery2).ToString());


                TxtAmount.Attributes.Add("onchange", "Myfunction('" + TxtAmount.ClientID + "','" + InsGrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FeeId + "','" + RowIndx + "','"+ iAcId +"','"+ iBrId +"','" +iCmpId+ "','"+ iFaId+ "','"+ AccLedgerId + "','" + OrderIndex + "')");

                
                
            }
            
        }

        



    }



    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        //var CLN = TreVwLst.SelectedNode.Value;
        //int IH = TreVwLst.SelectedNode.Depth;
        if (TreVwLst.SelectedNode.Depth == 0)
        {
            
            lblGrpId.Text = TreVwLst.SelectedNode.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Value;
            CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Text;

            CtrlGrdClass.SelectedValue = "";
            CtrlGrdClass.SelectedText = "";
            CtrlGrdDiv.SelectedValue = "";
            CtrlGrdDiv.SelectedText = "";
        }
        else if (TreVwLst.SelectedNode.Depth == 1)
        {
            lblGrpId.Text = TreVwLst.SelectedNode.Parent.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
            CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Text;
            lblClsId.Text = TreVwLst.SelectedNode.Value;
            lblClsId.Visible = false;
            CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Value;
            CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Text;
            CtrlGrdDiv.SelectedValue = "";
            CtrlGrdDiv.SelectedText = "";
        }
        else if (TreVwLst.SelectedNode.Depth == 2)
        {
            lblGrpId.Text = TreVwLst.SelectedNode.Parent.Parent.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Parent.Value;
            CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Parent.Text;
            lblClsId.Text = TreVwLst.SelectedNode.Parent.Value;
            lblClsId.Visible = false;
            CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
            CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Parent.Text;
            lblDivId.Text = TreVwLst.SelectedNode.Value;
            lblDivId.Visible = false;
            CtrlGrdDiv.SelectedValue = TreVwLst.SelectedNode.Value;
            CtrlGrdDiv.SelectedText = TreVwLst.SelectedNode.Text;

        }


        //if (TreeView1.SelectedNode)
        FnFillInstallment();
        DataTable DDD = ViewState["DT1"] as DataTable;
        //FillGrd(DDD, lblGrpId.Text, lblClsId.Text, lblDivId.Text);
    }

    public void FnFillGrd(DataTable DDD, string nINSTIId, string nCLSId, string nDIVId)
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