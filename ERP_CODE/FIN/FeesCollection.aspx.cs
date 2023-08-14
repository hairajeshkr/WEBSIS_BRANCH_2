using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

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
                //DdlFeeType.Items.Add(new ListItem("All", "0"));
                //DdlFeeType.SelectedValue = "0";
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
                CtrlRptDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");
                CtrlInsDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");

                //DdlFeeType.Items.Add(new ListItem("All", "0"));
                //DataTable ClsTC = (ObjCls.FnGetDataSet("select  TCD.nId nId, TCD.cName cName FROM TblGeneral where cTType ='FETYPE' ") as DataSet).Tables[0];
                //DdlFeeType.DataSource = ClsTC;
                //DdlFeeType.DataValueField = "nId";
                //DdlFeeType.DataTextField = "cName";
                //DdlFeeType.DataBind();

            }
            //CtrlGrdClass.ParentControl = CtrlGrdInstitute.IdControl;
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
        //ObjCls.Name = TxtName.Text.Trim();
        //ObjCls.Code = TxtCode.Text.Trim();
        //ObjCls.Abbrevation = TxtAbbrevation.Text.Trim();
        //ObjCls.Priority = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());  // max no of Admission
        //ObjCls.StartDate = ObjCls.FnDateTime(CtrlStartDate.DateText);
        ////String.Format("{0:G}", dt)

        ////ObjCls.StartDate = ObjCls.FnDateTime(String.Format("{0:G}", CtrlStartDate.DateText));

        ////Response.Write(CtrlStartDate.DateText);
        ////ObjCls.EndDate = ObjCls.FnDateTime(CtrlDueDate.DateText);

        //ObjCls.EndDate = ObjCls.FnDateTime(CtrlDueDate.DateText);
        ////ObjCls.EndDate = ObjCls.FnDateTime(String.Format("{0:G}", CtrlDueDate.DateText));

        //ObjCls.Remarks = TxtRemarks.Text.Trim();
        ////ObjCls.IsApprove = (ChkApprove.Checked == true ? true : false);
        //ObjCls.IsEca = (ChkECAInstallment.Checked == true ? true : false);
        //ObjCls.IsOneTime = (ChkOneTimeInstallment.Checked == true ? true : false);

        ////ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }
    public override void FnCancel()
    {
        base.FnCancel();

        //TxtName.Text = "";
        //TxtName.Text = "";
        //TxtCode.Text = "";
        //TxtAbbrevation.Text = "";
        //TxtPriority.Text = "";
        //CtrlStartDate.DateText = "";
        //CtrlDueDate.DateText = "";
        ////CtrlDueDate.DateText = getdate();
        //TxtCode_Srch.Text = "";
        //TxtRemarks.Text = "";
        //ChkActive.Checked = true;
        //ChkApprove.Checked = false;
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        //FnFocus(TxtName);
    }


    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        //ObjCls.Name = TxtName.Text.Trim();
        //ObjCls.Code = TxtCode_Srch.Text.Trim();
        ObjCls.StartDate = ObjCls.FnDateTime(DateTime.Now.ToString());
        ObjCls.EndDate = ObjCls.FnDateTime(DateTime.Now.ToString());

        // ObjCls.ApplicationNo= TxtMaxAddmission.Text.Trim();  /// maximum no of admission
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
                    //    if (TxtName.Text.Trim().Length <= 0)
                    //    {
                    //        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                    //        FnFocus(TxtName);
                    //        return;
                    //    }

                    //    FnAssignProperty();
                    //    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    //    {
                    //        case "NEW":
                    //            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                    //            break;
                    //        case "UPDATE":
                    //            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                    //            break;
                    //    }
                    Insert();
                   break;
                //case "DELETE":
                //    FnAssignProperty();
                //    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    break;
                //case "CLEAR":
                //    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
                //    FnCancel();
                //    break;
                //case "CLOSE":
                //    ObjCls.FnAlertMessage(" You Have No permission To Close Record");
                //    break;
                //case "PRINT":
                //    FnAssignProperty();
                //    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    break;
                //case "FIND":
                //    FnFindRecord();
                //    //FnAssignProperty();
                //    //base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                //    //FnGridViewBinding("");
                //    //System.Threading.Thread.Sleep(1000000);
                //    break;
                //case "HELP":
                //    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                //    break;

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

    protected void Btndetails_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void cmdFill_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 0;
        //CtrlGrdInstitute.SelectedValue;
        var StudID= CtrlGrdStudent.SelectedValue;
        //TxtName.Text = CtrlGrdStudent.SelectedText;
        //TxtGrpSec.Text = CtrlGrdClass.SelectedText + '/' + CtrlGrdDiv.SelectedText;
        //string strsqlOi = "SELECT cAdmissionNo FROM TblRegistrationStudent WHERE nId=" + StudID;
        //TxtAdmNo.Text = ObjCls.FnExecuteScalar(strsqlOi).ToString();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable ClsTGFI = (ObjCls.FnGetDataSet("select * from TblFeeMaster   ") as DataSet).Tables[0];
        //DataTable ClsTGFI = (ObjCls.FnGetDataSet("select  nId ID,cName Feename,0 TotalFee,0 Concession,0 Paid,0 Excess,0 Payable from TblFeeMaster where cTType='FEES' and nFeeTypeId=" + DdlFeeType.SelectedValue ) as DataSet).Tables[0];
       // DataTable ClsTGFI = (ObjCls.FnGetDataSet("select  nId ID,FM.cName Feename,0 TotalFee,0 Concession,0 Paid,0 Excess,0 Payable from TblFeeAssign FA inner join TblFeeMaster FM on FM.nId=FA.nFeeMasterId and FM.nFeeTypeId=" + DdlFeeType.SelectedValue + " where cTType='FEES'") as DataSet).Tables[0];
        //GrdVwRecords.DataSource = ClsTGFI;
        //GrdVwRecords.DataBind();

        FillGrd();

        GrdVwRecords.DataSource =  ViewState["DT2"];
        GrdVwRecords.DataBind();

        GrandTotal();

        int GTotalP = Convert.ToInt32(TxtAmntPayable.Text);
        float CD = (float) GTotalP;
        float GTotalC = float.Parse(TxtCumAmount.Text);

        TxtTotAmnt.Text = (CD + GTotalC).ToString();

    }

    [WebMethod]
    private  void GrandTotal()
    {
        float GTotal = 0f;
        for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
        {
            String total = (GrdVwRecords.Rows[i].FindControl("TxtPayable") as TextBox).Text;
            GTotal += Convert.ToSingle(total);
            
        }
         TxtAmntPayable.Text = GTotal.ToString();
        
    }

   
    public static void   GrandTotal1()
    {
        //float GTotal = 0f;
        //for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
        //{
        //    String total = (GrdVwRecords.Rows[i].FindControl("TxtPayable") as TextBox).Text;
        //    GTotal += Convert.ToSingle(total);

        //}
        //TxtAmntPayable.Text = GTotal.ToString();
        //GrandTotal();

    }

    public static string InsertData(string nFEEId)
    {
        string msg = string.Empty;

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");

        ///SqlCommand cmd = new SqlCommand("Insert into TblFeeAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount,nCompanyId, nBranchId, nFaId,nAcId,nAccLedgerId,nOrderIndex) VALUES(" + nFEEId + "," + nINSSTALId + "," + nINSTIId + "," + nCLSId + "," + nDIVId + "," + nSTUDId + "," + nAmount + "," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + "," + nAccLedgerId + "," + nOrderIndex + ")", con);
        //con.Open();
        //int i = cmd.ExecuteNonQuery();
        //con.Close();
        int i=1;
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



    protected void CtrlGrdStudent_Init(object sender, EventArgs e)
    {
        var StudID = CtrlGrdStudent.SelectedValue;
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
        var CC = ObjCls.FnExecuteScalar(strAGsql).ToString();

        string strADsql = "SELECT TCD.cName FROM  TblClassDetails TCD inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=TCD.nId  and  TCD.cttype='DIVN'   WHERE   TAD.nStudentID=" + StudID;
        var DV = ObjCls.FnExecuteScalar(strADsql).ToString();

        TxtGrpSec.Text = CC + '/' + DV;


    }

    public void FillGrd()
    {
        string msg = string.Empty;
        //string VV = TId;
        DataTable DDT = new DataTable();
        var StudIID = CtrlGrdStudent.SelectedValue;
        var FeeType = DdlFeeType.SelectedValue;
        var InstDate = CtrlInsDate.DateText;

        DataTable ClsTGFI = (ObjCls.FnGetDataSet("select * from TblClassDetails   ") as DataSet).Tables[0];
        DataTable ClsTGFI1 = (ObjCls.FnGetDataSet("select * from TblRegistrationStudent   ") as DataSet).Tables[0];
        DataTable ClsTGFI2 = (ObjCls.FnGetDataSet("select * from TblStudentAdmissionDetails   ") as DataSet).Tables[0];

        DataTable ClsTGFI3 = (ObjCls.FnGetDataSet("select  * from TblFineSettings   ") as DataSet).Tables[0];

        string strAIsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nInstituteId=4 and TCD.cttype='INGRP'    WHERE   S.nId=" + StudIID;
        var INSTID = ObjCls.FnExecuteScalar(strAIsql).ToString();
        //var INSTID = 1;


        string strAGsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nClassId=TCD.nId and TCD.cttype='CLS' inner join TblStudentAdmissionDetails TAD on TAD.nClassId=S.nClassId   WHERE   S.nId=" + StudIID;
        var CLSID = ObjCls.FnExecuteScalar(strAGsql).ToString();

        //string strADsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nDivisionId=TCD.nId and TCD.cttype='DIVN' inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=S.nDivisionId   WHERE   S.nId=" + StudIID;
        //var DIVID = ObjCls.FnExecuteScalar(strADsql).ToString();

        string strADsql = "SELECT TCD.nId from TblClassDetails TCD  inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=TCD.nId  and  TCD.cttype='DIVN' WHERE    TAD.nStudentID=" + StudIID;
        var DIVID = ObjCls.FnExecuteScalar(strADsql).ToString();

        //string strAFsql = "select Top 1  nAmount  from TblFineSettings FN inner join TblRegistrationStudent S on FN.nStudentId=S.nId where FN.dDueDate>='" + InstDate + "' and FN.nStudentId=" + StudIID;
        //var FineAmt = ObjCls.FnExecuteScalar(strAFsql).ToString();
        //TxtCumAmount.Text = FineAmt;



        //string strAFsql = "select  nAmount  from TblFineSettings FN inner join TblRegistrationStudent S on FN.nStudentId=S.nId where FN.dDueDate<='" + InstDate + "' and FN.nStudentId=" + StudIID;
        //object V = ObjCls.FnExecuteNonQuery("select  nAmount  from TblFineSettings FN inner join TblRegistrationStudent S on FN.nStudentId=S.nId where FN.dDueDate<='" + InstDate + "' and FN.nStudentId=" + StudIID)

        //SqlCommand cmd = new SqlCommand("Insert into TblFeeCollection(nReciptNo, nReciptDate, nAdmissionNo, nStudentId, nInstallmentDate, nGroupSection, nShowPayable, nAccLedgerId, nFeeTypeId, nFineCumulative, nFineAmount, nTotalAmountPayable, nAmountPayableIncludeFine, nNetAmountPayable, nChequeDDNo, nChequeDDDate,  cPayableAt, cRemarks, nPrintInstallmentName, nUseAbbrevation, nSendSMS, nUseDefault, nFeePrintNameSummary, nCompanyId, nBranchId, nFaId, nAcId) VALUES('" + ReceiptNo + "','" + ReceptDate + "','" + AdmissionNo + "'," + StudIID + ",'" + InstDate + "','" + GroupSection + "','" + ShowPayable + "'," + AccLedger + "," + FeeType + ",'" + FineCumeStatus + "','" + FineAmount + "','" + TotalAmtPayable + "','" + AmountIncludingFine + "','" + NetPayable + "','" + ChequeDDNo + "','" + ChequeDDDate + "','" + PayableAt + "','" + Remarks + "','" + PrInsname + "','" + UseAbbrevation + "','" + SendSMS + "','" + UseDefault + "','" + PrFeeNameSummary + "'," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + ")", con);
        //con.Open();
        //int i = cmd.ExecuteNonQuery();


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
                cmd.Parameters.AddWithValue("@nInstID", INSTID);
                cmd.Parameters.AddWithValue("@nClassID", CLSID);
                cmd.Parameters.AddWithValue("@nDivID", DIVID);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                int FinAmt = Convert.ToInt32(parm.Value);
                TxtCumAmount.Text = FinAmt.ToString();
                //using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                //{
                //    da.Fill(DDT);
                //}
            }


            //ViewState["DT2"] = DDT;
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
                cmd.Parameters.AddWithValue("@nInstID", INSTID);
                cmd.Parameters.AddWithValue("@nClassID", CLSID);
                cmd.Parameters.AddWithValue("@nDivID", DIVID);
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


    public void Insert()
    {


        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;

        string ReceiptNo = TxtRptNo.Text;
        DateTime ReceptDate = ObjCls.FnDateTime(CtrlRptDate.DateText);
        int AdmissionNo = ObjCls.FnIsNumeric(TxtAdmNo.Text);
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


        Int32 newProdID = 0;

        SqlCommand cmd2 = new SqlCommand("SELECT nId FROM TblFeeCollection    WHERE  nReciptNo=" + ReceiptNo, con);
        // newProdID = (Int32)cmd2.ExecuteScalar();
        object result = cmd2.ExecuteScalar();
        var RR = result.ToString();

        for (int k = 0; k < GrdVwRecords.Rows.Count; k++)
        {

            HdnId = (HiddenField)GrdVwRecords.Rows[k].FindControl("HdnId");
            //String total = (GrdVwRecords.Rows[k].FindControl("LblPayable") as Label).Text;

            TotalFee = (Label)GrdVwRecords.Rows[k].FindControl("LblTotalFee");
            Concession = (Label)GrdVwRecords.Rows[k].FindControl("LblConcession");
            Paid = (Label)GrdVwRecords.Rows[k].FindControl("LblPaid");
            Excess = (Label)GrdVwRecords.Rows[k].FindControl("LblExcess");
            Payable = (TextBox)GrdVwRecords.Rows[k].FindControl("TxtPayable");


            //float PaidV = float.Parse(Paid.Text) + float.Parse(Payable.Text);

            SqlCommand cmd1 = new SqlCommand("Insert into TblFeeCollectionDT(nHId, nFeeId, nTotalFee, nConcession, nPaid, nExcess, nPayable) VALUES('" + result + "'," + HdnId.Value + ",'" + TotalFee.Text + "','" + Concession.Text + "','" + Payable.Text + "','" + Excess.Text + "','" + Payable.Text + "')", con);
            
            cmd1.ExecuteNonQuery();
           



        }
        con.Close();

        //[nTotalFee] [numeric](18, 3) NULL,
        //[nConcession] [numeric](18, 3) NULL,
        //[nPaid] [numeric](18, 3) NULL,
        //[nExcess] [numeric](18, 3) NULL,
        //[nPayable] [numeric](18, 3) NULL



        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        //SqlCommand cmd = new SqlCommand("Insert into TblFeeAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount,nCompanyId, nBranchId, nFaId,nAcId,nAccLedgerId,nOrderIndex) VALUES(" + nFEEId + "," + nINSSTALId + "," + nINSTIId + "," + nCLSId + "," + nDIVId + "," + nSTUDId + "," + nAmount + "," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + "," + nAccLedgerId + "," + nOrderIndex + ")", con);
        //con.Open();
        //int i = cmd.ExecuteNonQuery();
        //con.Close();




        //using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
        //{
        //    using (SqlCommand cmd = new SqlCommand("SPTestT4", con))
        //    {
        //        con.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;


        //        cmd.Parameters.AddWithValue("@nStudIID", StudIID);
        //        cmd.Parameters.AddWithValue("@nFeeType", FeeType);
        //        cmd.Parameters.AddWithValue("@nInstDate", InstDate);
        //        cmd.Parameters.AddWithValue("@nInstID", INSTID);
        //        cmd.Parameters.AddWithValue("@nClassID", CLSID);
        //        cmd.Parameters.AddWithValue("@nDivID", DIVID);
        //        int i = cmd.ExecuteNonQuery();
        //        con.Close();
        //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //        {
        //            da.Fill(DDT);
        //        }
        //    }


        //    ViewState["DT2"] = DDT;
        //}




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
                float Payable = float.Parse(TotalFees.Text) - float.Parse(Conce.Text) - float.Parse(PaidV.Text);
                ((TextBox)e.Row.FindControl("TxtPayable")).Text = Payable.ToString();

                TextBox PayableAMT = ((TextBox)e.Row.FindControl("TxtPayable"));
                PayableAMT.Attributes.Add("onchange", "Myfunction('"+ PayableAMT.ClientID + "','" + TxtAmntPayable.ClientID + "')");


            }
        }
    }

   

}