using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class CoachEdit
    {
        public string CoachName { get; set; }
        public string SeasonRecord { get; set; }
        public string OverallRecord { get; set; }
        public string MarchMadnessRecord { get; set; }
        public int TeamId { get; set; }
    }
}
