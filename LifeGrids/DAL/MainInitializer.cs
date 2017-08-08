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
                                    CreateTime=new DateTime(2017,8,7,15,0,0),
                                    Content="This is Today.",
                                    State=Thing.ThingState.Doing,
                                    StopTime=null
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