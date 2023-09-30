using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
public partial class STUDENT_PhotoUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod()]
    public static bool SaveCapturedImage(string data)
    {
        string fileName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");

        //Convert Base64 Encoded string to Byte Array.
        byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);

        //Save the Byte Array as Image File.
        string filePath = HttpContext.Current.Server.MapPath(string.Format("~/UploadedFiles/Captures/{0}.jpg", fileName));
        File.WriteAllBytes(filePath, imageBytes);

        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-1MMBQG05\\SQLEXPRESS;Initial Catalog=WEBSIS;Integrated Security=True;");
        //con.Open();
        //SqlCommand cmd1 = new SqlCommand("Insert into TblImage(ImageName, ImagePath) VALUES('" + fileName + "','" + filePath + "')", con);

        //cmd1.ExecuteNonQuery();
        //con.Close();
        return true;


    }
}