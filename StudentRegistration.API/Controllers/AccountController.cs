using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Business.Responses;
using StudentRegistration.Business.Services;
using BModel = StudentRegistration.Business.Models;
namespace StudentRegistration.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService acccountService = new AccountService();

        [HttpGet("GetUsers")]
        public async Task<ApiResponse<List<BModel.UserProfile>>> GetUsers()
        {
            var users = await AccountService.GetUserProfileAsync($"https://fake-json-api.mock.beeceptor.com/users");
            // Placeholder implementation
            return users;
        }
    }
}
