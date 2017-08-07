using LifeGrids.DAL;
using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.ClassHelpers
{
    public class LifeHelper
    {
        private MainContext _db;

        public LifeHelper(MainContext db)
        {
            _db = db;
        }

        public Life GetLifeByAccount(string account)
        {
            MainContext mc = _db;
            Life resultLife = mc.Lifes.Where(l => l.Account == account).FirstOrDefault();
            if (resultLife != null)
            {
                return resultLife;
            }
            else
            {
                throw new Exception($"Account {account} is not exist!");
            }
        }

        public Grid GetGridByDate(DateTime date, Life life)
        {
            MainContext mc = _db;
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            Grid resultGrid = life.Grids.Where(g => g.Year == year && g.Month == month && g.Day == day).FirstOrDefault();
            if (resultGrid != null)
            {
                return resultGrid;
            }
            else
            {
                return new Grid
                {
                    Year = date.Year,
                    Month = date.Month,
                    Day = date.Day,
                    Things = null
                };
            }
        }
    }
}