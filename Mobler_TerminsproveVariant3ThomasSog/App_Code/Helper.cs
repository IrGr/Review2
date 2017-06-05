using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Metoden, der skalerer billeder
    /// http://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
    /// </summary>
    /// <param name="image"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
    {
        Image srcImage = image;
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(srcImage.HorizontalResolution, srcImage.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }


        return destImage;
    }


    /// <summary>
    /// Bruges til at generer md5hash udfra input
    ///http://dotnet-snippets.com/snippet/generate-md5-hash/644
    /// </summary>
    /// <param name="textToHash"></param>
    /// <returns></returns>
    public static string GetMD5Hash(String textToHash)
    {
        //Check wether data was passed
        if ((textToHash == null) || (textToHash.Length == 0))
        {
            return String.Empty;
        }

        //Calculate MD5 hash. This requires that the string is splitted into a byte[].
        MD5 md5 = new MD5CryptoServiceProvider();

        byte[] hashed = Encoding.Default.GetBytes(textToHash);
        byte[] result = md5.ComputeHash(hashed);

        //Convert result back to string.
        return System.BitConverter.ToString(result);

    }


    public static bool ErLoggetInd()
    {
        if (HttpContext.Current.Session["brugernavn"] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #region LogUd
    public static void LogUd()
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }
    #endregion


}