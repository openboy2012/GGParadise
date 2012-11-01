<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bulletinManage.aspx.cs" Inherits="Manage_bulletinManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function checkPublish() {
            var title = document.getElementById('<%=txtBulletinTitle.ClientID %>').value;
            var content = document.getElementById('<%=txtBulletinContents.ClientID %>').value;
            if (title == "") {
                alert('公告标题不能为空');
                return false;
            }
            if (content == "") {
                alert('公告内容不能为空');
                return false;
            } else if (content.length < 12) {
                alert('公告内容的长度不能小于12个字符')
                return false;
            }
            return true;
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
                                您现在的位置是：<a href="right.html" target="main">乖乖乐园管理首页</a>&gt;&gt;<a href="#">公告管理</a>
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
                                <asp:UpdatePanel ID="upnlBulletinManage" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" class="table2">
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;站内公告管理
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="gdvBulletin" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                                        Width="96%" AllowPaging="True" GridLines="Both" OnRowDataBound="gdvBulletin_RowDataBound"
                                                        PageSize="10" OnRowDeleting="gdvBulletin_OnRowDeleting" OnPageIndexChanging="gdvBulletin_PageIndexChanging">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="公告编号">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ToolTip='<%#Eval("id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="公告标题">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBulletinTitle" runat="server" Text='<%#Eval("title") %>' ToolTip='<%#Eval("title") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="20%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="公告内容">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBulletinContents" runat="server" Text='<%#Common.interceptstr((string)Eval("contents"),20)%>'
                                                                        ToolTip='<%#Eval("contents") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="40%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="公告发布时间">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIssuanceDate" runat="server" Text='<%#Eval("issuanceDate") %>'
                                                                        ToolTip='<%#Eval("issuanceDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="20%" />
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderText="删除公告" ShowDeleteButton="True" ItemStyle-Width="10%">
                                                                <ItemStyle Width="10%"></ItemStyle>
                                                            </asp:CommandField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="bar" style="text-align: center;">
                                                    添加新公告
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table cellpadding="0" cellspacing="0" style="width: 80%">
                                                        <tr>
                                                            <td style="width: 30%" align="right">
                                                                <span class="bulletin">公告标题：</span>
                                                            </td>
                                                            <td align="left" style="width: 70%">
                                                                <input type="text" id="txtBulletinTitle" runat="server" class="txtTitle" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <span class="bulletin">公告内容：</span>
                                                            </td>
                                                            <td align="left">
                                                                <textarea id="txtBulletinContents" runat="server" rows="3" cols="1" class="txtContent"></textarea>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="menufooter" style="text-align: center">
                                                    <asp:Button ID="btnConfirm" runat="server" Text="增加" CssClass="btn" OnClientClick="return checkPublish()"
                                                        OnClick="btnConfirm_Click" />
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
