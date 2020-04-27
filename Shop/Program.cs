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
                var menuCMS = new CMSmenuController();
                menuCMS.PrintmainMenu();
            }
            // SHOPPING MODE
            else
            {
                var menuCMS = new ShopMenuController();
                menuCMS.PrintMainShopMenu();
            }
        }
    }
}

