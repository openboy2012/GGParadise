using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;

public partial class UserPage_videoClass : System.Web.UI.Page
{
    public static string typeName = null;
    public static string type = null;
    VideoBLL videobll = new VideoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        type = Request["type"];
        switch (type)
        {
            case "film": typeName = "电影大片"; break;
            case "tv": typeName = "电视剧"; break;
            case "music": typeName = "歌曲MV"; break;
            case "cartoon": typeName = "动漫游戏"; break;
            case "humour": typeName = "幽默搞笑"; break;
            case "sport": typeName = "体育竞技"; break;
        }
        dlstNew.DataSource = videobll.getNewTop8(type);
        dlstNew.DataBind();
        dlstPlaySum.DataSource = videobll.getPlaySumTop8(type);
        dlstPlaySum.DataBind();
    }
}
