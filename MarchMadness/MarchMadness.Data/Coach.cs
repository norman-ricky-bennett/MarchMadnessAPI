﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Data
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; }
        [Required]
        public string CoachName { get; set; }
        [Required]
        public int SeasonRecord { get; set; }
        [Required]
        public int OverallRecord { get; set; }
        [Required]
        public int MarchMadnessRecord { get; set; }
    }
}
