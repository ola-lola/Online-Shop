using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shop {
    public class ShopMenuView {

        public static float total;
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nFind the product ( division | brigade | battalion )");
            Console.ResetColor();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
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
            Console.Out.WriteLine("Available divisions:\n");
            div_out = conection_DB2.Find_Division();
            View.PrintList(div_out);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\nEnter division number: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            result = Console.ReadLine();
            Console.ResetColor();
            
            while(!View.VerifyListChoiceInput(result, div_out)) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("wrong input");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n\nEnter PROPER (!!!) division number: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                result = Console.ReadLine();
                Console.ResetColor();
            }
            wsk = Int16.Parse(result);
            outcomeDiv = div_out[wsk-1];
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("DIVISION: " + outcomeDiv);
            Console.ResetColor();
            // Choose the brigade
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nFind the product ( division | brigade | battalion )");
            Console.ResetColor();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            ConnectDB conection_DB21 = new ConnectDB();
            Console.Out.WriteLine("Available brigades:\n");
            bry_out = conection_DB21.Find_Brigade(outcomeDiv);
            View.PrintList(bry_out);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\nEnter brigade number: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            result = Console.ReadLine();
            Console.ResetColor();
            while(!View.VerifyListChoiceInput(result, bry_out)) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("wrong input");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n\nEnter PROPER (!!!) brigade number: ");
                result = Console.ReadLine();
                Console.ResetColor();
            }
            wsk = Int16.Parse(result);
            outcomeBry = bry_out[wsk-1];
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("DIVISION: " + outcomeDiv + ", BRIGADE: " + outcomeBry);
            Console.ResetColor();
            // Choose the battalion
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nFind the product ( division | brigade | battalion )");
            Console.ResetColor();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            ConnectDB conection_DB22 = new ConnectDB();
            Console.Out.WriteLine("Available battalions:\n");
            bat_out = conection_DB22.Find_Battalion(outcomeDiv, outcomeBry);
            View.PrintList(bat_out);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\nEnter battalion number: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            result = Console.ReadLine();
            Console.ResetColor();
            while(!View.VerifyListChoiceInput(result, bat_out)) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("wrong input");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n\nEnter PROPER (!!!) battalion number: ");
                result = Console.ReadLine();
                Console.ResetColor();
            }
            wsk = Int16.Parse(result);
            outcomeBat = bat_out[wsk-1];
            Console.WriteLine("----------------------------");
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            Console.ResetColor();
            // Choose the product
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nFind the product ( division | brigade | battalion )");
            Console.ResetColor();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            ConnectDB conection_DB23 = new ConnectDB();
            Console.Out.WriteLine("Available products:\n");
            pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat); //list of products
            View.PrintList(pro_out);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\nEnter product number: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            result = Console.ReadLine();
            Console.ResetColor();
            while(!View.VerifyListChoiceInput(result, pro_out)) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("wrong input");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("Enter PROPER (!!!) product number: ");
                result = Console.ReadLine();
                Console.ResetColor();
            }
            wsk = Int16.Parse(result);
            outName = pro_out[wsk-1];  // jeden product
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
            Console.ResetColor();
            // return iiud of product and display     
            Console.ForegroundColor = ConsoleColor.DarkYellow;    
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                         \n  Your selected product  \n                         ");
            
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------------------");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("\n\n             Next step:            ");
                Console.ResetColor();
                Console.Write("\n\n    :: P ::          :: ENTER :: ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\n(put into Cart)  (continue shoping) ");
                Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n    :: A ::           :: ENTER ::           :: C ::   ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n(change quantity)  (continue shoping)  (check your cart)");
                    Console.ResetColor();
                    result1 = Console.ReadLine().ToUpper();
                    if (result1 == "A")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("\nHow many: ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        int x = Int16.Parse(Console.ReadLine());
                        customer_Cart[pro_discription]= x;
                        Console.ResetColor();
                    }
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                            \n                         Your Cart:                         \n                                                            \n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("LP| Description               | price | Quantity |  Value  |");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------------------------");
                    Temp_Display_Cart(customer_Cart);
                    Console.WriteLine();
                    Console.Write("\n\n    :: S ::          :: ENTER :: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n  (go to cash)   (continue shoping) ");
                    Console.ResetColor();
                    result1 = Console.ReadLine().ToUpper();
                    if (result1 == "S") {break;}
                }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                                            \n                         Your Cart:                         \n                                                            \n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("LP| Description               | price | Quantity |  Value  |");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------");
            Dictionary<Product, int> outcome_prod = new Dictionary<Product, int>();
            outcome_prod = Temp_Display_Cart(customer_Cart);
            Console.WriteLine();
            Console.Write("\n\n    :: C ::          :: ENTER :: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n  (update cart)   (approve and pay) ");
            Console.ResetColor();
            string result = Console.ReadLine().ToUpper();
            if (result == "C")
            {
                bool correction = true;
                while(correction)
                {   
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n\n             Next step:            ");
                    Console.ResetColor();
                    Console.Write("\n\n     :: D ::          :: U :: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n(update product)  (delete product) ");
                    Console.ResetColor();
                    result = Console.ReadLine().ToUpper();
                    if (result == "D")
                    {   
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nEnter the Lp of product: ");
                        Console.ResetColor();
                        int k = Int16.Parse(Console.ReadLine());
                        customer_Cart.Remove(customer_Cart.ElementAt(k-1).Key);
                        System.Threading.Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nProduct has been removed.");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(2000);
                    }
                    else if (result == "U")
                    {   
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nEnter the Lp of product: ");
                        Console.ResetColor();
                        int k = Int16.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Enter the corrected quantity: ");
                        Console.ResetColor();
                        int q = Int16.Parse(Console.ReadLine());
                        string ind = customer_Cart.ElementAt(k-1).Key;
                        customer_Cart[ind] = q;
                        System.Threading.Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nProduct has been updated.");
                        Console.ResetColor();
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                            \n                         Your Cart:                         \n                                                            \n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("LP| Description               | price | Quantity |  Value  |");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------------------------------");
                    Temp_Display_Cart(customer_Cart);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n\n    :: Q ::          :: ENTER :: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\n(approve cart) (continue shoping) ");
                    Console.ResetColor();
                    result = Console.ReadLine().ToUpper();
                    if (result == "Q") {break;}
                }
            
            }
            Console.Clear();
            List<string> nicpas = PaymentProcedure();
            PayAndOut();
            string ui;
            int current_in_shop, current_in_Cart, updated_in_shop;
            for (int i = 0; i < customer_Cart.Count; i++)
            {
                ui = customer_Cart.ElementAt(i).Key; //id productu
                ConnectDB connetion_DB31 = new ConnectDB();
                current_in_shop = connetion_DB31.FindQuantity(ui);
                current_in_Cart = customer_Cart.ElementAt(i).Value;
                if (current_in_shop > current_in_Cart)
                {
                    updated_in_shop = current_in_shop - current_in_Cart;
                }
                else {updated_in_shop = 100;}
                ConnectDB connection_DB32 = new ConnectDB();
                connection_DB32.UpdateProductQuantity(ui, updated_in_shop);
            }
            // add new record to transactions
            ConnectDB connection_DB34 = new ConnectDB();
            string customerUUID = connection_DB34.Find_UUID_Customer(nicpas[0], nicpas[1]);
            string customerCCard = connection_DB34.Find_CCard(nicpas[0], nicpas[1]);
            Transaction transact = new Transaction(customerUUID, total,customerCCard);
            ConnectDB connetion_DB33 = new ConnectDB();
            connetion_DB33.AddNewTransactionToDB(transact);


        }
        static List<string> PaymentProcedure()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                            \n                     Payment Procedures                     \n                                                            ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------------------------------------------\n");
            Console.ResetColor();
            
            Console.Write("Are you registered client (Y/N): ");
            string result = Console.ReadLine().ToUpper();
            List<string> nick_and_pass = new List<string>();
            if (result == "Y")
            {
                Console.Write("\n\nNickname: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string tempnick = Console.ReadLine();
                Console.ResetColor();
                // sprawdzić czy nick jest w bazie
                ConnectDB connection_DB40 = new ConnectDB();
                List<string> mynicks = connection_DB40.CheckNick();
                if (mynicks.Contains(tempnick))
                {
                    nick_and_pass.Add(tempnick);
                }
                else {nick_and_pass.Add("anonymous");}
                
                string pass = "";
                Console.Write("\nPassword: ");
                ConsoleKeyInfo key;
                do
                {   
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b");
                    }
                    Console.ResetColor();
                }
                while (key.Key != ConsoleKey.Enter);
                nick_and_pass.Add(pass);
            }
            else
            {   
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------------------------------");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                            \n                     Payment Procedures                     \n                                                            ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------------------------------\n");
                Console.ResetColor();
                Console.WriteLine("Would You like to register (gaining 5% discount) (Y/N): ");
                string result1 = Console.ReadLine().ToUpper();
                if (result1 == "Y")
                {
                    nick_and_pass = RegisterClient();
                }
                else
                {
                    string creditName= "";
                    string nonickName = "anonymous";
                    nick_and_pass.Add(nonickName);
                    string nopassword = "anonymous";
                    nick_and_pass.Add(nopassword);
                    do {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n\nEnter credit card owner Name: ");
                        Console.ResetColor();
                        creditName = Console.ReadLine();
                    } while (!ShopMenuView.ValidateClientInputData(creditName, "customers", "name"));


                    string creditNumber = "";
                    do {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\nEnter credit card number: ");
                        Console.ResetColor();
                        creditNumber = Console.ReadLine();
                    } while (!InputVerifications.IsCreditCardNo(creditNumber));

                    string creditvalid = "";
                    do {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\nEnter valid throu date: ");
                        Console.ResetColor();
                        creditvalid = Console.ReadLine();
                    } while (!InputVerifications.IsValidThruDate(creditvalid));

                    string creditCVC = "";
                    do {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\nEnter CVV/CVC: ");
                        Console.ResetColor();
                        creditCVC = Console.ReadLine();
                    } while (!InputVerifications.IsCVC(creditCVC));
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\nEnter shipping address:");
                    Console.ResetColor();
                    string address_ship = Console.ReadLine();
                }
            }
            return  nick_and_pass;
        }
        
        static void PayAndOut()
        {    
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\n     :: E ::   ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n(accept payment)  ");
            Console.ResetColor();
            string result = Console.ReadLine().ToUpper();
            if (result == "E")
            {
                Console.WriteLine("\n\nWe verifying your credit card validity - it takes few seconds");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nWe confirmed and finished your payment.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                ShopMenuView.LogoScreenShop(ScreenAfterShopping.ThankYouMessage);

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
            total = 0;    
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                        Total price: " + total + " Euro");
            Console.ResetColor();
            for (int i = 0; i < contentCart.Count; i++)
            {
                product_dict[product_list[i]] = contentCart.ElementAt(i).Value;
            }
            return product_dict;
        }

        public static List<string> RegisterClient()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please follow the next instructions to register (5% discount guaranted).\n");
            string client_table_name = "customers";
            List<string> nickpass = new List<string>();
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
            nickpass.Add(newEntryData[5]);
            nickpass.Add(newEntryData[6]);
            return nickpass;
        }
        public static List<string> GetEntryToDbClientInput(string dbClientTab, List<string> requiredColumns)
        {
            List<string> dataRowClientInput = new List<string>();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine($"\nEnter the following information about Yourself (payment and delivery)");
            Console.ResetColor();
            foreach (string column in requiredColumns) {
                string userInput = "";
                string street = "";
                string house = "";
                string city = "";
                string postalCode = "";


                do {
                    if (column != "delivery_address") {
                        Console.Write($"{column.ToUpper()}:  ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        userInput = Console.ReadLine();
                        Console.ResetColor();
                    } else {
                        do {
                            userInput = "";
                            do {
                                Console.Write("Street: ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                street = Console.ReadLine();
                                Console.ResetColor();
                            } while (!InputVerifications.IsStreet(street));

                            do {
                                Console.Write("House number: ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                house = Console.ReadLine();
                                Console.ResetColor();
                            } while (!InputVerifications.IsHouseNb(house));

                            do {
                                Console.Write("City: ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                city = Console.ReadLine();
                                Console.ResetColor();
                            } while (!InputVerifications.IsStreet(city));

                            do {
                                Console.Write("Postal code: ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                postalCode= Console.ReadLine();
                                Console.ResetColor();
                            } while (!InputVerifications.IsPostalCode(postalCode));
                        userInput = street + " " + house + " " + city + " " + postalCode;
                        } while (userInput.Length > 40);
                    }
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
                if (varchars25.Contains(dataClientColumn)) { if (input.Length > 0 && input.Length <= 25) return true; }
                else if (varchars40 == dataClientColumn) {if (input.Length <= 40) return true;}
                else if (varchars16 == dataClientColumn && InputVerifications.IsCreditCardNo(input)) {
                    if (input.Length <= 16) return true; }
                else if (varchars9 == dataClientColumn && InputVerifications.IsTelephone(input)) {
                    if (input.Length <= 9) return true;}
                return false;
            }

        }

    }
}