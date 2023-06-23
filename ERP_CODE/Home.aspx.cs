using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    ClsMenu ObjCls = new ClsMenu();
    ClsReportGeneral ObjRpt = new ClsReportGeneral();
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
                FnTestMenu();

                string[] _strLogDetails = (string[])((Session["LOG"]));

                ViewState["UNAME"] = _strLogDetails[0].ToString();
                ViewState["UID"] = _strLogDetails[1].ToString();
                ViewState["GRPID"] = _strLogDetails[2].ToString();

                ViewState["CID"] = _strLogDetails[3].ToString();
                ViewState["BID"] = _strLogDetails[4].ToString();
                ViewState["FID"] = _strLogDetails[5].ToString();
                ViewState["AID"] = _strLogDetails[6].ToString();

                ViewState["MID"] = ObjCls.EncryptQueryString("0");
                HyLnkLogOut.NavigateUrl = "SignIn.aspx?UID=" + ObjCls.EncryptQueryString(ViewState["UID"].ToString()) + "&UGRPID=" + ObjCls.EncryptQueryString(ViewState["GRPID"].ToString());
                FrmContent.Attributes.Add("src", FnGetDashBoardUrl());

                string _strCompanyName = "", _strBranchName = "", _strFaYear = "", _strUserName = "", _strAcName = "";
                ObjRpt.CompanyId = ObjRpt.FnIsNumeric(ViewState["CID"].ToString());
                ObjRpt.BranchId = ObjRpt.FnIsNumeric(ViewState["BID"].ToString());
                ObjRpt.FaId = ObjRpt.FnIsNumeric(ViewState["FID"].ToString());
                ObjRpt.UserId = ObjRpt.FnIsNumeric(ViewState["UID"].ToString());
                ObjRpt.FnGetCompanyDetails(ref _strCompanyName, ref _strBranchName, ref _strFaYear, ref _strUserName,ref _strAcName);
                LblTitle.Text =  _strBranchName + " - " + _strFaYear;
                HdrUserLeft.InnerText = _strUserName;
                SpnUserRight.InnerText = _strUserName;
            }
            FrmContent.Style.Add("height", "100vh");
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

        FnGetMenuVerticalList(ObjCls.FnGetUserGroupWiseMenuList() as DataSet, ref strScript, ref strMenuList);
         //FnTestMenu();
       LblMenu.Text = strMenuList;
        Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        ScriptManager.RegisterClientScriptBlock(objPage, typeof(Page), "Msg", strScript, false);
    }
    private string FnGetDashBoardUrl()
    {
        string strUrl = "~/DASHBOARD/DashboardInventory.aspx";//DashboardVehicle.aspx
        return strUrl + "?HDR=Dashboard&TTYPE=DASH&TITLE=Dashboard Details&CNTRID=0&UID=" + ObjCls.EncryptQueryString(ViewState["UID"].ToString()) + "&UGRPID=" + ObjCls.EncryptQueryString(ViewState["GRPID"].ToString()) + "&CID=" + ObjCls.EncryptQueryString(ViewState["CID"].ToString()) + "&BID=" + ObjCls.EncryptQueryString(ViewState["BID"].ToString()) + "&FID=" + ObjCls.EncryptQueryString(ViewState["FID"].ToString()) + "&WIDTH=1000&HEIGHT=1000";
    }
    private void FnTestMenu1()
    {
        string strMenu = "<div id='sidebar-menu' class='main_menu_side hidden-print main_menu'>" +
            "<div class='menu_section'>" + "<h3>Menu List</h3>" + "<ul class='nav side-menu'>"
            + "<li><a><i class='fa fa-home'></i>Vehicle Master<span class='fa fa-chevron-down'></span></a>" +
                                        "<ul class='nav child_menu'>" +
                                            "<li><a href = '#' > Vehicle Registartion</a></li>" +
                                                "<li><a>Mul Level<span class='fa fa-chevron-down'></span></a>" +
                                                    "<ul class='nav child_menu'>" +
                                                        "<li class='sub_menu'><a href = 'level2.html' > Mul 1</a></li>" +
                                                        "<li><a href = '#level2_1' > Mul 2</a>" +
                                                             "<li><a>Mul Level<span class='fa fa-chevron-down'></span></a>" +
                                                    "<ul class='nav child_menu'>" +
                                                        "<li class='sub_menu'><a href = 'level2.html' > Mul 1</a></li>" +
                                                        "<li><a href = '#level2_1' > Mul 2dfgfddddddddddddddddddddg</a></li>" +
                                                        "<li><a href = '#level2_2' > Mul 3</a></li>" +
                                                    "</ul>" +
                                                "</li>" +
                                                        "</li>" +
                                                        "<li><a href = '#level2_2' > Mul 3</a></li>" +
                                                    "</ul>" +
                                                "</li>" +
                                        "</ul>" +
                                    "</li>" +
                                "</ul>" +
                            "</div>" +
                        "</div>";
        LblMenu.Text = strMenu;
    }
    private void FnTestMenu()
    {
        string strMenu = "  <div id='sidebar-menu' class='main_menu_side hidden-print main_menu'>"
                            +"<div class='menu_section'><h3>Menu List</h3>"
                            + "<ul class='nav side-menu'>"
                            + "<li><a><i class='fa fa-home'></i>Vehicle Master<span class='fa fa-chevron-down'></span></a>"
                            + "<ul class='nav child_menu'>"
                            + "<li><a href = '#' > Vehicle Registartion</a></li>"
                            + "<li><a>Mul Level<span class='fa fa-chevron-down'></span></a>"
                                + "<ul class='nav child_menu'>"
                                    + "<li class='sub_menu'><a href = 'level2.html' > Sub Chld 1</a></li>"
                                    + "<li class='sub_menu'><a href = '#level2_1' > Sub Chld 2</a></li>"
                                + "</ul>"
                            + "</li>"
                             + "<li><a href = '#' > Vehicle </a></li>"
                            + "</ul>"
                            + "</li>"
                            + "<li><a><i class='fa fa-home'></i>Item Master<span class='fa fa-chevron-down'></span></a>"
                             + "<ul class='nav child_menu'>"
                                    + "<li class='sub_menu'><a href = 'level2.html' > Sub Chld 1</a></li>"
                                    + "<li class='sub_menu'><a href = '#level2_1' > Sub Chld 2</a></li>"
                                + "</ul></li>"
                            + "</ul>"
                            + "</div></div>";
        LblMenu.Text = strMenu;
    }
   
    public void FnGetMenuVerticalList(DataSet PrmMenuRecords, ref string PrmScript, ref string PrmMenuList)
    {
        string PrmCmpId = ObjCls.EncryptQueryString(ViewState["CID"].ToString());
        string PrmBrId = ObjCls.EncryptQueryString(ViewState["BID"].ToString());
        string PrmFaId = ObjCls.EncryptQueryString(ViewState["FID"].ToString());
        string PrmAcId = ObjCls.EncryptQueryString(ViewState["AID"].ToString());
        string PrmUsrId = ObjCls.EncryptQueryString(ViewState["UID"].ToString());
        string PrmUsrGrpId = ObjCls.EncryptQueryString(ViewState["GRPID"].ToString());
     
        string PrmURL, PrmHeader, strScript = "<script type='text/javascript'>";
        DataView dwMnuPrntLst, dwMnuChldLst;
        string strLink = "", strMenuScript = "<div id='sidebar-menu' class='main_menu_side hidden-print main_menu'><div class='menu_section'><h3>Menu List</h3><ul class='nav side-menu'>";
        DataTable dtMenuList = PrmMenuRecords.Tables[0];
        dwMnuPrntLst = new DataView(dtMenuList);
        dwMnuChldLst = new DataView(dtMenuList);
        int iCnt = 0;
        dwMnuPrntLst.RowFilter = "nIsParent=1";
        dwMnuPrntLst.Sort = "nMenuOrder ASC";
        DataTable dtLst = dwMnuPrntLst.ToTable();
        DataTable dtChldLst, dtSubChldLst;
        for (int iRw = 0; iRw <= dtLst.Rows.Count - 1; iRw++)
        {
            if (dtLst.Rows[iRw]["nMenuOrder"].ToString().Equals("500"))
            {
                strMenuScript = strMenuScript + "<li><a href='" + dtLst.Rows[iRw]["cFileName"].ToString().Trim() + "?UID=" + PrmUsrId + "&UGRPID=" + PrmUsrGrpId + "'><i class='" + dtLst.Rows[iRw]["cDescription"].ToString().Trim() + "' ></i><span>" + dtLst.Rows[iRw]["cName"].ToString().Trim() + "</span></a></li>";
            }
            else
            {
                strMenuScript = strMenuScript + "<li><a><i class='" + dtLst.Rows[iRw]["cDescription"].ToString().Trim() + "'></i>" + dtLst.Rows[iRw]["cName"].ToString().Trim() + "<span class='fa fa-chevron-down'></span></a><ul class='nav child_menu'>";// Parent Start
                dwMnuChldLst.RowFilter = "nParentId=" + dtLst.Rows[iRw]["nMenuId"].ToString();
                dwMnuChldLst.Sort = "nMenuOrder ASC";
                dtChldLst = dwMnuChldLst.ToTable();

                for (int jRw = 0; jRw <= dtChldLst.Rows.Count - 1; jRw++)
                {
                    if (dtChldLst.Rows[jRw]["nIsSubParent"].ToString().Equals("True") || dtChldLst.Rows[jRw]["nIsSubParent"].ToString().Equals("1"))
                    {
                        strMenuScript = strMenuScript + "<li><a>" + dtChldLst.Rows[jRw]["cName"].ToString().Trim() + "<span class='fa fa-chevron-down'></span></a><ul class='nav child_menu'>";// Sub Parent Start

                        dwMnuChldLst.RowFilter = " nParentId=" + dtChldLst.Rows[jRw]["nMenuId"].ToString();
                        dwMnuChldLst.Sort = "nMenuOrder ASC";
                        dtSubChldLst = dwMnuChldLst.ToTable();

                        for (int kRw = 0; kRw <= dtSubChldLst.Rows.Count - 1; kRw++)
                        {
                            iCnt = ObjCls.FnIsNumeric(dtSubChldLst.Rows[kRw]["nMenuId"].ToString().Trim());
                            strLink = dtSubChldLst.Rows[kRw]["cFileName"].ToString().Trim() + "?TITLE=" + dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim() + "&MID=" + ObjCls.EncryptQueryString(dtSubChldLst.Rows[kRw]["nMenuId"].ToString()) + "&CID=" + PrmCmpId + "&BID=" + PrmBrId + "&FID=" + PrmFaId + "&AID=" + PrmAcId + "&UID=" + PrmUsrId + "&UGRPID=" + PrmUsrGrpId + "&CNTRID=0&TTYPE=" + dtSubChldLst.Rows[kRw]["cTType"].ToString() + "&STYLE=1&HEIGHT=" + dtSubChldLst.Rows[kRw]["nHeight"].ToString() + "&WIDTH=" + dtSubChldLst.Rows[kRw]["nWidth"].ToString();
                            PrmURL = strLink;
                            PrmHeader = dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim();
                            strScript = strScript + "function FnPopUp" + iCnt.ToString() + "(){var ReportWin" + iCnt.ToString() + "=dhtmlwindow.open('ReportWindow" + iCnt.ToString() + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + dtSubChldLst.Rows[kRw]["nWidth"].ToString() + "px,height=" + dtSubChldLst.Rows[kRw]["nHeight"].ToString() + "px,resize=" + dtSubChldLst.Rows[kRw]["nResize"].ToString() + ",scrolling=" + dtSubChldLst.Rows[kRw]["nScrolling"].ToString() + ",center=1', 'recal');ReportWin" + iCnt.ToString() + ".onclose=function(){return window.confirm('Do you want to close " + dtSubChldLst.Rows[kRw]["cInterfaceTitle"].ToString().Trim() + " window?')}}";

                            strMenuScript = strMenuScript + "<li><a href='#' OnClick='return FnPopUp" + iCnt.ToString() + "()' >" + dtSubChldLst.Rows[kRw]["cName"].ToString().Trim() + "</a></li>";

                        }
                       //strMenuScript = strMenuScript + "</ul></li>";
                    }
                    else
                    {
                        iCnt = ObjCls.FnIsNumeric(dtChldLst.Rows[jRw]["nMenuId"].ToString().Trim());
                        strLink = dtChldLst.Rows[jRw]["cFileName"].ToString().Trim() + "?TITLE=" + dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim() + "&MID=" + ObjCls.EncryptQueryString(dtChldLst.Rows[jRw]["nMenuId"].ToString()) + "&CID=" + PrmCmpId + "&BID=" + PrmBrId + "&FID=" + PrmFaId + "&AID=" + PrmAcId + "&UID=" + PrmUsrId + "&UGRPID=" + PrmUsrGrpId + "&CNTRID=0&TTYPE=" + dtChldLst.Rows[jRw]["cTType"].ToString() + "&STYLE=1&HEIGHT=" + dtChldLst.Rows[jRw]["nHeight"].ToString() + "&WIDTH=" + dtChldLst.Rows[jRw]["nWidth"].ToString();
                        PrmURL = strLink;
                        PrmHeader = dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim();
                        strScript = strScript + "function FnPopUp" + iCnt.ToString() + "(){var ReportWin" + iCnt.ToString() + "=dhtmlwindow.open('ReportWindow" + iCnt.ToString() + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + dtChldLst.Rows[jRw]["nWidth"].ToString() + "px,height=" + dtChldLst.Rows[jRw]["nHeight"].ToString() + "px,resize=" + dtChldLst.Rows[jRw]["nResize"].ToString() + ",scrolling=" + dtChldLst.Rows[jRw]["nScrolling"].ToString() + ",center=1', 'recal');ReportWin" + iCnt.ToString() + ".onclose=function(){return window.confirm('Do you want to close " + dtChldLst.Rows[jRw]["cInterfaceTitle"].ToString().Trim() + " window?')}}";

                        strMenuScript = strMenuScript + "<li><a href='#' OnClick='return FnPopUp" + iCnt.ToString() + "()' >" + dtChldLst.Rows[jRw]["cName"].ToString().Trim() + "</a><ul class='nav child_menu'>";
                    }
                    strMenuScript = strMenuScript + "</ul></li>";
                }
            }
            strMenuScript = strMenuScript + "</ul></li>";// Parent End
        }
        strMenuScript = strMenuScript + "</ul></div></div>";
        PrmScript = strScript + "</script>";
        PrmMenuList = strMenuScript;
    }
}