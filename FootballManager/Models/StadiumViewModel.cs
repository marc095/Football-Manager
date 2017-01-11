namespace FootballManager.Models
{
    public class StadiumViewModel
    {
        public int StadiumId { get; set; }
        public int? TeamId { get; set; }

        public double Capacity { get; set; }
        public string Name { get; set; }
    }
}