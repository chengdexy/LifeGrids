using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeGrids.Models
{
    public class Thing
    {
        public enum ThingState
        {
            Doing=1,
            Done=2,
            Stop=3
        }

        public int ID { get; set; }
        public int GridID { get; set; }

        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public ThingState State { get; set; }
        public DateTime? StopTime { get; set; }
    }
}