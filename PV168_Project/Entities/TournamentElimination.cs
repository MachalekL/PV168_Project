using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class TournamentElimination : Tournament
    {
        public virtual Match Quarterfinal1 { get; set; }
        public virtual Match Quarterfinal2 { get; set; }
        public virtual Match Quarterfinal3 { get; set; }
        public virtual Match Quarterfinal4 { get; set; }

        public virtual Match Semifinal1 { get; set; }

        public virtual Match Semifinal2 { get; set; }

        public virtual Match Final { get; set; }


        public TournamentElimination(string name, ICollection<Team> participatingTeams) : base(name, participatingTeams)
        {
        }

        public bool CanPlayMatch(Team team1, Team team2)
        {
            if(ContainsAnyMatchOfTeam(team1) || ContainsAnyMatchOfTeam(team2))
            {
                return false;
            }
            return true;
        }
    }
}
