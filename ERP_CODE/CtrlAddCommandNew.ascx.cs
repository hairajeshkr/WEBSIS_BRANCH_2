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

public partial class CtrlAddCommandNew : System.Web.UI.UserControl
{
    public delegate void ClickEventHandler(object sender, EventArgs e);
    public event ClickEventHandler AddCommands;
    Boolean _IsPrint = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        TblCmd.Visible = true;
        BtnAdd.Attributes.Add("onclick", "javascript:return ValidateChildDataNew();");// ctl00_ContentPlaceHolder1_ctl00_BtnSave.disabled=true;__doPostBack('ctl00$ContentPlaceHolder1$ctl00$BtnSave','');");
        if (IsEnableScript == true)
        {
            BtnClear.Attributes.Add("onclick", "javascript:return FnClear();");
            BtnDelete.Attributes.Add("onclick", "javascript:return FnDelete();");
        }
        else
        {
            BtnDelete.Attributes.Add("onclick", "javascript:return confirm('Do you want to delete this record.');");
        }
    }
    public void ManiPulateData(object sender, EventArgs e)
    {
        if (AddCommands != null)
        {
            AddCommands(sender, e);
        }
    }
    public string AddToolTip
    {
        get
        {
            return BtnAdd.ToolTip;
        }
        set
        {
            BtnAdd.ToolTip = ((string)(value));
        }
    }
    public string AddText
    {
        get
        {
            return BtnAdd.Text;
        }
        set
        {
            BtnAdd.Text = ((string)(value));
        }
    }
    public string AddCommandName
    {
        get
        {
            return BtnAdd.CommandName;
        }
        set
        {
            BtnAdd.CommandName = ((string)(value));
        }
    }
    public string AddCommandArgument
    {
        get
        {
            return BtnAdd.CommandArgument;
        }
        set
        {
            BtnAdd.CommandArgument = ((string)(value));
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
    public string ID
    {
        get
        {
            return HdnChldId.Value;
        }
        set
        {
            HdnChldId.Value = value;
        }
    }
    public Button AddButton
    {
        get
        {
            return BtnAdd;
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
}
