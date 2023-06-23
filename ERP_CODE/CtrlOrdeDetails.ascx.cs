using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CtrlOrdeDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClsCommonVariables ObjCls = new ClsCommonVariables();

            BtnPrdSrch.UseSubmitBehavior = false;
            TxtOrderNo.Attributes.Add("autocomplete", "off");
            TxtCustName.Attributes.Add("autocomplete", "off");
            TxtCustCode.Attributes.Add("autocomplete", "off");
            TxtCustAdd.Attributes.Add("autocomplete", "off");
            TxtDueDate.Attributes.Add("autocomplete", "off");
            TxtFunction.Attributes.Add("autocomplete", "off");
            TxtPriority.Attributes.Add("autocomplete", "off");
            TxtFabType.Attributes.Add("autocomplete", "off");
            TxtDescription.Attributes.Add("autocomplete", "off");
            TxtDesigner.Attributes.Add("autocomplete", "off");
            TxtWrkStatus.Attributes.Add("autocomplete", "off");

            TxtOrderNo.Attributes.Add("onkeyup", "return FnFocusControl(event,'" + BtnPrdSrch.ClientID + "');");
            string strDestCtrl = HdnAutoId.ClientID + "," + HdnTokenNo.ClientID + "," + TxtCustName.ClientID + "," + TxtCustCode.ClientID + "," + TxtCustAdd.ClientID + "," + TxtDueDate.ClientID + "," + TxtDesigner.ClientID + "," + TxtPriority.ClientID + "," + TxtFunction.ClientID + "," + TxtFabType.ClientID + "," + TxtDescription.ClientID + "," + TxtWrkStatus.ClientID + "," + HdnCurStatus.ClientID + "," + LblError.ClientID + "," + HdnUnitBranchId.ClientID + "," + TxtUnit.ClientID + "," + TxtWork.ClientID + "," + HdnWorkPlan.ClientID + "," + HdnQcId.ClientID;
            BtnPrdSrch.Attributes.Add("onclick", "javascript:return FnGetShopeOrderItemDetails('" + ObjCls.DecryptQueryString(Request.QueryString["CID"].ToString()) + "','" + ObjCls.DecryptQueryString(Request.QueryString["BID"].ToString()) + "','" + TxtOrderNo.ClientID + "','" + strDestCtrl + "');");
            TxtOrderNo.Focus();
        } 
    }
    public Button ButtonSearchCtrl
    {
        get
        { return BtnPrdSrch; }
    }
    public HiddenField HdnAutoIdCtrl
    {
        get
        { return HdnAutoId; }
    }
    public HiddenField HdnTokenNoCtrl
    {
        get
        { return HdnTokenNo; }
    }
    public HiddenField HdnUnitBranchIdCtrl
    {
        get
        { return HdnUnitBranchId ; }
    }
    public TextBox TxtOrderNoCtrl
    {
        get
        { return TxtOrderNo; }
    }
    public TextBox TxtCustNameCtrl
    {
        get
        { return TxtCustName; }
    }
    public TextBox TxtCustCodeCtrl
    {
        get
        { return TxtCustCode; }
    }
    public TextBox TxtCustAddCtrl
    {
        get
        { return TxtCustAdd; }
    }
    public TextBox TxtDueDateCtrl
    {
        get
        { return TxtDueDate; }
    }
    public TextBox TxtFunctionCtrl
    {
        get
        { return TxtFunction; }
    }
    public TextBox TxtPriorityCtrl
    {
        get
        { return TxtPriority; }
    }
    public TextBox TxtFabTypeCtrl
    {
        get
        { return TxtFabType; }
    }
    public TextBox TxtDescriptionCtrl
    {
        get
        { return TxtDescription; }
    }
    public TextBox TxtDesignerCtrl
    {
        get
        { return TxtDesigner ; }
    }
    public TextBox TxtWrkStatusCtrl
    {
        get
        { return TxtWrkStatus; }
    }
    public TextBox TxtWorkCtrl
    {
        get
        { return TxtWork; }
    }
    public HiddenField HdnCurStatusCtrl
    {
        get
        { return HdnCurStatus; }
    }
    public HiddenField HdnWorkPlanCtrl
    {
        get
        { return HdnWorkPlan; }
    }
    public HiddenField HdnQcEmpCtrl
    {
        get
        { return HdnQcId; }
    }
    public void FnClearAllCtrls()
    {
        LblError.Text = "";
        HdnAutoId.Value = "";
        TxtOrderNo.Text = "";
        HdnTokenNo.Value = "";
        TxtCustName.Text = "";
        TxtCustCode.Text = "";
        TxtCustAdd.Text = "";
        TxtDueDate.Text = "";
        TxtPriority.Text = "";
        TxtFunction.Text = "";
        TxtFabType.Text = "";
        TxtDescription.Text = "";
        TxtDesigner.Text = "";
        TxtWrkStatus.Text = "";
        TxtWork.Text = "";
        TxtUnit.Text = "";
        HdnWorkPlan.Value = "0";
        HdnCurStatus.Value = "";
    }
}