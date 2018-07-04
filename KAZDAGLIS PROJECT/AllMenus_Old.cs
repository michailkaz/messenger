using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class AllMenus_Old : AllMenus
    {
        public static List<string> mainMenu = new List<string>() { "Log In", "Sign Up", "Exit" };
        public static List<string> userMenu = new List<string>() { "Send Mail", "Read Mail", "Logout", "Exit" };
        public static List<string> adminMenu = new List<string>() { "Send Mail", "Read Mail", "Users", "Logout", "Exit" };
        public static List<string> adminUsersMenu = new List<string>() { "Print Users", "Create User", "Users' Messages", "Main Menu", "Exit" };
        public static List<string> superAdminMenu = new List<string>() { "Print Users", "Users' Messages", "Create User", "Change User Details", "Delete User", "Logout", "Exit" };
        public static List<string> mailMenu = new List<string>() { "User", "Print Users", "Main Menu", "Exit" };

        //Menu m1 = new Menu(mainMenu);
        //public Menu m2 = new Menu(userMenu);
        //Menu m3 = new Menu(adminMenu);
        //Menu m4 = new Menu(adminUsersMenu);
        //Menu m5 = new Menu(mailMenu);
        //Menu m6 = new Menu(superAdminMenu);

        //MAIN MENU METHOD - Level 1.0
        #region MAIN MENU
        public string MainMenu(List<string> mainMenu)
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("  MESSAGES CLIENT");
                Console.WriteLine("     Welcome!");
                Console.WriteLine();

                #region LOGIN
                string selectedMenuItem = Menu.MenuRun(mainMenu, Username);
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
                        Console.WriteLine($"Username does not Exist. Try another one ({3 - i} more tries):");
                        Console.Write("Username: ");
                        Username = Console.ReadLine().Trim();

                        Verify = true;
                        Verify = dbc.DBUserCheck(Username);

                        if (i == 2 && Verify == false)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            MainMenu(mainMenu);
                        }

                    }
                    #endregion

                    #region PASSWORD INPUT
                    //PASSWORD INPUT
                    while (Username.Length == 0)
                    {
                        MainMenu(mainMenu);
                    }
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.WriteLine();
                    Console.WriteLine($"Welcome back {Username}! ");
                    Console.Write("Password: ");
                    var Password = Console.ReadLine().Trim();

                    Console.CursorVisible = false;
                    DBCheckPassword dbcp = new DBCheckPassword(Password, Username);
                    bool VerifyPassword = true;
                    VerifyPassword = dbcp.DBPasswordCheck(Password, Username);
                    int j = 0;
                    while ((VerifyPassword == false || Password.Length < 1) && j < 2)
                    {
                        j++;
                        Console.Clear();
                        Console.WriteLine("LOGIN");
                        Console.WriteLine();
                        Console.WriteLine($"Wrong Password. Are you sure you are {Username}? You have {3 - j} more tries.");
                        Console.Write("Password: ");
                        Password = Console.ReadLine().Trim();
                        VerifyPassword = true;
                        VerifyPassword = dbcp.DBPasswordCheck(Password, Username);
                        //
                        if (j == 2)
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            MainMenu(mainMenu);
                        }
                    }
                    AccessLevelCheck alc = new AccessLevelCheck(); //, true, true);
                    alc.CheckAccessLevel(Password, Username, true, true);
                    

                    //UserMenu(userMenu);
                    #endregion
                }
                #endregion

                #region Sign Up
                else if (selectedMenuItem == "Sign Up")  //Adds user to database
                {
                    Console.Clear();
                    Console.WriteLine("NEW USER SIGNUP");
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
                            MainMenu(mainMenu);
                        }
                    }
                    while (NewUsername.Length == 0)
                    {
                        MainMenu(mainMenu);
                    }
                    Console.Write("New Password: ");
                    string NewPassword = Console.ReadLine().Trim();
                    Console.Write("Confirm New Password: ");
                    string NewPassword2 = Console.ReadLine().Trim();
                    int j = 0;
                    while ((NewPassword != NewPassword2 || NewPassword.Length < 1) & j < 2)
                    {
                        Console.WriteLine($"Passwords did not Confirm. {2-j} tries left. Try again:");
                        Console.Write("New Password: ");
                        NewPassword = Console.ReadLine().Trim();
                        Console.Write("Confirm New Password: ");
                        NewPassword2 = Console.ReadLine().Trim();
                        Console.WriteLine("");
                        j++;
                    }
                    Console.Clear();
                    while (NewPassword == NewPassword2)
                    {
                        AddUser c = new AddUser(NewUsername, NewPassword);
                        AddUser.DBUserAdd(NewUsername, NewPassword);
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
                Console.Clear();
            }
        }
        #endregion

        //User Menu - Level 2.1
        #region USER MENU
        public string UserMenu(List<string> userMenu)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("USER MENU");
                Console.WriteLine();
                string selectedMenuItem = Menu.MenuRun(userMenu, Username);
                if (selectedMenuItem == "Send Mail")
                {
                    Console.Clear();



                }
                #region Read Mail
                else if (selectedMenuItem == "Read Mail")
                {
                    Console.Clear();
                    Console.WriteLine("New Username: ");
                    var NewUsername = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("New Password: ");
                    var NewPassword = Console.ReadLine();
                }
                #endregion
                #region Exit - Logout
                else if (selectedMenuItem == "Logout")
                {
                    Console.Clear();
                    MainMenu(mainMenu);
                }

                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
                #endregion
            }
        }
        #endregion

        //Admin Menu - Level 2.1
        #region ADMIN MENU
        public string AdminMenu(List<string> adminMenu)
        {
            while (true)
            {
                string selectedMenuItem = Menu.MenuRun(adminMenu, Username);
                if (selectedMenuItem == "Send Mail")
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    var Username = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Password: ");
                    var Password = Console.ReadLine();
                }
                else if (selectedMenuItem == "Read Mail")
                {
                    Console.Clear();
                    Console.WriteLine("New Username: ");
                    var NewUsername = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("New Password: ");
                    var NewPassword = Console.ReadLine();
                }
                else if (selectedMenuItem == "Users")
                {
                    Console.Clear();
                    Console.WriteLine("Users ");
                    var NewUsername = Console.ReadLine();
                }
                else if (selectedMenuItem == "Logout")
                {
                    Console.Clear();
                    MainMenu(mainMenu);
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }
        #endregion

        //Admin Users Menu - Level 2.2
        #region ADMIN USERS MENU
        public string AdminUsersMenu(List<string> adminUsersMenu)
        {
            while (true)
            {
                string selectedMenuItem = Menu.MenuRun(adminUsersMenu, Username);
                if (selectedMenuItem == "Print Users")
                {
                    Console.Clear();
                    Console.Write("Users: ");
                }
                else if (selectedMenuItem == "Create User") //Adds user to database
                {
                    Console.Clear();
                    Console.WriteLine("New Username: ");
                    var NewUsername = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("New Password: ");
                    var NewPassword = Console.ReadLine();
                    AddUser c = new AddUser(NewUsername, NewPassword);
                    AddUser.DBUserAdd(NewUsername, NewPassword);
                }
                else if (selectedMenuItem == "Users' Messages")
                {
                    Console.Clear();
                    Console.Write("Users Messages: ");
                }
                else if (selectedMenuItem == "Logout")
                {
                    Console.Clear();
                    AdminMenu(adminMenu);
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }
        #endregion

        //SUPER ADMIN MENU - Level 3.1
        #region SUPER ADMIN MENU
        public string SuperAdminMenu(List<string> superAdminMenu)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("SUPER ADMIN MENU");
                Console.WriteLine();
                string selectedMenuItem = Menu.MenuRun(superAdminMenu, Username);
                if (selectedMenuItem == "Send Mail")
                {
                    Console.Clear();



                }
                #region Read Mail
                else if (selectedMenuItem == "Read Mail")
                {
                    Console.Clear();
                    Console.WriteLine("New Username: ");
                    var NewUsername = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("New Password: ");
                    var NewPassword = Console.ReadLine();
                }
                #endregion
                #region Delete User
                if (selectedMenuItem == "Delete User")
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
                            SuperAdminMenu(superAdminMenu);
                        }

                    }
                    DBDeleteUser dbdu = new DBDeleteUser(deleteUser);
                    dbdu.DBUserDelete(deleteUser);

                }
                #endregion
                #region Logout - Exit
                else if (selectedMenuItem == "Logout")
                {
                    Console.Clear();
                    MainMenu(mainMenu);
                }

                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
                #endregion
            }
        }
        #endregion

        #region Mail Menu

        public string MailMenu(List<string> userMenu)
        {


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mail");
                Console.WriteLine();
                string selectedMenuItem = Menu.MenuRun(mailMenu, Username);
                if (selectedMenuItem == "Send Mail")
                {
                    Console.Clear();



                }
                #region Read Mail
                else if (selectedMenuItem == "Read Mail")
                {
                    Console.Clear();
                    Console.WriteLine("Read Mail of the User:");


                }
                #endregion
                #region Exit - Logout
                else if (selectedMenuItem == "Main Menu")
                {
                    Console.Clear();
                    UserMenu(userMenu);
                }

                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
                #endregion

                #endregion
            }
        }
        #endregion
    }
}
