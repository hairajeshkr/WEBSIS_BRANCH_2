using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Globalization;

public partial class FIN_FeesCollection : ClsPageEvents, IPageInterFace
{
    ClsFeeInstallmentMaster ObjCls = new ClsFeeInstallmentMaster();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    HiddenField HdnId = null;
    TextBox Payable = null;
    Label TotalFee = null, Concession = null, Excess = null, Paid = null;
    Label TotalFees, Conce;
    
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            if (!IsPostBack)
            {
                
                FnInitializeForm();
                ObjLst.FnGetFeeTypeList(DdlFeeType, "");
                CtrlRptDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");
                CtrlInsDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");
            }
            CtrlGrdDiv.ParentControl = CtrlGrdClass.IdControl;
            CtrlGrdStudent.ParentControl = CtrlGrdDiv.IdControl;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsFeeInstallmentMaster(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);

        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        
        FnGridViewBinding("");

    }


    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        
    }
    public override void FnCancel()
    {
        base.FnCancel();
        FnInitializeForm();
        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
    }


    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StartDate = ObjCls.FnDateTime(DateTime.Now.ToString());
        ObjCls.EndDate = ObjCls.FnDateTime(DateTime.Now.ToString());
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
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnInsert();
                            break;
                        case "UPDATE":
                            FnUpdate();
                            break;
                    }
                    break;


            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }

    }


    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            //GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            //ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            //TxtName.Text = ObjCls.Name.ToString();
            //TxtCode.Text = ObjCls.Code.ToString();
            //TxtAbbrevation.Text = ObjCls.Abbrevation.ToString();
            //TxtPriority.Text = ObjCls.Priority.ToString();
            ////CtrlStartDate.DateText= ObjCls.StartDate.ToString();
            ////CtrlDueDate.DateText = ObjCls.EndDate.ToString();


            //CtrlStartDate.DateText = ObjCls.FnDateTime(ObjCls.StartDate, "dd/MMM/yyyy");
            //CtrlDueDate.DateText = ObjCls.FnDateTime(ObjCls.EndDate, "dd/MMM/yyyy");
            //// CtrlDueDate.DateText = ObjCls.DueDate.ToString();
            //TxtRemarks.Text = ObjCls.Remarks.ToString();
            //ChkActive.Checked = ObjCls.Active;
            ////ChkApprove.Checked = ObjCls.IsApprove;
            //ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();
            //ChkECAInstallment.Checked = ObjCls.IsEca;
            //ChkOneTimeInstallment.Checked = ObjCls.IsOneTime;


            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           // GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

       
    protected void BtnShow_Click(object sender, EventArgs e)
    {
               
        FnFillGrd();

        GrdVwRecords.DataSource =  ViewState["DT2"];
        GrdVwRecords.DataBind();

        FnGrandAmtPayableTotal();

        int AmntPayable = Convert.ToInt32(TxtAmntPayable.Text);
        float FAmntPayable = (float)AmntPayable;
        float CumAmount = float.Parse(TxtCumAmount.Text);

        TxtTotAmnt.Text = (FAmntPayable + CumAmount).ToString();
        TxtNtPayable.Text = TxtTotAmnt.Text;

    }

    [WebMethod]
    private  void FnGrandAmtPayableTotal()
    {
        float GTotal = 0f;
        for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
        {
            String total = (GrdVwRecords.Rows[i].FindControl("TxtPayable") as TextBox).Text;
            GTotal += Convert.ToSingle(total);
            
        }
         TxtAmntPayable.Text = GTotal.ToString();
        
    }



    private void FnGrandPayableTotalAmt()
    {
        float GTotal = 0f;
        for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
        {
            String total = (GrdVwRecords.Rows[i].FindControl("TxtPayable") as TextBox).Text;
            GTotal += Convert.ToSingle(total);

        }
        TxtAmntPayable.Text = GTotal.ToString();
       
    }


    protected void BtnStud_Click(object sender, EventArgs e)
    {
        var StudID = CtrlGrdStudent.SelectedValue;

        //DataTable ClsTGFI = (ObjCls.FnGetDataSet("select * from TblRegistrationStudent   ") as DataSet).Tables[0];
        //DataTable ClsTGFIC = (ObjCls.FnGetDataSet("select * from TblClassDetails   ") as DataSet).Tables[0];
        //DataTable ClsTGFIS = (ObjCls.FnGetDataSet("select * from TblStudentAdmissionDetails   ") as DataSet).Tables[0];
        

        TxtGrpSec.Text = CtrlGrdClass.SelectedText + '/' + CtrlGrdDiv.SelectedText;
        string strsqlOi = "SELECT cAdmissionNo FROM TblRegistrationStudent WHERE nId=" + StudID;
        TxtAdmNo.Text = ObjCls.FnExecuteScalar(strsqlOi).ToString();

        string strAGsql = "SELECT TCD.cName FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nClassId=TCD.nId and TCD.cttype='CLS' inner join TblStudentAdmissionDetails TAD on TAD.nClassId=S.nClassId   WHERE   S.nId=" + StudID;
        var ClassId = ObjCls.FnExecuteScalar(strAGsql).ToString();

        string strADsql = "SELECT TCD.cName FROM  TblClassDetails TCD inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=TCD.nId  and  TCD.cttype='DIVN'   WHERE   TAD.nStudentID=" + StudID;
        var DivisionId = ObjCls.FnExecuteScalar(strADsql).ToString();

        TxtGrpSec.Text = ClassId + '/' + DivisionId;


    }

    public void FnFillGrd()
    {
       
        DataTable DDT = new DataTable();
        var StudIID = CtrlGrdStudent.SelectedValue;
        var FeeType = DdlFeeType.SelectedValue;
        var InstDate = CtrlInsDate.DateText;

        
        string strAIsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nInstituteId=4 and TCD.cttype='INGRP'    WHERE   S.nId=" + StudIID;
        var InstituteId = ObjCls.FnExecuteScalar(strAIsql).ToString();
        

        string strAGsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nClassId=TCD.nId and TCD.cttype='CLS' inner join TblStudentAdmissionDetails TAD on TAD.nClassId=S.nClassId   WHERE   S.nId=" + StudIID;
        var ClassId = ObjCls.FnExecuteScalar(strAGsql).ToString();

       
        string strADsql = "SELECT TCD.nId from TblClassDetails TCD  inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=TCD.nId  and  TCD.cttype='DIVN' WHERE    TAD.nStudentID=" + StudIID;
        var DivisionId = ObjCls.FnExecuteScalar(strADsql).ToString();



        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPTestTFineAmt", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@return", SqlDbType.Int);
                parm.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(parm);
                cmd.Parameters.AddWithValue("@nStudIID", StudIID);
                cmd.Parameters.AddWithValue("@nInstDate", InstDate);
                cmd.Parameters.AddWithValue("@nInstID", InstituteId);
                cmd.Parameters.AddWithValue("@nClassID", ClassId);
                cmd.Parameters.AddWithValue("@nDivID", DivisionId);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                int FinAmt = Convert.ToInt32(parm.Value);
                TxtCumAmount.Text = FinAmt.ToString();
            }

        }




        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPTestT4", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
               
                
                cmd.Parameters.AddWithValue("@nStudIID", StudIID);
                cmd.Parameters.AddWithValue("@nFeeType", FeeType);
                cmd.Parameters.AddWithValue("@nInstDate", InstDate);
                cmd.Parameters.AddWithValue("@nInstID", InstituteId);
                cmd.Parameters.AddWithValue("@nClassID", ClassId);
                cmd.Parameters.AddWithValue("@nDivID", DivisionId);
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


    public void FnInsert()
    {


        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

        string ReceiptNo = TxtRptNo.Text;
        DateTime ReceptDate = ObjCls.FnDateTime(CtrlRptDate.DateText);
        string AdmissionNo = TxtAdmNo.Text;
        int StudIID = ObjCls.FnIsNumeric(CtrlGrdStudent.SelectedValue);
        DateTime InstDate = ObjCls.FnDateTime(CtrlInsDate.DateText);
        string GroupSection = TxtGrpSec.Text;
        Boolean ShowPayable = (ChkSwPay.Checked == true ? true : false);
        int AccLedger = ObjCls.FnIsNumeric(CtrlGridHdOfAcc.SelectedValue);
        int FeeType = ObjCls.FnIsNumeric(DdlFeeType.SelectedValue);
        Boolean FineCumeStatus= (ChkCumulative.Checked == true ? true : false);
        var FineAmount = TxtCumAmount.Text;
        float TotalAmtPayable = ObjCls.FnIsNumeric(TxtAmntPayable.Text);
        float AmountIncludingFine = ObjCls.FnIsNumeric(TxtTotAmnt.Text);
        float NetPayable = ObjCls.FnIsNumeric(TxtNtPayable.Text);
        string ChequeDDNo = TxtCheqDDNo.Text;
        DateTime ChequeDDDate= ObjCls.FnDateTime(CtrlChqDDDate.DateText);
        string PayableAt = TxtPayAt.Text;
        string Remarks = TxtRemarks.Text;
        Boolean PrInsname = (ChkPrInsname.Checked == true ? true : false);
        Boolean UseAbbrevation = (ChkUseAbbr.Checked == true ? true : false);
        Boolean SendSMS = (ChkSendSMS.Checked == true ? true : false);
        Boolean UseDefault = (ChkUseDftCase.Checked == true ? true : false);
        Boolean PrFeeNameSummary = (ChkPrntSumm.Checked == true ? true : false);


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand("Insert into TblFeeCollection(nReciptNo, nReciptDate, nAdmissionNo, nStudentId, nInstallmentDate, nGroupSection, nShowPayable, nAccLedgerId, nFeeTypeId, nFineCumulative, nFineAmount, nTotalAmountPayable, nAmountPayableIncludeFine, nNetAmountPayable, nChequeDDNo, nChequeDDDate,  cPayableAt, cRemarks, nPrintInstallmentName, nUseAbbrevation, nSendSMS, nUseDefault, nFeePrintNameSummary, nCompanyId, nBranchId, nFaId, nAcId) VALUES('" + ReceiptNo + "','" + ReceptDate + "','" + AdmissionNo + "'," + StudIID + ",'" + InstDate + "','" + GroupSection + "','" + ShowPayable + "'," + AccLedger + "," + FeeType + ",'" + FineCumeStatus + "','" + FineAmount + "','" + TotalAmtPayable + "','" + AmountIncludingFine + "','" + NetPayable + "','" + ChequeDDNo + "','" + ChequeDDDate + "','" + PayableAt + "','" + Remarks + "','" + PrInsname + "','" + UseAbbrevation + "','" + SendSMS + "','" + UseDefault + "','" + PrFeeNameSummary + "'," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + ")", con);
        con.Open();
        int i = cmd.ExecuteNonQuery();



        SqlCommand cmd2 = new SqlCommand("SELECT nId FROM TblFeeCollection    WHERE  nReciptNo=" + ReceiptNo, con);
        object result = cmd2.ExecuteScalar();
        var RR = result.ToString();

        for (int k = 0; k < GrdVwRecords.Rows.Count; k++)
        {

            HdnId = (HiddenField)GrdVwRecords.Rows[k].FindControl("HdnId");
            TotalFee = (Label)GrdVwRecords.Rows[k].FindControl("LblTotalFee");
            Concession = (Label)GrdVwRecords.Rows[k].FindControl("LblConcession");
            Paid = (Label)GrdVwRecords.Rows[k].FindControl("LblPaid");
            Excess = (Label)GrdVwRecords.Rows[k].FindControl("LblExcess");
            Payable = (TextBox)GrdVwRecords.Rows[k].FindControl("TxtPayable");

            SqlCommand cmd1 = new SqlCommand("Insert into TblFeeCollectionDT(nHId, nFeeId, nTotalFee, nConcession, nPaid, nExcess, nPayable) VALUES('" + result + "'," + HdnId.Value + ",'" + TotalFee.Text + "','" + Concession.Text + "','" + Payable.Text + "','" + Excess.Text + "','" + Payable.Text + "')", con);
            
            cmd1.ExecuteNonQuery();
           



        }
        con.Close();

    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
              
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
            {
                Label TotalFees = ((Label)e.Row.FindControl("LblTotalFee"));
                Label Conce = ((Label)e.Row.FindControl("LblConcession"));
                Label PaidV = ((Label)e.Row.FindControl("LblPaid"));
                Label Excess = ((Label)e.Row.FindControl("LblExcess"));
                float Payable = float.Parse(TotalFees.Text) - float.Parse(Conce.Text) - float.Parse(PaidV.Text);
                if(Payable>=0)
                {
                    ((TextBox)e.Row.FindControl("TxtPayable")).Text = Payable.ToString();
                }
                else
                {
                    ((TextBox)e.Row.FindControl("TxtPayable")).Text = "0";
                    ((Label)e.Row.FindControl("LblExcess")).Text= (Math.Abs(Payable)).ToString();
                }
                

                TextBox PayableAMT = ((TextBox)e.Row.FindControl("TxtPayable"));

                PayableAMT.Attributes.Add("onchange", "Myfunction('"+ PayableAMT.ClientID + "','" + TxtAmntPayable.ClientID + "','" + TxtCumAmount.ClientID + "','" + TxtTotAmnt.ClientID + "','" + TxtNtPayable.ClientID + "')");

            }
        }
    }




    protected void TxtCumAmount_TextChanged(object sender, EventArgs e)
    {
        int TotAmt = 0, FinAmt = 0;
        TotAmt = ObjCls.FnIsNumeric(TxtAmntPayable.Text);
        FinAmt = ObjCls.FnIsNumeric(TxtCumAmount.Text);
        TxtTotAmnt.Text = (TotAmt + FinAmt).ToString();
        TxtNtPayable.Text = TxtTotAmnt.Text;
    }



    public void FnFillGrdList()
    {

        DataTable DTList = new DataTable();
        var StudIID = CtrlGrdStudent.SelectedValue;
        var FeeType = DdlFeeType.SelectedValue;
        var InstDate = CtrlInsDate.DateText;


        using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("SPFillGridList", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                               
                int i = cmd.ExecuteNonQuery();
                con.Close();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(DTList);
                }
            }

            ViewState["DT_List"] = DTList;
            GrdReceiptList.DataSource = DTList;
            GrdReceiptList.DataBind();
        }

    }
    protected void cmdFill_Click(object sender, EventArgs e)
    {
        FnFillGrdList();
       
    }


    public void FnFillData(string strValue)
    {

        DataTable DTList = new DataTable();
        int STIDD,HDACC;
        
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        
        SqlCommand cmd = new SqlCommand("select * from TblFeeCollection where nId="+ strValue, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            TxtRptNo.Text = dr[1].ToString();
            String  RecptIDate = dr[2].ToString();
            DateTime parsedRDate = DateTime.ParseExact(RecptIDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            string formattedRDate = parsedRDate.ToString("dd/MMM/yyyy");
            CtrlRptDate.DateText = formattedRDate;
            TxtAdmNo.Text = dr[3].ToString();
            CtrlGrdStudent.SelectedValue = dr[4].ToString();
            String IDate = dr[5].ToString();
            DateTime parsedDate = DateTime.ParseExact(IDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            string formattedDate = parsedDate.ToString("dd/MMM/yyyy");
            CtrlInsDate.DateText = formattedDate;

            TxtGrpSec.Text= dr[6].ToString();
            int SWP = ObjCls.FnIsNumeric(dr[7]);
            ChkSwPay.Checked = (SWP== 1 ? true : false);
            CtrlGridHdOfAcc.SelectedValue= dr[8].ToString();
            HDACC = ObjCls.FnIsNumeric(dr[8]);
           
            DdlFeeType.SelectedValue= dr[9].ToString();
            int CUM = ObjCls.FnIsNumeric(dr[10]);
            ChkCumulative.Checked = (CUM == 1 ? true : false);
            TxtCumAmount.Text= dr[11].ToString();
            TxtAmntPayable.Text= dr[12].ToString();
            TxtTotAmnt.Text= dr[13].ToString();
            TxtNtPayable.Text= dr[14].ToString();
            TxtCheqDDNo.Text= dr[15].ToString();
            CtrlChqDDDate.DateText= dr[16].ToString();
            TxtPayAt.Text= dr[17].ToString();
            TxtRemarks.Text = dr[18].ToString();
            int PrInsname= ObjCls.FnIsNumeric(dr[19]);
            ChkPrInsname.Checked= (PrInsname == 1 ? true : false);
            int UseAbbrevation = ObjCls.FnIsNumeric(dr[20]);
            ChkUseAbbr.Checked = (UseAbbrevation == 1 ? true : false);
            int SendSMS = ObjCls.FnIsNumeric(dr[21]);
            ChkSendSMS.Checked = (SendSMS == 1 ? true : false);
            int UseDefault = ObjCls.FnIsNumeric(dr[22]);
            ChkUseDftCase.Checked = (UseDefault == 1 ? true : false);
            int PrFeeNameSummary = ObjCls.FnIsNumeric(dr[22]);
            ChkPrntSumm.Checked = (PrFeeNameSummary == 1 ? true : false);
        }

       

        con.Close();


        string strStudsql = "SELECT cName FROM TblRegistrationStudent   WHERE  nId=" + CtrlGrdStudent.SelectedValue;
        var result = ObjCls.FnExecuteScalar(strStudsql).ToString();
        CtrlGrdStudent.SelectedText = result;

        //string strAHDsql = "SELECT cName FROM TblRegistrationStudent   WHERE  nId=" + CtrlGridHdOfAcc.SelectedValue;
        //var AccHead = ObjCls.FnExecuteScalar(strAHDsql).ToString();
        //CtrlGridHdOfAcc.SelectedText = AccHead;

        using (SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        {
            using (SqlCommand cmd1 = new SqlCommand("SPFillGridData", con1))
            {
                con1.Open();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@nReceipt", strValue);
                int i = cmd1.ExecuteNonQuery();
                con1.Close();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(DTList);
                }
            }

            ViewState["DT_List"] = DTList;
            GrdVwRecords.DataSource = DTList;
            GrdVwRecords.DataBind();
        }

        FnGrandPayableTotalAmt();

    }



   

    protected void GrdReceiptList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        GrdReceiptList.SelectedIndex = e.NewSelectedIndex;
        var IND= e.NewSelectedIndex;
        
        string strValue = ((HiddenField)GrdReceiptList.SelectedRow.Cells[1].FindControl("HdnId")).Value;
               
        LblnId.Text= strValue;

        FnFillData(strValue);
        TabContainer1.ActiveTabIndex = 0;
        CtrlCommand1.SaveText = "Update";
        CtrlCommand1.SaveCommandArgument = "UPDATE";
    }


    public void FnUpdate()
    {

        var LblnIdV = LblnId.Text;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

        string ReceiptNo = TxtRptNo.Text;
        DateTime ReceptDate = ObjCls.FnDateTime(CtrlRptDate.DateText);
        string AdmissionNo = TxtAdmNo.Text;
        int StudIID = ObjCls.FnIsNumeric(CtrlGrdStudent.SelectedValue);
        DateTime InstDate = ObjCls.FnDateTime(CtrlInsDate.DateText);
        string GroupSection = TxtGrpSec.Text;
        Boolean ShowPayable = (ChkSwPay.Checked == true ? true : false);
        int AccLedger = ObjCls.FnIsNumeric(CtrlGridHdOfAcc.SelectedValue);
        int FeeType = ObjCls.FnIsNumeric(DdlFeeType.SelectedValue);
        Boolean FineCumeStatus = (ChkCumulative.Checked == true ? true : false);
        var FineAmount = TxtCumAmount.Text;
        float TotalAmtPayable = ObjCls.FnIsNumeric(TxtAmntPayable.Text);
        float AmountIncludingFine = ObjCls.FnIsNumeric(TxtTotAmnt.Text);
        float NetPayable = ObjCls.FnIsNumeric(TxtNtPayable.Text);
        string ChequeDDNo = TxtCheqDDNo.Text;
        DateTime ChequeDDDate = ObjCls.FnDateTime(CtrlChqDDDate.DateText);
        string PayableAt = TxtPayAt.Text;
        string Remarks = TxtRemarks.Text;
        Boolean PrInsname = (ChkPrInsname.Checked == true ? true : false);
        Boolean UseAbbrevation = (ChkUseAbbr.Checked == true ? true : false);
        Boolean SendSMS = (ChkSendSMS.Checked == true ? true : false);
        Boolean UseDefault = (ChkUseDftCase.Checked == true ? true : false);
        Boolean PrFeeNameSummary = (ChkPrntSumm.Checked == true ? true : false);


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand(" Update TblFeeCollection set nReciptNo= '" + ReceiptNo + "',nReciptDate='" + ReceptDate + "' ,nAdmissionNo='" + AdmissionNo + "' ,nStudentId= " + StudIID + ",nInstallmentDate='" + InstDate + "' ,nGroupSection='" + GroupSection + "' ,nShowPayable='" + ShowPayable + "' ,nAccLedgerId=" + AccLedger + " ,nFeeTypeId=" + FeeType + " ,nFineCumulative='" + FineCumeStatus + "' ,nFineAmount='" + FineAmount + "' ,nTotalAmountPayable='" + TotalAmtPayable + "' ,nAmountPayableIncludeFine='" + AmountIncludingFine + "' ,nNetAmountPayable='" + NetPayable + "' ,nChequeDDNo='" + ChequeDDNo + "' ,nChequeDDDate='" + ChequeDDDate + "' ,cPayableAt='" + PayableAt + "' ,cRemarks='" + Remarks + "' ,nPrintInstallmentName='" + PrInsname + "' ,nUseAbbrevation='" + UseAbbrevation + "' ,nSendSMS='" + SendSMS + "' ,nUseDefault='" + UseDefault + "' ,nFeePrintNameSummary='" + PrFeeNameSummary + "' where nId="+ LblnIdV, con);
        con.Open();
        int i = cmd.ExecuteNonQuery();



        SqlCommand cmd2 = new SqlCommand("Delete FROM TblFeeCollectionDT  WHERE  nHId=" + LblnIdV, con);
        object result = cmd2.ExecuteScalar();
       

        for (int k = 0; k < GrdVwRecords.Rows.Count; k++)
        {

            HdnId = (HiddenField)GrdVwRecords.Rows[k].FindControl("HdnId");
            TotalFee = (Label)GrdVwRecords.Rows[k].FindControl("LblTotalFee");
            Concession = (Label)GrdVwRecords.Rows[k].FindControl("LblConcession");
            Paid = (Label)GrdVwRecords.Rows[k].FindControl("LblPaid");
            Excess = (Label)GrdVwRecords.Rows[k].FindControl("LblExcess");
            Payable = (TextBox)GrdVwRecords.Rows[k].FindControl("TxtPayable");

            SqlCommand cmd1 = new SqlCommand("Insert into TblFeeCollectionDT(nHId, nFeeId, nTotalFee, nConcession, nPaid, nExcess, nPayable) VALUES('" + LblnIdV + "'," + HdnId.Value + ",'" + TotalFee.Text + "','" + Concession.Text + "','" + Payable.Text + "','" + Excess.Text + "','" + Payable.Text + "')", con);

            cmd1.ExecuteNonQuery();




        }
        con.Close();

    }


}