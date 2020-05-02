using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shop {
    public class ShopMenuView {

        public static void PrintMainMenuShop(Menu menuInstance) {
            Console.Clear(); Console.ResetColor();
            
            ShopMenuView.LogoScreenShop(ShopLogo.ShopLogoPart1);
            menuInstance.PrintMenuList();
            ShopMenuView.LogoScreenShop(ShopLogo.ShopLogoPart2);
        }

        public static void LogoScreenShop(List<string> logo) {
            // Console.Clear();
            foreach (string line in logo) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(line);
            }
            Console.ResetColor();
            
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
            // Choose the brigade
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
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
            // Choose the battalion
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
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
            Console.WriteLine("----------------------------");
            Console.Clear();
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            // Choose the product
            Console.WriteLine("Find the product (division/brigade/battalion)");
            Console.WriteLine("==============================================");
            ConnectDB conection_DB23 = new ConnectDB();
            Console.Out.WriteLine("List of available products:");
            pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat); //list of products
            View.PrintList(pro_out);
            Console.Write("Enter product number: ");
            result = Console.ReadLine();
            while(!View.VerifyListChoiceInput(result, pro_out)) {
                Console.Write("Enter PROPER (!!!) product number: ");
                result = Console.ReadLine();
            }
            wsk = Int16.Parse(result);
            outName = pro_out[wsk-1];  // jeden product
            Console.Clear();
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            // return iiud of product and display         
            Console.WriteLine("==============================================");
            ConnectDB conection_DB24 = new ConnectDB();
            return prod_uuid = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
        }    
        public static void PutToCart()
        {
            Dictionary<string,int>  customer_Cart = new Dictionary<string,int>();
            bool continue_Shoping = true;
            while(continue_Shoping)
            {
                string pro_discription = GetProductUUID();
                Console.WriteLine("-----------------------------");
                Console.Write("P(put into Cart), ENTER (continue shoping) -> Select an option: ");
                string result1 = Console.ReadLine().ToUpper();
                if (result1 == "P")
                {
                    if (customer_Cart.ContainsKey(pro_discription))
                    {
                        int tempvalue = customer_Cart[pro_discription];
                        tempvalue += 1;
                        customer_Cart[pro_discription]= tempvalue;
                    }
                    else
                    {
                        customer_Cart.Add(pro_discription, 1);
                    }
                    Console.Write("A(add quantity), ENTER (continue): ");
                    result1 = Console.ReadLine().ToUpper();
                    if (result1 == "A")
                    {
                        Console.Write("How many: ");
                        int x = Int16.Parse(Console.ReadLine());
                        customer_Cart[pro_discription]= x;
                    }
                    Console.WriteLine("Your Cart:");
                    Console.WriteLine("LP| Description                 | price |Quantity|  Value  |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Temp_Display_Cart(customer_Cart);
                    Console.WriteLine();
                    Console.Write("S(to stop shoping), ENTER (continue shoping) -> Select an option: ");
                    result1 = Console.ReadLine().ToUpper();
                    if (result1 == "S") {break;}
                }
            }
            Console.Clear();
            Console.WriteLine("Your Cart:");
            Console.WriteLine("LP| Description                 | price |Quantity|  Value  |");
            Console.WriteLine("-----------------------------------------------------------");
            Dictionary<Product, int> outcome_prod = new Dictionary<Product, int>();
            outcome_prod = Temp_Display_Cart(customer_Cart);
            Console.WriteLine();
            Console.Write("C(Corect Cart content) -> Select an option:: ");
            string result = Console.ReadLine().ToUpper();
            if (result == "C")
            {
                bool correction = true;
                while(correction)
                {
                    Dictionary<string,int> correctCart = new Dictionary<string, int>();
                    Console.Write("D(delete product), U(update quantity -> Select an option: ");
                    result = Console.ReadLine().ToUpper();
                    if (result == "D")
                    {
                        Console.Write("Enter the Lp of product: ");
                        int k = Int16.Parse(Console.ReadLine());
                        customer_Cart.Remove(customer_Cart.ElementAt(k-1).Key);
                    }
                    else if (result == "U")
                    {
                        Console.Write("Enter the Lp of product: ");
                        int k = Int16.Parse(Console.ReadLine());
                        Console.Write("Enter the corrected quantity: ");
                        int q = Int16.Parse(Console.ReadLine());
                        string ind = customer_Cart.ElementAt(k-1).Key;
                        customer_Cart[ind] = q;
                    }
                    Console.Clear();
                    Console.WriteLine("LP| Description                 | price |Quantity|  Value  |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Temp_Display_Cart(customer_Cart);
                    Console.WriteLine();
                    Console.Write("Q(quit Cart correction), ENTER (continue correction): ");
                    result = Console.ReadLine().ToUpper();
                    if (result == "Q") {break;}
                }
            
            }
            PaymentProcedure();
        }
        static void PaymentProcedure()
        {
            Console.WriteLine();
            Console.WriteLine("Payment Procedures");
            Console.WriteLine("---------------------------");
            Console.Write("Enter credit card owner name: ");
            string creditName = Console.ReadLine();
            Console.Write("Enter credit card number: ");
            string creditNumber = Console.ReadLine();
            Console.Write("Enter valid throu date: ");
            string creditvalid = Console.ReadLine();
            Console.Write("Enter CVV/CVC: ");
            string creditCVC = Console.ReadLine();
            Console.Write("E (accept Payment)");
            string result = Console.ReadLine().ToUpper();
            if (result == "E")
            {
                Console.WriteLine("We verifying your credit card validity - it takes few seconds");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("We confirm your payment. Product will be deliver in 2 hours");
                Console.WriteLine("Thank You Very Much. We are looking forward to be in your service");
            }
            Console.ReadKey();
        }
        
        
        static Dictionary<Product, int> Temp_Display_Cart(Dictionary<string,int> contentCart)
        {
            Dictionary<Product, int> product_dict = new Dictionary<Product, int>();
            List<Product> product_list = new List<Product>();
            ConnectDB conectionproper = new ConnectDB();
            int counter = 0;
            float sum;
            float total = 0;    
            foreach (KeyValuePair<string,int> kvp in contentCart)
            {
                counter += 1;
                List<string> mojeproperties = conectionproper.Product_Properties(kvp.Key);
                string s1 = String.Format("{0}. {1}({2})",counter, mojeproperties[0],mojeproperties[5]);
                sum = kvp.Value * float.Parse(mojeproperties[7]);
                total = total + sum;
                string s = String.Format("{0,-35}{1, -8}{2,-10}{3,-8}",s1,mojeproperties[7], kvp.Value, sum);  
                Console.WriteLine(s);
                product_list.Add(new Product(
                    mojeproperties[0],mojeproperties[1],mojeproperties[2],mojeproperties[3],
                    Int16.Parse(mojeproperties[4]),mojeproperties[5],mojeproperties[6], float.Parse(mojeproperties[7])));
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("                                        Total price: " + total + " Euro");
            for (int i = 0; i < contentCart.Count; i++)
            {
                product_dict[product_list[i]] = contentCart.ElementAt(i).Value;
            }
            return product_dict;
        }

        public static void RegisterClient()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please follow the next instructions to register (5% discount guaranted).\n");
            string client_table_name = "customers";
            List<string> newEntryData = ShopMenuView.GetEntryToDbClientInput(client_table_name, new List<string>() { "name", 
                                                                                                        "surname", 
                                                                                                        "email",
                                                                                                        "delivery_address",
                                                                                                        "tel_number",
                                                                                                        "nick",
                                                                                                        "password",
                                                                                                        "credit_card_number"});
            
            Customer clientDataToBeAdded = new Customer(newEntryData[0],
                                                        newEntryData[1],
                                                        newEntryData[2],
                                                        newEntryData[3],
                                                        newEntryData[4],
                                                        newEntryData[5],
                                                        newEntryData[6],
                                                        newEntryData[7]);
            ConnectDB conection_ClientDB = new ConnectDB();
            conection_ClientDB.AddCustomer(client_table_name, clientDataToBeAdded);
            Console.ReadKey();
        }
        public static List<string> GetEntryToDbClientInput(string dbClientTab, List<string> requiredColumns)
        {
            List<string> dataRowClientInput = new List<string>();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine($"\nEnter the following information about Yourself (payment and delivery)");
            Console.ResetColor();
            foreach (string column in requiredColumns) {
                string userInput;
                do {
                    Console.Write($"{column.ToUpper()}:  ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    userInput = Console.ReadLine();
                    Console.ResetColor();
                } while (!ShopMenuView.ValidateClientInputData(userInput, dbClientTab, column));
                dataRowClientInput.Add(userInput);
            }
            return dataRowClientInput;
        }
        
        public static bool ValidateClientInputData(string input,string dbClientTableName,string dataClientColumn)
        {
            // Column with specific data type constraints - products table
            List<string> varchars25 = new List<string>(){"name", "surname", "email", "nick", "password" };
            string varchars40 = "delivery_address";
            string varchars16 = "credit_card_number";
            string varchars9 = "tel_number";
            if (dbClientTableName.ToLower() != "customers") {return false;}
            else {
                if (varchars25.Contains(dataClientColumn)) { if (input.Length <= 25) return true; }
                else if (varchars40 == dataClientColumn) {if (input.Length <= 40) return true;}
                else if (varchars16 == dataClientColumn) {if (input.Length <= 16) return true;}
                else if (varchars9 == dataClientColumn) {if (input.Length <= 9) return true;}
                return false;
            }

        }

    }
}
