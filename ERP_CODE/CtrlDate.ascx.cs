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

public partial class CtrlDate : System.Web.UI.UserControl
{
    ClsCommonVariables ObjCls = new ClsCommonVariables();
    Boolean bVal = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        CDdlr.Controls.Add(ObjCls.FnShowCalender("TxtDate", "Img1"));
        if (!IsPostBack)
        {
            if (IsVisibleDate == true)
            {
                DateText = DateTime.Now.ToString("dd/MMM/yyyy").Replace("-", "/");//HH:mm:ss
            }
        }
    }
    public void FnNewDate()
    {
        TxtDate.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace("-", "/");
    }
    public Boolean IsVisibleDate
    {
        get
        {
            return bVal;
        }
        set
        {
            bVal = value;
        }
    }
    public Boolean IsReadOnlyDate
    {
        set
        {
            TxtDate.ReadOnly = value;
        }
    }
    public string DateText
    {
        get
        {
            string strDate = TxtDate.Text.Trim();
            return (TxtDate.Text.Trim().Length > 0 ? strDate : "");
        }
        set
        {
            TxtDate.Text = value.ToString();
        }
    }
    public string TextControl
    {
        get
        { return TxtDate.ClientID; }
    }
}
