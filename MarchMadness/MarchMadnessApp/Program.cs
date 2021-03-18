using MarchMadness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            APIService service = new APIService();
            ProgramUI UI = new ProgramUI(service);

            UI.Run();
        }
    }
}
