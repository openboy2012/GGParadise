<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commentManage.aspx.cs" Inherits="Manage_commentManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function selectAll(a) {
            obj = document.getElementById('<%=gdvComment.ClientID %>').getElementsByTagName('input');
            var getobj = obj; for (i = 0; i < getobj.length; i++) {
                getobj[i].checked = a.checked;
            }
        }
        function selectedNum() {
            var n = 0; obj = document.getElementById('<%=gdvComment.ClientID %>').getElementsByTagName('input');
            var getobj = obj; for (i = 0; i < getobj.length; i++) {
                if (getobj[i].checked == true) {
                    n++;
                }
            } return n;
        }

        function checkPass() {
            var n = selectedNum();
            if (n < 1) {
                alert("提示：请至少选择一项进行删除操作");
                return false;
            }
            else {
                return confirm("您确认通过选中的评论内容的审核？");
            }
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="content">
        <table cellpadding="0" cellspacing="0" style="width: 96%;" align="center">
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" class="table">
                        <tr>
                            <td align="left">
                                <img src="images/ck.gif" style="width: 10px; height: 10px" alt="" />
                                您现在的位置是：<a href="right.html" target="main">乖乖乐园管理首页</a>&gt;&gt;<a href="#">评论审核</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" class="table">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="upnlCommentManage" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" class="table2">
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;视频评论审核管理
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="gdvComment" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                                        Width="96%" AllowPaging="True" GridLines="Both" OnPageIndexChanging="gdvComment_PageIndexChanging"
                                                        PageSize="20" OnRowDataBound="gdvComment_RowDataBound" OnRowDeleting="gdvComment_OnRowDeleting">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <input type="checkbox" id="chkAll" onclick="selectAll(this);" />全选
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <input type="checkbox" id="chkId" runat="server" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="编号">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ToolTip='<%#Eval("id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="发布人">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("userName") %>' ToolTip='<%#Eval("userName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="12%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIp" runat="server" Text='<%#Eval("ip") %>' ToolTip='<%#Eval("ip") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="13%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="评论内容">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBulletinContents" runat="server" Text='<%#Common.interceptstr((string)Eval("contents"),30)%>'
                                                                        ToolTip='<%#Eval("contents") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="40%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="视频ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVideoId" runat="server" Text='<%#Eval("videoId") %>' ToolTip='<%#Eval("videoId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="发布时间">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIssuanceDate" runat="server" Text='<%#Eval("issuanceDate") %>'
                                                                        ToolTip='<%#Eval("issuanceDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15%" />
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ItemStyle-Width="5%">
                                                                <ItemStyle Width="5%"></ItemStyle>
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="menufooter" align="left" style="padding-left: 100px;">
                                                    <asp:Button ID="btnConfirm" runat="server" Text="通过审核" CssClass="btn2" OnClick="btnConfirm_Click" OnClientClick="javascript:return checkPass();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" class="table">
                        <tr>
                            <td align="center">
                                <a href="right.html" target="main">返回首页</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
