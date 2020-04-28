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
                string result;
                Console.WriteLine("-----------------------------");
                Console.Write("P(put into Cart), ENTER (continue shoping) -> Select an option: ");
                result = Console.ReadLine().ToUpper();
                if (result == "P")
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
                    Console.WriteLine("Your Cart:");
                    Console.WriteLine("-----------");
                    Temp_Display_Cart(customer_Cart);
                    Console.WriteLine();
                    Console.Write("S(to stop shoping), ENTER (continue shoping) -> Select an option");
                    result = Console.ReadLine().ToUpper();
                    if (result == "S") {break;}
                }
            }
            Console.WriteLine("Your Cart:");
            Console.WriteLine("-----------");
            Temp_Display_Cart(customer_Cart);
            Console.WriteLine("Cart confirmation and payment block");
            Console.ReadKey();
        }
        static void Temp_Display_Cart(Dictionary<string,int> contentCart)
        {
                      
            foreach (KeyValuePair<string,int> kvp in contentCart)
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }
}
