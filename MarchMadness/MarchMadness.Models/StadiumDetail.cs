using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Models
{
    public class StadiumDetail
    {
        public int StadiumId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public DateTimeOffset BuildDate { get; set; }

    }
}
