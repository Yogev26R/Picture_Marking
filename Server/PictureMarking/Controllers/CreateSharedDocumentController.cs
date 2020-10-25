using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.SharedDocument;
using PictureMarkingContracts.Interface.SharedDocument;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateSharedDocumentController : ControllerBase
    {
        ICreateSharedDocumentService _createSharedDocumentService;
        public CreateSharedDocumentController(ICreateSharedDocumentService createSharedDocumentService)
        {
            _createSharedDocumentService = createSharedDocumentService;
        }

        [HttpPost]
        public Response CreateSharedDocument([FromBody] CreateSharedDocumentRequest request)
        {
            return _createSharedDocumentService.CreateSharedDocument(request);
        }
    }
}
