using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Marker
{
    public class CreateMarkerResponse : Response
    {
        public CreateMarkerRequest Request { get; }

        public CreateMarkerResponse(CreateMarkerRequest request)
        {
            Request = request;
        }
    }
}
