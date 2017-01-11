using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Domain.Entities
{
    public class Player : Person
    {
        [Required(ErrorMessage = "Please enter a player number")]
        public int PlayerNumber { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DayBirth { get; set; }
        public string ImageUrl { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
