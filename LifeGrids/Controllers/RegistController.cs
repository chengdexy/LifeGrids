using LifeGrids.DAL;
using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeGrids.Controllers
{
    public class RegistController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Regist
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

        // POST: Regist
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string account = fc["txtAccount"];
            string password = fc["txtPassword"];
            string passwordRE = fc["txtPassword_re"];

            string name = fc["txtName"];
            string sex = fc["txtSex"];
            DateTime birthday = Convert.ToDateTime(fc["txtBirthday"]);
            int hopeAge = Convert.ToInt32(fc["txtHopeAge"]);

            if (password == passwordRE)
            {
                Life life = new Life
                {
                    Account = account,
                    Password = password,
                    Name = name,
                    Sex = sex,
                    Brithday = birthday,
                    HopeAge = hopeAge
                };
                db.Lifes.Add(life);
                db.SaveChanges();
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