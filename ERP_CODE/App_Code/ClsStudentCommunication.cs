using System;
using System.Collections.Generic;
using System.Text;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;
public class ClsStudentCommunication : ClsCommonBaseMaster, IMasterCommands
{
    private int nPrimaryContact = 0, nExpired = 0, nStudentId = 0;
    //private string cPhoneNo, cMessagingNo, cEmail;
    public string cPhoneNo, cMessagingNo, cEmail,cRemarks;
    public ClsStudentCommunication() : base("TblStudentCommunicationDetails", "ID", 0, 0, 0, 0)
    {
       
    }

    public ClsStudentCommunication(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
       : base("TblStudentCommunicationDetails", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int PrimaryContact
    {
        get
        { return nPrimaryContact; }
        set
        { nPrimaryContact = value; }
    }
    
    public string MessagingNo
    {
        get
        { return cMessagingNo; }
        set
        { cMessagingNo = value; }
    }

    

    #region IMasterCommands Members
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        PrimaryContact = FnIsNumeric(drVal["PrimaryContact"].ToString());
        PhoneNo = drVal["PhoneNo"].ToString().Trim();
        cMessagingNo = drVal["MessagingNo"].ToString().Trim();
        Email = drVal["Email"].ToString().Trim();
        Remarks = drVal["Remarks"].ToString().Trim();


    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        //objFields.AddParameterFields("Prm_cName", System.Data.DbType.String, Name);
        //objFields.AddParameterFields("Prm_cCode", System.Data.DbType.String, Code);

        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId);
        objFields.AddParameterFields("Prm_nPrimaryContact", System.Data.DbType.Int32, PrimaryContact);
        objFields.AddParameterFields("Prm_cPhoneNo", System.Data.DbType.String, PhoneNo);
        objFields.AddParameterFields("Prm_cMessagingNo", System.Data.DbType.String, cMessagingNo);
        objFields.AddParameterFields("Prm_cEmail", System.Data.DbType.String, Email);
        //objFields.AddParameterFields("Prm_cRemarks", System.Data.DbType.String, Remarks);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProStudentCommunicationDetails", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProStudentCommunicationDetails", objFields));
            return objRetArrList[0].ToString();
        }
    }
    public override void ObjectToRow(System.Data.DataRow dRow, string ObjPrmCls)
    {
        base.ObjectToRow(dRow, ObjPrmCls);
        dRow["Name"] = Name;
        dRow["Code"] = Code;
        dRow["ParentId"] = ParentId;
        dRow["Parent"] = Parent;
    }
    #endregion
}