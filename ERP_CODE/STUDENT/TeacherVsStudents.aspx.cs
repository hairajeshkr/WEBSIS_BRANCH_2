using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_TeacherVsStudents : ClsPageEvents, IPageInterFace
{
    ClsTeacherVsStudent ObjCls = new ClsTeacherVsStudent();
    Label LblPaper = null, LblCreditHrs = null;
    HiddenField HdnId = null;
    CheckBox ChkSelect = null;
    int iCnt = 0;
    string PaperId, TeacherId,GroupId;

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            PaperId = Session["param1"] as string;
            TeacherId = Session["param2"] as string;
            GroupId = Session["param3"] as string;
            if (!IsPostBack)
            {
                ObjCls.PFlag = "S1";
                ViewState["SUBJ_ID"] = Request.QueryString["CNTRID"].ToString();
                FnInitializeForm();

            }
            CtrlGrdDivision.ParentControl = CtrlGrdClass.IdControl;
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
        ObjCls = new ClsTeacherVsStudent(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnFindRecord();

    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        
        ObjCls.NEPClassId = ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue);
        ObjCls.NEPDivisionId = ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue);
        ObjCls.NEPPaperId = ObjCls.FnIsNumeric(PaperId);
        ObjCls.GroupNID = ObjCls.FnIsNumeric(GroupId);
        ObjCls.NEPTeacherId= ObjCls.FnIsNumeric(TeacherId);
    }
    public override void FnCancel()
    {
        base.FnCancel();

        CtrlGrdClass.SelectedValue = "0";
        CtrlGrdClass.SelectedText = "";
        CtrlGrdDivision.SelectedValue = "0";
        CtrlGrdDivision.SelectedText = "";

        GrdVwRecords.DataSource = null;
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("S1");
        CtrlCommand1.IsVisibleSave = true;
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
                            ObjCls.PFlag = "S2";

                            FnAssignProperty();
                            for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            {
                                ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                if (ChkSelect.Checked == true)
                                {
                                    Label LblPaper = null;
                                    TextBox TxtCreditHrs = null;
                                    HiddenField HdnId = null;

                                    HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                                    ChkSelect = (CheckBox)GrdVwRecords.Rows[i].FindControl("ChkSelect");
                                    LblPaper = (Label)GrdVwRecords.Rows[i].FindControl("LblPaper");
                                    TxtCreditHrs = (TextBox)GrdVwRecords.Rows[i].FindControl("TxtCreditHrs");

                                    ObjCls.GroupNID = ObjCls.FnIsNumeric(GroupId);
                                    ObjCls.NEPStudentId = ObjCls.FnIsNumeric(HdnId.Value);
                                    _strMsg = ObjCls.SaveRecord() as string;
                                }

                            }
                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + " Records Saved"));
                            }
                            FnCancel();
                            break;
                    }
                    break;
                case "FIND":
                    ObjCls.PFlag = "S2";
                    FnFindRecord();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        ChkSelect = (CheckBox)e.Row.FindControl("ChkSelect");
        {
            
            ObjCls.PFlag = "S2";

        }
    }



}