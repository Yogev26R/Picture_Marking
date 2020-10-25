using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.Marker;
using PictureMarkingContracts.Interface.Marker;

namespace PictureMarking.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ReadMarkerController : ControllerBase
    {
        IReadMarkerService _readMarkerService;
        public ReadMarkerController(IReadMarkerService readMarkerService)
        {
            _readMarkerService = readMarkerService;
        }

        [HttpPost]
        public Response ReadMarkers([FromBody] ReadMarkersRequest request)
        {
            return _readMarkerService.ReadMarkers(request);
        }
    }
}
