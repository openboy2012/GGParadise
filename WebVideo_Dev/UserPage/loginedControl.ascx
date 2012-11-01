<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loginedControl.ascx.cs"
    Inherits="loginedControl" %>
<link href="css/ucontrol.css" rel="stylesheet" type="text/css" />
<div id="UserLogined" style="width: 98%; text-align: left;">
    <table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <th class="th" style="padding: 3px 0; text-align: center; width: 98%">
                当前登录用户
            </th>
        </tr>
        <tr>
            <td align="center">
                用户名：<% =uinfo.userName%>
                昵称：<%=uinfo.nickName %>
                积分：<%=uinfo.sumMark %>
            </td>
        </tr>
        <tr>
            <td align="center">
                <a href="#">用户中心</a>&nbsp;<a href="videoUpload.aspx" target="_blank">上传视频</a>&nbsp;<a
                    href="message.aspx?cmd=quit"> 退出</a>
            </td>
        </tr>
    </table>
</div>
