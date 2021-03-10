using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }
        public int SeasonRebounds { get; set; }
        public int SeasonAssists { get; set; }
        public int SeasonTotalPoints { get; set; }
    }
}
