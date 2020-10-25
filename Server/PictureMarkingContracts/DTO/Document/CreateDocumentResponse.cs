using Contracts.DTO;

namespace PictureMarkingContracts.DTO.Document
{
    public class CreateDocumentResponse : Response
    {
        public CreateDocumentRequest Request { get; }

        public CreateDocumentResponse(CreateDocumentRequest request)
        {
            Request = request;
        }
    }
}
