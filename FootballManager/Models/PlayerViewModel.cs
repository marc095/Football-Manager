using System;

namespace FootballManager.Models
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerNumber { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public int Age { get; set; }
        public DateTime DayBirth { get; set; }
        public string Country { get; set; }
        public int? TeamId { get; set; }
    }
}