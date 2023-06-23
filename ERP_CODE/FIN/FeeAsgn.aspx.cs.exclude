using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

public partial class FIN_FeeAsgn : ClsPageEvents, IPageInterFace
{
    ClsFeeInstallmentMaster ObjCls = new ClsFeeInstallmentMaster();
    ClsDropdownRecordList ObjFillD = new ClsDropdownRecordList();

   

    SqlConnection con;
    SqlCommand cmd;
    SqlTransaction tran;
    public String GRDS;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            if (!IsPostBack)
            {

                FnInitializeForm();
                FILLDROP();
                //GrdVwFee.DataBind();
              // fillInstallment();
                //fillGrowthHistory();
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }

    }

    public void ConnectionLOC()
    {
        con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True");
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandTimeout = 5000;
    }

    public void FILLDROP()
    {
       
        ObjFillD.FnGetBranchList(DrpInstitute, "");
              
        DataTable ClsTD = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN'") as DataSet).Tables[0];
        DrpDivision.DataSource = ClsTD;
        DrpDivision.DataValueField = "nId";
        DrpDivision.DataTextField = "cName";
        DrpDivision.DataBind();
              
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
        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;
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

        

            if (DrpInstitute.SelectedValue == "0")
            {
                DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM tblbranch") as DataSet).Tables[0];
                GrdVwRecords.DataSource = ClsTG;
                GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdVwRecords.DataBind();
                GrdVwRecords.SelectedIndex = -1;
            }
            else if ((DrpInstitute.SelectedValue != "0") && (DrpClass.SelectedValue == "0") && (DrpDivision.SelectedValue == "0"))
            {
                DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM TblclassDetails where cttype='CLS'and nBranchId=" + DrpInstitute.SelectedValue + " ") as DataSet).Tables[0];
                GrdVwRecords.DataSource = ClsTG;
                GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdVwRecords.DataBind();
                GrdVwRecords.SelectedIndex = -1;
            }
            else if ((DrpInstitute.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue == "0"))
            {
                DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM TblclassDetails where cttype='DIVN'") as DataSet).Tables[0];
                GrdVwRecords.DataSource = ClsTG;
                GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdVwRecords.DataBind();
                GrdVwRecords.SelectedIndex = -1;
            }
            else if ((DrpInstitute.SelectedValue != "0") && (DrpClass.SelectedValue != "0") && (DrpDivision.SelectedValue != "0"))
            {


            //DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM TblCategory") as DataSet).Tables[0];
            int Ins = ObjCls.FnIsNumeric(DrpInstitute.SelectedValue);
            int Cls = ObjCls.FnIsNumeric(DrpClass.SelectedValue);
            int Div = ObjCls.FnIsNumeric(DrpDivision.SelectedValue);
           // DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM TblRegistrationStudent") as DataSet).Tables[0];
            DataTable ClsTG = ObjFillD.FnGetStudentList(Ins, Cls, Div);
              
            GrdVwRecords.DataSource = ClsTG;
                GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
                GrdVwRecords.DataBind();
                GrdVwRecords.SelectedIndex = -1;
            }
        // GrdVwRecords.Focus()
        //fillInstallment();
    }

    public void fillInstallment()
    {

<<<<<<< HEAD
        DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId ID,cName,'' Remarks,'false' Active FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        // DataTable ClsTG = (ObjCls.FnGetDataSet("SELECT nId ID,cName FROM TblclassDetails") as DataSet).Tables[0];

        GrdVwFee.DataSource = ClsTGF;
        GrdVwFee.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwFee.DataBind();
        GrdVwFee.SelectedIndex = -1;


=======
        DataTable ClsTGF = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        //DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName FROM TblFeeMaster") as DataSet).Tables[0];
>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a
        DataTable ClsTGFM = (ObjCls.FnGetDataSet("SELECT cName FROM TblFeeMaster") as DataSet).Tables[0];

<<<<<<< HEAD
        //FlipDataTable(ClsTGFM);

        GrdVwFee.DataSource = FlipDataTable(ClsTGFM) ;
      
        GrdVwFee.DataBind();
        //GrdVwFee.HeaderRow.Visible = false;

        //GrdVwFee.DataSource = ClsTGFM;
        //GrdVwFee.DataKeyNames = new String[] { ObjCls.KeyName };
        //GrdVwFee.DataBind();
        GrdVwFee.SelectedIndex = -1;

    }

    public static DataTable FlipDataTable(DataTable dt)
