using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Text;
using System.Data;

[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Web_GridSelection : System.Web.Services.WebService
{
    string _Results = "", _PageResults = "";
    ClsWebServiceRecordList ObjCls = new ClsWebServiceRecordList();
    DataTable dtList;
    public Web_GridSelection()
    { 
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public string[] PopulateGrid(string PrmFlag, string PrmCmpId, string PrmBrId, string PrmFaId, string PrmUserId, string PrmName, string PrmCtrlId, string PrmParentId, string PrmSubParentId, int rowCount, int pageNo, string PrmDestCtrls)
    {
        ObjCls.CompanyId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmCmpId));
        ObjCls.BranchId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmBrId));
        ObjCls.FaId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmFaId));
        ObjCls.UserId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmUserId));
        ObjCls.UpdateDate = DateTime.Now;
        ObjCls.ControlId = PrmCtrlId.Trim();
        ObjCls.ParentId = ObjCls.FnIsNumeric(PrmParentId);
        ObjCls.ID = ObjCls.FnIsNumeric(PrmSubParentId);

        ObjCls.Name = PrmName.Trim();

        if (PrmFlag.Equals("USRGRP") || PrmFlag.Equals("ACCGRP") || PrmFlag.Equals("CN") || PrmFlag.Equals("ST") || PrmFlag.Equals("DI") || PrmFlag.Equals("LOC")
                                    || PrmFlag.Equals("EMP") || PrmFlag.Equals("ITM") || PrmFlag.Equals("UOM") || PrmFlag.Equals("PUA") || PrmFlag.Equals("SLA")
                                    || PrmFlag.Equals("ACC") || PrmFlag.Equals("ACCREG") || PrmFlag.Equals("GRD") || PrmFlag.Equals("ITMGRP") || PrmFlag.Equals("TAX") 
                                    || PrmFlag.Equals("TDS") || PrmFlag.Equals("CR") || PrmFlag.Equals("CP") || PrmFlag.Equals("JR") || PrmFlag.Equals("BNK") 
                                    || PrmFlag.Equals("CSH") || PrmFlag.Equals("AGNT") || PrmFlag.Equals("ALCN") || PrmFlag.Equals("BSR") || PrmFlag.Equals("SLR") 
                                    || PrmFlag.Equals("PAY") || PrmFlag.Equals("HELTH") || PrmFlag.Equals("BLDTLS") || PrmFlag.Equals("BRAND")
                                    || PrmFlag.Equals("BSLST") || PrmFlag.Equals("PASPORT") || PrmFlag.Equals("BANKNO") || PrmFlag.Equals("STDCAT")
                                    || PrmFlag.Equals("QUAL") || PrmFlag.Equals("DESG") || PrmFlag.Equals("HRS") || PrmFlag.Equals("VCHNO") || PrmFlag.Equals("STDNT")
                                    || PrmFlag.Equals("GWN") || PrmFlag.Equals("BATCHNO") || PrmFlag.Equals("MOBACC") || PrmFlag.Equals("MENU") || PrmFlag.Equals("PMENU")
                                    || PrmFlag.Equals("INVADD") || PrmFlag.Equals("ORDADD") || PrmFlag.Equals("CUST_GRP") || PrmFlag.Equals("SUP_GRP")
                                    || PrmFlag.Equals("RACK")   || PrmFlag.Equals("EMAIL") || PrmFlag.Equals("PHONENO") || PrmFlag.Equals("FACEBOOK") 
                                    || PrmFlag.Equals("FAMILYNAME") || PrmFlag.Equals("PLACE") || PrmFlag.Equals("WHATSAPP") || PrmFlag.Equals("HOUSENAME") || PrmFlag.Equals("MOBILENO")
                                    || PrmFlag.Equals("SHOPECUST") || PrmFlag.Equals("WPGRP") || PrmFlag.Equals("SUBGRD") || PrmFlag.Equals("ITMACC")
                                    || PrmFlag.Equals("PLCB") || PrmFlag.Equals("RELGN") || PrmFlag.Equals("TSKGRP") || PrmFlag.Equals("CLS")
                                    || PrmFlag.Equals("STDCOM") || PrmFlag.Equals("ITMZERO") || PrmFlag.Equals("LANG") || PrmFlag.Equals("DIVN") 
                                    || PrmFlag.Equals("CUTYPE") || PrmFlag.Equals("CUSTHD") || PrmFlag.Equals("QUOTA"))
        {
            dtList = ObjCls.FnGetGeneralRecordList(PrmFlag); 
        }

        if (PrmFlag.Equals("ACC") || PrmFlag.Equals("ACCREG") || PrmFlag.Equals("CR") || PrmFlag.Equals("CP") || PrmFlag.Equals("JR") || PrmFlag.Equals("BNK") 
            || PrmFlag.Equals("CSH") || PrmFlag.Equals("BSR") || PrmFlag.Equals("SLR") || PrmFlag.Equals("BSLST") || PrmFlag.Equals("MEM") || PrmFlag.Equals("SHR") || PrmFlag.Equals("PCARD"))
        {
            _Results = FnGetGridAccountLedgerList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls);
        }
        else if (PrmFlag.Equals("EMP"))
        {
            _Results = FnGetGridStaffList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls);
        }
        else if (PrmFlag.Equals("MOBACC"))
        {
            _Results = FnGetGridMobAccountLedgerList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls);
        }
        else if (PrmFlag.Equals("BANKDT") || PrmFlag.Equals("HELTH") || PrmFlag.Equals("BLDTLS") || PrmFlag.Equals("BRAND") 
                                    || PrmFlag.Equals("PUA") || PrmFlag.Equals("SLA") || PrmFlag.Equals("LEGAL") || PrmFlag.Equals("CHQNO")
                                    || PrmFlag.Equals("PASPORT") || PrmFlag.Equals("BANKNO") || PrmFlag.Equals("QUAL") || PrmFlag.Equals("DESG")
                                    || PrmFlag.Equals("VCHNO") || PrmFlag.Equals("GWN") || PrmFlag.Equals("HOUSENAME") || PrmFlag.Equals("FAMILYNAME") 
                                    || PrmFlag.Equals("PLACE") || PrmFlag.Equals("WHATSAPP"))
        {
            _Results = FnGetGridGeneralSingleList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls);
        }
        else if (PrmFlag.Equals("ITM") || PrmFlag.Equals("ITMACC") || PrmFlag.Equals("ITMZERO"))
        {
            _Results = FnGetGridItemList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls, PrmFlag);
        }
        else if (PrmFlag.Equals("STDNT"))
        {
            _Results = FnGetGridStudentList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls, PrmFlag);
        }
        else if (PrmFlag.Equals("EMAIL") || PrmFlag.Equals("PHONENO") || PrmFlag.Equals("FACEBOOK") || PrmFlag.Equals("WHATSAPP") || PrmFlag.Equals("MOBILENO"))
        {
            _Results = FnGetGridCustomerGridList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls, PrmFlag);
        }
        else
        {
            _Results = FnGetGridGeneralList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls, PrmFlag);
        }

        _PageResults = (dtList.Rows.Count > 0 ? FnGetPager(dtList.Rows.Count, pageNo, rowCount, PrmCtrlId) : "");
        StringBuilder strResponse = new StringBuilder();
        strResponse.Append("<RESPONSE><VALUES><ERROR>False</ERROR><PAGER><![CDATA[");
        strResponse.Append(_PageResults);
        strResponse.Append("]]></PAGER><GRID><![CDATA[");
        strResponse.Append(_Results);
        strResponse.Append("]]></GRID></VALUES></RESPONSE>");
        string[] srcResult = new string[]
        {
            strResponse.ToString(),
            PrmCtrlId.ToString()
        };
        return srcResult;
    }
    public string FnReplaceString(string PrmValue)
    {
        string str = PrmValue.Trim();
        return HttpUtility.HtmlEncode(PrmValue).Replace("'", "\\'").Replace("\r\n", " ").Replace("\n", " "); 
        //return PrmValue.Replace("'", " ").Replace("\r\n", " ").Replace("\n", " ").Replace(@"""", "");
    }
    private string FnGetGridGeneralSingleList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '450px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Particular(s)</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");
                _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString() + "</a>";
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridGeneralList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl, string PrmFlag)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string strCtlr = PrmDestCtrl.Trim();
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '350px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Code.</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");

                if (PrmDestCtrl.Trim().Length > 0 && PrmFlag.Equals("ITM"))
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelecteItemListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["UomId"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["Uom"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["TaxId"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["Tax"].ToString()) + "','" + PrmDestCtrl + "');\">" + FnReplaceString(dv[i]["Name"].ToString()) + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString().Replace("'", " ") + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridItemList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl, string PrmFlag)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string strCtlr = PrmDestCtrl.Trim();
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '650px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Code</td>"
                                + "<td class='headercellCode'>HsnCode</td>"
                                + "<td class='headercellCode'>Uom</td>"
                                + "<td class='headercell'>ItemGroup</td>"
                                + "<td class='headercellDigit'>Stock</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");

                if (PrmDestCtrl.Trim().Length > 0)
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelecteItemListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["UomId"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["Uom"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["TaxId"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["Tax"].ToString()) + "','" + FnReplaceString(dv[i]["BarCode"].ToString()) + "','" + FnReplaceString(dv[i]["Mrp"].ToString()) + "','" + FnReplaceString(dv[i]["Code"].ToString()) + "','" + PrmDestCtrl + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString().Replace("'", " ") + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["HsnCode"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Uom"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["ItemGroup"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDigit'>");
                strResults.Append(dv[i]["CurrentStock"].ToString());
                strResults.Append("</td>");

                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridStudentList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl, string PrmFlag)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string strCtlr = PrmDestCtrl.Trim();
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '650px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Student Id</td>"
                                + "<td class='headercellCode'>Adm.No</td>"
                                + "<td class='headercellCode'>RegNo.</td>"
                                + "<td class='headercell'>Class</td>"
                                + "<td class='headercell'>Division</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");

                if (PrmDestCtrl.Trim().Length > 0)
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelecteItemListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["Code"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["AdmissionNo"].ToString()) + "','" + ObjCls.FnIsNumeric(dv[i]["RegNo"].ToString()).ToString() + "','" + FnReplaceString(dv[i]["ClassId"].ToString()) + "','" + FnReplaceString(dv[i]["ClassName"].ToString()) + "','" + FnReplaceString(dv[i]["DivisionId"].ToString()) + "','" + FnReplaceString(dv[i]["DivisionName"].ToString()) + "','" + PrmDestCtrl + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString().Replace("'", " ") + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["AdmissionNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["RegNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["ClassName"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["DivisionName"].ToString());
                strResults.Append("</td>");

                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridAccountLedgerList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '1000px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Code.</td>"
                                + "<td class='headercellDigit'>Balance</td>"
                                + "<td class='headercell'>Account Group</td>"
                                + "<td class='headercell'>GstNo.</td>"
                                + "<td class='headercell'>Address</td>"
                                + "<td class='headercell'>MobNo.</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");
                if (PrmDestCtrl.Trim().Length > 0)
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedAccountListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + FnReplaceString(dv[i]["PAddress"].ToString()) + "','" + dv[i]["Bal"].ToString() + "','" + PrmDestCtrl + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDigit'>");
                strResults.Append(dv[i]["Bal"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["AccountGrp"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["GstNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["PAddress"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["MobNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridStaffList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '1000px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Code.</td>"
                                + "<td class='headercell'>Designation</td>"
                                + "<td class='headercell'>Address</td>"
                                + "<td class='headercell'>MobNo.</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");
                if (PrmDestCtrl.Trim().Length > 0)
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedAccountListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + FnReplaceString(dv[i]["PAddress"].ToString()) + "','" + dv[i]["Bal"].ToString() + "','" + PrmDestCtrl + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["Designation"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["PAddress"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["MobNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetPager(int intRowCount, int intPageNo, int intRowsPerPage, string PrmCtrlId)
    {
        StringBuilder strResults = new StringBuilder();
        int intPageCount;
        double dblPageCount;
        dblPageCount = ObjCls.FnIsDouble(intRowCount) / ObjCls.FnIsDouble(intRowsPerPage);
        intPageCount = ObjCls.FnIsNumeric(Math.Ceiling(dblPageCount));
        if (intPageNo > intPageCount || intPageNo < 1)
        {
            intPageNo = 1;
        }
        int intPageSet = 1;
        int intStartPage, intEndPage, intPagesPerSet;
        intPagesPerSet = 10;
        intStartPage = ((intPageSet - 1) * intPagesPerSet) + 1;
        intEndPage = intPageSet * intPagesPerSet;
        if (intEndPage > intPageCount)
        {
            intEndPage = intPageCount;
        }
        if (intPageSet > 1)
        {
            strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCall(");
            strResults.Append(intStartPage - intPagesPerSet);
            strResults.Append(", ");
            strResults.Append(intPageSet - 1);

            strResults.Append(",");
            strResults.Append("'" + PrmCtrlId + "'");

            strResults.Append(")\" class='Grdpager'><<<</a>");
        }
        for (int k = 1; k <= intPageCount; k++)
        {
            if (k == intPageNo)
            {
                strResults.Append("<span class='Grdpager'>");
                strResults.Append(k);
                strResults.Append("</span>");
            }
            else
            {
                strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCall(");
                strResults.Append(k);

                strResults.Append(",");
                strResults.Append("'" + PrmCtrlId + "'");

                strResults.Append(")\" class='GrdpagerInActive'>");
                strResults.Append(k);
                strResults.Append("</a>");
                string str = strResults.ToString();
            }
            strResults.Append("");
        }
        if (intPageCount > intEndPage)
        {
            strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCall(");
            strResults.Append(intEndPage + 1);
            strResults.Append(", ");
            strResults.Append(intPageSet + 1);

            strResults.Append(",");
            strResults.Append("'" + PrmCtrlId + "'");

            strResults.Append(")\" class='Grdpager'>>>></a>");
        }
        return strResults.ToString();
    }
    private string FnGetGridMobAccountLedgerList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '1000px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>Mob No.</td>"
                                + "<td class='headercell'>Name</td>"
                                + "<td class='headercellCode'>Code.</td>"
                                +"<td class='headercellDigit'>Balance</td>"
                                + "<td class='headercell'>Account Group</td>"
                                + "<td class='headercell'>GstNo</td>"
                                + "<td class='headercell'>Address</td></tr>");
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                strResults.Append("<td class = 'rowcell'>");
                if (PrmDestCtrl.Trim().Length > 0)
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedAccountListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["MobNo"].ToString()) + "','" + FnReplaceString(dv[i]["PAddress"].ToString()) + "','" + dv[i]["Bal"].ToString() + "','" + PrmDestCtrl + "');\">" + dv[i]["MobNo"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["MobNo"].ToString()) + "');\">" + dv[i]["MobNo"].ToString() + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["Name"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDigit'>");
                strResults.Append(dv[i]["Bal"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["AccountGrp"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["GstNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["PAddress"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["MobNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
    private string FnGetGridCustomerGridList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl, string PrmFlag)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string strCtlr = PrmDestCtrl.Trim();
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '600px'>");
            if (PrmFlag.Equals("SHOPECUST"))
            {
                strResults.Append("<tr class='header'>"
                                       + "<td class='headercell'>Particular</td>"
                                       + "<td class='headercellCode'>Code</td></tr>");
            }
            else
            {
                strResults.Append("<tr class='header'>"
                                    + "<td class='headercell'>Particular</td>"
                                    + "<td class='headercell'>Customer Name</td>"
                                    + "<td class='headercellCode'>Code</td></tr>");
            }
            int intStartIndex, intEndIndex, intRowCount;
            intRowCount = dv.Count;
            intStartIndex = ((intPageNo - 1) * intRowsPerPage);
            intEndIndex = (intStartIndex + intRowsPerPage) - 1;
            if (intRowCount <= intEndIndex)
            {
                intEndIndex = intRowCount - 1;
            }
            for (int i = intStartIndex; i <= intEndIndex; i++)
            {
                if (i % 2 == 0)
                {
                    strResults.Append("<tr class = 'rowstyle'>");
                }
                else
                {
                    strResults.Append("<tr class = 'alternatingrowstyle'>");
                }
                if (PrmFlag.Equals("SHOPECUST"))
                {
                    strResults.Append("<td class = 'rowcell'>");
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString().Replace("'", " ") + "</a>";
                    strResults.Append(_strName);
                    strResults.Append("</td>");
                }
                else
                {
                    strResults.Append("<td class = 'rowcell'>");
                    _strName = "<a href='#' onClick=\"return FnGetSelectedGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Particular"].ToString()) + "');\">" + dv[i]["Particular"].ToString().Replace("'", " ") + "</a>";
                    strResults.Append(_strName);
                    strResults.Append("</td>");
                    strResults.Append("<td class = 'rowcell'>");
                    strResults.Append(dv[i]["Name"].ToString());
                    strResults.Append("</td>");
                }
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("</tr>");
            }
            strResults.Append("</table>");
        }
        else
        {
            strResults.Append("");
            //strResults.Append("<table border='0'cellpadding='0' cellspacing='0' style='width: 100%'><tr><td align='center' colspan='3' valign='middle'><span style='color: #990000'><strong>Invalid Searching</strong></span></td></tr></table>");
        }
        return strResults.ToString();
    }
}

