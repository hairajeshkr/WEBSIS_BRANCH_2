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
using System.IO;
using System.Drawing;
public partial class MenuSettings : ClsPageEvents, IPageInterFace
{
    ClsMenuSettings ObjCls = new ClsMenuSettings();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                ObjLst.CompanyId = FnGetRights().COMPANYID;
                ObjLst.FnGetUserGroupList(DdlUsrGrp, "");
                DataView dWList = new DataView(ObjCls.FnConvertStringToDataTable(ObjCls.FnGetMenuXmlList()));
                dWList.RowFilter = " nParentId>0";
                ViewState["DT"] = dWList.ToTable();
                FnGridViewBinding("");
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    #region IPageInterFace Members
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.UserGrpId = ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString());
        ObjCls.UserId = 0;
        ObjCls.Remarks = FnGetCheckedMenuList();

        ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }
    private string FnGetCheckedMenuList()
    {
        int iCnt = 0, iIsBlck = 0;
        string strMenuList = "";

        HiddenField HdnMenuId;
        CheckBox ChkCreate, ChkModify, ChkDelete, ChkPrint;
        for (int iRw = 0; iRw <= GrdVwRecords.Rows.Count - 1; iRw++)
        {
            HdnMenuId = (HiddenField)GrdVwRecords.Rows[iRw].FindControl("HdnMenuId");
            ChkCreate = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkCreate");
            ChkModify = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkModify");
            ChkDelete = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkDelete");
            ChkPrint = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkPrint");

            if (ChkCreate.Checked == true || ChkModify.Checked == true || ChkDelete.Checked == true || ChkPrint.Checked == true)
            {
                if (iCnt.Equals(0))
                {
                    strMenuList = strMenuList + " SELECT " + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0," + ObjCls.FnIsNumeric(HdnMenuId.Value.ToString()) + "," + (ChkCreate.Checked == true ? 1 : 0) + "," + (ChkDelete.Checked == true ? 1 : 0) + "," + (ChkModify.Checked == true ? 1 : 0) + "," + (ChkPrint.Checked == true ? 1 : 0) + ",1,1,0,0,0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    iCnt = iCnt + 1;
                }
                else
                {
                    strMenuList = strMenuList + " UNION ALL SELECT " + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0," + ObjCls.FnIsNumeric(HdnMenuId.Value.ToString()) + "," + (ChkCreate.Checked == true ? 1 : 0) + "," + (ChkDelete.Checked == true ? 1 : 0) + "," + (ChkModify.Checked == true ? 1 : 0) + "," + (ChkPrint.Checked == true ? 1 : 0) + ",1,1,0,0,0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    iCnt = iCnt + 1;
                }
            }            
        }
        return strMenuList;
    }
    public override void FnCancel()
    {
        base.FnCancel();

        DdlUsrGrp.SelectedIndex = 0;
        CheckBox ChkCreate, ChkModify, ChkDelete, ChkPrint;
        for (int iRw = 0; iRw <= GrdVwRecords.Rows.Count - 1; iRw++)
        {
            ChkCreate = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkCreate");
            ChkModify = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkModify");
            ChkDelete = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkDelete");
            ChkPrint = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkPrint");

            ChkCreate.Checked = false;
            ChkModify.Checked = false;
            ChkDelete.Checked = false;
            ChkPrint.Checked = false;
        }
        ChkActive.Checked = true;
        GrdVwRecords.SelectedIndex = -1;

        CtrlCommand.SaveText = "Save";
        CtrlCommand.SaveCommandArgument = "NEW";
        FnFocus(DdlUsrGrp);
    }
    public void FnClose()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void FnClearItems(string PrmFlag)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public void FnFindRecord()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        return 1;
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource =ViewState["DT"] as DataTable ;
        //GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;
    }
    public override void FnInitializeForm()
    {
    }
    public void FnPrintRecord()
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            if (ObjCls.Remarks.Trim().Length > 0)
                            {
                                base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            }
                            else
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage("Invalid menu configuration"));
                            }
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    FnCancel();
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnCancel();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "CLOSE":
                    ObjCls.FnAlertMessage(" You Have No permission To Close Record");
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "FIND":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    FnGridViewBinding("");
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;
                case "FIRST":
                    //========Code
                    break;
                case "PREVIOUS":
                    //========Code
                    break;
                case "NEXT":
                    //========Code
                    break;
                case "LAST":
                    //========Code
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    #endregion
    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            ChkActive.Checked = ObjCls.Active;
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();

            CtrlCommand.SaveText = "Update";
            CtrlCommand.SaveCommandArgument = "UPDATE";
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblName = (Label)e.Row.FindControl("lblName");
                Label LblNam = (Label)e.Row.FindControl("LblNam");

                CheckBox ChkCreate = (CheckBox)e.Row.FindControl("ChkCreate");
                CheckBox ChkModify = (CheckBox)e.Row.FindControl("ChkModify");
                CheckBox ChkDelete = (CheckBox)e.Row.FindControl("ChkDelete");
                CheckBox ChkPrint = (CheckBox)e.Row.FindControl("ChkPrint");

                int _iId = ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "nMenuId"));
                int _iPrentId = ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "nParentId"));
                bool bVal = ObjCls.FnIsBoolean(DataBinder.Eval(e.Row.DataItem, "nIsParent"));
                bool bSubVal = ObjCls.FnIsBoolean(DataBinder.Eval(e.Row.DataItem, "nIsSubParent"));
                string strType = DataBinder.Eval(e.Row.DataItem, "cTType").ToString();

                lblName.Visible = (bVal == true ? false : true);
                LblNam.Visible = (bVal == true ? true : false);
                if (bVal == true || bSubVal == true)
                {
                    ChkCreate.Attributes.Add("onclick", "return FnCheckAll('" + GrdVwRecords.ClientID + "','" + e.Row.RowIndex.ToString() + "','" + _iId.ToString() + "','" + ChkCreate.ClientID + "','" + _iPrentId.ToString() + "','_ChkCreate')");
                    ChkModify.Attributes.Add("onclick", "return FnCheckAll('" + GrdVwRecords.ClientID + "','" + e.Row.RowIndex.ToString() + "','" + _iId.ToString() + "','" + ChkModify.ClientID + "','" + _iPrentId.ToString() + "','_ChkModify')");
                    ChkDelete.Attributes.Add("onclick", "return FnCheckAll('" + GrdVwRecords.ClientID + "','" + e.Row.RowIndex.ToString() + "','" + _iId.ToString() + "','" + ChkDelete.ClientID + "','" + _iPrentId.ToString() + "','_ChkDelete')");
                    ChkPrint.Attributes.Add("onclick", "return FnCheckAll('" + GrdVwRecords.ClientID + "','" + e.Row.RowIndex.ToString() + "','" + _iId.ToString() + "','" + ChkPrint.ClientID + "','" + _iPrentId.ToString() + "','_ChkPrint')");

                    e.Row.BackColor = (bSubVal == true ? System.Drawing.Color.Moccasin : System.Drawing.Color.BurlyWood);
                }
                else
                {
                    ChkCreate.Attributes.Add("onclick", "return FnCheckParent('" + GrdVwRecords.ClientID + "','" + ChkCreate.ClientID + "','" + _iPrentId.ToString() + "','_ChkCreate')");
                    ChkModify.Attributes.Add("onclick", "return FnCheckParent('" + GrdVwRecords.ClientID + "','" + ChkModify.ClientID + "','" + _iPrentId.ToString() + "','_ChkModify')");
                    ChkDelete.Attributes.Add("onclick", "return FnCheckParent('" + GrdVwRecords.ClientID + "','" + ChkDelete.ClientID + "','" + _iPrentId.ToString() + "','_ChkDelete')");
                    ChkPrint.Attributes.Add("onclick", "return FnCheckParent('" + GrdVwRecords.ClientID + "','" + ChkPrint.ClientID + "','" + _iPrentId.ToString() + "','_ChkPrint')");
                }
                if (strType.Equals("OUT"))
                {
                    ChkCreate.Enabled = false;// (strType.Equals("OUT") ? false : true);
                    ChkModify.Enabled = false;// (strType.Equals("OUT") ? false : true);
                    ChkDelete.Enabled = false;// (strType.Equals("OUT") ? false : true);
                    ChkPrint.Enabled = false;// (strType.Equals("OUT") ? false : true);

                    ChkCreate.Checked = true;// (strType.Equals("OUT") ? true : false);
                    ChkModify.Checked = true;// (strType.Equals("OUT") ? true : false);
                    ChkDelete.Checked = true;// (strType.Equals("OUT") ? true : false);
                    ChkPrint.Checked = true;// (strType.Equals("OUT") ? true : false);
                }
                else
                {
                    ChkCreate.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "IsCreate")).Equals(1) ? true : false);
                    ChkModify.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "IsUpdate")).Equals(1) ? true : false);
                    ChkDelete.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "IsDelete")).Equals(1) ? true : false);
                    ChkPrint.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "IsPrint")).Equals(1) ? true : false);
                }
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    protected void DdlUsrGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FnAssignProperty();
            DataSet dsVal= FnFindDataSetRecord(ObjCls);
            DataView dWList = new DataView(ObjCls.FnConvertStringToDataTable(ObjCls.FnGetMenuXmlList(dsVal)));
            dWList.RowFilter = " nParentId>0";
            ViewState["DT"] = dWList.ToTable();
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
}
