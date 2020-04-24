using System;
using System.Collections.Generic;

namespace Shop {
    public class CMSmenuView {
        public static void LogoScreen() {
            Console.Clear();
            string separator = new String('*', Console.LargestWindowWidth);
            Console.WriteLine(separator);
            foreach (string line in CMSlogo.ShopLogo()) {
                // Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine(separator);
        }
        public static void AddNewData() {
            Console.Clear();
            Console.WriteLine("Adding new record to the particular table");
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
            Connect_DB conection_DB2 = new Connect_DB();
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
            Connect_DB conection_DB21 = new Connect_DB();
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
            Connect_DB conection_DB22 = new Connect_DB();
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
            Connect_DB conection_DB23 = new Connect_DB();
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
            Connect_DB conection_DB24 = new Connect_DB();
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
            Connect_DB conection_DB5 = new Connect_DB();
            conection_DB5.Display_Table(table_name5, frag_cond);
            Console.ReadKey();
        }
    }
}