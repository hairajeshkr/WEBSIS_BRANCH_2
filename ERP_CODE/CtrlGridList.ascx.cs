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
using System.ComponentModel;

public partial class CtrlGridList : System.Web.UI.UserControl 
{
    int nGridWidth = 295, nGridHeight = 250, nGridRowCount = 25,nTextWidth=285;
    private string _StrPlaceHoldr = "", _strDestinationCtrl = "";
    public MenuType Type;
    private Boolean bIsMultiLine = false;
    public enum MenuType
    {
        UserGroup,
        AccountGroup,
        Country,
        State,
        District,
        Location,
        StaffList,
        ItemList,
        UomList,
        PackingList,
        GradeList,
        ItemGroupList,
        AccountLedger,
        AccountCrList,
        AccountDrList,
        AccountJrList,
        BankAccountList,
        CashAccountList,
        AllCountryList,
        TaxList,
        TdsList,
        AgentList,
        BuyerList,
        SellerList,
        PaymentTerms,
        Destination,
        DocumentRequired,
        BankDetails,
        CourierAdd,
        Health,
        Brand,
        PurchaseAccount,
        SalesAccount,
        AccountLedgerReg,
        BuyerSellerList,
        PassportNo,
        BankAccountNo,
        Qualification,
        Designation,
        Warehouse,
        MobWiseAccount,
        GroupItemList,
        Department,
        SupplierGroup,
        CustomerGroup,
        Email,
        PhoneNo,
        FaceBookProfile,
        FamilyName,
        WhatsAppNo,
        HouseName,
        MobileNo,
        ShopeCustomer,
        WhatsAppGroup,
        ItemAccList,
        RackList,
        TaskGroupList,
        ZeroTaxItemList,
        ReligionList,
        CommunityList,
        PlaceofBirth,
        CategoryList,
        LanguageList,
        ClassList,
        DivisionList,
        InstituteList
    }
    [DisplayName("Choose Model")]
    public MenuType AccountType
    {
        get
        {
            return Type;
        }
        set
        {
            Type = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        TxtCaption.Attributes.Add("autocomplete", "off");

        if (Type.ToString().Equals("UserGroup"))
        {
            HdnFlag.Value = "USRGRP";
        }
        else if (Type.ToString().Equals("PurchaseAccount"))
        {
            HdnFlag.Value = "PUA";
        }
        else if (Type.ToString().Equals("SalesAccount"))
        {
            HdnFlag.Value = "SLA";
        }
        else if (Type.ToString().Equals("AccountGroup"))
        {
            HdnFlag.Value = "ACCGRP";
        }
        else if (Type.ToString().Equals("Country"))
        {
            HdnFlag.Value = "CN";
        }
        else if (Type.ToString().Equals("State"))
        {
            HdnFlag.Value = "ST";
        }
        else if (Type.ToString().Equals("District"))
        {
            HdnFlag.Value = "DI";
        }
        else if (Type.ToString().Equals("Location"))
        {
            HdnFlag.Value = "LOC";
        }
        else if (Type.ToString().Equals("StaffList"))
        {
            HdnFlag.Value = "EMP";
        }
        else if (Type.ToString().Equals("AccountLedger"))
        {
            HdnFlag.Value = "ACC";
        }
        else if (Type.ToString().Equals("AccountLedgerReg"))
        {
            HdnFlag.Value = "ACCREG";
        }
        else if (Type.ToString().Equals("ItemList"))
        {
            HdnFlag.Value = "ITM";
        }  
        else if (Type.ToString().Equals("UomList"))
        {
            HdnFlag.Value = "UOM";
        }
        else if (Type.ToString().Equals("PackingList"))
        {
            HdnFlag.Value = "PCK";
        }
        else if (Type.ToString().Equals("GradeList"))
        {
            HdnFlag.Value = "GRD";
        }
        else if (Type.ToString().Equals("ItemGroupList"))
        {
            HdnFlag.Value = "ITMGRP";
        }
        else if (Type.ToString().Equals("AccountCrList"))
        {
            HdnFlag.Value = "CR";
        }
        else if (Type.ToString().Equals("AccountDrList"))
        {
            HdnFlag.Value = "CP";
        }
        else if (Type.ToString().Equals("AccountJrList"))
        {
            HdnFlag.Value = "JR";
        }
        else if (Type.ToString().Equals("BankAccountList"))
        {
            HdnFlag.Value = "BNK";
        }
        else if (Type.ToString().Equals("CashAccountList"))
        {
            HdnFlag.Value = "CSH";
        }
        else if (Type.ToString().Equals("AllCountryList"))
        {
            HdnFlag.Value = "ALCN";
        }
        else if (Type.ToString().Equals("TaxList"))
        {
            HdnFlag.Value = "TAX";
        }
        else if (Type.ToString().Equals("TdsList"))
        {
            HdnFlag.Value = "TDS";
        }
        else if (Type.ToString().Equals("AgentList"))
        {
            HdnFlag.Value = "AGNT";
        }
        else if (Type.ToString().Equals("SellerList"))
        {
            HdnFlag.Value = "SLR";
        }
        else if (Type.ToString().Equals("BuyerList"))
        {
            HdnFlag.Value = "BSR";
        }
        else if (Type.ToString().Equals("PaymentTerms"))
        {
            HdnFlag.Value = "PAY";
        }
        else if (Type.ToString().Equals("Destination"))
        {
            HdnFlag.Value = "DEST";
        }
        else if (Type.ToString().Equals("BankDetails"))
        {
            HdnFlag.Value = "BANKDT";
        }
        else if (Type.ToString().Equals("CourierAdd"))
        {
            HdnFlag.Value = "COURIR";
        }
        else if (Type.ToString().Equals("Health"))
        {
            HdnFlag.Value = "HELTH";
        }
        else if (Type.ToString().Equals("Brand"))
        {
            HdnFlag.Value = "BRND";
        }
        else if (Type.ToString().Equals("BuyerSellerList"))
        {
            HdnFlag.Value = "BSLST";
        }
        else if (Type.ToString().Equals("PassportNo"))
        {
            HdnFlag.Value = "PASPORT";
        }
        else if (Type.ToString().Equals("BankAccountNo"))
        {
            HdnFlag.Value = "BANKNO";
        }
        else if (Type.ToString().Equals("Qualification"))
        {
            HdnFlag.Value = "QUAL";
        }
        else if (Type.ToString().Equals("Designation"))
        {
            HdnFlag.Value = "DESG";
        }
        else if (Type.ToString().Equals("ContineerNo"))
        {
            HdnFlag.Value = "VCHNO";
        }
        else if (Type.ToString().Equals("Warehouse"))
        {
            HdnFlag.Value = "GWN";
        }
        else if (Type.ToString().Equals("BatchNoList"))
        {
            HdnFlag.Value = "BATCHNO";
        }
        else if (Type.ToString().Equals("MobWiseAccount"))
        {
            HdnFlag.Value = "MOBACC";
        }
        else if (Type.ToString().Equals("GroupItemList"))
        {
            HdnFlag.Value = "GRPITM";
        }
        else if (Type.ToString().Equals("Department"))
        {
            HdnFlag.Value = "DEPT";
        }
        else if (Type.ToString().Equals("ContactUser"))
        {
            HdnFlag.Value = "CUSTUSR";
        }
        else if (Type.ToString().Equals("CustomerGroup"))
        {
            HdnFlag.Value = "CUST_GRP";
        }
        else if (Type.ToString().Equals("SupplierGroup"))
        {
            HdnFlag.Value = "SUP_GRP";
        }
        else if (Type.ToString().Equals("Email"))
        {
            HdnFlag.Value = "EMAIL";
        }
        else if (Type.ToString().Equals("PhoneNo"))
        {
            HdnFlag.Value = "PHONENO";
        }
        else if (Type.ToString().Equals("FaceBookProfile"))
        {
            HdnFlag.Value = "FACEBOOK";
        }
        else if (Type.ToString().Equals("FamilyName"))
        {
            HdnFlag.Value = "FAMILYNAME";
        }
        else if (Type.ToString().Equals("Place"))
        {
            HdnFlag.Value = "PLACE";
        }
        else if (Type.ToString().Equals("WhatsAppNo"))
        {
            HdnFlag.Value = "WHATSAPP";
        }
        else if (Type.ToString().Equals("HouseName"))
        {
            HdnFlag.Value = "HOUSENAME";
        }
        else if (Type.ToString().Equals("MobileNo"))
        {
            HdnFlag.Value = "MOBILENO";
        }
        else if (Type.ToString().Equals("ShopeCustomer"))
        {
            HdnFlag.Value = "SHOPECUST";
        }
        else if (Type.ToString().Equals("WhatsAppGroup"))
        {
            HdnFlag.Value = "WPGRP";
        }
        else if (Type.ToString().Equals("ItemAccList"))
        {
            HdnFlag.Value = "ITMACC";
        }
        else if (Type.ToString().Equals("RackList"))
        {
            HdnFlag.Value = "RACK";
        }
        else if (Type.ToString().Equals("TaskGroupList"))
        {
            HdnFlag.Value = "TSKGRP";
        }
        else if (Type.ToString().Equals("BatchNoAllList"))
        {
            HdnFlag.Value = "BATCHNOALL";
        }
        else if (Type.ToString().Equals("ZeroTaxItemList"))
        {
            HdnFlag.Value = "ITMZERO";
        }
        else if (Type.ToString().Equals("ReligionList"))
        {
            HdnFlag.Value = "RELGN";
        }
        else if (Type.ToString().Equals("CategoryList"))
        {
            HdnFlag.Value = "STDCAT";
        }
        else if (Type.ToString().Equals("CommunityList"))
        {
            HdnFlag.Value = "STDCOM";
        }
        else if (Type.ToString().Equals("PlaceofBirth"))
        {
            HdnFlag.Value = "PLCB";
        }
        else if (Type.ToString().Equals("LanguageList"))
        {
            HdnFlag.Value = "LANG";
        }
        else if (Type.ToString().Equals("ClassList"))
        {
            HdnFlag.Value = "CLS";
        }
        else if (Type.ToString().Equals("DivisionList"))
        {
            HdnFlag.Value = "DIVN";
        }
        if (!IsPostBack)//
        {
            try
            {
                HdnCmpId.Value = Request.QueryString["CID"].ToString();
                HdnBrId.Value = Request.QueryString["BID"].ToString();
                HdnFaId.Value = Request.QueryString["FID"].ToString();
                HdnUserId.Value = Request.QueryString["UID"].ToString();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        if (IsMultiLineBox == true)
        {
            TxtCaption.TextMode = TextBoxMode.MultiLine;
            TxtCaption.CssClass = "textbox_Multilinefield_style";
        }
       

        TABLE1 .Visible = true;
        TABLE1.Width = GridWidht.ToString();
        TABLE1.Height = GridHeight.ToString();
 
        TxtCaption.Width = TextBoxWidth;
        hdnGridRowCount.Value = GridRowCount.ToString();
        devGridList.Style.Value = "overflow: scroll; width: " + Convert.ToString(GridWidht - 1) + "px; height: " + Convert.ToString(GridHeight - 1) + "px; position: static;";
        //HiddenAccType.Value = Type
        DivLst.Attributes.Add("onchange", "toggleImgDiv('" + this.ClientID  + "',event);");
        DivLst.Attributes.Add("onClick", "toggleImgDiv('" + this.ClientID + "',event);");
        TxtCaption.Attributes.Add("onkeyup", "txtOnChange('" + this.ClientID + "',event);");
        //TxtCaption.Attributes.Add("onblur", "FnOnHide('" + this.ClientID + "');");
        TxtCaption.Attributes.Add("placeholder", PlaceHoldr);
    }
    public string PlaceHoldr
    {
        get { return _StrPlaceHoldr ; }
        set { _StrPlaceHoldr = value; }
    }
    public int GridWidht
    {
        get { return nGridWidth; }
        set { nGridWidth = value; }
    }
    public Boolean IsMultiLineBox
    {
        get { return bIsMultiLine ; }
        set { bIsMultiLine = value; }
    }
    public int TextBoxWidth
    {
        get { return nTextWidth; }
        set { nTextWidth = value; }
    }
    public int GridHeight
    {
        get { return nGridHeight; }
        set { nGridHeight = value; }
    }
    public int GridRowCount
    {
        get { return nGridRowCount; }
        set { nGridRowCount = value; }
    }
    public short TabIndex
    {
        set
        {TxtCaption.TabIndex = value;}
    }
    public TextBox ControlTextBox
    {
        get
        {return TxtCaption;}
    }
    public string SelectedText
    {
        get
        {return TxtCaption.Text.Trim();}
        set
        {TxtCaption.Text = value;}
    }
    public string SelectedValue
    {
        get
        {return HdnId.Value.Trim();}
        set
        {HdnId.Value = value;}
    }
    public string SelectedCode
    {
        get
        { return HdnCode.Value.Trim(); }
        set
        { HdnCode.Value = value; }
    }
    public string ParentControl
    {
        set
        {HdnParent.Value = value;}
    }
    public string ParentSubControl
    {
        set
        { HdnSubParent.Value = value; }
    }
    public string IdControl
    {
        get
        {return HdnId.ClientID;}
    }
    public string TextControl
    {
        get
        { return TxtCaption.ClientID; }
    }
    public Boolean FnIsEnable
    {
        set
        { TxtCaption.Enabled = value; ImgLst.Visible = value; }
    }
    public Boolean IsCurrencySelect
    {
        set
        { HdnIsCurrency.Value = value.ToString(); }
    }
    public string UserIdCtrl
    {
        get
        { return HdnUserId.Value ; }
        set
        { HdnUserId.Value  = value; }
    }
    public string DestinationControls
    {
        get
        { return HdnDestCtrl.Value; }
        set
        { HdnDestCtrl.Value = value; }
    }
    protected void HdnSubParent_ValueChanged(object sender, EventArgs e)
    {

    }
}
