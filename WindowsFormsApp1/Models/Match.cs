using System;

namespace FootballProject
{
    public class Match
    {
        public int MatchId { get; set; }
        public int LeagueId { get; set; }
        public int RoundNo { get; set; } // Кръг (1, 2, 3...)

        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; } // За визуализация

        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; } // За визуализация

        public int? HomeScore { get; set; } // Може да е празно, ако не е игран
        public int? AwayScore { get; set; }

        public DateTime MatchDate { get; set; }

        public string Stadium { get; set; }
    }
}