using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp.Server.Repositories;
using WorkshopApp.Shared.Models;

namespace WorkshopApp.Server.Controllers
{
    [ApiController]
    [Route("api/github")]
    public class GithubController : ControllerBase
    {
        private readonly IGithubRepository _repository;

        public GithubController(IGithubRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserInfo>> Get(string username)
        {
            var data = await _repository.GetUser(username);

            return new UserInfo
            {
                FullName = data.FullName,
                AvatarUrl = data.AvatarUrl,
                Url = data.Url
            };
        }
    }
}
