using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Backend.Models
{
    public class CategorySQLImpl : ICategoryRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddCategory(Category category)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            comm.CommandText = "insert into category values ('" + category.CategoryName + "', '"
                + category.Description + "', '" + category.Image + "', " + category.Status
                + ", " + category.Position + ", '" + dateTime + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteCategory(int CatId)
        {
            comm.CommandText = "delete from category where categoryid = " + CatId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from category where status = 1 order by position";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string name = reader["CategoryName"].ToString();
                string desc = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                int status = Convert.ToInt32(reader["Status"]); 
                int pos = Convert.ToInt32(reader["Position"]);
                string dateTime = reader["CreatedAt"].ToString();
                list.Add(new Category(id, name, desc, img, status, pos, dateTime));
            }
            conn.Close();
            return list;
        }

        public void UpdateCategory(Category category)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            comm.CommandText = "update category set categoryname = '" + category.CategoryName 
                + "', description = '" + category.Description + "', image = '" + category.Image 
                + "', status = " + category.Status + ", position = " + category.Position 
                + ", createdat = '" + dateTime + "' where categoryid = " + category.CategoryId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}