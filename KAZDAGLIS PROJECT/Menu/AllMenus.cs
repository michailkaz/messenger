using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using KAZDAGLIS_PROJECT.DATABASE_CS;

namespace KAZDAGLIS_PROJECT
{
    public class AllMenus
    {
        

        public static List<string> guestMenu = new List<string>() { "Log In", "Sign Up", "Exit" };
        public static List<string> userMenu = new List<string>() { "Send Mail", "Change Password", "Logout", "Exit" };
        public static List<string> adminMenu = new List<string>() { "Send Mail", "Users", "Logout", "Exit" };
        public static List<string> adminUsersMenu = new List<string>() { "Print Users", "Create New User", "View Users Messages", "Edit Users Messages", "Main Menu"};
        public static List<string> superAdminMenu = new List<string>() { "Send Mail", "Print Users", "Change User Role", "Users Manipulation", "View Users Messages", "Edit Users Messages", "Delete Users Messages", "Logout", "Exit" };
        public static List<string> superMenu = new List<string>() {"Create New User", "Delete User", "Change User's Password", "Change User's Username", "Change User Role", "Main Menu" };
        //public static List<string> messagesManipulationMenu = new List<string>() { "Main Menu" };


        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public Guest guest = new Guest();

        #region GUEST MENU
        public string GuestMenu(List<string> guestMenu)
        {
            while (true)
            {
                string selectedMenuItem = Menu.MenuRun(guestMenu, "Guest", 0);
                //GUEST MODULES - LEVEL 1

                #region LOGIN
                if (selectedMenuItem == "Log In")
                {
                    Console.Clear();
                    Console.CursorVisible = true;
                    Console.WriteLine("LOGIN");
                    Console.WriteLine();

                    #region USERNAME INPUT
                    Console.Write("Username: ");
                    var Username = Console.ReadLine().Trim();
                    DBCheckUser dbc = new DBCheckUser(Username);
                    bool Verify = true;
                    Verify = dbc.DBUserCheck(Username);
                    int i = 0;
                    while ((Verify == false || Username.Length < 1) && i < 2)
                    {
                        i++;
                        Console.Clear();
                        Console.WriteLine("LOGIN");
                        Console.WriteLine();
                        Console.WriteLine($"Username <<{Username}>> does not Exist. Try another one ({3 - i} more tries):");
                        Console.Write("Username: ");
                        Username = Console.ReadLine().Trim();

                        Verify = true;
                        Verify = dbc.DBUserCheck(Username);

                        if (i == 2 && Verify == false)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            GuestMenu(guestMenu);
                        }

                    }

                    #endregion

                    #region PASSWORD INPUT
                    //PASSWORD INPUT
                    
                    while (Username.Length == 0)
                    {
                        Console.CursorVisible = false;
                        GuestMenu(guestMenu);
                    }
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.WriteLine();
                    Console.WriteLine($"Welcome back {Username}! ");
                    //Console.Write("Password: ");
                    //var Password = Console.ReadLine().Trim();

                    var Password = PasswordMask().Trim();

                    Console.CursorVisible = false;
                    DBCheckPassword dbcp = new DBCheckPassword(Username, Password);
                    bool VerifyPassword = true;
                    VerifyPassword = dbcp.DBPasswordCheck(Username, Password);
                    int j = 0;
                    while ((VerifyPassword == false || Password.Length < 1) && j < 2)
                    {
                        j++;
                        Console.Clear();
                        Console.WriteLine("LOGIN");
                        Console.WriteLine();
                        Console.WriteLine($"Wrong Password. Are you sure you are {Username}? You have {3 - j} more tries.");
                        //Console.Write("Password: ");
                        //Password = Console.ReadLine().Trim();
                        Password = PasswordMask().Trim();
                        VerifyPassword = true;
                        VerifyPassword = dbcp.DBPasswordCheck(Username, Password);
                        //
                        if (j == 2 && VerifyPassword == false)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            GuestMenu(guestMenu);
                        }
                        
                    }
                    AccessLevelCheck alc = new AccessLevelCheck(Username, Password);
                    alc.CheckAccessLevel(Username, Password);
                    

                    //UserMenu(userMenu);
                    #endregion
                }

                #endregion

