using FootballManager.Domain.Concrete;
using FootballManager.Models;
using System.Linq;
using System.Web.Mvc;
namespace FootballManager.Controllers
{
    public class TournamentController : Controller
    {
        EFContext context = new EFContext();
        TournamentViewModel tournamentVM = new TournamentViewModel();
        // GET: Tournament
        public ActionResult Index(string sortOrder)
        {
            tournamentVM.LaLigaModels = new System.Collections.Generic.List<OutputView>();
            tournamentVM.UEFAModels = new System.Collections.Generic.List<OutputView>();

            var resultLaliga = from t in context.Teams
                               from p in t.Tournaments
                               select new
                               {
                                   Name = p.Name,
                                   TeamName = t.Name,
                                   StartDate = p.StartDate,
                                   EndDate = p.EndDate,
                                   Image = p.ImageUrl,
                                   TeamImage = t.ImageUrl,
                                   Points = t.LaligaPoints,
                                   Wins = t.LaligaWins,
                                   Loses = t.LaligaDefeats,
                                   Draws = t.LaligaDraws,
                                   GoalScrd = t.LaligaScoredGoals,
                                   GoalMsd = t.LaligaMissingGoals,
                                   Played = t.LaligaAmountOfGames
                               };

            var laLiga = resultLaliga.Where(s => s.Name == "La liga").Select(s => new
            {
                s.Name,
                s.TeamName,
                s.StartDate,
                s.EndDate,
                Image = s.Image,
                TeamImage = s.TeamImage,
                Points = s.Points,
                Wins = s.Wins,
                Loses = s.Loses,
                Draws = s.Draws,
                GoalScrd = s.GoalScrd,
                GoalMsd = s.GoalMsd,
                Played = s.Played
            }).ToList();

            foreach (var item in laLiga)
            {
                tournamentVM.LaLigaModels.Add(new OutputView
                {
                    TeamName = item.TeamName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    TournamentName = item.Name,
                    ImageUrl = item.Image,
                    TeamImageUrl = item.TeamImage,
                    Points = item.Points,
                    Wins = item.Wins,
                    Loses = item.Loses,
                    Draws = item.Draws,
                    GoalScored = item.GoalScrd,
                    GoalMissed = item.GoalMsd,
                    Played = item.Played
                });
            }



            var resultUefa = from t in context.Teams
                             from p in t.Tournaments
                             select new
                             {
                                 Name = p.Name,
                                 TeamName = t.Name,
                                 StartDate = p.StartDate,
                                 EndDate = p.EndDate,
                                 Image = p.ImageUrl,
                                 TeamImage = t.ImageUrl,
                                 Points = t.UEFAPoints,
                                 Wins = t.UEFAWins,
                                 Loses = t.UEFADefeats,
                                 Draws = t.UEFADraws,
                                 GoalScrd = t.UEFAScoredGoals,
                                 GoalMsd = t.UEFAMissingGoals,
                                 Played = t.UEFAAmountOfGames
                             };
            var uefa = resultUefa.Where(s => s.Name == "UEFA Champions").Select(s => new
            {
                s.Name,
                s.TeamName,
                s.StartDate,
                s.EndDate,
                Image = s.Image,
                TeamImage = s.TeamImage,
                Points = s.Points,
                Wins = s.Wins,
                Loses = s.Loses,
                Draws = s.Draws,
                GoalScrd = s.GoalScrd,
                GoalMsd = s.GoalMsd,
                Played = s.Played
            }).ToList();
            foreach (var item in uefa)
            {
                tournamentVM.UEFAModels.Add(new OutputView
                {
                    TeamName = item.TeamName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    TournamentName = item.Name,
                    ImageUrl = item.Image,
                    TeamImageUrl = item.TeamImage,
                    Points = item.Points,
                    Wins = item.Wins,
                    Loses = item.Loses,
                    Draws = item.Draws,
                    GoalScored = item.GoalScrd,
                    GoalMissed = item.GoalMsd,
                    Played = item.Played
                });
            }
            ViewBag.SortParm = string.IsNullOrEmpty(sortOrder) ? "points_asc" : "";
            switch (sortOrder)
            {
                case "points_asc":
                    tournamentVM.LaLigaModels = tournamentVM.LaLigaModels.OrderBy(l => l.Points).ToList();
                    break;

                default:
                    tournamentVM.LaLigaModels = tournamentVM.LaLigaModels.OrderByDescending(l => l.Points).ToList();
                    break;
            }
            return View(tournamentVM);
        }
    }
}