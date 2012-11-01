<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="indexPage.aspx.cs" Inherits="UserPage_indexPage" %>

<%@ Register Src="loginedControl.ascx" TagName="loginedControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/table.css" rel="stylesheet" type="text/css" />
    <link href="css/body.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a
        {
            font: 宋体;
            cursor: pointer;
            text-decoration: none;
            color: #670606;
        }
        a:hover
        {
            text-decoration: underline;
        }
        .bdr
        {
            border: solid 2px #B8AF55;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bodyTopMain">
        <div id="bodyTop">
            <!--left start -->
            <div id="left" style="width: 568px;">
                <table cellpadding="0" cellspacing="0" style="width: 100%" align="center" class="border">
                    <tr>
                        <th align="left" class="th_bg" valign="middle">
                            &nbsp;&nbsp; 电 影 大 片<span style="padding-left: 430px"></span><a href="videoSearch.aspx?type=film"><img
                                src="images/more.gif" alt="more" title="获取更多" align="absmiddle" border="0" /></a>
                        </th>
                    </tr>
                    <tr>
                        <td class="tdindex">
                            <asp:DataList ID="dlstFilm" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                Width="100%">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                            <tr>
                                                <td style="padding: 4px 0 0 0">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                        <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                            width: 127px; height: 80px;" class="bdr" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'>
                                                        <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" class="th_bg" valign="middle">
                            &nbsp;&nbsp; 动 漫 游 戏<span style="padding-left: 430px"></span><a href="videoSearch.aspx?type=cartoon"><img
                                src="images/more.gif" alt="more" title="获取更多" align="absmiddle" border="0" /></a>
                        </th>
                    </tr>
                    <tr>
                        <td class="tdindex">
                            <asp:DataList ID="dlstCartoon" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                Width="100%">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                            <tr>
                                                <td style="padding: 4px 0 0 0">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                        <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                            width: 127px; height: 80px;" class="bdr" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'>
                                                        <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" class="th_bg" valign="middle">
                            &nbsp;&nbsp; 体 育 竞 技<span style="padding-left: 430px"></span><a href="videoSearch.aspx?type=sport"><img
                                src="images/more.gif" alt="more" title="获取更多" align="absmiddle" border="0" /></a>
                        </th>
                    </tr>
                    <tr>
                        <td class="tdindex">
                            <asp:DataList ID="dlstSport" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                Width="100%">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                            <tr>
                                                <td style="padding: 4px 0 0 0">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                        <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                            width: 127px; height: 80px;" class="bdr" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'>
                                                        <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <th align="left" class="th_bg">
                            &nbsp;&nbsp; 幽 默 搞 笑<span style="padding-left: 430px"></span><a href="videoSearch.aspx?type=humour"><img
                                src="images/more.gif" align="absmiddle" alt="more" title="获取更多" border="0" /></a>
                        </th>
                    </tr>
                    <tr>
                        <td class="tdindex">
                            <asp:DataList ID="dlstHumour" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                Width="100%">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                            <tr>
                                                <td style="padding: 4px 0 0 0">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                        <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                            width: 127px; height: 80px;" class="bdr" /></a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px;">
                                                    <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'>
                                                        <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </div>
            <!--left end -->
            <p class="rightTop">
            </p>
            <!--right start -->
            <div id="rightTop" class="right">
                <h2 class="bulletin">
                    Bulletin GGParadise <span>站内公告</span></h2>
                <div id="BulletinTitle" class="bulletinTitle">
                    <%=blm.Title%>
                </div>
                <div id="BulletinContents">

                    <script type="text/javascript">
                        document.write('<marquee class="bulletin" direction="up" height="100" scrollamount="1" onmouseover="this.stop()" onmouseout="this.start()">');
                        document.write('&nbsp;&nbsp;&nbsp;&nbsp;<%=blm.Contents%>');
                        document.write('</marquee>'); 
                    </script>

                </div>
                <div id="BulletinDate" class="bulletinDate">
                    公告发布时间：<%=DateTime.Parse(blm.issuanceDate.ToString()).ToString("yyyy-MM-dd")%><span
                        style="padding-right: 10px;"></span>
                </div>
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
            <p class="rightTop">
            </p>
            <div id="videoTopClickDiv" class="right">
                <h2 class="th_bg" style="width: 97%; padding: 2px; text-align: center;">
                    乖乖乐园点击排行榜TOP5
                </h2>
                <asp:DataList ID="dlstTopClick" runat="server" Width="100%">
                    <ItemTemplate>
                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="text-align: left; padding-left: 10px;">
                                    <img alt="Top5排行榜" src="" style="width: 23px; height: 17px" />
                                    <a title='<%#Eval("videoTitle") %>' target='_blank' href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>'>
                                        <%#Common.interceptstr((string)Eval("videoTitle"),10)%>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; padding-left: 10px;">
                                    播放次数：<span id="playSum"><%#Eval("playSum")%></span>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <p class="rightBot">
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
                    电 视 剧</h2>
                <div>
                    <asp:DataList ID="dlstTV" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                        Width="100%">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                    <tr>
                                        <td style="padding: 4px 0 0 0">
                                            <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                    width: 127px; height: 80px; border: solid 2px #fff;" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 5px;">
                                            <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'
                                                style="color: #CF9201; font: bold 12px/20px Arial,Helvetica,sans-serif,宋体;">
                                                <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br class="spacer" />
            </div>
            <!--story end -->
            <!--event start -->
            <div id="event">
                <h2>
                    音 乐 Music</h2>
                <div>
                    <asp:DataList ID="dlstMusic" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                        Width="100%">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <table cellpadding="0" cellspacing="0" align="center" style="margin: auto;">
                                    <tr>
                                        <td style="padding: 4px 0 0 0">
                                            <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle") %>'>
                                                <img alt='<%#Eval("videoTitle") %>' src='<%#Eval("videoPicture") %>' style="vertical-align: middle;
                                                    width: 127px; height: 80px; border: solid 2px #fff;" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 5px;">
                                            <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' target="_blank" title='<%#Eval("videoTitle")%>'
                                                style="color: #CF9201; font: bold 12px/20px Arial,Helvetica,sans-serif,宋体;">
                                                <%#Common.interceptstr((string)Eval("videoTitle"), 8)%>
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <br class="spacer" />
            </div>
            <!--event end -->
            <a href="#" class="whatNew"></a>
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
</asp:Content>
