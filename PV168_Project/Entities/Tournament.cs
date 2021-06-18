using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> ParticipatingTeams { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        public Tournament(string name, ICollection<Team> participatingTeams)
        {
            ParticipatingTeams = participatingTeams;
            Name = name;
        }

        public bool ContainsAnyMatchOfTeam(Team team)
        {
            foreach(Match match in Matches)
            {
                if(match.Team1 == team || match.Team2 == team)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsMatchOfTeams(Team team1, Team team2)
        {
            foreach (Match match in Matches)
            {
                if ((match.Team1 == team1 && match.Team2 == team2) || (match.Team1 == team2 && match.Team2 == team1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
