using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class Manage_userManage : System.Web.UI.Page
{
    UserBLL userbll = new UserBLL();
    URegModel um = new URegModel();
    Common common = new Common();
    SysNotesBLL sysnotesbll = new SysNotesBLL();

    private static string userName = null;
    private static string ip = null;
    private static string privilege = null;

    public static string group = null;
    public static string cmd = null;
    public static string key = null;
    public static string UserId = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Manage/login.aspx");
        }
        URegModel u = Session["userName"] as URegModel;
        this.gdvLoginedAdminInfo.DataSource = userbll.getAdminInfo(u.userName);
        this.gdvLoginedAdminInfo.DataBind();
        userName = u.userName;
        privilege = u.Privilege;
        UserId = u.Id;
        ip = Request.UserHostAddress.ToString();
        if (!IsPostBack)
        {
            key = null;
            group = null;
            cmd = Request.QueryString["cmd"];
            this.ibtnSearch.Enabled = true;
            if (cmd == "admin")
            {
                this.lblUrlAddress.Text = "用户权限管理";
                this.dropIdea.SelectedValue = "1";
                this.dropGroup.Visible = true;
                this.btnSetPrivilege.Visible = true;
            }
            if (cmd == "user")
            {
                this.lblUrlAddress.Text = "用户信息管理";
                this.dropIdea.Enabled = true;
                this.txtKey.Visible = true;
                this.btnSetPass.Visible = true;
                this.btnDelete.Visible = true;
            }
            if (cmd == "lock")
            {
                this.lblUrlAddress.Text = "用户状态管理";
                this.dropIdea.SelectedValue = "0";
                this.btnSetStatus.Visible = true;
                this.txtKey.Visible = true;
            }
            if (privilege == "2")
            {
                this.dropGroup.Items.Add(new ListItem("普通用户", "0"));
                this.dropGroup.Items.Add(new ListItem("视频审核组", "1"));
                this.dropGroupSet.Items.Add(new ListItem("普通用户", "0"));
                this.dropGroupSet.Items.Add(new ListItem("视频审核组", "1"));
            }
            if (privilege == "3")
            {
                this.dropGroup.Items.Add(new ListItem("普通用户", "0"));
                this.dropGroup.Items.Add(new ListItem("视频审核组", "1"));
                this.dropGroup.Items.Add(new ListItem("网站管理员", "2"));
                this.dropGroup.Items.Add(new ListItem("超级管理员", "3"));
                this.dropGroupSet.Items.Add(new ListItem("普通用户", "0"));
                this.dropGroupSet.Items.Add(new ListItem("视频审核组", "1"));
                this.dropGroupSet.Items.Add(new ListItem("网站管理员", "2"));
            }
            gdvBind(group, cmd, privilege, key);
        }
    }

    private void gdvBind(string group, string cmd, string privilege, string key)
    {
        if (group == null)
        {
            if (userbll.getUserRegisterInfo(cmd, privilege, key).Rows.Count > 0)
            {
                gdvUserRegister.DataSource = userbll.getUserRegisterInfo(cmd, privilege, key);
                gdvUserRegister.DataBind();
            }
            else
            {
                gdvUserRegister.DataSource = null;
                gdvUserRegister.DataBind();
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('查询结果不存在');", true);
            }
        }
        else
        {
            if (userbll.getUserRegisterByGroup(group).Rows.Count > 0)
            {
                gdvUserRegister.DataSource = userbll.getUserRegisterByGroup(group);
                gdvUserRegister.DataBind();
            }
            else
            {
                gdvUserRegister.DataSource = null;
                gdvUserRegister.DataBind();
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('查询结果不存在');", true);
            }
        }
    }

    protected void gdvUserRegister_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gdvUserRegister.Rows.Count - 1; i++)
        {
            Label privilege = (Label)this.gdvUserRegister.Rows[i].FindControl("lblGroup");
            if (privilege.Text.Trim() == "0")
            {
                privilege.Text = "普通用户";
                privilege.ToolTip = "普通用户";
            }
            if (privilege.Text.Trim() == "1")
            {
                privilege.Text = "视频审核组";
                privilege.ToolTip = "视频审核组";
            }
            if (privilege.Text.Trim() == "2")
            {
                privilege.Text = "网站管理员";
                privilege.ToolTip = "网站管理员";
            }
            if (privilege.Text.Trim() == "3")
            {
                privilege.Text = "超级管理员";
                privilege.ToolTip = "超级管理员";
            }
            Label status = (Label)this.gdvUserRegister.Rows[i].FindControl("lblStatus");
            if (status.Text.Trim() == "0")
            {
                status.Text = "正常";
                status.ToolTip = "正常";
            }
            if (status.Text.Trim() == "1")
            {
                status.Text = "账户锁定";
                status.ToolTip = "账户锁定";
            }
        }
    }

    protected void gdvLoginedAdminInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gdvLoginedAdminInfo.Rows.Count - 1; i++)
        {
            Label privilege = (Label)this.gdvLoginedAdminInfo.Rows[i].FindControl("lblGroup");
            if (privilege.Text.Trim() == "0")
            {
                privilege.Text = "普通用户";
                privilege.ToolTip = "普通用户";
            }
            if (privilege.Text.Trim() == "1")
            {
                privilege.Text = "视频审核组";
                privilege.ToolTip = "视频审核组";
            }
            if (privilege.Text.Trim() == "2")
            {
                privilege.Text = "网站管理员";
                privilege.ToolTip = "网站管理员";
            }
            if (privilege.Text.Trim() == "3")
            {
                privilege.Text = "超级管理员";
                privilege.ToolTip = "超级管理员";
            }
            Label status = (Label)this.gdvLoginedAdminInfo.Rows[i].FindControl("lblStatus");
            if (status.Text.Trim() == "0")
            {
                status.Text = "正常";
                status.ToolTip = "正常";
            }
            if (status.Text.Trim() == "1")
            {
                status.Text = "账户锁定";
                status.ToolTip = "账户锁定";
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        string operate = null;
        for (int i = 0; i <= this.gdvUserRegister.Rows.Count - 1; i++)
        {
            HtmlInputCheckBox hicb = (HtmlInputCheckBox)this.gdvUserRegister.Rows[i].FindControl("chkId");
            if (hicb.Checked == true)
            {
                string id = ((Label)(this.gdvUserRegister.Rows[i].FindControl("lblId"))).Text.Trim();
                if (UserId == id)
                {
                    ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('您不能删除自己的账户');", true);
                    break;
                }
                if (userbll.deleteUserRegister(id))
                {
                    n++;
                }
            }
        }
        if (n > 0)
        {
            operate = "成功删除了" + n + "个注册用户";
            sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
        }
        else
        {
            operate = "删除注册用户过程发生异常";
            sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
        }
        gdvBind(group, cmd, privilege, key);
    }

    protected void btnSetPass_Click(object sender, EventArgs e)
    {
        this.lblSetName.Text = "密码";
        for (int i = 0; i <= this.gdvUserRegister.Rows.Count - 1; i++)
        {
            HtmlInputCheckBox hicb = (HtmlInputCheckBox)this.gdvUserRegister.Rows[i].FindControl("chkId");
            if (hicb.Checked == true)
            {
                string uid = ((Label)(this.gdvUserRegister.Rows[i].FindControl("lblUserName"))).Text.Trim();
                um = userbll.getUReg(uid);
                this.lblUid.Text = um.userName;
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "showDiv();document.getElementById('passSetSpan').style.display='block';", true);
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string operate = null;
        string uid = this.lblUid.Text.Trim();
        if (lblSetName.Text == "密码")
        {
            string pass = common.Encrypt(this.txtPwd.Value.Trim());
            if (userbll.UpdatePass(uid, pass))
            {
                operate = "设置了注册用户'" + uid + "'的密码为" + this.txtPwd.Value.Trim();
                sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('密码修改成功');", true);
            }
        }
        if (lblSetName.Text == "权限")
        {
            string prl = this.dropGroupSet.SelectedValue;
            if (uid == userName)
            {
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('您不能设置自己的权限');", true);
            }
            else
            {
                if (userbll.doPrivilege(uid, prl))
                {
                    operate = "设置了注册用户'" + uid + "'的权限为" + this.dropGroupSet.SelectedItem.Text;
                    sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
                    ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('权限修改成功');", true);
                }
            }
        }
        if (lblSetName.Text == "状态")
        {
            string reason = this.txtReason.Value.Trim();
            if (uid == userName)
            {
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('您不能设置自己的状态');", true);
            }
            else
            {
                if (userbll.doStatus(uid, reason))
                {
                    operate = "更改了注册用户'" + uid + "'的用户状态,更改原因:" + reason;
                    sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
                    ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('用户状态修改成功');", true);
                }
            }
        }
        gdvBind(group, cmd, privilege, key);
    }

    protected void dropIdea_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (privilege == "2")
        {
            this.dropGroup.Items.Clear();
            this.dropGroup.Items.Add(new ListItem("普通用户", "0"));
            this.dropGroup.Items.Add(new ListItem("视频审核组", "1"));
        }
        if (privilege == "3")
        {
            this.dropGroup.Items.Clear();
            this.dropGroup.Items.Add(new ListItem("普通用户", "0"));
            this.dropGroup.Items.Add(new ListItem("视频审核组", "1"));
            this.dropGroup.Items.Add(new ListItem("网站管理员", "2"));
            this.dropGroup.Items.Add(new ListItem("超级管理员", "3"));
        }
        this.ibtnSearch.Enabled = true;
        if (this.dropIdea.SelectedValue == "0")
        {
            cmd = "user";
            this.dropGroup.Visible = false;
            this.txtKey.Visible = true;
        }
        else
        {
            group = this.dropGroup.SelectedValue;
            this.dropGroup.Visible = true;
            this.txtKey.Visible = false;
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (dropIdea.SelectedValue == "0")
        {
            key = this.txtKey.Value.Trim();
            group = null;
        }
        else
        {
            key = null;
            group = this.dropGroup.SelectedValue;
        }
        gdvBind(group, cmd, privilege, key);
    }

    protected void btnSetPrivilege_Click(object sender, EventArgs e)
    {
        this.lblSetName.Text = "权限";
        for (int i = 0; i <= this.gdvUserRegister.Rows.Count - 1; i++)
        {
            HtmlInputCheckBox hicb = (HtmlInputCheckBox)this.gdvUserRegister.Rows[i].FindControl("chkId");
            if (hicb.Checked == true)
            {
                string uid = ((Label)(this.gdvUserRegister.Rows[i].FindControl("lblUserName"))).Text.Trim();
                um = userbll.getUReg(uid);
                this.lblUid.Text = um.userName;
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "showDiv();document.getElementById('privilegeSetSpan').style.display='block';", true);
            }
        }
    }

    protected void btnSetStatus_Click(object sender, EventArgs e)
    {
        this.lblSetName.Text = "状态";
        for (int i = 0; i <= this.gdvUserRegister.Rows.Count - 1; i++)
        {
            HtmlInputCheckBox hicb = (HtmlInputCheckBox)this.gdvUserRegister.Rows[i].FindControl("chkId");
            if (hicb.Checked == true)
            {
                string uid = ((Label)(this.gdvUserRegister.Rows[i].FindControl("lblUserName"))).Text.Trim();
                um = userbll.getUReg(uid);
                this.lblUid.Text = um.userName;
                ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "showDiv();document.getElementById('lockSetSpan').style.display='block';", true);
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtReason.Value = string.Empty;
        ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "closeDiv", true);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        string operate = null;
        string uid = userName;
        string pass = common.Encrypt(this.pwdlogined.Value.Trim());
        if (userbll.UpdatePass(uid, pass))
        {
            operate = "修改了自己的密码为：" + this.pwdlogined.Value.Trim();
            sysnotesbll.sysNotesAdd(userName, privilege, ip, operate, 3);
            ScriptManager.RegisterStartupScript(this.upnlUserManage, this.GetType(), "", "alert('密码修改成功');", true);
        }
    }

    protected void gdvUserRegisterInfo_PageChanging(object sender, GridViewPageEventArgs e)
    {
        this.gdvUserRegister.PageIndex = e.NewPageIndex;
        gdvBind(group, cmd, privilege, key);
    }
}

