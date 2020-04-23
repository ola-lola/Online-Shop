using System;
using Npgsql;
using System.Collections.Generic;

namespace Shop
{
    ///
    // Class Conncect_DB - is IDAO implementation class
    ///
    class Connect_DB : IDAO
    {
        string connString = new DbSettings().connString;

       public void Add_new_record(string t_name,string n,string div, string bry, string bat, int qua,string un,string st,float pr)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("INSERT INTO {0}(product_uid,name,division,brigade,battalion,quantity,unit,status, price) VALUES (uuid_generate_v4(),@n,@div,@bry,@bat,@qua,@un,@st,@pr)", t_name);
                Console.Out.WriteLine("Opening connection");
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
                    Console.Out.WriteLine(String.Format("Inserted {0} row",nRows));
                }
            }
        }

        public void ReadRecord()
        {
            //TODO - Agnieszka
        }


        public void UpdateRecord(int qua,float pr, string product_uid)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string toUpdate = String.Format("UPDATE products SET quantity = @qua, price = @pr WHERE product_uid = '{0}'", product_uid);
                Console.Out.WriteLine(toUpdate);
                conn.Open();
                using (var command = new NpgsqlCommand(toUpdate, conn))
                {
                    command.Parameters.AddWithValue("@qua", qua);
                    command.Parameters.AddWithValue("@pr", pr);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Product info updated",nRows));
                }
            }
        }
        

        public void DeleteRecord() {}
        public List<Product> ReadTable(string tableName , List<string> requiredColumns)
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
                            Console.Write("{0}\t{1} \n", reader[0], reader[1]);
                        }
                    }
                }
                conn.Close();
                
                // TODO: update method - Agnieszka 
                return new List<Product>();
            }
        }

    
        public void Display_Table(string n, string fr)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string s = String.Format("SELECT name, quantity, unit, price FROM {0} WHERE name LIKE '{1}'", n, fr);
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
    }
    
}