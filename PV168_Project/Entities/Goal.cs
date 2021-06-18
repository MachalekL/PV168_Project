using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class Goal
    {
        public int GoalId { get; set; }

        public virtual Player Player { get; set; }

        public virtual Match Match { get; set; }

        public Goal(Player player, Match match)
        {
            Player = player;
            Match = match;
        }

    }
}
