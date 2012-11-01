using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class UserPage_indexPage : System.Web.UI.Page
{
    VideoBLL videobll = new VideoBLL();
    AdminBLL adminbll = new AdminBLL();
    public static BulletinModel blm = new BulletinModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        dlstTopClick.DataSource = videobll.getClickTop();
        dlstTopClick.DataBind();
        dlstHumour.DataSource = videobll.getVideoList("humour");
        dlstHumour.DataBind();
        dlstCartoon.DataSource = videobll.getVideoList("cartoon");
        dlstCartoon.DataBind();
        dlstFilm.DataSource = videobll.getVideoList("film");
        dlstFilm.DataBind();
        dlstSport.DataSource = videobll.getVideoList("sport");
        dlstSport.DataBind();
        dlstMusic.DataSource = videobll.getVideoList("music");
        dlstMusic.DataBind();
        dlstTV.DataSource = videobll.getVideoList("tv");
        dlstTV.DataBind();
        blm = adminbll.getBulletin();
        if (Session["userInfo"] != null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').show();$('#lBot').show();</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').hide();$('#lBot').hide();</script>");
        }
    }
}
