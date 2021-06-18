using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class Match
    {
        public int MatchId { get; set; }

        public bool Played { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Team Team2 { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

        public Match(Team team1, Team team2, Tournament tournament)
        {
            Team1Score = 0;
            Team2Score = 0;
            Played = false;
            Team1 = team1;
            Team2 = team2;
            Tournament = tournament;
        }

    }
}
