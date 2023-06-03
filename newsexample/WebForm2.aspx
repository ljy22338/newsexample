<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication6.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .body {
            background-image: url('image/background.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
</head>
<body>
    <style>
        .category_management{
            border: 1px solid #ddd;
    float: left;
    width: 49%;
        }
        .news_management{
            border: 1px solid #ddd;
    float: right;
    width: 50%;
        }
    </style>
    <form id="form1" runat="server">
        <div>
            <!--显示时间-->
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                      <!-- <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>-->     
                </ContentTemplate>
            </asp:UpdatePanel>

              <hr style="height:3px; border:1px; color:#333; background-color:#333; font-weight:bold;" />


        <div class="category_management" align="center" >
            <h4>分类管理</h4><br />
           <p> 添加分类<asp:TextBox ID="addcategory_text" runat="server" Height="20px" Width="100px"></asp:TextBox>
            <asp:Button ID="addcategory" runat="server" Text="确认" Onclick="AddCategory_Click"/></p>
           <p> 删除分类<asp:DropDownList ID="category" runat="server" Height="20px" Width="100px"></asp:DropDownList>
            <asp:Button ID="delcategory" runat="server" Text="确认" Onclick="DelCategory_Click"/></p>
        </div>
 
        <div class="news_management" align="center">
            <h4>新闻管理</h4><br />
            <p>选择分类<asp:DropDownList ID="category_select" runat="server" OnSelectedIndexChanged="SelectCategory_Click" AutoPostBack="true"></asp:DropDownList></p>
            <p>选择新闻<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="SelectNews_Click" AutoPostBack="true"></asp:DropDownList></p>
            <hr />
            <p>新闻标题<asp:TextBox ID="title" runat="server" Height="15px" Width="100px"></asp:TextBox></p>
           <p> 选择分类<asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="100px"></asp:DropDownList></p>
            <p>正文<br />
                <asp:TextBox ID="content" runat="server" TextMode="MultiLine" Height="500px" Width="400px"></asp:TextBox></p>

            <asp:Button ID="modify" runat="server" Text="修改" Onclick="ModifyArticle_Click"/>  
            <asp:Button ID="delete" runat="server" Text="删除" Onclick="DelArticle_Click"/> 
            <asp:Button ID="increase" runat="server" Text="添加" OnClick="AddArticle_Click" />
        </div>
            
        </div>


    </form>
</body>
</html>

 