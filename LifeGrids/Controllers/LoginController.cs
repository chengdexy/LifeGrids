using LifeGrids.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeGrids.Controllers
{
    public class LoginController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Login
        public ActionResult Index()
        {
            if (!(Session.Count > 0) || !((bool)Session["UserLoggedIn"] == true))
            {
                //未登录
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Grids");
            }

        }

        //POST: Login
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string account = fc["txtAccount"];
            string password = fc["txtPassword"];
            if (db.Lifes.Where(l => l.Account == account && l.Password == password).Count() > 0)
            {
                //匹配
                Session.Add("UserLoggedIn", true);
                Session.Add("Account", account);
                Session.Add("Password", password);
                return RedirectToAction("Index", "Grids");
            }
            else
            {
                return View("Index");
            }
        }
    }
}