using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO;
using LOTUS_GENERAL;
using System.Text.RegularExpressions;
using System.Drawing;
using LOTUS_DATA;
using System.Collections;


public class ClsBarCode : ClsCommonBaseMaster
{
    private int nImagLength, ntrid;
    private byte[] bImgBarCode;
    private string cBarCode;
    public ClsBarCode() : base("", "ID", 0, 0, 0,0)
    {
    }
    public string BarCode
    {
        get
        {
            if (cBarCode  == null)
            {
                cBarCode = "";
            }
            return cBarCode;
        }
        set
        {
            cBarCode = value;
        }
    }
    public int ImagLength
    {
        get
        {
            return nImagLength;
        }
        set
        {
            nImagLength = value;
        }
    }
    public int TrId
    {
        get
        {
            return ntrid;
        }
        set
        {
            ntrid = value;
        }
    }
    public byte[] ImgBarCode
    {
        get
        {
            return bImgBarCode;
        }
        set
        {
            bImgBarCode = value;
        }
    }
    public byte[] FnConvertPicBoxImageToByte(System.Windows.Forms.PictureBox pbImage)
    { 
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }
    public void FnGetBarCode(System.Windows.Forms.PictureBox pbImage)
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        int W = 250;// Convert.ToInt32(this.txtWidth.Text.Trim());
        if (BarCode.Trim().Length > 7)
        {
            W = 275;
        }
        if (BarCode.Trim().Length > 8)
        {
            W = 300;
        }
        int H = 50;// Convert.ToInt32(this.txtHeight.Text.Trim());
        BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.LEFT;
        //barcode alignment
        Align = BarcodeLib.AlignmentPositions.LEFT;
        /* switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
         {
             case "left": Align = BarcodeLib.AlignmentPositions.LEFT; break;
             case "right": Align = BarcodeLib.AlignmentPositions.RIGHT; break;
             default: Align = BarcodeLib.AlignmentPositions.CENTER; break;
         }//switch
         */
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
        type = BarcodeLib.TYPE.LOGMARS;
        /* 
         * switch (cbEncodeType.SelectedItem.ToString().Trim())
         {
             case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
             case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
             case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
             case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
             case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
             case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
             case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
             case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
             case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
             case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
             case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
             case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
             case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
             case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
             case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
             case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
             case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
             case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
             case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
             case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
             case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
             case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
             case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
             case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
             default: MessageBox.Show("Please specify the encoding type."); break;
         }//switch            
         */
        try
        {
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.IncludeLabel = false;// this.chkGenerateLabel.Checked;
                b.Alignment = Align;
                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);// this.cbRotateFlip.SelectedItem.ToString(), true);
                //label alignment and position
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                /*
                 switch (this.cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
                {
                    case "BOTTOMLEFT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT; break;
                    case "BOTTOMRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT; break;
                    case "TOPCENTER": b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER; break;
                    case "TOPLEFT": b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT; break;
                    case "TOPRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT; break;
                    default: b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER; break;
                }//switch
                 */

