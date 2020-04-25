using System;
using System.Collections.Generic;

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

        public static void AddNewData() {
            Console.WriteLine("Adding a new record to the particular table");
            
            string table_name1;
            do { 
                Console.Write("Enter the name of the table: ");
                table_name1 = Console.ReadLine();
            } while (table_name1.ToLower() != "products");
            
            
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

            System.Console.WriteLine($"Please specify entry to be added to the data table: {dbTableName}");
            foreach (string column in requiredColumns) {
                string userInput;
                do {
                    Console.Write($"{column.ToUpper()}:");
                    userInput = Console.ReadLine();
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
            Console.WriteLine("Displaying the particular table");
            Console.Write("Enter the name of the table: ");
            string table_name5 = Console.ReadLine();
            Console.Write("Enter name SQL LIKE condition (ex.%ban%): ");
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
                    Console.Write("Enter new price value: ");
                    float val = float.Parse(Console.ReadLine());
                    ConnectDB connection_DB26 = new ConnectDB();
                    connection_DB26.Update_Price(pro_discription, val);

                }
                else if (result == "2") 
                {
                    Console.Write("Enter new quantity value: ");
                    int ival = Int16.Parse(Console.ReadLine());
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.Update_Quantity(pro_discription, ival);
                }
                else if (result == "3")
                {
                    Console.Write("Enter new product name: ");
                    result = Console.ReadLine();
                    ConnectDB connection_DB27 = new ConnectDB();
                    connection_DB27.Update_Name(pro_discription, result);
                }
            }
            else if (result == "D")
            {
                ConnectDB connection_DB25 = new ConnectDB();
                connection_DB25.Delete_Record(pro_discription);
            }        
            Console.ReadKey();
        }

    }
}