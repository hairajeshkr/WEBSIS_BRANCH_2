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

public partial class Home1 : System.Web.UI.Page
{
    ClsMenu ObjCls = new ClsMenu();
    ClsReportGeneral ObjRpt = new ClsReportGeneral();
    protected override void OnInit(EventArgs e)
    {
        try
        {
            /*Literal link = new Literal();
            if (Session["MN_TYPE"].ToString().Equals("HR"))
            {
                link.Text = "<link href=\"../StyleSheet/StyleMenuHorizontal.css\" rel=\"stylesheet\" type=\"text/css\" />";
            }
            base.Page.Header.Controls.Add(link);
            base.OnInit(e);*/
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
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
                string[] _strLogDetails = (string[])((Session["LOG"]));

                ViewState["UNAME"] = _strLogDetails[0].ToString();
                ViewState["UID"] = _strLogDetails[1].ToString();
                ViewState["GRPID"] = _strLogDetails[2].ToString();

                ViewState["CID"] = _strLogDetails[3].ToString();
                ViewState["BID"] = _strLogDetails[4].ToString();
                ViewState["FID"] = _strLogDetails[5].ToString();

                ViewState["MID"] = ObjCls.EncryptQueryString("0");

                string _strCompanyName = "", _strBranchName = "", _strFaYear = "", _strUserName = "", _strAcName = "";
                ObjRpt.CompanyId = ObjRpt.FnIsNumeric(ViewState["CID"].ToString());
                ObjRpt.BranchId = ObjRpt.FnIsNumeric(ViewState["BID"].ToString());
                ObjRpt.FaId = ObjRpt.FnIsNumeric(ViewState["FID"].ToString());
                ObjRpt.UserId = ObjRpt.FnIsNumeric(ViewState["UID"].ToString());
                ObjRpt.FnGetCompanyDetails(ref _strCompanyName, ref _strBranchName, ref _strFaYear, ref _strUserName,ref _strAcName);
                LblTitle.Text = _strCompanyName;
                LblLoc.Text = _strBranchName;
                LblFaYear.Text = _strFaYear;
                LblFaYear.Visible = false;
                LblUsr.Text = _strUserName + "   ";
            }
            FnApplicationWindow();
        }
        catch (Exception ex)
        {
            Response.Redirect("SignIn.aspx");
            Response.Write(ex.Message);
        }
    }
    private void FnApplicationWindow()
    {
        string strScript = "", strMenuList = "";
        ObjCls.CompanyId = ObjCls.FnIsNumeric(ViewState["CID"].ToString());
        ObjCls.BranchId = ObjCls.FnIsNumeric(ViewState["BID"].ToString());
        ObjCls.FaId = ObjCls.FnIsNumeric(ViewState["FID"].ToString());
        ObjCls.UserId = ObjCls.FnIsNumeric(ViewState["UID"].ToString());
        ObjCls.UserGroupId = ObjCls.FnIsNumeric(ViewState["GRPID"].ToString());

        ObjCls.FnGetMenuListNew(ref strScript, ref strMenuList);
        LblMenu.Text = strMenuList;
        Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        ScriptManager.RegisterClientScriptBlock(objPage, typeof(Page), "Msg", strScript, false);
    }
}
