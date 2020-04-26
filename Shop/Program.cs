using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
           // build connection string with DB on local server
           
            // ADMIN MODE
            if (args.Length == 1 && args[0]== "aaa")
            {
                // var menuCMS = new CMSmainMenu();
                // menuCMS.PrintmainMenu();
            }
            // SHOPPING MODE
            else
            {
                Console.WriteLine("Hello Team");
                var menuCMS = new CMSmenuController();
                menuCMS.PrintmainMenu();
            }
        }
    }
}

