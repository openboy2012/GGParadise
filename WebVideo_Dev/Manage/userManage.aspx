<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userManage.aspx.cs" Inherits="Manage_userManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function selectAll(a) {
            obj = document.getElementById('<%=gdvUserRegister.ClientID %>').getElementsByTagName('input');
            var getobj = obj;
            for (i = 0; i < getobj.length; i++) {
                getobj[i].checked = a.checked;
            }
        }

        function selectedNum() {
            var n = 0;
            obj = document.getElementById('<%=gdvUserRegister.ClientID %>').getElementsByTagName('input');
            var getobj = obj;
            for (i = 0; i < getobj.length; i++) {
                if (getobj[i].checked == true) {
                    n++;
                }
            }
            return n;
        }

        function checkDelete() {
            var n = selectedNum();
            if (n < 1) {
                alert("提示：请至少选择一项进行删除操作");
                return false;
            }
            else {
                return confirm("您确认删除选中的用户？");
            }
        }
        function checkSetUpdate() {
            var setName = document.getElementById("<%=lblSetName.ClientID %>").innerHTML;
            var pwd = document.getElementById("txtPwd").value;
            var repwd = document.getElementById("txtRepwd").value;
            var reason = document.getElementById("txtReason").value;
            if (setName == "密码") {
                if (pwd == "") {
                    alert('密码不能空');
                    return false;
                }
                if (pwd.length < 6) {
                    alert('密码长度不少于6');
                    return false;
                }
                if (repwd == "") {
                    alert('重复密码不能空');
                    return false;
                }
                if (repwd != pwd) {
                    alert('两次密码不相同');
                    return false;
                }
                return true;
            }
            if (setName == "状态") {
                if (reason == "") {
                    alert('锁定原因不能空');
                    return false;
                }
                return true;
            }
        }

        function checkSet() {
            var n = selectedNum();
            if (n == 1) {
                return true;
            }
            else {
                alert("提示：请选择一项信息进行设置操作");
                return false;
            }
        }

        function showLpwd() {
            document.getElementById('divLoginPwd').style.display = "block";
        }
        function closeLpwd() {
            document.getElementById('divLoginPwd').style.display = "none";
        }

        function checkPwd() {
            var pwdvalue = document.getElementById("pwdlogined").value;
            var repwdvalue = document.getElementById("repwdlogined").value;
            if (pwdvalue == "") {
                alert('密码不能空');
                return false;
            }
            if (pwdvalue.length < 6) {
                alert('密码长度不能小于6');
                return false;
            }
            if (repwdvalue == "") {
                alert('重复密码不能空');
                return false;
            }
            if (repwdvalue != pwdvalue) {
                alert('两次密码不相同');
                return false;
            }
            return true;
        }

        function showDiv() {
            document.getElementById("userInfo").style.display = "block";
            document.getElementById("commandDiv").style.display = "none";
        }

        function closeDiv() {
            document.getElementById("userInfo").style.display = "none";
            document.getElementById("commandDiv").style.display = "block";
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
                                您现在的位置是：<a href="right.html" target="main">乖乖乐园管理首页</a>&gt;&gt;<a href="userManage.aspx"
                                    target="main">会员管理</a>&gt;&gt;<asp:Label runat="server" ID="lblUrlAddress" CssClass="nav"></asp:Label>
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
                                <asp:UpdatePanel ID="upnlUserManage" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" class="table2">
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;当前登录管理员信息
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px;">
                                                    <asp:GridView runat="server" ID="gdvLoginedAdminInfo" AutoGenerateColumns="False"
                                                        Width="96%" CssClass="GridViewStyle" OnRowDataBound="gdvLoginedAdminInfo_RowDataBound">
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="用户编号">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ToolTip='<%#Eval("id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="7%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="用户名">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("userName") %>' ToolTip='<%#Eval("userName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="密保问题">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("passQuestion") %>' ToolTip='<%#Eval("passQuestion") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="密保答案">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("passAnswer") %>' ToolTip='<%#Eval("passAnswer") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="电子邮箱">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("email") %>' ToolTip='<%#Eval("email") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="所在用户组">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGroup" runat="server" Text='<%#Eval("privilege") %>' ToolTip='<%#Eval("privilege") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="用户状态">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("lock") %>' ToolTip='<%#Eval("lock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="最新登陆">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblupdateTime" runat="server" Text='<%#Eval("updateTime") %>' ToolTip='<%#Eval("updateTime") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="13%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="备注">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("lockCause") %>' ToolTip='<%#Eval("lockCause") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="操作">
                                                                <ItemTemplate>
                                                                    <a href="#" onclick="javascript:showLpwd();">更改密码</a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                    </asp:GridView>
                                                    <div id="divLoginPwd" style="padding: 2px; margin: 2px; display: none;">
                                                        密码：<input id="pwdlogined" type="password" class="pass" runat="server" maxlength="20" />重复密码：<input
                                                            id="repwdlogined" type="password" class="pass" runat="server" maxlength="20" />&nbsp;<asp:Button
                                                                runat="server" ID="btnYes" Text="确认" CssClass="btn2" OnClick="btnYes_Click" OnClientClick="javascript:return checkPwd();">
                                                            </asp:Button>
                                                        &nbsp;<asp:Button runat="server" ID="btnNo" Text="取消" CssClass="btn2" OnClientClick="javascript:closeLpwd();">
                                                        </asp:Button></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;用户搜索
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="menu" style="padding-left: 70px;">
                                                    查询方式：<asp:DropDownList runat="server" CssClass="select" ID="dropIdea" AutoPostBack="True"
                                                        OnSelectedIndexChanged="dropIdea_SelectedIndexChanged" Enabled="false">
                                                        <asp:ListItem Value="0">用户名</asp:ListItem>
                                                        <asp:ListItem Value="1">用户权限</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                    <asp:DropDownList runat="server" ID="dropGroup" CssClass="select" Visible="false">
                                                    </asp:DropDownList>
                                                    <input type="text" runat="server" class="txt" id="txtKey" visible="false" />
                                                    &nbsp;<asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/Manage/images/btnSearch.gif"
                                                        Enabled="false" OnClick="ibtnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="bar" align="left">
                                                    &nbsp;&nbsp;用户信息
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px;">
                                                    <asp:GridView runat="server" ID="gdvUserRegister" AutoGenerateColumns="False" Width="96%"
                                                        CssClass="GridViewStyle" AllowPaging="True" PageSize="20" OnRowDataBound="gdvUserRegister_RowDataBound"
                                                        OnPageIndexChanging="gdvUserRegisterInfo_PageChanging">
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
                                                            <asp:TemplateField HeaderText="用户编号">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>' ToolTip='<%#Eval("id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="7%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="用户名">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("userName") %>' ToolTip='<%#Eval("userName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="密保问题">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("passQuestion") %>' ToolTip='<%#Eval("passQuestion") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="密保答案">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("passAnswer") %>' ToolTip='<%#Eval("passAnswer") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="电子邮箱">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("email") %>' ToolTip='<%#Eval("email") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="所在用户组">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGroup" runat="server" Text='<%#Eval("privilege") %>' ToolTip='<%#Eval("privilege") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="用户状态">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("lock") %>' ToolTip='<%#Eval("lock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="注册时间">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRegisterdate" runat="server" ToolTip='<%#Eval("registerDate") %>'><%#DateTime.Parse(Eval("registerDate").ToString()).ToString("yyyy-MM-dd") %></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="最新登陆">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUpdatetime" runat="server" ToolTip='<%#Eval("updateTime") %>'><%#DateTime.Parse(Eval("updateTime").ToString()).ToString("yyyy-MM-dd") %></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="备注">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("lockCause") %>' ToolTip='<%#Eval("lockCause") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="menufooter" align="center">
                                                    <div id="userInfo" style="display: none; border: solid 1px #00f; font: normal 100 13px/18px 微软雅黑;
                                                        vertical-align: middle; padding: 2px; background-color: #7DC7F6;">
                                                        <asp:Label runat="server" ID="lblUid" CssClass="red"></asp:Label>的<asp:Label ID="lblSetName"
                                                            runat="server" CssClass="blue"></asp:Label>设置： <span id="passSetSpan" style="display: none;">
                                                                密码：<input id="txtPwd" type="password" class="pass" runat="server" maxlength="20"
                                                                    size="20" />重复密码：<input id="txtRepwd" type="password" class="pass" runat="server"
                                                                        maxlength="20" size="20" />
                                                            </span><span id="privilegeSetSpan" style="display: none;">请选择所在用户组：
                                                                <asp:DropDownList ID="dropGroupSet" runat="server" CssClass="select">
                                                                </asp:DropDownList>
                                                            </span><span id="lockSetSpan" style="display: none;">锁定原因：<input id="txtReason" runat="server"
                                                                type="text" class="pass" />
                                                            </span>&nbsp;<asp:Button runat="server" ID="btnConfirm" Text="确认" CssClass="btn2"
                                                                OnClick="btnConfirm_Click" OnClientClick="javascript:return checkSetUpdate();">
                                                        </asp:Button>
                                                        &nbsp;<asp:Button runat="server" ID="btnCancel" Text="取消" CssClass="btn2" OnClick="btnCancel_Click">
                                                        </asp:Button>
                                                    </div>
                                                    <div id="commandDiv">
                                                        <asp:Button runat="server" ID="btnDelete" Text="删除" CssClass="btn2" OnClientClick="javascript:return checkDelete();"
                                                            ToolTip="你可以用此按钮进行用户删除操作" OnClick="btnDelete_Click" Visible="false" />
                                                        &nbsp;<asp:Button runat="server" ID="btnSetPass" Text="修改密码" CssClass="btn2" ToolTip="您可以用此按钮进行用户修改密码操作"
                                                            OnClick="btnSetPass_Click" OnClientClick="javascript:return checkSet();" Visible="false" />
                                                        <asp:Button ID="btnSetPrivilege" runat="server" CssClass="btn2" OnClick="btnSetPrivilege_Click"
                                                            OnClientClick="javascript:return checkSet();" Text="设置权限" ToolTip="您可以用此按钮进行设置用户权限操作"
                                                            Visible="false" />
                                                        <asp:Button ID="btnSetStatus" runat="server" CssClass="btn2" OnClick="btnSetStatus_Click"
                                                            OnClientClick="javascript:return checkSet();" Text="账户状态" ToolTip="您可以用此按钮进行设置账户锁定操作"
                                                            Visible="false" />
                                                    </div>
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
