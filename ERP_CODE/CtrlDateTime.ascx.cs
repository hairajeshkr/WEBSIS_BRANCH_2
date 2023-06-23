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

public partial class CtrlDateTime : System.Web.UI.UserControl
{
    ClsCommonVariables ObjCls = new ClsCommonVariables();
    Boolean bVal = false, bValTime = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        CDdlr.Controls.Add(ObjCls.FnShowCalender("TxtDate", "Img1"));
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
            if (IsVisibleDateTime == true)
            {
                DateText = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace("-", "/");
            }
            DdlHr.Visible = IsVisibleTimeControl;
            DdlMnt.Visible = IsVisibleTimeControl;
        }
    }
    public void FnNewDate()
    {
        if (IsVisibleDateTime == true)
        {
            FnSetClearDateTime();
        }
        else
        {
            TxtDate.Text = DateTime.Now.ToString("dd/MMM/yyyy").Replace("-", "/");
        }
    }
    public Boolean IsVisibleDateTime
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
    public Boolean IsVisibleTimeControl
    {
        get
        {
            return bValTime;
        }
        set
        {
            bValTime = value;
        }
    }
    public Boolean IsReadOnlyDate
    {
        set
        {
            TxtDate.ReadOnly = value;
        }
    }
    public string DateText
    {
        get
        {
            string strDate = TxtDate.Text.Trim() + " " + DdlHr.SelectedValue.ToString() + ":" + DdlMnt.SelectedValue.ToString() + ":00";
            return (TxtDate.Text.Trim().Length > 0 ? strDate : "");
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
                TxtDate.Text = strSourceDate[0].ToString().Replace("-", "/");
            }
            else
            {
                DdlHr.SelectedIndex=0;
                DdlMnt.SelectedIndex=0;
                TxtDate.Text = "";
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
    private void FnSetClearDateTime()
    {
        string[] strSourceDate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Split(' ');
        if (strSourceDate.Length > 1)
        {
            string[] strSourceTime = strSourceDate[1].Split(':');
            if (strSourceTime.Length > 1)
            {
                DdlHr.Text = FnRound(ObjCls.FnIsNumeric(strSourceTime[0].ToString()));
                DdlMnt.Text = FnRound(ObjCls.FnIsNumeric(strSourceTime[1].ToString()));
            }
        }
        TxtDate.Text = strSourceDate[0].ToString().Replace("-", "/");
    }
}
