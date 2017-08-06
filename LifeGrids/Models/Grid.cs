using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.Models
{
    public class Grid
    {
        public int ID { get; set; }
        public int LifeID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public virtual List<Thing> Things { get; set; }
    }
}