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



            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.GetAsync("https://localhost:44342/api/Team/1/").Result;

           

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Team team = response.Content.ReadAsAsync<Team>().Result;

            HttpResponseMessage teamResponse = httpClient.GetAsync(team.TeamName).Result;

            if (playerResponse.IsSuccessStatusCode)
            {
                Player player = playerResponse.Content.ReadAsAsync<Player>().Result;

                Console.WriteLine($"\n\n{team.TeamName} is {team.Height}cm tall and has {team.Eye_Color} eyes. {team.Name} is from the {planet.Climate} world of {planet.Name}.");
            }
            else
            {
                Console.WriteLine($"\n\n{person.Name} is {person.Height}cm tall and has {person.Eye_Color} eyes.");
            }
        }
    }
}
