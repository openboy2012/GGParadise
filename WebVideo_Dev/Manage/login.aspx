<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Manage_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function check() {
            var username = document.getElementById('<%=txtUserName.ClientID %>').value;
            var password = document.getElementById('<%=txtPwd.ClientID %>').value;
            var checkcode = document.getElementById('<%=txtCode.ClientID %>').value;
            if (username == "") {
                document.getElementById('<%=lblMsg.ClientID %>').innerHTML = "用户名不能为空！";
                return false;
            }
            if (password == "") {
                document.getElementById('<%=lblMsg.ClientID %>').innerHTML = "密码不能为空！";
                return false;
            }
            if (checkcode == "") {
                document.getElementById('<%=lblMsg.ClientID %>').innerHTML = "验证码不能为空！";
                return false;
            }
            return true;
        }</script>

</head>
<body>
    <form id="form1" runat="server" target="_top">
    <div id="content">
        <table cellspacing="0" cellpadding="0" style="margin-top: 10%; width: 100%;">
            <tr>
                <td align="center" valign="middle">
                    <table cellspacing="0" cellpadding="0" width="468">
                        <tr>
                            <td class="login_1">
                            </td>
                        </tr>
                        <tr>
                            <td class="login_2">
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="468" style="background-color: #fff;">
                        <tr>
                            <td class="login_3">
                            </td>
                            <td align="center" valign="middle">
                                <table cellspacing="2" cellpadding="0" width="230">
                                    <tr>
                                        <td>
                                            用户名
                                        </td>
                                        <td align="left" style="padding-left: 10px;">
                                            <input class="txt" maxlength="30" size="24" id="txtUserName" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            口 令
                                        </td>
                                        <td align="left" style="padding-left: 10px;">
                                            <input class="txt" type="password" maxlength="30" size="24" id="txtPwd" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            验证码
                                        </td>
                                        <td align="left" style="padding-left: 10px;">
                                            <input class="txt" type="text" maxlength="5" size="5" id="txtCode" runat="server" />
                                            <img id="imgCode" alt="验证码" src="CreateCode.aspx" onclick="this.src=this.src+'?'"
                                                align="absmiddle" style="cursor: pointer;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Label ID="lblMsg" runat="server" Text="请勿非法登录" CssClass="lblMsg"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:ImageButton ID="ibtnSubmit" ImageUrl="images/bt_login.gif" runat="server" OnClick="ibtnSubmit_Click"
                                                OnClientClick="javascript:return check();"></asp:ImageButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="login_4">
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="468" border="0">
                        <tr>
                            <td class="login_5">
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="0" width="468" border="0">
                        <tr>
                            <td align="center">
                                <hr />
                                Copyright &copy; 2010-2011 GGParadise Corporation, All Rights Reserved
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
