using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.DTO.User;

namespace PictureMarkingContracts.Interface.Document
{
    public interface IUpdateDocumentService
    {
        public Response UpdateDocument(UpdateDocumentRequest request);
    }
}
