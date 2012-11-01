using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class Manage_bulletinManage : System.Web.UI.Page
{
    AdminBLL adminbll = new AdminBLL();
    BulletinModel bm = new BulletinModel();
    SysNotesBLL sysnotesbll = new SysNotesBLL();
    private static string userName = null;
    private static string ip = null;
    private static string privilege = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Manage/login.aspx");
        }
        URegModel u = Session["userName"] as URegModel;
        if (int.Parse(u.Privilege) == 1)
        {
            Response.Redirect("~/Manage/right.html");
        }
        ip = Request.UserHostAddress.ToString();
        userName = u.userName;
        privilege = u.Privilege;
        if (!IsPostBack)
        {
            gdvBind();
        }
    }

    private void gdvBind()
    {
        if (adminbll.getBulletins().Rows.Count > 0)
        {
            this.gdvBulletin.DataSource = adminbll.getBulletins();
            this.gdvBulletin.DataBind();
        }
        else
        {
            this.gdvBulletin.DataSource = null;
            this.gdvBulletin.DataBind();
            ScriptManager.RegisterStartupScript(this.upnlBulletinManage, this.GetType(), "", "alert('系统里不存在任何一条站内公告');", true);
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        bm.Title = this.txtBulletinTitle.Value.Trim();
        bm.Contents = this.txtBulletinContents.Value.Trim();
        if (adminbll.addBulletin(bm))
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "添加了一条新的站内公告", 5);
            ScriptManager.RegisterStartupScript(this.upnlBulletinManage, this.GetType(), "", "alert('站内公告添加成功');", true);
            gdvBind();
        }
    }

    protected void gdvBulletin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除的该站内公告吗?')");
            }
        }
    }

    protected void gdvBulletin_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Int32.Parse(((Label)gdvBulletin.Rows[e.RowIndex].FindControl("lblId")).Text.ToString());
        if (adminbll.deleteBulletin(id))
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "删除了一条过时的站内公告", 5);
            ScriptManager.RegisterStartupScript(this.upnlBulletinManage, this.GetType(), "", "alert('站内公告删除成功');", true);
            gdvBind();
        }
    }

    protected void gdvBulletin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBulletin.PageIndex = e.NewPageIndex;
        gdvBind();
    }
}
