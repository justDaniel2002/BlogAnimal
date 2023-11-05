using BlogAnimalApi.DTO;
using BlogAnimalApi.DTO.requestDTO;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

/*        private string ToCsv(IEnumerable<AccountDTO> data)
        {
            var sb = new StringBuilder();

            // Thêm tiêu đề cột (nếu cần)
            sb.AppendLine("Property1,Property2,Property3");

            foreach (var item in data)
            {
                // Tùy chỉnh cách chuyển đổi dữ liệu theo nhu cầu của bạn.
                // Đây là một ví dụ đơn giản; bạn có thể cần phải điều chỉnh nó cho cấu trúc dữ liệu cụ thể của bạn.
                sb.AppendLine($"{item.AccountId},{item.Email},{item.Property3}");
            }

            return sb.ToString();
        }*/

        [HttpGet("getAllAccount")]
        public async Task<IActionResult> getAllAccount()
        {
            var result = await accountService.getAll();
            
            return Ok(result);
        }

        [HttpGet("getAccountById/{id}")]
        public async Task<IActionResult> getAccountById(string id)
        {
            var result = await accountService.getAccountById(id);

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

        public class checkPassModel{
            public string password { get; set; }
        }
        [HttpPost("checkPassword/{accountId}")]
        public async Task<IActionResult> checkPassword(string accountId, checkPassModel CKM)
        {
            var result = await accountService.checkPassword(accountId, util.hashPassword(CKM.password));

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> editAccount(AccountDTO accountDTO)
        {
            try
            {
                await accountService.editAccount(accountDTO);

                return StatusCode(StatusCodes.Status200OK);
            }catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        public class editPassModel
        {
            public string oldpassword { get; set; }
            public string newpassword { get; set; }
        }

        [HttpPut("editpassword/{accountId}")]
        public async Task<IActionResult> editPassword(string accountId, editPassModel EPM)
        {
            try
            {
                string result = await accountService.editPassword(accountId, util.hashPassword(EPM.oldpassword), EPM.newpassword);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
