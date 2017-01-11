using System;

namespace FootballManager.Models
{
    public class OutputView
    {
        public string TournamentName { get; set; }
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int GoalScored { get; set; }
        public int GoalMissed { get; set; }
        public int Points { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
        public string TeamImageUrl { get; set; }

    }
}