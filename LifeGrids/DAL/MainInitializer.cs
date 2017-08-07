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
            var Lifes = new List<Life>
            {
                new Life{
                    Account="chengdexy",
                    Password="darkmoon1",
                    Birthday=new DateTime(1986,2,13),
                    Deathday=new DateTime(2066,2,13),
                    Grids=new List<Grid>{
                        new Grid
                        {
                            Year=2017,
                            Month=8,
                            Day=7,
                            Things=new List<Thing>
                            {
                                new Thing
                                {
                                    Hour=15,
                                    Minute=0,
                                    Second=0,
                                    Html="This is Today."
                                }
                            }
                        }
                    }
                }
            };
            Lifes.ForEach(L => context.Lifes.Add(L));
            context.SaveChanges();
        }
    }
}