using System;

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
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");
        
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Add");
                    Connect_DB conection_DB = new Connect_DB();
                    conection_DB.Add_new_record("Sweet Bananas","Fresh Food", "Fruits","Bananas",999,"kg","A", (float)2.5);
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Find");
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
                    return false;
                default:
                    return true;
            }
        }
    }
}