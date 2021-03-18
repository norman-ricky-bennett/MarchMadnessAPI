using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadness.Data
{

    public class SearchResult<T>
    {
        public int Count { get; set; } = 0;
        public List<T> Results { get; set; } = new List<T>();
    }

}
