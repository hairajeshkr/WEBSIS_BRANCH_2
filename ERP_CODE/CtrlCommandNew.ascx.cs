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

public partial class CtrlCommandNew : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler FooterCommands;
    Boolean _IsPrint = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnFetch.Attributes.Add("onclick", "javascript:return ValidateMasterData();");// ctl00_ContentPlaceHolder1_ctl00_BtnSave.disabled=true;__doPostBack('ctl00$ContentPlaceHolder1$ctl00$BtnSave','');");
        if (IsEnableScript == true)
        {
            BtnClear.Attributes.Add("onclick", "javascript:return FnClear();");
            BtnPrint.Attributes.Add("onclick", "javascript:return FnRptWindow();");
        }
    }
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (FooterCommands != null)
        {
            _IsPrint = Convert.ToBoolean(HdnCnfrm.Value);
            FooterCommands(sender, e);
        }
    }
    public string FetchToolTip
    {
        get
        {
            return BtnFetch.ToolTip;
        }
        set
        {
            BtnFetch.ToolTip = ((string)(value));
        }
    }
    public string FetchText
    {
        get
        {
            return BtnFetch.Text;
        }
        set
        {
            BtnFetch.Text = ((string)(value));
        }
    }
    public string FetchCommandName
    {
        get
        {
            return BtnFetch.CommandName;
        }
        set
        {
            BtnFetch.CommandName = ((string)(value));
        }
    }
    public string FetchCommandArgument
    {
        get
        {
            return BtnFetch.CommandArgument;
        }
        set
        {
            BtnFetch.CommandArgument = ((string)(value));
        }
    }
    public bool FetchIsEnabled
    {
        get
        {
            return BtnFetch.Enabled;
        }
        set
        {
            BtnFetch.Enabled = ((bool)(value));
        }
    }
    public bool ClearIsEnabled
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
    public bool IsVisibleClear
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
    public bool IsVisiblePrint
    {
        get
        {
            return BtnPrint.Visible;
        }
        set
        {
            BtnPrint.Visible = ((bool)(value));
        }
    }
    public bool IsVisibleFind
    {
        get
        {
            return BtnFetch.Visible;
        }
        set
        {
            BtnFetch.Visible = ((bool)(value));
        }
    }
    public string ID
    {
        get
        {
            return HdnId.Value;
        }
        set
        {
            HdnId.Value = value;
        }
    }
    public Boolean IsPrint
    {
        get
        {
            return _IsPrint;
        }
        set
        {
            _IsPrint = value;
        }
    }
    public Button FetchButton
    {
        get
        {
            return BtnFetch;
        }
    }
    Boolean bVal = false;
    public Boolean IsEnableScript
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
    public string PrintText
    {
        get
        {
            return BtnPrint.Text;
        }
        set
        {
            BtnPrint.Text = ((string)(value));
        }
    }
}
