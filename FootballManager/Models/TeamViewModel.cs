using System.Collections.Generic;

namespace FootballManager.Models
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }
        public int? CoachId { get; set; }
        public string Name { get; set; }
        public List<ListViewModel> ModelStadium { get; set; }
    }
}