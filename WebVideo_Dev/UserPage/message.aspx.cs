using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class UserPage_message : System.Web.UI.Page
{
    UserBLL userBLL = new UserBLL();
    Common common = new Common();
    URegModel urm = new URegModel();
    UInfoModel userInfo = new UInfoModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        string cmd = null;
        string msgid = null;
        cmd = Request["cmd"];
        lbtnUrl.Text = Request.Cookies["url"].Value;
        string url = lbtnUrl.Text;
        switch (cmd)
        {
            case "quit":
                {
                    lblMsg.Text = "退出成功，正在返回之前的页面……";
                    Session.Clear();
                }
                break;
            case "login":
                {
                    urm.userName = Request["uid"];
                    urm.userPass = Request["pwd"];
                    lblMsg.Text = checkLogin(urm);
                }
                break;
            case "upload":
                {
                    msgid = Request["msgid"];
                    if (msgid == "1")
                    {
                        lblMsg.Text = "视频上传失败，失败原因：视频截图发生错误！";
                    }
                    else if (msgid == "2")
                    {
                        lblMsg.Text = "视频上传失败，失败原因：视频格式转化发生错误！";
                    }
                    else if (msgid == "3")
                    {
                        lblMsg.Text = "视频上传成功，恭喜您获得10个网站积分！";
                        userInfo = userBLL.getUInfo(Request.QueryString["uid"]);
                        Session["userInfo"] = userInfo;
                    }
                    else
                    {
                        lblMsg.Text = "视频上传失败，失败原因：系统发生未知错误";
                    }
                }
                break;
            default: lblMsg.Text = "系统出现错误";
                break;
        }
        string JSCode = " <script>setTimeout('Load();', 5000);function Load() {window.location.href ='" + url + "';}</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", JSCode);
    }

    private string checkLogin(URegModel urM)
    {
        string msg = null;
        if (userBLL.login(urM))
        {
            if (userBLL.getUReg(urM.userName)._Lock == "0")
            {
                userInfo = userBLL.getUInfo(urM.userName);
                Session["userInfo"] = userInfo;
                msg = "登录成功，正在返回登录前的页面，请稍后……";
            }
            else
            {
                msg = "您已经成功登陆，但您的账户已经被锁定，如有疑问，请联系网站管理员！";
            }
        }
        else
        {
            msg = "登录失败！用户名或者密码错误";
        }
        return msg;
    }

    protected void lbtnUrl_Click(object sender, EventArgs e)
    {
        string url = lbtnUrl.Text;
        Response.Redirect(url);
    }
}
