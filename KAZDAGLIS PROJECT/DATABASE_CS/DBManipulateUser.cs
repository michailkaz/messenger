using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT
{
    class DBManipulateUser
    {

        public string Username;

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public DBManipulateUser(string username)
        {
            Username = username;
        }
        
        public bool DBUserManipulate(string deleteUsername, string action, string actionString, string username, string password, string newUsername, string newPassword)
        {
            bool isUserDeleted = false;
            SqlConnection con = new SqlConnection(ConnectionString);
            //string actionString = "Select User delete from dbo.Users where Username = @Username";
            SqlCommand cmd = new SqlCommand("Select * from dbo.Users where Username = @Username", con);
            cmd.Parameters.AddWithValue("@Username", deleteUsername);
            
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    Console.WriteLine($"User {deleteUsername} Exists. \nShould I {action}??");
                    Console.CursorVisible = true;
                    Console.Write("Press any key to Continue. =>To Abort press ESC<= ...");
                    var key2 = Console.ReadKey();
                    Console.CursorVisible = false;
                    if (key2.Key == ConsoleKey.Escape)
                    {
                        AccessLevelCheck alc = new AccessLevelCheck();
                        Console.Clear();
                        alc.LevelMenuCall(username, password);
                    }
                    else
                    {
                        dr.Close();
                        SqlCommand cmdAction = new SqlCommand(actionString, con);
                        cmdAction.Parameters.AddWithValue("@Username", deleteUsername);
                        cmdAction.Parameters.AddWithValue("@NewUsername", newUsername);
                        cmdAction.Parameters.AddWithValue("@Password", newPassword);
                        try
                        {
                            Console.Clear();
                            SqlDataReader drDelete = cmdAction.ExecuteReader();
                            isUserDeleted = true;
                            Console.WriteLine($"User {deleteUsername}, {action} successfully!");
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + $"User {deleteUsername}, {action} NOT successfully!");
                            Console.ReadLine();
                        }
                        break;
                    }
                }
                else isUserDeleted = false;
            }
            return isUserDeleted;
        }

        public DBManipulateUser()
        {

        }

    }
}
