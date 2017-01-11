namespace FootballManager.Domain.Migrations
{
    using Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FootballManager.Domain.Concrete.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FootballManager.Domain.Concrete.EFContext context)
        {
            Coach coah1 = new Coach()
            {
                Id = 1,
                Age = 46,
                Name = "Luis",
                Surname = "Enrique",
                TeamId = 1
            };
            Coach coah2 = new Coach()
            {
                Id = 2,
                Age = 44,
                Name = "Zinedine",
                Surname = "Zidane",
                TeamId = 2
            };

            Team team1 = new Team()
            {
                Id = 1,
                Name = "Barcelona",
                Coach = coah1,
                ImageUrl = "/Content/img/barcelona.jpg",
                LaligaAmountOfGames = 16,
                LaligaPoints = 34,
                LaligaMissingGoals = 16,
                LaligaScoredGoals = 41,
                LaligaWins = 10,
                LaligaDraws = 4,
                LaligaDefeats = 2,
                UEFAAmountOfGames = 6,
                UEFAWins = 5,
                UEFADefeats = 1,
                UEFADraws = 0,
                UEFAPoints = 15,
                UEFAScoredGoals = 20,
                UEFAMissingGoals = 4
            };
            Team team2 = new Team()
            {
                Id = 2,
                Name = "Real Madrid",
                Coach = coah2,
                ImageUrl = "/Content/img/realmadrid.jpg",
                UEFAPoints = 12,
                UEFAWins = 3,
                UEFADraws = 3,
                UEFAAmountOfGames = 6,
                UEFADefeats = 0,
                UEFAMissingGoals = 10,
                UEFAScoredGoals = 16,
                LaligaAmountOfGames = 15,
                LaligaWins = 11,
                LaligaDraws = 4,
                LaligaDefeats = 0,
                LaligaPoints = 37,
                LaligaScoredGoals = 40,
                LaligaMissingGoals = 14
            };
            context.Coaches.Add(coah1);
            context.Coaches.Add(coah2);
            context.Teams.Add(team1);
            context.Teams.Add(team2);

            Player player = new Player()
            {
                Id = 1,
                Age = 29,
                Name = "Lionel",
                Surname = "Messi",
                PlayerNumber = 10,
                TeamId = 1,
                ImageUrl = "/Content/img/messi.jpg",
                Country = "Argentina",
                DayBirth = new System.DateTime(1987 / 06 / 24)
            };
            Player player1 = new Player()
            {
                Id = 2,
                Age = 31,
                Name = "Cristiano",
                Surname = "Ronaldo",
                PlayerNumber = 7,
                TeamId = 2,
                ImageUrl = "/Content/img/ronaldo.jpg",
                Country = "Portugal",
                DayBirth = new System.DateTime(1985 / 02 / 05)
            };
            context.Players.Add(player);
            context.Players.Add(player1);

            FStadium stadium = new FStadium()
            {
                Id = 1,
                Capacity = 99.353,
                Name = "Camp Nou"
            };
            FStadium stadium1 = new FStadium()
            {
                Id = 2,
                Capacity = 85.454,
                Name = "Santiago Bernabeu"
            };
            context.FStadiums.Add(stadium);
            context.FStadiums.Add(stadium1);

            Tournament tournament = new Tournament()
            {
                Id = 1,
                Name = "La liga",
                StartDate = new System.DateTime(2016 / 08 / 15),
                EndDate = new System.DateTime(2017 / 05 / 27),
                ImageUrl = "/Content/img/LaLiga.png"
            };
            Tournament tournament1 = new Tournament()
            {
                Id = 2,
                Name = "UEFA Champions",
                StartDate = new System.DateTime(2016 / 09 / 22),
                EndDate = new System.DateTime(2017 / 05 / 30),
                ImageUrl = "/Content/img/uefa.png"
            };

            context.Tournaments.Add(tournament);
            context.Tournaments.Add(tournament1);
        }
    }
}
