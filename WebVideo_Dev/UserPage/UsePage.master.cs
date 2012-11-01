using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class UsePage : System.Web.UI.MasterPage
{
    Common common = new Common();
    HttpCookie Url = new HttpCookie("url");
    protected void Page_Load(object sender, EventArgs e)
    {
        Url.Value = Request.Url.AbsoluteUri;
        Response.Cookies.Add(Url);
    }

    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string uid = username.Value;
        string pwd = common.Encrypt(password.Value.Trim());
        string redirectUrl = "~/UserPage/message.aspx?cmd=login&uid=" + uid + "&pwd=" + pwd;
        Response.Redirect(redirectUrl);
    }
}
