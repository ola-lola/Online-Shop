using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shop {
    public class CMSmenuView {

        public static void PrintMainMenuCMS(Menu menuCMSInstance) {
            Console.Clear(); Console.ResetColor();
            CMSmenuView.ShowLogo(CMSlogo.LogoLine1);
            CMSmenuView.ShowLogo(CMSlogo.ShopLogo());
            menuCMSInstance.PrintMenuList();
            CMSmenuView.ShowLogo(CMSlogo.LogoLine2);
        }

        public static void ShowLogo(IEnumerable<string> logo) {
            foreach (string line in logo) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(line);
                Console.ResetColor();
            }
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

        public static string GetColumnName(string tableName) {

            string columnName;
            ConnectDB conection_DB102 = new ConnectDB();

            do { 
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Enter the name of the column: ");
                Console.ResetColor();
                columnName = Console.ReadLine();
            } while (!conection_DB102.GetColumnNamesFromTable(tableName).Contains(columnName));

            return columnName;
        }

        public static void MainAddNewProduct() {

            Product added = CMSaddController.PrintCMSaddController();
            
            if (added != null) {
                ConnectDB conection_DB = new ConnectDB();
                conection_DB.AddProduct("products", added);
            }
            
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
                bool flag = false;
                do {
                    if (flag) { View.PrintError("Please give valid input"); }
                    Console.Write($"{column.ToUpper()}:  ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    userInput = Console.ReadLine();
                    Console.ResetColor();
                } while (flag = !CMSmenuView.ValidateInputData(userInput, dbTableName, column));
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
                if (varchars25.Contains(dataColumnName)) { if (input.Length > 0 && input.Length <= 25 && InputVerifications.isWord(input)) return true; }
                // unit
                else if (varchars5 == dataColumnName) {if (input.Length > 0 && input.Length <= 5 && InputVerifications.isWord(input)) return true;}
                // status
                else if (varchars1 == dataColumnName) {if (input.Length > 0 && input.Length == 1 && InputVerifications.isWord(input)) return true;}
                
                else if (ints == dataColumnName) {
                    try {
                        int qua_new = Int16.Parse(input);
                        return true;
                    } catch (Exception) {return false;}
                }
                else if (reals == dataColumnName) {
                    try {
                        float price_new = float.Parse(input);
                        return true;
                    } catch (Exception) {return false;}
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

           
        public static void SearchInStock() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Display specific tables, columns or products\n");

            ConnectDB conection_DB5 = new ConnectDB();
            PrintAvailableOptions("tables", conection_DB5.GetTableNamesFromDb());
            string table_name5 = CMSmenuView.GetTableName();
            
            // GET 'SEARCH BY' INFO
            ConnectDB conection_DB101 = new ConnectDB();
            PrintAvailableOptions("columns", conection_DB101.GetColumnNamesFromTable(table_name5));
            string searchByColumn = GetColumnName(table_name5);
            System.Console.WriteLine($"Search by column: {searchByColumn}");            

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nEnter a letter or word: ");
            Console.ResetColor();
            string frag_cond = Console.ReadLine();
            
            conection_DB5.SearchInTable(table_name5, frag_cond, searchByColumn);
            Console.ReadKey();
            
        }

        public static string GetProductUUID() {
            Console.Clear();
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
            List<string> div_out = new List<string>();
            List<string> bry_out = new List<string>();
            List<string> bat_out = new List<string>();
            List<string> pro_out = new List<string>();
            string prod_uuid;
            string outcomeDiv;
            string outcomeBry;
            string outcomeBat;
            string outName;
            string result;
            int wsk;
            // Choose the division
            ConnectDB conection_DB2 = new ConnectDB();
            Console.Out.WriteLine("List of available divisions:");
            div_out = conection_DB2.Find_Division();
            View.PrintList(div_out);
            Console.Write("Enter division number: ");
            result = Console.ReadLine();
            while(!View.VerifyListChoiceInput(result, div_out)) {
                Console.Write("Enter PROPER (!!!) division number: ");
                result = Console.ReadLine();
            }
            wsk = Int16.Parse(result);
            outcomeDiv = div_out[wsk-1];
            Console.Clear();
            Console.WriteLine("DIVISION: " + outcomeDiv);
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
            // Choose the brigade
            ConnectDB conection_DB21 = new ConnectDB();
            Console.Out.WriteLine("List of available brigades:");
            bry_out = conection_DB21.Find_Brigade(outcomeDiv);
            View.PrintList(bry_out);
            Console.Write("Enter brigade number: ");
            result = Console.ReadLine();
            while(!View.VerifyListChoiceInput(result, bry_out)) {
                Console.Write("Enter PROPER (!!!) brigade number: ");
                result = Console.ReadLine();
            }
            wsk = Int16.Parse(result);
            outcomeBry = bry_out[wsk-1];
            Console.Clear();
            Console.WriteLine("DIVISION: " + outcomeDiv + ", BRIGADE: " + outcomeBry);
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
            // Choose the battalion
            ConnectDB conection_DB22 = new ConnectDB();
            Console.Out.WriteLine("List of available battalions:");
            bat_out = conection_DB22.Find_Battalion(outcomeDiv, outcomeBry);
            View.PrintList(bat_out);
            
            Console.Write("Enter battalion number: ");
            result = Console.ReadLine();
            while(!View.VerifyListChoiceInput(result, bat_out)) {
                Console.Write("Enter PROPER (!!!) battalion number: ");
                result = Console.ReadLine();
            }
            wsk = Int16.Parse(result);
            outcomeBat = bat_out[wsk-1];
            Console.Clear();
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
            // Choose the product
            ConnectDB conection_DB23 = new ConnectDB();
            Console.Out.WriteLine("List of available products:");
            pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat);
            View.PrintList(pro_out);
            Console.Write("Enter product number: ");
            result = Console.ReadLine();
            while(!View.VerifyListChoiceInput(result, pro_out)) {
                Console.Write("Enter PROPER (!!!) product number: ");
                result = Console.ReadLine();
            }
            wsk = Int16.Parse(result);
            outName = pro_out[wsk-1];
            Console.WriteLine("-----------------------------");
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            // return iiud of product and display         
            ConnectDB conection_DB24 = new ConnectDB();
            return prod_uuid = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
        }    
        
        public static void UpdateOrDelete()
        {
            string pro_discription = GetProductUUID();
            string result;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("U (update)   D  (delete) -> Select an option");
            result = Console.ReadLine().ToUpper();
            if (result == "U")
            {
                Console.WriteLine("What would you like to change? -> Select an option");
                List<string> things_to_change = new List<string>() {"price", "quantity","name of product"};
                for (int i = 1; i<=things_to_change.Count; i++)
                {
                    Console.Write(i +") " + things_to_change[i-1] + "  ");
                }
                result = Console.ReadLine();
                if (result == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nEnter NEW price value: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n*If a new price includes cents/pounds - please use dots between numbers e.g. 2.4):\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    result = Console.ReadLine();
                        while (!(InputVerifications.isNumeric(result)))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Invalid input.\n\n Try again:  ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            result = Console.ReadLine();
                            Console.ResetColor();
                        }
                    float val = float.Parse(result);
                    Console.ResetColor();
                    ConnectDB connection_DB26 = new ConnectDB();
                    connection_DB26.UpdateProductPrice(pro_discription, val);
                }

                else if (result == "2") 
                {   
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nEnter NEW quantity value: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    result = Console.ReadLine();
                        while (!(InputVerifications.isNumeric(result)))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Quantity column accept only numbers. Do not use letters.\n\n Try again:  ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            result = Console.ReadLine();
                            Console.ResetColor();
                        }
                    int ival = Int16.Parse(result);
                    Console.ResetColor();
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.UpdateProductQuantity(pro_discription, ival);
                }
                else if (result == "3")
                {   
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\nEnter NEW product name: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    result = Console.ReadLine();
                    while (result.Length > 25){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis name is too long.Please use max 25 letters.\n\n Try again:  ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        result = Console.ReadLine();
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.UpdateProductName(pro_discription, result);
                }
                else
                {
                    Console.WriteLine("You exit update. No changes");
                }
            }
            else if (result == "D")
            {
                ConnectDB connection_DB25 = new ConnectDB();
                connection_DB25.DeleteProduct(pro_discription);
            }        
            Console.ReadKey();
        }

        public static void PreviewAllItemsInStock() {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please follow the instructions to see table content in the Shop's Database.\n");
            
            ConnectDB conection_DB_100 = new ConnectDB();
            PrintAvailableOptions("tables", conection_DB_100.GetTableNamesFromDb());
            string tableName = CMSmenuView.GetTableName();
            
            // GET 'SEARCH WHAT' INFO
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("Please input which columns to display\nenter - confirm, Esc - to finish input"); Console.ResetColor();
            List<string> columnsToQuery = new List<string>();
            PrintAvailableOptions("columns", conection_DB_100.GetColumnNamesFromTable(tableName));
            var action = Console.ReadKey(true).Key;
            while (action != ConsoleKey.Escape) {
                string column = GetColumnName(tableName);
                columnsToQuery.Add(column);
                action = Console.ReadKey(true).Key;
            }
            conection_DB_100.ReadTable(tableName, columnsToQuery);
            Console.ReadKey();
        }

        public static void PrintAvailableOptions(string optionsGroupName, List<string> options) {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"AVAILABLE {optionsGroupName.ToUpper()} TO CHOOSE:");
            Console.ResetColor();
            foreach (string name in options) {
                Console.Write($":: {name} :: ");
            }
            System.Console.WriteLine();
        }
    }
}