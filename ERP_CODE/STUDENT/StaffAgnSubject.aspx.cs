using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class STUDENT_StaffAgnSubject : ClsPageEvents, IPageInterFace
{
    ClsAcademicStaffStudent ObjCls = new ClsAcademicStaffStudent();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //TxtPriority.Attributes.Add("onkeydown", "return NumbersOnly(event);");
                FnInitializeForm();

            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
        CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
    }

    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsAcademicStaffStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StaffId = 4;
        //ObjCls.FnIsNumeric(CtrlGrdStaffName.SelectedValue.ToString());
        ObjCls.ClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue.ToString());
        ObjCls.DivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue.ToString());
        ObjCls.SubjectId = ObjCls.FnIsNumeric(CtrlGrdSubject.SelectedValue.ToString());



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

        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        //TabContainer1.ActiveTabIndex = 1;
    }
    protected void FnFindGrid()
    {
        string connString = "Data Source=LAPTOP-7QR5CKRO\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True";
        string query = "select TRS.nId ID,TRS.cName Name,TRS.cAdmissionNo AdmissionNo,TCD.cName ClassName,TCDD.cName DivisionName,TAS.cName SubjectName from tblregistrationstudent TRS inner join TblStudentAdmissionDetails TSAD on TSAD.nStudentId = TRS.nId inner join TblClassDetails TCD on TCD.nId = TRS.nClassId and TCD.cTType = 'CLS' inner join TblClassDetails TCDD on TCDD.nId = TRS.nDivisionId and TCDD.cTType = 'DIVN' left join TblAcademicStaffStudent TASS on TASS.nStudentId = TSAD.nStudentId left join TblAcademicSubject TAS on TAS.nId = TASS.nSubjectId where TCD.nId = 10039 and TCDD.nId = 10048 and TAS.nId = 1 and TASS.nStaffId = 4 ";

        DataTable DT = new DataTable();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(DT);
        conn.Close();
        da.Dispose();


        //DataTable DT = (ObjCls.FnGetDataSet("select TRS.cName Name,TCD.cName ClassName,TCDD.cName DivisionName from tblregistrationstudent TRS inner join TblAcademicStaffAssign TASA on TRS.nClassId = TASA.nClassId and TRS.nDivisionId = TASA.nDivisionId inner join TblClassDetails TCD on TCD.nId = TASA.nClassId inner join TblClassDetails TCDD on TCDD.nId = TASA.nDivisionId where TASA.nClassId = 10039 and TASA.nDivisionId = 10046") as DataSet).Tables[0];
        GrdVwRecords.DataSource = DT;
        GrdVwRecords.DataBind();

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

                            HiddenField HdnStudentId = null, HdnAdId = null, HdnClassId = null, HdnDivisionId = null;

                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                HdnStudentId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnStudentId");
                                HdnAdId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                HdnClassId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnClassId");
                                HdnDivisionId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnDivisionId");

                                ObjCls.ID = ObjCls.FnIsNumeric(HdnAdId.Value);
                                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnStudentId.Value);
                                ObjCls.ClassId = ObjCls.FnIsNumeric(HdnClassId.Value);
                                ObjCls.DivisionId = ObjCls.FnIsNumeric(HdnDivisionId.Value);

                                ObjCls.SubjectId = ObjCls.FnIsNumeric(CtrlGrdSubject.SelectedValue);
                                ObjCls.StaffId = 4;      // ObjCls.FnIsNumeric(CtrlGrdStaffName.SelectedValue);
                               _strMsg = ObjCls.UpdateRecord() as string;
                                iCnt = iCnt + 1;
                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(" saved successfully"));
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
                    DataTable dtt= (ObjCls.FnGetDataSet("select * from TblClassDetails") as DataSet).Tables[0];
                    DataTable DT = (ObjCls.FnGetDataSet("select * from TblAcademicStaffStudent") as DataSet).Tables[0];
                    //DataTable DTS = (ObjCls.FnGetDataSet(" .nSubjectId WHERE TSAD.nIsDelete=0 AND TSAD.nClassId=2 AND TSAD.nDivisionId=10007 AND TRSS.nId NOT IN (Select TBASS.nStudentId from TblAcademicStaffStudent TBASS) ") as DataSet).Tables[0];
                    DataTable dtpro= (ObjCls.FnGetDataSet("EXEC	[dbo].[ProAcademicStaffStudent] @Prm_nStaffId = 4, @Prm_nInstGrpId = NULL,@Prm_nClassId = 2,@Prm_nDivisionId = 10007,@Prm_nSubjectId = 1,@Prm_nStudentId = NULL,@Prm_nId = NULL,@Prm_cRemarks = NULL,@Prm_cTType = NULL,@Prm_nActive = NULL,@Prm_nCompanyId = NULL,@Prm_nBranchId = NULL,@Prm_nFaId = NULL,@Prm_nAcId = NULL,@Prm_nUserId = NULL,@Prm_dDate = NULL,@Prm_cFlag = N'S'") as DataSet).Tables[0];
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
}