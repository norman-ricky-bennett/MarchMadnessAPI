using MarchMadness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarchMadnessApp
{
    public class ProgramUI
    {
        private APIService _service;
        public ProgramUI(APIService service)
        {
            _service = service;
        }

        public void Run()
        {
            
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to look up?\n" +
                    "1. Team\n" +
                    "2. Player\n" +
                    "3. Coach\n" +
                    "4. Stadium\n" +
                    "5. Teams\n" +
                    "6. Search People\n" +
                    "7. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetTeam();
                        break;
                    case "2":
                        GetPlayer();
                        break;
                    case "3":
                        GetCoach();
                        break;
                    case "4":
                        GetStadium();
                        break;
                    case "5":
                        SearchTeams();
                        break;
                    case "6":
                        SearchPlayers();
                        break;
                    case "7":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void GetTeam()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the Team you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Team team = _service.GetAsync<Team>($"https://localhost:44342/api/Team/{id}").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{team.TeamName} is a {team.TeamSeed}seed team and is currently being led by coach {team.Coachname_Id}");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public void GetPlayer()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the player you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Player player = _service.GetAsync<Player>($"https://localhost:44342/api/Player/{id}").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{player.Name} is a {player.Position} with a total of {player.SeasonTotalPoints} points, {player.SeasonRebounds} rebounds, and {player.SeasonAssists} asists this season");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public void GetCoach()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the coach you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Coach coach = _service.GetAsync<Coach>($"https://localhost:44342/api/Coach/{id}").Result;
            Console.Clear();

            if (coach == default)
            {
                Console.WriteLine("This coach does not exist. Press any key to continue . . .");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\n\n{coach.CoachName} is an NCAA coach with an overall record of {coach.OverallRecord} wins.");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public void GetStadium()
        {
            Console.Clear();
            Console.WriteLine("What is the ID of the Stadium you want to see?");
            string id = Console.ReadLine();

            Console.WriteLine("Loading...");
            Thread.Sleep(50);
            Stadium stadium = _service.GetAsync<Stadium>($"https://localhost:44342/api/Stadium/{id}").Result;
            Console.Clear();

            Console.WriteLine($"\n\n{stadium.Name} stadium is a located in {stadium.Location}, and it can hold a total of {stadium.Capacity} fans at once. This stadium was built in {stadium.BuildDate}.");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        public void SearchTeams()
        {
            Console.Clear();
            Console.WriteLine("What team are you searching for?");
            string query = Console.ReadLine();

            SearchResult<Team> results = _service.SearchTeamAsync(query).Result;
            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach (Team team in results.Results)
            {
                Console.WriteLine($"{team.TeamName} - seed {team.TeamSeed}, current coach: {team.Coachname_Id}");
            }

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
        
        public void SearchPlayers()
        {
            Console.Clear();
            Console.WriteLine("What name are you searching for?");
            string query = Console.ReadLine();

            SearchResult<Player> results = _service.SearchPlayerAsync(query).Result;
            Console.Clear();
            Console.WriteLine($"Found {results.Count} results\n");

            foreach (Player player in results.Results)
            {
                Console.WriteLine($"{player.Name} - {player.Position}, {player.SeasonTotalPoints} total season points");
            }

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
        }
        
    }
}
