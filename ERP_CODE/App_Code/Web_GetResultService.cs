using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Text;
using System.Data;
using System.Configuration;

[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Web_GetResultService : System.Web.Services.WebService
{
    ClsWebServiceRecordList ObjCls = new ClsWebServiceRecordList();
    public Web_GetResultService()
    {
    }
    [WebMethod]
    public string[] FnGetTaxCalculation(string PrmQty, string PrmRate, string PrmTaxId, string PrmDiscount)
    {
        AppSettingsReader asdr = new AppSettingsReader();
        string[] strVal = null;
        if (asdr.GetValue("ISINCLUSIVETAX", typeof(string)).ToString().Equals("1"))
        {
            strVal = ObjCls.FnTaxClaculate(ObjCls.FnIsDouble(PrmQty), ObjCls.FnIsDouble(PrmRate), ObjCls.FnIsNumeric(PrmTaxId), 0, ObjCls.FnIsDouble(PrmDiscount), false, true, true);
        }
        else
        {
            strVal = ObjCls.FnTaxClaculate(ObjCls.FnIsDouble(PrmQty), ObjCls.FnIsDouble(PrmRate), ObjCls.FnIsNumeric(PrmTaxId), 0, ObjCls.FnIsDouble(PrmDiscount), false, false, true);
        }
        return strVal;
    }
    [WebMethod]
    public string[] FnGetPieceDiscTaxCalculation(string PrmQty, string PrmRate, string PrmPieceVal, string PrmTaxId)
    {
        AppSettingsReader asdr = new AppSettingsReader();
        double dDiscount = 0;
        if (ObjCls.FnIsDouble(PrmPieceVal) > 0)
        {
            dDiscount = Math.Round(ObjCls.FnIsDouble(PrmQty) * ObjCls.FnIsDouble(PrmPieceVal), 2);
        }
        string[] strVal = null;
        if (asdr.GetValue("ISINCLUSIVETAX", typeof(string)).ToString().Equals("1"))
        {
            strVal = ObjCls.FnPieceTaxClaculate(ObjCls.FnIsDouble(PrmQty), ObjCls.FnIsDouble(PrmRate), ObjCls.FnIsNumeric(PrmTaxId), 0, dDiscount, false, true, true);
        }
        else
        {
            strVal = ObjCls.FnPieceTaxClaculate(ObjCls.FnIsDouble(PrmQty), ObjCls.FnIsDouble(PrmRate), ObjCls.FnIsNumeric(PrmTaxId), 0, dDiscount, false, false, true);
        }
        return strVal;
    }
    [WebMethod]
    public string[] FnGetTaxCalculationExclusive(string PrmQty, string PrmRate, string PrmTaxId, string PrmDiscount)
    {
        return ObjCls.FnTaxClaculate(ObjCls.FnIsDouble(PrmQty), ObjCls.FnIsDouble(PrmRate), ObjCls.FnIsNumeric(PrmTaxId), 0, ObjCls.FnIsDouble(PrmDiscount), false, false, true);
    }
    [WebMethod]
    public string[] FnGetTaxCalculationExclusiveMode(string PrmQty, string PrmRate, string PrmTaxId, string PrmDiscount)
    {
        string[] strList = new string[7];
        int PrmCessId = 0;
        double PrmCessValue = ObjCls.FnGetTaxCessVal("CESS", PrmCessId);
        double PrmTaxValue = ObjCls.FnGetTaxCessVal("TAX", ObjCls.FnIsNumeric(PrmTaxId));

        double dPrice = Math.Round(ObjCls.FnIsDouble(PrmQty) * ObjCls.FnIsDouble(PrmRate), 2);
        double dDiscountValue = Math.Round(dPrice * ObjCls.FnIsDouble(PrmDiscount) / 100, 3);
        double dTaxAmount = 0, dCessAmount = 0, dTotalAmount;
        double dAmt = Math.Round(dPrice - dDiscountValue, 2);

        dTaxAmount = Math.Round((dAmt * PrmTaxValue) / 100, 2);

        dCessAmount = 0;// Math.Round(dTaxAmount * PrmCessValue / 100, 2);
        dTotalAmount = Math.Round(dTaxAmount + dCessAmount + dAmt, 2);

        strList.SetValue(dPrice.ToString(), 0);
        strList.SetValue(dAmt.ToString(), 1);
        strList.SetValue(dDiscountValue.ToString(), 2);
        strList.SetValue(dTaxAmount.ToString(), 3);
        strList.SetValue(dCessAmount.ToString(), 4);
        strList.SetValue(dTotalAmount.ToString(), 5);
        return strList;
    }
    [WebMethod]
    public string[] FnGetTaxCalculationExclusiveModeNew(string PrmQty, string PrmRate, string PrmTaxId, string PrmDiscount)
    {
        string[] strList = new string[7];
        int PrmCessId = 0;
        double PrmCessValue = ObjCls.FnGetTaxCessVal("CESS", PrmCessId);
        double PrmTaxValue = ObjCls.FnGetTaxCessVal("TAX", ObjCls.FnIsNumeric(PrmTaxId));
        double dPrice = Math.Round(ObjCls.FnIsDouble(PrmQty) * ObjCls.FnIsDouble(PrmRate), 2);
        double dDiscountValue = ObjCls.FnIsDouble(PrmDiscount);// (ObjCls.FnIsDouble(PrmDiscAmt) > 0 ? ObjCls.FnIsDouble(PrmDiscAmt) : dPrice * ObjCls.FnIsDouble(PrmDiscount) / 100);

        double dTaxAmount = 0, dCessAmount = 0, dTotalAmount, dDiscPer = 0;
        double dAmt = Math.Round(dPrice - dDiscountValue, 2);
        dDiscPer = Math.Round((dDiscountValue * 100) / dPrice, 3);

        dTaxAmount = Math.Round((dAmt * PrmTaxValue) / 100, 2);

        dCessAmount = 0;// Math.Round(dTaxAmount * PrmCessValue / 100, 2);
        dTotalAmount = Math.Round(dTaxAmount + dCessAmount + dAmt, 2);

        strList.SetValue(dPrice.ToString(), 0);
        strList.SetValue(dAmt.ToString(), 1);
        strList.SetValue(dDiscountValue.ToString(), 2);
        strList.SetValue(dTaxAmount.ToString(), 3);
        strList.SetValue(dCessAmount.ToString(), 4);
        strList.SetValue(dTotalAmount.ToString(), 5);
        strList.SetValue(dDiscPer.ToString(), 6);
        return strList;
    }
    //===================================================================
    [WebMethod]
    public string[] FnGetAdditionChargeCalculation(string PrmChrgId, string PrmAmt, string PrmTaxAmt, string PrmNetTotal)
    {
        string[] strChrg = PrmChrgId.Split('-');
        string[] strList = new string[3];
        string strChrgType = "";
        double dPercentage = 0, dChrgAmt = 0, dAddVal = 0, dLessVal = 0;
        ObjCls.FnGetTransChargeValueList(ObjCls.FnIsNumeric(strChrg[1]), ref dPercentage, ref dChrgAmt, ref strChrgType);
        if (strChrgType.Equals("TAX"))
        {
            dAddVal = Math.Round((ObjCls.FnIsDouble(PrmAmt) * dPercentage) / 100, 2);
        }
        else if (strChrgType.Equals("CESS"))
        {
            dAddVal = Math.Round((ObjCls.FnIsDouble(PrmTaxAmt) * dPercentage) / 100, 2);
        }
        else if (strChrgType.Equals("TDS"))
        {
            dLessVal = Math.Round((ObjCls.FnIsDouble(PrmNetTotal) * dPercentage) / 100, 2);
        }
        strList.SetValue(dAddVal.ToString(), 0);
        strList.SetValue(dLessVal.ToString(), 1);
        strList.SetValue(strChrgType, 2);
        return strList;
    }
    [WebMethod]
    public string[] FnGetAccountShipmentDetailsList(string PrmAccountId, string PrmPayamentTermsId)
    {
        return ObjCls.FnGetShipmentRecordList(ObjCls.FnIsNumeric(PrmAccountId), ObjCls.FnIsNumeric(PrmPayamentTermsId));
    }
    //==================== DROPDOWN LIST

    [WebMethod()]
    public string[,] FnGetStaffList_DropDownList(string PrmCompanyId, string PrmBranchId, string PrmDesignation)
    {
        ClsDropdownRecordList ObjWeb = new ClsDropdownRecordList();
        string[,] strArry = ObjWeb.FnGetConfigStaffListArrayList(PrmCompanyId, PrmBranchId, PrmDesignation.Trim(), "---Select Staff ---");
        return strArry;
    }

    //===================== BATCh STOCK LIST ======================
    [WebMethod]
    public string FnGetDoubleValue(string PrmVal)
    {
        return ObjCls.FnIsDouble(PrmVal).ToString();
    }
}

