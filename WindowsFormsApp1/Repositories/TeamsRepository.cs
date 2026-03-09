using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FootballProject
{
    public class TeamsRepository
    {
        public List<Team> GetAll()
        {
            var teams = new List<Team>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT team_id, name, city FROM Teams ORDER BY team_id";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new Team
                        {
                            TeamId = Convert.ToInt32(reader["team_id"]),
                            Name = reader["name"].ToString(),
                            City = reader["city"].ToString()
                        });
                    }
                }
            }
            return teams;
        }

        public void Add(Team team)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Teams (name, city) VALUES (@name, @city)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", team.Name);
                    cmd.Parameters.AddWithValue("@city", team.City);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Team team)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Teams SET name=@name, city=@city WHERE team_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", team.Name);
                    cmd.Parameters.AddWithValue("@city", team.City);
                    cmd.Parameters.AddWithValue("@id", team.TeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Teams WHERE team_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}