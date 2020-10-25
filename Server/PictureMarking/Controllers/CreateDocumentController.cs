using Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.Document;

namespace PictureMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateDocumentController : ControllerBase
    {
        ICreateDocumentService _createDocumentService;

        public CreateDocumentController(ICreateDocumentService createDocumentService)
        {
            _createDocumentService = createDocumentService;
        }

        [HttpPost]
        public Response CreateDocument([FromBody] CreateDocumentRequest request)
        {
            return _createDocumentService.CreateDocument(request);
        }
    }
}
