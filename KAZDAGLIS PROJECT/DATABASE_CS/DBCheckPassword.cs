using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT
{
    class DBCheckPassword
    {

        public string Password;
        public string Username;

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public DBCheckPassword(string username, string password)
        {
            Password = password;
            Username = username;
        }

        public bool DBPasswordCheck(string username, string password)
        {
            bool isPasswordCorrect = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users where Username = @Username and Password = @Password", con);
            cmd.Parameters.AddWithValue("@Username", username);//.Text);
            cmd.Parameters.AddWithValue("@Password", password);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {                
                if (dr.HasRows == true)
                {
                    Console.WriteLine($"User {Username} Exists");
                    isPasswordCorrect = true;
                    break;
                }
                else isPasswordCorrect = false;
            }
            return isPasswordCorrect;
        }
    }
}
