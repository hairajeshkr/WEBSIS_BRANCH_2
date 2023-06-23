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

public partial class Enc : System.Web.UI.Page
{
    ClsEncryptDecryptQueryString ObjCls = new ClsEncryptDecryptQueryString();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox2.Text = ObjCls.EncryptQueryString(TextBox1.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox2.Text = ObjCls.DecryptQueryString(TextBox1.Text);
    }
}
