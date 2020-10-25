using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Marker;
using PictureMarkingContracts.Interface;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.Marker;
using System;

namespace CreateMarkerService
{
    [Register(Policy.Transient, typeof(ICreateMarkerService))]
    public class CreateMarkerServiceImpl : ICreateMarkerService
    {
        IMarkerDAL _dal;
        IIDGeneratorService _idGeneratorService;
        public CreateMarkerServiceImpl(IMarkerDAL dal, IIDGeneratorService idGeneratorService)
        {
            _dal = dal;
            _idGeneratorService = idGeneratorService;
        }
        public Response CreateMaker(CreateMarkerRequest request)
        {
            try
            {
                request.Marker.MarkerID = _idGeneratorService.GenerateID(request.Marker.MarkerLocation);
                var ds = _dal.CreateMarker(request.Marker);
                var tbl = ds.Tables[0];

                CreateMarkerResponse retval;
                retval = new CreateMarkerResponseOK(request);

                return retval;
            }

            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
    }
}
