using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.MODEL;
public partial class loginedControl : System.Web.UI.UserControl
{
    public static UInfoModel uinfo = new UInfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userInfo"]!=null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#UserLogined').show();</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').show();$('#lBot').show();</script>");
            uinfo = Session["userInfo"] as UInfoModel;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#UserLogined').hide();</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#lTop').hide();$('#lBot').hide();</script>");
        }
    }
}
