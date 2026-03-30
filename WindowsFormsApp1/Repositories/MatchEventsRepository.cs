using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace FootballProject
{
    public class MatchEventsRepository
    {
        // 1. Взимаме всички събития за конкретен мач (подредени по минута)
        public List<MatchEvent> GetEventsForMatch(int matchId)
        {
            var events = new List<MatchEvent>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT e.event_id, e.match_id, e.player_id, e.team_id, e.minute, e.event_type,
                           CONCAT(p.first_name, ' ', p.last_name) AS player_name,
                           t.name AS team_name
                    FROM MatchEvents e
                    JOIN Players p ON e.player_id = p.player_id
                    JOIN Teams t ON e.team_id = t.team_id
                    WHERE e.match_id = @mId
                    ORDER BY e.minute ASC";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mId", matchId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new MatchEvent
                            {
                                EventId = Convert.ToInt32(reader["event_id"]),
                                MatchId = Convert.ToInt32(reader["match_id"]),
                                PlayerId = Convert.ToInt32(reader["player_id"]),
                                TeamId = Convert.ToInt32(reader["team_id"]),
                                Minute = Convert.ToInt32(reader["minute"]),
                                EventType = reader["event_type"].ToString(),
                                PlayerName = reader["player_name"].ToString(),
                                TeamName = reader["team_name"].ToString()
                            });
                        }
                    }
                }
            }
            return events;
        }

        // 2. Взимаме играчите САМО от двата отбора, които играят в мача (За падащото меню)
        public List<Player> GetPlayersForMatch(int homeTeamId, int awayTeamId)
        {
            var players = new List<Player>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                // Показваме името на играча и отбора му в скоби (напр. "Иван Иванов (Левски)")
                string sql = @"
                    SELECT p.player_id, p.first_name, p.last_name, p.team_id, t.name AS team_name 
                    FROM Players p 
                    JOIN Teams t ON p.team_id = t.team_id 
                    WHERE p.team_id IN (@homeId, @awayId)
                    ORDER BY t.name, p.first_name";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@homeId", homeTeamId);
                    cmd.Parameters.AddWithValue("@awayId", awayTeamId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            players.Add(new Player
                            {
                                PlayerId = Convert.ToInt32(reader["player_id"]),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                TeamId = Convert.ToInt32(reader["team_id"]),
                                TeamName = reader["team_name"].ToString()
                            });
                        }
                    }
                }
            }
            return players;
        }

        // 3. Добавяне на събитие
        public void AddEvent(MatchEvent matchEvent)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO MatchEvents (match_id, player_id, team_id, minute, event_type) VALUES (@mId, @pId, @tId, @min, @type)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mId", matchEvent.MatchId);
                    cmd.Parameters.AddWithValue("@pId", matchEvent.PlayerId);
                    cmd.Parameters.AddWithValue("@tId", matchEvent.TeamId);
                    cmd.Parameters.AddWithValue("@min", matchEvent.Minute);
                    cmd.Parameters.AddWithValue("@type", matchEvent.EventType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Изтриване на събитие
        public void DeleteEvent(int eventId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM MatchEvents WHERE event_id = @eId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@eId", eventId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. БОНУС ФУНКЦИЯ: Автоматично изчисляване на резултата на база вкараните голове!
        public void AutoCalculateScore(int matchId, int homeTeamId, int awayTeamId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                // Взимаме броя голове за домакина
                string sqlHome = "SELECT COUNT(*) FROM MatchEvents WHERE match_id = @mId AND team_id = @hId AND event_type = 'Гол'";
                int homeGoals = 0;
                using (var cmdH = new MySqlCommand(sqlHome, conn))
                {
                    cmdH.Parameters.AddWithValue("@mId", matchId);
                    cmdH.Parameters.AddWithValue("@hId", homeTeamId);
                    homeGoals = Convert.ToInt32(cmdH.ExecuteScalar());
                }

                // Взимаме броя голове за госта
                string sqlAway = "SELECT COUNT(*) FROM MatchEvents WHERE match_id = @mId AND team_id = @aId AND event_type = 'Гол'";
                int awayGoals = 0;
                using (var cmdA = new MySqlCommand(sqlAway, conn))
                {
                    cmdA.Parameters.AddWithValue("@mId", matchId);
                    cmdA.Parameters.AddWithValue("@aId", awayTeamId);
                    awayGoals = Convert.ToInt32(cmdA.ExecuteScalar());
                }

                // Обновяваме резултата в таблица Matches
                string sqlUpdate = "UPDATE Matches SET home_score = @hScore, away_score = @aScore WHERE match_id = @mId";
                using (var cmdUpd = new MySqlCommand(sqlUpdate, conn))
                {
                    cmdUpd.Parameters.AddWithValue("@hScore", homeGoals);
                    cmdUpd.Parameters.AddWithValue("@aScore", awayGoals);
                    cmdUpd.Parameters.AddWithValue("@mId", matchId);
                    cmdUpd.ExecuteNonQuery();
                }
            }
        }
    }
}