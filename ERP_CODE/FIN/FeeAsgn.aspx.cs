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

    public String GRDS,FFF;
    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            
            if (!IsPostBack)
            {
                lblGrpId.Text = "0";
                lblClsId.Text = "0";
                lblDivId.Text = "0";
                FnInitializeForm();
                
                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);
               FnfillInstallment();
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
    public static string InsertData(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount, string iCmpId, string iBrId, string iFaId, string iAcId,string nAccLedgerId,string nOrderIndex)
    {
        string msg = string.Empty;
        
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        
           SqlCommand cmd = new SqlCommand("Insert into TblFeeAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount,nCompanyId, nBranchId, nFaId,nAcId,nAccLedgerId,nOrderIndex) VALUES(" + nFEEId + ","+ nINSSTALId + ","+ nINSTIId + ","+ nCLSId + ","+ nDIVId + ","+ nSTUDId + ","+ nAmount + "," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + "," + nAccLedgerId + "," + nOrderIndex + ")", con);
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
        // FnfillInstallment();
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

        
        CtrlGrdInstitute.SelectedValue = "0";
        CtrlGrdInstitute.SelectedText = "";

        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";

        CtrlGrdDiv.SelectedValue = "0";
        CtrlGrdDiv.SelectedText = "";

        CtrlGrdStudent.SelectedValue = "0";
        CtrlGrdStudent.SelectedText = "";

        FnFocus(CtrlGrdInstitute.ControlTextBox);
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
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
                            {
                                using (SqlCommand cmd = new SqlCommand("ProInsertMainGrd", con))
                                {
                                    con.Open();
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    int i = cmd.ExecuteNonQuery();
                                    con.Close();

                                }

                            }
                            FnfillInstallment();
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


    protected void BtnFind_Click(object sender, EventArgs e)
    {
        //FnFindRecord();
        // GrdVwRecords.Focus()
        //FnfillInstallment();
    }

    public void FnfillInstallment()
    {
        
        DataTable ClsTGFI = (ObjCls.FnGetDataSet("SELECT nId,cName, CONVERT(varchar,GETDATE(),106) FromDate, CONVERT(varchar,GETDATE(),106) DueDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        
        DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName,nId  FROM TblFeeMaster") as DataSet).Tables[0];
       
        GrdVwFee.DataSource = FnflipDataTable(ClsTGFM, ClsTGFI);
        ViewState["DT1"] = GrdVwFee.DataSource;
        GrdVwFee.DataBind();
     
        DataTable DDD = ViewState["DT1"] as DataTable;
        
    }

    public static DataTable FnflipDataTable(DataTable dtFeeName, DataTable dtInstll)

    {
        int i, j, k,h;
        //var VD, VD1, VD2, VD3, VD4;
        DataRow dr;
        DataTable table = new DataTable();
        //table.Columns.Add(Convert.ToString("nId"));
        //table.Columns.Add(Convert.ToString("cName"));
        //table.Columns.Add(Convert.ToString("FromDate"));
        //table.Columns.Add(Convert.ToString("DueDate"));


        for (i = 0; i <= (dtFeeName.Rows.Count - 1); i++)
        {
            //dr = table.NewRow();

            for (j = 0; j < dtFeeName.Columns.Count; j++)
            {
                dtInstll.Columns.Add(Convert.ToString(dtFeeName.Rows[i][j]));
            // dtInstll.Columns.Add(Convert.ToString(dtFeeName.Rows[1][i]));
            }
        }

        table = dtInstll;


        //Get all the rows and change into columns

        //for (i = 0; i <= (dtFeeName.Rows.Count - 1); i++)
        //{
        //    //dr = table.NewRow();

        //    for (j = 0; j < dtFeeName.Columns.Count; j++)
        //    {
        //        table.Columns.Add(Convert.ToString(dtFeeName.Rows[i][j]));
        //    }
        //}


        //for (j = 0; j < 1; j++)
        //{
        //    //dr = table.NewRow();
            
        //    for (k = 0; k <= dtInstll.Rows.Count-1; k++)
        //    {
               
        //        table.Rows.Add(Convert.ToString(dtInstll.Rows[k][j]));

        //        var VD = (dtInstll.Rows[k][j]).ToString();
        //        var VD1 = (dtInstll.Rows[k][1]).ToString();
        //        var VD2 = (dtInstll.Rows[k][2]).ToString();
        //        var VD3 = (dtInstll.Rows[k][3]).ToString();
        //        //get feecode from table and assign to next line

        //        table.Rows[k][1] = VD1;
        //        table.Rows[k][2] = VD2;
        //        table.Rows[k][3] = VD3;
        //    }
        //}


      
        //get all the columns and make it as rows

        return table;
    }
        
        
    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            CtrlDate CtrlFromDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[2].Controls.Add(CtrlFromDate);
            CtrlFromDate.ID = "C";

            CtrlDate CtrlDueDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[3].Controls.Add(CtrlDueDate);

            var FromD = CtrlFromDate.DateText;
            var DueD = CtrlDueDate.DateText;

            CtrlDate FromDC = (CtrlDate)e.Row.FindControl("CtrlFromDate");
            CtrlDate FromDD = (CtrlDate)e.Row.FindControl("CtrlDueDate");
            
            int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

            //var GrpId = lblGrpId.Text;
            //var ClsId = lblClsId.Text;
            //var DivId = lblDivId.Text;
            int RR;
           // ViewState["DT1"] = GrdVwFee.DataSource;
            DataTable DDD = ViewState["DT1"] as DataTable;
            //var StudId = CtrlGrdStudent.SelectedValue.ToString();

            var GrpId = CtrlGrdInstitute.IdControl;
            var ClsId = CtrlGrdClass.IdControl;
            var DivId = CtrlGrdDiv.IdControl;
            var StudId = CtrlGrdStudent.IdControl;

            var GrpIdF = CtrlGrdInstitute.SelectedValue;
            var ClsIdF = CtrlGrdClass.SelectedValue;
            var DivIdF = CtrlGrdDiv.SelectedValue;
            var StudIdF = CtrlGrdStudent.SelectedValue;

            for (int i = 4; i < e.Row.Cells.Count; i+=2)
            {

               System.Web.UI.WebControls.TextBox TxtAmount = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(TxtAmount);

                HiddenField TXTID = new HiddenField();
                e.Row.Cells[i + 1].Controls.Add(TXTID);
                TXTID.Value = GrdVwFee.HeaderRow.Cells[i + 1].Text;
                var FEEID = TXTID.Value;

                GrdVwFee.HeaderRow.Cells[i + 1].Visible = false;
                e.Row.Cells[i + 1].Visible = false;

                // txt.AutoPostBack = false;

                // SqlCommand cmd = new SqlCommand("select  isnull(nAmount,0) from TblFeeAssign where nInstituteGrpId=isnull(" + GrpId + ",0) and nClassId=isnull(" + ClsId + ",0) and nDivisionId=isnull(" + DivId + ",0) and nStudentId=isnull(" + StudId + ",0) and nInstalmentId =isnull(" + e.Row.Cells[0].Text + ",0) and nFeeMasterId = isnull(" + FEEID +",0)", con);


                SqlCommand cmd = new SqlCommand("select  isnull(nAmount,0) from TblFeeAssign where nInstituteGrpId=" + GrpIdF + " and nClassId=" + ClsIdF + " and nDivisionId=" + DivIdF + " and nStudentId=" + StudIdF + " and nInstalmentId =" + e.Row.Cells[0].Text + " and nFeeMasterId = " + FEEID + "", con);
                con.Open();
                var VV = cmd.ExecuteScalar();
                con.Close();
                if (VV == null)
                {
                    TxtAmount.Text = "0";

                }
                else
                {
                    TxtAmount.Text = VV.ToString();
                }




                // TxtAmount.Text = AMTV.ToString();


                RR = (e.Row.RowIndex)+1 ;
                var LLL = TxtAmount.Text;

               

                string strsqlAc = "SELECT nAccLedgerId FROM TblFeeMaster WHERE nId=" + FEEID;
                var nAccLedgerId = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(strsqlAc).ToString());
         
                string strsqlOi = "SELECT nOrderIndex FROM TblFeeMaster WHERE nId=" + FEEID;
                var nOrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(strsqlOi).ToString());
                
                TxtAmount.Attributes.Add("onchange", "Myfunction('" + TxtAmount.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FEEID + "','" + RR + "','" + CtrlFromDate.ClientID + "','" + CtrlDueDate.ClientID + "','" + iCmpId + "','" + iBrId + "','" + iFaId + "','" + iAcId + "','" + nAccLedgerId + "','" + nOrderIndex + "')");

                CtrlFromDate.Attributes.Add("onclick", "DateGetF('"+ CtrlFromDate.ClientID  + "')");
                
            }

         
            }


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

    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        var CLN = TreVwLst.SelectedNode.Value;
        int IH = TreVwLst.SelectedNode.Depth;
        try
        {
            FnCancel();
            if (TreVwLst.SelectedNode.Depth == 0)
            {
                //group

                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Text;

            }
            else if (TreVwLst.SelectedNode.Depth == 1)
            {
                //Class

                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Text;
                CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Text;

            }
            else if (TreVwLst.SelectedNode.Depth == 2)
            {
                //Division


                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Parent.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Parent.Text;

                CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Parent.Text;

                CtrlGrdDiv.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdDiv.SelectedText = TreVwLst.SelectedNode.Text;

            }
            FnfillInstallment();
            DataTable DDD = ViewState["DT1"] as DataTable;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    public void FillGrd( string nINSTIId, string nCLSId, string nDIVId)
    {
        string msg = string.Empty;
        //string VV = TId;
        DataTable DDT = new DataTable();
        var StudIID = CtrlGrdStudent.SelectedValue;
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPTestT3", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@EmptableT", DDD);
                cmd.Parameters.AddWithValue("@nINSTIId", nINSTIId);
                cmd.Parameters.AddWithValue("@nCLSId", nCLSId);
                cmd.Parameters.AddWithValue("@nDIVId", nDIVId);
                cmd.Parameters.AddWithValue("@nStudIID", StudIID);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(DDT);
                }
            }


            ViewState["DT2"] = DDT;
        }


    }



    

    public void UpdateGridcell(string amount,int RowG,string ColumnG)
    {
        GrdVwFee.Rows[Convert.ToInt32(RowG)].Cells[Convert.ToInt32(ColumnG)].Text = amount.ToString();
        var CDSA = GrdVwFee.Rows[Convert.ToInt32(RowG)].Cells[Convert.ToInt32(ColumnG)].Text;
    }










    protected void cmdFill_Click(object sender, EventArgs e)
    {

        FnfillInstallment();
       
       // FillGrd( lblGrpId.Text, lblClsId.Text, lblDivId.Text);
    }
}