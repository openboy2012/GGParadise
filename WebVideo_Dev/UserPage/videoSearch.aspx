<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="videoSearch.aspx.cs" Inherits="UserPage_videoSearch" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/body.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function() {
            $("span.detail").hide();
            $('<a class="reveal" title="查看详细信息">查看详细&gt;&gt;</a> ').insertBefore('.detail');
            $("a.reveal").click(function() {
                $(this).parents("p").children("span.detail").fadeIn(2500);
                $(this).parents("p").children("a.reveal").fadeOut(600);
                $(this).parents("p").children("span.undis").fadeOut(600);
            });
        }); 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bodyTopMain">
        <div id="bodyTop2">
            <!--left start -->
            <div id="left" style="width: 630px;">
                <table style="width: 96%; height: auto" class="border" cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="th_bg" align="left">
                            &nbsp;&nbsp;视 频 搜 索
                        </th>
                    </tr>
                    <tr>
                        <td class="tdmenu" align="center" valign="middle">
                            <span>搜 索：</span><asp:DropDownList ID="dropType" runat="server">
                                <asp:ListItem Selected="True" Value="1">视频</asp:ListItem>
                                <asp:ListItem Value="2">会员</asp:ListItem>
                                <asp:ListItem Value="3">相册</asp:ListItem>
                                <asp:ListItem Value="4">影评</asp:ListItem>
                            </asp:DropDownList>
                            <input runat="server" id="txtKey" maxlength="30" size="30" style="height: 20px; border: solid 1px #808080;
                                font: normal 12px/20px Arial;" />
                            <asp:ImageButton ID="ibtnVideoSearch" runat="server" ImageUrl="~/UserPage/images/btnSearch.gif"
                                align="absmiddle" OnClick="ibtnSearch_Click"></asp:ImageButton>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbody">
                            <asp:DataList ID="dlstVideoInfo" runat="server" Width="100%" CssClass="DataListStyle">
                                <ItemTemplate>
                                    <table style="width: 630px; height: auto;" cellpadding="0" cellspacing="0" align="center">
                                        <tr>
                                            <td>
                                                <table style="width: 630px; height: auto;">
                                                    <tr>
                                                        <td style="width: 150px;" align="center">
                                                            <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                                <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                                    width: 127px; height: 80px; border: solid 2px #B8AF55;" /></a>
                                                        </td>
                                                        <td style="width: 480px; height: auto; text-align: center;" align="center">
                                                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                <tr>
                                                                    <th align="left">
                                                                        <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' title='<%#Eval("videoTitle") %>'>
                                                                            <%#Eval("videoTitle") %></a><span style="color: #00f"><%=typeName %></span>
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <span>发布人：</span> <a href='#' title='<%#Eval("userName") %>'>
                                                                            <%#Eval("userName") %></a><span> | 播放次数：</span><span title='<%#Eval("playSum") %>'
                                                                                style="color: #f00;"><%#Eval("playSum")%></span> <span>| 发布时间：</span><%#DateTime.Parse(Eval("videoDate").ToString()).ToString("yyyy-MM-dd")%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="height: 13px">
                                                                        <span>视频简介：</span>
                                                                        <p id="detail">
                                                                            <span class="undis" style="color: #003399;">
                                                                                <%#Common.interceptstr((string)Eval("videoContent"), 12) %></span><span class="detail"
                                                                                    style="color: #003399;" title='<%#Eval("videoContent") %>'><%#Eval("videoContent")%></span></p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <img alt="被顶次数" src="images/up.gif" /><span style="color: #00f;"><%#Eval("flower") %></span>
                                                                        <img alt="被踩次数" src="images/down.gif" /><span style="color: #f00;"><%#Eval("tile") %></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px 0;">
                                                <table cellpadding="0" cellspacing="0" style="width: 98%;" align="center">
                                                    <tr>
                                                        <td>
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle CssClass="DataListItemStyle" />
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbody">
                            <webdiyer:AspNetPager ID="AspNetPagerSearch" runat="server" AlwaysShow="True" CssClass="paginator"
                                NumericButtonCount="5" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页"
                                NextPageText="下一页" PrevPageText="上一页" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                                ShowCustomInfoSection="Left" CustomInfoHTML="共%PageCount%页，当前第%CurrentPageIndex%页"
                                SubmitButtonStyle="vertical-align: bottom" CustomInfoTextAlign="Left" Width="90%"
                                LayoutType="Table" ShowNavigationToolTip="true" UrlPageIndexName="pageindex"
                                CustomInfoStyle="pages" Height="30px" SubmitButtonText="Go" PageIndexBoxStyle="border:1px solid #000"
                                SubmitButtonImageUrl="images/btngo.gif" OnPageChanged="AspNetPagerVideoInfo_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table>
            </div>
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
</asp:Content>
