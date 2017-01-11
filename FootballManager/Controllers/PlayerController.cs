using FootballManager.Domain.Concrete;
using FootballManager.Domain.Entities;
using FootballManager.Mappers;
using FootballManager.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FootballManager.Controllers
{
    public class PlayerController : Controller
    {
        private PlayerRepository repository = new PlayerRepository();
        private TeamRepository teamRepository = new TeamRepository();

        //
        // GET: /Player/

        public ActionResult Index(string searchString)
        {
            //var players = from p in repository.Entities
            //              select p;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    players = players.Where(s => s.Name.Contains(searchString));
            //}

            return View(repository.Entities);
        }

        public ActionResult PlayerSearch(string playerName)
        {
            var players = this.repository.Entities;
            if (!String.IsNullOrEmpty(playerName))
            {

                players = players.Where(p => p.Team.Name.Contains(playerName));
            }
            //return PartialView("PlayerSearch", players.ToList());
            return View("Index", players.ToList());
        }

        public ActionResult Edit(int id)
        {
            Player player = this.repository.Entities.FirstOrDefault(p => p.Id == id);
            PlayerViewModel playerModel = Mapping.Map(player);
            ViewData["AllTeams"] = from team in teamRepository.Entities
                                   select new SelectListItem { Text = team.Name, Value = team.Id.ToString() };
            return View(playerModel);
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel player)
        {
            var savePlayer = Mapping.Map(player);
            repository.Save(savePlayer);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewData["AllTeams"] = from team in teamRepository.Entities
                                   select new SelectListItem { Text = team.Name, Value = team.Id.ToString() };
            return View("Edit", new PlayerViewModel());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) { Response.Write("Null id!"); return RedirectToAction("Index"); }
            Player player = repository.Entities.FirstOrDefault(p => p.Id == id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}