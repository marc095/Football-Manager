using FootballManager.Domain.Concrete;
using FootballManager.Domain.Entities;
using FootballManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace FootballManager.Controllers
{
    public class TeamController : Controller
    {
        private TeamRepository repository = new TeamRepository();
        private CoachRepository coachRepo = new CoachRepository();
        private StadiumRepository stadiums = new StadiumRepository();
        private StadiumTeamRepository stadiumTeamRepo = new StadiumTeamRepository();
        // GET: Team
        public ActionResult Index()
        {
            return View(repository.Entities);
        }

        public ActionResult Edit(int id)
        {
            Team team = this.repository.Entities.FirstOrDefault(t => t.Id == id);
            var Result = from stadium in stadiums.Entities.ToList()
                         select new
                         {
                             stadium.Id,
                             stadium.Name,
                             Checked = (from st in stadiumTeamRepo.Entities.ToList()
                                        where (st.TeamId == id) && (st.FStadiumId == stadium.Id)
                                        select st).Count() > 0
                         };
            TeamViewModel teamVM = new TeamViewModel();
            teamVM.TeamId = id;
            teamVM.Name = team.Name;
            teamVM.CoachId = team.CoachId;
            var myList = new List<ListViewModel>();
            foreach (var item in Result)
            {
                myList.Add(new ListViewModel { Id = item.Id, Name = item.Name, Checked = item.Checked });
            }
            teamVM.ModelStadium = myList;
            ViewData["AllCoaches"] = from coach in coachRepo.Entities
                                     select new SelectListItem { Text = coach.Name + " " + coach.Surname, Value = coach.Id.ToString() };
            return View(teamVM);
        }

        [HttpPost]
        public ActionResult Edit(TeamViewModel teamVM)
        {
            Team team = this.repository.Entities.FirstOrDefault(t => t.Id == teamVM.TeamId);
            team.Name = teamVM.Name;
            team.CoachId = team.CoachId;
            foreach (var item in stadiumTeamRepo.Entities)
            {
                if (item.TeamId == team.Id)
                {
                    this.stadiumTeamRepo.ChangeState(item);
                }
            }

            foreach (var item in teamVM.ModelStadium)
            {
                if (item.Checked)
                {
                    this.stadiumTeamRepo.Add(new StadiumTeam { FStadiumId = item.Id, TeamId = team.Id });
                }
            }
            stadiumTeamRepo.Save();
            return RedirectToAction("Index");
        }

    }
}