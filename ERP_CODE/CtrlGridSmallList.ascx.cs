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

public partial class CtrlGridSmallList : System.Web.UI.UserControl 
{
    int nGridWidth = 295, nGridHeight = 250, nGridRowCount = 25,nTextWidth=120;
    private string _StrPlaceHoldr = "", _strDestinationCtrl = "";
    private bool bIsVisibleSearch = true;
    public MenuType Type;
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
        CrRefNo,
        DrRefNo,
        ChequeNoList,
        BatchNoList,
        CessList,
        OfferNoList,
        AMCNameList,
        AmcSerialNoList,
        PendingSerialNoList,
        TemplateSubGroup,
        TemplateCategory,
        TemplateGroup,
        WhatsAppGroup,
        PurchaseBillNoList
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
            HdnFlag.Value = "STF";
        }
        else if (Type.ToString().Equals("AccountLedger"))
        {
            HdnFlag.Value = "ACC";
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
        else if (Type.ToString().Equals("CrRefNo"))
        {
            HdnFlag.Value = "CRREF";
        }
        else if (Type.ToString().Equals("DrRefNo"))
        {
            HdnFlag.Value = "DRREF";
        }
        else if (Type.ToString().Equals("ChequeNoList"))
        {
            HdnFlag.Value = "CHQNO";
        }
        else if (Type.ToString().Equals("BatchNoList"))
        {
            HdnFlag.Value = "BATCHNO";
        }
        else if (Type.ToString().Equals("CessList"))
        {
            HdnFlag.Value = "CESS";
        }
        else if (Type.ToString().Equals("OfferNoList"))
        {
            HdnFlag.Value = "OFFRNO";
        }
        else if (Type.ToString().Equals("AMCNameList"))
        {
            HdnFlag.Value = "AMCLST";
        }
        else if (Type.ToString().Equals("AmcSerialNoList"))
        {
            HdnFlag.Value = "AMCSRLNO";
        }
        else if (Type.ToString().Equals("PendingSerialNoList"))
        {
            HdnFlag.Value = "PNDSRLNO";
        }
        else if (Type.ToString().Equals("TemplateSubGroup"))
        {
            HdnFlag.Value = "TEMSUB";
        }
        else if (Type.ToString().Equals("TemplateCategory"))
        {
            HdnFlag.Value = "TEMCAT";
        }
        else if (Type.ToString().Equals("TemplateGroup"))
        {
            HdnFlag.Value = "TEMGRP";
        }
        else if (Type.ToString().Equals("WhatsAppGroup"))
        {
            HdnFlag.Value = "WPGRP";
        }
        else if (Type.ToString().Equals("PurchaseBillNoList"))
        {
            HdnFlag.Value = "PUBLST";
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
        TABLE1 .Visible = true;
        TABLE1.Width = GridWidht.ToString();
        TABLE1.Height = GridHeight.ToString();
        TxtCaption.Width = TextBoxWidth;
        hdnGridRowCount.Value = GridRowCount.ToString();
        devGridList.Style.Value = "overflow: scroll; width: " + Convert.ToString(GridWidht - 1) + "px; height: " + Convert.ToString(GridHeight - 1) + "px; position: static;";
        //HiddenAccType.Value = Type
        if (IsVisibleSearch == true)
        {
            DivLst.Attributes.Add("onchange", "toggleImgDiv('" + this.ClientID + "',event);");
            DivLst.Attributes.Add("onClick", "toggleImgDiv('" + this.ClientID + "',event);");
            TxtCaption.Attributes.Add("onkeyup", "txtOnChange('" + this.ClientID + "',event);");
        }
        else
        {
            ImgLst.Visible = false;
        }
        //TxtCaption.Attributes.Add("onblur", "FnOnHide('" + this.ClientID + "');");
        TxtCaption.Attributes.Add("placeholder", PlaceHoldr);
    }
    public bool IsVisibleSearch
    {
        get { return bIsVisibleSearch; }
        set { bIsVisibleSearch = value; }
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
    public string ParentControl
    {
        set
        {HdnParent.Value = value;}
    }
    public string TextControl
    {
        get
        { return TxtCaption.ClientID; }
    }
    public string IdControl
    {
        get
        {return HdnId.ClientID;}
    }
    public Boolean FnIsEnable
    {
        set
        { TxtCaption.Enabled = value; }
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
    public string ParentSubControl
    {
        set
        { HdnSubParent.Value = value; }
    }
}
