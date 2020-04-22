using System;
using System.Collections.Generic;

namespace Shop
{
    static class CMSmenu 
    {
        public static bool CMSMenu_display()
        {
            Console.Clear();
            Console.WriteLine("Admin Staff -> Choose an option:");
            Console.WriteLine("1) Add a new record to the table: products");
            Console.WriteLine("2) Find the record in the table: products");
            Console.WriteLine("3) Update the record in the table: products");
            Console.WriteLine("4) Delete the record from the table: products");
            Console.WriteLine("5) Display the table: products");
            Console.WriteLine("6) Exit");
            Console.Write("\r\nSelect an option: ");
        
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Adding new record to particular table");
                    Console.Write("Enter the name of the table: ");
                    string table_name1 = Console.ReadLine();
                    Console.Write("Enter the name of new product: ");
                    string name_new = Console.ReadLine();
                    Console.Write("Enter the division of new product: ");
                    string div_new = Console.ReadLine();
                    Console.Write("Enter the brygade of new product: ");
                    string bryg_new = Console.ReadLine();
                    Console.Write("Enter the battalion of new product: ");
                    string bat_new = Console.ReadLine();
                    Console.Write("Enter the quantity of new product: ");
                    string qua_new_str = Console.ReadLine();
                    int qua_new = Int16.Parse(qua_new_str);
                    Console.Write("Enter the unit of new product: ");
                    string unit_new = Console.ReadLine();
                    Console.Write("Enter the status of new product: ");
                    string status_new = Console.ReadLine().ToUpper();
                    Console.Write("Enter the price of new product: ");
                    string price_new_str = Console.ReadLine();
                    float price_new = float.Parse(price_new_str);
                    Connect_DB conection_DB = new Connect_DB();
                    conection_DB.Add_new_record(table_name1,name_new,div_new, bryg_new,bat_new,qua_new,unit_new,status_new, price_new);
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Find");
                    // TODO - update UI (for Agnieszka, current is for dry runs only)
                    // Connect_DB conection_DB2 = new Connect_DB();
                    // conection_DB2.ReadTable("products", new List<string>{"name", "division"} );
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.WriteLine("Update");
                    Console.ReadKey();
                    return true;
                case "4":
                    Console.WriteLine("Delete");
                    Console.ReadKey();
                    return true;
                case "5":
                    Console.WriteLine("Displaying the particular table");
                    Console.Write("Enter the name of the table: ");
                    string table_name5 = Console.ReadLine();
                    Console.Write("Enter name SQL LIKE condition (ex.%ban%): ");
                    string frag_cond = Console.ReadLine();
                    Connect_DB conection_DB5 = new Connect_DB();
                    conection_DB5.Display_Table(table_name5, frag_cond);
                    Console.ReadKey();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }
        }
    }
}