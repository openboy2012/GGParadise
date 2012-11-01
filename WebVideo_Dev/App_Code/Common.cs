using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common
{

    #region 获取WebConfiguation配置

    //获取转换工具路径；
    public string ffmpegtool = ConfigurationManager.AppSettings["ffmpeg"];
    //获取时间修复工具路径；
    public string flvmditool = ConfigurationManager.AppSettings["flvmdi"];
    //获取视频的文件夹名；
    public string upFile = ConfigurationManager.AppSettings["upFile"] + "/";
    //获取图片文件的文件夹名；
    public string imgFile = ConfigurationManager.AppSettings["imgFile"] + "/";
    //获取转换以后文件的文件夹名；
    public string playFile = ConfigurationManager.AppSettings["playFile"] + "/";
    //文件图片大小；
    public string sizeOfImg = ConfigurationManager.AppSettings["imgSize"];
    //文件大小；
    public string widthOfFile = ConfigurationManager.AppSettings["widthSize"];
    public string heightOfFile = ConfigurationManager.AppSettings["heightSize"];

    #endregion

    #region 字符串处理静态方法

    //截取文本字符串
    public static string interceptstr(string str, int len)
    {
        if (str.Length > len)
        {
            str = str.Replace(str.Substring(len), "");
        }
        return str;
    }

    //替换文本字符串
    public static string displayFormat(string str)
    {
        str = str.Replace("\n", "<br>");
        str = str.Replace(" ", "&nbsp;");
        return str;
    }

    #endregion

    #region 视频文件转换方法

    //获取文件扩展名
    public string getExtension(string fileName)
    {
        int i = fileName.LastIndexOf(".") + 1;
        string Name = fileName.Substring(i);
        return Name;
    }

    /// <summary>
    /// 视频格式转化
    /// </summary>
    /// <param name="fileName">文件名</param>
    /// <param name="playFile">播放路径</param>
    /// <param name="imgFile">截图路径</param>
    /// <returns>返回真或假</returns>
    public bool changeVideoType(string fileName, string playFile)
    {
        bool flag = false;
        string ffmpeg = System.Web.HttpContext.Current.Server.MapPath("~/" + ffmpegtool);
        if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
        {
            return flag;
        }
        else
        {
            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");
            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = "-i " + fileName + " -ab 64 -ar 22050 -r 29.97 -s " + widthOfFile + "x" + heightOfFile + " -qscale 6 " + flv_file;
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            System.Threading.Thread.Sleep(3000);
            if (System.IO.File.Exists(flv_file))
            {
                flag = true;
            }
            return flag;
        }
    }

    /// <summary>
    /// 抓图
    /// </summary>
    /// <param name="fileName">源文件路径</param>
    /// <param name="imgFile">图片路径</param>
    /// <returns></returns>
    public bool catchImg(string fileName, string imgFile)
    {
        bool flag = false;
        string ffmpeg = System.Web.HttpContext.Current.Server.MapPath("~/" + ffmpegtool);
        if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
        {
            return flag;
        }
        else
        {
            string flv_img = imgFile + ".jpg";
            string FlvImgSize = sizeOfImg;
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.Arguments = " -i " + fileName + " -y -f image2 -ss 2 -t 0.001 -s " + FlvImgSize + " " + flv_img;
            try
            {
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            System.Threading.Thread.Sleep(2000);
            if (System.IO.File.Exists(flv_img))
            {
                flag = true;
            }
            return flag;
        }
    }

    /// <summary>
    /// 修复转换后的FLV文件时间轴
    /// </summary>
    /// <param name="fileName">FLV文件名</param>
    /// <returns></returns>
    public bool fixFlvDuration(string fileName)
    {
        string flvmdi = System.Web.HttpContext.Current.Server.MapPath("~/" + flvmditool);
        if ((!System.IO.File.Exists(flvmdi)) || (!System.IO.File.Exists(fileName)))
        {
            return false;
        }
        else
        {
            System.Diagnostics.ProcessStartInfo fixflvdurStartInfo = new System.Diagnostics.ProcessStartInfo(flvmdi);
            fixflvdurStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            fixflvdurStartInfo.Arguments = " " + fileName;
            try
            {
                System.Diagnostics.Process.Start(fixflvdurStartInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }

    #endregion

    #region 视频播放方法

    /// <summary>
    /// 视频播放
    /// </summary>
    /// <param name="url">视频地址</param>
    /// <param name="width">视频宽度</param>
    /// <param name="height">视频高度</param>
    /// <returns></returns>
    public string GetFlashText(string url, int width, int height)
    {
        string strTmp = url.ToLower();
        if (strTmp.EndsWith("flv"))
        {
            return flvPlay(url, width, height);
        }
        else
        {
            return "视频格式不正确";
        }
    }

    /// <summary>
    /// FLV格式视频播放
    /// </summary>
    /// <param name="url">视频地址</param>
    /// <param name="width">视频宽度</param>
    /// <param name="height">视频高度</param>
    /// <returns></returns>
    private string flvPlay(string url, int width, int height)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<object codeBase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" ");
        sb.Append(" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" ");
        sb.Append(" height=\"" + height + "\" width=\"" + width + "\" >");
        sb.Append("<param name=\"FlashVars\" value=\"vcastr_file=" + url + "&LogoText=GGParadise&BufferTime=3\">");
        sb.Append("<param name=\"Movie\" value=\"../Common/tool/Flvplayer.swf\">");
        sb.Append("<param name=\"Quality\" value=\"High\">");
        sb.Append("<param name=\"allowFullScreen\" value=\"true\">");
        sb.Append("<embed src=\"../Common/tool/Flvplayer.swf\" flashvars=\"vcastr_file=" + url + "&LogoText=GGParadise;\" height=\"" + height + "\" width=\"" + width + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" menu=\"false\">");
        sb.Append("</embed>");
        sb.Append("</object>");
        return sb.ToString();
    }
    #endregion

    #region 字符加密方法(用户密码)

    /// <summary>
    /// 加密类
    /// </summary>
    /// <param name="str">加密的字段</param>
    /// <returns></returns>
    public string Encrypt(string str)
    {
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
        SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
        byte[] hash = sha.ComputeHash(buffer);
        StringBuilder passwordBuilder = new StringBuilder();
        foreach (byte hashByte in hash)
        {
            passwordBuilder.Append(hashByte.ToString("x2"));
        }
        return passwordBuilder.ToString();
    }

    #endregion

    #region AES加密

    public static string EncryptID(string toEncrypt)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateEncryptor();//using System.Security.Cryptography;   
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length).Replace("+","%2B");
    }

    #endregion AES加密

    #region AES解密

    public static string DecryptID(string toDecrypt)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = rDel.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return UTF8Encoding.UTF8.GetString(resultArray);
    }

    #endregion AES解密

    #region 时间转换方法
    /// <summary>
    /// 转换时间类
    /// </summary>
    /// <param name="date">要转换的时间</param>
    /// <returns></returns>
    public static string getIsDate(string date)
    {
        //转换时间
        DateTime isDate = Convert.ToDateTime(date);
        //获取当前时间
        DateTime nowDate = DateTime.Now;
        //获取两个时间的差
        TimeSpan ts = nowDate - isDate;
        //将时间差转换为分钟
        int minutes = Convert.ToInt32(ts.TotalSeconds) / 60;
        if (minutes == 0)
        {
            return "60秒内";
        }
        else if (minutes > 0 && minutes < 60)
        {
            return "1小时以内";
        }
        else if (minutes > 60 && minutes < 1440)
        {
            return Convert.ToString(minutes / 60) + "小时前";
        }
        else if (minutes > 1440 && minutes < 43200)
        {
            return Convert.ToString(minutes / 1440) + "天前";
        }
        else if (minutes > 43200 && minutes < 518400)
        {
            return Convert.ToString(minutes / 43200) + "月前";
        }
        else
        {
            date = date.Substring(0, 10);
            return date;
        }
    }
    #endregion

    #region 删除视频源文件

    public static bool doFileDelete(string fileName)
    {
        bool flag = false;
        System.IO.FileInfo FI = new System.IO.FileInfo(@fileName);
        if (FI.Exists)
        {
            FI.Delete();
            flag = true;
        }
        return flag;
    }

    public void clearUpFile()
    {
        string NowTime = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        string fileUrl = System.Web.HttpContext.Current.Server.MapPath("~/" + upFile);
        DirectoryInfo dires = new DirectoryInfo(@fileUrl);
        FileInfo[] files = dires.GetFiles();
        foreach (FileInfo f in files)
        {
            string getName = f.Name.Substring(0, 18);
            if (long.Parse(getName) < (long.Parse(NowTime) - 18000000))
            {
                f.Delete();
            }
        }
    }
    #endregion

}

