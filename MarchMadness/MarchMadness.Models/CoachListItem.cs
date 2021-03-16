using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class CoachListItem
    {
        public int CoachID { get; set; }
        public string CoachName { get; set; }
        public string SeasonRecord { get; set; }
        public string OverallRecord { get; set; }
        public string MarchMadnessRecord { get; set; }
    }
}
