using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FootballProject
{
    public class LeaguesRepository
    {
        // ================= CRUD ЗА ЛИГИ =================
        public List<League> GetAllLeagues()
        {
            var leagues = new List<League>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT league_id, name, season FROM Leagues ORDER BY season DESC, name ASC";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        leagues.Add(new League
                        {
                            LeagueId = Convert.ToInt32(reader["league_id"]),
                            Name = reader["name"].ToString(),
                            Season = reader["season"].ToString()
                        });
                    }
                }
            }
            return leagues;
        }

        public void AddLeague(League league)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Leagues (name, season) VALUES (@name, @season)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", league.Name);
                    cmd.Parameters.AddWithValue("@season", league.Season);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLeague(League league)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Leagues SET name=@name, season=@season WHERE league_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", league.Name);
                    cmd.Parameters.AddWithValue("@season", league.Season);
                    cmd.Parameters.AddWithValue("@id", league.LeagueId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLeague(int id)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Leagues WHERE league_id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ================= УПРАВЛЕНИЕ НА УЧАСТНИЦИ =================

        // Взима отборите, които ВЕЧЕ са в тази лига
        public List<Team> GetParticipants(int leagueId)
        {
            var teams = new List<Team>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT t.team_id, t.name, t.city 
                               FROM Teams t
                               JOIN league_teams lt ON t.team_id = lt.team_id
                               WHERE lt.league_id = @lId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
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
            }
            return teams;
        }

        // Взима отборите, които са СВОБОДНИ (не са в тази лига)
        public List<Team> GetAvailableClubs(int leagueId)
        {
            var teams = new List<Team>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT team_id, name, city 
                               FROM Teams 
                               WHERE team_id NOT IN (SELECT team_id FROM league_teams WHERE league_id = @lId)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(new Team { TeamId = Convert.ToInt32(reader["team_id"]), Name = reader["name"].ToString() });
                        }
                    }
                }
            }
            return teams;
        }

        public void AddClubToLeague(int leagueId, int teamId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO league_teams (league_id, team_id) VALUES (@lId, @tId)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
                    cmd.Parameters.AddWithValue("@tId", teamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Премахване с БИЗНЕС ПРАВИЛО за оценка 6.00 (проверка за изиграни мачове)
        public void RemoveClubFromLeague(int leagueId, int teamId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                // Проверка: Има ли този отбор изиграни мачове?
                string checkSql = "SELECT COUNT(*) FROM Matches WHERE home_team_id = @tId OR away_team_id = @tId";
                using (var checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tId", teamId);
                    int matchCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (matchCount > 0)
                    {
                        throw new Exception("Този отбор има регистрирани мачове и не може да бъде премахнат от лигата!");
                    }
                }

                string sql = "DELETE FROM league_teams WHERE league_id = @lId AND team_id = @tId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
                    cmd.Parameters.AddWithValue("@tId", teamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}