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

public partial class Company : System.Web.UI.Page
{
    ClsDropdownRecordList ObjCls = new ClsDropdownRecordList();
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ViewState["APPPATH"] = Session["APPPATH"].ToString();
                LblMn.Visible = true;
                RadBtnMenu0.Visible = true;
                string strCmp = "", strBr = "", strFa = "", strUsr = "", strAc = "";
                ObjCls.CompanyId = 1;
                ObjCls.FnGetCompanyDetails(ref strCmp, ref strBr, ref strFa, ref strUsr, ref strAc);
                LblCmp.Text = strCmp.ToString();
                ObjCls.UserId = ObjCls.FnIsNumeric(Session["UID"].ToString());
                ObjCls.FnGetUserBranchList(DdlBranch, "--- BRANCH ---");
                ObjCls.FnGetUserFaYearList(DdlFYear, "--- FINANCIAL YEAR ---");
                ObjCls.FnGetUserAcYearList(DdlAcYear, "--- ACADEMIC YEAR ---");
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
            Response.Redirect("SignIn.aspx");
        }
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
        try
        {
            if (ObjCls.FnIsNumeric(Session["UID"].ToString()) > 0 && ObjCls.FnIsNumeric(Session["UGRPID"].ToString()) > 0)
            {
                string[] _strLogDetails = new string[7];
                _strLogDetails[0] = Session["UNAME"].ToString();
                _strLogDetails[1] = Session["UID"].ToString();
                _strLogDetails[2] = Session["UGRPID"].ToString();
                _strLogDetails[3] = "1";//Company Id
                _strLogDetails[4] = DdlBranch.SelectedValue.ToString();
                _strLogDetails[5] = DdlFYear.SelectedValue.ToString();
                _strLogDetails[6] = DdlAcYear.SelectedValue.ToString();
                Session["LOG"] = _strLogDetails;//Session["MN_TYPE"] 
                if (RadBtnMenu0.SelectedValue.ToString().Equals("HR"))
                {
                    Response.Redirect(ViewState["APPPATH"].ToString() + "?CID=" + ObjCls.EncryptQueryString("1") + "&BID=" + ObjCls.EncryptQueryString(DdlBranch.SelectedValue.ToString()) + "&FID=" + ObjCls.EncryptQueryString(DdlFYear.SelectedValue.ToString()) + "&AID=" + ObjCls.EncryptQueryString("1") + "&UID=" + ObjCls.EncryptQueryString(Session["UID"].ToString()) + "&UNAME=" + Session["UNAME"].ToString());
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                FnPopUpAlert(ObjCls.FnAlertMessage("Invalid User Name & Password. Try again.."));
                FnFocus(DdlBranch);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage("Session Expired . Please Login Again."));
            FnFocus(DdlBranch);
        }
    }
}
