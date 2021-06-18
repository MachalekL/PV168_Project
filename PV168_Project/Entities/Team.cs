using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Team(string name)
        {
            Name = name;
        }


    }
}
