using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

public partial class STUDENT_MarkAsgnStudent : ClsPageEvents, IPageInterFace
{
    string connString = "Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True";
    ClsAcademicMarkAssign ObjCls = new ClsAcademicMarkAssign();
    TextBox TxtMark;
    HiddenField HdnId, HdnRwIndex;
    DropDownList DdlGrde;
    Label LblGrade;
    DataTable DT = new DataTable();
    DataTable DTGrade = new DataTable();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //FnFillDdlGrade();
                FnInitializeForm();
                
            }
            CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void FnFillDdlGrade()
    {
        //string query = "select nId,cName from Tbl ";
    }
    protected void FnFindGrid()
    {
        DropDownList ddlgrade;
        Label lbgrade;
        if (DdlEntryType.SelectedValue=="1")
        {
            string query = "select TRS.nId ID,TRS.cName Name,TRS.cAdmissionNo AdmissionNo,TASS.nObtainedMark ObtainedMark from tblregistrationstudent TRS inner join TblStudentAdmissionDetails TSAD on TSAD.nStudentId = TRS.nId inner join TblClassDetails TCD on TCD.nId = TRS.nClassId and TCD.cTType = 'CLS' inner join TblClassDetails TCDD on TCDD.nId = TRS.nDivisionId and TCDD.cTType = 'DIVN' left join TblAcademicMarkAssign TASS on TASS.nStudentId = TSAD.nStudentId left join TblAcademicSubject TAS on TAS.nId = TASS.nSubjectId left join TblAcademicTermMaster TATM on TATM.nId = TASS.nTermId left join TblAcademicExamMaster TAEM on TAEM.nId = TASS.nExamId and TAEM.cTType = 'EXM' left join TblAcademicExamMaster TAEMM on TAEMM.nId = TASS.nExamSubId and TAEMM.cTType = 'SUBEXM' where TCD.nId = 10039 and TCDD.nId = 10048 and TAS.nId = 1 and TASS.nStaffId = 4 and TASS.nTermId = 1 and TASS.nExamId = 5 and TASS.nExamSubId = 3 and TASS.nEntryTypeId = 1 and TASS.nGradeSystemId = 2";
            //string query = "select TRS.nId ID,TRS.cName Name,TRS.cAdmissionNo AdmissionNo,TASS.nObtainedMark ObtainedMark from tblregistrationstudent TRS inner join TblStudentAdmissionDetails TSAD on TSAD.nStudentId = TRS.nId inner join TblClassDetails TCD on TCD.nId = TRS.nClassId and TCD.cTType = 'CLS' inner join TblClassDetails TCDD on TCDD.nId = TRS.nDivisionId and TCDD.cTType = 'DIVN' left join TblAcademicMarkAssign TASS on TASS.nStudentId = TSAD.nStudentId left join TblAcademicSubject TAS on TAS.nId = TASS.nSubjectId left join TblAcademicTermMaster TATM on TATM.nId = TASS.nTermId left join TblAcademicExamMaster TAEM on TAEM.nId = TASS.nExamId and TAEM.cTType = 'EXM' left join TblAcademicExamMaster TAEMM on TAEMM.nId = TASS.nExamSubId and TAEMM.cTType = 'SUBEXM' where TCD.nId = 10039 and TCDD.nId = 10048 and TAS.nId = 1 and TASS.nStaffId = 4 and TASS.nTermId = 1 and TASS.nExamId = 5 and TASS.nExamSubId = 3";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DT);

            conn.Close();
            da.Dispose();
            GrdVwRecords.DataSource = DT;
            GrdVwRecords.DataBind();

            
            for(int i=0;i<GrdVwRecords.Rows.Count;i++)
            {
               ddlgrade = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlGrade");
               ddlgrade.Visible = false;
            }
            
            
        }
  
        else if(DdlEntryType.SelectedValue=="2")
        {
            string query= "select TRS.nId ID,TRS.cName Name,TRS.cAdmissionNo AdmissionNo,TASS.nObtainedMark ObtainedMark from tblregistrationstudent TRS inner join TblStudentAdmissionDetails TSAD on TSAD.nStudentId = TRS.nId inner join TblClassDetails TCD on TCD.nId = TRS.nClassId and TCD.cTType = 'CLS' inner join TblClassDetails TCDD on TCDD.nId = TRS.nDivisionId and TCDD.cTType = 'DIVN' left join TblAcademicMarkAssign TASS on TASS.nStudentId = TSAD.nStudentId left join TblAcademicSubject TAS on TAS.nId = TASS.nSubjectId left join TblAcademicTermMaster TATM on TATM.nId = TASS.nTermId left join TblAcademicExamMaster TAEM on TAEM.nId = TASS.nExamId and TAEM.cTType = 'EXM' left join TblAcademicExamMaster TAEMM on TAEMM.nId = TASS.nExamSubId and TAEMM.cTType = 'SUBEXM' where TCD.nId = 10039 and TCDD.nId = 10048 and TAS.nId = 1 and TASS.nStaffId = 4 and TASS.nTermId = 1 and TASS.nExamId = 5 and TASS.nExamSubId = 3 and TASS.nEntryTypeId = 1 and TASS.nGradeSystemId = 2";
            //string query = "select TRS.nId ID,TRS.cName Name,TRS.cAdmissionNo AdmissionNo,TASS.nObtainedMark ObtainedMark from tblregistrationstudent TRS inner join TblStudentAdmissionDetails TSAD on TSAD.nStudentId = TRS.nId inner join TblClassDetails TCD on TCD.nId = TRS.nClassId and TCD.cTType = 'CLS' inner join TblClassDetails TCDD on TCDD.nId = TRS.nDivisionId and TCDD.cTType = 'DIVN' left join TblAcademicMarkAssign TASS on TASS.nStudentId = TSAD.nStudentId left join TblAcademicSubject TAS on TAS.nId = TASS.nSubjectId left join TblAcademicTermMaster TATM on TATM.nId = TASS.nTermId left join TblAcademicExamMaster TAEM on TAEM.nId = TASS.nExamId and TAEM.cTType = 'EXM' left join TblAcademicExamMaster TAEMM on TAEMM.nId = TASS.nExamSubId and TAEMM.cTType = 'SUBEXM' where TCD.nId = 10039 and TCDD.nId = 10048 and TAS.nId = 1 and TASS.nStaffId = 4 and TASS.nTermId = 1 and TASS.nExamId = 5 and TASS.nExamSubId = 3";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DT);

            conn.Close();
            da.Dispose();
            GrdVwRecords.DataSource = DT;
            GrdVwRecords.DataBind();

            int GrSyId = ObjCls.FnIsNumeric(DdlGradingSystm.SelectedValue);
            string querys = "select nId Id,cName Name from TblAcademicGradeMaster where nParentId=" + GrSyId;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd1 = new SqlCommand(querys, con);
            conn.Open();
            SqlDataAdapter daa = new SqlDataAdapter(cmd1);
            daa.Fill(DTGrade);
            

            for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
            {
                GrdVwRecords.Rows[i].Cells[3].Visible = false;
                GrdVwRecords.HeaderRow.Cells[3].Visible = false;
                TxtMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMark");
                TxtMark.Visible = false;
                lbgrade = (Label)GrdVwRecords.Rows[i].FindControl("LblGrade");
                lbgrade.Visible = false;
                ddlgrade = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlGrade");
                ddlgrade.DataSource = DTGrade;
                ddlgrade.DataTextField = "Name";
                ddlgrade.DataValueField = "Id";
                ddlgrade.DataBind();
            }
            

            

        }
       
       

    }
    [WebMethod]
    public static string FnFillGrade(int amount)
    {
        
        string msg = string.Empty;

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        
       

        //SqlCommand cmd = new SqlCommand("Insert into TblFeeAssignTemp(nFeeMasterId, nInstalmentId, nInstituteGrpId, nClassId, nDivisionId, nStudentId, nAmount,nCompanyId, nBranchId, nFaId,nAcId,nAccLedgerId,nOrderIndex) VALUES(" + nFEEId + "," + nINSSTALId + "," + nINSTIId + "," + nCLSId + "," + nDIVId + "," + nSTUDId + "," + nAmount + "," + iCmpId + "," + iBrId + "," + iFaId + "," + iAcId + "," + nAccLedgerId + "," + nOrderIndex + ")", con);
        //con.Open();
        //int i = cmd.ExecuteNonQuery();
        //con.Close();
        //if (i == 1)
        //{
        //    msg = "true";
        //}
        //else
        //{
        //    msg = "false";
        //}
        return msg;
    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsAcademicMarkAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        
        
    }
    public void FnAssignProperty()
    {
        
        base.FnAssignProperty(ObjCls);
        ObjCls.StaffId = 4;
        //ObjCls.StaffId = ObjCls.FnIsNumeric(CtrlGrdStaffName.SelectedValue.ToString());
        
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue.ToString());
        ObjCls.SubjectId = ObjCls.FnIsNumeric(CtrlGrdSubject.SelectedValue.ToString());
        ObjCls.TermId= ObjCls.FnIsNumeric(CtrlGrdSelectTerm.SelectedValue.ToString());
        ObjCls.ExamId= ObjCls.FnIsNumeric(CtrlGrdExam.SelectedValue.ToString());
        ObjCls.ExamSubId= ObjCls.FnIsNumeric(CtrlGrdSubExam.SelectedValue.ToString());
        ObjCls.EntryTypeId= ObjCls.FnIsNumeric(DdlEntryType.SelectedValue.ToString());
        ObjCls.GradeSystemId= ObjCls.FnIsNumeric(DdlGradingSystm.SelectedValue.ToString());
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        CtrlGrdStaffName.SelectedValue = "0";
        CtrlGrdStaffName.SelectedText = "";
        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";
        CtrlGrdDivision.SelectedValue = "0";
        CtrlGrdDivision.SelectedText = "";
        CtrlGrdSubject.SelectedValue = "0";
        CtrlGrdSubject.SelectedText = "";

        CtrlGrdSelectTerm.SelectedValue = "0";
        CtrlGrdSelectTerm.SelectedText = "";
        CtrlGrdExam.SelectedValue = "0";
        CtrlGrdExam.SelectedText = "";
        CtrlGrdSubExam.SelectedValue = "0";
        CtrlGrdSubExam.SelectedText = "";

        DdlEntryType.SelectedValue = "0";
        DdlGradingSystm.SelectedValue = "0";

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        //FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);

        ObjCls.StaffId = 4;
            //ObjCls.FnIsNumeric(CtrlGrdStaffName.SelectedValue.ToString());
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue.ToString());
        ObjCls.SubjectId = ObjCls.FnIsNumeric(CtrlGrdSubject.SelectedValue.ToString());
        ObjCls.TermId = ObjCls.FnIsNumeric(CtrlGrdSelectTerm.SelectedValue.ToString());
        ObjCls.ExamId = ObjCls.FnIsNumeric(CtrlGrdExam.SelectedValue.ToString());
        ObjCls.ExamSubId = ObjCls.FnIsNumeric(CtrlGrdSubExam.SelectedValue.ToString());
        ObjCls.EntryTypeId= ObjCls.FnIsNumeric(DdlEntryType.SelectedValue.ToString());
        ObjCls.GradeSystemId= ObjCls.FnIsNumeric(DdlGradingSystm.SelectedValue.ToString());

        

        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        //FnFindGrid();
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
                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            int iCnt = 0;
                            TextBox TxtRollNo = null;
                            HiddenField HdnStudentId = null, HdnAdId = null;
                           
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnStudentId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnStudentId");
                                HdnAdId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                TxtMark = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtMark");
                                DdlGrde=(DropDownList)GrdVwRecords.Rows[i].FindControl("DdlGrade");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnAdId.Value);
                                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnStudentId.Value);
                                ObjCls.ObtainedMark= ObjCls.FnIsNumeric(TxtMark.Text);
                                ObjCls.ObtainedGradeId= ObjCls.FnIsNumeric(DdlGrde.SelectedValue);
                                _strMsg = ObjCls.UpdateRecord() as string;
                                iCnt = iCnt + 1;
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage("record saved successfully"));
                            }
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "CLEAR":
                    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
                    FnCancel();
                    break;
                case "CLOSE":
                    ObjCls.FnAlertMessage(" You Have No permission To Close Record");
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "FIND":
                    DataTable DT = (ObjCls.FnGetDataSet("select * from TblAcademicMarkAssign") as DataSet).Tables[0];
                    //FnFindGrid();
                    FnFindRecord();
                    //FnAssignProperty();
                    //base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    //FnGridViewBinding("");
                    //System.Threading.Thread.Sleep(1000000);
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
                case "FIRST":
                    //========Code
                    break;
                case "PREVIOUS":
                    //========Code
                    break;
                case "NEXT":
                    //========Code
                    break;
                case "LAST":
                    //========Code
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
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();

            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

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
            GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void FnUpdateMarks()
    {
        LblGrade.Text = "A";
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
                {
                    DropDownList DdlGrade = (DropDownList)e.Row.FindControl("DdlGrade");

                    FnSetDropDownValue(DdlGrade, ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ObtainedGradeId").ToString()).ToString());



                    //TxtMark = (TextBox)e.Row.FindControl("TxtMark");
                    //LblGrade = (Label)e.Row.FindControl("LblGrade");
                    //FnAutocompleteOff(TxtMark);
                    //HdnRwIndex = (HiddenField)e.Row.FindControl("HdnRwIndex");
                    //_strDestControl = GrdVwRecords.ClientID + "," + TxtMark.ClientID;
                    //// TxtMark.Attributes.Add("onkeyup", "return FnUpdateMark('" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "','" + CtrlGrdStaffName.IdControl + "','" + CtrlGrdClass.IdControl + "','" + CtrlGrdDivision.IdControl + "','" + CtrlGrdSubject.IdControl + "','" + CtrlGrdSelectTerm.IdControl + "','" + CtrlGrdExam.IdControl + "','" + CtrlGrdSubExam.IdControl + "','" + TxtMark.ClientID + "','" + HdnRwIndex.ClientID + "', '" + _strDestControl + "');");
                    ////TxtMark.Attributes.Add("onkeyup", "return FnUpdateMark('" + TxtMark.ClientID + "','" + LblGrade + "')");
                    //TxtMark.Attributes.Add("onkeyup", "return FnUpdateMark('" + TxtMark.ClientID + "','" + LblGrade + "')");
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
}