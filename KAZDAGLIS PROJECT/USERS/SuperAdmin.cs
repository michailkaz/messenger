using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class SuperAdmin : Admin
    {
        private const string objectName = "Super Admin";
        private string _isSuperAdmin;

        public string IsSuperAdmin { get { return _isSuperAdmin; } set { _isSuperAdmin = value; } }

        public SuperAdmin(string isSuperAdmin)
        {
            IsSuperAdmin = isSuperAdmin;
        }
        public SuperAdmin(string username, string password, string isSuperAdmin)
        {

            Username = username;
            Password = password;
            IsSuperAdmin = isSuperAdmin;

        }
        public SuperAdmin()
        {

        }
        public SuperAdmin(string username, string password, int accessLevel)
        {
            Username = username;
            Password = password;
            AccessLevel = accessLevel;
        }

        public new void MenuCall(List<string> menu)
        {
            AllMenus m = new AllMenus();
            m.MainMenu(menu, Username, Password, AccessLevel);
        }

    }
}
