using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KAZDAGLIS_PROJECT
{
    class AccessLevelCheck
    {

        //private AllMenus currentUser;

        //private static AccessLevelCheck _instance = null;


        //public static AccessLevelCheck Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            //Edw tithetai to instance
        //            _instance = new AccessLevelCheck();
        //        }
        //        return _instance;
        //    }
        //}

        //private AccessLevelCheck() { }

        //public AllMenus GetCurrentUser()
        //{
        //    return currentUser;
        //}

        //public bool IsLoggedIn()
        //{
        //    if (currentUser != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public void Logout()
        //{
        //    currentUser = null;
        //}



        public string Password { get; set; }
        public string Username { get; set; }
        public string AdminStatus { get; set; }
        public string SuperAdminStatus { get; set; }
        public int AccessLevel { get; set; }

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }



        public int CheckAccessLevel(string username, string password)
        {
            int x = 1;
            bool adminStatus = true;
            bool superAdminStatus = true;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmdA = new SqlCommand("Select * from dbo.Users where Username = @Username and Password = @Password and AdminStatus = @AdminStatus", con);
            SqlCommand cmdS = new SqlCommand("Select * from dbo.Users where Username = @Username and Password = @Password and SuperAdminStatus = @SuperAdminStatus", con);
            SqlDataReader drS = null;
            cmdA.Parameters.AddWithValue("@Username", username);
            cmdA.Parameters.AddWithValue("@Password", password);
            cmdA.Parameters.AddWithValue("@AdminStatus", adminStatus);
            cmdS.Parameters.AddWithValue("@Username", username);
            cmdS.Parameters.AddWithValue("@Password", password);
            cmdS.Parameters.AddWithValue("@SuperAdminStatus", superAdminStatus);

            try
            {
                con.Open();
                SqlDataReader dr = cmdA.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        x = 2;
                        break;
                    }
                }
                dr.Close();
                drS = cmdS.ExecuteReader();
                while (drS.Read())
                {
                    if (drS.HasRows == true)
                    {
                        x = 3;
                        break;
                    }
                }
            }
            finally
            {
                if (drS != null)
                    drS.Close();
                if (con != null)
                    con.Close();
            }
            Console.Clear();

            AllMenus S1 = new AllMenus(username, password, x);

            if (x == 1)
            {
                S1.MenuCall(AllMenus.userMenu);
            }
            else if (x == 2)
            {
                S1.MenuCall(AllMenus.adminMenu);
            }
            else if (x == 3)
            {
                S1.MenuCall(AllMenus.superAdminMenu);
            }

            return x;
        }

        public void LevelMenuCall(string username, string password)
        {
            int x = CheckAccessLevel(username, password);
            AllMenus S1 = new AllMenus(username, password, x);
            if (x == 1)
            {
                S1.MenuCall(AllMenus.userMenu);
            }
            else if (x == 2)
            {
                S1.MenuCall(AllMenus.adminMenu);
            }
            else if (x == 3)
            {
                S1.MenuCall(AllMenus.superAdminMenu);
            }
        }


        public string CheckAccessLevelByUsername(string username)
        {
            int x = 1;
            bool adminStatus = true;
            bool superAdminStatus = true;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmdA = new SqlCommand("Select * from dbo.Users where Username = @Username and AdminStatus = @AdminStatus", con);
            SqlCommand cmdS = new SqlCommand("Select * from dbo.Users where Username = @Username and SuperAdminStatus = @SuperAdminStatus", con);
            SqlDataReader drS = null;
            cmdA.Parameters.AddWithValue("@Username", username);
            cmdA.Parameters.AddWithValue("@AdminStatus", adminStatus);
            cmdS.Parameters.AddWithValue("@Username", username);
            cmdS.Parameters.AddWithValue("@SuperAdminStatus", superAdminStatus);

            try
            {
                con.Open();
                SqlDataReader dr = cmdA.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        x = 2;

                        break;
                    }
                }
                dr.Close();
                drS = cmdS.ExecuteReader();
                while (drS.Read())
                {
                    if (drS.HasRows == true)
                    {
                        x = 3;
                        break;
                    }
                }
            }
            finally
            {
                if (drS != null)
                    drS.Close();
                if (con != null)
                    con.Close();
            }
            Console.Clear();

            //AllMenus S1 = new AllMenus(username, x);

            if (x == 1)
            {
                string y = "User";
                return y;
            }
            else if (x == 2)
            {
                string y = "Admin";
                return y;
            }
            else if (x == 3)
            {
                string y = "Super Admin";
                return y;
            }
            else
            {
                string y = "Unknown";
                return y;
            }
        }

        public AccessLevelCheck(int accessLevel)
        {
            AccessLevel = accessLevel;
        }
        public AccessLevelCheck(string username, string password)
        {
            Password = password;
            Username = username;
        }

        public AccessLevelCheck(string username, string password, int accessLevel)
        {
            Password = password;
            Username = username;
            AccessLevel = accessLevel;
        }

        public AccessLevelCheck()
        {

        }
    }
}
