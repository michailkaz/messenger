using KAZDAGLIS_PROJECT.DATABASE_CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace KAZDAGLIS_PROJECT
{
    class UsersMessagesMenu
    {
        public void MenuUserMessages(List<string> userList, string username, string password, int accessLevel, string action, string actionString)
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

                    var firstUser = Menu.MenuRun(userList, username, accessLevel);
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
                        listOfUsersString.Insert(0, firstUser);
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
                            var key = Console.ReadKey();
                            Console.CursorVisible = false;
                            if (key.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                MenuUserMessages(userList, username, password, accessLevel, action, actionString);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("  MESSAGES CLIENT");
                                Console.WriteLine($" Welcome <{username}>!");
                                Console.WriteLine();

                                GetMessages messages = new GetMessages();
                                List<string> messageList = messages.DBMessagesManipulate(firstUser, secondUser);
                                messageList.Add("Main Menu");
                                var selectedMessage = Menu.MenuRun(messageList, username, accessLevel);
                                #region Main Menus
                                if (selectedMessage == "Main Menu")
                                {
                                    Console.Clear();
                                    alc.LevelMenuCall(username, password);
                                }
                                #endregion
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(selectedMessage);
                                    string[] indexNo = selectedMessage.Split('-');
                                    int MessageID = int.Parse(indexNo[0].Trim());

                                    string newMessage = $"{selectedMessage}";

                                    if (action == "update message")
                                    {
                                        Console.CursorVisible = true;
                                        Console.Write("Please write the new message: ");
                                        Console.CursorVisible = false;
                                        newMessage = Console.ReadLine();
                                    }
                                    
                                    DBManipulateMessages mm2 = new DBManipulateMessages();
                                    mm2.MessageManipulate(username, password, action, actionString, newMessage, MessageID);
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
            }
            
        }

        //public string UsersMessagesPrint(List<string> userMenu, string username, string password, int accessLevel)
        //{
        //    AccessLevelCheck alc = new AccessLevelCheck(username, password, accessLevel);
        //    DBPrintUsers pu = new DBPrintUsers();
        //    SqlConnection con = new SqlConnection(pu.ConncetionString);
        //    List<string> listOfUsersString = pu.DBUsersPrintString(username);


        //    while (true)
        //    {
        //        for (int i = 0; i < listOfUsersString.Count; i++)
        //        {

        //            Console.Clear();
        //            Console.WriteLine("  MESSAGES CLIENT");
        //            Console.WriteLine($"   Welcome {username}!");
        //            Console.WriteLine($"     Level: {accessLevel}");
        //            Console.WriteLine();
        //            Console.CursorVisible = true;
        //            Console.WriteLine("Please Select First User! Press any key to select..");
        //            Console.ReadKey();
        //            Console.CursorVisible = false;

        //            var firstUser = Menu.MenuRun(userMenu, username, accessLevel);
        //            #region Main Menus
        //            if (firstUser == "Main Menu")
        //            {
        //                Console.Clear();
        //                alc.LevelMenuCall(username, password);
        //            }
        //            #endregion

        //            #region List Menus
        //            else
        //            {
        //                Console.Clear();
        //                Console.CursorVisible = true;
        //                Console.WriteLine($"You selected {firstUser}. Please Select Second User! Press any key to select..");
        //                Console.ReadKey();
        //                Console.CursorVisible = false;
        //                listOfUsersString.RemoveAll(x => x.Equals(firstUser));
        //                var secondUser = Menu.MenuRun(listOfUsersString, username, accessLevel);

        //                #region Main Menus
        //                if (secondUser == "Main Menu")
        //                {
        //                    Console.Clear();
        //                    alc.LevelMenuCall(username, password);
        //                }
        //                #endregion

        //                #region List Menus
        //                else
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine("MESSAGES");
        //                    Console.WriteLine();
        //                    Console.WriteLine($"{username.ToUpper()}, you selected to view messages between {firstUser.ToUpper()} and {secondUser.ToUpper()}");
        //                    Console.CursorVisible = true;
        //                    Console.Write("Press any key to Continue. =>To go Back press ESC<= ...");
        //                    var key2 = Console.ReadKey();
        //                    Console.CursorVisible = false;
        //                    if (key2.Key == ConsoleKey.Escape)
        //                    {
        //                        Console.Clear();
        //                        UsersMessagesPrint(listOfUsersString, username, password, accessLevel);
        //                    }
        //                    else
        //                    {
        //                        Console.Clear();
        //                        GetMessages messages = new GetMessages();
        //                        List<string> messageList = messages.DBMessagesPrint(firstUser, secondUser);
        //                        Console.Clear();
        //                        Console.WriteLine("MESSAGES");
        //                        Console.WriteLine();
        //                        messageList.ForEach(Console.WriteLine);
        //                        Console.WriteLine();
        //                        Console.CursorVisible = true;
        //                        Console.Write("Press any key to read more Users' Messages. =>To go to Main Menu press ESC<= ...");
        //                        var key3 = Console.ReadKey();
        //                        Console.CursorVisible = false;
        //                        if (key3.Key == ConsoleKey.Escape)
        //                        {
        //                            Console.Clear();
        //                            alc.LevelMenuCall(username, password);
        //                        }
        //                        UsersMessagesPrint(listOfUsersString, username, password, accessLevel);
        //                    }
        //                    //}
        //                    #endregion
        //                }
        //                #endregion
        //            }
        //            #endregion
        //        }
        //    }
        //    #endregion
    }
}
