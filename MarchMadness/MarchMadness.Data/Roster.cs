using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Data
{
    public class Roster
    {
        [Key]
        public int RosterId { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        [ForeignKey(nameof(Player))]
        [Required]
        public int PlayerId { get; set; }

    }
}
