using System;
namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
           // build connection string with DB on local server
           
           if (args.Length == 1)
           {
               if (args[0]== "aaa")
               {
                   bool showMenu = true;
                   while(showMenu)
                   {
                       showMenu = CMSmenu.CMSMenu_display();
                   }
               }
           }
           Console.WriteLine("Hello Team");
        }
        
    }
}
