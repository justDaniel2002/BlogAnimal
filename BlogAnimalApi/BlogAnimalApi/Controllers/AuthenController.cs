using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAnimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly AccountService accountService;
        public AuthenController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDTO dto)
        {
            var result = await accountService.SignIn(dto.Email, dto.Password);

            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(Account account)
        {
            try
            {
               await accountService.SignUp(account);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }
    }
}
