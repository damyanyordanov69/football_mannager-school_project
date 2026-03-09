using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace FootballProject
{
    public static class Db
    {
        public static MySqlConnection GetConnection()
        {
            var config = ConfigurationManager.ConnectionStrings["FootballDb"];
            if (config == null)
            {
                throw new Exception("Грешка: Не мога да намеря 'FootballDb' в App.config.");
            }
            return new MySqlConnection(config.ConnectionString);
        }
    }
}