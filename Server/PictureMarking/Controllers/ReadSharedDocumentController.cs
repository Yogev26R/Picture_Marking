using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.SharedDocument;

namespace PictureMarking.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ReadSharedDocumentController : ControllerBase
    {
        IReadSharedDocumentService _readSharedDocumentService;

        public ReadSharedDocumentController(IReadSharedDocumentService readSharedDocumentService)
        {
            _readSharedDocumentService = readSharedDocumentService;
        }
        
        [HttpPost]
        public Response ReadSharedDocuments([FromBody] ReadSharedDocumentsRequest request)
        {
            return _readSharedDocumentService.ReadSharedDocuments(request);
        }
    }
}
