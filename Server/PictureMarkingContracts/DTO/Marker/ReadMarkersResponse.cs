using Contracts.DTO;

namespace PictureMarkingContracts.DTO.Marker
{
    public class ReadMarkersResponse : Response
    {
        public ReadMarkersRequest Request { get; set; }
        public ReadMarkersResponse(ReadMarkersRequest request)
        {
            Request = request;
        }
    }
}