                #region Sign Up
                else if (selectedMenuItem == "Sign Up")  //Adds user to database
                {
                    Console.Clear();
                    Console.WriteLine("NEW USER");
                    Console.CursorVisible = true;
                    Console.Write("New Username: ");
                    var NewUsername = Console.ReadLine().Trim();
                    DBCheckUser dbc = new DBCheckUser(NewUsername);
                    bool VerifyNewUsername = false;
                    VerifyNewUsername = dbc.DBUserCheck(NewUsername);
                    int i = 0;
                    while ((VerifyNewUsername == true || NewUsername.Length < 1) && i < 2)
                    {
                        i++;
                        Console.Clear();
                        Console.WriteLine("NEW USER SIGNUP");
                        Console.WriteLine();
                        Console.WriteLine($"Username is Taken. Try another one ({3 - i} more tries):");
                        Console.Write("Username: ");
                        NewUsername = Console.ReadLine().Trim();

                        VerifyNewUsername = false;
                        VerifyNewUsername = dbc.DBUserCheck(NewUsername);

                        if (i == 2 && VerifyNewUsername == true)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            GuestMenu(guestMenu);
                        }
                    }
                    while (NewUsername.Length == 0)
                    {
                        GuestMenu(guestMenu);
                    }
                    Console.Write("New Password: ");
                    string NewPassword = Console.ReadLine().Trim();
                    Console.Write("Confirm New Password: ");
                    string NewPassword2 = Console.ReadLine().Trim();
                    int j = 0;
                    while ((NewPassword != NewPassword2 || NewPassword.Length < 1) & j < 2)
                    {
                        Console.WriteLine($"Passwords did not Confirm. {2 - j} tries left. Try again:");
                        Console.Write("New Password: ");
                        NewPassword = Console.ReadLine().Trim();
                        Console.Write("Confirm New Password: ");
                        NewPassword2 = Console.ReadLine().Trim();
                        Console.WriteLine("");
                        j++;
                    }
                    Console.Clear();
                    if (NewPassword == NewPassword2)
                    {
                        AddUser c = new AddUser(NewUsername, NewPassword);
                        AddUser.DBUserAdd(NewUsername, NewPassword);
                        Console.WriteLine($"New User Created with Username: {NewUsername}");
                        Console.Write($"Press any key to Continue..");
                        Console.ReadKey();
                        Console.CursorVisible = false;
                    }
                }
                #endregion

