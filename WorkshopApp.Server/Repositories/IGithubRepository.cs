using System.Threading.Tasks;
using WorkshopApp.Server.Models;

namespace WorkshopApp.Server.Repositories
{
    public interface IGithubRepository
    {
        Task<GithubUser> GetUser(string userName);
    }
}
