<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="play.aspx.cs" Inherits="UserPage_play" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="loginedControl.ascx" TagName="loginedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/body.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function checkPublish() {
            var contents = document.getElementById('<%=txtComment.ClientID%>').value;
            var code = document.getElementById('<%=txtCode.ClientID %>').value;
            if (contents == "") {
                alert('评论内容不能为空！');
                return false;
            }
            else {
                if (contents.length < 6) {
                    alert('评论内容的长度不能小于6个字符！');
                    return false;
                }
            }
            if (code == "") {
                alert('验证码不能为空');
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
            <div id="left" style="width: 568px;">
                <h2 class="videoplaying">
                    Video Playing</h2>
                <div>
                    <table style="width: 100%" cellpadding="0" cellspacing="0" class="border" align="center">
                        <tr>
                            <th class="th_bg" align="center">
                                您正在收看的是：<a class="red"><% =videoTitle %></a> （已经播放<a class="red"><% =playSum %></a>次）
                            </th>
                        </tr>
                        <tr>
                            <td align="center" class="tdindex">
                                <asp:UpdatePanel ID="upnlEval" runat="server">
                                    <ContentTemplate>
                                        <div style="width: 300px;">
                                            <span style="width: 120px; float: left;"><span class="upcolor">顶一下</span>
                                                <asp:ImageButton ID="ibtnFlower" runat="server" ImageUrl="~/UserPage/images/up.gif"
                                                    OnClick="ibtnFlower_Click" ToolTip="点这顶一下该视频" /><span class="upcolor">
                                                        <% =flower  %></span> </span><span style="width: 120px; float: right;"><span class="downcolor">
                                                            踩一下</span>
                                                            <asp:ImageButton ID="ibtnTile" runat="server" ImageUrl="~/UserPage/images/down.gif"
                                                                OnClick="ibtnTile_Click" ToolTip="点这踩一下该视频" />
                                                            <span class="downcolor">
                                                                <% =tile  %></span> </span>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdindex" align="center">
                                <asp:Literal ID="ltlPlay" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdindex" align="center">
                                <asp:UpdatePanel ID="upnlComment" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <th class="th_bg" align="left">
                                                    &nbsp;&nbsp; 影片评论 --<a class="red">
                                                        <%=videoTitle %></a>(共<a class="red"><%=count %></a>条 )
                                                </th>
                                            </tr>
                                            <tr>
                                                <td class="tdindex" align="center">
                                                    <asp:DataList ID="dlstComment" runat="server" Width="100%">
                                                        <ItemTemplate>
                                                            <div class="content">
                                                                <table cellpadding="0" cellspacing="0" style="width: 90%; margin: auto; border: solid 1px #111;"
                                                                    align="center">
                                                                    <tr>
                                                                        <td class="cmmtitle" align="left" style="padding-left: 3px;">
                                                                            <asp:Label ID="txtUid" runat="server" CssClass="cmmuser"><%#Eval("userName") %>（<%#Eval("ip") %>）</asp:Label>
                                                                            在
                                                                            <%#Common.getIsDate(Convert.ToString(Eval("issuanceDate")))%>发表评论:
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="cmmcontent" align="left" style="padding-left: 8px;">
                                                                            <asp:Label ID="txtCommentcontent" runat="server" Text='<%#Common.displayFormat((string)Eval("contents")) %>'> </asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-left: 5px;" class="tdindex">
                                                    <webdiyer:AspNetPager ID="AspNetPagerVideoInfo" runat="server" AlwaysShow="True"
                                                        NumericButtonCount="5" CssClass="paginator" CurrentPageButtonClass="cpb" CustomInfoHTML="共%PageCount%页，第%CurrentPageIndex%页"
                                                        CustomInfoStyle="pages" CustomInfoTextAlign="Left" FirstPageText="首页" Height="30px"
                                                        LastPageText="尾页" LayoutType="Table" NextPageText="后页" OnPageChanging="AspNetPagerVideoInfo_PageChanging"
                                                        PageIndexBoxStyle="border:1px solid #000" PageIndexBoxType="TextBox" PageSize="5"
                                                        PrevPageText="前页" ShowCustomInfoSection="Left" ShowNavigationToolTip="true" ShowPageIndexBox="Always"
                                                        SubmitButtonImageUrl="images/btngo.gif" SubmitButtonStyle="vertical-align: bottom"
                                                        UrlPageIndexName="pageindex" Width="90%" CurrentPageButtonPosition="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="th_bg" align="left">
                                                    &nbsp;&nbsp;发表评伦
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center" class="tdindex">
                                                    <asp:TextBox ID="txtComment" runat="server" Height="120px" TextMode="MultiLine" Width="480px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="tdindex">
                                                    <span style="font-size: 14px; font-family: 微软雅黑;">请输入验证码：</span>
                                                    <input id="txtCode" type="text" runat="server" class="txtcode" />
                                                    <img id="imgCode" alt="validateCode" title="验证码，看不清楚点击刷新" src="CreateCode.aspx" onclick="this.src=this.src+'?'"
                                                        align="absmiddle" class="hand" />
                                                    <asp:Button ID="btnSubmit2" runat="server" Text="发表评论" OnClick="btnSubmit2_Click"
                                                        CssClass="btn3" OnClientClick="return checkPublish();" ToolTip="发表评论" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                <h2 class="bulletin">
                    Video Infomation <span>视频信息</span></h2>
                <ul class="videoInfo">
                    <li><span>视频简介：<span style="color: #00f; width: 90%;">&nbsp;&nbsp;&nbsp;&nbsp;<%=videoContent %></span></span></li>
                    <li><span>发布人：<a href="#"><%=userName %></a></span></li>
                    <li><span>上传于：<%=videoDate%></span></li>
                </ul>
            </div>
            <p class="rightBot">
            </p>
            <p id="lTop" class="rightTop">
            </p>
            <div id="rightBody" class="right">
                <uc1:loginedControl ID="loginedControl" runat="server" />
            </div>
            <p id="lBot" class="rightBot">
            </p>
            <!--right end -->
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
    <!--bodyTop end -->
    <!--bodyBot start -->
    <div id="bodyBotMain">
        <div id="bodyBot">
            <!--story start -->
            <div id="story">
                <h2>
                    Stories</h2>
                <ul>
                    <li><a href="#">Nulla nisl, auctor vitae, tempus et, congue fermenm,</a></li>
                    <li><a href="#">Ante. Praesent neque ante,</a></li>
                    <li><a href="#">Imperdiet eu, dapibus aliquam, pretium a, auguena</a></li>
                    <li><a href="#">Erat. Vivamus vel tellus ut mi ultricies</a></li>
                    <li><a href="#">Adipiscing. Ut sed sem. Proin mauris elit, faucibus</a></li>
                    <li><a href="#">Vitae, nonummy in, fringi</a></li>
                </ul>
                <a href="#" class="rm3">Read More</a>
                <br class="spacer" />
            </div>
            <!--story end -->
            <!--event start -->
            <div id="event">
                <h2>
                    Events</h2>
                <ul>
                    <li><a href="#">Donec sed urna. Nulla consectetuer, nisi eget</a></li>
                    <li><a href="#">ullamcorper luctus, libero neque nonummy iseu</a></li>
                    <li><a href="#">pharetra libero ligula in leo. Aliquam blandit callis</a></li>
                    <li><a href="#">quam. Vestibulum</a></li>
                    <li><a href="#">nonummy, justo turpis tincidunt lorem, a mo velit</a></li>
                    <li><a href="#">Vitae, nonummy in, fringi</a></li>
                </ul>
                <a href="#" class="rm4">Read More</a>
                <br class="spacer" />
            </div>
            <!--event end -->
            <a href="#" class="whatNew"></a>
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
</asp:Content>
