using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class PlayerCreate
    {
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public int SeasonRebounds { get; set; }
        public int SeasonAssists { get; set; }
        public int SeasonTotalPoints { get; set; }
    }
}
