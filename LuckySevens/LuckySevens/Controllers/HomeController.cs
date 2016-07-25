using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuckySevens.Models;
using LuckySevens.Models.WorkFlows;

namespace LuckySevens.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LuckySevensMVC()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LuckySevensMVC(decimal amount)
        {
            var player = new Player() {StartingBet = amount};

            var gameWF = new GameWorkFlow();
            gameWF.PlayGame(player);

            return View("Results", player);
        }

        public ActionResult LuckySevensJS()
        {
            return View();
        }
    }
}