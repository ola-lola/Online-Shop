using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Shop
{
    ///
    // Class Conncect_DB - is IDAO implementation class
    ///
    public class ConnectDB : IDAOcrud
    {
        private static string connString = DbSettings.connString;

        public void AddProduct(string t_name, Product product)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("INSERT INTO {0}(product_uid,name,division,brigade,battalion,quantity,unit,status, price) VALUES (uuid_generate_v4(),@n,@div,@bry,@bat,@qua,@un,@st,@pr)", t_name);

                conn.Open();
                using (var command = new NpgsqlCommand(s, conn))
                {
                    command.Parameters.AddWithValue("@n", product.Name);
                    command.Parameters.AddWithValue("@div", product.Division1);
                    command.Parameters.AddWithValue("@bry", product.Brigade2);
                    command.Parameters.AddWithValue("@bat", product.Battalion3);
                    command.Parameters.AddWithValue("@qua", product.Quantity);
                    command.Parameters.AddWithValue("@un", product.Unit);
                    command.Parameters.AddWithValue("@st", product.Status);
                    command.Parameters.AddWithValue("@pr", product.PricePerUnit);
                    int nRows = command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Out.WriteLine(String.Format("\nInserted {0} row",nRows));
                    Console.ResetColor();
                }
            }
        }


        public void UpdateProductName(string product_uid, string name)
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

        public void UpdateProductQuantity(string product_uid, int quantity)
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

        public void UpdateProductPrice(string product_uid, float price)
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


        public void DeleteProduct(string product_uid)
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
            string[] allColumnNames = Enum.GetNames(typeof(ProductsTableColumns));
            
            // Create SQL query string
            var columns = String.Join(", ", requiredColumns);

            var pressedKey = ConsoleKey.Spacebar;
            int offset = 0;
            while(pressedKey == ConsoleKey.Spacebar || pressedKey == ConsoleKey.LeftArrow) {

                string SQLquery = $"SELECT {columns} FROM {tableName} LIMIT 10 OFFSET {offset}";

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
                            // FIXME: Move printing to View!!! - Agnieszka
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            System.Console.WriteLine("Table name: " + tableName);
                            Console.ResetColor();
                            string separator = new String('*', Console.LargestWindowWidth);
                            Console.WriteLine("\n"+separator);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            foreach (string column in requiredColumns) {
                                System.Console.Write($"{column, 25}\t");
                            }
                            Console.ResetColor();
                            System.Console.Write("\n");
                            Console.WriteLine(separator);
                            while (reader.Read()) {
                                // TODO: add option in this method to choose columns to display or add writing data to List<Products>
                                foreach (string columnName in allColumnNames.Intersect(requiredColumns))
                                {
                                    System.Console.Write($"{reader[columnName], 25}\t");
                                }
                                System.Console.Write("\n");
                            }
                        }
                    }
                    conn.Close();
                    
                    // TODO: update method - Agnieszka 
                    // return new List<Product>();
                }
                
                pressedKey = Console.ReadKey().Key;
                if (pressedKey == ConsoleKey.LeftArrow) {offset -= 10; if (offset < 0) {offset = 0;}}
                if (pressedKey == ConsoleKey.Spacebar) {offset += 10;}
            }
        }


        // OTHER METHODS
        public List<string> GetTableNamesFromDb() {

            List<string> tables = new List<string>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                DataTable dataTable = conn.GetSchema("Tables");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Per info:
                        // string dbName = (string)row[0];
                        // string tableAccessibilityPublicPrivate = (string)row[1];
                        
                        string tableName = (string)row[2];
                        tables.Add(tableName);
                    }

                conn.Close();
            }
            return tables;
        }
        
        public List<string> GetColumnNamesFromTable(string tableName) {
            
            List<string> columns = new List<string>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"SELECT * FROM {tableName}", conn))
                {
                    var reader = command.ExecuteReader();
                    // while (reader.Read())
                    // {
                        for (int i = 0; i < reader.FieldCount; i++) {
                            // Console.WriteLine(reader.GetName(i));
                            columns.Add(reader.GetName(i));
                        }
                    // }
                }
                conn.Close();
            }
            return columns;
        }
        
        public void SearchInTable(string n, string fr)
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
        
        // FIND METHODS
        public List<string> Find_Division()
        {
            List<string> div_list = new List<string>();
            using (var conn = new NpgsqlConnection(connString))
            {   
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