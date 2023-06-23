using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : ClsPageEvents, IPageInterFace
{
    ClsUser ObjCls = new ClsUser();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        /*int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID;
        ObjCls = new clsAccountGroup(ref iCmpId, ref iBrId, ref iFaId);*/
        ViewState["DT"] = FnGetGeneralTable(ObjCls);// ObjCls.FnConvertStringToDataTable(ObjCls.FnReadXmlFile(Server.MapPath("XML_NULL//GENERAL.xml"))) as DataTable;
        FnGridViewBinding("");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName.Text.Trim();
        ObjCls.Code = TxtCode.Text.Trim();
        ObjCls.Password = ObjCls.EncryptQueryString(TxtPwd.Text.Trim());
        ObjCls.Remarks = TxtRemarks.Text.Trim();
        ObjCls.IsApprove = (ChkApprove.Checked == true ? 1 : 0);
        ObjCls.Active = (ChkActive.Checked == true ? true : false);
        ObjCls.StaffId = ObjCls.FnIsNumeric(CtrlGrdStaff.SelectedValue.ToString());
        ObjCls.GroupId = ObjCls.FnIsNumeric(CtrlGrdGrp.SelectedValue.ToString());
        ObjCls.Email = TxtEmail.Text.Trim();
        ObjCls.MobNo = TxtMobNo.Text.Trim();
        ObjCls.DepartmentId = "";
        ObjCls.DesignationId = 0;
        ObjCls.ActiveDate = DateTime.Now;
        ObjCls.InactiveDate = DateTime.Now;
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();

        TxtName.Text = "";
        TxtName_Srch.Text = "";
        TxtCode_Srch.Text = "";
        CtrlGrdGrp.SelectedText = "";
        CtrlGrdGrp.SelectedValue = "0";
        CtrlGrdStaff.SelectedText = "";
        CtrlGrdStaff.SelectedValue = "0";
        TxtEmail.Text = "";
        TxtMobNo.Text = "";
        TxtPwd.Text = "";
        TxtRemarks.Text = "";
        ChkActive.Checked = true;
        ChkApprove.Checked = false;
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        FnFocus(TxtName);
    }
    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName_Srch.Text.Trim();
        ObjCls.Code = TxtCode_Srch.Text.Trim();
        ObjCls.ActiveDate = DateTime.Now;
        ObjCls.InactiveDate = DateTime.Now;
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
                    if (TxtName.Text.Trim().Length <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                        FnFocus(TxtName);
                        return;
                    }
                    if (IsValidPassword(TxtPwd.Text.Trim()) == false)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("To check a password between 7 to 15 characters which contain at least one numeric digit ,one upper case ,one Lower case and a special character"));
                        FnFocus(TxtPwd);
                        return;
                    }
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
            TxtName.Text = ObjCls.Name.ToString();
            TxtCode.Text = ObjCls.Code.ToString();
            TxtMobNo.Text = ObjCls.MobNo.ToString();

            CtrlGrdGrp.SelectedText = ObjCls.GroupName;
            CtrlGrdGrp.SelectedValue = ObjCls.GroupId.ToString();

            CtrlGrdStaff.SelectedText = ObjCls.StaffName.ToString();
            CtrlGrdStaff.SelectedValue = ObjCls.StaffId.ToString();

            TxtPwd.Text = ObjCls.DecryptQueryString(ObjCls.Password.ToString().Replace(" ", "+"));
            TxtEmail.Text = ObjCls.Email.ToString();

            TxtRemarks.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            ChkApprove.Checked = (ObjCls.IsApprove == 1 ? true : false);
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
    public static bool IsValidPassword(string plainText)
    {
        Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,15}$");
        Match match = regex.Match(plainText);
        return match.Success;
    }
}