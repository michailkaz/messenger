using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAZDAGLIS_PROJECT
{
    public class Program
    {

        private static void Main(string[] args)
        {
            //Database.dbCall();
            //AddUser.dbUserAdd("George","password");
            
            //AllMenus mM = new AllMenus();
            //Console.CursorVisible = false;
            //mM.MainMenu(AllMenus.mainMenu);
            //mM.SuperAdminMenu(AllMenus.superAdminMenu);

            AllMenus guest = new AllMenus();
            guest.MenuCall();

            


        }
        
    }



}

