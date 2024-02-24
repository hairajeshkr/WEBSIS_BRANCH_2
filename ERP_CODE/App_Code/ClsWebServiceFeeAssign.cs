using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;

public class ClsWebServiceFeeAssign : ClsCommonBaseMaster, IMasterCommands
{
    private DataTable _DTRECORDS = null;
    private int nInstalmentId = 0, nFeeMasterId = 0, nInstituteGrpId;
    private DateTime dStartDate = Convert.ToDateTime("1800-01-01"), dEndDate = Convert.ToDateTime("1800-01-01");

    public ClsWebServiceFeeAssign()
    : base("", "ID", 0, 0, 0, 0)
    {
    }
    public ClsWebServiceFeeAssign(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
        : base("", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public DateTime StartDate
    {
        get
        { return dStartDate; }
        set
        { dStartDate = value; }
    }
    public DateTime EndDate
    {
        get
        { return dEndDate; }
        set
        { dEndDate = value; }
    }
    public int InstalmentId
    {
        get
        { return nInstalmentId; }
        set
        { nInstalmentId = value; }
    }
    public int FeeMasterId
    {
        get
        { return nFeeMasterId; }
        set
        { nFeeMasterId = value; }
    }
    public int InstituteGrpId
    {
        get
        { return nInstituteGrpId; }
        set
        { nInstituteGrpId = value; }
    }
    #region IMasterCommands Members
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }
    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {

    }
    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_dStartDate", System.Data.DbType.DateTime, StartDate);
        objFields.AddParameterFields("Prm_dEndDate", System.Data.DbType.DateTime, EndDate);
        objFields.AddParameterFields("Prm_nTokenId", System.Data.DbType.Double, TokenNo);
        objFields.AddParameterFields("Prm_nInstituteGrpId", System.Data.DbType.Int32, InstituteGrpId); ;
        objFields.AddParameterFields("Prm_nFeeMasterId", System.Data.DbType.Int32, FeeMasterId); ;
        objFields.AddParameterFields("Prm_nInstalmentId", System.Data.DbType.Int32, InstalmentId); ;

        objFields.AddParameterFields("Prm_nStudentId", System.Data.DbType.Int32, StudentId); ;
        objFields.AddParameterFields("Prm_nClassId", System.Data.DbType.Int32, ClassId); ;
        objFields.AddParameterFields("Prm_nDivisionId", System.Data.DbType.Int32, DivisionId); ;
        objFields.AddParameterFields("Prm_nInstituteId", System.Data.DbType.Int32, InstituteId); ;

        objFields.AddParameterFields("Prm_nAmount", System.Data.DbType.Double, Amount); ;
        objFields.AddParameterFields("Prm_nTotalAmt", System.Data.DbType.Double, TotalAmt); ;
        objFields.AddParameterFields("Prm_nOtherAmt", System.Data.DbType.Double, OtherAmt); ;


        return objDBManager.GetRecord("ProStudentWebService", objFields) as DataSet;
    }
    public override void ObjectToRow(System.Data.DataRow dRow, string ObjPrmCls)
    {

    }
    public DataTable FnGetFeeAssignTemp()
    {
        return (ManipulateData("FEE_ASGN") as DataSet).Tables[0];
    }
    public DataTable FnGetConcessionAssignTemp()
    {
        return (ManipulateData("CON_ASGN") as DataSet).Tables[0];
    }
    #endregion
}

