using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public Response Login([FromBody] LoginRequest request)
        {
            return _loginService.Login(request);
        }
    }
}
