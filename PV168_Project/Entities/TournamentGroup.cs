using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class TournamentGroup : Tournament
    {

        public 




        public TournamentGroup(string name, ICollection<Team> participatingTeams) : base(name, participatingTeams)
        {
        }

        public bool CanPlayMatch(Team team1, Team team2)
        {
            return !ContainsMatchOfTeams(team1, team2);
        }
    }
}
