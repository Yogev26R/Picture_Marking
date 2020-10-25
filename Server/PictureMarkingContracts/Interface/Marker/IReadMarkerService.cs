using Contracts.DTO;
using PictureMarkingContracts.DTO.Marker;

namespace PictureMarkingContracts.Interface.Marker
{
    public interface IReadMarkerService
    {
        public Response ReadMarkers(ReadMarkersRequest request);
    }
}
