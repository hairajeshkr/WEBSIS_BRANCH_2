using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class FIN_FineSettings : ClsPageEvents, IPageInterFace
{
    ClsStudentAdmissionDetails ObjCls = new ClsStudentAdmissionDetails();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    ClsFeeMaster ObjCls1 = new ClsFeeMaster();
    static int icount = 0;
    TreeNode tnode;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {

            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //ChkSelect.Attributes.Add("onclick", "return GridChkSelectAll();");

                //ObjLst.FnGetUserAcYearList(DdlAcYear, "--- ACADEMIC YEAR ---");
                // ObjLst.FnGetLanguageList(DdlAcYear, "---Sort by Language---");
                
                FnInitializeForm();
                DrpInstallFill();

                /////Tree View
                DataTable ClsTD = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);

            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }
    public void DrpInstallFill()
    {
        DataTable ClsTD = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblFeeInstallmentMaster") as DataSet).Tables[0];
        DdlInslment.DataSource = ClsTD;
        DdlInslment.DataValueField = "nId";
        DdlInslment.DataTextField = "cName";
        DdlInslment.DataBind();
    }



    public void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode)
    {
        int VS;
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode tnode = new TreeNode
            {
                Text = row["Name"].ToString(),
                Value = row["ID"].ToString()
            };

            if (ParentId == 0)
            {
                TreeView1.Nodes.Add(tnode);
                DataTable dtChild = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId="+ tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(dtChild, VS, tnode);


            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild1 = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN' and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(dtChild1, VS, tnode);

            }
            else if (ParentId == 2)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild2 = (ObjCls.FnGetDataSet("select  TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId=SAD.nStudentId where SAD.nDivisionId= " + tnode.Value) as DataSet).Tables[0];
                VS = 3;
                PopulateTreeView(dtChild2, VS, tnode);

            }
            else
            {

                treeNode.ChildNodes.Add(tnode);

            }
        }
    }



    public override void FnInitializeForm()
    {
        TabContainer1.ActiveTabIndex = 0;
        int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
        ObjCls1 = new ClsFeeMaster(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        FnFindRecord();
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
    }
    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnFindRecord()
    {
        FnAssignProperty();
        ViewState["DT"] = ObjLst.FnGetFineMasterList() as DataTable;
        //ViewState["DT_CHILD"] = (ObjCls.FindRecord() as DataSet).Tables[0];

        //FnGridViewBinding("MAIN");
        FnGridViewBinding("");
    }
    public object FnGetGridRowCount(string PrmFlag)
    {
        throw new NotImplementedException();
    }
    public void FnGridViewBinding(string PrmFlag)
    {
        
            GrdVwRecordsMain.DataSource = ViewState["DT"] as DataTable;
            GrdVwRecordsMain.DataKeyNames = new String[] { ObjCls1.KeyName };
            GrdVwRecordsMain.DataBind();
            GrdVwRecordsMain.SelectedIndex = -1;
        
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
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            int iCnt = 0;
                            //for (int i = 0; i <= GrdVwRecords.Rows.Count - 1; i++)
                            //{
                            //    HdnFeeMstId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnFeeMstId");
                            //    HdnId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnId");
                            //    DdlLedger = (DropDownList)GrdVwRecords.Rows[i].FindControl("DdlLedger");

                            //    ObjCls.ID = ObjCls.FnIsNumeric(HdnId.Value);
                            //    ObjCls.FeeMasterId = ObjCls.FnIsNumeric(HdnFeeMstId.Value);
                            //    ObjCls.AccLedgerId = ObjCls.FnIsNumeric(DdlLedger.SelectedValue);
                            //    _strMsg = ObjCls.UpdateRecord() as string;
                            //    iCnt = iCnt + 1;
                            //}
                            //if (iCnt > 0)
                            //{
                            //    FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + "Records updated successfully"));
                            //}
                            break;
                    }
                    break;
                //case "ADD":
                //    FnAssignProperty();
                //    int nCnt = 0;
                //    string strId = "";
                //    for (int i = 0; i <= GrdVwRecordsMain.Rows.Count - 1; i++)
                //    {
                //        ChkVal = (CheckBox)GrdVwRecordsMain.Rows[i].FindControl("ChkVal");
                //        if (ChkVal.Checked == true)
                //        {
                //            HdnId = (HiddenField)GrdVwRecordsMain.Rows[i].FindControl("HdnId");
                //            strId = strId + HdnId.Value + ",";
                //            nCnt++;
                //        }
                //    }
                //    if (nCnt > 0)
                //    {
                //        ObjCls.Remarks = FnRemoveLastValue(strId);
                //        ViewState["DT_CHILD"] = (ObjCls.SaveChildRecord() as DataSet).Tables[0];
                //        FnGridViewBinding("");
                //    }
                //    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "PRINT":
                    FnAssignProperty();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }

    //protected void GrdVwRecords_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
    //    {
    //        DdlLedger = (DropDownList)e.Row.FindControl("DdlLedger");
    //        FnBindingDropDownList(ObjLst, ViewState["ACC"] as DataTable, DdlLedger, "");
    //        FnSetDropDownValue(DdlLedger, DataBinder.Eval(e.Row.DataItem, "AccLedgerId").ToString());
    //        e.Row.Attributes.Add("onmouseover", "this.style.cursor=\'pointer\'");
    //    }
    //}

    //protected void GrdVwRecordsMain_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID")) > 0)
    //    {
    //        ChkVal = (CheckBox)e.Row.FindControl("ChkVal");
    //        ChkVal.Checked = (ObjCls.FnIsNumeric((ViewState["DT_CHILD"] as DataTable).Compute("Count(ID)", " FeeMasterId= " + ObjCls.FnIsNumeric(DataBinder.Eval(e.Row.DataItem, "ID"))).ToString()) > 0 ? true : false);
    //    }
    //}
}