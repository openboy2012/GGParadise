<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Manage_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
    <title>乖乖乐园管理中心</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8">

    <script type="text/javascript">
        function initAll() {
            window.parent.frames["topFrame"].document.getElementById("u").innerHTML = "<%=UserName %>";
            window.parent.frames["topFrame"].document.getElementById("g").innerHTML = "<%=Group %>";
            window.parent.frames["topFrame"].document.getElementById("privilege").value = "<%=Privilege %>";
            window.parent.frames["leftFrame"].document.getElementById("privilege").value = "<%=Privilege %>";
        }
        window.onload = initAll;
    </script>

</head>
<frameset rows="59,*" frameborder="no" border="0" framespacing="0">
    <frame src="top.html" noresize="noresize" frameborder="0" name="topFrame" marginwidth="0"
        marginheight="0" scrolling="no" />
    <frameset rows="*" cols="195,*" id="frame">
        <frame src="left.html" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0"
            frameborder="0" scrolling="auto" />
        <frame src="right.html" name="main" marginwidth="0" marginheight="0" frameborder="0"
            scrolling="yes" />
    </frameset>
    <noframes>
        <body>
            <form id="form1" runat="server">
            <div>
            </div>
            </form>
        </body>
    </noframes>
</frameset>
</html> 