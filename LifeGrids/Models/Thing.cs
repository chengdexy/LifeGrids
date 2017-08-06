using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.Models
{
    public class Thing
    {
        public int ID { get; set; }
        public int GridID { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public string Html { get; set; }
    }
}