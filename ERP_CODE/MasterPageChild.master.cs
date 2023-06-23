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
using System.Drawing;
public partial class MasterPageChild : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        /*Literal link = new Literal();
        if (Request.QueryString["STYLE"].ToString().Equals("1"))
        {
            link.Text = "<link href=\"../StyleSheet/StyleControlsNew.css\" rel=\"stylesheet\" type=\"text/css\" />";
            link.Text = link.Text + "<link href=\"../StyleSheet/StyleSheetContentNew.css\" rel=\"stylesheet\" type=\"text/css\" />";
        }
        else
        {
            link.Text = "<link href=\"../StyleSheet/StyleControls.css\" rel=\"stylesheet\" type=\"text/css\" />";
            link.Text = link.Text + "<link href=\"../StyleSheet/StyleSheetContent.css\" rel=\"stylesheet\" type=\"text/css\" />";
        }
        base.Page.Header.Controls.Add(link);
        base.OnInit(e);*/
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        FnStartProgressBar();

        ServiceReference Scr = new ServiceReference();
        Scr.Path = "Web_GridSelection.asmx";
        ScriptManager1.Services.Add(Scr);

        ServiceReference ScrFetch = new ServiceReference();
        ScrFetch.Path = "Web_GridFetchSelection.asmx";
        ScriptManager1.Services.Add(ScrFetch);

        ServiceReference ScrAjax = new ServiceReference();
        ScrAjax.Path = "Web_GetResultService.asmx";
        ScriptManager1.Services.Add(ScrAjax);
        try
        {
            if (!IsPostBack)
            {
                string _strFrmDate = "", _strToDate = "";
                ClsFaYear ObjCls = new ClsFaYear();
                ObjCls.FaId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(Request.QueryString["FID"].ToString()));
                ObjCls.FnGetFaYearDate(ref _strFrmDate, ref _strToDate);
                HdnFrmDate.Value = _strFrmDate.Replace("-", "/");
                HdnToDate.Value = _strToDate.Replace("-", "/");

                ObjCls.FaId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(Request.QueryString["AID"].ToString()));
                ObjCls.FnGetFaYearDate(ref _strFrmDate, ref _strToDate);
                HdnAcFrmDate.Value = _strFrmDate.Replace("-", "/");
                HdnAcToDate.Value = _strToDate.Replace("-", "/");

                HdnDate.Value = DateTime.Now.ToString("yyyy/MM/dd").Replace("-", "/");
            }
        }
        catch (Exception ex)
        {
            LblWindowTitle.ForeColor = Color.Red;
            LblWindowTitle.Text = ex.Message;
        }
    }
    public void FnStartProgressBar()
    {
        int iWidth = (FnIsNumeric(Request.QueryString["WIDTH"].ToString()) / 2) - 50;
        int iHeight = (FnIsNumeric(Request.QueryString["HEIGHT"].ToString()) / 2) - 50;
        Label LblPrgBar = (Label)UpdateProgress1.FindControl("LblPrgBar");
        string strPrgBar = "<div id='IMGDIV' class='report-popup-box' runat='server' align='center' valign='middle'>"
                 + "</div><div class='load-process-wrapper'><div class='load-process-container'><img id='IMG1' src='../images/one.png' style='width: 21px; height: 43px' runat= server /><div class='load-process'></div></div></div>";
        LblPrgBar.Text = strPrgBar;
    }
    public int FnIsNumeric(object PrmVal)
    {
        int _iVal = 0;
        try
        {
            _iVal = Convert.ToInt32(PrmVal);
        }
        catch (Exception)
        {
            _iVal = 0;
        }
        return _iVal;
    }
}
/*
int iWidth = (FnIsNumeric(Request.QueryString["WIDTH"].ToString()) / 2) - 50;
        int iHeight = (FnIsNumeric(Request.QueryString["HEIGHT"].ToString()) / 2) - 50;
        Label LblPrgBar = (Label)UpdateProgress1.FindControl("LblPrgBar");
        string strPrgBar = "<div id='IMGDIV' runat='server' align='center' style='visibility: visible; vertical-align: middle;"
                 + "position:absolute; top: " + iHeight + "px;left: " + iWidth + "px; text-align:center; background-color: white;"
                 + "border-right: black 0px solid; border-top: black 0px solid; border-left: black 0px solid;"
                 + " border-bottom: black 0px solid;' valign='middle'>"
                 + "<img id='IMG1' src='../images/PleaseWait.gif' style='width: 144px; height: 125px' runat= server /><br/></div>";
        LblPrgBar.Text = strPrgBar;
*/
//<input onclick='CancelPostBack()' type='button' value='c' id='Button1' runat='server' visible='false' />  150px;left: 400px