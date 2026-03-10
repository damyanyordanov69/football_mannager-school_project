using System;

namespace FootballProject
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}