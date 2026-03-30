using System;

namespace FootballProject
{
    public class MatchEvent
    {
        public int EventId { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } // Име на играча за таблицата
        public int TeamId { get; set; }
        public string TeamName { get; set; }   // Име на отбора за таблицата
        public int Minute { get; set; }
        public string EventType { get; set; }  // Гол, Жълт картон, Червен картон или Фал
    }
}