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

public partial class CtrlNameIdCtrl : System.Web.UI.UserControl
{
    private string _StrPlaceHoldr = "";
    private bool _bVal = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtName.Attributes.Add("autocomplete", "off");
        if (!IsPostBack)
        {
            TxtName.Enabled = IsEnable;
        }
        TxtName.Attributes.Add("placeholder", PlaceHoldr); 
        TblCtrl.Visible = true;
    }
    public string SelectedText
    {
        get
        {
            return TxtName.Text;
        }
        set
        {
            TxtName.Text = value;
        }
    }
    public string SelectedValue
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
    public Boolean IsEnable
    {
        get
        {
            return _bVal;
        }
        set
        {
            _bVal = value;
        }
    }
    public string PlaceHoldr
    {
        get { return _StrPlaceHoldr; }
        set { _StrPlaceHoldr = value; }
    }
    public string TextControl
    {
        get
        { return TxtName.ClientID ; }
    }
    public string IdControl
    {
        get
        { return HdnId.ClientID ; }
    }
    public TextBox ControlTextBox
    {
        get
        { return TxtName; }
    }
}