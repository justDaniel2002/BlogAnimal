using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;
        private readonly Util util;
        public AccountController(AccountService accountService, Util util)
        {
            this.accountService = accountService;
            this.util = util;
        }

        [HttpGet("getAllAccount")]
        public async Task<IActionResult> getAllAccount()
        {
            var result = await accountService.getAll();

            return Ok(result);
        }

        [HttpPost("banAccount/{accountId}")]
        public async Task<IActionResult> banAccount(string accountId)
        {
            try
            {
                await accountService.banAccount(accountId);
                return StatusCode(StatusCodes.Status200OK);
            }catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
