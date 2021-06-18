using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV168_Project.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int GameNumber { get; set; }

        public virtual Team Team { get; set; }
    }
}
