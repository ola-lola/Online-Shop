using System;
using System.Collections.Generic;


namespace Shop {
        
    public class CMSaddController {

        public static Product PrintCMSaddController() {

            // Console.Clear();
            // Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Console.WriteLine("Please follow the next instructions to add a new record to Shop's Database.\n");

            ConnectDB newConn = new ConnectDB();
            List<string> tables = newConn.GetTableNamesFromDb();
            Menu tablesToChoose = new Menu(tables);

            while (tablesToChoose.menuDisplayed) {

                tablesToChoose.current = tablesToChoose.menuItems[tablesToChoose.currentItemIndex];
                
                tablesToChoose.current.isChecked = true;
                Console.Clear();
        
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Please follow the next instructions to add a new record to Shop's Database.\n");

                tablesToChoose.PrintMenuList();
                Console.ResetColor();
                tablesToChoose.current.isChecked = false;

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Enter) {

                    // Parse current menu item content (string) to defined enum
                    switch (tablesToChoose.current.Content) {
                        case "products":
                            Console.Clear();
                            List<string> newEntryData = CMSmenuView.GetEntryToDbInput("products", new List<string>() { "name", 
                                                                                                                "division", 
                                                                                                                "brigade",
                                                                                                                "battalion",
                                                                                                                "quantity",
                                                                                                                "unit",
                                                                                                                "status",
                                                                                                                "price"});  
                    
                            Product productToBeAdded = new Product( newEntryData[0],
                                                                    newEntryData[1],
                                                                    newEntryData[2],
                                                                    newEntryData[3],
                                                                    Int16.Parse(newEntryData[4]),
                                                                    newEntryData[5],
                                                                    newEntryData[6].ToUpper(),
                                                                    float.Parse(newEntryData[7]));

                            return productToBeAdded;
                            break;
                        case "customers":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine(   "\nOPTION NOT AVAILABLE YET - PLEASE CHOOSE ANOTHER DATA TABLE\n\n" +
                                                        "\tThis feature is coming in the release 2.0");
                            Console.ResetColor();
                            break;
                        case "transactions":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            System.Console.WriteLine(   "\nOPTION NOT AVAILABLE YET - PLEASE CHOOSE ANOTHER DATA TABLE\n\n" +
                                                        "\tThis feature is coming in the release 2.0");
                            Console.ResetColor();
                            break;
                    }
                    tablesToChoose.menuDisplayed = false;
                }
                tablesToChoose.NavigateMenu(pressedKey);
            }
            Product dummy = null;
            return dummy;

        }
        
    }
}
