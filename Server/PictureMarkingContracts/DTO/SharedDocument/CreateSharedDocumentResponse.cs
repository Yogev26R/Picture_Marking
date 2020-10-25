using Contracts.DTO;

namespace PictureMarkingContracts.DTO.SharedDocument
{
    public class CreateSharedDocumentResponse : Response
    {
        public CreateSharedDocumentRequest Request { get; }

        public CreateSharedDocumentResponse(CreateSharedDocumentRequest request)
        {
            Request = request;
        }
    }
}