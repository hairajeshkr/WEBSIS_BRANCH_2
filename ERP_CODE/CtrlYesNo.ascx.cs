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

public partial class CtrlYesNo : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler SymbolAddCommands;
    protected void Page_Load(object sender, EventArgs e)
    {
        // OnSelectedIndexChanged="RadBtnLst_SelectedIndexChanged"  AutoPostBack="True" 
        RadBtnLst.Attributes.Add("onclick", "return FnGetRadBtnSelectedValue('" + RadBtnLst.ClientID + "','" + TxtNo.ClientID + "');"); 
    }
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (SymbolAddCommands != null)
        {
            SymbolAddCommands(sender, e);
        }
    }
    public TextBox TextBoxCtrl
    {
        get
        {
            return TxtNo;
        }
    }
    public RadioButtonList RadioBtnListCtrl
    {
        get
        {
            return RadBtnLst;
        }
    }
    public string TextBoxValue
    {
        get
        {
            return TxtNo.Text.Trim();
        }
        set
        {
            TxtNo.Text = value.ToString();
        }
    }
    protected void RadBtnLst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadBtnLst.SelectedValue.ToString().Equals("YES"))
        {
            TxtNo.Enabled = true;
            TxtNo.Focus();
        }
        else
        {
            TxtNo.Enabled = false;
            TxtNo.Text = "";
        }
    }
}
