using Contracts.DTO;

namespace PictureMarkingContracts.DTO.Document
{
    public class ReadDocumentsResponse : Response
    {
        public ReadDocumentsRequest Request { get; }
        public ReadDocumentsResponse(ReadDocumentsRequest request)
        {
            Request = request;
        }
    }
}