=======

        GrdVwFee.DataSource = FlipDataTable(ClsTGFM, ClsTGF);
        GrdVwFee.DataBind();
   
        

    }


    public static DataTable FlipDataTable(DataTable dt, DataTable dt1)
>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a

    {
        DataRow dr;
        DataTable table = new DataTable();
<<<<<<< HEAD
        table.Columns.Add(Convert.ToString("cName"));
        table.Columns.Add(Convert.ToString("ID"));
        table.Columns.Add(Convert.ToString("Remarks"));
        table.Columns.Add(Convert.ToString("Active"));
=======
        table.Columns.Add(Convert.ToString("nId"));

        table.Columns.Add(Convert.ToString("cName"));
        
>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a
        //Get all the rows and change into columns
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            dr = table.NewRow();

<<<<<<< HEAD
            for (int i = 0; i <= (dt.Rows.Count-1); i++)

        {

            //table.Columns.Add(Convert.ToString(i));

            table.Columns.Add(Convert.ToString(dt.Rows[i][j]));
                dr[0] = 1;
           // string RTD = dt.Rows[i];

=======
            for (int i = 0; i <= (dt.Rows.Count - 1); i++)

            {
                table.Columns.Add(Convert.ToString(dt.Rows[i][j]));
            }
>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a
        }
            table.Rows.Add(dr);
        }
        

        //get all the columns and make it as rows
<<<<<<< HEAD

        //for (int j = 0; j < dt.Columns.Count; j++)

        //{

        //    dr = table.NewRow();

        //    dr[0] = dt.Columns[j].ToString();

        //    for (int k = 1; k <= dt.Rows.Count; k++)

        //        dr[k] = dt.Rows[k - 1][j];

        //    table.Rows.Add(dr);

        //}
=======
        //for (int j = 0; j <= dt1.Columns.Count; j++)
        for (int j = 0; j <1; j++)
        {
            dr = table.NewRow();
            //dr[0] = dt1.Columns[j+1].ToString();
            //dr[1] = dt1.Columns[j+1].ToString();
            for (int k = 1; k <= dt1.Rows.Count; k++)
            {
                // dr[k] = dt1.Rows[k - 1][j];
                // dr[k] = dt1.Rows[k-1][j+1];
                //table.Rows.Add(dr);
                table.Rows.Add(Convert.ToString(dt1.Rows[k - 1][j]));
               // table.Rows.Add(Convert.ToString(dt1.Rows[k ][j+1]));
               var VD= (dt1.Rows[k - 1][j]).ToString();
                var VD1 = (dt1.Rows[k - 1][1]).ToString();
                table.Rows[k - 1][1] = VD1;
            }
        }
                return table;
