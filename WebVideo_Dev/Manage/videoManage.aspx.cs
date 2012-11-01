using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class Manage_videoManage : System.Web.UI.Page
{
    VideoBLL videobll = new VideoBLL();
    SysNotesBLL sysnotesbll = new SysNotesBLL();
    Common common = new Common();
    public static string typeName = null;
    public static string type = null;
    public static string ideal = null;
    public static string key = null;

    private static string userName = null;
    private static string ip = null;
    private static string privilege = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Manage/login.aspx");
        }
        URegModel u = Session["userName"] as URegModel;
        if (int.Parse(u.Privilege) == 1 && Request["type"] != "auditing")
        {
            Response.Redirect("~/Manage/right.html");
        }
        ip = Request.UserHostAddress.ToString();
        userName = u.userName;
        privilege = u.Privilege;
        if (!IsPostBack)
        {
            type = Request["type"];
            if (type != null)
            {
                this.dropVideoType.Enabled = false;
                ideal = "0";
                key = "";
                this.ibtnSearch.Enabled = true;
                switch (type)
                {
                    case "film":
                        {
                            this.lblUrlAddress.Text = "电影";
                            this.dropVideoType.SelectedIndex = 3;
                        }
                        break;
                    case "cartoon":
                        {
                            this.lblUrlAddress.Text = "动漫";
                            this.dropVideoType.SelectedIndex = 6;
                        }
                        break;
                    case "tv":
                        {
                            this.lblUrlAddress.Text = "电视剧";
                            this.dropVideoType.SelectedIndex = 5;
                        }
                        break;
                    case "humour":
                        {
                            this.lblUrlAddress.Text = "幽默";
                            this.dropVideoType.SelectedIndex = 1;
                        }
                        break;
                    case "music":
                        {
                            this.lblUrlAddress.Text = "音乐";
                            this.dropVideoType.SelectedIndex = 4;
                        }
                        break;
                    case "sport":
                        {
                            this.lblUrlAddress.Text = "体育";
                            this.dropVideoType.SelectedIndex = 2;
                        }
                        break;
                    default:
                        {
                            this.lblUrlAddress.Text = "视频审核";
                            this.dropVideoType.SelectedItem.Text = "视频审核";
                            this.dropOrderBy.Enabled = false;
                            this.ibtnSearch.Enabled = false;
                            this.btnPass.Visible = true;
                            ideal = "Auditing";
                        }
                        break;
                }
                typeName = this.dropVideoType.SelectedItem.Text;
                VideoBind();
            }
            VideoBind();
        }

    }

    public void VideoBind()
    {
        if (videobll.getVideoList(type, ideal, key).Rows.Count > 0)
        {
            this.btnPass.Enabled = true;
            this.btnDelete.Enabled = true;
            this.AspNetPagerVideoInfo.PageSize = 15;
            this.AspNetPagerVideoInfo.RecordCount = videobll.getVideoList(type, ideal, key).Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = videobll.getVideoList(type, ideal, key).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = this.AspNetPagerVideoInfo.PageSize;
            pds.CurrentPageIndex = this.AspNetPagerVideoInfo.CurrentPageIndex - 1;
            dlstVideoInfo.DataSource = pds;
            dlstVideoInfo.DataBind();
        }
        else
        {
            dlstVideoInfo.DataSource = null;
            dlstVideoInfo.DataBind();
            this.btnDelete.Enabled = false;
            this.btnPass.Enabled = false;
            ScriptManager.RegisterStartupScript(this.upnlVideoManage, this.GetType(), "", "document.getElementById('checkAll').disabled=true;", true);
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        type = this.dropVideoType.SelectedValue;
        ideal = this.dropOrderBy.SelectedValue;
        key = this.txtKey.Text.Trim();
        if (type == "0")
        {
            ScriptManager.RegisterStartupScript(this.upnlVideoManage, this.GetType(), "", "alert('请选择信息类型');", true);
        }
        else
        {
            VideoBind();
        }
    }

    protected void AspNetPagerVideoInfo_PageChanged(object sender, EventArgs e)
    {
        VideoBind();
    }

    protected void dropVideoType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ibtnSearch.Enabled = true;
        this.txtKey.Focus();
    }

    protected void btnPass_Click(object sender, EventArgs e)
    {
        int n = 0;
        for (int i = 0; i < this.dlstVideoInfo.Items.Count; i++)
        {
            HtmlInputCheckBox cbox = (HtmlInputCheckBox)dlstVideoInfo.Items[i].FindControl("chkId");
            if (cbox.Checked)
            {
                HtmlInputHidden hdnId = (HtmlInputHidden)dlstVideoInfo.Items[i].FindControl("hdnId");
                string id = hdnId.Value;
                string fileName = Server.MapPath(videobll.getVideoInfo(id).videoPath);
                if (common.fixFlvDuration(fileName))
                {
                    if (videobll.videoPass(id))
                    {
                        n++;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.upnlVideoManage, this.GetType(), "", "alert('通过视频审核时发生异常');", true);
                    break;
                }
            }
        }
        if (n > 0)
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "成功通过了" + n + "个视频的审核", 1);
        }
        else
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "视频审核通过过程发生异常", 1);
        }
        VideoBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        for (int i = 0; i < this.dlstVideoInfo.Items.Count; i++)
        {
            HtmlInputCheckBox cbox = (HtmlInputCheckBox)dlstVideoInfo.Items[i].FindControl("chkId");
            if (cbox.Checked)
            {
                HtmlInputHidden hdnId = (HtmlInputHidden)dlstVideoInfo.Items[i].FindControl("hdnId");
                string id = hdnId.Value;
                string imagePath = Server.MapPath(videobll.getVideoInfo(id).videoPicture.ToString());
                bool a = Common.doFileDelete(imagePath);
                string videoPath = Server.MapPath(videobll.getVideoInfo(id).videoPath.ToString());
                bool b = Common.doFileDelete(videoPath);
                if (a && b)
                {
                    if (videobll.videoDelete(id))
                    {
                        n++;
                    }
                }
            }
        }
        if (n > 0)
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "成功删除了" + n + "个视频", 2);
            string jscript = "alert('成功删除" + n + "个视频');";
            ScriptManager.RegisterStartupScript(this.upnlVideoManage, this.GetType(), "", jscript, true);
        }
        else
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "删除视频发生异常", 2);
            ScriptManager.RegisterStartupScript(this.upnlVideoManage, this.GetType(), "", "alert('删除视频发生异常');", true);
        }
        VideoBind();
    }
    protected void dropOrderBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtKey.Focus();
    }
}
