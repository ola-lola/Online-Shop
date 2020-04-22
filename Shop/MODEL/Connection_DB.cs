using System;
using Npgsql;
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
    }
    
}