>>>>>>> c7ab00d4dfec66d782820b629b85a0b75e59a33a

    }


    protected void DrpInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpInstitute.SelectedValue != "0")
        {
            DrpClass.Enabled = true;

            DrpClass.Items.Clear();

            DrpClass.Items.Add(new ListItem("Select", "0"));
            DataTable ClsTC = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' and nBranchId=" + DrpInstitute.SelectedValue + "") as DataSet).Tables[0];
            DrpClass.DataSource = ClsTC;
            DrpClass.DataValueField = "nId";
            DrpClass.DataTextField = "cName";
            DrpClass.DataBind();
        }
        else
        {
            DrpClass.Enabled = false;
            DrpDivision.Enabled = false;
        }
    }


    protected void DrpClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpClass.SelectedValue != "0")
        {
            DrpDivision.Enabled = true;
            DrpDivision.Items.Clear();
            DrpDivision.Items.Add(new ListItem("Select", "0"));
            DataTable ClsTD = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' and nBranchId=" + DrpInstitute.SelectedValue + "") as DataSet).Tables[0];
            DrpDivision.DataSource = ClsTD;
            DrpDivision.DataValueField = "nId";
            DrpDivision.DataTextField = "cName";
            DrpDivision.DataBind();
        }
        else
        {
            DrpDivision.Enabled = false;
        }
    }

    protected void GrdVwRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
         fillInstallment();
        //fillInstallment2();

        String Name1 = GrdVwRecords.SelectedRow.Cells[0].Text;
        GRDS = Name1;
    }

    
    protected void GrdVwFee_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 2; i < e.Row.Cells.Count; i++)
            {
                //int rowIndex = 1;
                System.Web.UI.WebControls.TextBox txt = new System.Web.UI.WebControls.TextBox() { ID = "txtDynamic" + i };
                e.Row.Cells[i].Controls.Add(txt);

                System.Web.UI.WebControls.TextBox txt1 = new System.Web.UI.WebControls.TextBox() { ID = "T" + i };
                e.Row.Cells[i].Controls.Add(txt1);

                txt1.Text = GrdVwFee.HeaderRow.Cells[i].Text;
                //txt1.ID = 2;
                //txt1.Visible = false;

                // txt.Attributes.Add("onclick","window.alert(1);");
                int RR = e.Row.RowIndex;
                //int INSId = ObjCls.FnIsNumeric(DrpInstitute.SelectedValue.ToString());
                //int CLSId = ObjCls.FnIsNumeric(DrpClass.SelectedValue.ToString());
                //int DIVId = ObjCls.FnIsNumeric(DrpDivision.SelectedValue.ToString());
                //int VI = i;
                //int STUDId = 1;
                //int INSTALID = GrdVwFee.SelectedIndex;
                // txt.Attributes.Add("onclick", "Myfunction("+ INSId + "," + CLSId + "," + DIVId + ")");
                //var DD = 

                String Name2 = GrdVwRecords.SelectedRow.Cells[0].Text;

                //GrdVwFee.Rows[i].Cells[8].Visible = false;

                txt.Attributes.Add("onkeyup", "Myfunction('" + txt.ClientID + "','" + DrpInstitute.ClientID + "','" + DrpClass.ClientID  + "','" + DrpDivision.ClientID + "','" + Name2 + "','" + txt1.ClientID + "')");

                //txt.Attributes.Add("onkeydown", "Myfunction('" + txt.ClientID + "')");
                //  document.getElementById('<%= txt_id.ClientID %>').value;
                //document.getElementById('<%= txt_id.ClientID %>').value;

                //document.getElementById(txt).value


            }

        }




        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    for (int colIndex = 1; colIndex < e.Row.Cells.Count; colIndex++)
        //    {
        //        int rowIndex = colIndex;
        //        System.Web.UI.WebControls.TextBox txtName = new System.Web.UI.WebControls.TextBox();
        //        txtName.Width = 100;
        //        txtName.ID = "T" + colIndex;
        //        string txtID = "T" + colIndex;
        //        txtName.AutoPostBack = false;
        //        e.Row.Cells[colIndex].Controls.Add(txtName);

        //    }
        //}


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

        //System.Web.UI.WebControls.Button btn = e.CommandSource as System.Web.UI.WebControls.Button;
        //GridViewRow row = btn.NamingContainer as GridViewRow;
        //if (row != null)
        //{
        //    System.Web.UI.WebControls.TextBox txt = row.FindControl("TextBox1") as System.Web.UI.WebControls.TextBox;
        //    if (txt != null)
        //    {

        //    }
        //}
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
}