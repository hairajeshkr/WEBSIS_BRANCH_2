﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ADMIN_DocMaster : ClsPageEvents, IPageInterFace
{
    ClsGeneral ObjCls = new ClsGeneral();

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);

            if (!IsPostBack)
            {
                TxtPriority.Attributes.Add("onkeydown", "return NumbersOnly(event);");
                FnInitializeForm();
                //ObjCls = new ClsUser(objUserRights.COMPANYID, objUserRights.BRANCHID, objUserRights.FAYEARID);
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        //ObjCls = new ClsGeneral(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);

        ViewState["DT"] = FnGetGeneralTable(ObjCls);

        FnGridViewBinding("");

    }


    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = txtName.Text.Trim();
        //ObjCls.Code = Drpcode.SelectedItem.Text.ToString();
        //ObjCls.Code = ChkDtype.SelectedItem.Text.ToString();
        for(int i=0;i<ChkDtype.Items.Count;i++)
        {
            if (ChkDtype.Items[i].Selected)
                ObjCls.Code += ChkDtype.Items[i].Text.ToString()+",";
        }
        ObjCls.OrderIndex= ObjCls.FnIsNumeric(TxtPriority.Text.Trim());
        ObjCls.Remarks = TxtRemarks.Text.Trim();
        ObjCls.GrpId = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());

    }
    public override void FnCancel()
    {
        base.FnCancel();

        txtName.Text = "";
        TxtPriority.Text = "";
        TxtRemarks.Text = "";
        //ChkActive.Checked = true;



        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        //FnFocus(TxtName);
    }


    public void FnClose()
    {
        throw new NotImplementedException();
    }

    public void FnFindRecord()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.Name = TxtName_Srch.Text.Trim();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");
        TabContainer1.ActiveTabIndex = 1;
    }

    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }

    public void FnGridViewBinding(string PrmFlag)
    {
        GrdVwRecords.DataSource = ViewState["DT"] as DataTable;
        GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        GrdVwRecords.DataBind();
        GrdVwRecords.SelectedIndex = -1;
    }

    public void FnPrintRecord()
    {
        throw new NotImplementedException();
    }

    public void ManiPulateDataEvent_Clicked(object sender, EventArgs e)
    {
        try
        {
            switch (((Button)sender).CommandName.ToString().ToUpper())
            {
                case "SAVE":
                    if (txtName.Text.Trim().Length <= 0)
                    {
                        FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                        FnFocus(txtName);
                        return;
                    }

                    FnAssignProperty();
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                        case "UPDATE":
                            base.ManiPulateDataEvent_Clicked(((Button)sender).CommandArgument.ToString().ToUpper(), ObjCls, false);
                            break;
                    }
                    break;
                case "DELETE":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
                case "CLEAR":
                    //FnPopUpAlert(ObjCls.FnReportWindow("SA.HTML", "wELCOME"));
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
                    FnFindRecord();
                    //FnAssignProperty();
                    //base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    //FnGridViewBinding("");
                    //System.Threading.Thread.Sleep(1000000);
                    break;
                case "HELP":
                    ObjCls.FnAlertMessage(" You Have No permission To Help Record");
                    break;

            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }

    }


    protected void GrdVwRecords_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
            ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
            ViewState["ID"] = ObjCls.ID.ToString();
            txtName.Text = ObjCls.Name.ToString();
            ChkDtype.SelectedValue = ObjCls.Code.ToString();
            //TxtCode.Text = ObjCls.Code.ToString();
            TxtPriority.Text = ObjCls.OrderIndex.ToString();
            TxtRemarks.Text = ObjCls.Remarks.ToString();
            ChkActive.Checked = ObjCls.Active;
            //ChkApprove.Checked = ObjCls.IsApprove;
            //ChkDtype.SelectedIndex=
            ViewState["DT_UPDATE"] = ObjCls.UpdateDate.ToString();
           


            CtrlCommand1.SaveText = "Update";
            CtrlCommand1.SaveCommandArgument = "UPDATE";

            TabContainer1.ActiveTabIndex = 0;

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    protected void GrdVwRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdVwRecords.PageIndex = e.NewPageIndex;
            FnGridViewBinding("");
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

}