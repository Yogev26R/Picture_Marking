using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.DTO.User;

namespace PictureMarkingContracts.Interface.Document
{
    public interface IReadDocumentService
    {
        public Response ReadDocument(string documentID);
        public Response ReadDocuments(ReadDocumentsRequest request);
    }
}
