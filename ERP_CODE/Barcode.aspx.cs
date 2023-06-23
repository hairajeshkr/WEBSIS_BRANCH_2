using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.IO;

public partial class Barcode : System.Web.UI.Page 
{
    ClsBarCode ObjBar = new ClsBarCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string FnGetAttachFilePath()
    {
        string strPath = "";
        try
        {
            AppSettingsReader asdr = new AppSettingsReader();
            strPath = asdr.GetValue("PATH", typeof(string)).ToString();
        }
        catch (Exception ex)
        {
            strPath = "";
            throw ex;
        }
        return strPath;
    }
    public string FnSetBarCode(int PrmBarCodeNo)
    {
        string strBar = "",strSymbol="IM";
        if (PrmBarCodeNo <= 9999)
        {
            strBar = strSymbol + "00" + PrmBarCodeNo.ToString();
        }
        else if (PrmBarCodeNo > 99999 && PrmBarCodeNo <= 99999)
        {
            strBar = strSymbol + "0" + PrmBarCodeNo.ToString();
        }
        else
        {
            strBar = strSymbol + PrmBarCodeNo.ToString();

        }
        return strBar.Trim();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int iCnt = ObjBar.FnIsNumeric(TxtFrm.Text);
        int iBarCode = ObjBar.FnIsNumeric(TxtTo.Text);
        for (iCnt = ObjBar.FnIsNumeric(TxtFrm.Text); iCnt <= iBarCode; iCnt++)
        {
            PictureBox pic = new PictureBox();
            ObjBar.BarCode = FnSetBarCode(iCnt);
            ObjBar.CompanyId = 1;
            ObjBar.FnGenerateBarCode(pic,true);
            string strPath = Server.MapPath(Request.ApplicationPath) + "\\AttachFiles\\" + "IMELT12345.jpg";
            pic.Image.Save(strPath);
            byte[] buffer1 = null;
            if (strPath.Trim().Length > 0)
            {
                FileStream imageStream1 = new FileStream(strPath.Trim(), FileMode.Open, FileAccess.Read);
                BinaryReader mbr1 = new BinaryReader(imageStream1);
                buffer1 = new byte[imageStream1.Length];
                mbr1.Read(buffer1, 0, Convert.ToInt32(imageStream1.Length));
                imageStream1.Close();
            }
            else
            {
                buffer1 = new byte[0];
            }
            string base64String = Convert.ToBase64String(buffer1, 0, buffer1.Length);
            ImgThump.Src = "data:image/png;base64," + base64String;
            ImgThump.Visible = true;

            ObjBar.ImgBarCode = buffer1;
            ObjBar.ImagLength = buffer1.Length;
            string str = ObjBar.ManipulateData("N") as string;
        }
        LblInfo.Text = iCnt.ToString() + " Completed";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ObjBar.ID = 1;
        DataSet ds = ObjBar.ManipulateData("S") as DataSet;
        ObjBar.GetDataRow("1", ds.Tables[0]);
        byte[] buffer1 = ObjBar.ImgBarCode;
        string base64String = Convert.ToBase64String(buffer1, 0, buffer1.Length);
        Img1.Src = "data:image/png;base64," + base64String;
        Img1.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        PictureBox pic = new PictureBox();
        ObjBar.BarCode = ObjBar.FnIsNumeric(TxtFrm.Text).ToString() + "CH1";
        ObjBar.CompanyId = 1;
        ObjBar.FnGenerateBarCodeNew(pic, true);
        string strPath = Server.MapPath(Request.ApplicationPath) + "\\AttachFiles\\" + "IMELT12345.jpg";
        pic.Image.Save(strPath);
        byte[] buffer1 = null;
        if (strPath.Trim().Length > 0)
        {
            FileStream imageStream1 = new FileStream(strPath.Trim(), FileMode.Open, FileAccess.Read);
            BinaryReader mbr1 = new BinaryReader(imageStream1);
            buffer1 = new byte[imageStream1.Length];
            mbr1.Read(buffer1, 0, Convert.ToInt32(imageStream1.Length));
            imageStream1.Close();
        }
        else
        {
            buffer1 = new byte[0];
        }
        string base64String = Convert.ToBase64String(buffer1, 0, buffer1.Length);
        ImgThump0.Src = "data:image/png;base64," + base64String;
        ImgThump0.Visible = true;

        ObjBar.ImgBarCode = buffer1;
        ObjBar.ImagLength = buffer1.Length;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}