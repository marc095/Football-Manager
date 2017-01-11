namespace FootballManager.Domain.Entities
{
    public class Coach : Person
    {
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
