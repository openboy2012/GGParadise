<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/UsePage.master" AutoEventWireup="true"
    CodeFile="videoClass.aspx.cs" Inherits="UserPage_videoClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <div id="bodyTop2">
            <!--left start -->
            <div id="left" style="width: 630px;">
                <table cellpadding="2" cellspacing="0" style="width: 100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="border" style="width: 98%; height: auto"
                                align="center">
                                <tr>
                                    <th class="th_bg" align="left">
                                        &nbsp;&nbsp; <span style="color: Silver">最新</span><span style="color: #f00;"><%=typeName %></span>视频<span
                                            style="padding-left: 440px"></span><a href="videoSearch.aspx?type=<%=type %>"><img
                                                src="images/more.gif" alt="more" title="获取更多" align="absmiddle" border="0" /></a>
                                    </th>
                                </tr>
                                <tr>
                                    <td align="center" class="tdindex">
                                        <asp:DataList ID="dlstNew" runat="server" RepeatColumns="4" Style="vertical-align: middle;
                                            margin-right: 0px;" Width="600px">
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
                                                            <td style="padding-top: 1px;">
                                                                <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' title='<%#Eval("videoTitle") %>'>
                                                                    <%#Common.interceptstr((string)Eval("videoTitle"),8)%></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 1px;">
                                                                发布：<%#Eval("userName") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 1px;">
                                                                发布于：<%#Common.getIsDate(Convert.ToString(Eval("videoDate")))%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="th_bg" align="left">
                                        &nbsp;&nbsp;<span style="color: #FFCC00">人气</span><span style="color: #f00;"><%=typeName %></span>视频
                                        <span style="padding-left: 440px"></span><a href="videoSearch.aspx?type=<%=type %>">
                                            <img src="images/more.gif" alt="more" title="获取更多" align="absmiddle" border="0" /></a>
                                    </th>
                                </tr>
                                <tr>
                                    <td align="center" class="tdindex">
                                        <asp:DataList ID="dlstPlaySum" runat="server" RepeatColumns="4" Style="vertical-align: middle;
                                            margin-right: 0px;" Width="590px">
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
                                                            <td style="padding-top: 1px;">
                                                                <a href='play.aspx?id=<%#Common.EncryptID(Eval("id").ToString()) %>' title='<%#Eval("videoTitle") %>'>
                                                                    <%#Common.interceptstr((string)Eval("videoTitle"),8)%></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 1px;">
                                                                发布：<%#Eval("userName") %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 1px;">
                                                                播放次数：<%#Eval("playSum") %>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--left end -->
            <!--right start -->
            <div id="rightTop" class="right">
                <ul>
                    <li></li>
                    <li></li>
                </ul>
            </div>
            <!--right end -->
            <br class="spacer" />
        </div>
        <br class="spacer" />
    </div>
</asp:Content>
