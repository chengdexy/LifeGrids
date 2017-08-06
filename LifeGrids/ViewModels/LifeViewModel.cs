using LifeGrids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.ViewModels
{
    public class LifeViewModel
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Brithday { get; set; }
        public DateTime Deathday { get; set; }
        public int HopeAge { get; set; }
        public int DaysInLife { get; set; }

        public LifeViewModel(Life life)
        {
            ID = life.ID;
            Account = life.Account;
            Name = life.Name;
            Sex = life.Sex;
            HopeAge = life.HopeAge;
            Brithday = life.Brithday;
            Deathday = Brithday.AddYears(HopeAge).AddDays(1);
            DaysInLife = (Deathday - Brithday).Days;
        }
    }
}