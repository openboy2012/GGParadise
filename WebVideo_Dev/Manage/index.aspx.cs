using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;
public partial class Manage_index : System.Web.UI.Page
{
    public static string UserName = null;
    public static string Group = null;
    public static string Privilege = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLoginState("userName", "~/Manage/login.aspx");
    }

    private void CheckLoginState(string AttributeNameInSession, string Url)
    {
        if (Session[AttributeNameInSession] == null || Session[AttributeNameInSession].ToString() == "")
            Server.Transfer(Url);
        else
        {
            URegModel u = Session["userName"] as URegModel;
            Privilege = u.Privilege.Trim();
            UserName = u.userName;
            if (Privilege == "1")
            {
                Group = "[视频审核组]";
            }
            if (Privilege == "2")
            {
                Group = "[网站管理员]";
            }
            if (Privilege == "3")
            {
                Group = "[超级管理员]";
            }
        }
    }
}
