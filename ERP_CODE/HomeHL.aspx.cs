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

public partial class HomeHL : System.Web.UI.Page
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
                ViewState["AID"] = _strLogDetails[6].ToString();

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
        ObjCls.AcId = ObjCls.FnIsNumeric(ViewState["AID"].ToString());
        ObjCls.UserId = ObjCls.FnIsNumeric(ViewState["UID"].ToString());
        ObjCls.UserGroupId = ObjCls.FnIsNumeric(ViewState["GRPID"].ToString());

        ObjCls.FnGetMenuList_Horizontal(ref strScript, ref strMenuList);
        //FnGetMenuHorizontalList(ref strScript, ref strMenuList);
        LblMenu.Text = strMenuList;
        Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        ScriptManager.RegisterClientScriptBlock(objPage, typeof(Page), "Msg", strScript, false);
    }
    //===========================================
    public void FnGetMenuHorizontalList(ref string PrmScript, ref string PrmMenuList)
    {
        string PrmCmpId =ObjCls. EncryptQueryString("1");
        string PrmBrId = ObjCls.EncryptQueryString("2");
        string PrmFaId = ObjCls.EncryptQueryString("4");
        string PrmUsrId = ObjCls.EncryptQueryString("1");
        string PrmUsrGrpId = ObjCls.EncryptQueryString("0");

        string strSql = "SELECT nMenuId,nModuleId,nParentId,cTType,cName,cInterfaceName,cInterfaceTitle,cFileName,nMenuOrder,nIsParent,nIsSubParent,nHeight,nWidth,cTargetField,nResize,nScrolling,cDescription "
                     + " FROM dbo.TblMenu WHERE nActive=1 AND nModuleId>0 "
                     + "ORDER BY nMenuOrder";
        DataSet dsVal = ObjCls.FnGetDataSet(strSql);
        //===========================================================================================

        string strChldActive = "";
        string PrmURL, PrmHeader, strScript = "<script type='text/javascript'>";
        DataView dwMnuPrntLst, dwMnuChldLst;
        string strLink = "", strMenuScript = "<ul class=\"sidebar-menu\">";// <ul class=\"sidebar-menu\"><li class=\"header\">MAIN NAVIGATION</li> "<div id='accordian'>";
        DataTable dtMenuList = dsVal.Tables[0];
        dwMnuPrntLst = new DataView(dtMenuList);
        dwMnuChldLst = new DataView(dtMenuList);
        int iCnt = 0;
        dwMnuPrntLst.RowFilter = "nIsParent=1";
        dwMnuPrntLst.Sort = "nMenuOrder ASC";
        DataTable dtLst = dwMnuPrntLst.ToTable();
        DataTable dtChldLst, dtSubChldLst;
        for (int iRw = 0; iRw <= dtLst.Rows.Count - 1; iRw++)
        {
            if (iRw.Equals(0))
            {
                strMenuScript = strMenuScript + "<li class=\"treeview\"><a href=\"#\"><i class='" + dtLst.Rows[iRw]["cDescription"].ToString().Trim() + "'></i><span>" + dtLst.Rows[iRw]["cName"].ToString().Trim() + "</span><i class=\"fa fa-angle-left pull-right\"></i></a><ul class=\"treeview-menu\">";
            }
            else//<span class='icon-dashboard'></span> 
            {
                if (dtLst.Rows[iRw]["nMenuOrder"].ToString().Equals("500"))
                {
                    strMenuScript = strMenuScript + "<li><a href='" + dtLst.Rows[iRw]["cFileName"].ToString().Trim() + "'><i class='" + dtLst.Rows[iRw]["cDescription"].ToString().Trim() + "' ></i><span>" + dtLst.Rows[iRw]["cName"].ToString().Trim() + "</span></a></li>";
                }
                else
                {
                    strMenuScript = strMenuScript + "<li class=\"treeview\"><a href=\"#\"><i class='" + dtLst.Rows[iRw]["cDescription"].ToString().Trim() + "'></i><span>" + dtLst.Rows[iRw]["cName"].ToString().Trim() + "</span><i class=\"fa fa-angle-left pull-right\"></i></a><ul class=\"treeview-menu\">";
                }
            }
            dwMnuChldLst.RowFilter = "nParentId=" + dtLst.Rows[iRw]["nMenuId"].ToString();
            dwMnuChldLst.Sort = "nMenuOrder ASC";
            dtChldLst = dwMnuChldLst.ToTable();
            for (int jRw = 0; jRw <= dtChldLst.Rows.Count - 1; jRw++)
            {
                strChldActive = "";// (jRw.Equals(0) ? " class=\"active\" " : "");
                iCnt = iCnt + 1;
                if (dtChldLst.Rows[jRw]["nIsSubParent"].ToString().Equals("True"))
                {
                    strMenuScript = strMenuScript + "<li class=\"treeview\"><a href=\"#\"><i class='" + dtChldLst.Rows[jRw]["cDescription"].ToString().Trim() + "'></i><span>" + dtChldLst.Rows[jRw]["cName"].ToString().Trim() + "</span></a><ul style=\"display:none\">";
                }
                else
                {
                    strLink = dtChldLst.Rows[jRw]["cFileName"].ToString().Trim() + "?TITLE=" + dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim() + "&MID=" + ObjCls.EncryptQueryString(dtChldLst.Rows[jRw]["nMenuId"].ToString()) + "&CID=" + PrmCmpId + "&BID=" + PrmBrId + "&FID=" + PrmFaId + "&UID=" + PrmUsrId + "&UGRPID=" + PrmUsrGrpId + "&CNTRID=0&TTYPE=" + dtChldLst.Rows[jRw]["cTType"].ToString() + "&STYLE=1&HEIGHT=" + dtChldLst.Rows[jRw]["nHeight"].ToString() + "&WIDTH=" + dtChldLst.Rows[jRw]["nWidth"].ToString();
                    PrmURL = strLink;
                    PrmHeader = dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim();
                    strScript = strScript + "function FnPopUp" + iCnt.ToString() + "(){var ReportWin" + iCnt.ToString() + "=dhtmlwindow.open('ReportWindow" + iCnt.ToString() + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + dtChldLst.Rows[jRw]["nWidth"].ToString() + "px,height=" + dtChldLst.Rows[jRw]["nHeight"].ToString() + "px,resize=" + dtChldLst.Rows[jRw]["nResize"].ToString() + ",scrolling=" + dtChldLst.Rows[jRw]["nScrolling"].ToString() + ",center=1', 'recal');ReportWin" + iCnt.ToString() + ".onclose=function(){return window.confirm('Do you want to close " + dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim() + " window?')}}";
                    strMenuScript = strMenuScript + "<li><a href=\"#\" OnClick='return FnPopUp" + iCnt.ToString() + "()' ><i class='" + dtChldLst.Rows[jRw]["cDescription"].ToString().Trim() + "' ></i><span>" + dtChldLst.Rows[jRw]["cName"].ToString().Trim() + "</span></a></li><ul style=\"display:none\">";
                }
                dwMnuChldLst.RowFilter = " nParentId=" + dtChldLst.Rows[jRw]["nMenuId"].ToString();
                dwMnuChldLst.Sort = "nMenuOrder ASC";
                dtSubChldLst = dwMnuChldLst.ToTable();
                for (int kRw = 0; kRw <= dtSubChldLst.Rows.Count - 1; kRw++)
                {
                    strChldActive = "";// (kRw.Equals(0) ? " class=\"active\" " : "");
                    iCnt = iCnt + 1;
                    if (dtSubChldLst.Rows[kRw]["nIsSubParent"].ToString().Equals("True"))
                    {
                        strMenuScript = strMenuScript + "<li class=" + strChldActive + "><a href=\"#\"><i class='" + dtSubChldLst.Rows[kRw]["cDescription"].ToString().Trim() + "' ></i>" + dtSubChldLst.Rows[kRw]["cName"].ToString().Trim() + "</a></li>";
                    }
                    else
                    {
                        strLink = dtSubChldLst.Rows[kRw]["cFileName"].ToString() + "?TITLE=" + dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim() + "&MID=" + ObjCls.EncryptQueryString(dtSubChldLst.Rows[kRw]["nMenuId"].ToString()) + "&CID=" + PrmCmpId + "&BID=" + PrmBrId + "&FID=" + PrmFaId + "&UID=" + PrmUsrId + "&UGRPID=" + PrmUsrGrpId + "&CNTRID=0&TTYPE=" + dtSubChldLst.Rows[kRw]["cTType"].ToString().Trim() + "&STYLE=1&HEIGHT=" + dtSubChldLst.Rows[kRw]["nHeight"].ToString() + "&WIDTH=" + dtSubChldLst.Rows[kRw]["nWidth"].ToString();
                        PrmURL = strLink;
                        PrmHeader = dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim();
                        strScript = strScript + "function FnPopUp" + iCnt.ToString() + "(){var ReportWin" + iCnt.ToString() + "=dhtmlwindow.open('ReportWindow" + iCnt.ToString() + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + dtSubChldLst.Rows[kRw]["nWidth"].ToString() + "px,height=" + dtSubChldLst.Rows[kRw]["nHeight"].ToString() + "px,resize=" + dtSubChldLst.Rows[kRw]["nResize"].ToString() + ",scrolling=" + dtSubChldLst.Rows[kRw]["nScrolling"].ToString() + ",center=1', 'recal');ReportWin" + iCnt.ToString() + ".onclose=function(){return window.confirm('Do you want to close " + dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim() + " window?')}}";

                        strMenuScript = strMenuScript + "<li><a href=\"#\" OnClick='return FnPopUp" + iCnt.ToString() + "()' ><i class='" + dtSubChldLst.Rows[kRw]["cDescription"].ToString().Trim() + "' ></i>" + dtSubChldLst.Rows[kRw]["cName"].ToString().Trim() + "</a></li>";
                    }
                }
                strMenuScript = strMenuScript + "</ul>";
            }
            strMenuScript = strMenuScript + "</ul>";
        }
        strMenuScript = strMenuScript + "</ul>";
        PrmScript = strScript + "</script>";
        PrmMenuList = strMenuScript;
    }
}
