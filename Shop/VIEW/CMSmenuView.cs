using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop {
    public class CMSmenuView {

        public static void PrintMainMenuCMS(List<MenuItem> menuItemsToBePrinted) {
            Console.Clear(); Console.ResetColor();

            CMSmenuView.LogoScreen();
            PrintMenuList(menuItemsToBePrinted);
        }

        public static void PrintMenuList(List<MenuItem> menuItemsList) {
            foreach (MenuItem item in menuItemsList) {
                Console.WriteLine(item);
            }
        }

        public static void LogoScreen() {
            Console.Clear();
            string separator = new String('*', Console.LargestWindowWidth);
            Console.WriteLine(separator);
            foreach (string line in CMSlogo.ShopLogo()) {
                // Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
            Console.WriteLine($"\n{separator}");
        }

        public static string GetTableName() {

            string tableName;

            do { 
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Enter the name of the table: ");
                Console.ResetColor();
                tableName = Console.ReadLine();
            } while (!Enum.GetNames(typeof(AvailableTableNames)).Contains(tableName));

            return tableName;
        }
        public static void AddNewData() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please follow the next instructions to add a new record to Shop's Database.\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("AVAILABLE TABLES TO CHOOSE:");
            Console.ResetColor();
            Console.WriteLine(":: products :: division :: brigade :: battalion :: clients :: transactions ::\n");
            
            string table_name1 = CMSmenuView.GetTableName();
            
            List<string> newEntryData = CMSmenuView.GetEntryToDbInput(table_name1, new List<string>() { "name", 
                                                                                                        "division", 
                                                                                                        "brigade",
                                                                                                        "battalion",
                                                                                                        "quantity",
                                                                                                        "unit",
                                                                                                        "status",
                                                                                                        "price"});  
            
            string name_new = newEntryData[0];
            string div_new = newEntryData[1];
            string bryg_new = newEntryData[2];
            string bat_new = newEntryData[3];
            string qua_new_str = newEntryData[4];
            int qua_new = Int16.Parse(qua_new_str);
            string unit_new = newEntryData[5];
            string status_new = newEntryData[6].ToUpper();
            string price_new_str = newEntryData[7];
            float price_new = float.Parse(price_new_str);

            ConnectDB conection_DB = new ConnectDB();
            conection_DB.Add_new_record(table_name1,name_new,div_new, bryg_new,bat_new,qua_new,unit_new,status_new, price_new);
            Console.ReadKey();
        }

        public static void PrintTableStructure(string tableName) {

        }

        public static List<string> GetEntryToDbInput(string dbTableName, List<string> requiredColumns) {
            
            List<string> dataRowInput = new List<string>();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine($"\nEnter the following information about new product which you want to add.");
            Console.ResetColor();
            foreach (string column in requiredColumns) {
                string userInput;
                do {
                    Console.Write($"{column.ToUpper()}:  ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    userInput = Console.ReadLine();
                    Console.ResetColor();
                } while (!CMSmenuView.ValidateInputData(userInput, dbTableName, column));
                dataRowInput.Add(userInput);
            }

            return dataRowInput;
        }


        public static bool ValidateInputData (string input, string dbTableName, string dataColumnName) {
            
            // Column with specific data type constraints - products table
            List<string> varchars25 = new List<string>(){"name", "division", "brigade", "battalion" };
            string varchars5 = "unit";
            string varchars1 = "status";
            string ints = "quantity";
            string reals = "price";

            if (dbTableName.ToLower() != "products") {return false;}
            else {
                if (varchars25.Contains(dataColumnName)) { if (input.Length <= 25) return true; }
                else if (varchars5 == dataColumnName) {if (input.Length <= 5) return true;}
                else if (varchars1 == dataColumnName) {if (input.Length == 1) return true;}
                
                else if (ints == dataColumnName) {
                    try {
                        int qua_new = Int16.Parse(input);
                        return true;
                    } catch (Exception e) {return false;}
                }
                else if (reals == dataColumnName) {
                    try {
                        float price_new = float.Parse(input);
                        return true;
                    } catch (Exception e) {return false;}
                }
                return false;
            }
            // TODO: Update validation to be based on db type reqest:
            // Query that might be helpful:
            // SELECT DATA_TYPE 
            // FROM INFORMATION_SCHEMA.COLUMNS
            // WHERE 
            //     TABLE_NAME = 'yourTableName' AND 
            //     COLUMN_NAME = 'yourColumnName'
        }

        public static void FindByCategory() {
            Console.Clear();
            Console.WriteLine("Find product using the category search machine");
            Console.WriteLine("===============================================");
            List<string> div_out = new List<string>();
            List<string> bry_out = new List<string>();
            List<string> bat_out = new List<string>();
            List<string> pro_out = new List<string>();
            string pro_discription;
            string outcomeDiv;
            string outcomeBry;
            string outcomeBat;
            string outName;
            string result;
            int wsk;
            ConnectDB conection_DB2 = new ConnectDB();
            div_out = conection_DB2.Find_Division();
            for (int j = 1; j <= div_out.Count; j++)
            {
                Console.WriteLine("{0}. {1}", j, div_out[j-1]);
            }
            
            Console.Write("Enter division number: ");
            result = Console.ReadLine();
            wsk = Int16.Parse(result);
            outcomeDiv = div_out[wsk-1];
            Console.WriteLine("--------------------------");
            Console.WriteLine("DIVISION: " + outcomeDiv);
            ConnectDB conection_DB21 = new ConnectDB();
            bry_out = conection_DB21.Find_Brigade(outcomeDiv);
            for (int j = 1; j <= bry_out.Count; j++)
            {
                Console.WriteLine("{0}. {1}", j, bry_out[j-1]);
            }
            
            Console.Write("Enter brigade number: ");
            result = Console.ReadLine();
            wsk = Int16.Parse(result);
            outcomeBry = bry_out[wsk-1];
            Console.WriteLine("----------------------------");
            Console.WriteLine("DIVISION: " + outcomeDiv + ", BRIGADE: " + outcomeBry);
            ConnectDB conection_DB22 = new ConnectDB();
            bat_out = conection_DB22.Find_Battalion(outcomeDiv, outcomeBry);
            for (int j = 1; j <= bat_out.Count; j++)
            {
                Console.WriteLine("{0}. {1}", j, bat_out[j-1]);
            }
            
            Console.Write("Enter battalion number: ");
            result = Console.ReadLine();
            wsk = Int16.Parse(result);
            outcomeBat = bat_out[wsk-1];
            Console.WriteLine("----------------------------");
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            ConnectDB conection_DB23 = new ConnectDB();
            pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat);
            for (int j = 1; j <= pro_out.Count; j++)
            {
                Console.WriteLine("{0}. {1}", j, pro_out[j-1]);
            }
            
            Console.Write("Enter product number: ");
            result = Console.ReadLine();
            wsk = Int16.Parse(result);
            
            outName = pro_out[wsk-1];
            Console.WriteLine("-----------------------------");
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            ConnectDB conection_DB24 = new ConnectDB();
            //zwraca uuid
            pro_discription = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
            Console.WriteLine("UUID: " + pro_discription);
            Console.ReadKey();
        }
    
        public static void SearchInStock() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Display specific tables, columns or products\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("AVAILABLE TABLES TO CHOOSE:");
            Console.ResetColor();
            Console.WriteLine(":: products :: division :: brigade :: battalion :: clients :: transactions ::\n");
            string table_name5 = CMSmenuView.GetTableName();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nEnter a letter or word: ");
            Console.ResetColor();
            string frag_cond = Console.ReadLine();
            ConnectDB conection_DB5 = new ConnectDB();
            conection_DB5.Display_Table(table_name5, frag_cond);
            Console.ReadKey();
            
        }

        public static void UpdateOrDelete() {
            Console.WriteLine("Updating the record");
            Console.WriteLine("=======================");
            List<string> div_out = new List<string>();
            List<string> bry_out = new List<string>();
            List<string> bat_out = new List<string>();
            List<string> pro_out = new List<string>();
            string pro_discription;
            string outcomeDiv;
            string outcomeBry;
            string outcomeBat;
            string outName;
            string result;
            int wsk;
            ConnectDB conection_DB2 = new ConnectDB();
            div_out = conection_DB2.Find_Division();

            for (int i = 1; i <= div_out.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, div_out[i-1]);
            }

            Console.Write("Enter division number: ");

            result = Console.ReadLine();
            // check block
            char firstchar = result[0];  //first char from string input
            int asciicode = firstchar;   //change char to ascii value
            char maxchar = (char)(div_out.Count + '0'); // change size list to char
            int maxascii = maxchar; //change char to ascii value
            while (asciicode < 49 || asciicode > maxascii)  //while correcness loop
            {
                Console.Write("Enter PROPER (!!!) division number: ");
                result = Console.ReadLine();
                firstchar = result[0];  
                asciicode = firstchar;
            }
            // check block
            wsk = Int16.Parse(result);
            outcomeDiv = div_out[wsk-1];
            Console.WriteLine("--------------------------");
            Console.WriteLine("DIVISION: " + outcomeDiv);
            ConnectDB conection_DB21 = new ConnectDB();
            bry_out = conection_DB21.Find_Brigade(outcomeDiv);
            for (int i = 1; i <= bry_out.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, bry_out[i-1]);
            }
            
            Console.Write("Enter brigade number: ");
            result = Console.ReadLine();
            // check block
            firstchar = result[0];  //first char from string input
            asciicode = firstchar;   //change char to ascii value
            maxchar = (char)(bry_out.Count + '0'); // change size list to char
            maxascii = maxchar; //change char to ascii value
            while (asciicode < 49 || asciicode > maxascii)  //while correcness loop
            {
                Console.Write("Enter PROPER (!!!) brigade number: ");
                result = Console.ReadLine();
                firstchar = result[0];  
                asciicode = firstchar;
            }
            // check block
            wsk = Int16.Parse(result);
            outcomeBry = bry_out[wsk-1];
            Console.WriteLine("----------------------------");
            Console.WriteLine("DIVISION: " + outcomeDiv + ", BRIGADE: " + outcomeBry);
            ConnectDB conection_DB22 = new ConnectDB();
            bat_out = conection_DB22.Find_Battalion(outcomeDiv, outcomeBry);
            for (int i = 1; i <= bat_out.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, bat_out[i-1]);
            }
            
            Console.Write("Enter battalion number: ");
            result = Console.ReadLine();
            // check block
            firstchar = result[0];  //first char from string input
            asciicode = firstchar;   //change char to ascii value
            maxchar = (char)(bat_out.Count + '0'); // change size list to char
            maxascii = maxchar; //change char to ascii value
            while (asciicode < 49 || asciicode > maxascii)  //while correcness loop
            {
                Console.Write("Enter PROPER (!!!) battalion number: ");
                result = Console.ReadLine();
                firstchar = result[0];  
                asciicode = firstchar;
            }
            // check block
            wsk = Int16.Parse(result);
            outcomeBat = bat_out[wsk-1];
            Console.WriteLine("----------------------------");
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            ConnectDB conection_DB23 = new ConnectDB();
            pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat);
            for (int i = 1; i <= pro_out.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, pro_out[i-1]);
            }
            

            Console.Write("Enter product number: ");
            result = Console.ReadLine();
            // check block
            firstchar = result[0];  //first char from string input
            asciicode = firstchar;   //change char to ascii value
            maxchar = (char)(pro_out.Count + '0'); // change size list to char
            maxascii = maxchar; //change char to ascii value
            while (asciicode < 49 || asciicode > maxascii)  //while correcness loop
            {
                Console.Write("Enter PROPER (!!!) product number: ");
                result = Console.ReadLine();
                firstchar = result[0];  
                asciicode = firstchar;
            }
            // check block
            wsk = Int16.Parse(result);
            outName = pro_out[wsk-1];
            Console.WriteLine("-----------------------------");
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            ConnectDB conection_DB24 = new ConnectDB();
            // return uuid
            pro_discription = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
            
            Console.WriteLine("-----------------------------");
            Console.WriteLine("U (update)   D  (delete) -> Select an option");
            result = Console.ReadLine().ToUpper();
            if (result == "U")
            {
                Console.WriteLine("What would you like to change? -> Select an option");
                List<string> things_to_change = new List<string>() {"price", "quantity","name of product"};
                for (int i = 1; i<=things_to_change.Count; i++)
                {
                    Console.WriteLine(i +") " + things_to_change[i-1]);
                }
                result = Console.ReadLine();
                if (result == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Enter new price value: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    float val = float.Parse(Console.ReadLine());
                    Console.ResetColor();
                    ConnectDB connection_DB26 = new ConnectDB();
                    connection_DB26.UpdatePrice(pro_discription, val);

                }
                else if (result == "2") 
                {   
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Enter new quantity value: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    int ival = Int16.Parse(Console.ReadLine());
                    Console.ResetColor();
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.UpdateQuantity(pro_discription, ival);
                }
                else if (result == "3")
                {   
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Enter new product name: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    result = Console.ReadLine();
                    Console.ResetColor();
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.UpdateName(pro_discription, result);
                }
            }
            else if (result == "D")
            {
                ConnectDB connection_DB25 = new ConnectDB();
                connection_DB25.DeleteRecord(pro_discription);
            }        
            Console.ReadKey();
        }

        public static void PreviewAllItemsInStock() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please follow the next instructions to add a new record to Shop's Database.\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("AVAILABLE TABLES TO CHOOSE:");
            Console.ResetColor();
            Console.WriteLine(":: products :: division :: brigade :: battalion :: clients :: transactions ::\n");
            string tableName = CMSmenuView.GetTableName();
            ConnectDB conection_DB_100 = new ConnectDB();
            List<string> columnsToQuery = new List<string>();
            
            conection_DB_100.ReadTable(tableName, new List<string>() {"name", "division", "status"});
            Console.ReadKey();
        }
    }
}