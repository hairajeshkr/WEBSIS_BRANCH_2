using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PDF"].ToString() == "0")
        {
            if (Request.QueryString["FILE_TYPE"].ToString() == "VCH_REG")
            {
                FnImgFilePath("VCH", Session["IMG_RC"].ToString());
            }
            else if (Request.QueryString["FILE_TYPE"].ToString() == "VCH_IMG")
            {
                FnImgFilePath("VCH", Session["IMG_VCH"].ToString());
            }
            else if (Request.QueryString["FILE_TYPE"].ToString() == "PRF_IMG")
            {
                FnImgFilePath("PRF", Session["IMG_PRF"].ToString());
            }
            else
            {
                FnImgFilePath(Request.QueryString["FILE_TYPE"].ToString().Trim(), Session["IMG"].ToString());
            }
        }
        else
        {
            Response.Redirect(FnDocFilePath(Request.QueryString["FILE_TYPE"].ToString().Trim(), Session["IMG"].ToString()));
        }
    }
    public string FnDocFilePath(string PrmFlag, string PrmFileName)
    {
        string strFile = "";
        if (PrmFlag.Equals("VCH") || PrmFlag.Equals("VCH_REG"))
        {
            strFile = "~\\UploadedFiles\\Vehicle\\" + PrmFileName.Replace("~", "").Trim();
        }
        return strFile;
    }
    public void FnImgFilePath(string PrmFlag, string PrmFileName)
    {
        if (PrmFileName.Trim().Length > 0)
        {
            string strFile = "";
            if (PrmFlag.Equals("VCH"))
            {
                strFile = "~\\UploadedFiles\\Vehicle\\" + PrmFileName.Replace("~", "").Trim();
            }
            else if (PrmFlag.Equals("PRF"))
            {
                strFile = "~\\UploadedFiles\\Profile\\" + PrmFileName.Replace("~", "").Trim();
            }
            ImgFile.ImageUrl = strFile;
        }
        else
        {
            LblMsg.Text = "File could't found";
        }
    }
}