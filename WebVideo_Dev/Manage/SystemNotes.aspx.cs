using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TeWebVideo.BLL;

public partial class Manage_SystemNotes : System.Web.UI.Page
{
    SysNotesBLL sysnotesbll = new SysNotesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gdvBind();
        }
    }

    public void gdvBind()
    {
        gdvSystemNotes.DataSource = sysnotesbll.getSystemNotes();
        gdvSystemNotes.DataBind();
    }

    protected void gdvSystemNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSystemNotes.PageIndex = e.NewPageIndex;
        gdvBind();
    }

    protected void gdvSystemNotes_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i <= this.gdvSystemNotes.Rows.Count - 1; i++)
        {
            Label privilege = (Label)this.gdvSystemNotes.Rows[i].FindControl("lblGroup");
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
        }
    }

}
