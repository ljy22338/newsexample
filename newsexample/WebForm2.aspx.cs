using newsexample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebApplication6
{
    public partial class WebForm2 : System.Web.UI.Page
    {

   
        protected void Page_Load(object sender, EventArgs e)
        {
   //         Label1.Enabled = true;
            if (!IsPostBack)
            {
                LoadPageData();
            }


        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "当前时间：" + DateTime.Now.ToString();
        }
        protected void LoadPageData()
        {
            List<Category> list = MvcApplication.CategoryDAO.GetCategories();
            List<string> names = (from c in list select c.Name).ToList();
            category_select.DataSource = names;
            category_select.DataBind();
            DropDownList2.DataSource = names;
            DropDownList2.DataBind();
            category.DataSource = names;
            category.DataBind();



            string categoryName = category_select.SelectedItem.Text;
            long id = MvcApplication.CategoryDAO.GetCategoriesByCName(categoryName).Id;
            List<Article> list1 = MvcApplication.ArticleDAO.GetArticlesByCid(id);
            List<string> names1 = (from c in list1 select c.Title).ToList();
            DropDownList1.DataSource = names1;
            DropDownList1.DataBind();
  

            Label1.Text = "当前时间：" + DateTime.Now.ToString();

            if (DropDownList1.SelectedItem != null)
            {
                Article article = MvcApplication.ArticleDAO.GetArticlesByTitle(DropDownList1.SelectedItem.Text).First();
                MvcApplication.Article = article;
                title.Text = article.Title;
                DropDownList2.SelectedIndex = category_select.SelectedIndex;
                content.Text = article.Content;
            }

        }
        protected void AddCategory_Click(object sender, EventArgs e)
        {
            MvcApplication.CategoryDAO.CreateCategory(addcategory_text.Text);
        }
        protected void DelCategory_Click(object sender, EventArgs e)
        {
           MvcApplication.CategoryDAO.DeleteCategory(category.SelectedItem.Text);
        }




        protected void ModifyArticle_Click(object sender, EventArgs e)
        {

            long cid = MvcApplication.CategoryDAO.GetCategoriesByCName(DropDownList2.SelectedItem.Text).Id;

            
            MvcApplication.ArticleDAO.UpdateArticle(MvcApplication.Article.Id, title.Text, content.Text, cid);
        }
        protected void DelArticle_Click(object sender, EventArgs e)
        {
            MvcApplication.ArticleDAO.DeleteArticle(title.Text);
        }       
        protected void AddArticle_Click(object sender, EventArgs e)
        {
            long id = MvcApplication.CategoryDAO.GetCategoriesByCName(category_select.SelectedItem.Text).Id;
            MvcApplication.ArticleDAO.CreateArticle(title.Text, content.Text, id);
        }

        protected void SelectNews_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
            {
                Article article = MvcApplication.ArticleDAO.GetArticlesByTitle(DropDownList1.SelectedItem.Text).First();
                title.Text = article.Title;
                MvcApplication.Article = article;
                DropDownList2.SelectedIndex = category_select.SelectedIndex;
                content.Text = article.Content;
            }
        }        
        protected void SelectCategory_Click(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
            string categoryName = category_select.SelectedItem.Text;
            long id =MvcApplication.CategoryDAO.GetCategoriesByCName(categoryName).Id;
            List<Article> list = MvcApplication.ArticleDAO.GetArticlesByCid(id);
            List<string> names = (from c in list select c.Title).ToList();
            DropDownList1.DataSource = names;
            DropDownList1.DataBind();


            if (DropDownList1.SelectedItem != null)
            {
                Article article = MvcApplication.ArticleDAO.GetArticlesByTitle(DropDownList1.SelectedItem.Text).First();
                title.Text = article.Title;
                MvcApplication.Article = article;
                DropDownList2.SelectedIndex = category_select.SelectedIndex;
                content.Text = article.Content;
            }

        }

    }
}