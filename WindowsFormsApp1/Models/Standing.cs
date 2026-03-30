namespace FootballProject
{
    public class Standing
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }   // Вкарани голове
        public int GoalsAgainst { get; set; } // Допуснати голове

        // Изчисляеми свойства
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points => (Wins * 3) + (Draws * 1);

        // Формат за таблицата "Вкарани : Допуснати"
        public string GoalsDisplay => $"{GoalsFor} : {GoalsAgainst}";
    }
}