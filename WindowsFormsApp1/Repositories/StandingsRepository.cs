using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballProject
{
    public class StandingsRepository
    {
        private LeaguesRepository _leaguesRepo = new LeaguesRepository();
        private MatchesRepository _matchesRepo = new MatchesRepository();

        public List<Standing> GetStandings(int leagueId)
        {
            // 1. Взимаме всички отбори, които участват в тази лига
            var teams = _leaguesRepo.GetParticipants(leagueId);
            var standings = teams.Select(t => new Standing
            {
                TeamId = t.TeamId,
                TeamName = t.Name
            }).ToList();

            // 2. Взимаме всички мачове за лигата, които имат резултат
            var matches = _matchesRepo.GetMatches(leagueId)
                .Where(m => m.HomeScore.HasValue && m.AwayScore.HasValue)
                .ToList();

            // 3. Алгоритъм за изчисляване на статистиката
            foreach (var m in matches)
            {
                var homeEntry = standings.First(s => s.TeamId == m.HomeTeamId);
                var awayEntry = standings.First(s => s.TeamId == m.AwayTeamId);

                homeEntry.Played++;
                awayEntry.Played++;
                homeEntry.GoalsFor += m.HomeScore.Value;
                homeEntry.GoalsAgainst += m.AwayScore.Value;
                awayEntry.GoalsFor += m.AwayScore.Value;
                awayEntry.GoalsAgainst += m.HomeScore.Value;

                if (m.HomeScore > m.AwayScore) // Победа за домакина
                {
                    homeEntry.Wins++;
                    awayEntry.Losses++;
                }
                else if (m.HomeScore < m.AwayScore) // Победа за госта
                {
                    awayEntry.Wins++;
                    homeEntry.Losses++;
                }
                else // Равенство
                {
                    homeEntry.Draws++;
                    awayEntry.Draws++;
                }
            }

            // 4. Сортиране по критериите на учителя (Точки -> Голова разлика -> Вкарани голове)
            return standings
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.GoalDifference)
                .ThenByDescending(s => s.GoalsFor)
                .ToList();
        }
    }
}