                //===== Encoding performed here =====
                //pictureBox1 .Image = b.Encode(type, this.textBox1.Text.Trim(), this.btnForeColor.BackColor, this.btnBackColor.BackColor, W, H);
                pbImage.Image = b.Encode(type, BarCode.Trim(), Color.Black, Color.White, W, H);
                //===================================
                //show the encoding time
                //this.lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";
                //txtEncoded.Text = b.EncodedValue;
                // tsslEncodedType.Text = "Encoding Type: " + b.EncodedType.ToString();
            }//if
            pbImage.Width = pbImage.Image.Width;
            pbImage.Height = pbImage.Image.Height;
            //reposition the barcode image to the middle
            //pictureBox1.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
        }//try
        catch (Exception ex)
        {
            throw ex;
        }//catch
    }
    public void FnGenerateBarCode(System.Windows.Forms.PictureBox pbImage, bool PrmIsLabel)
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        int W = 180;// 225;// Convert.ToInt32(this.txtWidth.Text.Trim());
        int H = 75;// 50;// Convert.ToInt32(this.txtHeight.Text.Trim());
        BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;//.LEFT;
        //barcode alignment
        Align = BarcodeLib.AlignmentPositions.CENTER;
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
        type = BarcodeLib.TYPE.LOGMARS; //TELEPEN - 21-01-2011 , LOGMARS - 20-01-11 , CODE128B - 19-01-2011 , CODE128A - 18-01-2011 , CODE128 - 17-01-2011 , CODE93- 16-01-2011 , CODE39Extended; 15-01-2011 , CODE39;-14-01-2011 , CODE11; - Date 13-01-2011 
        try
        {
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.IncludeLabel = PrmIsLabel;// this.chkGenerateLabel.Checked;
                b.Alignment = Align;
                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);// this.cbRotateFlip.SelectedItem.ToString(), true);
                //label alignment and position
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//.BOTTOMCENTER;
                //===== Encoding performed here =====
                pbImage.Image = b.Encode(type, BarCode.Trim().Replace("/", "-"), Color.Black, Color.White, W, H);
                //===================================
            }//if
            pbImage.Width = pbImage.Image.Width;
            pbImage.Height = pbImage.Image.Height;
        }//try
        catch (Exception ex)
        {
            throw ex;
        }//catch
    }
    public void FnGenerateBarCodeNew(System.Windows.Forms.PictureBox pbImage, bool PrmIsLabel)
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        int W = 180;// 225;// Convert.ToInt32(this.txtWidth.Text.Trim());
        int H = 50;// 50;// Convert.ToInt32(this.txtHeight.Text.Trim());
        BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;//.LEFT;
        //barcode alignment
        Align = BarcodeLib.AlignmentPositions.CENTER;
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
        type = BarcodeLib.TYPE.CODE128A; //TELEPEN - 21-01-2011 , LOGMARS - 20-01-11 , CODE128B - 19-01-2011 , CODE128A - 18-01-2011 , CODE128 - 17-01-2011 , CODE93- 16-01-2011 , CODE39Extended; 15-01-2011 , CODE39;-14-01-2011 , CODE11; - Date 13-01-2011 
        try
        {
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.IncludeLabel = PrmIsLabel;// this.chkGenerateLabel.Checked;
                b.Alignment = Align;
                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);// this.cbRotateFlip.SelectedItem.ToString(), true);
                //label alignment and position
                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;//.BOTTOMCENTER;
                //===== Encoding performed here =====
                pbImage.Image = b.Encode(type, BarCode.Trim().Replace("/", "-"), Color.Black, Color.White, W, H);
                //===================================
            }//if
            pbImage.Width = pbImage.Image.Width;
            pbImage.Height = pbImage.Image.Height;
        }//try
        catch (Exception ex)
        {
            throw ex;
        }//catch
    }
    //=========================
    public void GetDataRow(string PrmDataId, DataTable PrmDtRecord)
    {
        base.GetDataRow(PrmDataId, PrmDtRecord);
        DataRow drVal = (PrmDtRecord.Select("Id=" + PrmDataId.Trim() + "") as DataRow[])[0];
        BarCode = drVal["BarCode"].ToString().Trim();
        TrId = FnIsNumeric(drVal["TrId"].ToString().Trim());
        if (drVal["ImagLength"].ToString().Trim().Length > 0)
        {
            ImgBarCode = (byte[])((drVal["ImgBarCode"]));
        }
        else
        {
            ImgBarCode = new byte[0];
        }
    }
    public object ManipulateData(string PrmDbFlag)
    {
        base.ManipulateData(PrmDbFlag);
        ClsDBManager objDBManager = new ClsDBManager();
        objDBManager.DataSetting = DBSource.GENERAL;

        objFields.AddParameterFields("Prm_cBarCode", System.Data.DbType.String, BarCode);
        objFields.AddParameterFields("Prm_nTrId", System.Data.DbType.Int32, TrId);
        objFields.AddParameterFields("Prm_nImagLength", System.Data.DbType.Int32, ImagLength );
        objFields.AddParameterFields("Prm_cImgBarCode", System.Data.DbType.Binary, ImgBarCode);

        if (PrmDbFlag.Equals("S"))
        {
            return objDBManager.GetRecord("ADM_ProBarCodeReg", objFields) as DataSet;
        }
        else
        {
            ArrayList objRetArrList = new ArrayList(objDBManager.UpdateRecord("ADM_ProBarCodeReg", objFields));
            return objRetArrList[0].ToString();
        }
    }
}

