using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class Guest : IMenuable
    {
        

        private string _username;
        private string _password;

        public string Username { get { return _username; } set => _username = value; }
        public string Password { get { return _password; } set => _password = value; }
        public int AccessLevel { get; set; }
        //public bool isAdmin { get; set; }
        //public bool isSuperAdmin { get; set; }
        private const string objectName = "Guest";

        //AllMenus m = new AllMenus();

        public Guest(string username, string password, int accessLevel)
        {

            Username = username;
            Password = password;
            AccessLevel = accessLevel;

        }
        public Guest()
        {
            //Username = "a";
        }
        public void MenuCall()
        {
            
            //Menu mM = new Menu(AllMenus.mainMenu);
            Console.CursorVisible = false;
            //m.MenuCall();
        }
        public void MenuCall(List<string> menu)
        {
            
            //Menu mM = new Menu(AllMenus.mainMenu);
            Console.CursorVisible = false;
            //m.MainMenu(menu, Username, Password);
        }
    }
}
