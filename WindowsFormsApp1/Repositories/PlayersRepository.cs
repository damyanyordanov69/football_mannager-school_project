using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FootballProject
{
    public class PlayersRepository
    {
        public List<Player> GetPlayers(int? teamId = null, string position = null, string nameFilter = null)
        {
            var players = new List<Player>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT p.player_id, p.first_name, p.last_name, p.birth_date, p.position, p.team_id, t.name AS team_name 
                               FROM Players p 
                               JOIN Teams t ON p.team_id = t.team_id 
                               WHERE 1=1 ";

                if (teamId.HasValue && teamId.Value > 0) sql += " AND p.team_id = @teamId ";
                if (!string.IsNullOrEmpty(position) && position != "Всички") sql += " AND p.position = @position ";
                if (!string.IsNullOrWhiteSpace(nameFilter)) sql += " AND (p.first_name LIKE @name OR p.last_name LIKE @name) ";

                sql += " ORDER BY p.player_id";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (teamId.HasValue && teamId.Value > 0) cmd.Parameters.AddWithValue("@teamId", teamId.Value);
                    if (!string.IsNullOrEmpty(position) && position != "Всички") cmd.Parameters.AddWithValue("@position", position);
                    if (!string.IsNullOrWhiteSpace(nameFilter)) cmd.Parameters.AddWithValue("@name", "%" + nameFilter + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            players.Add(new Player
                            {
                                PlayerId = Convert.ToInt32(reader["player_id"]),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["birth_date"]),
                                Position = reader["position"].ToString(),
                                TeamId = Convert.ToInt32(reader["team_id"]),
                                TeamName = reader["team_name"].ToString()
                            });
                        }
                    }
                }
            }
            return players;
        }

        public void Add(Player player)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Players (first_name, last_name, birth_date, position, team_id) VALUES (@fname, @lname, @bdate, @pos, @tid)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fname", player.FirstName);
                    cmd.Parameters.AddWithValue("@lname", player.LastName);
                    cmd.Parameters.AddWithValue("@bdate", player.BirthDate);
                    cmd.Parameters.AddWithValue("@pos", player.Position);
                    cmd.Parameters.AddWithValue("@tid", player.TeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Player player)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Players SET first_name=@fname, last_name=@lname, birth_date=@bdate, position=@pos, team_id=@tid WHERE player_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fname", player.FirstName);
                    cmd.Parameters.AddWithValue("@lname", player.LastName);
                    cmd.Parameters.AddWithValue("@bdate", player.BirthDate);
                    cmd.Parameters.AddWithValue("@pos", player.Position);
                    cmd.Parameters.AddWithValue("@tid", player.TeamId);
                    cmd.Parameters.AddWithValue("@id", player.PlayerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int playerId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Players WHERE player_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", playerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}