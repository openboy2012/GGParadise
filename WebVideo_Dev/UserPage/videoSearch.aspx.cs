using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using TeWebVideo.BLL;

public partial class UserPage_videoSearch : System.Web.UI.Page
{
    VideoBLL videobll = new VideoBLL();
    public static string typeName = null;
    public static string type = null;
    public static string ideal = null;
    public static string key = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            type = Request.QueryString["type"];
            if (type != null)
            {
                switch (type)
                {
                    case "film":
                        {
                            typeName = "所属类型：电影大片";
                        }
                        break;
                    case "cartoon":
                        {
                            typeName = "所属类型：动漫游戏";
                        }
                        break;
                    case "tv":
                        {
                            typeName = "所属类型：电视剧";
                        }
                        break;
                    case "humour":
                        {
                            typeName = "所属类型：幽默搞笑";
                        }
                        break;
                    case "music":
                        {
                            typeName = "所属类型：音乐MV";
                        }
                        break;
                    case "sport":
                        {
                            typeName = "所属类型：体育竞技";
                        }
                        break;
                }
                ideal = "0";
                key = string.Empty;
                VideoBind();
            }
            else
            {
                type = null;
                VideoBind();
            }
        }
    }

    public void VideoBind()
    {
        if (videobll.getVideoList(type, ideal, key).Rows.Count > 0)
        {
            this.AspNetPagerSearch.PageSize = 10;
            this.AspNetPagerSearch.RecordCount = videobll.getVideoList(type, ideal, key).Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = videobll.getVideoList(type, ideal, key).DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = this.AspNetPagerSearch.PageSize;
            pds.CurrentPageIndex = this.AspNetPagerSearch.CurrentPageIndex - 1;
            dlstVideoInfo.DataSource = pds;
            dlstVideoInfo.DataBind();
        }
        else
        {
            dlstVideoInfo.DataSource = null;
            dlstVideoInfo.DataBind();
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        key = this.txtKey.Value.Trim();
        VideoBind();
    }

    protected void AspNetPagerVideoInfo_PageChanged(object sender, EventArgs e)
    {
        VideoBind();
    }

}
