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

public partial class CtrlMnthYear : System.Web.UI.UserControl
{
    ClsCommonVariables ObjCls = new ClsCommonVariables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AppSettingsReader asdr = new AppSettingsReader();
            for (int nYr = ObjCls.FnIsNumeric(asdr.GetValue("FRMYEAR", typeof(string)).ToString()); nYr <= DateTime.Now.Year; nYr++)
            {
                DdlYear.Items.Add(nYr.ToString());
            }
            DdlYear.Items.Insert(0, "--Year--");
        }
    }
    public Boolean IsReadOnly
    {
        set
        {
            DdlMonth.Enabled = value;
            DdlYear.Enabled = value;
        }
    }
    public string MonthYearText
    {
        get
        {
            return  "01" + "/" + DdlMonth.SelectedValue.ToString() + "/" + DdlYear.SelectedValue.ToString();
        }
        set
        {
            if (value.ToString().Trim().Length > 0)
            {
                string[] strSourceDate = value.ToString().Trim().Split('/');
                if (strSourceDate.Length > 1)
                {
                    DdlMonth.Text = strSourceDate[1].ToString();
                    DdlYear.Text = strSourceDate[2].ToString();
                }
            }
            else
            {
                DdlMonth.SelectedIndex=0;
                DdlYear.SelectedIndex=0;
            }
        }
    }
    public void FnSetClear()
    {
        DdlMonth.SelectedIndex = 0;
        DdlYear.SelectedIndex = 0;
    }
}
