using FootballManager.Domain.Entities;
using FootballManager.Models;

namespace FootballManager.Mappers
{
    public static class Mapping
    {
        public static PlayerViewModel Map(Player player)
        {
            return new PlayerViewModel() { PlayerId = player.Id, Age = player.Age, PlayerName = player.Name, Surname = player.Surname, PlayerNumber = player.PlayerNumber, TeamId = player.TeamId, ImageUrl = player.ImageUrl, DayBirth = player.DayBirth, Country = player.Country };
        }
        public static Player Map(PlayerViewModel playerVM)
        {
            return new Player() { Id = playerVM.PlayerId, Age = playerVM.Age, Name = playerVM.PlayerName, PlayerNumber = playerVM.PlayerNumber, Surname = playerVM.Surname, TeamId = playerVM.TeamId, ImageUrl = playerVM.ImageUrl, DayBirth = playerVM.DayBirth, Country = playerVM.Country };
        }
        public static CoachViewModel Map(Coach coach)
        {
            return new CoachViewModel() { CoachId = coach.Id, Age = coach.Age, Name = coach.Name, Surname = coach.Surname, TeamId = coach.TeamId };
        }
        public static Coach Map(CoachViewModel coach)
        {
            return new Coach() { Id = coach.CoachId, TeamId = coach.TeamId, Surname = coach.Surname, Name = coach.Name, Age = coach.Age };
        }

        public static FStadium Map(StadiumViewModel stadium)
        {
            return new FStadium() { Id = stadium.StadiumId, Capacity = stadium.Capacity, Name = stadium.Name };
        }

        public static StadiumViewModel Map(FStadium stadium)
        {
            return new StadiumViewModel() { StadiumId = stadium.Id, Name = stadium.Name, Capacity = stadium.Capacity };
        }
    }
}