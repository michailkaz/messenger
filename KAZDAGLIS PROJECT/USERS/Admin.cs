using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class Admin : User
    {
        private string _isAdmin;

        private const string objectName = "Admin";
        
        public string IsAdmin { get { return _isAdmin; } set { _isAdmin = value; } }

        public Admin(string username, string password, string isAdmin)
        {

            Username = username;
            Password = password;
            IsAdmin = isAdmin;
            //AccessLevel = accessLevel;

        }
        public Admin(string isAdmin) //: base(Password, Username)
        {
            IsAdmin = isAdmin;
        }
        public Admin(string username, string password, int accessLevel)
        {
            Username = username;
            Password = password;
            AccessLevel = accessLevel;
        }
        public Admin()
        {
           
        }

        
    }
}
