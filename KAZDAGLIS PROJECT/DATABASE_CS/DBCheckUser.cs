using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT
{
    class DBCheckUser
    {

        public string Username;

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }
        Guest guest = new Guest();

        public DBCheckUser(string username)
        {
            Username = username;
        }

        public DBCheckUser()
        {
            
        }

        public bool DBUserCheck(string username)
        {
            bool isUserExisted = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users where Username = @Username", con);
            cmd.Parameters.AddWithValue("@Username", username);
            SqlDataReader dr;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        Console.WriteLine("User Exists");
                        isUserExisted = true;
                        break;
                    }
                    else isUserExisted = false;
                }
                return isUserExisted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "/n Connection Slow! Try Again. Press any key to Continue..");
                Console.ReadKey();
                guest.MenuCall();
            }
            return false;
            
                        
            
        }
    }
}
