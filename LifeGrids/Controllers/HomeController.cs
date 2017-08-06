using LifeGrids.DAL;
using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeGrids.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!(Session.Count > 0) || !((bool)Session["UserLoggedIn"] == true))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Grids");
            }
        }


    }
}