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

public partial class CtrlRewindEvent : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler RewindCommands;

    protected void Page_Load(object sender, EventArgs e)
    {
        TxtReffNo.Attributes.Add("autocomplete", "off");
        if (IsEnableScript == true)
        {
            BtnFirst.Attributes.Add("onclick", "javascript:return FnGetFirst();");
            BtnPrevious.Attributes.Add("onclick", "javascript:return FnGetPrevious();");
            BtnNext.Attributes.Add("onclick", "javascript:return FnGetNext();");
            BtnLast.Attributes.Add("onclick", "javascript:return FnGetLast();");
        }
        //TxtReffNo.Attributes.Add("onkeypress", "return NumbersOnly(event);");
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
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (RewindCommands != null)
        {
           RewindCommands(sender, e);
        }
    }
    public string TxtRefNo
    {
        get
        {
            return TxtReffNo.Text;
        }
        set
        {
            TxtReffNo.Text = value;
        }
    }
    public string TokenNo
    {
        get
        {
            return LblTkn.Text;
        }
        set
        {
            LblTkn.Text = value;
        }
    }
    public Boolean IsEnableLastButton
    {
        get
        {
            return BtnLast.Enabled;
        }
        set
        {
            BtnLast.Enabled = value;
        }
    }
    public Boolean IsEnablePreviousButton
    {
        get
        {
            return BtnPrevious.Enabled;
        }
        set
        {
            BtnPrevious.Enabled = value;
        }
    }
    public Boolean IsEnableNextButton
    {
        get
        {
            return BtnNext.Enabled;
        }
        set
        {
            BtnNext.Enabled = value;
        }
    }
    public Boolean IsEnableFirstButton
    {
        get
        {
            return BtnFirst.Enabled;
        }
        set
        {
            BtnFirst.Enabled = value;
        }
    }
    public Boolean IsEnableGetButton
    {
        get
        {
            return BtnGet.Enabled;
        }
        set
        {
            BtnGet.Enabled = value;
        }
    }
    public Boolean IsVisibleGetButton
    {
        get
        {
            return BtnGet.Visible;
        }
        set
        {
            BtnGet.Visible = value;
        }
    }
}