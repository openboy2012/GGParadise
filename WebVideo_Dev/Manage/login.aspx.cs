using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;
public partial class Manage_login : System.Web.UI.Page
{
    UserBLL userbll = new UserBLL();
    Common common = new Common();
    URegModel urm = new URegModel();
    SysNotesBLL sysnotesbll = new SysNotesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["userName"] = null;
        }
    }
    protected void ibtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string ip = Request.UserHostAddress.ToString();
        string code = Request.Cookies["ImageV"].Value.ToLower();
        urm.userName = this.txtUserName.Value.Trim();
        urm.userPass = common.Encrypt(this.txtPwd.Value.Trim());
        string getcode = this.txtCode.Value.ToLower();
        if (getcode == code)
        {
            if (userbll.login(urm))
            {
                URegModel u = userbll.getUReg(this.txtUserName.Value.Trim());
                if (int.Parse(u.Privilege) > 0)
                {
                    Session["userName"] = u;
                    sysnotesbll.sysNotesAdd(u.userName, u.Privilege, ip, null, 0);
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    this.lblMsg.Text = "权限级别不足，无法进行系统管理";
                }
            }
            else
            {
                this.lblMsg.Text = "用户名或密码错误！";
                this.txtUserName.Value = string.Empty;
                this.txtPwd.Value = string.Empty;
                this.txtCode.Value = string.Empty;
                this.txtUserName.Focus();
            }
        }
        else
        {
            this.lblMsg.Text = "验证码错误！";
            this.txtCode.Value = string.Empty;
        }
    }
}
