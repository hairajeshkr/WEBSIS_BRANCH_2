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

public partial class CtrlSymbolAddCmnd : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler SymbolAddCommands;
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnAdd.Attributes.Add("onclick", "javascript:return FnAddScript('" + TxtNo.ClientID + "');");
        BtnClear.Attributes.Add("onclick", "javascript:return FnMinScript('" + TxtNo.ClientID + "');");
    }
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (SymbolAddCommands != null)
        {
            SymbolAddCommands(sender, e);
        }
    }
    public bool AddIsEnabled
    {
        get
        {
            return BtnAdd.Enabled;
        }
        set
        {
            BtnAdd.Enabled = ((bool)(value));
        }
    }
    public bool MinusIsEnabled
    {
        get
        {
            return BtnClear.Enabled;
        }
        set
        {
            BtnClear.Enabled = ((bool)(value));
        }
    }
    public bool IsVisibleMinus
    {
        get
        {
            return BtnClear.Visible;
        }
        set
        {
            BtnClear.Visible = ((bool)(value));
        }
    }
    public Button AddButton
    {
        get
        {
            return BtnAdd;
        }
    }
    public TextBox TextBoxCtrl
    {
        get
        {
            return TxtNo;
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
}
