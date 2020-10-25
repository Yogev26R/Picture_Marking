using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public Response Register([FromBody] RegisterRequest request)
        {
            return _registerService.Register(request);
        }
    }
}
