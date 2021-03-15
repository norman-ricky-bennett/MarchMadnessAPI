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
        public int SeasonRecord { get; set; }
        public int OverallRecord { get; set; }
        public int MarchMadnessRecord { get; set; }
    }
}
