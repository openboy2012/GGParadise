<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemNotes.aspx.cs" Inherits="Manage_SystemNotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
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
                                您现在的位置是：<a href="right.html" target="main">乖乖乐园管理首页</a>&gt;&gt;<a href="#">系统日志</a>
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
                                <asp:UpdatePanel ID="upnlSystemNotes" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" class="table2">
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;系统日志
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px;">
                                                    <asp:GridView runat="server" ID="gdvSystemNotes" AutoGenerateColumns="False" Width="96%"
                                                        CssClass="GridViewStyle" AllowPaging="True" PageSize="20" OnRowDataBound="gdvSystemNotes_DataRowBound"
                                                        OnPageIndexChanging="gdvSystemNotes_PageIndexChanging">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="用户名">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("userName") %>' ToolTip='<%#Eval("userName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="用户组">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGroup" runat="server" Text='<%#Eval("privilege") %>' ToolTip='<%#Eval("privilege") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="登录IP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIp" runat="server" Text='<%#Eval("ip") %>' ToolTip='<%#Eval("ip") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="12%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="操作时间">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTime" runat="server" Text='<%#Eval("time") %>' ToolTip='<%#Eval("time") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="13%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="日志内容">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOperate" runat="server" Text='<%#Eval("operate") %>' ToolTip='<%#Eval("operate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="55%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                    </asp:GridView>
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
                <td align="center">
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
