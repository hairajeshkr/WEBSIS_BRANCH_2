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
    public static string InsertData(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, string nAmount)
    {
        string msg = string.Empty;
        //string VV = TId;
        //String STDDI = CtrlGrdStudent.SelectedValue;
        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("Insert into TblFeeAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount) VALUES(@nFeeMasterId,@nInstalmentId,@nInstituteGrpId,@nClassId,@nDivisionId,@nStudentId,@nAmount)", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@nFeeMasterId", nFEEId);
                cmd.Parameters.AddWithValue("@nInstalmentId", nINSSTALId);
                cmd.Parameters.AddWithValue("@nInstituteGrpId", nINSTIId);
                cmd.Parameters.AddWithValue("@nClassId", nCLSId);
                cmd.Parameters.AddWithValue("@nDivisionId", nDIVId);
                cmd.Parameters.AddWithValue("@nStudentId", nSTUDId);
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

    //    //ViewState["DT2"] = GrdVwFee.DataSource;
    //   // DataTable DDD = ViewState["DT2"] as DataTable;

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




    






    public static DataTable FlipDataTable(DataTable dt, DataTable dt1,DataTable dt2)

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
        for (int j = 0; j <1; j++)
        {
            dr = table.NewRow();
            //dr = table.NewRow();
            table.Rows.Add(Convert.ToString(0));
            for (int k = 1; k <= dt1.Rows.Count; k++)
            {
                //table.Rows.Add(Convert.ToString(0));
                table.Rows.Add(Convert.ToString(dt1.Rows[k - 1][j]));
                //table.Rows.Add(Convert.ToString(dt1.Rows[k][j]));
                var VD= (dt1.Rows[k - 1][j]).ToString();
                var VD1 = (dt1.Rows[k - 1][1]).ToString();
                var VD2= (dt1.Rows[k - 1][2]).ToString();
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
            CtrlFromDate.ID = "C";

            CtrlDate CtrlDueDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
            e.Row.Cells[3].Controls.Add(CtrlDueDate);

            var FromD = CtrlFromDate.DateText;
            var DueD = CtrlDueDate.DateText;

            CtrlDate FromDC = (CtrlDate)e.Row.FindControl("CtrlFromDate");
            CtrlDate FromDD = (CtrlDate)e.Row.FindControl("CtrlDueDate");

            
            for (int i = 4; i < e.Row.Cells.Count; i++)
            {

               System.Web.UI.WebControls.TextBox txt = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(txt);
                //txt.AutoPostBack = false;
               

                System.Web.UI.WebControls.TextBox txt1 = new System.Web.UI.WebControls.TextBox() { ID = "T" + i };
                e.Row.Cells[i].Controls.Add(txt1);
                //txt1.Visible = false;

                DataTable DDDR = ViewState["DT2"] as DataTable;
                //txt.Text = Convert.ToString(DDDR.Rows[i][i]);

                int RR = (e.Row.RowIndex)+1;
                var LLL = txt.Text;
                ViewState["DT1"] = GrdVwFee.DataSource;
                DataTable DDD = ViewState["DT1"] as DataTable;
                txt1.Text = Convert.ToString(DDD.Rows[0][i]);
                //var INSSS = GrdVwFee.HeaderRow.Cells[1].Text;



                var INSSS = e.Row.Cells[0].Text;
                var INSSSN = e.Row.Cells[1].Text;
                var GrpId = lblGrpId.Text;
                var ClsId= lblClsId.Text;
                var DivId = lblDivId.Text;

                var FDT = lblMessage.Text;
               // var StudId = String.IsNullOrEmpty(CtrlGrdStudent.SelectedValue);
                var StudId = CtrlGrdStudent.SelectedValue.ToString();
                var Cov = e.Row.Cells[i].Text;


                //txt.Attributes.Add("onkeyup", "Myfunction('" + txt.ClientID + "','" + TxtGrp.ClientID + "','" + TxtCls.ClientID  + "','" + TxtDiv.ClientID + "','" + TxtStd.ClientID + "','" + txt1.ClientID + "','" + RR + "')");
                // GrdVwFee.Attributes.Add("onbind", "Myfunction('" + txt.ClientID + "','" + TxtGrp.ClientID + "','" + TxtCls.ClientID + "','" + TxtDiv.ClientID + "','" + TxtStd.ClientID + "','" + txt1.ClientID + "','" + RR + "')");
                // txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + TxtGrp.ClientID + "','" + TxtCls.ClientID + "','" + TxtDiv.ClientID + "','" + TxtStd.ClientID + "','" + txt1.ClientID + "','" + RR + "')");

                // txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + CtrlGrdStudent.ClientID + "','" + txt1.ClientID + "','" + RR + "')");
               
                //txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "')");

                txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "','" + CtrlFromDate.ClientID + "','" + CtrlDueDate.ClientID + "')");
                
                CtrlFromDate.Attributes.Add("onclick", "DateGetF('"+ CtrlFromDate.ClientID  + "')");
                // txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "','" + FromDC.ClientID + "','" + FromDD.ClientID + "')");

                //txt.Attributes.Add("onchange", UpdateGridcell(Convert.ToInt32(txt.Text),e.Row.RowIndex, Convert.ToInt32(e.Row.Cells[i])));

                //txt.Attributes.Add("onchange", UpdateGridcell(txt.Text, e.Row.RowIndex, e.Row.Cells[i].Text));
                ////txt.Attributes.Add("onchange", "Myfunction('" + txt.ClientID + "','" + GrpId + "','" + ClsId + "','" + DivId + "','" + StudId + "','" + txt1.ClientID + "','" + RR + "','" + CtrlFromDate.DateText + "','" + CtrlDueDate.DateText + "')");
            }
           // CmdSave.Attributes.Add("onclick", InsertData(txt.ClientID, GrpId, ClsId, DivId, StudId, txt1.ClientID, ));
        }

      
    }

    private EventHandler txtDynamic_TextChanged()
    {
        throw new NotImplementedException();

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
        ///lblMessage.Text = item.ToString();

    }

    protected void GrdVwFee_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string commandName = e.CommandName;
        int rowIndex = Convert.ToInt32(e.CommandName);
        GridViewRow row = GrdVwFee.Rows[rowIndex];
        

        string Cat_name = (GrdVwFee.Rows[rowIndex].FindControl("ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwFee_txtDynamic4_1") as TextBox).Text;

    }



    //protected override void Render(HtmlTextWriter writer)
    //{
    //    foreach (GridViewRow r in GrdVwFee.Rows)
    //    {
    //        if (r.RowType == DataControlRowType.DataRow)
    //        {
    //            for (int columnIndex = 0; columnIndex <
    //                r.Cells.Count; columnIndex++)
    //            {
    //                Page.ClientScript.RegisterForEventValidation(
    //                    r.UniqueID + "$ctl00", columnIndex.ToString());
    //            }
    //        }
    //    }

    //    base.Render(writer);

    //}


    protected void GrdVwFee_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if(e.AffectedRows<1)
        {
            e.KeepInEditMode = true;
        }

    }


    protected void CtrlGrdStudent_SelectedValueChanged(object sender, EventArgs e)
    {
        var StdII = CtrlGrdStudent.SelectedValue;
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
        string GRP, CLS, DIVN;
        if (TreeView1.SelectedNode.Depth==0)
        {
            //group
             GRP = TreeView1.SelectedNode.Value;
            //TxtGrp.Text = TreeView1.SelectedNode.Value;
            lblGrp.Text = "-->" + TreeView1.SelectedNode.Text;
            lblGrpId.Text = TreeView1.SelectedNode.Value;
            lblGrpId.Visible = false;
            lblCls.Text = "";
            lblDiv.Text = "";
            CtrlGrdInstitute.SelectedValue= TreeView1.SelectedNode.Value;
            CtrlGrdInstitute.SelectedText= TreeView1.SelectedNode.Text;

            CtrlGrdClass.SelectedValue = "";
            CtrlGrdClass.SelectedText ="";
            CtrlGrdDiv.SelectedValue = "";
            CtrlGrdDiv.SelectedText = "";
        }
        else if(TreeView1.SelectedNode.Depth == 1)
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
            lblGrp.Text ="-->" + TreeView1.SelectedNode.Parent.Parent.Text;
            lblGrpId.Text = TreeView1.SelectedNode.Parent.Parent.Value;
            lblGrpId.Visible = false;
            CtrlGrdInstitute.SelectedValue = TreeView1.SelectedNode.Parent.Parent.Value;
            CtrlGrdInstitute.SelectedText = TreeView1.SelectedNode.Parent.Parent.Text;
            CLS = TreeView1.SelectedNode.Parent.Value;
           // TxtCls.Text = TreeView1.SelectedNode.Parent.Value;
            lblCls.Text = "-->" + TreeView1.SelectedNode.Parent.Text;
            lblClsId.Text= TreeView1.SelectedNode.Parent.Value;
            lblClsId.Visible = false;
            CtrlGrdClass.SelectedValue = TreeView1.SelectedNode.Parent.Value;
            CtrlGrdClass.SelectedText = TreeView1.SelectedNode.Parent.Text;
            DIVN = TreeView1.SelectedNode.Value;
            //TxtDiv.Text = TreeView1.SelectedNode.Value;
            lblDiv.Text = "-->" + TreeView1.SelectedNode.Text;
            lblDivId.Text= TreeView1.SelectedNode.Value;
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
            using (SqlCommand cmd = new SqlCommand("SPTestT2", con))
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





    protected void CmdSave_Click(object sender, EventArgs e)
    {
        DataTable DD1D = ViewState["DT1"] as DataTable;

               

        foreach (GridViewRow row in GrdVwFee.Rows)
        {
            for (int j = 4; j <= GrdVwFee.Rows[0].Cells.Count - 1; j++)
            {
                //TextBox AmountT = (TextBox)GrdVwFee.Rows.Cells[j].FindControl("txtD");
            }

        }

            TextBox AmountTv = null;

        for (int i = 1; i <= GrdVwFee.Rows.Count - 1; i++)
                {
                    for (int j = 4; j <= GrdVwFee.Rows[0].Cells.Count - 1; j++)
                    {

                       // txt1.Text = Convert.ToString(DDD.Rows[0][i]);
                        var FFEID = GrdVwFee.Rows[0].Cells[j].Text;
                        var INSTLID = GrdVwFee.Rows[i].Cells[0].Text;
                        var INSTIId = CtrlGrdInstitute.SelectedValue;
                        var CLSId = CtrlGrdClass.SelectedValue;
                        var DIVId = CtrlGrdDiv.SelectedValue;
                        var STUDId = CtrlGrdStudent.SelectedValue;
                //cmd.Parameters.AddWithValue("@nAmount", 1);

               
                //TestControl objTestControl = (TestControl)Page.FindControl("TestControl");
                //TextBox objTextBox = objTestControl.FindControl("txtFirstName");
                //string strFirstName = objTextBox.Text;

                //System.Web.UI.WebControls.TextBox txt = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + j };

                //TextBox AmountT  = (TextBox)GrdVwFee.Rows[i].FindControl("txtDynamic"+ j);

                //TextBox AmountT = (TextBox)GrdVwFee.Rows[i].FindControl("txt");
              
                object value = this.GrdVwFee.Rows[i].Cells[j].Text;
                ///  string text = (string)TextBox.text(value);

                TextBox messageT = GrdVwFee.NamingContainer.FindControl("ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwFee_txtDynamic4_1") as TextBox;

                //CtrlDate CtrlFromDate = (CtrlDate)LoadControl("~/CtrlDate.ascx");
                //CtrlDate CTDDS = (CtrlDate)GrdVwFee.Rows[i].Cells[2].FindControl("CtrlFromDate");
                CtrlDate CTDDS = (CtrlDate)GrdVwFee.Rows[i].FindControl("CtrlFromDate");
                
                TextBox AmountT = (TextBox)GrdVwFee.Rows[i].Cells[j].FindControl("txtD");
               // TextBox AmountT = (TextBox)GrdVwFee.Rows[i].Cells[j].FindControl("txtDynamic" + j + "_" + i);
                //TextBox AmountT = (TextBox)GrdVwFee.Rows[i].Cells[j].FindControl("txtDynamic"+ j );

                TextBox AmountT1 = (TextBox)GrdVwFee.Rows[i].Cells[j].FindControl("ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwFee_txtDynamic4_1");

                TextBox AmountT2 = (TextBox)GrdVwFee.Rows[i].FindControl("ContentPlaceHolder1_TabContainer1_TabPanel2_GrdVwFee_txtDynamic4_1");
                //string temp1 = AmountT.Text;
                               
                // InsertDataRow(FFEID, INSTLID, INSTIId, CLSId, DIVId, STUDId, Amount);

            }
        }

              
    }


    public static string InsertDataRow(string nFEEId, string nINSSTALId, string nINSTIId, string nCLSId, string nDIVId, string nSTUDId, int nAmount)
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

    public void UpdateGridcell(string amount,int RowG,string ColumnG)
    {
        GrdVwFee.Rows[Convert.ToInt32(RowG)].Cells[Convert.ToInt32(ColumnG)].Text = amount.ToString();
        var CDSA = GrdVwFee.Rows[Convert.ToInt32(RowG)].Cells[Convert.ToInt32(ColumnG)].Text;
    }




}