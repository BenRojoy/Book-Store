using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class UserSQLImpl : IUserRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        public void AddUser(Users user)
        {
            comm.CommandText = "insert into users values ('" + user.Name + "', '" + user.Username + "', '" + user.Password +
                "', '" + user.Email + "', " + user.Mobile + ", 1, 'user')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteUser(int userId)
        {
            comm.CommandText = "delete from users where userid = " + userId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Users> GetUsers()
        {
            List<Users> list = new List<Users>();
            comm.CommandText = "select * from users where type = 'user'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["UserId"]);
                string name = reader["Name"].ToString();
                //string username = reader["Username"].ToString();
                //string password = reader["Password"].ToString();
                string email = reader["Email"].ToString();
                Int64 mobile = Convert.ToInt64(reader["Mobile"]);
                int status = Convert.ToInt32(reader["AccountStatus"]);
                list.Add(new Users(id, name, null, null, email, mobile, status));
            }
            conn.Close();
            return list;
        }

        public void UpdateUser(Users user)
        {
            comm.CommandText = "update users set name = '" + user.Name + "', username = '" + user.Username + "', password = '" +
                user.Password + "', email = '" + user.Email + "', mobile = " + user.Mobile + " where userid = " + user.UserId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void AdminUpdateUser(int id, int status)
        {
            comm.CommandText = "update users set accountstatus = " + status + " where userid = " + id;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

    }
}