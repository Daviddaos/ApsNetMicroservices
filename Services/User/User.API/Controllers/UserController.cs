using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.API.Controllers
{
    using User.API.Entities;
    using User.API.Repositories;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IUserRepository> _logger;

        public UserController(IUserRepository userRepository, ILogger<IUserRepository> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet("{filter}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByFiler(string filter)
        {
            _logger.LogInformation($"Get users filter: { filter }");

            var users = await _userRepository.GetUsersByFilter(filter);

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddUser(User user)
        {
            _logger.LogInformation($"Add user: { user }");

            await _userRepository.AddUser(user);

            return Created("", user);
        }
    }
}
