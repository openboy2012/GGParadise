<%@ Page Language="C#" AutoEventWireup="true" CodeFile="play.aspx.cs" Inherits="Manage_play" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
    <div id="content">
        <table cellpadding="0" cellspacing="0" style="width: 96%;" align="center">
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" class="table">
                        <tr>
                            <td align="left">
                                <img src="images/ck.gif" style="width: 10px; height: 10px" alt="" />
                                您现在的位置是：<a href="right.html" target="main">乖乖乐园管理首页</a>&gt;&gt;<a href="#">视频管理</a>&gt;&gt;视频播放
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="table" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" style="padding: 5px;">
                                <table class="border" cellpadding="0" cellspacing="0" style="width: 96%;">
                                    <tr>
                                        <th class="bar" align="center" style="text-align: center;">
                                            您正在收看的是：<a class="red"><% =videoTitle %></a> （已经播放<a class="red"><% =playSum %></a>次）
                                        </th>
                                    </tr>
                                    <tr>
                                        <td class="tdlb" align="center">
                                            <asp:Literal ID="ltlPlay" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_play" align="center">
                                            上传用户：<%=publishName %>
                                            <span style="padding-left: 100px"></span>上传于：<%=videoDate %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_play" align="center">
                                            视频简介：<br />
                                            <%=videoContent %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="menufooter" align="center">
                                            <asp:Button ID="btnPass" runat="server" Text="确认" CssClass="btn" OnClick="btnPass_Click" />
                                            &nbsp;<asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="btn" OnClick="btnDelete_Click" />
                                        </td>
                                    </tr>
                                </table>
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
