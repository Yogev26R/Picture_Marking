using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Marker
{
    public class CreateMarkerResponseOK : CreateMarkerResponse
    {
        public CreateMarkerResponseOK(CreateMarkerRequest request) : base(request) { }
    }
}
