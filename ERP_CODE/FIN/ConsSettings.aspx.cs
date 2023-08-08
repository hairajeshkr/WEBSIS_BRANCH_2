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
                FnFillInstallment();
                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);
                
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
    public static string InsertData(int nFEEId, int nINSSTALId, int nINSTIId, int nCLSId, int nDIVId, int nSTUDId, int nAmount,int AcId,int BrId,int CmpId,int FaId,int AccLedgerId,int OrderIndex)
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
    public override void FnCancel()
    {
        base.FnCancel();

        //DdlInslment.SelectedIndex = 0;
        CtrlGrdInstitute.SelectedValue = "0";
        CtrlGrdInstitute.SelectedText = "";

        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";

        CtrlGrdStudent.SelectedValue = "0";
        CtrlGrdStudent.SelectedText = "";

        CtrlGrdDiv.SelectedValue = "0";
        CtrlGrdDiv.SelectedText = "";

        

        FnFocus(CtrlGrdInstitute.ControlTextBox);
    }





    public override void FnInitializeForm()
    {
        //TabContainer1.ActiveTabIndex = 0;
        //ViewState["DT"] = FnGetGeneralTable(ObjCls);
        //FnGridViewBinding("");
        //FnFillInstallment();
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
        //GrdVwFee.DataSource = ViewState["DT"] as DataTable;
        //GrdVwFee.DataKeyNames = new String[] { ObjCls.KeyName };
        //GrdVwFee.DataBind();
        //GrdVwFee.SelectedIndex = -1;
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
                    //FnFillInstallment();
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
       
        
        DataTable DTInstallment = (ObjCls.FnGetDataSet("SELECT nId ID,cName,dStartDate,dEndDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
       

        GrdVwInstallment.DataSource = DTInstallment;
        GrdVwInstallment.DataBind();




    }










    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        //var CLN = TreVwLst.SelectedNode.Value;
        //int IH = TreVwLst.SelectedNode.Depth
        try
        {
            FnCancel();
            if (TreVwLst.SelectedNode.Depth == 0)
            {
                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Text;

            }
            else if (TreVwLst.SelectedNode.Depth == 1)
            {
                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Text;
                CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Text;
            }
            else if (TreVwLst.SelectedNode.Depth == 2)
            {

                CtrlGrdInstitute.SelectedValue = TreVwLst.SelectedNode.Parent.Parent.Value;
                CtrlGrdInstitute.SelectedText = TreVwLst.SelectedNode.Parent.Parent.Text;
                CtrlGrdClass.SelectedValue = TreVwLst.SelectedNode.Parent.Value;
                CtrlGrdClass.SelectedText = TreVwLst.SelectedNode.Parent.Text;
                CtrlGrdDiv.SelectedValue = TreVwLst.SelectedNode.Value;
                CtrlGrdDiv.SelectedText = TreVwLst.SelectedNode.Text;

            }

           //FnFillInstallment();


        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }










    protected void GrdVwInstallment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        //string customerId = GrdVwInstallment.DataKeys[e.Row.RowIndex].Value.ToString();
        GridView gvOrders = e.Row.FindControl("GrdVwFee") as GridView;

        DataTable DTFeeName = (ObjCls.FnGetDataSet("SELECT nId ID,cName Name ,0 Amount  FROM TblFeeMaster") as DataSet).Tables[0];
        gvOrders.DataSource = DTFeeName;
        gvOrders.DataBind();
        


        }
    }



    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

            var InsGrpId = CtrlGrdInstitute.IdControl;
            var ClsId = CtrlGrdClass.IdControl;
            var DivId = CtrlGrdDiv.IdControl;
            var StudId = CtrlGrdStudent.IdControl;

            string InstallmentId = ((Label)e.Row.Parent.Parent.Parent.FindControl("LblId")).Text;
            string InstallmentName = ((Label)e.Row.Parent.Parent.Parent.FindControl("LblInstallment")).Text;
            string FeeId = ((Label)e.Row.FindControl("LblFeeId")).Text;
            string FeeName = ((Label)e.Row.FindControl("LblFee")).Text;
            TextBox TxtAmnt = ((TextBox)e.Row.FindControl("TxtAmount"));

            CtrlDate Fromdate= ((CtrlDate)e.Row.Parent.Parent.Parent.FindControl("CtrlFromDate"));
            CtrlDate DueDate = ((CtrlDate)e.Row.Parent.Parent.Parent.FindControl("CtrlToDate"));
            

            string sqlquery = "select nAccLedgerId from TblFeeMaster where nId=" + FeeId;
            int AccLedgerId = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery).ToString());
            //int AccLedgerId = 1;

            string sqlquery2 = "select nOrderIndex from TblFeeMaster where nId=" + FeeId;
            int OrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery2).ToString());
            //int OrderIndex = 1;

            var InsgrpIdd = CtrlGrdInstitute.SelectedValue;
            var ClsIdd = CtrlGrdClass.SelectedValue;
            var DivIdd = CtrlGrdDiv.SelectedValue;
            var StuIdd = CtrlGrdStudent.SelectedValue;

            SqlCommand cmd = new SqlCommand("select  isnull(nAmount,0) from TblFeeConcessionAssign where nInstituteGrpId=" + InsgrpIdd + " and nClassId=" + ClsIdd + " and nDivisionId=" + DivIdd + " and nStudentId=" + StuIdd + " and nInstalmentId =" + InstallmentId + " and nFeeMasterId = " + FeeId + "", con);

            con.Open();
            var VV = cmd.ExecuteScalar();
            con.Close();
            if (VV == null)
            {
                TxtAmnt.Text = "0";
            }
            else
            {
                TxtAmnt.Text = VV.ToString();
            }


            //TxtAmnt.Attributes.Add("onchange", "Myfunction('" + TxtAmnt.ClientID + "','" + InsGrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FeeId + "','"+InstallmentId+"','" + iAcId + "','" + iBrId + "','" + iCmpId + "','" + iFaId + "','" + AccLedgerId + "','" + OrderIndex + "')");
            TxtAmnt.Attributes.Add("onchange", "Myfunction('" + TxtAmnt.ClientID + "','" + InsGrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FeeId + "','" + InstallmentId + "','" + iAcId + "','" + iBrId + "','" + iCmpId + "','" + iFaId + "','" + AccLedgerId + "','" + OrderIndex + "','" + Fromdate+ "','" + DueDate + "')");

        }
    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {
        FnFillInstallment();
    }
}