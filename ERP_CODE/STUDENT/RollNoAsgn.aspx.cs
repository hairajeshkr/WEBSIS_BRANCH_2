using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class STUDENT_RollNoAsgn : ClsPageEvents,IPageInterFace
{
    ClsStudentRollNoAssign ObjCls = new ClsStudentRollNoAssign();
    
    ClsDropdownRecordList obj = new ClsDropdownRecordList();

    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                FnInitializeForm();
                obj.FnGetBranchList(DdlInstitute, "");
                
                //filldropdown();
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
        /*int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID;
        ObjCls = new clsAccountGroup(ref iCmpId, ref iBrId, ref iFaId);*/
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        //FnGetCheckboxListValue();
    }

    public void FnAssignProperty()
    {
        base.FnAssignProperty(ObjCls);
        ObjCls.ClassId = ObjCls.FnIsNumeric(DdlClass.SelectedValue);
        ObjCls.DivisionId = ObjCls.FnIsNumeric(DdlDivision.SelectedValue);
        ObjCls.SortByName =DdlSortBy.SelectedValue;
        ObjCls.SortByLanguage = DdlSortBy.SelectedValue;
        ObjCls.SortBySex = DdlSortBy.SelectedValue;
    }

    public void FnClose()
    {
        throw new NotImplementedException();
    }
    public override void FnCancel()
    {
        base.FnCancel();
               
        FnInitializeForm();

        CtrlCommand1.SaveText = "Save";
        CtrlCommand1.SaveCommandArgument = "NEW";
        TabContainer1.ActiveTabIndex = 0;
        
    }

    public void FnFindRecord()
    {
        FnAssignProperty();

        FnFindRecord(ObjCls);
        FnGridViewBinding("");

        //if (DdlInstitute.SelectedValue == "0")
        //{
        //    DataTable clsls1 = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName,'' RollNo from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
        //    GrdVwRecords.DataSource = clsls1;
        //    GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //    GrdVwRecords.DataBind();
        //    GrdVwRecords.SelectedIndex = -1;

        //}
        //else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue == "0") && (DdlDivision.SelectedValue == "0"))
        //{
        //    DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName,'' RollNo from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
        //    GrdVwRecords.DataSource = dt;
        //    GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //    GrdVwRecords.DataBind();
        //    GrdVwRecords.SelectedIndex = -1;
        //}
        //else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue != "0") && (DdlDivision.SelectedValue == "0"))
        //{
        //    DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName,'' RollNo from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
        //    GrdVwRecords.DataSource = dt;
        //    GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //    GrdVwRecords.DataBind();
        //    GrdVwRecords.SelectedIndex = -1;
        //}
        //else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue != "0") && (DdlDivision.SelectedValue != "0"))
        //{
        //    DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName,'' RollNo from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId where TBL.nClassId=" + DdlClass.SelectedValue + " and TBL.nDivisionId=" + DdlDivision.SelectedValue + " order by TRS.cName") as DataSet).Tables[0];
        //    GrdVwRecords.DataSource = dt;
        //    GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
        //    GrdVwRecords.DataBind();
        //    GrdVwRecords.SelectedIndex = -1;

        //}

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
                    //FnAssignProperty();
                    
                    switch (((Button)sender).CommandArgument.ToString().ToUpper())
                    {
                        case "NEW":
                            FnAssignProperty();
                            int iCnt = 0;
                            for (int i = 0; i <= GrdVwRecords.Rows.Count-1; i++)
                            {
                                HiddenField HdnStudentId = (HiddenField)GrdVwRecords.Rows[i].FindControl("HdnStudentId");
                                Label LblRollNo = (Label)GrdVwRecords.Rows[i].FindControl("LblRollNo");
                                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnStudentId.Value);
                                ObjCls.RollNo = ObjCls.FnIsNumeric(LblRollNo.Text);
                                _strMsg = ObjCls.UpdateRecord() as string;
                                iCnt = iCnt + 1;
                            }

                            if (iCnt > 0)
                            {
                                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + "Records Roll No Assigned"));
                            }

                            break;
                    }
                    break;
                case "FIND":
                    FnFindRecord();
                    break;


            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }


        //try
        //{
        //    switch (((Button)sender).CommandArgument.ToString().ToUpper())
        //    {

        //        case "NEW":
        //            FnAssignProperty();
        //            int iCnt = 0;
        //            for (int i = 0; i <= GrdStudents.Rows.Count; i++)
        //            {
        //                HiddenField HdnStudentId = (HiddenField)GrdStudents.Rows[i].FindControl("HdnStudentId");
        //                Label LblRollNo = (Label)GrdStudents.Rows[i].FindControl("LblRollNo");
        //                ObjCls.StudentId = ObjCls.FnIsNumeric(HdnStudentId.Value);
        //                ObjCls.RollNo = ObjCls.FnIsNumeric(LblRollNo.Text);
        //                _strMsg = ObjCls.UpdateRecord() as string;
        //                iCnt = iCnt + 1;
        //            }
                    
        //            if (iCnt > 0)
        //            {
        //                FnPopUpAlert(ObjCls.FnAlertMessage(iCnt.ToString() + "Records Roll No Assigned"));
        //            }

        //            break;
        //        case "FIND":
        //            FnFindRecord();
        //            break;

        //    }
        //}
        //catch (Exception ex)
        //{
        //    FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        //}
    }


    protected void BtnFind_Click(object sender, EventArgs e)
    {

        FnFindRecord();

        if (DdlInstitute.SelectedValue == "0")
        {
            DataTable clsls1 = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
            GrdVwRecords.DataSource = clsls1;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;

        }
        else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue == "0") && (DdlDivision.SelectedValue == "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue != "0") && (DdlDivision.SelectedValue == "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;
        }
        else if ((DdlInstitute.SelectedValue != "0") && (DdlClass.SelectedValue != "0") && (DdlDivision.SelectedValue != "0"))
        {
            DataTable dt = (ObjCls.FnGetDataSet("select  TRS.cCode ID,TRS.cName Name,(select CName from TblClassDetails TGL where TGL.nId=TBL.nClassId and cTType='CLS') ClassName,(select CName from TblClassDetails TDL where TDL.nId=TBL.nDivisionId and cTType='DIVN') DivisionName from TblStudentAdmissionDetails TBL INNER JOIN TblRegistrationStudent TRS on TRS.nId=TBL.nStudentId") as DataSet).Tables[0];
            GrdVwRecords.DataSource = dt;
            GrdVwRecords.DataKeyNames = new String[] { ObjCls.KeyName };
            GrdVwRecords.DataBind();
            GrdVwRecords.SelectedIndex = -1;

        }

    }



    protected void DrpInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obj.FnGetBranchList(DrpInstitution, "");
        DdlClass.Items.Clear();
        DdlClass.Items.Add(new ListItem("select", "0"));
        int i = ObjCls.FnIsNumeric(DdlInstitute.SelectedValue);
        DataTable clsCls = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='CLS' and nBranchId=" + i + "") as DataSet).Tables[0];
        DdlClass.DataSource = clsCls;
        DdlClass.DataValueField = "nId";
        DdlClass.DataTextField = "cName";
        DdlClass.DataBind();

    }

    protected void DrpClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlDivision.Items.Clear();
        DdlDivision.Items.Add(new ListItem("select", "0"));
        int i = ObjCls.FnIsNumeric(DdlClass.SelectedValue);
        DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN' and nParentId=" + i + "") as DataSet).Tables[0];
        //DataTable clsDiv = (ObjCls.FnGetDataSet("select  nId,cName from TblClassDetails where cTType='DIVN'") as DataSet).Tables[0];
        DdlDivision.DataSource = clsDiv;
        DdlDivision.DataValueField = "nId";
        DdlDivision.DataTextField = "cName";
        DdlDivision.DataBind();
        ////clsDiv.Clear();

    }

}