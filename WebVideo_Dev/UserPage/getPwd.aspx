<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="getPwd.aspx.cs" Inherits="UserPage_getPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/body.css" rel="stylesheet" type="text/css" />
    <link href="css/dropdownlist.css" rel="stylesheet" type="text/css" />

    <script src="js/dropdownlist.js" type="text/javascript" charset="GB2312"></script>

    <script type="text/javascript">
        function checkUE() {
            var uid = $("#<% =txtUserName.ClientID %>").val();
            var email = $("#<% =txtEmail.ClientID %>").val();
            if (uid == "") {
                alert("用户名不能为空");
                return false;
            }
            if (email == "") {
                alert("Email不能为空");
                return false;
            }
            return true;
        }

        function checkQA() {
            var answer = $('#<% =txtAnswer.ClientID %>').val();
            if ($("#list > div > table tr > td > div :first").text() == "--请选择密保问题--") {
                alert('请选择一个密保问题');
                return false;
            }
            else {
                var question = $("#list > div > table tr > td > div :first").text();
                $("#<%=hdnQuestion.ClientID %>").val(question);
            }
            if (answer == "") {
                alert('密保答案不能为空');
                return false;
            }
            return true;
        }

        function checkPass() {
            var pass = $("#<%=txtPassword.ClientID %>").val();
            var repass = $("#<%=txtRepassword.ClientID %>").val();
            if (pass == "") {
                alert('密码不能为空');
                return false;
            }
            if (repass == "") {
                alert("重复密码不能为空");
                return false;
            }
            if (pass != repass) {
                alert('两次密码不相同');
                return false;
            }
            return true;
        }
       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bodyTopMain">
        <div id="bodyTop">
            <!--left start -->
            <div id="left">
                <h2 class="getpassword">
                    Get Password</h2>
                <div id="userIdDiv">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;" class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                找回用户密码（输入用户名）
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">请输入用户名：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtUserName" runat="server" class="txt" style="width: 180px;"
                                    maxlength="20" size="20" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">请输入注册邮箱：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtEmail" runat="server" class="txt" style="width: 180px;"
                                    maxlength="30" size="30" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnNext1" runat="server" Text="下一步" CssClass="btn2" OnClick="btnNext1_Click"
                                    OnClientClick="javascript:return checkUE();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="passProtectDiv" style="display: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;" class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                用户：<span style="color: #f00;"><%=userName %></span>&nbsp;找回用户密码（验证密保问题）
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">密保问题：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <span id="list" style="cursor: pointer;">
                                    <input type="hidden" id="hdnQuestion" runat="server" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">密保答案：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtAnswer" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnNext2" runat="server" Text="下一步" CssClass="btn2" OnClick="btnNext2_Click"
                                    OnClientClick="javascript:return checkQA();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="pwdDiv" style="display: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;" class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                用户：<span style="color: #f00;"><%=userName %></span>&nbsp;找回用户密码（设置新密码）
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="password" id="txtPassword" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">重复密码：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="password" id="txtRepassword" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnConfirm" runat="server" Text="完成" CssClass="btn2" OnClick="btnConfirm_Click"
                                    OnClientClick="javascript:return checkPass();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!--left end -->
            <p class="rightTop">
            </p>
            <!--right start -->
            <div id="rightTop" class="right">
                <h2 class="faq">
                    GGParadise FAQ <span>提问与回答</span></h2>
                <ul>
                    <li><span>提问1：</span></li>
                    <li><span>答案1：</span></li>
                    <li><span>提问2：</span></li>
                    <li><span>答案2：</span></li>
                </ul>
            </div>
            <p class="rightBot">
            </p>
            <!--right end -->
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
</asp:Content>
