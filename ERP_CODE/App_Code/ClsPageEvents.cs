using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LOTUS_GENERAL;
using System.Collections.Generic;
using System.Drawing;
using AjaxControlToolkit;
using System.Drawing.Imaging;
using System.IO;

public partial class ClsPageEvents : System.Web.UI.Page
{
    public int _nRptHeight = 0, _nRptWidth = 0;
    public string _strFileFormat = "", _strUrl = "", _strLnk = "", _strTitle = "", _strHdr = "", _strDestPath = "", _strImgeByte = "", _strDateVal = "", _strMsg = "";

    public DataSet DS_RECORD = null;
    public DataTable DT_RECORD = null;
    public DataView _dwMainRecord = null, _dwChildRecod = null;

    ClsUserRights objUserRights;   
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClsUserPrevilage ObjUsrPrevilage = new ClsUserPrevilage();
            objUserRights = new ClsUserRights();
            ViewState["ID"] = "0";
            ViewState["CHLD_ID"] = "0";
            ViewState["DT"] = "";
            ViewState["DT_CHILD"] = "";
            ViewState["DT_UPDATE"] = DateTime.Now.ToString();
            objUserRights.USERID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["UID"].ToString().Replace(" ", "+")));
            objUserRights.COMPANYID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["CID"].ToString())); 
            objUserRights.BRANCHID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["BID"].ToString()));
            objUserRights.FAYEARID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["FID"].ToString()));
            objUserRights.ACYEARID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["AID"].ToString()));

            objUserRights.MENUID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["MID"].ToString().Replace(" ", "+")));
            objUserRights.USERGROUPID = ObjUsrPrevilage.FnIsNumeric(ObjUsrPrevilage.DecryptQueryString(Request.QueryString["UGRPID"].ToString().Replace(" ", "+")));

            objUserRights.TTYPE = Request.QueryString["TTYPE"].ToString();

            ObjUsrPrevilage.CompanyId = objUserRights.COMPANYID;
            ObjUsrPrevilage.BranchId = objUserRights.BRANCHID;
            ObjUsrPrevilage.FaId = objUserRights.FAYEARID;
            ObjUsrPrevilage.AcId = objUserRights.ACYEARID;
            ObjUsrPrevilage.UserId = objUserRights.USERID;
            ObjUsrPrevilage.MenuId = objUserRights.MENUID;

            ObjUsrPrevilage.FnPrevilage();
            objUserRights.INSERT = ObjUsrPrevilage.ISINSERTROLE;
            objUserRights.UPDATE = ObjUsrPrevilage.ISUPDATEROLE;
            objUserRights.DELETE = ObjUsrPrevilage.ISDELETEROLE;
            objUserRights.PRINT = ObjUsrPrevilage.ISPRINTROLE;
            objUserRights.PRINTPREVIEW = ObjUsrPrevilage.ISPRINTPREVIEWROLE;
            objUserRights.EMAIL = ObjUsrPrevilage.ISEMAILROLE;
            ViewState["USERRIGHTS"] = objUserRights;
        } 
        if (ViewState["USERRIGHTS"] != null)
        {
            objUserRights = ViewState["USERRIGHTS"] as ClsUserRights;
        }
    }
    public void FnPopUpAlert(string PrmMsgString)
    {
        Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        if (objPage != null)
        {
            ScriptManager.RegisterClientScriptBlock(objPage, typeof(ClsPageEvents), "Msg", PrmMsgString, false);
        }
    }
    public void FnShowOutPut(string PrmOutPut, ClsCommonBaseMaster PrmBaseMaster, bool PrmIsPrint)
    {
        string[] _strMsg = PrmOutPut.Split('/');
        if (PrmIsPrint == true)
        {
            PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(_strMsg[0]);
            FnPrintRecord(PrmBaseMaster);
            FnCancel();
        }
        else
        {
            if (_strMsg.Length > 1)
            {
                if (_strMsg[0].Equals("0"))
                {
                    FnPopUpAlert(PrmBaseMaster.FnAlertMessage(_strMsg[1]));
                }
                else
                {
                    FnPopUpAlert(PrmBaseMaster.FnAlertMessage(_strMsg[1]));
                    FnCancel();
                }
            }
            else
            {
                FnPopUpAlert(PrmBaseMaster.FnAlertMessage((_strMsg.Length > 1 ? _strMsg[1] : _strMsg[0])));
            }
        }
    }
    public void FnUnClearOutPut(string PrmOutPut, ClsCommonBaseMaster PrmBaseMaster, bool PrmIsAdd)
    {
        string[] _strMsg = PrmOutPut.Split('/');
        if (PrmIsAdd == true)
        {
            ViewState["ID"] =_strMsg[0].ToString();
        }
        FnPopUpAlert(PrmBaseMaster.FnAlertMessage((_strMsg.Length > 1 ? _strMsg[1] : _strMsg[0])));
    }
    public virtual void ManiPulateDataEvent_Clicked(string PrmFlag,ClsCommonBaseMaster PrmBaseMaster,bool PrmIsPrint)
    {
        try
        {
            switch (PrmFlag.ToUpper())
            {
                case "NEW":
                    if (objUserRights.INSERT == true)
                    {
                        FnShowOutPut(PrmBaseMaster.SaveRecord() as string, PrmBaseMaster, PrmIsPrint);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Save New Record"));
                    }
                    break;
                case "GENINV":
                    if (objUserRights.INSERT == true)
                    {
                        string strMsg = PrmBaseMaster.AutoGenerateRecord(PrmFlag) as string;
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Generate New Record"));
                    }
                    break;
                case "INSERT"://If record save then cold't clear the filed
                    if (objUserRights.INSERT == true)
                    {
                        FnUnClearOutPut(PrmBaseMaster.SaveRecord() as string, PrmBaseMaster, PrmIsPrint);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Save New Record"));
                    }
                    break;
                case "UPDATE":
                    if (objUserRights.UPDATE == true)
                    {
                        FnShowOutPut(PrmBaseMaster.UpdateRecord() as string, PrmBaseMaster, PrmIsPrint);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Update Record"));
                    }
                    break;
                case "MODIFY"://If record save then cold't clear the filed
                    if (objUserRights.INSERT == true)
                    {
                        FnUnClearOutPut(PrmBaseMaster.UpdateRecord() as string, PrmBaseMaster, PrmIsPrint);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Update Record"));
                    }
                    break;
                case "DELETE":
                    if (objUserRights.DELETE == true)
                    {
                        FnShowOutPut(PrmBaseMaster.DeleteRecord() as string, PrmBaseMaster, false);
                        //FnPopUpAlert(PrmBaseMaster.FnAlertMessage(PrmBaseMaster.DeleteRecord() as string));
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Delete Record"));
                    }
                    break;
                case "CLEAR":
                    FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Clear Record"));
                    break;
                case "CLOSE":
                    FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Close Record"));
                    break;
                case "PRINT":
                    if (objUserRights.PRINT == true)
                    {
                        FnPrintRecord(PrmBaseMaster);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
                    }
                    break;
                case "PRINT_EXCEL":
                    if (objUserRights.PRINT == true)
                    {
                        FnPrintRecordExcel(PrmBaseMaster);
                    }
                    else
                    {
                        FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
                    }
                    break;
                case "DTPRINT":
                    FnPrintDetailedRecord(PrmBaseMaster);
                    break;
                case "FIND":
                    FnFindRecord(PrmBaseMaster);
                    break;
                case "SEARCH":
                    FnSearchRecord(PrmBaseMaster);
                    break;
                case "HELP":
                    FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Help Record"));
                    break;
                case "FIRST":
                    FnAssignProperty(PrmBaseMaster);
                    PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnGetFirstId());
                    if (PrmBaseMaster.ID > 0)
                    {
                        ViewState["ID"] = PrmBaseMaster.ID.ToString();
                        FnFindRecord(PrmBaseMaster);
                    }
                    break;
                case "PREVIOUS":
                    FnAssignProperty(PrmBaseMaster);
                    PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnGetPreviousId());
                    if (PrmBaseMaster.ID > 0)
                    {
                        ViewState["ID"] = PrmBaseMaster.ID.ToString();
                        FnFindRecord(PrmBaseMaster);
                    }
                    break;
                case "NEXT":
                    FnAssignProperty(PrmBaseMaster);
                    PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnGetNextId());
                    if (PrmBaseMaster.ID > 0)
                    {
                        ViewState["ID"] = PrmBaseMaster.ID.ToString();
                        FnFindRecord(PrmBaseMaster);
                    }
                    break;
                case "LAST":
                    FnAssignProperty(PrmBaseMaster);
                    PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnGetLastId());
                    if (PrmBaseMaster.ID > 0)
                    {
                        ViewState["ID"] = PrmBaseMaster.ID.ToString();
                        FnFindRecord(PrmBaseMaster);
                    }
                    break;
                case "GET":
                    FnAssignProperty(PrmBaseMaster);
                    PrmBaseMaster.ID = PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnGetRefNoId());
                    if (PrmBaseMaster.ID > 0)
                    {
                        ViewState["ID"] = PrmBaseMaster.ID.ToString();
                        FnFindRecord(PrmBaseMaster);
                    }
                    break;
                case "ITEM_NEW":// Child Insertion
                    ViewState["DT_CHILD"] = PrmBaseMaster.SaveChildRecord() as DataTable;
                    break;
                case "ITEM_UPDATE":// Child Updation,
                    ViewState["DT_CHILD"] = PrmBaseMaster.UpdateChildRecord() as DataTable;
                    break;
                case "ITEM_DELETE":// Child Deletion
                    ViewState["DT_CHILD"] = PrmBaseMaster.DeleteChildRecord() as DataTable;
                    break;
                case "ITEM_FIND":// Token wise item pending display
                    FnFindChildRecord(PrmBaseMaster);
                    break;
            }
        }
        catch (Exception ex)
        {
            PrmBaseMaster.FnAlertMessage(ex.Message);
        } 
    }
    public virtual void FnAssignProperty(ClsCommonBaseMaster PrmBaseItems)
    {
        PrmBaseItems.ID = PrmBaseItems.FnIsNumeric(ViewState["ID"].ToString());
        PrmBaseItems.CompanyId = objUserRights.COMPANYID;
        PrmBaseItems.BranchId = objUserRights.BRANCHID;
        PrmBaseItems.FaId = objUserRights.FAYEARID;
        PrmBaseItems.AcId = objUserRights.ACYEARID;
        PrmBaseItems.UserId = objUserRights.USERID;
        PrmBaseItems.TType = objUserRights.TTYPE;
        PrmBaseItems.UpdateDate = PrmBaseItems.FnDateTime(ViewState["DT_UPDATE"].ToString());
    }
    public virtual void FnAssignChildProperty(ClsCommonBaseMaster PrmBaseItems)
    {
        PrmBaseItems.ID = PrmBaseItems.FnIsNumeric(ViewState["CHLD_ID"].ToString());
        PrmBaseItems.CompanyId = objUserRights.COMPANYID;
        PrmBaseItems.BranchId = objUserRights.BRANCHID;
        PrmBaseItems.FaId = objUserRights.FAYEARID;
        PrmBaseItems.AcId = objUserRights.ACYEARID;
        PrmBaseItems.UserId = objUserRights.USERID;
        PrmBaseItems.TType = objUserRights.TTYPE;
    }
    public virtual void FnCancel()
    { 
        ViewState["ID"] = "0";
        ViewState["DT_UPDATE"] = DateTime.Now.ToString();
        FnInitializeForm();
    }
    public virtual void FnClearItems(string PrmFlag)
    {
        ViewState["CHLD_ID"] = "0";  
    }
    public virtual void FnFindRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        DataSet dsVal = PrmBaseMaster.FindRecord() as DataSet;
        ViewState["DT"] = dsVal.Tables[0];
        if (dsVal.Tables.Count.Equals(2))
        {
            ViewState["DT_CHILD"] = dsVal.Tables[1];
        }
    }
    public void FnSearchRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        DataSet dsVal = PrmBaseMaster.SearchRecord() as DataSet;
        ViewState["DT"] = dsVal.Tables[0];
    }
    public DataTable FnSearchRecordTable(ClsCommonBaseMaster PrmBaseMaster)
    {
        DataSet dsVal = PrmBaseMaster.SearchRecord() as DataSet;
        return dsVal.Tables[0];
    }
    public void FnEditListRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        DataSet dsVal = PrmBaseMaster.EditListRecord() as DataSet;
        ViewState["DT"] = dsVal.Tables[0]; 
        if (dsVal.Tables.Count.Equals(2))
        {
            ViewState["DT_CHILD"] = dsVal.Tables[1];
        }
    }
    public DataSet FnFindDataSetRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        return PrmBaseMaster.FindRecord() as DataSet;
    }
    public virtual void FnFindChildRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        ViewState["DT_CHILD"] = PrmBaseMaster.FindRecord() as DataTable;
    }
    public virtual void FnFocus(Control PrmCntrl)
    {
        ScriptManager ScrtManager = (ScriptManager)Master.FindControl("ScriptManager1");
        ScrtManager.SetFocus(PrmCntrl);
    }
    public ClsUserRights FnGetRights()
    {
        return objUserRights;
    }
    public virtual void FnInitializeForm()
    {
    }
    public string FnGetAutoCodeValue(ClsCommonBaseMaster PrmBaseMaster, string PrmTType, int PrmMenuId)
    {
        PrmBaseMaster.TType = PrmTType.Trim();
        PrmBaseMaster.MenuId = PrmMenuId;
        return PrmBaseMaster.FnGetAutoCode().ToString();
    }
    //========================================================== PRINT ===========================================
    public virtual void FnPrintRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        if (objUserRights.PRINT == true)
        {
            ClsReportGeneral ObjRpt = new ClsReportGeneral();
            string _strRpt = ObjRpt.FnVoucherReportWindow(PrmBaseMaster.ID.ToString(), PrmBaseMaster.RefNo.ToString(), objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(),objUserRights.TTYPE);
            FnPopUpAlert(_strRpt);
        }
        else
        {
            FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
        }                   
    }
    public void FnPrintBarCode(ClsCommonBaseMaster PrmBaseMaster, string PrmBarCode)
    {
        ClsReportGeneral ObjRpt = new ClsReportGeneral();
        string _strRpt = ObjRpt.FnVoucherReportWindow(PrmBaseMaster.ID.ToString(), PrmBaseMaster.RefNo.ToString(), objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), PrmBarCode.Trim(), "BARCODE");
        FnPopUpAlert(_strRpt);
    }
    public void FnPrintOrder(ClsCommonBaseMaster PrmBaseMaster, string PrmOrderType)
    {
        ClsReportGeneral ObjRpt = new ClsReportGeneral();
        string _strRpt = ObjRpt.FnVoucherReportWindow(PrmBaseMaster.ID.ToString(), PrmBaseMaster.RefNo.ToString(), objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), objUserRights.TTYPE, PrmOrderType);
        FnPopUpAlert(_strRpt);
    }
    public void FnPopUpChild(ClsCommonBaseMaster PrmBaseMaster,string PrmHeader,string PrmURL,int PrmWidth,int PrmHeight,bool PrmResize)
    {
        string _strRpt = PrmBaseMaster.FnPopUpWindow(PrmHeader, PrmURL, PrmWidth, PrmHeight, PrmResize);
        FnPopUpAlert(_strRpt);
    }
    public void FnPrintDetailedRecord(ClsCommonBaseMaster PrmBaseMaster)
    {
        if (objUserRights.PRINT == true)
        {
            Session["RPT"] = PrmBaseMaster;
            ClsReportGeneral ObjRpt = new ClsReportGeneral();
            string _strRpt = ObjRpt.FnDetailedReportWindow(objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), objUserRights.TTYPE);
            FnPopUpAlert(_strRpt);
        }
        else
        {
            FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
        }
    }
    public void FnPrintDetailedRecord(ClsCommonBaseMaster PrmBaseMaster, string PrmTType)
    {
        if (objUserRights.PRINT == true)
        {
            Session["RPT"] = PrmBaseMaster;
            ClsReportGeneral ObjRpt = new ClsReportGeneral();
            string _strRpt = ObjRpt.FnDetailedReportWindow(objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), PrmTType, PrmTType);
            FnPopUpAlert(_strRpt);
        }
        else
        {
            FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
        }
    }
    public virtual void FnPrintRecordExcel(ClsCommonBaseMaster PrmBaseMaster)
    {
        if (objUserRights.PRINT == true)
        {
            ClsReportGeneral ObjRpt = new ClsReportGeneral();
            string _strRpt = ObjRpt.FnVoucherReportExcel(PrmBaseMaster.ID.ToString(), PrmBaseMaster.RefNo.ToString(), objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), objUserRights.TTYPE);
            FnPopUpAlert(_strRpt);
        }
        else
        {
            FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
        }
    }
    public void FnPrintDetailedRecordExcel(ClsCommonBaseMaster PrmBaseMaster)
    {
        if (objUserRights.PRINT == true)
        {
            Session["RPT"] = PrmBaseMaster;
            ClsReportGeneral ObjRpt = new ClsReportGeneral();
            string _strRpt = ObjRpt.FnDetailedReportExcel(objUserRights.COMPANYID.ToString(), objUserRights.BRANCHID.ToString(), objUserRights.FAYEARID.ToString(), objUserRights.USERID.ToString(), objUserRights.MENUID.ToString(), objUserRights.TTYPE);
            FnPopUpAlert(_strRpt);
        }
        else
        {
            FnPopUpAlert(PrmBaseMaster.FnAlertMessage(" You Have No permission To Print Record"));
        }
    }
    //============================================================================== END
    public string FnGetDefaultProductionAccountId()
    {
        string strAccId = "";
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            strAccId = asdr.GetValue("PRDACCID", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            strAccId = "0";
            throw ex;
        }
        return strAccId;
    }
    public void FnGetDefaultPurchaseAccount(ref string PrmPuId, ref string PrmPuAcc)
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            PrmPuId = asdr.GetValue("PUID", typeof(string)).ToString();
            PrmPuAcc = asdr.GetValue("PUACC", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FnGetDefaultUnRegPurchaseAccount(ref string PrmPuId, ref string PrmPuAcc)
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            PrmPuId = asdr.GetValue("UPUID", typeof(string)).ToString();
            PrmPuAcc = asdr.GetValue("UPUACC", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetDefaultPurchaseAccount()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("PUID", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool FnGetIsAutoStock()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return (asdr.GetValue("ISAUTOSTK", typeof(string)).ToString() == "1" ? true : false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool FnGetIsAutoStockEnable()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return (asdr.GetValue("ISAUTOENABLE", typeof(string)).ToString() == "1" ? true : false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool FnGetIsBarcodeVisible()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return (asdr.GetValue("ISBARCODENABLE", typeof(string)).ToString() == "1" ? true : false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool FnGetIsBarcodeEnable()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return (asdr.GetValue("ISBARCODENABLE", typeof(string)).ToString() == "1" ? true : false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FnGetDefaultSalesAccount(ref string PrmSlId, ref string PrmSlAcc)
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            PrmSlId = asdr.GetValue("SLID", typeof(string)).ToString();
            PrmSlAcc = asdr.GetValue("SLACC", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetDefaultSalesAccount()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("SLID", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FnGetDefaultCashAccount(ref string PrmId, ref string PrmAcc)
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            PrmId = asdr.GetValue("CSHID", typeof(string)).ToString();
            PrmAcc = asdr.GetValue("CSHACC", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetDefaultOfficeTime()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("DTIME", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetDefaultTarget()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("TARGET", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetSalesTType()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("SALES_TTYPE", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnGetPurchaseTType()
    {
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            return asdr.GetValue("PURCHASE_TTYPE", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string FnReplaceString(string PrmValue)
    {
        string str = PrmValue.Trim();
        return HttpUtility.HtmlEncode(PrmValue).Replace("'", "\\'");
    }
    public string FnSetFormatedValue(double PrmVal)
    {
        return (PrmVal != 0 ? String.Format("{0:0.00}", PrmVal) : "");
    }
    public string FnGetFromDate(ClsCommonBaseMaster PrmBaseMaster, int PrmFaId)
    {
        string _strFrmDate = "", _strToDate = "";
        PrmBaseMaster.FaId = PrmFaId;
        PrmBaseMaster.FnGetFaYearDate(ref _strFrmDate, ref _strToDate);
        DateTime dtVal = Convert.ToDateTime(_strFrmDate);
        return PrmBaseMaster.FnDateTime(dtVal, "");
    }
    public string FnGetGrdDateFormat(ClsCommonBaseMaster PrmBaseMaster, object PrmDate)
    {
        string strDate = "";
        if (PrmBaseMaster.FnDateTime(PrmDate, "").Equals("01/Jan/1800"))
        {
            strDate = "";
        }
        else
        {
            strDate = PrmBaseMaster.FnDateTime(PrmDate, "");
        }
        return strDate;
    }
    public string FnGetMenuPrefix(ClsCommonBaseMaster PrmBaseMaster, int PrmMenuId)
    {
        DataTable _dtGet = PrmBaseMaster.FnGetDataSet("SELECT cPrefix FROM TblMenu WHERE nMenuId=" + PrmMenuId).Tables[0];
        return (_dtGet.Rows.Count > 0 ? _dtGet.Rows[0][0].ToString() : "");
    }
    public void FnSetRadioButtonValue(RadioButtonList PrmRadBtnLst, string PrmVal)
    {
        for (int iRw = 0; iRw <= PrmRadBtnLst.Items.Count - 1; iRw++)
        {
            if (PrmVal.Trim().Equals(PrmRadBtnLst.Items[iRw].Value.ToString()))
            {
                PrmRadBtnLst.Items[iRw].Selected = true;
            }
        }
    }
    public void FnSetCheckboxListValue(CheckBoxList PrmChkBoxLst, string PrmVal)
    {
        string[] strSrcVal = PrmVal.Trim().Split(',');
        for (int iItm = 0; iItm <= strSrcVal.Length - 1; iItm++)
        {
            for (int iRw = 0; iRw <= PrmChkBoxLst.Items.Count - 1; iRw++)
            {
                if (strSrcVal[iItm].Trim().Equals(PrmChkBoxLst.Items[iRw].Value.ToString()))
                {
                    PrmChkBoxLst.Items[iRw].Selected = true;
                }
            }
        }
    }
    public void FnUnSelectCheckboxListValue(CheckBoxList PrmChkBoxLst)
    {
        for (int iRw = 0; iRw <= PrmChkBoxLst.Items.Count - 1; iRw++)
        {
            PrmChkBoxLst.Items[iRw].Selected = false;
        }
    }
    public void FnSetCheckboxListText(CheckBoxList PrmChkBoxLst, string PrmVal)
    {
        string[] strSrcVal = PrmVal.Trim().Split(',');
        for (int iItm = 0; iItm <= strSrcVal.Length - 1; iItm++)
        {
            for (int iRw = 0; iRw <= PrmChkBoxLst.Items.Count - 1; iRw++)
            {
                if (strSrcVal[iItm].Trim().Equals(PrmChkBoxLst.Items[iRw].Text.ToString()))
                {
                    PrmChkBoxLst.Items[iRw].Selected = true;
                }
            }
        }
    }
    public string FnGetCheckboxListValue(CheckBoxList PrmChkBoxLst)
    {
        string strVal = "";
        for (int iRw = 0; iRw <= PrmChkBoxLst.Items.Count - 1; iRw++)
        {
            if (PrmChkBoxLst.Items[iRw].Selected==true)
            {
                strVal = strVal + PrmChkBoxLst.Items[iRw].Value + ",";
            }
        }
        return strVal;
    }
    public string FnGetCheckboxListText(CheckBoxList PrmChkBoxLst)
    {
        string strVal = "";
        for (int iRw = 0; iRw <= PrmChkBoxLst.Items.Count - 1; iRw++)
        {
            if (PrmChkBoxLst.Items[iRw].Selected == true)
            {
                strVal = strVal + PrmChkBoxLst.Items[iRw].Text + ",";
            }
        }
        return strVal;
    }
    public int FnGetLastItemCode(ClsCommonBaseMaster PrmBaseMaster, int PrmCmpId)
    {
        string strsql = "SELECT MAX(cCode) FROM TblItem WHERE nCompanyId=" + PrmCmpId;
        return PrmBaseMaster.FnIsNumeric(PrmBaseMaster.FnExecuteScalar(strsql).ToString());
    }
    public void FnBindingDropDownList(ClsDropdownRecordList PrmList, DataTable PrmDtLst, DropDownList PrmDropDown, string PrmCaption)
    {
        PrmDropDown.DataSource = PrmDtLst;
        PrmDropDown.DataTextField = "Name";
        PrmDropDown.DataValueField = "Id";
        PrmDropDown.DataBind();
        PrmList.FnNullDropDownList(PrmDropDown, (PrmCaption.Trim().Length > 0 ? PrmCaption : "---Select---"), "0");
    }
    public void FnSetDropDownValue(DropDownList PrmDropDown, string PrmVal)
    {
        try
        {
            PrmDropDown.Text = PrmVal;
        }
        catch (Exception ex)
        {
            PrmDropDown.Text = "0";
            string str = ex.Message;
        }
    }
    public DataTable FnGetCustomerDetails(ClsCommonBaseMaster PrmBaseMaster, int PrmCmpId, int PrmAccId, string PrmCode)
    {
        string strSql = "SELECT nId AS Id,cName AS Name,cCode AS Code,cPAddress AS Address FROM TblRegistration WHERE nCompanyId =" + PrmCmpId + " AND nId="+ PrmAccId+ " AND cCode='" + PrmCode + "'";
        return PrmBaseMaster.FnGetDataSet(strSql).Tables[0];
    }
    //=========================================================================================
    public bool FnAlterationStatusVisible(ClsCommonBaseMaster PrmBaseMaster, string PrmStatus)
    {
        return (PrmBaseMaster.FnIsNumeric(PrmStatus) > 0 ? true : false);
    }
    public Color FnGetOrderUnit_Color(string PrmStatus)
    {
        Color _ClrStatus;
        if (PrmStatus.Equals("2"))
        {
            _ClrStatus = ColorTranslator.FromHtml("#d9dff1");
        }
        else if (PrmStatus.Equals("3"))
        {
            _ClrStatus = ColorTranslator.FromHtml("#f9d5f4");
        }
        else if (PrmStatus.Equals("5"))
        {
            _ClrStatus = ColorTranslator.FromHtml("#f7c984");
        }
        else
        {
            _ClrStatus = ColorTranslator.FromHtml("#c7efc4");
        }
        return _ClrStatus;
    }
    public string FnGetDateDiffDays(DateTime PrmFrmDate, DateTime PrmToDate)
    {
        return (Convert.ToDateTime(PrmFrmDate.ToString("dd/MMM/yyyy")) - Convert.ToDateTime(PrmToDate.ToString("dd/MMM/yyyy"))).TotalDays.ToString();
    }
    //====================== XML DATATABLE
    public DataTable FnGetGeneralTable(ClsCommonBaseMaster PrmBaseMaster)
    {
      return PrmBaseMaster.FnConvertStringToDataTable(PrmBaseMaster.FnReadXmlFile(Server.MapPath("~/XML_NULL//GENERAL.xml"))) as DataTable;
    }
    public DataTable FnGetTransMasterTable(ClsCommonBaseMaster PrmBaseMaster)
    {
        return PrmBaseMaster.FnConvertStringToDataTable(PrmBaseMaster.FnReadXmlFile(Server.MapPath("~/XML_NULL//TransMaster.xml"))) as DataTable;
    }
    public DataTable FnGetTransChildTable(ClsCommonBaseMaster PrmBaseMaster)
    {
        return PrmBaseMaster.FnConvertStringToDataTable(PrmBaseMaster.FnReadXmlFile(Server.MapPath("~/XML_NULL//TransChild.xml"))) as DataTable;
    }

    // FILE UPLOAD====================
    public string FnFileDownloadPath(object PrmFileName, string PrmFlag)
    {
        string strFile = "#";
        if (PrmFlag.Equals("VCH"))
        {
            strFile = "~\\UploadedFiles\\Vehicle\\" + PrmFileName.ToString().Replace("~", "").Trim();
        }
        else if (PrmFlag.Equals("ITM"))
        {
            strFile = "~\\UploadedFiles\\Products\\" + PrmFileName.ToString().Replace("~", "").Trim();
        }
        else if (PrmFlag.Equals("DOC"))
        {
            strFile = "~\\UploadedFiles\\Documents\\" + PrmFileName.ToString().Replace("~", "").Trim();
        }
        else if (PrmFlag.Equals("PRF"))
        {
            strFile = "~\\UploadedFiles\\Profile\\" + PrmFileName.ToString().Replace("~", "").Trim();
        }
        return strFile.Trim();
    }
    public string FnServerUploadPath(string PrmFileName)
    {
        return Server.MapPath(Request.ApplicationPath) + PrmFileName.Trim();
    }
    public string[] FnGetImageFormat(ref string PrmFormat)
    {
        PrmFormat = "Only .JPEG || .jpg ||.jpeg ||.JPG ||.png || .PNG ||.tif ||.tiff ||.TIF ||.TIFF ||.jfif ||.JFIF Image formats are allowed.";
        string[] allowed = { ".JPEG", ".jpg", ".jpeg", ".JPG", ".png", ".PNG", ".tif", ".tiff", ".TIF", ".TIFF", ".jfif", ".JFIF" };
        return allowed;
    }
    public string[] FnGetAllFormat(ref string PrmFormat)
    {
        PrmFormat = "Only .JPEG || .jpg ||.jpeg ||.JPG ||.png || .PNG ||.tif ||.tiff ||.TIF ||.TIFF ||.jfif ||.JFIF Image formats are allowed.";
        string[] allowed = { ".JPEG", ".jpg", ".jpeg", ".JPG", ".png", ".PNG", ".tif", ".tiff", ".TIF", ".TIFF", ".jfif", ".JFIF", ".pdf", ".PDF" };
        return allowed;
    }
    public string FnSaveUploadFileName(ClsCommonBaseMaster PrmBaseMaster, string PrmFileName, string PrmPrefix)
    {
        string[] source = PrmFileName.Trim().Split('\\');
        string[] sourcefile = source[source.GetUpperBound(0)].Split('.');
        string sourcefileExt = sourcefile[sourcefile.GetUpperBound(0)];
        return PrmPrefix.Trim() + PrmBaseMaster.FnGetTokenId().ToString() + "." + sourcefileExt;
    }
    public string FnSaveUploadFile(string PrmTokenNo, string PrmFileName, string PrmPrefix)
    {
        string[] source = PrmFileName.Trim().Split('\\');
        string[] sourcefile = source[source.GetUpperBound(0)].Split('.');
        string sourcefileExt = sourcefile[sourcefile.GetUpperBound(0)];
        return PrmPrefix.Trim() + PrmTokenNo.ToString() + "." + sourcefileExt;
    }
    public bool FnValidateFileSize(AsyncFileUpload PrmFileUploadCtrl, decimal PrmSize, int PrmHeight, int PrmWidth)
    {
        bool bVal = true;
        if (PrmSize > 0)
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(PrmFileUploadCtrl.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            decimal size = Math.Round(((decimal)PrmFileUploadCtrl.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > PrmSize)
            {
                FnPopUpAlert("File size must not exceed " + PrmSize.ToString() + " KB.");
                bVal = false;
            }
            else if (height > PrmHeight)
            {
                FnPopUpAlert("Height must not exceed " + PrmHeight.ToString() + "px.");
                bVal = false;
            }
            else if (width > PrmWidth)
            {
                FnPopUpAlert("Width must not exceed " + PrmWidth.ToString() + "px.");
                bVal = false;
            }
        }
        return bVal;
    }
    public string[] FnGetPdfFormat(ref string PrmFormat)
    {
        PrmFormat = "Only .pdf || .PDF Document formats are allowed.";
        string[] allowed = { ".pdf", ".PDF" };
        return allowed;
    }
    public string FnDocFileIcon()
    {
        return "..\\images\\DocIcon.png";
    }
    public string FnVehicleRegIcon()
    {
        return "..\\images\\VchReg.png";
    }
    public string FnVehicleImgIcon()
    {
        return "..\\images\\VchImg.png";
    }
    public string FnProfileIcon()
    {
        return "..\\images\\profileIcon.png";
    }
    public string FnDocFilePath(string PrmFlag, string PrmFileName)
    {
        string strFile = "";
        if (PrmFlag.Equals("VCH"))
        {
            strFile = "\\UploadedFiles\\Vehicle\\" + PrmFileName.Replace("~", "").Trim();
        }
        else if (PrmFlag.Equals("ITM"))
        {
            strFile = "\\UploadedFiles\\Products\\" + PrmFileName.Replace("~", "").Trim();
        }
        else if (PrmFlag.Equals("DOC"))
        {
            strFile = "\\UploadedFiles\\Documents\\" + PrmFileName.Replace("~", "").Trim();
        }
        return strFile;
    }
    public string FnProfileFilePath(string PrmFileName)
    {
        return "\\UploadedFiles\\Profile\\" + PrmFileName.Replace("~", "").Trim();
    }
    public string FnUploadDocFilePath(string PrmFlag, string PrmFileName)
    {
        string strFile = "";
        if (PrmFlag.Equals("VCH_REG") || PrmFlag.Equals("VCH_IMG"))
        {
            strFile = "\\UploadedFiles\\Vehicle\\" + PrmFileName.Replace("~", "").Trim();
        }
        return strFile;
    }
    public void FnBindDocumetPath(HyperLink PrmHyLnkFile, string PrmFileName, string PrmDocType)
    {
        PrmHyLnkFile.Height = 30;
        PrmHyLnkFile.Width = 30;
        PrmHyLnkFile.ImageHeight = 30;
        PrmHyLnkFile.ImageWidth = 30;
        if (PrmDocType.Equals("VCH_REG"))
        {
            PrmHyLnkFile.ImageUrl = FnVehicleRegIcon();
        }
        else if (PrmDocType.Equals("VCH_IMG"))
        {
            PrmHyLnkFile.ImageUrl = FnVehicleImgIcon();
        }
        else if (PrmDocType.Equals("PRF"))
        {
            PrmHyLnkFile.ImageUrl = FnProfileIcon();
        }
        else if (PrmDocType.Equals("DOC"))
        {
            PrmHyLnkFile.ImageUrl = FnDocFileIcon();
        }
        if (PrmFileName.Trim().Length > 0)
        {
            PrmHyLnkFile.NavigateUrl = FnDocFilePath(PrmDocType, PrmFileName);
            PrmHyLnkFile.Target = "_blank";
        }
        else
        {
            PrmHyLnkFile.ToolTip = "";
            PrmHyLnkFile.NavigateUrl = "";
        }
    }
    public bool ThumbnailCallback()
    {
        return false;
    }
    public byte[] FnGenerateThumbnail(string PrmFilePath, ref string PrmImgUrl)
    {
        byte[] bytes = null;
        string path = PrmFilePath;
        System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        using (System.Drawing.Image thumbnail = image.GetThumbnailImage(150, 175, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                thumbnail.Save(memoryStream, ImageFormat.Png);
                bytes = new byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bytes, 0, (int)bytes.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                PrmImgUrl = "data:image/png;base64," + base64String;
            }
        }
        return bytes;
    }
    public void FnFileUplodSuccessErrorScript(AsyncFileUpload PrmFileUpload)
    {
        PrmFileUpload.OnClientUploadComplete = "FnUploadComplete";
        PrmFileUpload.OnClientUploadError = "FnUploadError";
    }
    public void FnFileUplodSuccessErrorScript(AsyncFileUpload PrmFileUpload, string PrmSuccess, string PrmError)
    {
        PrmFileUpload.OnClientUploadComplete = PrmSuccess;
        PrmFileUpload.OnClientUploadError = PrmError;
    }
    public void FnConvertByteToImge(byte[] PrmBytes, HtmlImage PrmImage)
    {
        try
        {
            //PrmImage.Width = 150;
            //PrmImage.Height = 175;
            if (PrmBytes.ToString().Trim().Length > 0)
            {
                //byte[] bImg = (byte[])((Session["IMGBYTES"]));
                string base64String = Convert.ToBase64String(PrmBytes, 0, PrmBytes.Length);
                PrmImage.Src = "data:image/png;base64," + base64String;
            }
            else
            {
                PrmImage.Src = "~//images//none.png";
            }
        }
        catch (Exception ex)
        {
            PrmImage.Src = "~//images/none.png";
        }
    }
    public void FnNoneImage(HtmlImage PrmImage)
    {
        PrmImage.Src = "~//images/none.png";
    }
    public void FnGetPopUpWindowDispaly(string PrmHeader, HyperLink PrmHyLink, int PrmWidth, int PrmHeight, string PrmURL, Label PrmLblScript)
    {
        string strScript = "<script type='text/javascript'>";
        strScript = strScript + "function FnPopUpDisplay" + PrmHyLink.ID + "(){var ReportWinEdit" + PrmHyLink.ID + "=dhtmlwindow.open('ReportWindowEdit" + PrmHyLink.ID + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + PrmWidth.ToString() + "px,height=" + PrmHeight.ToString() + "px,resize=0,scrolling=0,center=1', 'recal');}";
        strScript = strScript + "</script>";
        PrmHyLink.Attributes.Add("onClick", "return FnPopUpDisplay" + PrmHyLink.ID + "();");
        PrmLblScript.Text = PrmLblScript.Text + strScript;
        //Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        //ScriptManager.RegisterClientScriptBlock(objPage, typeof(ClsPageEvents), "Msg", strScript, false);
    }
    public void FnGetPopUpWindowDispaly(string PrmHeader, LinkButton PrmLnkBtn, int PrmWidth, int PrmHeight, string PrmURL, Label PrmLblScript)
    {
        PrmLblScript.Text = "";
        string strScript = "<script type='text/javascript'>";
        strScript = strScript + "function FnPopUpDisplay" + PrmLnkBtn.ID + "(){var ReportWinEdit" + PrmLnkBtn.ID + "=dhtmlwindow.open('ReportWindowEdit" + PrmLnkBtn.ID + "', 'iframe', '" + PrmURL + "', '" + PrmHeader + "', 'width=" + PrmWidth.ToString() + "px,height=" + PrmHeight.ToString() + "px,resize=0,scrolling=0,center=1', 'recal');}";
        strScript = strScript + "</script>";
        PrmLblScript.Text = strScript;
        PrmLnkBtn.Attributes.Add("onClick", "return FnPopUpDisplay" + PrmLnkBtn.ID + "();");
        //Page objPage = (HttpContext.Current.CurrentHandler) as Page;
        //ScriptManager.RegisterClientScriptBlock(objPage, typeof(ClsPageEvents), "Msg", strScript, false);
    }
    //=================== GRID LIST FUNCTION
    public string FnCombineString(string PrmStr1, string PrmStr2)
    {
        return PrmStr1.Trim() + " " + PrmStr2.Trim();
    }
    public string FnGetSubString(object PrmVal)
    {
        return (PrmVal.ToString().Trim().Length > 19 ? PrmVal.ToString().Trim().Substring(0, 20) + "...." : PrmVal.ToString());
    }
    public string FnGetSubString(object PrmVal, int PrmLength)
    {
        return (PrmVal.ToString().Trim().Length > (PrmLength + 6) ? PrmVal.ToString().Trim().Substring(0, PrmLength) + "...." : PrmVal.ToString());
    }
    public string FnGetDateString(object PrmVal)
    {
        if (PrmVal.ToString().Trim().Length > 0)
        {
            _strDateVal = (Convert.ToDateTime(PrmVal).ToString("dd/MMM/yyyy") == "01/Jan/1800" ? "" : Convert.ToDateTime(PrmVal).ToString("dd/MMM/yyyy"));
        }
        return _strDateVal;
    }
}
//string str = "";
// foreach (Control objPar in Form.FindControl("ContentPlaceHolder1").Controls )
// {
//     str = objPar.ClientID.ToString();
// }

 //Dim fcName As IFooterCommand = CType(Form.FindControl("ContentPlaceHolder1").FindControl("CtrlFooterCommand"), IFooterCommand) ctl00_ContentPlaceHolder1_CtrlCommand1
//ICommnadInterFace _CtrlCmnd = (ICommnadInterFace)Form.FindControl("ContentPlaceHolder1").FindControl("CtrlCommand");
//_CtrlCmnd.SaveText = "Save";
//_CtrlCmnd.SaveToolTip = "Save";
//_CtrlCmnd.SaveCommandArgument = "NEW";