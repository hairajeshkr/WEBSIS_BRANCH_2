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
    Label LblID = null, LblFeeName = null, LblIID=null, LblName=null;
    TextBox txtAmount = null;
    CtrlDate CtrlFromDate = null, CtrlDueDate = null;
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
            CtrlCommand1.IsVisibleDelete = false;


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
                case "DELETE":
                    DeleteData();
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

        DataTable ClsTGFI = (ObjCls.FnGetDataSet("SELECT nId ID,cName, dStartDate FromDate, dEndDate DueDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        GrdVwIns.DataSource = ClsTGFI;
        GrdVwIns.DataBind();
        DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT nId ID,cName FeeName,0 Amount  FROM TblFeeMaster") as DataSet).Tables[0];
        
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
           // FnfillInstallment();
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



    protected void cmdFill_Click(object sender, EventArgs e)
    {
        CtrlCommand1.IsVisibleDelete = true;
        FnfillInstallment();
       
       // FillGrd( lblGrpId.Text, lblClsId.Text, lblDivId.Text);
    }

    protected void GrdVwIns_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GrdVwFees = (GridView)e.Row.FindControl("GrdVwRecordsF");
            if (GrdVwFees != null)
            {
                
                DataTable dtFees = (ObjCls.FnGetDataSet("SELECT nId ID,cName FeeName,0 Amount  FROM TblFeeMaster  ") as DataSet).Tables[0];
                GrdVwFees.DataSource = dtFees;
                GrdVwFees.DataBind();

            }

        }

    }

    protected void GrdVwRecordsF_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

            var GrpId = CtrlGrdInstitute.IdControl;
            var ClsId = CtrlGrdClass.IdControl;
            var DivId = CtrlGrdDiv.IdControl;
            var StudId = CtrlGrdStudent.IdControl;

            var GrpIdF = CtrlGrdInstitute.SelectedValue;
            var ClsIdF = CtrlGrdClass.SelectedValue;
            var DivIdF = CtrlGrdDiv.SelectedValue;
            var StudIdF = CtrlGrdStudent.SelectedValue;

            string INSID = ((Label)e.Row.Parent.Parent.Parent.FindControl("LblIID")).Text;
            string INSNAM = ((Label)e.Row.Parent.Parent.Parent.FindControl("LblName")).Text;
            string FEEID = ((Label)e.Row.FindControl("LblID")).Text;
            string FEENAME = ((Label)e.Row.FindControl("FeeName")).Text;
            TextBox FEEAMT = ((TextBox)e.Row.FindControl("txtAmount"));

            CtrlDate FromDC = (CtrlDate)e.Row.Parent.Parent.Parent.FindControl("CtrlFromDate");
            CtrlDate DueDC = (CtrlDate)e.Row.Parent.Parent.Parent.FindControl("CtrlDueDate");

            string strsqlAc = "SELECT nAccLedgerId FROM TblFeeMaster WHERE nId=" + FEEID;
            var nAccLedgerId = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(strsqlAc).ToString());

            string strsqlOi = "SELECT nOrderIndex FROM TblFeeMaster WHERE nId=" + FEEID;
            var nOrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(strsqlOi).ToString());



            SqlCommand cmd = new SqlCommand("select  isnull(nAmount,0) from TblFeeAssign where nInstituteGrpId=" + GrpIdF + " and nClassId=" + ClsIdF + " and nDivisionId=" + DivIdF + " and nStudentId=" + StudIdF + " and nInstalmentId =" + INSID + " and nFeeMasterId = " + FEEID + "", con);
            con.Open();
            var VV = cmd.ExecuteScalar();
            con.Close();
            if (VV == null)
            {
                FEEAMT.Text = "0";

            }
            else
            {
                FEEAMT.Text = VV.ToString();
            }

            //FEEAMT.Attributes.Add("onchange", "Myfunction('" + FEEAMT.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FEEID + "','" + INSID + "','" + iCmpId + "','" + iBrId + "','" + iFaId + "','" + iAcId + "','" + nAccLedgerId + "','" + nOrderIndex + "')");
            FEEAMT.Attributes.Add("onchange", "Myfunction('" + FEEAMT.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FEEID + "','" + INSID + "','" + iCmpId + "','" + iBrId + "','" + iFaId + "','" + iAcId + "','" + nAccLedgerId + "','" + nOrderIndex + "','" + FromDC.ClientID + "','" + DueDC.ClientID + "')");
            
        }

    }




    public void DeleteData()
    {
        string msg = string.Empty;
        //string VV = TId;
        DataTable DDT = new DataTable();
        var StudIIDD = CtrlGrdStudent.SelectedValue;
        var nINSTIIdD = CtrlGrdInstitute.SelectedValue;
        var nCLSIdD = CtrlGrdClass.SelectedValue;
        var nDIVIdD = CtrlGrdDiv.SelectedValue;

        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPDeleteData", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@EmptableT", DDD);
                cmd.Parameters.AddWithValue("@nINSTIId", nINSTIIdD);
                cmd.Parameters.AddWithValue("@nCLSId", nCLSIdD);
                cmd.Parameters.AddWithValue("@nDIVId", nDIVIdD);
                cmd.Parameters.AddWithValue("@nStudIID", StudIIDD);
                int i = cmd.ExecuteNonQuery();
                con.Close();
               
            }

        }


    }


}