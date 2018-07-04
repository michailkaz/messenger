using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT
{
    class DBManipulateMessages
    {

        public string Username;

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public DBManipulateMessages(string username)
        {
            Username = username;
        }

        public bool MessageManipulate(string username, string password, string action, string actionString, string newMessage, int messageID)
        {
            bool isUserDeleted = false;
            SqlConnection con = new SqlConnection(ConnectionString);

            Console.Clear();
            Console.WriteLine($"Message {action}: {newMessage}. \nShould I proceed??");
            Console.CursorVisible = true;
            Console.Write("Press any key to Continue. =>To Abort press ESC<= ...");
            Console.Clear();
            var key2 = Console.ReadKey();
            Console.CursorVisible = false;
            if (key2.Key == ConsoleKey.Escape)
            {
                AccessLevelCheck alc = new AccessLevelCheck();
                Console.Clear();
                alc.LevelMenuCall(username, password);
                isUserDeleted = false;
            }
            else
            {

                SqlCommand cmd2 = new SqlCommand(actionString, con);
                cmd2.Parameters.AddWithValue("@NewMessage", newMessage);
                cmd2.Parameters.AddWithValue("@MessageID", messageID);
                try
                {
                    Console.Clear();
                    con.Open();
                    SqlDataReader drDelete = cmd2.ExecuteReader();
                    cmd2.Dispose();
                    con.Close();
                    isUserDeleted = true;
                    Console.WriteLine($"Message \n{action} {newMessage}! \nOperation successfull!");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + $"Message \n{ action} { newMessage}! \nOperation NOT successfull!");
                    Console.ReadLine();
                    isUserDeleted = false;
                }
                return isUserDeleted;
            } 
            return isUserDeleted;
        }

        public DBManipulateMessages()
        {

        }

    }
}
