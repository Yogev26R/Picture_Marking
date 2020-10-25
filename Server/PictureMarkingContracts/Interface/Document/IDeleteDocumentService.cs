using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;

namespace PictureMarkingContracts.Interface.Document
{
    public interface IDeleteDocumentService
    {
        public Response DeleteDocument(DeleteDocumentRequest request);
    }
}
