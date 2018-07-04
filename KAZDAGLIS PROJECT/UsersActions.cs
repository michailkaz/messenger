using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KAZDAGLIS_PROJECT.DATABASE_CS;

namespace KAZDAGLIS_PROJECT
{
    class UsersActions
    {
        public void ActionsUsers(List<string> superMenu, string username, string password, int accessLevel)
        {
            DBManipulateUser du = new DBManipulateUser();
            DATABASE_CS.DBPrintUsers pu = new DATABASE_CS.DBPrintUsers();
            List<string> listOfUsersString = pu.DBUsersPrintString(username);
            string changeUsername = (Menu.MenuRun(listOfUsersString, username, accessLevel)).Trim();
            Console.Clear();
            string SuperMenuItem = (Menu.MenuRun(superMenu, username, accessLevel)).Trim();
            string newUsername = "";
            string newPassword = "";

            if (SuperMenuItem == "Delete User")
            {
                string actionString = "delete from dbo.Users where Username = @Username; delete from dbo.Messages where Sender = @Username or Receiver = @Username;";
                du.DBUserManipulate(changeUsername, "delete", actionString, username, password, newUsername, newPassword);
            }

            else if (SuperMenuItem == "Change User's Password")
            {
                Console.Clear();
                Console.WriteLine("Change User's Password");
                Console.WriteLine();
                Console.CursorVisible = true;
                Console.WriteLine($"Please Enter new Password for user {changeUsername}: ");
                newPassword = Console.ReadLine().Trim();
                Console.CursorVisible = false;
                string actionString = "Update dbo.Users set Password = @Password where Username = @Username";
                du.DBUserManipulate(changeUsername, "change Password", actionString, username, password, newUsername, newPassword);
            }
            else if (SuperMenuItem == "Change User Role")
            {
                Console.Clear();
                Console.WriteLine("USER ROLES");
                Console.WriteLine("");
                DBPrintUsers pu2 = new DBPrintUsers();
                AssignRoles ar = new AssignRoles();
                SuperMenuItem = pu2.DBUsersPrintString(username).ToString();
                ar.UserRoles(listOfUsersString, username, password, accessLevel);
                Console.Clear();
            }
            else if (SuperMenuItem == "Change User's Username")
            {
                Console.Clear();
                Console.WriteLine("Change User's Username");
                Console.WriteLine();
                Console.CursorVisible = true;
                Console.WriteLine($"Please Enter new Username for user {changeUsername}: ");
                newUsername = Console.ReadLine().Trim();
                Console.CursorVisible = false;
                bool Verify = false;
                DBCheckUser dbc = new DBCheckUser();
                Verify = dbc.DBUserCheck(newUsername);
                int i = 0;
                while ((Verify == true || newUsername.Length < 1) && i < 2)
                {
                    i++;
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.WriteLine();
                    Console.WriteLine($"Username <<{newUsername}>> Exist. Try another one ({3 - i} more tries):");
                    Console.CursorVisible = true;
                    Console.Write("Username: ");
                    newUsername = Console.ReadLine().Trim();
                    Console.CursorVisible = false;

                    Verify = false;
                    Verify = dbc.DBUserCheck(newUsername);

                    if (i == 2 && Verify == true)
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        AccessLevelCheck alc = new AccessLevelCheck();
                        Console.CursorVisible = true;
                        Console.WriteLine("End of Tries!! \n Press any key to continue...");
                        Console.ReadKey();
                        Console.CursorVisible = false;
                        alc.LevelMenuCall(username, password);
                    }

                }
                string actionString = "Update dbo.Users set Username = @NewUsername where Username = @Username; Update dbo.Messages set Sender = @NewUsername where Sender = @Username; Update dbo.Messages set Receiver = @NewUsername where Receiver = @Username;";
                du.DBUserManipulate(changeUsername, "change Username", actionString, username, password, newUsername, newPassword);
            }
        }
    }
}
