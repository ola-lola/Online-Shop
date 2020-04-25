using System;
using Npgsql;
using System.Collections.Generic;
namespace Shop
{
    ///
    // Class Conncect_DB - is IDAO implementation class
    ///
    class ConnectDB : IDAO
    {
    private static string connString = DbSettings.connString;

        public void Add_new_record(string t_name,string n,string div, string bry, string bat, int qua,string un,string st,float pr)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("INSERT INTO {0}(product_uid,name,division,brigade,battalion,quantity,unit,status, price) VALUES (uuid_generate_v4(),@n,@div,@bry,@bat,@qua,@un,@st,@pr)", t_name);

                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    command.Parameters.AddWithValue("@n", n);
                    command.Parameters.AddWithValue("@div", div);
                    command.Parameters.AddWithValue("@bry", bry);
                    command.Parameters.AddWithValue("@bat", bat);
                    command.Parameters.AddWithValue("@qua", qua);
                    command.Parameters.AddWithValue("@un", un);
                    command.Parameters.AddWithValue("@st", st);
                    command.Parameters.AddWithValue("@pr", pr);
                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Out.WriteLine(String.Format("\nInserted {0} row",nRows));
                    Console.ResetColor();
                }
            }
        }

        public void ReadRecord()
        {
            //TODO - Agnieszka
        }

        public void UpdateQuantity(string product_uid, int quantity)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string toUpdate = String.Format("UPDATE products SET quantity = @quantity WHERE product_uid = '{0}'", product_uid);
                Console.Out.WriteLine(toUpdate);
                conn.Open();
                using (var command = new NpgsqlCommand(toUpdate, conn))
                {
                    command.Parameters.AddWithValue("@quantity", quantity);

                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Out.WriteLine(String.Format("Product info updated",nRows));
                    Console.ResetColor();
                }
            }
        }

        public void UpdateName(string product_uid, string name)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string toUpdate = String.Format("UPDATE products SET name = @name WHERE product_uid = '{0}'", product_uid);
                Console.Out.WriteLine(toUpdate);
                conn.Open();
                using (var command = new NpgsqlCommand(toUpdate, conn))
                {
                    command.Parameters.AddWithValue("@name", name);

                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Out.WriteLine(String.Format("Product info updated",nRows));
                    Console.ResetColor();
                }
            }
        }

        public void UpdatePrice(string product_uid, float price)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string toUpdate = String.Format("UPDATE products SET price = @price WHERE product_uid = '{0}'", product_uid);
                Console.Out.WriteLine(toUpdate);
                conn.Open();
                using (var command = new NpgsqlCommand(toUpdate, conn))
                {
                    command.Parameters.AddWithValue("@price", price);

                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Out.WriteLine(String.Format("Product info updated",nRows));
                    Console.ResetColor();
                }
            }
        }

        public void DeleteRecord(string product_uid)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string toDelete = String.Format("DELETE FROM products WHERE product_uid = '{0}'", product_uid);
                conn.Open();
                using (var command = new NpgsqlCommand(toDelete, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Out.WriteLine(String.Format("Numbers of deleted rows = {0}", nRows));
                    Console.ResetColor();
                }
            }
        }

        
        public void ReadTable(string tableName , List<string> requiredColumns)
        {
            // Create SQL query string
            var columns = String.Join(", ", requiredColumns);
            // TODO: think about LIMIT added here (what if very large table?) -Agnieszka
            string SQLquery = $"SELECT {columns} FROM {tableName}";

            // Execute query to DB
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(SQLquery, conn))
                {
                    NpgsqlDataReader reader = null;
                    try {reader = command.ExecuteReader();}
                    catch (Npgsql.PostgresException e) { System.Console.WriteLine(e.Message); }

                    if (reader != null) {
                        while (reader.Read()) {
                            // TODO: change display or add writing data to List<Products>
                            Console.Write("{0}\t{1}\t{2} \n", reader[0], reader[1], reader[2]);
                        }
                    }
                }
                conn.Close();
                
                // TODO: update method - Agnieszka 
                // return new List<Product>();
            }
        }

        
        //METODY ANDRZEJA


        public void Delete_Record(string id)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("DELETE FROM products WHERE product_uid = '{0}'", id);
                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Numbers of rows deleted = {0}", nRows));
                }
            }
        }

        public void Update_Price(string id, float pr)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("UPDATE products SET price = {0} WHERE product_uid = '{1}'", pr,id);
                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Numbers of rows uddated = {0}", nRows));
                }
            }
        }
        public void Update_Quantity(string id, int qu)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("UPDATE products SET quantity = {0} WHERE product_uid = '{1}'", qu,id);
                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Numbers of rows uddated = {0}", nRows));
                }
            }
        }
        public void Update_Name(string id, string na)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("UPDATE products SET name = '{0}' WHERE product_uid = '{1}'", na,id);
                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Numbers of rows uddated = {0}", nRows));
                }
            }
        }

        

        
        public void Display_Table(string n, string fr)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT name, quantity, unit, price FROM {0} WHERE name LIKE '{1}%'"
                + "or name LIKE '%{1}%' or name LIKE '%{1}'", n, fr);
                Console.Out.WriteLine("Opening connection");
                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            string.Format("{0} - {1} {2}, price = {3}",
                            reader.GetString(0),
                            reader.GetInt16(1).ToString(),
                            reader.GetString(2),
                            reader.GetDouble(3).ToString()));
                    }
                }
            }
        }
        public List<string> Find_Division()
        {
            List<string> div_list = new List<string>();
            using (var conn = new NpgsqlConnection(connString))
            {   
                Console.Out.WriteLine("List of available divisions");
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT DISTINCT division FROM products",conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        div_list.Add(reader.GetString(0));
                    }
                }
            }
            return div_list;
        }
        public List<string> Find_Brigade(string div)
        {
            List<string> bryg_list = new List<string>();
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT DISTINCT brigade FROM products WHERE division = '{0}'",div);
                conn.Open();
                using (var command = new NpgsqlCommand(s,conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bryg_list.Add(reader.GetString(0));
                    }
                }
            }
            return bryg_list;
        }
        public List<string> Find_Battalion(string div, string bry)
        {
            List<string> batt_list = new List<string>();
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT DISTINCT battalion FROM products WHERE division = '{0}' AND brigade = '{1}'",div,bry);
                conn.Open();
                using (var command = new NpgsqlCommand(s,conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        batt_list.Add(reader.GetString(0));
                    }
                }
            }
            return batt_list;
        }
        public List<string> Find_Product(string div, string bry, string bat)
        {
            List<string> prod_list = new List<string>();
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT DISTINCT name FROM products WHERE division = '{0}' AND brigade = '{1}' AND battalion = '{2}'",div,bry, bat);
                conn.Open();
                using (var command = new NpgsqlCommand(s,conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        prod_list.Add(reader.GetString(0));
                    }
                }
            }
            return prod_list;
        }
        public string Find_Selected_Product(string div, string bry, string bat, string name)
        {
            string prod_uuid = "";
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT DISTINCT name, quantity, unit, price, product_uid FROM products WHERE division = '{0}' AND brigade = '{1}' AND battalion = '{2}' AND name = '{3}'",div,bry, bat,name);
                conn.Open();
                using (var command = new NpgsqlCommand(s,conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            string.Format("{0} - {1} {2}, price = {3}",
                            reader.GetString(0),
                            reader.GetInt16(1).ToString(),
                            reader.GetString(2),
                            reader.GetFloat(3).ToString()));
                        prod_uuid = reader.GetGuid(4).ToString();
                    }
                }
            }
            return prod_uuid;
        }
    }
}