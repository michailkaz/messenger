using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.IO;

namespace KAZDAGLIS_PROJECT
{
    class AssignRoles
    {

        public string RoleUsername { get; set; }
        public int Role { get; set; }

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public static void DBRole(string roleUsername, int role)
        {
            DataTable Users = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                try
                {
                    if (role == 3)
                    {
                        string insertString = $@"use Project1 UPDATE [dbo].[Users] SET AdminStatus = 0, SuperAdminStatus = 1 WHERE Username = '{roleUsername}';"; //Command
                        SqlCommand cmd = new SqlCommand(insertString, conn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else if (role == 2)
                    {
                        string insertString = $@"use Project1 UPDATE [dbo].[Users] SET AdminStatus = 1, SuperAdminStatus = 0 WHERE Username = '{roleUsername}';"; //Command
                        SqlCommand cmd = new SqlCommand(insertString, conn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    else
                    {
                        string insertString = $@"use Project1 UPDATE [dbo].[Users] SET AdminStatus = 0, SuperAdminStatus = 0 WHERE Username = '{roleUsername}';"; //Command
                        SqlCommand cmd = new SqlCommand(insertString, conn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    //cmd.ExecuteNonQuery();  // Send command
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

                conn.Close();

            }

        }


        public string UserRoles(List<string> userMenu, string username, string password, int accessLevel)
        {
            AccessLevelCheck alc = new AccessLevelCheck(username, password, accessLevel);
            DATABASE_CS.DBPrintUsers pu = new DATABASE_CS.DBPrintUsers();

            SqlConnection con = new SqlConnection(pu.ConncetionString);
            List<string> listOfUsersString = pu.DBUsersPrintString(username);
            AllMenus am = new AllMenus(username, password, accessLevel);

            while (true)
            {
                for (int i = 0; i < listOfUsersString.Count; i++)
                {

                    Console.Clear();
                    Console.WriteLine("  MESSAGES CLIENT");
                    Console.WriteLine($"   Welcome <{username.ToUpper()}>!");
                    Console.WriteLine($"     Level: {accessLevel}");
                    Console.WriteLine();
                    Console.CursorVisible = true;
                    Console.WriteLine("Please Select User! Press any key to select..");
                    Console.ReadKey();
                    Console.CursorVisible = false;

                    string roleUsername = (Menu.MenuRun(listOfUsersString, username, accessLevel)).Trim();
                    #region Main Menus
                    if (roleUsername == "Main Menu")
                    {
                        Console.Clear();
                        alc.LevelMenuCall(username, password);
                    }
                    #endregion

                    #region List Menus
                    else
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("  MESSAGES CLIENT");
                        Console.WriteLine($"   Welcome <{username.ToUpper()}>!");
                        Console.WriteLine($"     Level: {accessLevel}");
                        Console.WriteLine();
                        string currentRole = alc.CheckAccessLevelByUsername(roleUsername);
                        Console.CursorVisible = true;
                        Console.WriteLine($"You selected (({roleUsername.Trim()})) whose role is ({currentRole}). \nPlease Select his Role! \nPress any key to select..");
                        Console.ReadKey();
                        Console.Clear();
                        Console.CursorVisible = false;
                        List<string> RoleList = new List<string> { "User", "Admin", "Super Admin", "Back" };
                        var AccessLevel = Menu.MenuRun(RoleList, username, accessLevel);
                        if (AccessLevel == "Super Admin")
                        {
                            DBRole(roleUsername, 3);
                        }
                        else if (AccessLevel == "Admin")
                        {
                            DBRole(roleUsername, 2);
                        }
                        else if (AccessLevel == "Back")
                        {
                            Console.Clear();
                            alc.LevelMenuCall(username, password);
                        }
                        else
                        {
                            DBRole(roleUsername, 1);
                        }
                        Console.Clear();
                        Console.WriteLine("  MESSAGES CLIENT");
                        Console.WriteLine($"   Welcome <{username.ToUpper()}>!");
                        Console.WriteLine($"     Level: {accessLevel}");
                        Console.WriteLine();
                        Console.WriteLine($"The new AccessLevel of User {roleUsername} is {AccessLevel}.");
                        Console.ReadKey();
                        Console.Clear();
                        alc.LevelMenuCall(username, password);

                    }
                    #endregion
                }
            }
        }


        public AssignRoles(string roleUsername, int role)
        {
            this.RoleUsername = roleUsername;
            Role = role;
        }
        public AssignRoles()
        {

        }
    }
}
