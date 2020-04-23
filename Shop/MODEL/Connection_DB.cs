using System;
using Npgsql;
using System.Collections.Generic;
namespace Shop
{
    class Connect_DB
    {
        private static string Host = "127.0.0.1";
        private static string User = "postgres";
        private static string DBname = "fmcgshop";
        private static string Password = "trenchnap2019";
        private static string Port = "5432";
        
        string connString = String.Format(
            "Server={0};Username={1};Database={2};Port={3};Password={4}",
            Host,User,DBname,Port,Password
        );

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