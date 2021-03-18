using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class CoachCreate
    {
        [Required]
        public string CoachName { get; set; }
        [Required]
        public string SeasonRecord { get; set; }
        [Required]
        public string OverallRecord { get; set; }
        [Required]
        public string MarchMadnessRecord { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
