using System;
using System.Text.RegularExpressions;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
           // build connection string with DB on local server
           
            // ADMIN MODE
            // if (args.Length == 1 && args[0]== "aaa")
            // {
            //     var menuCMS = new CMSmenuController();
            //     menuCMS.PrintmainMenu();
            // }
            // // SHOPPING MODE
            // else
            // {
            //     var menuCMS = new ShopMenuController();
            //     menuCMS.PrintMainShopMenu();
            // }

            System.Console.WriteLine(
                InputVerifications.IsEmail("A2@gmail.com")
            );
            // string regMatchPasswordCriteria = "^(?=.*[0-9]{2,})(?=.*[A-Z])[A-Za-z\\d]{6,}$";
            // Regex reg = new Regex(regMatchPasswordCriteria);
            // bool checkPasswordReg = reg.IsMatch("20yuTaa") ? true : false;
            // System.Console.WriteLine(checkPasswordReg);
        }
    }
}

