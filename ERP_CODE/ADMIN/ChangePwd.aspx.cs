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
using System.Text.RegularExpressions;

public partial class ChangePwd : ClsPageEvents, IPageInterFace
{
    ClsUser ObjCls = new ClsUser();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
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
    }

    public override void FnCancel()
    {
        base.FnCancel();

        TxtPwd.Text = "";
        TxtNewPawd.Text = "";
        TxtREType.Text = "";
        CtrlCommand.SaveText = "Save";
        CtrlCommand.SaveCommandArgument = "NEW";
        FnFocus(TxtPwd);
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
        throw new Exception("The method or operation is not implemented.");
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        return 1;
    }

    public void FnGridViewBinding(string PrmFlag)
    {

    }

    public override void FnInitializeForm()
    {
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
                    if (TxtPwd.Text.Trim().Length > 0 && TxtNewPawd.Text.Trim().Length > 0 && TxtREType.Text.Trim().Length > 0)
                    {
                        string strSql = "SELECT COUNT(*) FROM TblUser WHERE cPassword='" + ObjCls.EncryptQueryString(TxtPwd.Text.Trim()) + "' AND nId=" + FnGetRights().USERID;
                        int iCnt = ObjCls.FnIsNumeric(ObjCls.FnExecuteScalar(strSql));
                        if (iCnt > 0)
                        {
                            if (IsValidPassword(TxtREType.Text.Trim()) == false)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage("To check a password between 7 to 15 characters which contain at least one numeric digit ,one upper case ,one Lower case and a special character"));
                                FnFocus(TxtPwd);
                                return;
                            }
                            strSql = "UPDATE dbo.TblUser SET cPassword='" + ObjCls.EncryptQueryString(TxtREType.Text.Trim()) + "' WHERE nId=" + FnGetRights().USERID;
                            ObjCls.FnExecuteNonQuery(strSql);
                            FnPopUpAlert(ObjCls.FnAlertMessage("Password updation successfully completed"));
                        }
                        else
                        {
                            FnPopUpAlert(ObjCls.FnAlertMessage("Invalid current password..try again "));
                        }
                    }
                    else
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Invalid entery..try again "));
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
            ObjCls.FnAlertMessage(ex.Message);
        }
    }
    public static bool IsValidPassword(string plainText)
    {
        Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{7,15}$");
        Match match = regex.Match(plainText);
        return match.Success;
    }
    #endregion
}
