using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class STUDENT_StudentCommunication : ClsPageEvents, IPageInterFace
{
    ClsStudentCommunication ObjCls = new ClsStudentCommunication();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ViewState["STU_ID"] = Request.QueryString["CNTRID"].ToString();
               
                FnInitializeForm();
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public override void FnInitializeForm()
    {
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls = new ClsStudentCommunication(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.StudentId = ObjCls.FnIsNumeric(ViewState["STU_ID"].ToString());
        ObjCls.PrimaryContact = ObjCls.FnIsNumeric(DdlPrimaryContact.SelectedValue.ToString());
        ObjCls.PhoneNo = TxtphoneNo.Text.Trim();
        ObjCls.MessagingNo = TxtMessageNo.Text.Trim();
        ObjCls.Email = TxtCommunicationEmail.Text.Trim();
        ObjCls.Remarks = TxtRemarks.Text.Trim();
    }

    public override void FnCancel()
    {
        //base.FnCancel();
        DdlPrimaryContact.SelectedValue = "";
        TxtphoneNo.Text = "";
        TxtMessageNo.Text = "";
        TxtCommunicationEmail.Text = "";
        TxtRemarks.Text = "";

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 1;
        
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        DT_RECORD = ViewState["DT"] as DataTable;
        if (DT_RECORD.Rows.Count > 0)
        {
            ObjCls.GetDataRow(DT_RECORD.Rows[0]["ID"].ToString(), DT_RECORD);
            ViewState["ID"] = ObjCls.ID.ToString();

            DdlPrimaryContact.Text = ObjCls.PrimaryContact.ToString();
           
            TxtphoneNo.Text = ObjCls.PhoneNo.ToString();
            TxtMessageNo.Text = ObjCls.MessagingNo.ToString();
            TxtCommunicationEmail.Text = ObjCls.Email.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();

            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;
        }
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        throw new NotImplementedException();
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
                            _strMsg = ObjCls.SaveRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                        case "UPDATE":
                            _strMsg = ObjCls.UpdateRecord() as string;
                            FnUnClearOutPut(_strMsg, ObjCls, false);
                            break;
                    }
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    
}