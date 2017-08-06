using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LifeGrids.DAL
{
    public class MainInitializer : DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            var Lifes = new List<Life>();
            Life newLife = new Life();
            newLife.Account = "chengdexy";
            newLife.Password = "darkmoon1";
            newLife.Name = "Xue Yuan";
            newLife.Sex = "Man";
            newLife.Brithday = new DateTime(1986, 2, 13);
            newLife.HopeAge = 80;
            int daysInLife = (newLife.Brithday.AddYears(80) - newLife.Brithday).Days;
            Grid[] gridArray = new Grid[daysInLife];
            for (int i = 0; i < daysInLife; i++)
            {
                DateTime date = newLife.Brithday.AddDays(i);
                gridArray[i] = new Grid
                {
                    Year = date.Year,
                    Month = date.Month,
                    Day = date.Day,
                    Things = new List<Thing>
                    {
                        new Thing
                        {
                            Hour=0,
                            Minute=0,
                            Second=0,
                            Html="hahahaha"
                        }
                    }
                };
            }
            newLife.Grids = gridArray.ToList<Grid>();
            Lifes.Add(newLife);
            Lifes.ForEach(L => context.Lifes.Add(L));
            context.SaveChanges();
        }
    }
}