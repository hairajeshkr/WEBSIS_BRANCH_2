using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
public partial class REPORT_FORMS_RptSchoolCumulative : ClsPageEvents, IPageInterFace
{
    ClsStudentClassDivisionAssign ObjCls = new ClsStudentClassDivisionAssign();
    ClsDropdownRecordList ObjLst = new ClsDropdownRecordList();

    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {
        try
        {
            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            //CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
                //FnInitializeForm();
                DataTable DTInstitute = (ObjCls.FnGetDataSet("select TCD.nId ID,TCD.cName Name FROM TblClassDetails  TCD where TCD.cttype='INGRP'") as DataSet).Tables[0];
                this.PopulateTreeView(DTInstitute, icount, null);


                //DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[9] { new DataColumn("hMale"), new DataColumn("hFemale"), new DataColumn("hTotal"), new DataColumn+("mMale"), new DataColumn("mFemale"), new DataColumn("mTotal"), new DataColumn("cMale"), new DataColumn("cFemale"), new DataColumn("cTotal") });
                ////dt.Rows.Add("John Hammond", "United States", "Albert Dunner", "Bolivia");
                ////dt.Rows.Add("Mudassar Khan", "India", "Jason Sprint", "Canada");
                ////dt.Rows.Add("Suzanne Mathews", "France", "Alfred Lobo", "Philippines");
                ////dt.Rows.Add("Robert Schidner", "Russia", "Shaikh Ayyaz", "UAE");
                //GrdVwRecords.DataSource = dt;
                //GrdVwRecords.DataBind();



                //DataTable DTClasses = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='CLS' ") as DataSet).Tables[0];
                //ChkClassDivList.DataSource = DTClasses;
                //ChkClassDivList.DataValueField = "nId";
                //ChkClassDivList.DataTextField = "cName";
                //ChkClassDivList.DataBind();

                //DataTable DTChkClassDiv = (ObjCls.FnGetDataSet("SELECT nId,cName FROM TblclassDetails where cttype='DIVN' ") as DataSet).Tables[0];
                //ChkDivList.DataSource = DTChkClassDiv;
                //ChkDivList.DataValueField = "nId";
                //ChkDivList.DataTextField = "cName";
                //ChkDivList.DataBind();
            }

        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
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
                TreVwLst.Nodes.Add(tnode);
                DataTable DTClass = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS' and TCD.nParentId= " + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(DTClass, VS, tnode);
            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable DTDivision = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN'and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(DTDivision, VS, tnode);
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
        ObjCls = new ClsStudentClassDivisionAssign(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
        ViewState["DT"] = FnGetGeneralTable(ObjCls);
        ViewState["DT_CHILD"] = FnGetGeneralTable(ObjCls);
        ViewState["DIV"] = FnGetGeneralTable(ObjCls);
        FnGridViewBinding("");
        FnGridViewBinding("SRCH");
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
        //CtrlGrdClass.SelectedValue = "0";
        //CtrlGrdClass.SelectedText = "";
        //CtrlGrdDivision.SelectedValue = "0";
        //CtrlGrdDivision.SelectedText = "";
        //CtrlCommand1.SaveText = "Save";
        //CtrlCommand1.SaveCommandArgument = "NEW";
        //FnFocus(CtrlGrdClass.ControlTextBox);
        TabContainer1.ActiveTabIndex = 0;
    }

    public void FnFindRecord()
    {
        FnAssignProperty();
        //FnGetDivisionList();
        FnFindRecord(ObjCls);
        FnGridViewBinding("");

        //ObjLst.FnGetDivisionList(DdlToDivision, "", ObjCls.FnIsNumeric(CtrlGrdClass.SelectedValue), ObjCls.FnIsNumeric(CtrlGrdDivision.SelectedValue));
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
        //GrdVwRecords.SelectedIndex = -1;

        //GrdVwSummary.DataSource = ViewState["DT"] as DataTable;
        //GrdVwSummary.DataBind();

        //GrdVwList.DataSource = ViewState["DT"] as DataTable;
        //GrdVwList.DataBind();

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


                    //DataTable dt = new DataTable();
                    //dt.Columns.Add(new DataColumn("Group", typeof(string)));
                    ////dt.Columns.Add(new DataColumn("SubGroup", typeof(string)));

                    //string selectedItemsC = "", selectedclass = "";
                    //for (int i = 0; i < ChkClassDivList.Items.Count; i++)
                    //{
                    //    if (ChkClassDivList.Items[i].Selected)
                    //    {
                    //        selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
                    //        selectedclass = ChkClassDivList.Items[i].Text;
                    //        DataRow row = dt.NewRow();
                    //        row["Group"] = selectedclass.TrimEnd(',');
                    //        dt.Rows.Add(row);
                    //    }

                    //}

                    //selectedItemsC = selectedItemsC.TrimEnd(',');
                    //selectedclass = selectedclass.TrimEnd(',');

                    //DataTable dclass = new DataTable();
                    //dclass.Columns.Add(new DataColumn("SubGroup", typeof(string)));
                    //string selectedItemsD = "", selecteddiv = "";
                    //for (int i = 0; i < ChkDivList.Items.Count; i++)
                    //{

                    //    if (ChkDivList.Items[i].Selected)
                    //    {
                    //        selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
                    //        selecteddiv = ChkDivList.Items[i].Text;
                    //        DataRow drow = dclass.NewRow();
                    //        drow["SubGroup"] = selecteddiv;
                    //        dclass.Rows.Add(drow);


                    //    }

                    //}



                    //selectedItemsD = selectedItemsD.TrimEnd(',');
                    //selecteddiv = selecteddiv.TrimEnd(',');

                    //DataTable DTMale = new DataTable();

                    //if (ChkReligionCat.SelectedValue == "1")
                    //{
                    //    string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=8  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=8  then 1 end)as Female,0 total,count(case when cSex= 'Male' and nReligionId=18  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=18  then 1 end)as hFemale,0 htotal,count(case when cSex= 'Male' and nReligionId=9  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=9  then 1 end)as mFemale,0 mtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";
                    //    DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    //    GrdVwRecords.DataSource = DTMale;
                    //    GrdVwCategory.Visible = false;
                    //    GrdVwRecords.DataBind();
                       


                    //    for (int i = 0; i < GrdVwRecords.Rows.Count; i++)
                    //    {
                    //        Label ChrisMale = (Label)GrdVwRecords.Rows[i].Cells[2].FindControl("lblchristianm");
                    //        Label ChrisFeMale = (Label)GrdVwRecords.Rows[i].Cells[3].FindControl("lblchristianf");
                    //        int cMale = Convert.ToInt32(ChrisMale.Text);
                    //        int cFemale = Convert.ToInt32(ChrisFeMale.Text);
                    //        int nTotChristain = cMale + cFemale;
                    //        GrdVwRecords.Rows[i].Cells[4].Text = nTotChristain.ToString();

                    //        Label HinduMale = (Label)GrdVwRecords.Rows[i].Cells[5].FindControl("lblhindum");
                    //        Label HinduFeMale = (Label)GrdVwRecords.Rows[i].Cells[6].FindControl("Lblhinduf");
                    //        int hMale = Convert.ToInt32(HinduMale.Text);
                    //        int hFemale = Convert.ToInt32(HinduFeMale.Text);
                    //        int nTotHindu = hMale + hFemale;
                    //        GrdVwRecords.Rows[i].Cells[7].Text = nTotHindu.ToString();

                    //        Label MuslimMale = (Label)GrdVwRecords.Rows[i].Cells[8].FindControl("lblmuslimmale");
                    //        Label MuslimFeMale = (Label)GrdVwRecords.Rows[i].Cells[9].FindControl("lblmuslimfeMale");
                    //        int mMale = Convert.ToInt32(MuslimMale.Text);
                    //        int mFemale = Convert.ToInt32(MuslimFeMale.Text);
                    //        int nTot = mMale + mFemale;
                    //        GrdVwRecords.Rows[i].Cells[10].Text = nTotHindu.ToString();


                    //        int AllRelgMale = cMale + hMale + mMale;
                    //        int AllRelgFeMale = cFemale + hFemale + mFemale;
                    //        int AllRelgTot = AllRelgMale + AllRelgFeMale;

                    //        GrdVwRecords.Rows[i].Cells[11].Text = AllRelgMale.ToString();
                    //        GrdVwRecords.Rows[i].Cells[12].Text = AllRelgFeMale.ToString();
                    //        GrdVwRecords.Rows[i].Cells[13].Text = AllRelgTot.ToString();




                      //  }




                    //}
                    //else if (ChkReligionCat.SelectedValue == "2")
                    //{
                    //    string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nCategoryId=5  then 1 end) as GMale,count(case when cSex= 'Female' and nCategoryId=5  then 1 end)as GFemale,0 Gtotal,count(case when cSex= 'Male' and nCategoryId=30  then 1 end) as NonResMale,count(case when cSex= 'Female' and nCategoryId=30  then 1 end)as NonResFeMale,0 NonRestotal,count(case when cSex= 'Male' and nCategoryId=6  then 1 end) as OBCMale,count(case when cSex= 'Female' and nCategoryId=6  then 1 end)as OBCFemale,0 OBCtotal,count(case when cSex= 'Male' and nCategoryId=15  then 1 end) as OECMale,count(case when cSex= 'Female' and nCategoryId=15  then 1 end)as OECFemale,0 OECtotal,count(case when cSex= 'Male' and nCategoryId=23  then 1 end) as RESMale,count(case when cSex= 'Female' and nCategoryId=23  then 1 end)as RESFemale,0 REStotal,count(case when cSex= 'Male' and nCategoryId=3  then 1 end) as SCMale,count(case when cSex= 'Female' and nCategoryId=3  then 1 end)as SCFemale,0 SCtotal,count(case when cSex= 'Male' and nCategoryId=11  then 1 end) as STMale,count(case when cSex= 'Female' and nCategoryId=11  then 1 end)as STFemale,0 STtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";
                    //    DTMale = (ObjCls.FnGetDataSet(query) as DataSet).Tables[0];
                    //    GrdVwRecords.Visible = false;
                    //    GrdVwCategory.DataSource = DTMale;
                    //    GrdVwCategory.DataBind();

                    //    for (int i = 0; i < GrdVwCategory.Rows.Count; i++)
                    //    {
                    //        //Label ChrisMale = (Label)GrdVwRecords.Rows[i].Cells[2].FindControl("lblchristianm");
                    //        //Label ChrisFeMale = (Label)GrdVwRecords.Rows[i].Cells[3].FindControl("lblchristianf");
                    //        Label GMale = (Label)GrdVwCategory.Rows[i].FindControl("lblgeneralm");
                    //        Label GFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblgeneralf");
                    //        int cMale = Convert.ToInt32(GMale.Text);
                    //        int cFemale = Convert.ToInt32(GFeMale.Text);
                    //        int nTotGeneral = cMale + cFemale;
                    //        GrdVwCategory.Rows[i].Cells[4].Text = nTotGeneral.ToString();

                    //        Label NonResMale = (Label)GrdVwCategory.Rows[i].FindControl("lblnonresm");
                    //        Label NonResFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblnonresf");
                    //        int NonReserMale = Convert.ToInt32(NonResMale.Text);
                    //        int NonReserFemale = Convert.ToInt32(NonResFeMale.Text);
                    //        int nTotNonRes = NonReserMale + NonReserFemale;
                    //        GrdVwCategory.Rows[i].Cells[7].Text = nTotNonRes.ToString();


                    //        Label ObcMale = (Label)GrdVwCategory.Rows[i].FindControl("lblobcm");
                    //        Label ObcFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblobcf");
                    //        int ObcMales = Convert.ToInt32(ObcMale.Text);
                    //        int ObcFeMales = Convert.ToInt32(ObcFeMale.Text);
                    //        int nTotObc = ObcMales + ObcFeMales;
                    //        GrdVwCategory.Rows[i].Cells[10].Text = nTotObc.ToString();


                    //        Label OecMale = (Label)GrdVwCategory.Rows[i].FindControl("lbloecm");
                    //        Label OecFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lbloecf");
                    //        int OecMales = Convert.ToInt32(OecMale.Text);
                    //        int OecFeMales = Convert.ToInt32(OecFeMale.Text);
                    //        int nTotOec = OecMales + OecFeMales;
                    //        GrdVwCategory.Rows[i].Cells[13].Text = nTotOec.ToString();


                    //        Label ResMale = (Label)GrdVwCategory.Rows[i].FindControl("lblreservationm");
                    //        Label ResFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblreservationf");
                    //        int ReserMales = Convert.ToInt32(ResMale.Text);
                    //        int ReserFeMales = Convert.ToInt32(ResFeMale.Text);
                    //        int nTotReserv = ReserMales + ReserFeMales;
                    //        GrdVwCategory.Rows[i].Cells[16].Text = nTotReserv.ToString();

                    //        Label ScMale = (Label)GrdVwCategory.Rows[i].FindControl("lblscm");
                    //        Label ScFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblscf");
                    //        int ScMales = Convert.ToInt32(ScMale.Text);
                    //        int ScFeMales = Convert.ToInt32(ScFeMale.Text);
                    //        int nTotSc = ScMales + ScFeMales;
                    //        GrdVwCategory.Rows[i].Cells[19].Text = nTotSc.ToString();


                    //        Label StMale = (Label)GrdVwCategory.Rows[i].FindControl("lblstm");
                    //        Label StFeMale = (Label)GrdVwCategory.Rows[i].FindControl("lblstf");
                    //        int StMales = Convert.ToInt32(StMale.Text);
                    //        int StFeMales = Convert.ToInt32(StFeMale.Text);
                    //        int nTotSt = StMales + StFeMales;
                    //        GrdVwCategory.Rows[i].Cells[22].Text = nTotSt.ToString();


                    //        int TotMales = cMale + NonReserMale + ObcMales + OecMales + ReserMales + ScMales + StMales;
                    //        int TotFemales = cFemale + NonReserFemale + ObcFeMales + OecFeMales + ReserFeMales + ScFeMales + StFeMales;
                    //        int TotCount = TotMales + TotFemales;

                    //        GrdVwCategory.Rows[i].Cells[23].Text = TotMales.ToString();
                    //        GrdVwCategory.Rows[i].Cells[24].Text = TotFemales.ToString();
                    //        GrdVwCategory.Rows[i].Cells[25].Text = TotCount.ToString();





                    //    }
                   // }



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
                    //FnCancel_Srch();
                    break;
                case "PRINT":
                    FnAssignProperty_Srch();
                    base.ManiPulateDataEvent_Clicked(((Button)sender).CommandName.ToString().ToUpper(), ObjCls, false);
                   // this.BindReport();
                    break;
            }
        }
        catch (Exception ex)
        {
            FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
        }
    }


    //protected void ChkSelctAllClass_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkSelctAllClass.Checked == true)
    //    {
    //        foreach (ListItem item in ChkClassDivList.Items)
    //        {
    //            item.Selected = true;
    //            item.Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (ListItem item in ChkClassDivList.Items)
    //        {
    //            item.Selected = false;
    //            item.Enabled = true;
    //        }
    //    }
    //}



    //protected void ChkSelectAllDiv_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (ChkSelectAllDiv.Checked == true)
    //    {
    //        foreach (ListItem item in ChkDivList.Items)
    //        {
    //            item.Selected = true;
    //            item.Enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (ListItem item in ChkDivList.Items)
    //        {
    //            item.Selected = false;
    //            item.Enabled = true;
    //        }

    //    }
    //}

    protected void GrdVwRecords_DataBound(object sender, EventArgs e)
    {
        if (ChkReligionCat.SelectedValue == "1")
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "Class";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 1;
            cell.Text = "Division";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Christian";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Hindu";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "Muslim";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "All Religion";
            row.Controls.Add(cell);




            //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            GrdVwRecords.HeaderRow.Parent.Controls.AddAt(0, row);
        }




    }

    protected void GrdVwCategory_DataBound(object sender, EventArgs e)
    {
        if (ChkReligionCat.SelectedValue == "2")
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "Class";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 1;
            cell.Text = "Division";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "GENERAL";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "NON RESERVATION";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "OBC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "OEC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "RESERVATION";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "SC";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "ST";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 3;
            cell.Text = "All Category";
            row.Controls.Add(cell);


            //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            GrdVwRecords.Visible = false;
            GrdVwCategory.HeaderRow.Parent.Controls.AddAt(0, row);

        }
    }



    //private void BindReport()
    //{
    //    string selectedItemsC = "", selectedclass = "";
    //    for (int i = 0; i < ChkClassDivList.Items.Count; i++)
    //    {
    //        if (ChkClassDivList.Items[i].Selected)
    //        {
    //            selectedItemsC += ChkClassDivList.Items[i].Value.ToString() + ",";
    //            selectedclass = ChkClassDivList.Items[i].Text;
    //        }

    //    }

    //    selectedItemsC = selectedItemsC.TrimEnd(',');
    //    selectedclass = selectedclass.TrimEnd(',');


    //    string selectedItemsD = "", selecteddiv = "";
    //    for (int i = 0; i < ChkDivList.Items.Count; i++)
    //    {

    //        if (ChkDivList.Items[i].Selected)
    //        {
    //            selectedItemsD += ChkDivList.Items[i].Value.ToString() + ",";
    //            selecteddiv = ChkDivList.Items[i].Text;
    //        }

    //    }


    //    selectedItemsD = selectedItemsD.TrimEnd(',');
    //    selecteddiv = selecteddiv.TrimEnd(',');

    //    //DataTable DTList = new DataTable();

    //    //using (SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;"))
    //    //{
    //    //    using (SqlCommand cmd1 = new SqlCommand("SPFillStudentGridData", con1))
    //    //    {
    //    //        con1.Open();
    //    //        cmd1.CommandType = CommandType.StoredProcedure;
    //    //        cmd1.Parameters.AddWithValue("@Class", selectedItemsC);
    //    //        cmd1.Parameters.AddWithValue("@Division", selectedItemsD);
    //    //        int i = cmd1.ExecuteNonQuery();
    //    //        con1.Close();
    //    //        using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
    //    //        {
    //    //            da.Fill(DTList);
    //    //        }
    //    //    }

    //    //    ViewState["DT_List"] = DTList;

    //    //}


    //    if (ChkReligionCat.SelectedValue == "1")
    //    {
    //        //string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' then 1 end) as Male,count(case when cSex= 'Female' then 1 end)as Female FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";

    //         string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nReligionId=7  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=7  then 1 end)as Female,0 total,count(case when cSex= 'Male' and nReligionId=2  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=2  then 1 end)as hFemale,0 htotal,count(case when cSex= 'Male' and nReligionId=6  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=6  then 1 end)as mFemale,0 mtotal FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName";
    //        //string query = "select 'CLS' class,'DIV' division ,count(case when cSex= 'Male' and nReligionId=8  then 1 end) as Male,count(case when cSex= 'Female' and nReligionId=8  then 1 end)as Female,count(case when cSex= 'Male' and nReligionId=18  then 1 end) as hMale,count(case when cSex= 'Female' and nReligionId=18  then 1 end)as hFemale,count(case when cSex= 'Male' and nReligionId=9  then 1 end) as mMale,count(case when cSex= 'Female' and nReligionId=9  then 1 end)as mFemale FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ") ";

    //        string parameter1 = query;
    //        string parameter2 = "1";
    //        Session["param1"] = parameter1;
    //        Session["param2"] = parameter2;
    //    }
    //    if (ChkReligionCat.SelectedValue == "2")
    //    {

    //        string query = "select CLS.cName class,DIV.cName division ,count(case when cSex= 'Male' and nCategoryId=5  then 1 end) as GMale,count(case when cSex= 'Female' and nCategoryId=5  then 1 end)as GFemale,count(case when cSex= 'Male' and nCategoryId=30  then 1 end) as NonResMale,count(case when cSex= 'Female' and nCategoryId=30  then 1 end)as NonResFeMale,count(case when cSex= 'Male' and nCategoryId=6  then 1 end) as OBCMale,count(case when cSex= 'Female' and nCategoryId=6  then 1 end)as OBCFemale,count(case when cSex= 'Male' and nCategoryId=15  then 1 end) as OECMale,count(case when cSex= 'Female' and nCategoryId=15  then 1 end)as OECFemale,count(case when cSex= 'Male' and nCategoryId=23  then 1 end) as RESMale,count(case when cSex= 'Female' and nCategoryId=23  then 1 end)as RESFemale,count(case when cSex= 'Male' and nCategoryId=3  then 1 end) as SCMale,count(case when cSex= 'Female' and nCategoryId=3  then 1 end)as SCFemale,count(case when cSex= 'Male' and nCategoryId=11  then 1 end) as STMale,count(case when cSex= 'Female' and nCategoryId=11  then 1 end)as STFemale FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId inner join tblclassdetails CLS on STDA.nClassId = CLS.nId inner join  tblclassdetails DIV on STDA.nDivisionId = DIV.nId  and STDA.nClassId in(" + selectedItemsC + ") and STDA.nDivisionId in (" + selectedItemsD + ")  group by CLS.cName,DIV.cName ";
    //        //string query = "select 'CLS'  class,'DIV' division ,count(case when cSex= 'Male' and nCategoryId=5  then 1 end) as GMale,count(case when cSex= 'Female' and nCategoryId=5  then 1 end)as GFemale,count(case when cSex= 'Male' and nCategoryId=30  then 1 end) as NonResMale,count(case when cSex= 'Female' and nCategoryId=30  then 1 end)as NonResFeMale,count(case when cSex= 'Male' and nCategoryId=6  then 1 end) as OBCMale,count(case when cSex= 'Female' and nCategoryId=6  then 1 end)as OBCFemale,count(case when cSex= 'Male' and nCategoryId=15  then 1 end) as OECMale,count(case when cSex= 'Female' and nCategoryId=15  then 1 end)as OECFemale,count(case when cSex= 'Male' and nCategoryId=23  then 1 end) as RESMale,count(case when cSex= 'Female' and nCategoryId=23  then 1 end)as RESFemale,count(case when cSex= 'Male' and nCategoryId=3  then 1 end) as SCMale,count(case when cSex= 'Female' and nCategoryId=3  then 1 end)as SCFemale,count(case when cSex= 'Male' and nCategoryId=11  then 1 end) as STMale,count(case when cSex= 'Female' and nCategoryId=11  then 1 end)as STFemale FROM TblRegistrationStudent STDR inner join TblStudentAdmissionDetails STDA on STDR.nId = STDA.nStudentId  and STDA.nClassId in(" + selectedItemsC + ") ";

    //        string parameter1 = query;
    //        string parameter2 = "2";
    //        Session["param1"] = parameter1;
    //        Session["param2"] = parameter2;
    //    }

    //   // Response.Redirect("RptSchoolCumulativeViewer.aspx");

    //    Response.Redirect("RptSchoolCumulativeViewer.aspx");
    //    //Response.Redirect("RptSchoolCumulative.aspx");
    //}


    protected void TreVwLst_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            FnCancel();
        }
        catch
        {
        }
    }


}
