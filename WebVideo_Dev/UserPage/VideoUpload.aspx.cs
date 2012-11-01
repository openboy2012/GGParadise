using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;
public partial class UserPage_VideoUpload : System.Web.UI.Page
{
    Common common = new Common();
    VideoBLL videobll = new VideoBLL();
    UserBLL userbll = new UserBLL();
    HttpCookie Url = new HttpCookie("url");
    public static UInfoModel uinfo = new UInfoModel();
    private static string ExtenName = null;
    private static string saveName = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.btnChangeExtension.Enabled = false;
        }
        if (Session["userInfo"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请您先登录！');location='indexPage.aspx' </script>");
        }
        else
        {
            uinfo = Session["userInfo"] as UInfoModel;
            Url.Value = Request.Url.AbsoluteUri;
            Response.Cookies.Add(Url);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        common.clearUpFile();
        string FileName = this.InputfileVideoUpload.FileName;//获取上传文件的全路径  
        ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名  
        saveName = DateTime.Now.ToString("yyyyMMddHHmmssffff");//获取存储名
        string SaveFileName = System.IO.Path.Combine(Request.PhysicalApplicationPath, common.upFile + saveName + ExtenName);//合并两个路径为上传到服务器上的全路径  
        if (this.InputfileVideoUpload.ContentLength > 0)
        {
            try
            {
                this.InputfileVideoUpload.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        this.btnChangeExtension.Enabled = true;
        this.btnUpload.Enabled = false;
    }

    protected void btnChangeExtension_Click(object sender, EventArgs e)
    {
        string title = this.txtVideoTitle.Value;
        string contents = this.txtVideoContent.Value;
        string types = this.dropVideoType.SelectedValue;

        string upFileName = Server.MapPath("~/" + common.upFile + saveName + ExtenName);
        string playFile = Server.MapPath("~/" + common.playFile + saveName);
        string imgFile = Server.MapPath("~/" + common.imgFile + saveName);

        if (common.catchImg(upFileName, imgFile))
        {
            if (ExtenName == ".flv")
            {
                //直接拷贝到播放文件夹下
                System.IO.File.Copy(upFileName, playFile + ".flv");
                doStore(saveName);
            }
            else
            {
                if (common.changeVideoType(upFileName, playFile))
                {
                    doStore(saveName);
                }
                else
                {
                    Page.Response.Redirect("message.aspx?cmd=upload&msgid=2");
                }
            }
        }
        else
        {
            Page.Response.Redirect("message.aspx?cmd=upload&msgid=1");
        }
        this.btnChangeExtension.Enabled = true;
    }

    private void doStore(string saveName)
    {
        VideoInfoModel vim = new VideoInfoModel();
        UInfoModel uim = new UInfoModel();
        vim.userName = uinfo.userName;
        vim.videoTitle = this.txtVideoTitle.Value;
        vim.videoContent = this.txtVideoContent.Value;
        vim.videoPath = "../" + common.playFile + saveName + ".flv";
        vim.videoPicture = "../" + common.imgFile + saveName + ".jpg";
        vim.videoType = this.dropVideoType.SelectedValue.ToString();
        if (userbll.insertVideo(vim))
        {
            uim.userName = uinfo.userName;
            uim.sumMark = "10";//上传一个视频加10个积分;
            userbll.addSumMark(uim);
            string redirect = "message.aspx?cmd=upload&msgid=3&uid=" + uinfo.userName;
            Page.Response.Redirect(redirect);
        }
    }
}
