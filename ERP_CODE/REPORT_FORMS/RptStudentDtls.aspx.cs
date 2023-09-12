﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class REPORT_FORMS_RptStudentDtls : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();
    DataTable DTMale = new DataTable();
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();

                DataTable DTClasses = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
                ChkClassDivList.DataSource = DTClasses;
                ChkClassDivList.DataValueField = "nId";
                ChkClassDivList.DataTextField = "cName";
                ChkClassDivList.DataBind();

                DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
                ChkDivList.DataSource = DTChkClassDiv;
                ChkDivList.DataValueField = "nId";
                ChkDivList.DataTextField = "cName";
                ChkDivList.DataBind();

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
        ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        //FnGridViewBinding("");
        //FnGridViewBinding("SRCH");
    }
    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);

    }
    public void FnAssignProperty_Srch()
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
        FnFindRecord(ObjCls);
        TabContainer1.ActiveTabIndex = 0;
    }
    public void FnFindRecord_Srch()
    {
        FnAssignProperty_Srch();
        ViewState["DT_CHILD"] = (ObjCls.FindRecord() as DataSet).Tables[0];
        FnGridViewBinding("SRCH");
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

                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Group", typeof(string)));
                    //dt.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                   
                    string selectedItemsC = "", selectedclass="";
                    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    {
                        if (ChkClassDivList.Items[i].Selected)
                        { 
                            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                            selectedclass = ChkClassDivList.Items[i].Text;
                            DataRow row = dt.NewRow();
                            row["Group"] = selectedclass.TrimEnd(',');
                            dt.Rows.Add(row);
                        }
                        
                    }

                    selectedItemsC = selectedItemsC.TrimEnd(',');
                    selectedclass = selectedclass.TrimEnd(',');

                    DataTable dclass = new DataTable();
                    dclass.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                    string selectedItemsD = "",selecteddiv="";
                    for (int i = 0; i < ChkDivList.Items.Count; i++)
                    {
                       
                        if (ChkDivList.Items[i].Selected)
                        {
                            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                            selecteddiv = ChkDivList.Items[i].Text;
                            DataRow drow = dclass.NewRow();
                            drow["SubGroup"] = selecteddiv;
                            dclass.Rows.Add(drow);
                            
                            
                        }

                    }

                    //for (int k = 0; k < dt.Rows.Count; k++)
                    //{
                    //    GrdVwRecords.Rows[k].Cells[1].Text = dt.Rows[k].ItemArray.ToString();
                    //}
                    


                    //GrdVwRecords.DataSource = dt;
                    //GrdVwRecords.DataBind();
                    
                    selectedItemsD = selectedItemsD.TrimEnd(',');
                    selecteddiv = selecteddiv.TrimEnd(',');



                    //string query = "select count(case when cSex='Male' then 1 end) as Male,count(case when cSex='Female' then 1 end) as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ") ";

                    string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";


                    DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    GrdVwRecords.DataSource = DTMale;
                    GrdVwRecords.DataBind();

                    // kl = GrdVwRecords.Rows[1].Cells[3].Text;

                    for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
                    {
                        Label k = (Label)GrdVwRecords.Rows[i].Cells[3].FindControl("Lblboys");

                        Label h = (Label)GrdVwRecords.Rows[i].Cells[4].FindControl("lblfemale");
                        int j = Convert.ToInt32(k.Text);
                        int m = Convert.ToInt32(h.Text);
                        int n = j + m;
                        GrdVwRecords.Rows[i].Cells[4].Text = n.ToString();
                    }

                   
                    break;
                case "FIND":
                    FnFindRecord();
                    break;
                case "FIND_SRCH":
                    FnFindRecord_Srch();
                    break;
                case "CLEAR":
                    FnCancel();
                    break;
                case "CLEAR_SRCH":
                    break;
                case "PRINT":
                    FnAssignProperty_Srch();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    protected void ChkSelctAllClass_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSelctAllClass.Checked == true)
        {
            foreach (ListItem item in ChkClassDivList.Items)
            {
                item.Selected = true;
                item.Enabled = true;
            }
        }
        else
        {
            foreach (ListItem item in ChkClassDivList.Items)
            {
                item.Selected = false;
                item.Enabled = true;
            }
        }
    }



    protected void ChkSelectAllDiv_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkSelectAllDiv.Checked == true)
        {
            foreach (ListItem item in ChkDivList.Items)
            {
                item.Selected = true;
                item.Enabled = true;
            }
        }
        else
        {
            foreach (ListItem item in ChkDivList.Items)
            {
                item.Selected = false;
                item.Enabled = true;
            }

        }
    }
}