using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.ViewModels
{
    public class GridViewModel
    {
        public int yearCount { get; set; }
        public int monthCount { get; set; }
        public int weekCount { get; set; }
        public int dayCount { get; set; }
        public int fromToday { get; set; } //距离今天有几天,正数代表过去,负数代表未来
        public DateTime thisDay { get; set; }
        public List<Thing> things { get; set; }

        public GridViewModel(Life life, Grid grid)
        {
            yearCount = grid.Year - life.Birthday.Year+1;
            monthCount = yearCount * 12 + (grid.Month - life.Birthday.Month)+1;
            thisDay = new DateTime(grid.Year, grid.Month, grid.Day);
            dayCount = (thisDay - life.Birthday).Days+1;
            weekCount = dayCount % 7 == 0 ? dayCount / 7 : dayCount / 7 + 1;
            fromToday = (DateTime.Now - thisDay).Days;
            things = grid.Things;
        }
    }
}