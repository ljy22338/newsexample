using newsexample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using static newsexample.GlobalMysql;

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
                List<Item> items = MvcApplication.globalMysql.getArticle();
                items = items.Select(x => {
                    x.Col2 = x.Col2.Length > 50 ? x.Col2.Substring(0, 50) : x.Col2;
                    return x;
                }).ToList();
                repArticles.DataSource = items;
                repArticles.DataBind();
            }


        }




    }
}