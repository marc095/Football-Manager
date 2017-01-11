using FootballManager.Domain.Concrete;
using FootballManager.Domain.Entities;
using FootballManager.Models;
using System.Linq;
using System.Web.Mvc;
namespace FootballManager.Controllers
{
    public class CoachController : Controller
    {
        CoachRepository repository = new CoachRepository();
        TeamRepository teamRepository = new TeamRepository();
        // GET: Coach
        public ActionResult Index()
        {
            return View(repository.Entities);
        }

        public ActionResult Edit(int id)
        {
            Coach coach = repository.Entities.FirstOrDefault(c => c.Id == id);
            CoachViewModel coachVM = Mappers.Mapping.Map(coach);
            ViewData["AllTeams"] = from team in teamRepository.Entities
                                   select new SelectListItem { Text = team.Name, Value = team.Id.ToString() };
            return View(coachVM);
        }

        [HttpPost]
        public ActionResult Edit(CoachViewModel coach)
        {
            Coach coach1 = Mappers.Mapping.Map(coach);
            repository.Save(coach1);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewData["AllTeams"] = from team in teamRepository.Entities
                                   select new SelectListItem { Text = team.Name, Value = team.Id.ToString() };
            return View("Edit", new CoachViewModel());
        }

        public ActionResult Delete(int? id)
        {
            Coach coach = repository.Entities.FirstOrDefault(c => c.Id == id);
            return View(coach);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}