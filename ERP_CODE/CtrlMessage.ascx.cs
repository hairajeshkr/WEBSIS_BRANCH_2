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

public partial class CtrlMessage : System.Web.UI.UserControl
{
    private int _Width1 = 100, _Width2 = 100;
    protected void Page_Load(object sender, EventArgs e)
    {
        LblMsg1.Width = Width1;
        LblMsg2.Width = Width2;
    }
    public string Message1
    {
        get
        {
            return LblMsg1.Text;
        }
        set
        {
            LblMsg1.Text = value;
        }
    }
    public string Message2
    {
        get
        {
            return LblMsg2.Text;
        }
        set
        {
            LblMsg2.Text = value;
        }
    }
    public int Width1
    {
        get { return _Width1; }
        set { _Width1 = value; }
    }
    public int Width2
    {
        get { return _Width2; }
        set { _Width2 = value; }
    }
    public void FnIsVisible(bool PrmVal)
    {
        LblMsg1.Visible = PrmVal;
        LblMsg2.Visible = PrmVal;
    }
    public void FnClear()
    {
        LblMsg1.Text = "";
        LblMsg2.Text = "";
    }
}