using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;

public partial class UserPage_getPwd : System.Web.UI.Page
{
    public static string userName = null;
    UserBLL userbll = new UserBLL();
    Common common = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNext1_Click(object sender, EventArgs e)
    {
        userName = this.txtUserName.Value.Trim();
        string Email = this.txtEmail.Value.Trim();
        if (userbll.checkUser(userName))
        {
            if (Email == userbll.getUReg(userName).Email)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#userIdDiv').hide();$('#passProtectDiv').show();</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Email地址输入不正确');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名不存在');</script>");
        }
    }
    protected void btnNext2_Click(object sender, EventArgs e)
    {
        string question = this.hdnQuestion.Value;
        string answer = this.txtAnswer.Value;
        if (question == userbll.getUReg(userName).passQuestion && answer == userbll.getUReg(userName).passAnswer)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#passProtectDiv').hide();$('#userIdDiv').hide();$('#pwdDiv').show();</script>");
        }
        else 
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#passProtectDiv').show();$('#userIdDiv').hide();alert('密保问题或者密保答案错误');</script>");
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string pwd = common.Encrypt(this.txtPassword.Value.Trim());
        if (userbll.UpdatePass(userName, pwd)) 
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$('#passProtectDiv').hide();$('#userIdDiv').hide();$('#pwdDiv').show();alert('密码修改成功');location.href='indexPage.aspx';</script>");
        }
    }
}
