namespace FootballManager.Models
{
    public class CoachViewModel
    {
        public int CoachId { get; set; }
        public int? TeamId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}