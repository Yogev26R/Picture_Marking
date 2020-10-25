using Contracts.DTO;
using PictureMarkingContracts.DTO.SharedDocument;

namespace PictureMarkingContracts.Interface.SharedDocument
{
    public interface ICreateSharedDocumentService
    {
        Response CreateSharedDocument(CreateSharedDocumentRequest request);
    }
}
