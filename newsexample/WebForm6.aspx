<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="WebApplication6.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
            background-image: url('\image\web.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-color: transparent;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <!-- 这里是页面的注册部分 -->
                <h4 align="center">用户注册</h4>
                <hr style="height: 3px; border: 0; color: #333; background-color: #333; font-weight: bold;" />
                <br />
                <table align="center" cellpadding="4" cellspacing="0" border="0" width="300px" bgcolor="#dbdbdb">
                    <tr>
                        <td width="135px" height="35px" align="center">用户名:</td>
                        <td align="left">
                            <asp:TextBox ID="username" runat="server"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td height="35px" align="center">密码：</td>
                        <td align="left">
                            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="135px" height="35px" align="center">确认密码:</td>
                        <td align="left">
                            <asp:TextBox ID="checkpwd" runat="server" TextMode="Password"></asp:TextBox></td>                         
                    </tr>
                    <tr>
                        <td colspan="2" height="40px" align="center">
                            <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="reset" name="reset" type="reset" value="重置" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
