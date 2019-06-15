using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WorkshopApp.Server.Models;

namespace WorkshopApp.Server.Repositories
{
    public class GithubRepository : IGithubRepository
    {
        private readonly HttpClient _client;

        public GithubRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<GithubUser> GetUser(string userName)
        {
            var response = await _client.GetAsync($"/users/{userName}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Parse<GithubUser>(json);
        }
    }
}
