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

public partial class CtrlTokenEvent : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler TokenCommands;

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (TokenCommands != null)
        {
            TokenCommands(sender, e);
        }
    }
    public string TokenNo
    {
        get
        {
            return TxtTokenNo.Text;
        }
        set
        {
            TxtTokenNo.Text = value;
        }
    }
    public Boolean IsVisibleTokenButton
    {
        get
        {
            return BtnTknFind.Visible;
        }
        set
        {
            BtnTknFind.Visible = value;
        }
    }
    public void FnIsVisible(bool PrmVal)
    {
        BtnTknFind.Visible = PrmVal;
        LblTokenNo.Visible = PrmVal;
    }
}