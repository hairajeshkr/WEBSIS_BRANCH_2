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
    //finma ObjClsFin = new ClsFeeMaster();
    static int icount = 0;
    protected override void Page_Load(object sender, EventArgs e)
    {

        try
        {

            base.Page_Load(sender, e);
            CtrlCommand1.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
           // CtrlCommand2.FooterCommands += new CtrlCommand.ClickEventHandler(ManiPulateDataEvent_Clicked);
            if (!IsPostBack)
            {
               
                FnInitializeForm();

               
                DataTable ClsTD = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nClassId  where TCD.cttype='CLS'") as DataSet).Tables[0];
                this.PopulateTreeView(ClsTD, icount, null);

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
                TreeView1.Nodes.Add(tnode);
                DataTable dtChild = (ObjCls.FnGetDataSet("select Distinct TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblClassDetails  TCD on TCD.nId=SAD.nDivisionId  where TCD.cttype='DIVN' and SAD.nClassId= " + tnode.Value) as DataSet).Tables[0];
                VS = 1;
                this.PopulateTreeView(dtChild, VS, tnode);


            }
            else if (ParentId == 1)
            {
                treeNode.ChildNodes.Add(tnode);
                DataTable dtChild1 = (ObjCls.FnGetDataSet("select  TCD.nId ID,TCD.cName Name FROM TblStudentAdmissionDetails SAD inner join TblRegistrationStudent  TCD on TCD.nId=SAD.nStudentId where SAD.nDivisionId= " + tnode.Value) as DataSet).Tables[0];
                VS = 2;
                PopulateTreeView(dtChild1, VS, tnode);

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
    //int iCmpId = FnGetRights().COMPANYID, iBrId = FnGetRights().BRANCHID, iFaId = FnGetRights().FAYEARID, iAcId = FnGetRights().ACYEARID;
    //ObjCls = new ClsStudentAdmissionDetails(ref iCmpId, ref iBrId, ref iFaId, ref iAcId);
 
    //TxtCode.Text = ObjCls.FnGetAutoCode().ToString();

    ViewState["DT"] = FnGetGeneralTable(ObjCls);
    FnGridViewBinding("");
}
public void FnAssignProperty()
{
    base.FnAssignProperty(ObjCls);
    //ObjCls.Name = TxtName.Text.Trim();
    //ObjCls.Code = TxtCode.Text.Trim();
    //ObjCls.OrderIndex = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());  // max no of Admission

    //ObjCls.Remarks = TxtRemarks.Text.Trim();
    ////ObjCls.IsApprove = (ChkApprove.Checked == true ? true : false);
    //ObjCls.Active = (ChkActive.Checked == true ? true : false);

}

public override void FnCancel()
{
    base.FnCancel();

    //TxtName.Text = "";
    //TxtPriority.Text = "";
    //TxtCode_Srch.Text = "";
    //TxtRemarks.Text = "";
    //ChkActive.Checked = true;
    //ChkApprove.Checked = false;

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
    //ObjCls.Name = TxtName.Text.Trim();
    //ObjCls.Code = TxtCode_Srch.Text.Trim();
    //ObjCls.OrderIndex = ObjCls.FnIsNumeric(TxtPriority.Text.Trim());  /// maximum no of admission
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
    GrdVwSummary.DataSource = ViewState["DT"] as DataTable;
    GrdVwSummary.DataKeyNames = new String[] { ObjCls.KeyName };
    GrdVwSummary.DataBind();
    GrdVwSummary.SelectedIndex = -1;
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
                //if (TxtName.Text.Trim().Length <= 0)
                //{
                //    FnPopUpAlert(ObjCls.FnAlertMessage("Please enter the name"));
                //    FnFocus(TxtName);
                //    return;
                //}

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
        //GrdVwRecords.SelectedIndex = e.NewSelectedIndex;
        //ObjCls.GetDataRow(GrdVwRecords.SelectedDataKey.Values[0].ToString(), ViewState["DT"] as DataTable);
        //ViewState["ID"] = ObjCls.ID.ToString();
        //TxtName.Text = ObjCls.Name.ToString();
        //TxtCode.Text = ObjCls.Code.ToString();
        //TxtPriority.Text = ObjCls.OrderIndex.ToString();
        //TxtRemarks.Text = ObjCls.Remarks.ToString();
        //ChkActive.Checked = ObjCls.Active;
        //ChkApprove.Checked = ObjCls.IsApprove;
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
        //GrdVwRecords.PageIndex = e.NewPageIndex;
        FnGridViewBinding("");
    }
    catch (Exception ex)
    {
        FnPopUpAlert(ObjCls.FnAlertMessage(ex.Message));
    }
}


public void PopulateNode(Object sender, TreeNodeEventArgs e)
{

    // Call the appropriate method to populate a node at a particular level.
    switch (e.Node.Depth)
    {
        case 0:
            // Populate the first-level nodes.
            PopulateCategories(e.Node);
            break;
        case 1:
            // Populate the second-level nodes.
            PopulateProducts(e.Node);
            break;
        default:
            // Do nothing.
            break;
    }

}

void PopulateCategories(TreeNode node)
{

    // Query for the product categories. These are the values
    // for the second-level nodes.
    DataSet ResultSet = new DataSet("Select * From TblStudentAdmissionDetails");
    DataTable dt = new DataTable();



    // Create the second-level nodes.
    if (ResultSet.Tables.Count > 0)
    {

        // Iterate through and create a new node for each row in the query results.
        // Notice that the query results are stored in the table of the DataSet.
        foreach (DataRow row in ResultSet.Tables[0].Rows)
        {

            // Create the new node. Notice that the CategoryId is stored in the Value property 
            // of the node. This will make querying for items in a specific category easier when
            // the third-level nodes are created. 
            TreeNode newNode = new TreeNode();
            newNode.Text = row["ClassName"].ToString();
            newNode.Value = row["ClassID"].ToString();

            // Set the PopulateOnDemand property to true so that the child nodes can be 
            // dynamically populated.
            newNode.PopulateOnDemand = true;

            // Set additional properties for the node.
            newNode.SelectAction = TreeNodeSelectAction.Expand;

            // Add the new node to the ChildNodes collection of the parent node.
            node.ChildNodes.Add(newNode);

        }

    }

}

void PopulateProducts(TreeNode node)
{

    // Query for the products of the current category. These are the values
    // for the third-level nodes.
    DataSet ResultSet = new DataSet("Select DivisionId,DivisionName From TblClassDetails");

    // Create the third-level nodes.
    if (ResultSet.Tables.Count > 0)
    {

        // Iterate through and create a new node for each row in the query results.
        // Notice that the query results are stored in the table of the DataSet.
        foreach (DataRow row in ResultSet.Tables[0].Rows)
        {

            // Create the new node.
            TreeNode NewNode = new TreeNode(row["ProductName"].ToString());

            // Set the PopulateOnDemand property to false, because these are leaf nodes and
            // do not need to be populated.
            NewNode.PopulateOnDemand = false;

            // Set additional properties for the node.
            NewNode.SelectAction = TreeNodeSelectAction.None;

            // Add the new node to the ChildNodes collection of the parent node.
            node.ChildNodes.Add(NewNode);

        }

    }

}



}