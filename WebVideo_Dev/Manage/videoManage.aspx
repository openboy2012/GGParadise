<%@ Page Language="C#" AutoEventWireup="true" CodeFile="videoManage.aspx.cs" Inherits="Manage_videoManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.4.1-vsdoc.js"></script>

    <script type="text/javascript">
        function selectAll(a) {
            obj = document.getElementById('<%=dlstVideoInfo.ClientID %>').getElementsByTagName('input');
            var getobj = obj;
            for (i = 0; i < getobj.length; i++) {
                getobj[i].checked = a.checked;
            }
        }

        function GetChecks() {
            obj = document.getElementById('<%=dlstVideoInfo.ClientID %>').getElementsByTagName('input');
            var n = 0;
            var getobj = obj;
            for (i = 0; i < getobj.length; i++) {
                if (getobj[i].checked == true) {
                    n++;
                }
            }
            return n;
        }

        function checkDelete() {
            var i = GetChecks();
            if (i == 0) {
                alert("您没有选中任何记录，请选择至少一项");
                return false;
            }
            else {
                return confirm("是否全部删除您选中的记录？");
            }
        }

        function checkPass() {
            var i = GetChecks();
            if (i == 0) {
                alert("您没有选中任何记录，请选择至少一项");
                return false;
            }
            else {
                return confirm("是否全部通过审核您选中的记录？");
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
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
                                您现在的位置是：<a href="right.html">乖乖乐园管理首页</a>&gt;&gt;<a href="videoManage.aspx">视频管理</a>&gt;&gt;<asp:Label
                                    runat="server" ID="lblUrlAddress" CssClass="nav"></asp:Label>
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
                                <asp:UpdatePanel ID="upnlVideoManage" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" class="table2" style="width: 96%;">
                                            <tr>
                                                <th class="bar">
                                                    &nbsp;&nbsp; 视频管理页面
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="menu" align="center">
                                                    搜索：
                                                    <asp:DropDownList ID="dropVideoType" runat="server" CssClass="select" AutoPostBack="True"
                                                        OnSelectedIndexChanged="dropVideoType_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Text="--请选择视频类型--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Value="humour">幽默搞笑</asp:ListItem>
                                                        <asp:ListItem Value="sport">体育竞技</asp:ListItem>
                                                        <asp:ListItem Value="film">电影大片</asp:ListItem>
                                                        <asp:ListItem Value="music">歌曲MV</asp:ListItem>
                                                        <asp:ListItem Value="tv">电 视 剧</asp:ListItem>
                                                        <asp:ListItem Value="cartoon">动漫游戏</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="dropOrderBy" runat="server" CssClass="select" AutoPostBack="True"
                                                        OnSelectedIndexChanged="dropOrderBy_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--请选择排序类型--</asp:ListItem>
                                                        <asp:ListItem Value="1">人气</asp:ListItem>
                                                        <asp:ListItem Value="2">时间</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtKey" runat="server" CssClass="txt" Text="请输入关键字" OnFocus="javascript:this.select()"></asp:TextBox>
                                                    <asp:ImageButton ID="ibtnSearch" runat="server" Enabled="false" ImageUrl="~/Manage/images/btnSearch.gif"
                                                        OnClick="ibtnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="bar">
                                                    &nbsp;&nbsp; 视频列表
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 3px;">
                                                    <asp:DataList ID="dlstVideoInfo" runat="server" RepeatColumns="5" Width="800px">
                                                        <ItemTemplate>
                                                            <table id="videoTable" cellpadding="0" cellspacing="0" class="videolist_td" align="center">
                                                                <tr>
                                                                    <td style="padding: 2px 0 0 0;" align="center">
                                                                        <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="main" title='<%#Eval("videoTitle") %>'>
                                                                            <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="width: 130px;
                                                                                height: 80px;" /></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <a title='<%#Eval("videoTitle") %>' target="main" href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>'>
                                                                            <%#Common.interceptstr((string)Eval("videoTitle"),8)%></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td_color">
                                                                        &nbsp; 发布：<%#Eval("userName") %>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="td_color">
                                                                        &nbsp; 发布于：<%#Common.getIsDate(Convert.ToString(Eval("videoDate")))%>
                                                                        <input type="hidden" id="hdnId" runat="server" value='<%#Eval("id") %>' />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center" class="bar">
                                                                        <input type="checkbox" runat="server" id="chkId" />选择
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 30px" align="center">
                                                    <webdiyer:AspNetPager ID="AspNetPagerVideoInfo" runat="server" AlwaysShow="True"
                                                        CssClass="paginator" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页"
                                                        NextPageText="下一页" PrevPageText="上一页" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                                                        ShowCustomInfoSection="Left" CustomInfoHTML="共%PageCount%页，当前第%CurrentPageIndex%页"
                                                        SubmitButtonStyle="vertical-align: bottom" CustomInfoTextAlign="Left" Width="80%"
                                                        LayoutType="Table" ShowNavigationToolTip="true" UrlPageIndexName="pageindex"
                                                        CustomInfoStyle="pages" Height="30px" SubmitButtonText="Go" PageIndexBoxStyle="border:1px solid #000"
                                                        SubmitButtonImageUrl="images/btngo.gif" OnPageChanged="AspNetPagerVideoInfo_PageChanged">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="menufooter">
                                                    <span style="padding-left: 50px"></span>
                                                    <input type="checkbox" runat="server" id="checkAll" onclick="selectAll(this);" />全选
                                                    <span style="padding-left: 500px"></span>
                                                    <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="btn" OnClick="btnDelete_Click"
                                                        OnClientClick="return checkDelete();" />
                                                    &nbsp;<asp:Button ID="btnPass" runat="server" Text="确定" CssClass="btn" OnClick="btnPass_Click"
                                                        Visible="false" OnClientClick="return checkPass()" />
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
