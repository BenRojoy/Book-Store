using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class LoginSQLImpl : ILoginRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        SqlCommand comm = new SqlCommand();

        public string[] UserLogin(Login login)
        {
            comm.CommandText = "select name, type from users where username = '" + login.Username + "' and password = '" + login.Password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                string[] obj = new string[2];
                obj[0] = reader["name"].ToString();
                obj[1] = reader["type"].ToString();
                conn.Close();
                return obj;
            }
            else
            {
                conn.Close();
                return null;
            }
        }
    }
}