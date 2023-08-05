﻿using System;
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
       
        DataTable DTInstallment = (ObjCls.FnGetDataSet("SELECT nId,cName, CONVERT(varchar,GETDATE(),106) FromDate, CONVERT(varchar,GETDATE(),106) DueDate  FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DataTable DTFeeName = (ObjCls.FnGetDataSet("SELECT cName,nId  FROM TblFeeMaster") as DataSet).Tables[0];

        GrdVwFee.DataSource = FnFlipDataTable(DTFeeName, DTInstallment);
        //ViewState["DT1"] = GrdVwFee.DataSource;
        //DataTable DDD = ViewState["DT1"] as DataTable;
        GrdVwFee.DataBind();
              
        

    }



    public static DataTable FnFlipDataTable(DataTable DTFeeName, DataTable DTInstallment)

    {
        DataTable table = new DataTable();
        int j = 0, i = 0, k = 0,h=0;
        for (i = 0; i <= (DTFeeName.Rows.Count - 1); i++)
        {
            //dr = table.NewRow();

            for (j = 0; j < DTFeeName.Columns.Count; j++)
            {
                DTInstallment.Columns.Add(Convert.ToString(DTFeeName.Rows[i][j]));
                // dtInstll.Columns.Add(Convert.ToString(dtFeeName.Rows[1][i]));
            }
        }

        table = DTInstallment;
        return table;
    }


    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
           

            CtrlDate CtrlFromDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[2].Controls.Add(CtrlFromDate);
            CtrlFromDate.ID = "txtdate";


            CtrlDate CtrlDueDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[3].Controls.Add(CtrlDueDate);

            int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

            //var InsGrpId = lblGrpId.Text;
            //var ClsId = lblClsId.Text;
            //var DivId = lblDivId.Text;
            var InsGrpId = CtrlGrdInstitute.IdControl;
            var ClsId = CtrlGrdClass.IdControl;
            var DivId = CtrlGrdDiv.IdControl;
            var StudId = CtrlGrdStudent.IdControl;
            

            var InsgrpIdd = CtrlGrdInstitute.SelectedValue;
            var ClsIdd = CtrlGrdClass.SelectedValue;
            var DivIdd = CtrlGrdDiv.SelectedValue;
            var StuIdd = CtrlGrdStudent.SelectedValue;


            ViewState["DT1"] = GrdVwFee.DataSource;
            DataTable DDD = ViewState["DT1"] as DataTable;



            for (int i = 4; i < e.Row.Cells.Count; i+=2)
            {

                System.Web.UI.WebControls.TextBox TxtAmount = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(TxtAmount);


                //e.Row.Cells[i - 1].Visible = false;

                HiddenField tmp = new HiddenField();
                e.Row.Cells[i + 1].Controls.Add(tmp);
                tmp.Value = GrdVwFee.HeaderRow.Cells[i + 1].Text;

                GrdVwFee.HeaderRow.Cells[i+1].Visible = false;

                e.Row.Cells[i + 1].Visible = false;

                var FeeId = tmp.Value;

                SqlCommand cmd = new SqlCommand("select  isnull(nAmount,0) from TblFeeConcessionAssign where nInstituteGrpId=" + InsgrpIdd + " and nClassId=" + ClsIdd + " and nDivisionId=" + DivIdd + " and nStudentId=" + StuIdd + " and nInstalmentId =" + e.Row.Cells[0].Text + " and nFeeMasterId = " + FeeId + "", con);

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
                int RowIndx = (e.Row.RowIndex)+1;
                

                
               //Convert.ToString(DDD.Rows[0][i]);


                string sqlquery = "select nAccLedgerId from TblFeeMaster where nId=" + FeeId;
                int AccLedgerId = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery).ToString());
                //int AccLedgerId = 1;

                string sqlquery2= "select nOrderIndex from TblFeeMaster where nId=" + FeeId;
                int OrderIndex = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(sqlquery2).ToString());
                //int OrderIndex = 1;

                TxtAmount.Attributes.Add("onchange", "Myfunction('" + TxtAmount.ClientID + "','" + InsGrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + FeeId + "','" + RowIndx + "','"+ iAcId +"','"+ iBrId +"','" +iCmpId+ "','"+ iFaId+ "','"+ AccLedgerId + "','" + OrderIndex + "')");



            }
            
        }

           



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

           FnFillInstallment();


        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }







        protected void BtnFind_Click(object sender, EventArgs e)
    {
        
        FnFillInstallment();
    }
}