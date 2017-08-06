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
    public class GridsController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Grids
        public ActionResult Index()
        {
            if (!(Session.Count > 0) || !((bool)Session["UserLoggedIn"] == true))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string account = Session["Account"].ToString();
                LifeHelper lh = new LifeHelper(db);
                Life life = lh.GetLifeByAccount(account);
                LifeViewModel lvm = new LifeViewModel(life);
                return View(lvm);
            }
        }
    }
}