using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System.Collections.Generic;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnSubscribeController : ControllerBase
    {
        IUnSubscribeService _unSubscribeService;

        public UnSubscribeController(IUnSubscribeService unSubscribeService)
        {
            _unSubscribeService = unSubscribeService;
        }

        [HttpPost]
        public Response UnSubscribe([FromBody] UnSubscribeRequest request)
        {
            return _unSubscribeService.UnSubscribe(request);
        }

    }
}
