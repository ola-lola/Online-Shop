using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Shop {
    public class Cart
    {
        public Dictionary<Product,int> cart = new Dictionary<Product, int>();
        public string Customer;
        public int CartValue;


        public void AddProductToCart() 
        {
            Dictionary<string,int>  customer_Cart = new Dictionary<string,int>();
            bool continue_Shoping = true;
            while(continue_Shoping)
            {
                string pro_discription = ShopMenuView.GetProductUUID();
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
            Console.Write("A(accept Cart content -> go to payment procedures: ");
            string result = Console.ReadLine().ToUpper();
            if (result == "A")
            {
                PaymentProcedure();
            }
            
        } 

        static void PaymentProcedure()
        {
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
       

        /*
        public void UpdateProductInCart() 
        {
         Dictionary<Product, int> customerCart = new Dictionary<Product, int>();
         Console.WriteLine("What do you want to do?");
         string result;
         result = Console.ReadLine();
         string pro_discription = ShopMenuView.GetProductUUID();
        if ((customerCart.ContainsKey(pro_discription) && value == 1)) {
            customerCart.Remove(pro_discription);
            Console.WriteLine("This product was deleted from your cart");
        }
        else { 
            int tempvalue = customerCart[pro_discription];
            tempvalue -= 1;
            customerCart[pro_discription] = tempvalue;
            Console.WriteLine("");
            }
        }

        */

        public void DeleteProductFromCart()
        {
            //odejmowanie pojedynczego produktu
        }

        public void DeleteAllFromCart()
        {

        }

        public void CalculateTotalCartValue()
        {
            //update total price po każdym dodaniu/odjeciu produktu z koszyka
        }

        public void MakeProductReservation() 
        {
            //jak starczy czasu
        }

        static Dictionary<Product, int> Temp_Display_Cart(Dictionary<string,int> contentCart)
        {
            Dictionary<Product, int> product_dict = new Dictionary<Product, int>();
            List<Product> product_list = new List<Product>();
            ConnectDB conectionproper = new ConnectDB();
            int counter = 0;    
            foreach (KeyValuePair<string,int> kvp in contentCart)
            {
                counter += 1;
                List<string> mojeproperties = conectionproper.Product_Properties(kvp.Key);
                string s1 = String.Format("{0}. {1}({2})",counter, mojeproperties[0],mojeproperties[5]);
                string s = String.Format("{0,-35}{1,-12}{2, -8}  --->  {3}",s1, "price/unit:",mojeproperties[7], kvp.Value);  
                Console.WriteLine(s);
                product_list.Add(new Product(
                    mojeproperties[0],mojeproperties[1],mojeproperties[2],mojeproperties[3],
                    Int16.Parse(mojeproperties[4]),mojeproperties[5],mojeproperties[6], float.Parse(mojeproperties[7])));
            }
            for (int i = 0; i < contentCart.Count; i++)
            {
                product_dict[product_list[i]] = contentCart.ElementAt(i).Value;
            }
            return product_dict;
        }

    }
}

