<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body>

        <style>
.head {
    display: inline-block;
}

.head ul {
    list-style: none;
    margin: 0;
    padding: 0;
}

.head ul li {
    display: inline-block;
}

.head ul li a {
    display: block;
    padding: 10px;
}

        body {
            background-image: url('\image\web.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-color: transparent;
        }

            /* ul {
                color:#ff0000;
                line-height:2;
    padding: 0;
    margin: 0;
    list-style: none;
  }
  
  li.span {
    margin-top: 35px;
    margin-bottom: 35px;
    background:linear-gradient(to right,#ff6a00,#00ff21) no-repeat;
    background-size:35px ,35px;
    transition:background-size 13000ms;
  }
  li.span:hover{
                      background-size:100%,2px;
  }*/
    </style>
    <form id="form1" runat="server">
        <div>
            <!--显示时间-->
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <script type="text/javascript">
                setInterval(function () {
                    var currentTime = new Date().toLocaleString();
                    document.getElementById('<%= Label1.ClientID %>').innerHTML = "当前时间：" + currentTime;
                }, 1000);
            </script>
        </div>
        <div class="head">
            <!-- 导航栏 -->
            <ul>
                <li><a href="WebForm1.aspx">返回首页</a></li>
                <li><a href="WebForm5.aspx">用户登录</a></li>
                <li><a href="WebForm6.aspx">用户注册</a></li>
            </ul>
        </div>
        <div class="content">
            <!-- 这里是页面的主要内容 -->
            <hr style="height:3px; border:0; color:#333; background-color:#333; font-weight:bold;" />               
            <asp:Repeater runat="server" ID="repArticles">
                <ItemTemplate>
                  <a href="#"> <h4> <%# Eval("Col1") %></h4></a>
                    <%# Eval("Col2") %>...<br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

