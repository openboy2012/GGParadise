<%@ Page Language="C#" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="UserPage_message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/msg.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="MsgMain">
        <div id="Msg">
            <h1 class="h1">
                消息提示</h1>
            <ul>
                <li><a>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label></a></li>
                <li><a>
                    <asp:LinkButton ID="lbtnUrl" runat="server" OnClick="lbtnUrl_Click"></asp:LinkButton></a></li>
                <li><a class="red">如果没有跳转请点击上面的链接</a></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
