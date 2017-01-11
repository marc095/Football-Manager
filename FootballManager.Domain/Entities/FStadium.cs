using System.Collections.Generic;

namespace FootballManager.Domain.Entities
{
    public class FStadium
    {
        public FStadium()
        {
            this.StadiumTeams = new List<StadiumTeam>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public virtual List<StadiumTeam> StadiumTeams { get; set; }
    }
}
