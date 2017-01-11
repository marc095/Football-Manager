using System.Collections.Generic;

namespace FootballManager.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
            this.StadiumTeams = new List<StadiumTeam>();
            this.Tournaments = new List<Tournament>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int LaligaWins { get; set; }
        public int LaligaDraws { get; set; }
        public int LaligaDefeats { get; set; }
        public int LaligaAmountOfGames { get; set; }
        public int LaligaScoredGoals { get; set; }
        public int LaligaMissingGoals { get; set; }
        public int LaligaPoints { get; set; }
        public int UEFAWins { get; set; }
        public int UEFADraws { get; set; }
        public int UEFADefeats { get; set; }
        public int UEFAAmountOfGames { get; set; }
        public int UEFAScoredGoals { get; set; }
        public int UEFAMissingGoals { get; set; }
        public int UEFAPoints { get; set; }
        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        public int? PlayerId { get; set; }
        public virtual List<Player> Players { get; set; }
        public virtual List<StadiumTeam> StadiumTeams { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
    }
}
