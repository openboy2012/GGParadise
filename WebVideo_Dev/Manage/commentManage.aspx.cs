using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using TeWebVideo.BLL;
using TeWebVideo.MODEL;

public partial class Manage_commentManage : System.Web.UI.Page
{
    AdminBLL adminbll = new AdminBLL();
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
        ip = Request.UserHostAddress.ToString();
        userName = u.userName;
        privilege = u.Privilege;
        if (!IsPostBack)
        {
            gdvBind();
        }
    }

    public void gdvBind()
    {
        if (adminbll.commentAuditing().Rows.Count > 0)
        {
            gdvComment.DataSource = adminbll.commentAuditing();
            gdvComment.DataBind();
        }
        else
        {
            gdvComment.DataSource = null;
            gdvComment.DataBind();
            ScriptManager.RegisterStartupScript(this.upnlCommentManage, this.GetType(), "", "alert('所有评论都已经通过审核!');", true);
        }
    }

    protected void gdvComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvComment.PageIndex = e.NewPageIndex;
        gdvBind();
    }

    protected void gdvComment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //如果是绑定数据行 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[7].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除的该评论吗?')");
            }
        }
    }

    protected void gdvComment_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Int32.Parse(((Label)gdvComment.Rows[e.RowIndex].FindControl("lblId")).Text.ToString());
        if (adminbll.deletecomment(id))
        {
            sysnotesbll.sysNotesAdd(userName, privilege, ip, "成功删除了一条评论", 4);
            ScriptManager.RegisterStartupScript(this.upnlCommentManage, this.GetType(), "", "alert('评论删除成功');", true);
            gdvBind();
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        int n = 0;
        for (int i = 0; i <= this.gdvComment.Rows.Count - 1; i++)
        {
            HtmlInputCheckBox cbox = (HtmlInputCheckBox)gdvComment.Rows[i].FindControl("chkId");
            if (cbox.Checked)
            {
                int id = Int32.Parse(((Label)gdvComment.Rows[i].FindControl("lblId")).Text.ToString());
                if (adminbll.passcomment(id))
                {
                    n++;
                }
            }
        }
        sysnotesbll.sysNotesAdd(userName, privilege, ip, "成功通过了" + n + "条评论内容的审核", 4);
        string message = "alert('成功通过了" + n + "条评论内容的审核！');";
        ScriptManager.RegisterStartupScript(this.upnlCommentManage, this.GetType(), "", message, true);
        gdvBind();
    }
}
