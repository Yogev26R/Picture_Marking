using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.Document;

namespace PictureMarking.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ReadDocumentController : ControllerBase
    {
        IReadDocumentService _readDocumentService;

        public ReadDocumentController(IReadDocumentService readDocumentService)
        {
            _readDocumentService = readDocumentService;
        }

        [HttpPost]
        public Response ReadDocuments([FromBody] ReadDocumentsRequest request)
        {
            return _readDocumentService.ReadDocuments(request);
        }
    }
}
