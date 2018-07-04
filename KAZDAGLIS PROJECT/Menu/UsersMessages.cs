using KAZDAGLIS_PROJECT.DATABASE_CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace KAZDAGLIS_PROJECT
{
    class UsersMessages
    {
        public void MessagesUserPrint(List<string> userMenu, string username, string password, int accessLevel)
        {
            AccessLevelCheck alc = new AccessLevelCheck(username, password, accessLevel);
            DBPrintUsers pu = new DBPrintUsers();
            List<string> listOfUsersString = pu.DBUsersPrintString(username);


            while (true)
            {
                for (int i = 0; i < listOfUsersString.Count; i++)
                {

                    Console.Clear();
                    Console.WriteLine("  MESSAGES CLIENT");
                    Console.WriteLine($" Welcome {username}!");
                    Console.WriteLine();

                    var selectedMenuItem = Menu.MenuRun(userMenu, username, accessLevel);
                    #region Main Menus
                    if (selectedMenuItem == "Main Menu")
                    {
                        Console.Clear();
                        alc.LevelMenuCall(username, password);
                    }
                    #endregion

                    #region List Menus
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("MESSAGES");
                        Console.WriteLine();
                        Console.WriteLine($"{username}, you selected to send messagee to: {selectedMenuItem}");
                        Console.CursorVisible = true;
                        Console.Write("Press any key to Continue. =>To go Back press ESC<= ...");
                        var key = Console.ReadKey();
                        Console.CursorVisible = false;
                        if (key.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            MessagesUserPrint(listOfUsersString, username, password, accessLevel);
                        }
                        else
                        {
                            Console.Clear();
                            GetMessages messages = new GetMessages();
                            List<string> messageList = messages.DBMessagesPrint(username, selectedMenuItem);
                            messageList.ForEach(Console.WriteLine);


                            Console.CursorVisible = true;
                            Console.Write($"{username}              :  ");
                           
                                string message = Console.ReadLine();

                                int j = 0;
                                while ((message.Length > 250) & j < 2)
                                {
                                    Console.WriteLine("MESSAGES");
                                    Console.WriteLine();
                                    Console.WriteLine($"Message Too Long. {2 - j} tries left. Try again under 250 characters:");
                                    Console.Write($"{username}            :");
                                    message = Console.ReadLine().Trim();
                                    Console.WriteLine("");
                                    j++;
                                }
                                Console.Clear();
                                if (message.Length > 250)
                                {
                                    Console.Clear();
                                    Console.WriteLine("MESSAGES");
                                    Console.WriteLine();
                                    Console.WriteLine("No Message Sent");
                                    Console.Write($"Press any key to Continue..");
                                    Console.ReadKey();
                                    Console.CursorVisible = false;
                                    MessagesUserPrint(listOfUsersString, username, password, accessLevel);
                                }
                                else
                                {
                                    SendMessage c = new SendMessage(username, selectedMenuItem);
                                    SendMessage.DBMessageSend(username, selectedMenuItem, message);
                                    Console.WriteLine("MESSAGES");
                                    Console.WriteLine();
                                    Console.WriteLine($"You sent this message to {selectedMenuItem}: {message}");
                                    Console.Write($"Press any key to Continue..");
                                    Console.ReadKey();
                                    Console.CursorVisible = false;
                                }
                            
                        }
                    }
                    #endregion
                }
            }
        }

        public string UsersMessagesPrint(List<string> userMenu, string username, string password, int accessLevel)
        {
            AccessLevelCheck alc = new AccessLevelCheck(username, password, accessLevel);
            DBPrintUsers pu = new DBPrintUsers();
            SqlConnection con = new SqlConnection(pu.ConncetionString);
            List<string> listOfUsersString = pu.DBUsersPrintString(username);


            while (true)
            {
                for (int i = 0; i < listOfUsersString.Count; i++)
                {

                    Console.Clear();
                    Console.WriteLine("  MESSAGES CLIENT");
                    Console.WriteLine($"   Welcome {username}!");
                    Console.WriteLine($"     Level: {accessLevel}");
                    Console.WriteLine();
                    Console.CursorVisible = true;
                    Console.WriteLine("Please Select First User! Press any key to select..");
                    Console.ReadKey();
                    Console.CursorVisible = false;

                    var firstUser = Menu.MenuRun(userMenu, username, accessLevel);
                    #region Main Menus
                    if (firstUser == "Main Menu")
                    {
                        Console.Clear();
                        alc.LevelMenuCall(username, password);
                    }
                    #endregion

                    #region List Menus
                    else
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.WriteLine($"You selected {firstUser}. Please Select Second User! Press any key to select..");
                        Console.ReadKey();
                        Console.CursorVisible = false;
                        listOfUsersString.RemoveAll(x => x.Equals(firstUser));
                        var secondUser = Menu.MenuRun(listOfUsersString, username, accessLevel);
                        #region Main Menus
                        if (secondUser == "Main Menu")
                        {
                            Console.Clear();
                            alc.LevelMenuCall(username, password);
                        }
                        #endregion

                        #region List Menus
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("MESSAGES");
                            Console.WriteLine();
                            Console.WriteLine($"{username.ToUpper()}, you selected to view messages between {firstUser.ToUpper()} and {secondUser.ToUpper()}");
                            Console.CursorVisible = true;
                            Console.Write("Press any key to Continue. =>To go Back press ESC<= ...");
                            var key2 = Console.ReadKey();
                            Console.CursorVisible = false;
                            if (key2.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                UsersMessagesPrint(listOfUsersString, username, password, accessLevel);
                            }
                            else
                            {
                                Console.Clear();
                                GetMessages messages = new GetMessages();
                                List<string> messageList = messages.DBMessagesPrint(firstUser, secondUser);
                                Console.Clear();
                                Console.WriteLine("MESSAGES");
                                Console.WriteLine();
                                messageList.ForEach(Console.WriteLine);
                                Console.WriteLine();
                                Console.CursorVisible = true;
                                Console.Write("Press any key to read more Users' Messages. =>To go to Main Menu press ESC<= ...");
                                var key3 = Console.ReadKey();
                                Console.CursorVisible = false;
                                if (key3.Key == ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    alc.LevelMenuCall(username, password);
                                }
                                UsersMessagesPrint(listOfUsersString, username, password, accessLevel);
                            }
                            //}
                            #endregion
                        }
                        #endregion
                    }
                }
            }
        }
    }
}