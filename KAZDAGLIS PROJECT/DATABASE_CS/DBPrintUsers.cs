using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT.DATABASE_CS
{
    public class DBPrintUsers : AllMenus
    {



        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }
        public List<string> ListOfUsersString { get; set; }



        public List<SuperAdmin> DBUsersPrint()
        {
            var listOfUsers = new List<SuperAdmin>();
            var listOfUsersString = new List<string>();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users", con);
            //cmd.Parameters.AddWithValue("@Username", username);
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "/n Connection Slow! Try Again. Press any key to Continue");
                Console.ReadKey();
                MenuCall();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var User = new SuperAdmin
                {
                    Username = dr["Username"].ToString(),
                    IsAdmin = dr["AdminStatus"].ToString(),
                    IsSuperAdmin = dr["SuperAdminStatus"].ToString()
                };

                listOfUsers.Add(User);
            }
            return listOfUsers;
        }

        public void Printusers()
        {
            Console.Clear();
            Console.WriteLine("Users: ");
            string isAdmin = "";
            string isSuperAdmin = "";
            var listOfUsers = DBUsersPrint();
            foreach (SuperAdmin User in listOfUsers)
            {
                isSuperAdmin = "";
                isAdmin = "";
                if (User.IsAdmin == "True")
                {
                    isAdmin = "Admin";
                    isSuperAdmin = "";
                }
                else if (User.IsSuperAdmin == "True")
                {
                    isSuperAdmin = "Super Admin";
                    isAdmin = "";
                }
                else if (User.IsAdmin == "False" && User.IsSuperAdmin == "False")
                {
                    isAdmin = "User";
                }
                else
                {
                    isSuperAdmin = "";
                    isAdmin = "";
                }
                Console.WriteLine($"{User.Username}      \t {isAdmin}{isSuperAdmin}");

            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public List<string> DBUsersPrintString(string username)
        {
            var listOfUsers = new List<SuperAdmin>();
            var listOfUsersString = new List<string>();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users", con);
            //cmd.Parameters.AddWithValue("@Username", username);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var User = new SuperAdmin
                {
                    Username = dr["Username"].ToString(),
                    IsAdmin = dr["AdminStatus"].ToString(),
                    IsSuperAdmin = dr["SuperAdminStatus"].ToString()
                };

                //Console.WriteLine($"Adds {User.Username}");
                listOfUsersString.Add($"{User.Username}");
                
            }
            
            listOfUsersString.RemoveAll(x => x.Equals(username));
            listOfUsersString.Add("Main Menu");
            return listOfUsersString;
        }

        public List<string> DBUsersStatusPrintString()
        {
            var listOfUsers = new List<SuperAdmin>();
            var listOfUsersStatusString = new List<string>();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users", con);
            //cmd.Parameters.AddWithValue("@Username", username);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var User = new SuperAdmin
                {
                    Username = dr["Username"].ToString(),
                    IsAdmin = dr["AdminStatus"].ToString(),
                    IsSuperAdmin = dr["SuperAdminStatus"].ToString()
                };


                listOfUsersStatusString.Add($"{User.Username} - {User.IsAdmin} - {User.IsSuperAdmin}");
                
            }
            listOfUsersStatusString.Add("Main Menu");
            return listOfUsersStatusString;
        }

        //return listOfUsers;
        public DBPrintUsers(List<string> listOfUsersString)
        {
            this.ListOfUsersString = listOfUsersString;
        }
        public DBPrintUsers()
        {

        }
    }
}