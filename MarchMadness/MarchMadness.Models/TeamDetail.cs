using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamSeed { get; set; }
        public List<PlayerListItem> Players { get; set; }
        public List<CoachListItem> Coach { get; set; }
    }
}
