using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.Models
{
    public class Life
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Deathday { get; set; }
        public virtual List<Grid> Grids { get; set; }
    }
}