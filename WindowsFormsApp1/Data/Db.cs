using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace FootballProject // Смени с твоето име на проекта, ако е различно
{
    public static class Db
    {
        public static MySqlConnection GetConnection()
        {
            // Взимаме настройките
            var config = ConfigurationManager.ConnectionStrings["FootballDb"];

            // Проверяваме дали въобще съществуват, за да не гърми с TypeInitializationException
            if (config == null)
            {
                throw new Exception("Грешка: Не мога да намеря 'FootballDb' в App.config. Проверете дали файлът е валиден!");
            }

            return new MySqlConnection(config.ConnectionString);
        }
    }
}