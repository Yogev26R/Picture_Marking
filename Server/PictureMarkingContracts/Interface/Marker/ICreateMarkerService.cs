using Contracts.DTO;
using PictureMarkingContracts.DTO.Marker;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.Interface.Marker
{
    public interface ICreateMarkerService
    {
        public Response CreateMaker(CreateMarkerRequest request);
    }
}
