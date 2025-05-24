using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBBA.helpers
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Points { get; set; }
        public string Icon { get; set; }
        public string City { get; set; }
    }
    public class Game
    {
        public int Round { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public string Venue { get; set; }
    }

}