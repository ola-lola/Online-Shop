using System;
using System.Collections.Generic;
// using System.Reflection;
using System.Threading;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
           // build connection string with DB on local server
           
           if (args.Length == 1)
           {
               // ADMIN MODE
               if (args[0]== "aaa")
               {
                   bool showMenu = true;
                   while(showMenu)
                   {
                       showMenu = CMSmenu.CMSMenu_display();
                   }
               }
           }
           // SHOPPING MODE
           else
           {
                Console.WriteLine("Hello Team");
                var menuCMSv2 = new CMSmainMenu();
                menuCMSv2.PrintCMSmenu_v2();
           }
        }
    }
}

