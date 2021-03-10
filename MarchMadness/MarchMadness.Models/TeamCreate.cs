﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class TeamCreate
    {
        [Required]
        public string TeamName { get; set; }
        public int TeamSeed { get; set; }
    }
}
