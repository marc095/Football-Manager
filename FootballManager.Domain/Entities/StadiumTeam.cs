namespace FootballManager.Domain.Entities
{
    public class StadiumTeam
    {
        public int Id { get; set; }
        public int FStadiumId { get; set; }
        public int TeamId { get; set; }
        public virtual FStadium FStadium { get; set; }
        public virtual Team Team { get; set; }
    }
}
