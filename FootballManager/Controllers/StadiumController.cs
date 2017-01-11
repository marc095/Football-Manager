using FootballManager.Domain.Concrete;
using FootballManager.Domain.Entities;
using FootballManager.Models;
using System.Linq;
using System.Web.Mvc;

namespace FootballManager.Controllers
{
    public class StadiumController : Controller
    {
        StadiumRepository repository = new StadiumRepository();
        TeamRepository teamRepository = new TeamRepository();
        // GET: Stadium
        public ActionResult Index()
        {
            return View(this.repository.Entities);
        }

        public ActionResult Edit(int id)
        {
            FStadium stadium = this.repository.Entities.FirstOrDefault(p => p.Id == id);
            StadiumViewModel stadiumVM = Mappers.Mapping.Map(stadium);

            return View(stadiumVM);
        }
        [HttpPost]
        public ActionResult Edit(StadiumViewModel stadiumVM)
        {
            FStadium stadium = Mappers.Mapping.Map(stadiumVM);
            this.repository.Save(stadium);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View("Edit", new StadiumViewModel());
        }
        public ActionResult Delete(int? id)
        {
            FStadium stadium = this.repository.Entities.FirstOrDefault(s => s.Id == id);
            return View(stadium);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}