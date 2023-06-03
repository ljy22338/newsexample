using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApplication6.GlobalMysql;

namespace WebApplication6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Label1.Text = "当前时间：" + currentTime;

            if (!IsPostBack)
            {
                List<Item> items = Global.globalMysql.getArticle();
                items = items.Select(x => {
                    x.Col2 = x.Col2.Length > 50 ? x.Col2.Substring(0, 50) : x.Col2;
                    return x;
                }).ToList();
                repArticles.DataSource = items;
                repArticles.DataBind();
            }


        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            var usernameText = username.Text;
            var passwordText = password.Text;

            if (passwordText == "qazxcv" && usernameText == "admin")
            {
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                   "alert", "alert('密码错误!')", true);
            }
        }
    }
}