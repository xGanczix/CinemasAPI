using CinemasAPI.Models;
using CinemasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemasAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserClient client)
        {
            _accountService.RegisterUser(client);

            return Ok();
        }
    }
}
