using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class UserPage_play : System.Web.UI.Page
{
    public static int playSum;     //保存视频点击率
    public static int flower;      //保存视频被顶的次数
    public static int tile;        //保存视频被踩的次数
    public static string videoDate;   //保存视频发布时间
    public static string userName;      //发布人
    public static string videoTitle;  //视频名称
    public static string videoContent; //视频内容
    public static string videoType;   //视频类型
    public static string link; //视频路径
    public static string id;//视频ID
    public static string loginId;//登录用户
    public static int count;//评论数目
    public static string LoginedUserName = null;
    public static string UserScore = null;

    VideoBLL videobll = new VideoBLL();
    UserBLL userbll = new UserBLL();
    VideoInfoModel videoInfoModel = new VideoInfoModel();
    VideoIdeaModel videoIdeaModel = new VideoIdeaModel();
    Common common = new Common();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userInfo"] == null)
        {
            loginId = "【游客】";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').hide();$('#lBot').hide();</script>");
        }
        else
        {
            UInfoModel uinfo = Session["userInfo"] as UInfoModel;
            loginId = uinfo.userName;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').show();$('#lBot').show();</script>");
        }
        id = Request["id"];
        id = Common.DecryptID(id);
        if (!IsPostBack)
        {
            videobll.addPlaySum(id);
            videoPlay();
        }
        commentBind();
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
        userName = videoInfoModel.userName;
        flower = videoInfoModel.Flower;
        tile = videoInfoModel.Tile;
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
        this.ltlPlay.Text = common.GetFlashText(link, 540, 405);
    }

    protected void commentBind()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = videobll.getVideoIdea(id).DefaultView;
        pds.AllowPaging = true;
        count = videobll.getVideoIdea(id).Rows.Count;

        this.AspNetPagerVideoInfo.RecordCount = count;
        pds.CurrentPageIndex = this.AspNetPagerVideoInfo.CurrentPageIndex - 1;
        pds.PageSize = this.AspNetPagerVideoInfo.PageSize;

        dlstComment.DataSource = pds;
        dlstComment.DataBind();
    }

    private void updateEval()
    {
        flower = videobll.getVideoInfo(id).Flower;
        tile = videobll.getVideoInfo(id).Tile;
    }

    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        string Code = Request.Cookies["ImageV"].Value.ToLower();
        string getCode = this.txtCode.Value.ToLower();
        string ip = Request.UserHostAddress.ToString();
        videoIdeaModel.Id = id;
        videoIdeaModel.userName = loginId;
        videoIdeaModel.Ip = ip;
        videoIdeaModel.Contents = this.txtComment.Text;
        if (getCode == Code)
        {
            if (videobll.addComment(videoIdeaModel))
            {
                ScriptManager.RegisterStartupScript(upnlComment, this.GetType(), "", "alert('评论发布成功!');", true);
                this.txtComment.Text = "";
                this.txtCode.Value = "";
                commentBind();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(upnlComment, this.GetType(), "", "alert('验证码错误!');", true);
            this.txtCode.Value = "";
            this.txtCode.Focus();
        }
        ScriptManager.RegisterStartupScript(upnlComment, this.GetType(), "", "document.getElementById('imgCode').onclick", true);
    }

    protected void ibtnFlower_Click(object sender, ImageClickEventArgs e)
    {
        string ip = Request.UserHostAddress.ToString();
        if (videobll.isExistPoll(ip, id))
        {
            ScriptManager.RegisterStartupScript(upnlEval, this.GetType(), "警告", "alert('此IP已经投过票，一个视频只可以投一次!');", true);
        }
        else
        {
            if (videobll.addFlower(id))
            {
                videobll.addPoll(ip, id);
                ScriptManager.RegisterStartupScript(upnlEval, this.GetType(), "提示", "alert('投票成功!');", true);
            }
        }
        updateEval();
    }

    protected void ibtnTile_Click(object sender, ImageClickEventArgs e)
    {
        string ip = Request.UserHostAddress.ToString();
        if (videobll.isExistPoll(ip, id))
        {
            ScriptManager.RegisterStartupScript(upnlEval, this.GetType(), "警告", "alert('此IP已经投过票，一个视频只可以投一次!');", true);
        }
        else
        {
            if (videobll.addTile(id))
            {
                videobll.addPoll(ip, id);
                ScriptManager.RegisterStartupScript(upnlEval, this.GetType(), "提示", "alert('投票成功!');", true);
            }
        }
        updateEval();
    }

    protected void AspNetPagerVideoInfo_PageChanging(object sender, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPagerVideoInfo.CurrentPageIndex = e.NewPageIndex;
        commentBind();
    }
}
