using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class FIN_FeesCollection : ClsPageEvents, IPageInterFace
{
    ClsFeeInstallmentMaster ObjCls = new ClsFeeInstallmentMaster();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

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
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
                CtrlRptDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");
                CtrlInsDate.DateText = DateTime.Now.ToString("dd/MMM/yyyy");
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
                //case "SAVE":
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
                //    break;
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

        TxtTotAmnt.Text = (CD - GTotalC).ToString();

    }


    private void GrandTotal()
    {
        float GTotal = 0f;
        for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
        {
            String total = (GrdVwRecords.Rows[i].FindControl("LblPayable") as Label).Text;
            GTotal += Convert.ToSingle(total);
        }
        TxtAmntPayable.Text = GTotal.ToString();
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

        string strADsql = "SELECT TCD.cName FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nDivisionId=TCD.nId and TCD.cttype='DIVN' inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=S.nDivisionId   WHERE   S.nId=" + StudID;
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

        DataTable ClsTGFI3 = (ObjCls.FnGetDataSet("select * from TblFineSettings   ") as DataSet).Tables[0];

        string strAIsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nInstituteId=4 and TCD.cttype='INGRP'    WHERE   S.nId=" + StudIID;
        var INSTID = ObjCls.FnExecuteScalar(strAIsql).ToString();
        //var INSTID = 1;


        string strAGsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nClassId=TCD.nId and TCD.cttype='CLS' inner join TblStudentAdmissionDetails TAD on TAD.nClassId=S.nClassId   WHERE   S.nId=" + StudIID;
        var CLSID = ObjCls.FnExecuteScalar(strAGsql).ToString();

        string strADsql = "SELECT TCD.nId FROM TblRegistrationStudent S inner join TblClassDetails TCD on S.nDivisionId=TCD.nId and TCD.cttype='DIVN' inner join TblStudentAdmissionDetails TAD on TAD.nDivisionId=S.nDivisionId   WHERE   S.nId=" + StudIID;
        var DIVID = ObjCls.FnExecuteScalar(strADsql).ToString();


        string strAFsql = "select  nAmount  from TblFineSettings FN inner join TblRegistrationStudent S on FN.nStudentId=S.nId where FN.dDueDate>='" + InstDate + "' and FN.nStudentId=" + StudIID;
        var FineAmt = ObjCls.FnExecuteScalar(strAFsql).ToString();
        TxtCumAmount.Text = FineAmt;

       


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



}