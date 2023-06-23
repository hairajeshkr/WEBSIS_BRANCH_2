using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserLogList : ClsPageEvents, IPageInterFace
{
    ClsUserLog ObjCls = new ClsUserLog();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            //CtrlCommand.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
                FnInitializeForm();
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    #region IPageInterFace Members
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.FromDate = ObjCls.FnDateTime(DateTime.Now.ToString("dd/mmm/yyy"));
        ObjCls.ToDate = ObjCls.FnDateTime(DateTime.Now.ToString("dd/mmm/yyy"));
        ObjCls.UserGrpId = ObjCls.FnIsNumeric(CtrlGrdUserGroup.SelectedValue.ToString());
        ObjCls.Name = TxtUserName.Text.Trim();
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }
    public override void FnCancel()
    {
        TxtUserName.Text = "";
        CtrlGrdUserGroup.SelectedText = "";
        CtrlGrdUserGroup.SelectedValue = "0";
        ChkActive.Checked = true;
        base.FnCancel();
    }
    public void FnClose()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void FnClearItems(string PrmFlag)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        return 1;
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;
        lblMsg.Visible = (GrdVwRecords.Rows.Count > 0 ? false  : true );
    }
    public override void FnInitializeForm()
    {
        FnFindRecord();
    }
    public void FnPrintRecord()
    {
        throw new Exception("The method or operation is not implemented.");
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
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    FnCancel();
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnCancel();
                    break;
                case "CLEAR":
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
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnGridViewBinding("");
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
            }
        }
        catch (Exception ex)
        {
            ObjCls.FnAlertMessage(ex.Message);
        }
    }
    #endregion
    protected void GrdVwRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            ObjCls.FnAlertMessage(ex.Message);
        }
    }
    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
    }
    protected void GrdVwRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            HiddenField HdnUserId = (HiddenField)GrdVwRecords.Rows[e.RowIndex].FindControl("HdnUserId");
            FnAssignProperty();
            ObjCls.ID = ObjCls.FnIsNumeric(HdnUserId.Value);
            base.ManiPulateDataEvent_Clicked("UPDATE", ObjCls, false);
            FnFindRecord();
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LnkLogOut = (LinkButton)e.Row.FindControl("LnkLogOut");
                LnkLogOut.Enabled = (DataBinder.Eval(e.Row.DataItem, "Active").ToString().Equals("True") ? true : false);
                LnkLogOut.Text = (DataBinder.Eval(e.Row.DataItem, "Active").ToString().Equals("True") ? "LOG OUT" : "");
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
}
