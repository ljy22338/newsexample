using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MySql.Data.MySqlClient;
using MySQL.Data.EntityFrameworkCore;

namespace newsexample
{
    public class GlobalMysql : HttpApplication
    {
        public class Item
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
        }
        string connStr = "server=43.139.219.177;port=7923;uid=root;pwd=qazxcvx123456;database=news";
        public List<Item> getArticle()
        {



            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM article";
                List<Item> list = new List<Item>();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.Col1 = reader.GetString(0);
                        item.Col2 = reader.GetString(1);
                        list.Add(item);
                    }
                }


                return list;
            }

        }
    }

    public class ArticleDAO
    {
        private readonly string connectionString = "server=43.139.219.177;uid=root;pwd=123456;database=news";



        public void CreateArticle(string title, string content, long categoryId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO article (title, content, cid) VALUES (@title, @content, @categoryId)", conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateArticle(long id, string title, string content, long categoryId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("UPDATE article SET title = @title, content = @content, cid = @categoryId WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteArticle(string title)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM article WHERE title = @title", conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Article> GetArticlesByTitle(string title)
        {
            List<Article> articles = new List<Article>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM article WHERE title = @title", conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(reader.GetOrdinal("id"));
                        string content = reader.GetString(reader.GetOrdinal("content"));
                        long categoryId = reader.GetInt64(reader.GetOrdinal("cid"));
                        articles.Add(new Article(id, title, content, categoryId));
                    }
                }
            }
            if (articles.Count == 0) { articles.Add(new Article(0, "", "", 0)); }
            return articles;
        }
        public List<Article> GetArticlesById(long id)
        {
            List<Article> articles = new List<Article>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM article WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string content = reader.GetString(reader.GetOrdinal("content"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        long categoryId = reader.GetInt64(reader.GetOrdinal("cid"));
                        articles.Add(new Article(id, title, content, categoryId));
                    }
                }
            }
            return articles;
        }
        public List<Article> GetArticlesByCid(long cid)
        {
            List<Article> articles = new List<Article>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM article WHERE cid = @cid", conn))
            {
                cmd.Parameters.AddWithValue("@cid", cid);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string content = reader.GetString(reader.GetOrdinal("content"));
                        string title = reader.GetString(reader.GetOrdinal("title"));
                        long id = reader.GetInt64(reader.GetOrdinal("id"));
                        articles.Add(new Article(id, title, content, cid));
                    }
                }
            }
            return articles;
        }
    }

    public class Article
    {
        public long Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long CategoryId { get; set; }

        public Article(long id, string title, string content, long categoryId)
        {
            Id = id;
            Title = title;
            Content = content;
            CategoryId = categoryId;
        }
    }
    public class CategoryDAO
    {
        private readonly string connectionString = "server=43.139.219.177;uid=root;pwd=123456;database=news";

        public void CreateCategory(string cname)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO category (cname) VALUES (@cname)", conn))
            {
                cmd.Parameters.AddWithValue("@cname", cname);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCategory(long id, string cname)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("UPDATE category SET cname = @cname WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(string cname)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM category WHERE  cname = @cname", conn))
            {
                cmd.Parameters.AddWithValue("@cname", cname);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Category GetCategoriesByCName(string cname)
        {
            Category category = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM category WHERE cname = @cname", conn))
            {
                cmd.Parameters.AddWithValue("@cname", cname);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("cname"));
                        category = new Category(id, name);
                    }
                }
            }
            return category;
        }
        public Category GetCategoriesById(long id)
        {
            Category category = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM category WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("cname"));
                        category = new Category(id, name);
                    }
                }
            }
            return category;
        }
        public List<Category> GetCategories()
        {
            List<Category> categorys = new List<Category>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM category", conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("cname"));
                        long id = reader.GetInt64(reader.GetOrdinal("id"));
                        categorys.Add(new Category(id, name));
                    }
                }
            }
            return categorys;
        }
    }

    public class Category
    {
        public long Id { get; }
        public string Name { get; set; }

        public Category(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class MvcApplication : System.Web.HttpApplication
    {
        public static GlobalMysql globalMysql;
        public static ArticleDAO ArticleDAO;
        public static CategoryDAO CategoryDAO;
        public static Article Article = null;
        void Application_Start(object sender, EventArgs e)
        {
            ArticleDAO = new ArticleDAO();
            CategoryDAO = new CategoryDAO();
            globalMysql = new GlobalMysql();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
