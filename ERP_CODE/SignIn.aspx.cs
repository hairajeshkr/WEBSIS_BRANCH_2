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

public partial class SignIn : System.Web.UI.Page
{
    ClsUserLog ObjCls = new ClsUserLog();
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtUserName.Attributes.Add("autocomplete", "off");
        TxtPwd.Attributes.Add("autocomplete", "off");

        if (!IsPostBack)
        {
            try
            {
                FnSetLogOut(Request.QueryString["UID"].ToString(), Request.QueryString["UGRPID"].ToString());
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            TxtUserName.Focus();
        }
    }
    private void FnSetLogOut(string PrmUserId, string PrmUserGrpId)
    {
        ObjCls.ID = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmUserId.Replace(" ", "+")));
        ObjCls.UserId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmUserId.Replace(" ", "+")));
        ObjCls.FromDate = ObjCls.FnDateTime(DateTime.Now.ToString());
        ObjCls.ToDate = ObjCls.FnDateTime(DateTime.Now.ToString());
        ObjCls.UpdateDate = ObjCls.FnDateTime(DateTime.Now.ToString());
        ObjCls.UpdateRecord();
    }
    public void FnPopUpAlert(string PrmMsgString)
    {
        Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        if (objPage != null)
        {
            ScriptManager.RegisterClientScriptBlock(objPage, typeof(ClsPageEvents), "Msg", PrmMsgString, false);
        }
    }
    public void FnFocus(Control PrmCntrl)
    {
        ScriptManager1.SetFocus(PrmCntrl);
    }
    protected void BtnLogIn_Click(object sender, EventArgs e)
    {
        string strAppPage = "";
        int iUId = 0, iGrpId = 0;
        try
        {
            ObjCls.FnLogIn(TxtUserName.Text.Trim(), ObjCls.EncryptQueryString(TxtPwd.Text.Trim()), ref iUId, ref iGrpId, ref strAppPage);
            if (iUId > 0 && iGrpId > 0)
            {
                Session["UNAME"] = TxtUserName.Text.Trim();
                Session["UID"] = iUId.ToString();
                Session["UGRPID"] = iGrpId.ToString();
                Session["APPPATH"] = strAppPage;
                Response.Redirect("Company.aspx");
            }
            else if (iUId < 0 && iGrpId < 0)
            {
                FnPopUpAlert(ObjCls.FnAlertMessage("This User is already logged. Try another user.. Otherwise contact administartor"));
                FnFocus(TxtUserName);
            }
            else
            {
                FnPopUpAlert(ObjCls.FnAlertMessage("Invalid User Name & Password. Try again.."));
                FnFocus(TxtUserName);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
            FnFocus(TxtUserName);
        }
    }
}
