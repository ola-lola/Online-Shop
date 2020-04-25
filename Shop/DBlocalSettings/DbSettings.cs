using System;

namespace Shop
{
    ///
    // DbSettings - class defining settings of the local Postgres server
    ///
    public class DbSettings
    {
        private static string Host = "127.0.0.1";
        private static string User = "ola";
        private static string DBname = "ola";
        private static string Password = "shop123";
        private static string Port = "5432";
        
        public static string connString = String.Format(
            "Server={0};Username={1};Database={2};Port={3};Password={4}",
            Host,User,DBname,Port,Password
        );


    }
}