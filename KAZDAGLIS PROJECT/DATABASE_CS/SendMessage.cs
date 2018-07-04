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
    class SendMessage
    {

        public string Sender { get; set; }
        public string Receiver { get; set; }

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public static void DBMessageSend(string Sender, string Receiver, string Message)
        {
            DataTable Messages = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                DateTime now = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";     
                

                string insertString = $@"insert into dbo.Messages(Sender, Receiver, Message, MessageDateTime) values ('{Sender}', '{Receiver}', '{Message}', '{now.ToString(format)}')"; //Command
                

                using (SqlCommand cmd = new SqlCommand(insertString, conn))  // Instantiate the command with a query and connection
                {
                    try
                    {
                        cmd.ExecuteNonQuery();  // Send command
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }


                }
            }

        }


        public SendMessage(string sender, string receiver)
        {
            this.Sender = sender;
            Receiver = receiver;
        }
        public SendMessage()
        {
            
        }
    }
}
