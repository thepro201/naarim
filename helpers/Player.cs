using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBBA.helpers
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public string Icon { get; set; }
        public double PPG { get; set; }
        public double APG { get; set; }
        public double RPG { get; set; }
    }
}
