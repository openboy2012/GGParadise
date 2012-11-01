<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="register.aspx.cs" Inherits="UserPage_register" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/body.css" rel="stylesheet" type="text/css" />
    <link href="css/table.css" rel="stylesheet" type="text/css" />
    <link href="css/dropdownlist.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery.validate.extension.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/dropdownlist.js" charset="GB2312"></script>

    <script type="text/javascript">
        function checkAll()
        {
             if($("#list > div > table tr > td > div :first").text()=="--请选择密保问题--")
             {               
                 $("#lblMsg").show();
                 $("#lblMsg").addClass("error");
                 $("#list >div").addClass("error");
                 $("#lblMsg").text("请选择一个密保问题");
                 return false;
             }
             else
             {
                  $("#list >div").removeClass("error");
                  $("#lblMsg").removeClass("error");
                  $("#lblMsg").hide();
                  var question=$("#list > div > table tr > td > div :first").text();
                  $("#<%=hdnQuestion.ClientID %>").val(question);
             }
             return true;
        }       
        
        function InitRules() { 
            var dataInfo = {
                  uid:function()
                  { 
                      return $("#<%=txtUserName.ClientID %>").val();
                      }
                  };
            var remoteInfo = GetRemoteInfo('WebService.asmx/CheckUid', dataInfo);
            opts = {
            rules:
            {
                  <%=txtUserName.UniqueID %>:
                  {
                       required:true,
                       remote:remoteInfo         
                  },
                  <%=txtPassword.UniqueID %>:
                  {
                       required:true,
                       minlength:6
                  },
                  <%=txtRePassword.UniqueID %>:
                  {
                       required:true,
                       equalTo:"#<%=txtPassword.ClientID %>"
                  },
                  <%=txtAnswer.UniqueID %>:
                  {
                       required:true,
                       minlength:4
                  },
                  <%=txtEmail.UniqueID %>:
                  {
                       required:true,
                       email:true
                  },
                  <%=txtNickname.UniqueID %>:
                  {
                       required:true,
                       minlength:4
                  },
                  <%=txtCode.UniqueID %>:
                  {
                       required:true
                  }
            },
            messages:
            {
                  <%=txtPassword.UniqueID %>:
                  {
                     required:"用户密码必须填写",
                     minlength:"密码长度不少于6个字符"
                  },
                  <%=txtRePassword.UniqueID %>:
                  {
                     required:"请输入重复密码",
                     equalTo:"两次密码不一致"
                  },
                  <%=txtAnswer.UniqueID %>:
                  {
                     required:"密保长度必须填写",
                     minlength:"密保答案长度不少于4个字符"
                  },
                  <%=txtEmail.UniqueID %>:
                  {
                     required:"请输入电子邮箱"
                  },
                  <%=txtNickname.UniqueID %>:
                  {
                     required:"请输入用户昵称",
                     minlength:"请输入长度至少为4的用户昵称"
                  },
                  <%=txtCode.UniqueID %>:
                  {
                     required:"验证码必须填写"
                  }
            }
            }
         }
         
        function showRegMsgDiv() {
            $("#codeMsg").show();
            setTimeout("closeRegMsgDiv()", 3000);
        }
        function closeRegMsgDiv() {
            $("#codeMsg").hide();
        }
        
        function showBGDiv() {
            $("#bg").show();
            $("#Terms").show();
        }
        function closeBGDiv() {
            $("#Terms").hide();
            $("#bg").hide();
        }
        

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--bodyTop start -->
    <div id="bodyTopMain">
        <div id="bodyTop">
            <!--left start -->
            <div id="left">
                <h2 class="contact">
                    Register New Form</h2>
                <div>
                    <table id="reg" cellpadding="0" cellspacing="0" style="width: 100%;" align="center"
                        class="border">
                        <tr>
                            <th colspan="2" class="th_bg">
                                乖乖乐园新用户注册
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_bg" style="padding-left: 5px;">
                                用户名注册&nbsp;<span style="padding-left: 100px;"></span><span id="codeMsg" style="display: none;"><asp:Label
                                    ID="lblError" runat="server" CssClass="white"></asp:Label></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px;" align="right" class="tdreg">
                                <span>用户名：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input type="text" runat="server" id="txtUserName" class="txt" maxlength="20" size="20"
                                    style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_bg" style="padding-left: 5px;">
                                设置安全信息
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>密 码：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input type="password" runat="server" id="txtPassword" class="txt" maxlength="20"
                                    size="20" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>重复密码：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input id="txtRePassword" type="password" runat="server" class="txt" maxlength="20"
                                    size="20" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>密保问题：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <span id="list" onmouseout="javascript:return checkAll();" style="cursor: pointer;">
                                    <input type="hidden" id="hdnQuestion" runat="server" /></span>
                                <div style="padding: 6px 0 2px 0px;">
                                    <label id="lblMsg">
                                    </label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>密保答案：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input id="txtAnswer" type="text" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>E-mail：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input id="txtEmail" type="text" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_bg" style="padding-left: 5px;">
                                个性设置
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>用户昵称：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input id="txtNickname" type="text" runat="server" class="txt" style="width: 180px;" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="td_bg" style="padding-left: 5px;" class="tdreg">
                                条例及验证码
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="tdreg">
                                <span>验证码：</span>
                            </td>
                            <td style="padding-left: 5px;" class="tdreg">
                                <input id="txtCode" type="text" runat="server" class="txt" style="width: 72px;" size="5" />
                                <img title="验证码,看不清楚可以点击刷新"  id="imgCode" alt="validateCode" src="CreateCode.aspx" onclick="this.src=this.src+'?'"
                                    align="absmiddle" /><span style="font: normal 12px 宋体">看不清楚，点击图片更换</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="padding-left: 80px" class="tdreg">
                                <input type="checkbox" id="chkTerms" name="chkTerms" class="required" checked="checked"  />
                                <a href="#" onclick="javascript:return showBGDiv();">同意本站条款</a>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="padding-left: 150px" class="tdreg">
                                <asp:Button runat="server" ID="btnRegister" CssClass="btn2" Text="注册" OnClick="btnRegister_Click"
                                    OnClientClick="javascript:return checkAll();" />
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
                <h2 class="stories">
                    Welcome Here<span>乖乖乐园用户注册</span>
                </h2>
                <ul class="videoupload">
                    <li><a>注册用户好处1：</a></li>
                    <li><a>注册用户好处2：</a></li>
                    <li><a>注册用户好处3：</a></li>
                </ul>
            </div>
            <!--right end -->
            <p class="rightBot">
            </p>
            <br class="spacer" />
        </div>
    </div>
    <!--bodyTop end -->
    <!--RegisterTerms start-->
    <div id="Terms" class="divTerms" style="display: none;">
        <table cellpadding="0" cellspacing="0" style="width: 100%; background-color: #fff;">
            <tr>
                <th align="right" class="th_bg">
                    本站用户条款<span style="padding-left: 200px;"></span> <a class="hand" href="javascript:closeBGDiv()">
                        关闭</a><span style="padding-right: 10px;"></span>
                </th>
            </tr>
            <tr>
                <td>
                    <div id="TermsContents">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--RegisterTerms end-->

    <script type="text/javascript">
        InitRules();
    </script>

</asp:Content>
