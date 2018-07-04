using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class User : Guest
    {


        private const string objectName = "User";
        public new void MenuCall(List<string> menu)
        {
            AllMenus m = new AllMenus();
            m.MainMenu(menu, Username, Password, AccessLevel);
        }
        public User()
        {

        }
        public User(string username, string password, int accessLevel) //: base(username, password)
        {

            Username = username;
            Password = password;
            AccessLevel = accessLevel;

        }
        public User(string username, string password) //: base(username, password)
        {

            Username = username;
            Password = password;
            

        }
    }
}
