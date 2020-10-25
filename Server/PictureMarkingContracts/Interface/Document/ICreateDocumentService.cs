using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;

namespace PictureMarkingContracts.Interface.Document
{
    public interface ICreateDocumentService
    {
        public Response CreateDocument(CreateDocumentRequest request);
    }
}
