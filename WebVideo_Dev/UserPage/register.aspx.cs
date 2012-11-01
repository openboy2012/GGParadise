using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;
public partial class UserPage_register : System.Web.UI.Page
{
    URegModel urm = new URegModel();
    UInfoModel uim = new UInfoModel();
    Common comm = new Common();
    UserBLL userbll = new UserBLL();

    public static string ques = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.hdnValue.Value = this.hdnQuestion.Value;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string code = this.txtCode.Value.ToLower();
        string ValidateCode = Request.Cookies["ImageV"].Value.ToLower();
        if (code == ValidateCode)
        {
            urm.userName = this.txtUserName.Value;
            urm.userPass = comm.Encrypt(this.txtPassword.Value.Trim());
            urm.passQuestion = this.hdnQuestion.Value;
            ques = this.hdnQuestion.Value;
            urm.passAnswer = this.txtAnswer.Value;
            urm.Email = this.txtEmail.Value;
            if (userbll.checkUser(urm.userName))
            {
                this.lblError.Text = "该用户名已经存在";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>showRegMsgDiv();</script>");
            }
            else
            {
                if (userbll.newRegister(urm))
                {
                    uim.nickName = this.txtNickname.Value;
                    uim.userName = this.txtUserName.Value;
                    if (userbll.updateNickname(uim))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新用户注册成功！');location='indexPage.aspx' </script>");
                    }
                }
            }
        }
        else
        {
            this.lblError.Text = "验证码错误";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>showRegMsgDiv();</script>");
        }
    }
}
