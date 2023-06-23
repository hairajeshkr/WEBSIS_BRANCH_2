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

public partial class CtrlTime : System.Web.UI.UserControl
{
    ClsCommonVariables ObjCls = new ClsCommonVariables();
    Boolean bVal = false, bValTime = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strHr = "";          
            for (int iHr = 0; iHr < 24; iHr++)
            {
                strHr = (iHr.ToString().Trim().Length == 1 ? "0" + iHr.ToString() : iHr.ToString());
                DdlHr.Items.Add(strHr);
            }
            for (int jHr = 0; jHr <= 59; jHr++)
            {
                strHr = (jHr.ToString().Trim().Length == 1 ? "0" + jHr.ToString() : jHr.ToString());
                DdlMnt.Items.Add(strHr);
            }
        }
    }
    public string TimeText
    {
        get
        {
            return DdlHr.SelectedValue.ToString() + ":" + DdlMnt.SelectedValue.ToString() + ":00";
        }
        set
        {
            if (value.ToString().Trim().Length > 0)
            {
                string[] strSourceDate = value.ToString().Split(' ');
                if (strSourceDate.Length > 1)
                {
                    string[] strSourceTime = strSourceDate[1].Split(':');
                    if (strSourceTime.Length > 1)
                    {
                        DdlHr.Text = FnRound(ObjCls.FnIsNumeric(strSourceTime[0].ToString()));
                        DdlMnt.Text = FnRound(ObjCls.FnIsNumeric(strSourceTime[1].ToString()));
                    }
                }
            }
            else
            {
                DdlHr.SelectedIndex=0;
                DdlMnt.SelectedIndex=0;
            }
        }
    }
    private string FnRound(int PrmVal)
    {
        string strVal = PrmVal.ToString();
        if (PrmVal <= 10)
        {
            strVal = "0" + PrmVal.ToString();
        }
        return strVal;
    }
}
