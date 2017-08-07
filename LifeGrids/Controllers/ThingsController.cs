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
        public ActionResult Index(int ID)
        {
            if (!(Session.Count > 0) || !((bool)Session["UserLoggedIn"] == true))
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

        public string AddNewThing(DateTime date)
        {
            return date.ToString();
        }
    }
}