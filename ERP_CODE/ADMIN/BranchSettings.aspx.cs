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
public partial class BranchSettings : ClsPageEvents, IPageInterFace
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
                ObjLst.FnGetUserList(DdlUsrGrp, "");
                if (FnGetRights().TTYPE.Equals("USRBR"))
                {
                    ViewState["DT"] = ObjCls.FnGetBranchFaYearList() as DataTable;
                }
               /* if (FnGetRights().TTYPE.Equals("USRCMP"))
                {
                    ViewState["DT"] = ObjCls.FnGetCompanyFaYearList() as DataTable;
                }*/
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
        ObjCls.Remarks = FnGetCheckedMenuList();

        ObjCls.Active = (ChkActive.Checked == true ? true : false);
    }
    private string FnGetCheckedMenuList()
    {
        int iCnt = 0, iIsBlck = 0;
        string strMenuList = "";

        HiddenField HdnId, HdnTType;
        CheckBox ChkCreate, ChkIsBlck;
        for (int iRw = 0; iRw <= GrdVwRecords.Rows.Count - 1; iRw++)
        {
            HdnId = (HiddenField)GrdVwRecords.Rows[iRw].FindControl("HdnId");
            HdnTType = (HiddenField)GrdVwRecords.Rows[iRw].FindControl("HdnTType");
            ChkCreate = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkCreate");
            ChkIsBlck = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkIsBlck");
            iIsBlck = (ChkIsBlck.Checked == true ? 1 : 0);
            if (ChkCreate.Checked == true )
            {
                if (iCnt.Equals(0))
                {
                    if (HdnTType.Value.Equals("BRNH"))
                    {
                        strMenuList = strMenuList + " SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0," + FnGetRights().COMPANYID.ToString() + "," + ObjCls.FnIsNumeric(HdnId.Value) + ",0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
                    else if (HdnTType.Value.Equals("CMP"))
                    {
                        strMenuList = strMenuList + " SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0," + ObjCls.FnIsNumeric(HdnId.Value) + ",0,0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
                    else
                    {
                        strMenuList = strMenuList + " SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0,0,0," + ObjCls.FnIsNumeric(HdnId.Value) + ",'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
                    iCnt = iCnt + 1;
                }
                else
                {
                    if (HdnTType.Value.Equals("BRNH"))
                    {
                        strMenuList = strMenuList + " UNION ALL SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0," + FnGetRights().COMPANYID.ToString() + "," + ObjCls.FnIsNumeric(HdnId.Value) + ",0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
                    else if (HdnTType.Value.Equals("CMP"))
                    {
                        strMenuList = strMenuList + " UNION ALL SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0," + ObjCls.FnIsNumeric(HdnId.Value) + ",0,0,'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
                    else
                    {
                        strMenuList = strMenuList + " UNION ALL SELECT 0," + ObjCls.FnIsNumeric(DdlUsrGrp.SelectedValue.ToString()) + ",0,0,0,0,0,0,0,0,0," + ObjCls.FnIsNumeric(HdnId.Value) + ",'" + FnGetRights().TTYPE.ToString() + "','" + FnGetRights().USERID.ToString() + "',GETDATE(),1," + iIsBlck + ",0";
                    }
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
        CheckBox ChkCreate;
        for (int iRw = 0; iRw <= GrdVwRecords.Rows.Count - 1; iRw++)
        {
            ChkCreate = (CheckBox)GrdVwRecords.Rows[iRw].FindControl("ChkCreate");
           
            ChkCreate.Checked = false;
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
                                FnPopUpAlert(ObjCls.FnAlertMessage("Invalid Branch/Financial year configuration"));
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
                CheckBox ChkIsBlck = (CheckBox)e.Row.FindControl("ChkIsBlck");

                if (DataBinder.Eval(e.Row.DataItem, "TType").ToString().Equals("BRNH"))
                {
                    lblName.Visible = true;
                    LblNam.Visible = false;
                    ChkIsBlck.Visible = false;
                    ChkCreate.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "BranchId")) > 0 ? true : false);
                    ChkIsBlck.Checked = false;
                }
                else if (DataBinder.Eval(e.Row.DataItem, "TType").ToString().Equals("CMP"))
                {
                    lblName.Visible = true;
                    LblNam.Visible = false;
                    ChkIsBlck.Visible = false;
                    ChkCreate.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "CompanyId")) > 0 ? true : false);
                    ChkIsBlck.Checked = false;
                }
                else
                {
                    lblName.Visible = false;
                    LblNam.Visible = true;
                    ChkIsBlck.Visible = true;
                    ChkCreate.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "FaId")) > 0 ? true : false);
                    //ChkIsBlck.Checked = (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "IsBlock")) > 0 ? true : false);
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
            FnFindRecord(ObjCls);
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
}
