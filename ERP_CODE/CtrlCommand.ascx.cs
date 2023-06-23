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

public partial class CtrlCommand : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler FooterCommands;
    Boolean _IsPrint = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        BtnSave.Attributes.Add("onclick", "javascript:return ValidateMasterData();");// ctl00_ContentPlaceHolder1_ctl00_BtnSave.disabled=true;__doPostBack('ctl00$ContentPlaceHolder1$ctl00$BtnSave','');");
        if (IsEnableScript == true)
        {
            BtnClear.Attributes.Add("onclick", "javascript:return FnClear();");
            BtnPrint.Attributes.Add("onclick", "javascript:return FnRptWindow();");
            BtnDelete.Attributes.Add("onclick", "javascript:return FnDelete();");
        }
        else
        {
            BtnDelete.Attributes.Add("onclick", "javascript:return confirm('Do you want to delete this record.');");
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
    public string SaveToolTip
    {
        get
        {
            return BtnSave.ToolTip;
        }
        set
        {
            BtnSave.ToolTip = ((string)(value));
        }
    }
    public string SaveText
    {
        get
        {
            return BtnSave.Text;
        }
        set
        {
            BtnSave.Text = ((string)(value));
        }
    }
    public string ClearText
    {
        get
        {
            return BtnClear.Text;
        }
        set
        {
            BtnClear.Text = ((string)(value));
        }
    }
    public string SaveCommandName
    {
        get
        {
            return BtnSave.CommandName;
        }
        set
        {
            BtnSave.CommandName = ((string)(value));
        }
    }
    public string FindCommandName
    {
        get
        {
            return BtnFind.CommandName;
        }
        set
        {
            BtnFind.CommandName = ((string)(value));
        }
    }
    public string SaveCommandArgument
    {
        get
        {
            return BtnSave.CommandArgument;
        }
        set
        {
            BtnSave.CommandArgument = ((string)(value));
        }
    }
    public string DeleteCommandName
    {
        get
        {
            return BtnDelete.CommandName;
        }
        set
        {
            BtnDelete.CommandName = ((string)(value));
        }
    }
    public string DeleteCommandArgument
    {
        get
        {
            return BtnDelete.CommandArgument;
        }
        set
        {
            BtnDelete.CommandArgument = ((string)(value));
        }
    }
    public string ClearCommandArgument
    {
        get
        {
            return BtnClear.CommandArgument;
        }
        set
        {
            BtnClear.CommandArgument = ((string)(value));
        }
    }
    public string ClearCommandName
    {
        get
        {
            return BtnClear.CommandName;
        }
        set
        {
            BtnClear.CommandName = ((string)(value));
        }
    }
    public bool SaveIsEnabled
    {
        get
        {
            return BtnSave.Enabled;
        }
        set
        {
            BtnSave.Enabled = ((bool)(value));
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
    public bool IsVisibleDelete
    {
        get
        {
            return BtnDelete.Visible;
        }
        set
        {
            BtnDelete.Visible = ((bool)(value));
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
            return BtnFind.Visible;
        }
        set
        {
            BtnFind.Visible = ((bool)(value));
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
    public Button SaveButton
    {
        get
        {
            return BtnSave;
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
