using MarchMadness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarchMadnessApp
{
    public class APIService
    {
        private HttpClient _client;

        public APIService()
        {
            _client = new HttpClient();
        }

        public async Task<Team> GetTeamAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44342/api/Team/{id}/");

            if (response.IsSuccessStatusCode)
            {
                Team team = await response.Content.ReadAsAsync<Team>();
                return team;
            }

            return null;
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44342/api/Player/{id}/");
            if (response.IsSuccessStatusCode)
            {
                Player player = await response.Content.ReadAsAsync<Player>();
                return player;
            }

            return null;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }

        public async Task<SearchResult<T>> SearchAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }
            return default;
        }

        public async Task<SearchResult<Team>> SearchTeamAsync(string query)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44342/api/Team/?search={query}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<Team>>();
            }

            return new SearchResult<Team>();
        }

        public async Task<SearchResult<T>> SearchAsync<T>(string table, string query)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44342/api/{table}/?search={query}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }

            return new SearchResult<T>();
        }

        public async Task<SearchResult<Coach>> SearchCoachAsync(string query)
        {
            return await SearchAsync<Coach>("coaches", query);
        }

        public async Task<SearchResult<Player>> SearchPlayerAsync(string query)
        {
            return await SearchAsync<Player>("players", query);
        }
    }
}
