using System;
using System.Collections.Generic;

namespace Shop
{
    static class CMSmenu 
    {
        public static bool CMSMenu_display()
        {
            Console.Clear();
            Console.WriteLine("CSM CRUD method -> Choose an option:");
            Console.WriteLine("1) CREATE a new record");
            Console.WriteLine("2) READ records");
            Console.WriteLine("3) UPDATE or DELETE the record");
            Console.WriteLine("4) Exit");
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
                    ConnectDB conection_DB = new ConnectDB();
                    conection_DB.Add_new_record(table_name1,name_new,div_new, bryg_new,bat_new,qua_new,unit_new,status_new, price_new);
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.WriteLine("Displaying the contents of the particular table");
                    Console.Write("Enter the name of the table: ");
                    string table_name5 = Console.ReadLine();
                    Console.Write("Enter name SQL LIKE condition (ex.%ban%): ");
                    string frag_cond = Console.ReadLine();
                    ConnectDB conection_DB5 = new ConnectDB();
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
                    return true;
                
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}