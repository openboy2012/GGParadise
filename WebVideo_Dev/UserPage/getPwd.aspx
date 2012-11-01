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
                alert("�û�������Ϊ��");
                return false;
            }
            if (email == "") {
                alert("Email����Ϊ��");
                return false;
            }
            return true;
        }

        function checkQA() {
            var answer = $('#<% =txtAnswer.ClientID %>').val();
            if ($("#list > div > table tr > td > div :first").text() == "--��ѡ���ܱ�����--") {
                alert('��ѡ��һ���ܱ�����');
                return false;
            }
            else {
                var question = $("#list > div > table tr > td > div :first").text();
                $("#<%=hdnQuestion.ClientID %>").val(question);
            }
            if (answer == "") {
                alert('�ܱ��𰸲���Ϊ��');
                return false;
            }
            return true;
        }

        function checkPass() {
            var pass = $("#<%=txtPassword.ClientID %>").val();
            var repass = $("#<%=txtRepassword.ClientID %>").val();
            if (pass == "") {
                alert('���벻��Ϊ��');
                return false;
            }
            if (repass == "") {
                alert("�ظ����벻��Ϊ��");
                return false;
            }
            if (pass != repass) {
                alert('�������벻��ͬ');
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
                                �һ��û����루�����û�����
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">�������û�����</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtUserName" runat="server" class="txt" style="width: 180px;"
                                    maxlength="20" size="20" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">������ע�����䣺</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtEmail" runat="server" class="txt" style="width: 180px;"
                                    maxlength="30" size="30" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnNext1" runat="server" Text="��һ��" CssClass="btn2" OnClick="btnNext1_Click"
                                    OnClientClick="javascript:return checkUE();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="passProtectDiv" style="display: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;" class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                �û���<span style="color: #f00;"><%=userName %></span>&nbsp;�һ��û����루��֤�ܱ����⣩
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">�ܱ����⣺</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <span id="list" style="cursor: pointer;">
                                    <input type="hidden" id="hdnQuestion" runat="server" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">�ܱ��𰸣�</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="text" id="txtAnswer" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnNext2" runat="server" Text="��һ��" CssClass="btn2" OnClick="btnNext2_Click"
                                    OnClientClick="javascript:return checkQA();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="pwdDiv" style="display: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;" class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                �û���<span style="color: #f00;"><%=userName %></span>&nbsp;�һ��û����루���������룩
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �룺</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="password" id="txtPassword" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 160px; padding: 3px; background-color: #DCD58F;">
                                <span class="black">�ظ����룺</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdindex">
                                <input type="password" id="txtRepassword" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 30px" class="tdindex">
                                <asp:Button ID="btnConfirm" runat="server" Text="���" CssClass="btn2" OnClick="btnConfirm_Click"
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
                    GGParadise FAQ <span>������ش�</span></h2>
                <ul>
                    <li><span>����1��</span></li>
                    <li><span>��1��</span></li>
                    <li><span>����2��</span></li>
                    <li><span>��2��</span></li>
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
