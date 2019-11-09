using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLS_CRUD.Models
{
    public class Team
    {
        public int? TeamID { get; set; }
        public string TeamName { get; set; }
        public string Conference { get; set; }
        public int? GamesPlayed { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public int? Draws { get; set; }
        public int? GoalsFor { get; set; }
        public int? GoalsAgainst { get; set; }
        public int? GoalDifference { get; set; }
        public int? Points { get; set; }
    }
}
