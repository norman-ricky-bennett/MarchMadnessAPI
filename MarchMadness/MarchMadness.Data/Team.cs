using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int TeamSeed { get; set; }
        [Required]
        public int Coachname_Id { get; set; }
        [Required]
        public int Stadium_Id { get; set; }
        [Required]
        public int Game_Id { get; set; }
       

    }
}
