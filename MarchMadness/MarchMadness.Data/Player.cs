using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public int SeasonRebounds { get; set; }

        public int SeasonAssists { get; set; }

        [Required]
        public int SeasonTotalPoints { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
