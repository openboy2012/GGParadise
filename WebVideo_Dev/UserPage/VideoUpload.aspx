<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoUpload.aspx.cs" Inherits="UserPage_VideoUpload" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload"
    TagPrefix="Upload" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/upload.css" />

    <script src="js/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function ToggleVisibility(id, type) {
            el = document.getElementById(id);
            if (el.style) {
                if (type == 'on') {
                    el.style.display = 'block';
                }
                else {
                    el.style.display = 'none';
                }
            }
            else {
                if (type == 'on') {
                    el.display = 'block';
                }
                else {
                    el.display = 'none';
                }
            }
        }

        function checkVideoExtension() {
            var fileName = $('#<%=InputfileVideoUpload.ClientID %>').val();
            if (fileName == "") {
                alert("请选择一个文件！");
                $('#<%=InputfileVideoUpload.ClientID %>').addClass("error");
                return false;
            }
            else {
                var Extension = fileName.substring(fileName.length - 4);
                if (Extension == ".avi" || Extension == ".flv" || Extension == ".3gp" || Extension == ".wmv") {
                    $('#<%=InputfileVideoUpload.ClientID %>').removeClass("error");
                    return true;
                }
                else {
                    $('#<%=InputfileVideoUpload.ClientID %>').addClass("error");
                    alert("文件格式不正确,请上传.avi|.flv|.3gp|.wmv格式类型的视频文件");
                    return false;
                }
            }
        }

        function check() {
            var title = $('#<%=txtVideoTitle.ClientID %>').val();
            var content = $('#<%=txtVideoContent.ClientID %>').val();
            var types = $('#<%=dropVideoType.ClientID %>').val();
            if (title.length < 12) {
                $('#<%=txtVideoTitle.ClientID %>').addClass('error');
                alert('视频标题的长度不能小于12个字符');
                return false;
            }
            if (content.length < 15 || content.length > 120) {
                $('#<%=txtVideoContent.ClientID %>').addClass('error');
                alert('视频简介的长度不能小于15个字符不大于120字符');
                return false;
            }
            if (types == "" || types == null) {
                $('#<%=dropVideoType.ClientID %>').addClass('error');
                alert('请选择视频类型');
                return false;
            }
            $('#<%=txtVideoTitle.ClientID %>').removeClass('error');
            $('#<%=txtVideoContent.ClientID %>').removeClass('error');
            $('#<%=dropVideoType.ClientID %>').remove('error');
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="UploadMain">
        <div id="UploadDiv" class="upload">
            <h3>
                当前登陆用户信息
            </h3>
            <div style="padding-left: 3px;" id="divUserInfo">
                <span>用户名：<% =uinfo.userName%>
                    昵称：<%=uinfo.nickName %>
                    积分：<%=uinfo.sumMark %>
                    视频个数：<%=uinfo.sumVideo %>
                    <a href="#">用户中心</a>&nbsp;<a href="message.aspx?cmd=quit"> 退出</a></span>
            </div>
            <h3>
                乖乖乐园视频文件上传
            </h3>
            <div id="videoUpload" style="padding: 2px;">
                <div style="margin-top: 2px; text-align: center;">
                    <Upload:InputFile ID="InputfileVideoUpload" runat="server" CssClass="txt" Width="460px" />
                    &nbsp;<asp:Button ID="btnUpload" runat="server" Text="上传" CssClass="btn" OnClientClick="javascript:return checkVideoExtension();ToggleVisibility('ProgressBar','on')"
                        OnClick="btnUpload_Click" />
                    <div id="ProgressBar">
                        <Upload:ProgressBar ID="pbProgressBar" runat="server" Inline="true" Width="100%">
                        </Upload:ProgressBar>
                    </div>
                </div>
                <h3>
                    视频详细信息填写
                </h3>
                <div id="videoExtensionChange">
                    <ul style="margin-top: 5px;">
                        <li><span>视频标题：<input type="text" id="txtVideoTitle" runat="server" class="txt" style="width: 250px;"
                            maxlength="30" size="20" /></span></li>
                        <li><span>视频简介：<textarea id="txtVideoContent" runat="server" class="txt" cols="1"
                            rows="3" style="width: 250px;"></textarea></span></li>
                        <li><span>视频类型：<asp:DropDownList ID="dropVideoType" runat="server" Height="24px"
                            Width="150px">
                            <asp:ListItem Value="">--视频类型--</asp:ListItem>
                            <asp:ListItem Value="film">电影</asp:ListItem>
                            <asp:ListItem Value="sport">体育</asp:ListItem>
                            <asp:ListItem Value="humour">搞笑</asp:ListItem>
                            <asp:ListItem Value="cartoon">动漫</asp:ListItem>
                            <asp:ListItem Value="music">歌曲MV</asp:ListItem>
                            <asp:ListItem Value="tv">电视剧</asp:ListItem>
                        </asp:DropDownList>
                        </span></li>
                        <li style="text-align: center;">
                            <asp:Button ID="btnChangeExtension" runat="server" Text="转化视频" CssClass="btn" OnClientClick="javascript:return check();"
                                OnClick="btnChangeExtension_Click" /></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
