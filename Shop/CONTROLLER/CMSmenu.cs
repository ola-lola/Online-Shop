using System;
using System.Collections.Generic;

namespace Shop
{
    static class CMSmenu 
    {
        public static bool CMSMenu_display()
        {
<<<<<<< HEAD
            Console.Clear();
            Console.WriteLine("CSM CRUD -> Choose an option:");
            Console.WriteLine("1) CREATE a new record");
            Console.WriteLine("2) READ records");
            Console.WriteLine("3) UPDATE the record");
            Console.WriteLine("4) DELETE the record");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");
        
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Adding a new record to the particular table");
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
                    return true;
                case "2":
                    Console.WriteLine("Displaying the contents of the particular table");
                    Console.Write("Enter the name of the table: ");
                    string table_name5 = Console.ReadLine();
                    Console.Write("Enter name SQL LIKE condition (ex.%ban%): ");
                    string frag_cond = Console.ReadLine();
                    Connect_DB conection_DB5 = new Connect_DB();
                    conection_DB5.Display_Table(table_name5, frag_cond);
                    Console.ReadKey();
                    return true;
                                    
                case "3":
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
                    Connect_DB conection_DB2 = new Connect_DB();
                    div_out = conection_DB2.Find_Division();
                    for (int i = 1; i <= div_out.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", i, div_out[i-1]);
                    }
=======
            return false;
//             Console.Clear();
//             Console.WriteLine("Admin Staff -> Choose an option:");
//             Console.WriteLine("1) Add a new record to the table");
//             Console.WriteLine("2) Find the record in the table");
//             Console.WriteLine("3) Update the record in the table");
//             Console.WriteLine("4) Delete the record from the table");
//             Console.WriteLine("5) Display the table");
//             Console.WriteLine("6) Exit");
//             Console.Write("\r\nSelect an option: ");
        
//             switch (Console.ReadLine())
//             {
//                 case "1":
//                     Console.WriteLine("Adding new record to the particular table");
//                     Console.Write("Enter the name of the table: ");
//                     string table_name1 = Console.ReadLine();
//                     Console.Write("Enter the name of new product: ");
//                     string name_new = Console.ReadLine();
//                     Console.Write("Enter the division of new product: ");
//                     string div_new = Console.ReadLine();
//                     Console.Write("Enter the brygade of new product: ");
//                     string bryg_new = Console.ReadLine();
//                     Console.Write("Enter the battalion of new product: ");
//                     string bat_new = Console.ReadLine();
//                     Console.Write("Enter the quantity of new product: ");
//                     string qua_new_str = Console.ReadLine();
//                     int qua_new = Int16.Parse(qua_new_str);
//                     Console.Write("Enter the unit of new product: ");
//                     string unit_new = Console.ReadLine();
//                     Console.Write("Enter the status of new product: ");
//                     string status_new = Console.ReadLine().ToUpper();
//                     Console.Write("Enter the price of new product: ");
//                     string price_new_str = Console.ReadLine();
//                     float price_new = float.Parse(price_new_str);
//                     Connect_DB conection_DB = new Connect_DB();
//                     conection_DB.Add_new_record(table_name1,name_new,div_new, bryg_new,bat_new,qua_new,unit_new,status_new, price_new);
//                     Console.ReadKey();
//                     return true;
//                 case "2":
//                     Console.WriteLine("Find product using the category search machine");
//                     Console.WriteLine("===============================================");
//                     List<string> div_out = new List<string>();
//                     List<string> bry_out = new List<string>();
//                     List<string> bat_out = new List<string>();
//                     List<string> pro_out = new List<string>();
//                     string pro_discription;
//                     string outcomeDiv;
//                     string outcomeBry;
//                     string outcomeBat;
//                     string outName;
//                     string result;
//                     int wsk;
//                     Connect_DB conection_DB2 = new Connect_DB();
//                     div_out = conection_DB2.Find_Division();
//                     for (int i = 1; i <= div_out.Count; i++)
//                     {
//                         Console.WriteLine("{0}. {1}", i, div_out[i-1]);
//                     }
>>>>>>> d5a560004ba5229eb2a6986685f5e71ac2bdcc8a
                    
//                     Console.Write("Enter division number: ");
//                     result = Console.ReadLine();
//                     wsk = Int16.Parse(result);
//                     outcomeDiv = div_out[wsk-1];
//                     Console.WriteLine("--------------------------");
//                     Console.WriteLine("DIVISION: " + outcomeDiv);
//                     Connect_DB conection_DB21 = new Connect_DB();
//                     bry_out = conection_DB21.Find_Brigade(outcomeDiv);
//                     for (int i = 1; i <= bry_out.Count; i++)
//                     {
//                         Console.WriteLine("{0}. {1}", i, bry_out[i-1]);
//                     }
                    
//                     Console.Write("Enter brigade number: ");
//                     result = Console.ReadLine();
//                     wsk = Int16.Parse(result);
//                     outcomeBry = bry_out[wsk-1];
//                     Console.WriteLine("----------------------------");
//                     Console.WriteLine("DIVISION: " + outcomeDiv + ", BRIGADE: " + outcomeBry);
//                     Connect_DB conection_DB22 = new Connect_DB();
//                     bat_out = conection_DB22.Find_Battalion(outcomeDiv, outcomeBry);
//                     for (int i = 1; i <= bat_out.Count; i++)
//                     {
//                         Console.WriteLine("{0}. {1}", i, bat_out[i-1]);
//                     }
                    
//                     Console.Write("Enter battalion number: ");
//                     result = Console.ReadLine();
//                     wsk = Int16.Parse(result);
//                     outcomeBat = bat_out[wsk-1];
//                     Console.WriteLine("----------------------------");
//                     Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
//                     Connect_DB conection_DB23 = new Connect_DB();
//                     pro_out = conection_DB23.Find_Product(outcomeDiv, outcomeBry, outcomeBat);
//                     for (int i = 1; i <= pro_out.Count; i++)
//                     {
//                         Console.WriteLine("{0}. {1}", i, pro_out[i-1]);
//                     }
                    
<<<<<<< HEAD
                    Console.Write("Enter product number: ");
                    result = Console.ReadLine();
                    wsk = Int16.Parse(result);
                    outName = pro_out[wsk-1];
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
                    Connect_DB conection_DB24 = new Connect_DB();
                    
                    pro_discription = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
                    Console.WriteLine();
                    Console.WriteLine("Select option: U(update), D(delete)");
                    result = Console.ReadLine().ToUpper();
                    if (result == "U")
                    {

                    }
                    if(result == "D")
                    {

                    }
                                     
                    Console.WriteLine("UUID: " + pro_discription);
                    
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
=======
//                     Console.Write("Enter product number: ");
//                     result = Console.ReadLine();
//                     wsk = Int16.Parse(result);
                    
//                     outName = pro_out[wsk-1];
//                     Console.WriteLine("-----------------------------");
//                     Console.WriteLine("DIVISION: "+ outcomeDiv + ", BRIGADE: " + outcomeBry + ", BATTALION: " + outcomeBat);
//                     Connect_DB conection_DB24 = new Connect_DB();
//                     //zwraca uuid
//                     pro_discription = conection_DB24.Find_Selected_Product(outcomeDiv, outcomeBry, outcomeBat, outName);
//                     Console.WriteLine("UUID: " + pro_discription);
                    
                    
                    
//                     Console.ReadKey();
//                     return true;
                
                
                
                
                
//                 case "3":
//                     Console.WriteLine("Update");
//                     Console.ReadKey();
//                     return true;
//                 case "4":
//                     Console.WriteLine("Delete");
//                     Console.ReadKey();
//                     return true;
//                 case "5":
//                     Console.WriteLine("Displaying the particular table");
//                     Console.Write("Enter the name of the table: ");
//                     string table_name5 = Console.ReadLine();
//                     Console.Write("Enter name SQL LIKE condition (ex.%ban%): ");
//                     string frag_cond = Console.ReadLine();
//                     Connect_DB conection_DB5 = new Connect_DB();
//                     conection_DB5.Display_Table(table_name5, frag_cond);
//                     Console.ReadKey();
//                     return true;
//                 case "6":
//                     return false;
//                 default:
//                     return true;
//             }
>>>>>>> d5a560004ba5229eb2a6986685f5e71ac2bdcc8a
        }
    }
}