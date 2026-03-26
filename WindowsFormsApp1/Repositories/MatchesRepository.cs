using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FootballProject
{
    public class MatchesRepository
    {
        private LeaguesRepository _leaguesRepo = new LeaguesRepository();

        // 1. Взимане на мачовете за дадена лига
        public List<Match> GetMatches(int leagueId)
        {
            var matches = new List<Match>();
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT m.match_id, m.league_id, m.round_no, m.match_date,
                           m.home_team_id, th.name AS home_team_name,
                           m.away_team_id, ta.name AS away_team_name,
                           m.home_score, m.away_score
                    FROM Matches m
                    JOIN Teams th ON m.home_team_id = th.team_id
                    JOIN Teams ta ON m.away_team_id = ta.team_id
                    WHERE m.league_id = @lId
                    ORDER BY m.round_no ASC, m.match_date ASC";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matches.Add(new Match
                            {
                                MatchId = Convert.ToInt32(reader["match_id"]),
                                LeagueId = Convert.ToInt32(reader["league_id"]),
                                RoundNo = Convert.ToInt32(reader["round_no"]),
                                HomeTeamId = Convert.ToInt32(reader["home_team_id"]),
                                HomeTeamName = reader["home_team_name"].ToString(),
                                AwayTeamId = Convert.ToInt32(reader["away_team_id"]),
                                AwayTeamName = reader["away_team_name"].ToString(),
                                HomeScore = reader["home_score"] != DBNull.Value ? Convert.ToInt32(reader["home_score"]) : (int?)null,
                                AwayScore = reader["away_score"] != DBNull.Value ? Convert.ToInt32(reader["away_score"]) : (int?)null,
                                MatchDate = Convert.ToDateTime(reader["match_date"])
                            });
                        }
                    }
                }
            }
            return matches;
        }

        // 2. Проверка дали вече има програма
        public bool HasSchedule(int leagueId)
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Matches WHERE league_id = @lId";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lId", leagueId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // 3. АВТОМАТИЧНО ГЕНЕРИРАНЕ НА ПРОГРАМА (АЛГОРИТЪМ)
        public void GenerateSchedule(int leagueId, bool isDoubleRoundRobin)
        {
            if (HasSchedule(leagueId))
                throw new Exception("Програмата за тази лига вече е генерирана!");

            var teams = _leaguesRepo.GetParticipants(leagueId);
            if (teams.Count < 2)
                throw new Exception("Трябват поне 2 отбора за генериране на програма!");

            // Ако отборите са нечетен брой, добавяме фиктивен "Почиващ" отбор (ID = -1)
            if (teams.Count % 2 != 0)
                teams.Add(new Team { TeamId = -1, Name = "Почива" });

            int totalTeams = teams.Count;
            int totalRounds = totalTeams - 1;
            int matchesPerRound = totalTeams / 2;

            DateTime startDate = DateTime.Today.AddDays(7); // Започваме след 1 седмица

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO Matches (league_id, round_no, home_team_id, away_team_id, match_date) VALUES (@lId, @rnd, @home, @away, @date)";

                        // Завъртаме 1 път (или 2 пъти за разменено гостуване)
                        int loops = isDoubleRoundRobin ? 2 : 1;

                        for (int loop = 0; loop < loops; loop++)
                        {
                            for (int round = 0; round < totalRounds; round++)
                            {
                                int currentRoundNo = round + 1 + (loop * totalRounds);
                                DateTime roundDate = startDate.AddDays(currentRoundNo * 7); // Всеки кръг е през 7 дни

                                for (int match = 0; match < matchesPerRound; match++)
                                {
                                    int homeIdx = (round + match) % (totalTeams - 1);
                                    int awayIdx = (totalTeams - 1 - match + round) % (totalTeams - 1);

                                    if (match == 0) awayIdx = totalTeams - 1;

                                    Team homeTeam = teams[homeIdx];
                                    Team awayTeam = teams[awayIdx];

                                    // Разменяме домакинството през кръг за баланс
                                    if (match == 0 && round % 2 == 1)
                                    {
                                        Team temp = homeTeam; homeTeam = awayTeam; awayTeam = temp;
                                    }

                                    // Ако сме във второто завъртане (пролетен полусезон), обръщаме всички домакинства
                                    if (loop == 1)
                                    {
                                        Team temp = homeTeam; homeTeam = awayTeam; awayTeam = temp;
                                    }

                                    // Записваме мача, само ако никой не играе с фиктивния "Почиващ" отбор
                                    if (homeTeam.TeamId != -1 && awayTeam.TeamId != -1)
                                    {
                                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                                        {
                                            cmd.Parameters.AddWithValue("@lId", leagueId);
                                            cmd.Parameters.AddWithValue("@rnd", currentRoundNo);
                                            cmd.Parameters.AddWithValue("@home", homeTeam.TeamId);
                                            cmd.Parameters.AddWithValue("@away", awayTeam.TeamId);
                                            cmd.Parameters.AddWithValue("@date", roundDate);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}