                #region Exit

                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                #endregion
            }
            
        }
        #endregion

        //MAIN MENU METHOD - Level 1.0
        #region MAIN MENU
        public string MainMenu(List<string> userMenu, string username, string password, int accessLevel)
        {
            while (true)
            {
                string selectedMenuItem2 = Menu.MenuRun(userMenu, username, accessLevel);
                DBManipulateUser du = new DBManipulateUser();

                //USER MODULES - LEVEL 2
                #region USER MODULES

                #region Send Mail
                if (selectedMenuItem2 == "Send Mail")
                {
                    Console.Clear();
                    DBPrintUsers pu = new DBPrintUsers();
                    UsersMessages umm = new UsersMessages();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    Console.Clear();
                    umm.MessagesUserPrint(listOfUsersString, username, password, AccessLevel);
                }

                #endregion

                #region Change Password
                else if (selectedMenuItem2 == "Change Password")
                {
                    Console.Clear();
                    Console.WriteLine("Change User's Password");
                    Console.WriteLine();
                    Console.Write($"Please Enter your new Password {username}: ");
                    string newPassword = Console.ReadLine().Trim();
                    string actionString = "Update dbo.Users set Password = @Password where Username = @Username";
                    du.DBUserManipulate(username, "change Password", actionString, username, password, username, newPassword);
                }
                #endregion

                #region Read Mail
                //else if (selectedMenuItem2 == "Read Mail")
                //{
                //    Console.Clear();
                //    Console.WriteLine("New Username: ");
                //    var NewUsername = Console.ReadLine();
                //    Console.WriteLine();
                //    Console.Write("New Password: ");
                //    var NewPassword = Console.ReadLine();
                //}
                #endregion

                #endregion

                //ADMIN MODULES = LEVEL 3
                #region ADMIN MODULES

                #region Users Manipulation Menu
                else if (selectedMenuItem2 == "Users Manipulation")
                {
                    Console.Clear();
                    UsersActions ua = new UsersActions();
                    ua.ActionsUsers(superMenu, username, password, accessLevel);
                }
                #endregion

                #region Users Messages Manipulation Menu

                //else if (selectedMenuItem2 == "Users Messages Manipulation")
                //{
                //    Console.Clear();
                //    UsersActions ua = new UsersActions();
                //    ua.ActionsUsers(messagesManipulationMenu, username, password, accessLevel);
                //}

                #endregion

                #region Message Manipulation Admin

                else if (selectedMenuItem2 == "Edit Users Messages")
                {

                    Console.Clear();
                    DBPrintUsers pu = new DBPrintUsers();
                    UsersMessagesMenu umm = new UsersMessagesMenu();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    Console.Clear();
                    string actionString = "Update dbo.Messages set Message = @newMessage where MessageID = @MessageID";
                    umm.MenuUserMessages(listOfUsersString, username, password, AccessLevel, "update message", actionString);

                }

                else if (selectedMenuItem2 == "Delete Users Messages")
                {

                    Console.Clear();
                    DBPrintUsers pu = new DBPrintUsers();
                    UsersMessagesMenu umm = new UsersMessagesMenu();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    Console.Clear();
                    string actionString = "delete From dbo.Messages where MessageID = @MessageID";
                    umm.MenuUserMessages(listOfUsersString, username, password, AccessLevel, "delete", actionString);

                }

                #endregion

                #region ADMIN USER MENU
                else if (selectedMenuItem2 == "Users")
                {
                    Console.Clear();
                    MenuCall(adminUsersMenu);
                }
                #endregion
                
                #region Print Users

                else if (selectedMenuItem2 == "Print Users")
                {
                    DBPrintUsers pu = new DBPrintUsers();
                    pu.Printusers();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    Console.Clear();
                    MainMenu(listOfUsersString, Username, Password, accessLevel);
                }
                #endregion

               

                #region Users Messages
                else if (selectedMenuItem2 == "View Users Messages")
                {
                    Console.Clear();
                    Console.WriteLine("VIEW USERS MESSAGES");
                    Console.WriteLine("");

                    DBPrintUsers pu = new DBPrintUsers();
                    UsersMessages umm = new UsersMessages();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    umm.UsersMessagesPrint(listOfUsersString, username, password, AccessLevel);

                    Console.Clear();
                }
                #endregion

                

                #endregion

                //SUPER ADMIN MODULES - LEVEL 4
                #region SUPER ADMIN MODULES

                #region Delete User

                else if (selectedMenuItem2 == "Delete User")
                {
                    Console.Clear();
                    Console.CursorVisible = true;
                    Console.WriteLine("DELETE USER");
                    Console.WriteLine();

                    #region DELETE USERNAME INPUT
                    Console.Write("Which User should I Delete for you SuperAdmin: ");
                    string deleteUser = Console.ReadLine().Trim();
                    DBCheckUser dbc = new DBCheckUser(deleteUser);
                    bool Verify = true;
                    Verify = dbc.DBUserCheck(deleteUser);
                    int i = 0;
                    while ((Verify == false || deleteUser.Length < 1) && i < 2)
                    {
                        i++;
                        Console.Clear();
                        Console.WriteLine("LOGIN");
                        Console.WriteLine();
                        Console.WriteLine($"Username does not Exist. Try another one ({3 - i} more tries):");
                        Console.Write("Username: ");
                        deleteUser = Console.ReadLine().Trim();

                        Verify = true;
                        Verify = dbc.DBUserCheck(deleteUser);

                        if (i == 2 && Verify == false)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            MainMenu(superAdminMenu, Username, Password, accessLevel);
                        }
                    }
                    DBManipulateUser dbdu = new DBManipulateUser(deleteUser);
                    string actionString = "delete From dbo.Users where Username = @Username";
                    dbdu.DBUserManipulate(deleteUser, "delete", actionString, username, password, "", ""); //(deleteUser, username, password, actionString);
                    #endregion
                }
                #endregion

                #endregion

                #region Update User

                //else if (selectedMenuItem2 == "Update User")
                //{
                //    Console.Clear();
                //    Console.CursorVisible = true;
                //    Console.WriteLine("Update USER");
                //    Console.WriteLine();

                //    #region DELETE USERNAME INPUT
                //    Console.Write("Which User should I Update for you SuperAdmin: ");
                //    string updateUser = Console.ReadLine().Trim();
                //    DBCheckUser dbc = new DBCheckUser(updateUser);
                //    bool Verify = true;
                //    Verify = dbc.DBUserCheck(updateUser);
                //    int i = 0;
                //    while ((Verify == false || updateUser.Length < 1) && i < 2)
                //    {
                //        i++;
                //        Console.Clear();
                //        Console.WriteLine("LOGIN");
                //        Console.WriteLine();
                //        Console.WriteLine($"Username does not Exist. Try another one ({3 - i} more tries):");
                //        Console.Write("Username: ");
                //        updateUser = Console.ReadLine().Trim();

                //        Verify = true;
                //        Verify = dbc.DBUserCheck(updateUser);

                //        if (i == 2 && Verify == false)
                //        {
                //            Console.Clear();
                //            Console.CursorVisible = false;
                //            MainMenu(superAdminMenu, Username, Password, accessLevel);
                //        }
                //    }

                //    DBDeleteUser dbdu = new DBDeleteUser(updateUser);
                //    dbdu.DBUserDelete(updateUser, Username, Password);
                //}
                #endregion

                #region Create User

                else if (selectedMenuItem2 == "Create New User")  //Adds user to database
                {
                    Console.Clear();
                    Console.WriteLine("NEW USER");
                    Console.CursorVisible = true;
                    Console.Write("New Username: ");
                    var NewUsername = Console.ReadLine().Trim();
                    DBCheckUser dbc = new DBCheckUser(NewUsername);
                    bool VerifyNewUsername = false;
                    VerifyNewUsername = dbc.DBUserCheck(NewUsername);
                    int i = 0;
                    while ((VerifyNewUsername == true || NewUsername.Length < 1) && i < 2)
                    {
                        i++;
                        Console.Clear();
                        Console.WriteLine("NEW USER SIGNUP");
                        Console.WriteLine();
                        Console.WriteLine($"Username is Taken. Try another one ({3 - i} more tries):");
                        Console.Write("Username: ");
                        NewUsername = Console.ReadLine().Trim();

                        VerifyNewUsername = false;
                        VerifyNewUsername = dbc.DBUserCheck(NewUsername);

                        if (i == 2 && VerifyNewUsername == true)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            GuestMenu(guestMenu);
                        }
                    }
                    while (NewUsername.Length == 0)
                    {
                        GuestMenu(guestMenu);
                    }
                    Console.Write("New Password: ");
                    string NewPassword = Console.ReadLine().Trim();
                    Console.Write("Confirm New Password: ");
                    string NewPassword2 = Console.ReadLine().Trim();
                    int j = 0;
                    while ((NewPassword != NewPassword2 || NewPassword.Length < 1) & j < 2)
                    {
                        Console.WriteLine($"Passwords did not Confirm. {2 - j} tries left. Try again:");
                        Console.Write("New Password: ");
                        NewPassword = Console.ReadLine().Trim();
                        Console.Write("Confirm New Password: ");
                        NewPassword2 = Console.ReadLine().Trim();
                        Console.WriteLine("");
                        j++;
                    }
                    Console.Clear();
                    if (NewPassword == NewPassword2)
                    {
                        AddUser c = new AddUser(NewUsername, NewPassword);
                        AddUser.DBUserAdd(NewUsername, NewPassword);
                        Console.WriteLine($"New User Created with Username: {NewUsername}");
                        Console.Write($"Press any key to Continue..");
                        Console.ReadKey();
                        Console.CursorVisible = false;
                    }
                }

                #endregion

                #region Change User Role
                else if (selectedMenuItem2 == "Change User Role")
                {
                    Console.Clear();
                    Console.WriteLine("USER ROLES");
                    Console.WriteLine("");
                    DBPrintUsers pu = new DBPrintUsers();
                    AssignRoles ar = new AssignRoles();
                    var listOfUsersString = pu.DBUsersPrintString(username);
                    ar.UserRoles(listOfUsersString, username, password, AccessLevel);
                    Console.Clear();
                }
                #endregion

                #endregion

                #region Main Menu

                else if (selectedMenuItem2 == "Main Menu")
                {
                    Console.Clear();
                    AccessLevelCheck alc = new AccessLevelCheck(Username, Password); //, true, true);
                    alc.LevelMenuCall(Username, Password);
                    //MainMenu(superAdminMenu, Username, Password);
                }
                #endregion

                //#endregion

                //UNIVERSAL MODULES - LEVEL ALL

                #region UNIVERSAL MODULES

                #region Logout

                else if (selectedMenuItem2 == "Logout")
                {
                    Console.Clear();
                    MenuCall();
                }
                #endregion

                #region Exit

                else if (selectedMenuItem2 == "Exit")
                {
                    Environment.Exit(0);
                }
                #endregion

                #endregion

               
                Console.Clear();
            }
        }
        //#endregion


        #region PasswordMask
        public string PasswordMask()
        {

            var pass = "";
            Console.Write("Enter your password: ");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b \b");
                }
            }

            while (key.Key != ConsoleKey.Enter);

            return pass;
            
        }
        #endregion

        #region Constructors

        public AllMenus()
        {

        }
        public AllMenus(string username, int accessLevel)
        {
            Username = username;
            AccessLevel = accessLevel;
        }
        public AllMenus(string username, string password, int accessLevel)
        {
            Username = username;
            Password = password;
            AccessLevel = accessLevel;
        }
        public void MenuCall()
        {
            Console.CursorVisible = false;
            GuestMenu(guestMenu);
        }

        #endregion

        public void MenuCall(List<string> menu)
        {
            Console.CursorVisible = false;
            MainMenu(menu, Username, Password, AccessLevel);
        }
    }
}
