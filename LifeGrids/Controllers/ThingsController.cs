using LifeGrids.ClassHelpers;
using LifeGrids.DAL;
using LifeGrids.Models;
using LifeGrids.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeGrids.Controllers
{
    public class ThingsController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Things
        public ActionResult Index(int ID = -1)
        {
            if (!(Session.Count > 0) || !((bool)Session["UserLoggedIn"] == true) || ID == -1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                LifeHelper lh = new LifeHelper(db);
                Life thisLife = lh.GetLifeByAccount(Session["Account"].ToString());
                int dayNumber = ID;
                DateTime thisDay = thisLife.Birthday.AddDays(dayNumber);
                Grid thisGrid = lh.GetGridByDate(thisDay, thisLife);
                GridViewModel gvm = new GridViewModel(thisLife, thisGrid);
                return View(gvm);
            }

        }

        // GET: AddNewThing
        public ActionResult AddNewThing(int ID, DateTime Date)
        {
            ViewBag.ID = ID;
            ViewBag.Date = Date;
            return View();
        }

        // POST: AddNewThing
        [HttpPost]
        public ActionResult AddNewThing(FormCollection fc)
        {
            int id = Convert.ToInt32(fc["txtIdHidden"]);
            string temp = fc["txtDateHidden"];
            DateTime date = Convert.ToDateTime(temp);
            string content = fc["taContent"];
            Thing newThing = new Thing
            {
                Content = content,
                CreateTime = DateTime.Now,
                State = Thing.ThingState.Doing,
                StopTime = null
            };
            LifeHelper lh = new LifeHelper(db);
            Life life = lh.GetLifeByAccount(Session["Account"].ToString());
            Grid thisGrid = lh.GetGridByDate(date, life);
            thisGrid.Things = new List<Thing>();
            thisGrid.Things.Add(newThing);
            life.Grids.Add(thisGrid);
            db.SaveChanges();
            return RedirectToAction("Index", new { ID = id });
        }
    }
}