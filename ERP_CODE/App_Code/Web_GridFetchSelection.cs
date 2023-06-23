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
public class Web_GridFetchSelection : System.Web.Services.WebService
{
    string _Results = "", _PageResults = "";
    ClsWebServiceRecordList ObjCls = new ClsWebServiceRecordList();
    DataTable dtList;
    public Web_GridFetchSelection()
    { 
    }

    [WebMethod]
    public string[] PopulateFetchGrid(string PrmFlag, string PrmCmpId, string PrmBrId, string PrmFaId, string PrmUserId,string PrmName, string PrmCtrlId,string PrmParentId,int rowCount, int pageNo,string PrmDestCtrls)
    {
        ObjCls.CompanyId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmCmpId));
        ObjCls.BranchId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmBrId));
        ObjCls.FaId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmFaId));
        ObjCls.UserId = ObjCls.FnIsNumeric(ObjCls.DecryptQueryString(PrmUserId));
        ObjCls.UpdateDate = DateTime.Now;
        ObjCls.ControlId = PrmCtrlId.Trim();
        ObjCls.ParentId = ObjCls.FnIsNumeric(PrmParentId);

        ObjCls.Name = PrmName.Trim();

        if (PrmFlag.Equals("PO") || PrmFlag.Equals("POE") || PrmFlag.Equals("SO") || PrmFlag.Equals("SHP") || PrmFlag.Equals("SL") || PrmFlag.Equals("PI") || PrmFlag.Equals("PRQ") || PrmFlag.Equals("PPS") || PrmFlag.Equals("PDPS"))
        {
            dtList = ObjCls.FnGetGeneralFetchRecordList(PrmFlag);  
        }

        if (PrmFlag.Equals("PO") || PrmFlag.Equals("POE") || PrmFlag.Equals("SO") || PrmFlag.Equals("SHP") || PrmFlag.Equals("PI") || PrmFlag.Equals("PRQ") || PrmFlag.Equals("PPS") || PrmFlag.Equals("PDPS"))
        {
            _Results = FnGetGridGeneralList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId);
            //FnGetGridDetailedFetchList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId, PrmDestCtrls);
        }
        else if (PrmFlag.Equals("SL"))
        {
            _Results = FnGetGridInvoiceList(dtList.DefaultView, pageNo, rowCount, PrmCtrlId);
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
        return srcResult;// strResponse.ToString();
    }
    public string FnReplaceString(string PrmValue)
    {
        string str = PrmValue.Trim();
        return HttpUtility.HtmlEncode(PrmValue).Replace("'", "\\'").Replace("\r\n", " ").Replace("\n", " ");
        //return PrmValue.Replace("'", " ").Replace("\r\n", " ").Replace("\n", " ").Replace(@"""", "");
    }
    private string FnGetGridGeneralSingleList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId)
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
                _strName = "<a href='#' onClick=\"return FnGetSelectedFetchGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString() + "</a>";
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
    private string FnGetGridGeneralList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '250px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercellRefNo'>Ref No.</td>"
                                + "<td class='headercellDob'>Date.</td></tr>");
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
                strResults.Append("<td class = 'rowcellRefNo'>");
                _strName = "<a href='#' onClick=\"return FnGetSelectedFetchGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["RefNo"].ToString()) + "');\">" + dv[i]["RefNo"].ToString().Replace("'", " ") + "</a>";
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDob'>");
                strResults.Append(ObjCls.FnDateTime(dv[i]["TrDate"].ToString(), ""));
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
    private string FnGetGridInvoiceList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '500px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercellRefNo'>Ref No.</td>"
                                + "<td class='headercellDob'>Date.</td>"
                                + "<td class='headercellCode'>Bill Qty.</td>"
                                + "<td class='headercellCode'>Delivery Qty.</td>"
                                + "<td class='headercellCode'>Balance</td></tr>");
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
                strResults.Append("<td class = 'rowcellRefNo'>");
                _strName = "<a href='#' onClick=\"return FnGetSelectedFetchGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["RefNo"].ToString()) + "');\">" + dv[i]["RefNo"].ToString().Replace("'", " ") + "</a>";
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDob'>");
                strResults.Append(ObjCls.FnDateTime(dv[i]["TrDate"].ToString(), ""));
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Qty"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["ShpQty"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["BalQty"].ToString());
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
    private string FnGetGridDetailedFetchList(DataView dv, int intPageNo, int intRowsPerPage, string PrmCtrlId, string PrmDestCtrl)
    {
        StringBuilder strResults = new StringBuilder();
        if (dv.ToTable().Rows.Count > 0)
        {
            string _strName = "";
            strResults.Append(" <table id = 'tblContent' cellpadding = '0' cellspacing = '0'  width = '1000px'>");
            strResults.Append("<tr class='header'>"
                                + "<td class='headercell'>RefNo</td>"
                                + "<td class='headercellCode'>Date.</td>"
                                + "<td class='headercell'>Account Group</td>"
                                + "<td class='headercell'>TinNo</td>"
                                + "<td class='headercell'>Address</td>"
                                + "<td class='headercell'>MobNo.</td>"
                                + "<td class='headercellDigit'>Balance</td></tr>");
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
                    _strName = "<a href='#' onClick=\"return FnGetSelectedFetchDetailedListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "','" + FnReplaceString(dv[i]["PerAdd"].ToString()) + "','" + dv[i]["Bal"].ToString() + "','" + PrmDestCtrl + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                else
                {
                    _strName = "<a href='#' onClick=\"return FnGetSelectedFetchGeneralListValue('" + PrmCtrlId + "','" + dv[i]["Id"].ToString() + "','" + FnReplaceString(dv[i]["Name"].ToString()) + "');\">" + dv[i]["Name"].ToString() + "</a>";
                }
                strResults.Append(_strName);
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellCode'>");
                strResults.Append(dv[i]["Code"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["AccountGrp"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["TinNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["PerAdd"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcell'>");
                strResults.Append(dv[i]["MobNo"].ToString());
                strResults.Append("</td>");
                strResults.Append("<td class = 'rowcellDigit'>");
                strResults.Append(dv[i]["Bal"].ToString());
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
            strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCallFetch(");
            strResults.Append(intStartPage - intPagesPerSet);
            strResults.Append(", ");
            strResults.Append(intPageSet - 1);

            strResults.Append(",");
            strResults.Append("'" + PrmCtrlId + "'");

            strResults.Append(")\" class='pager'><<<</a>&nbsp;");
        }
        for (int k = 1; k <= intPageCount; k++)
        {
            if (k == intPageNo)
            {
                strResults.Append("<span class='pager'>");
                strResults.Append(k);
                strResults.Append("</span>");
            }
            else
            {
                strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCallFetch(");
                strResults.Append(k);

                strResults.Append(",");
                strResults.Append("'" + PrmCtrlId + "'");

                strResults.Append(")\" class='pager'>");
                strResults.Append(k);
                strResults.Append("</a>");
                string str = strResults.ToString();
            }
            strResults.Append("&nbsp;");
        }
        if (intPageCount > intEndPage)
        {
            strResults.Append("<a href = 'javascript:;' onclick = \"WebServiceCallFetch(");
            strResults.Append(intEndPage + 1);
            strResults.Append(", ");
            strResults.Append(intPageSet + 1);

            strResults.Append(",");
            strResults.Append("'" + PrmCtrlId + "'");

            strResults.Append(")\" class='pager'>>>></a>");
        }
        return strResults.ToString();
    }
}

