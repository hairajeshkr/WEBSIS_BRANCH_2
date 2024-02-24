using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOTUS_GENERAL;
using LOTUS_DATA;
using System.Collections;
using System.Data;

public class ClsTeacherVsStudent : ClsCommonBaseMaster, IMasterCommands
{
    public int nNEPClassId = 0, nNEPDivisionId, nNEPGroupNID, nNEPStudentId, NEPPaperId, NEPTeacherId, Rdel;
    public string cNEPSubjectName;
    public string PFlag = "S1";
    public ClsTeacherVsStudent() : base("TblNEPStudentGroupDetails", "ID", 0, 0, 0, 0)
    {
    }

    public ClsTeacherVsStudent(ref int PrmCompanyId, ref int PrmBranchId, ref int PrmFaId, ref int PrmAcId)
      : base("TblNEPStudentGroupDetails", "ID", PrmCompanyId, PrmBranchId, PrmFaId, PrmAcId)
    {
    }
    public int NEPClassId
    {
        get
        { return nNEPClassId; }
        set
        { nNEPClassId = value; }
    }
    public int NEPDivisionId
    {
        get
        { return nNEPDivisionId; }
        set
        { nNEPDivisionId = value; }
    }
    public int GroupNID
    {
        get
        { return nNEPGroupNID; }
        set
        { nNEPGroupNID = value; }
    }
    public int NEPStudentId
    {
        get
        { return nNEPStudentId; }
        set
        { nNEPStudentId = value; }
    }
    
    public override System.Data.DataTable CreatePropertyTable(string PrmTableName)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public override void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];

        NEPClassId = FnIsNumeric(drVal["ClassId"].ToString());
        NEPDivisionId = FnIsNumeric(drVal["DivisionId"].ToString());
        GroupNID = FnIsNumeric(drVal["GroupID"].ToString());
        NEPStudentId = FnIsNumeric(drVal["Id"].ToString());
    }

    public override object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;


        objFields.AddParameterFields("Prm_nNEPClassId", System.Data.DbType.Int32, NEPClassId);
        objFields.AddParameterFields("Prm_nNEPDivisionId", System.Data.DbType.Int32, NEPDivisionId);
        objFields.AddParameterFields("Prm_GroupNID", System.Data.DbType.Int32, GroupNID);
        objFields.AddParameterFields("Prm_StudentID", System.Data.DbType.Int32, NEPStudentId);
        objFields.AddParameterFields("Prm_cFillFlag", System.Data.DbType.String, PFlag);
        objFields.AddParameterFields("Prm_PaperID", System.Data.DbType.String, NEPPaperId);
        objFields.AddParameterFields("Prm_TeacherID", System.Data.DbType.String, NEPTeacherId);
        objFields.AddParameterFields("Prm_Rdel", System.Data.DbType.Int32, Rdel);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ProTeacherVsStudent", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ProTeacherVsStudent", objFields));
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

}