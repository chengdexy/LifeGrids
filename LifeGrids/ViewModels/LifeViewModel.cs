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
        public DateTime Birthday { get; set; }
        public DateTime Deathday { get; set; }
        public int HopeAge { get; set; }
        public int DaysInLife { get; set; }

        public LifeViewModel(Life life)
        {
            ID = life.ID;
            Account = life.Account;
            Birthday = life.Birthday;
            Deathday = life.Deathday;
            HopeAge = Deathday.Year - Birthday.Year;
            DaysInLife = (Deathday - Birthday).Days;
        }
    }
}