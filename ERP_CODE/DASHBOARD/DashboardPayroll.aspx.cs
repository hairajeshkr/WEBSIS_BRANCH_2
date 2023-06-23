using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashboardPayroll : ClsPageEvents, IPageInterFace
{
   // ClsInvoice ObjCls = new ClsInvoice();
    string strCnt1 = "0", strCnt2 = "0", strCnt3 = "0", strCnt4 = "0", strCnt5 = "0", strCnt6 = "0", strCnt7 = "0", strCnt8 = "0";
    public void FnAssignProperty()
    {
        throw new NotImplementedException();
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        throw new NotImplementedException();
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnPrintRecord()
    {
        throw new NotImplementedException();
    }

    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
           // FnGetInventoryDashboard(ObjCls, ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(Request.QueryString["CID"].ToString())), RptrReceiptLst, RptrIssueLst, RptrExpireLst, ref strCnt1, ref strCnt2, ref strCnt3, ref strCnt4, ref strCnt5, ref strCnt6, ref strCnt7, ref strCnt8);
            SpnCnt1.InnerText = strCnt1;
            SpnCnt2.InnerText = strCnt2;
            SpnCnt3.InnerText = strCnt3;
            SpnCnt4.InnerText = strCnt4;
            SpnCnt5.InnerText = strCnt5;
            SpnCnt6.InnerText = strCnt6;
            SpnCnt7.InnerText = strCnt7;
            SpnCnt8.InnerText = strCnt8;
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }
}