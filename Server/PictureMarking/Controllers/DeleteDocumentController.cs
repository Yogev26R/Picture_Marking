using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.Document;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteDocumentController : ControllerBase
    {
        IDeleteDocumentService _deleteDocumentService;

        public DeleteDocumentController(IDeleteDocumentService deleteDocumentService)
        {
            _deleteDocumentService = deleteDocumentService;
        }

        [HttpPost]
        public Response DeleteDocument([FromBody] DeleteDocumentRequest request)
        {
            return _deleteDocumentService.DeleteDocument(request);
        }
    }
}
