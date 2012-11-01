using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class Manage_play : System.Web.UI.Page
{
    public static int playSum;     //保存视频点击率
    public static int flower;      //保存视频被顶的次数
    public static int tile;        //保存视频被踩的次数
    public static string videoDate;   //保存视频发布时间
    public static string publishName;      //发布人
    public static string videoTitle;  //视频名称
    public static string videoContent; //视频内容
    public static string videoType;   //视频类型
    public static string link; //视频路径
    public static string id;//视频ID

    private static string userName = null;
    private static string ip = null;
    private static string privilege = null;

    VideoBLL videobll = new VideoBLL();
    VideoInfoModel videoInfoModel = new VideoInfoModel();
    Common comm = new Common();
    UserBLL userbll = new UserBLL();
    SysNotesBLL sysnotesbll = new SysNotesBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        id = Common.DecryptID(id);
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Manage/login.aspx");
        }
        URegModel u = Session["userName"] as URegModel;
        ip = Request.UserHostAddress.ToString();
        userName = u.userName;
        privilege = u.Privilege;
        if (int.Parse(u.Privilege) < 2 && videobll.getVideoInfo(id).Auditing == "1")
        {
            this.btnDelete.Visible = false;
        }
        if (!IsPostBack)
        {
            videoPlay();
        }
    }

    protected void videoPlay()
    {
        videoInfoModel = videobll.getVideoInfo(id);
        link = videoInfoModel.videoPath;
        playSum = videoInfoModel.playSum;
        videoTitle = videoInfoModel.videoTitle;
        videoContent = videoInfoModel.videoContent;
        videoDate = videoInfoModel.videoDate;
        videoType = videoInfoModel.videoType;
        publishName = videoInfoModel.userName;
        flower = videoInfoModel.Flower;
        tile = videoInfoModel.Tile;
        if (videoInfoModel.Auditing.ToString() == "1")
        {
            this.btnPass.Visible = false;
        }
        if (!link.StartsWith("http://"))
        {
            //获取当前的绝对路径
            string sss = Request.Url.AbsoluteUri;
            //查询"play.aspx"在字符串中的位置
            int idx = sss.IndexOf("play.aspx");
            //获取指定字符串
            sss = sss.Substring(0, idx);
            link = sss + link;
        }
        //显示播放器并可以播放视频
        this.ltlPlay.Text = comm.GetFlashText(link, 640, 480);
    }

    protected void btnPass_Click(object sender, EventArgs e)
    {
        string fileName = Server.MapPath(videobll.getVideoInfo(id).videoPath);
        if (comm.fixFlvDuration(fileName))
        {
            if (videobll.videoPass(id))
            {
                sysnotesbll.sysNotesAdd(userName, privilege, ip, "成功通过一个视频审核", 1);
                Page.Response.Redirect("videoManage.aspx");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('视频通过审核时发生异常');</script>");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string imagePath = Server.MapPath(videobll.getVideoInfo(id).videoPicture.ToString());
        bool a = Common.doFileDelete(imagePath);
        string videoPath = Server.MapPath(videobll.getVideoInfo(id).videoPath.ToString());
        bool b = Common.doFileDelete(videoPath);
        if (a && b)
        {
            if (videobll.videoDelete(id))
            {
                sysnotesbll.sysNotesAdd(userName, ip, privilege, "成功删除一个审核未通过的视频", 2);
                Page.Response.Redirect("videoManage.aspx");
            }
        }
    }
}
